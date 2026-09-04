using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using el_shabander.bl;

namespace el_shabander.pl
{
    /// <summary>
    /// كنترول يعرض شارت سعر الذهب كخط اتجاه واحد بس (من غير نقاط/Points)، زي شاشات
    /// منصات التداول: بيتلوّن أخضر لما السعر يرتفع خلال المدة المختارة وأحمر لما ينزل.
    /// بيتحط تحت جدول الأسعار مباشرة في شاشة "أسعار الذهب" (ucGoldPrice) بدل ما يتفتح
    /// في نافذة منفصلة بزرار. بيتحدث نفسه تلقائيًا كل دقيقة زي جدول السعر بالظبط.
    /// </summary>
    public partial class ucGoldPriceChart : UserControl
    {
        private static readonly (string Karat, string Label)[] Karats = new[]
        {
            ("24", "عيار 24"),
            ("22", "عيار 22"),
            ("21", "عيار 21"),
            ("18", "عيار 18"),
            ("14", "عيار 14"),
        };

        private const int MaxChartPoints = 300;

        private System.Windows.Forms.Timer refreshTimer;

        private ChartControl chart;
        private Series lineSeries;
        private DevExpress.XtraEditors.RadioGroup rgKarat;
        private DevExpress.XtraEditors.RadioGroup rgSide;
        private DevExpress.XtraEditors.RadioGroup rgPeriod;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private Label lblStatus;
        private Label lblLastValue;

        public ucGoldPriceChart()
        {
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            BuildLayout();
            _ = LoadAndDrawAsync();

            refreshTimer = new System.Windows.Forms.Timer { Interval = 60000 }; // تحديث تلقائي كل دقيقة، زي جدول السعر
            refreshTimer.Tick += async (s, e) => await LoadAndDrawAsync();
            refreshTimer.Start();
            this.Disposed += (s, e) => refreshTimer?.Stop();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "ucGoldPriceChart";
            this.Dock = DockStyle.Fill;
            this.ResumeLayout(false);
        }

        // ===================== بناء الواجهة =====================
        private void BuildLayout()
        {
            this.Controls.Clear();

            // ---- شريط الفلاتر العلوي ----
            var pnlFilters = new Panel { Dock = DockStyle.Top, Height = 96, Padding = new Padding(10) };

            rgKarat = new DevExpress.XtraEditors.RadioGroup
            {
                Location = new Point(10, 8),
                Width = 300,
                Height = 36
            };
            rgKarat.Properties.Items.Clear();
            foreach (var (karat, label) in Karats)
                rgKarat.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(karat, label));
            rgKarat.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            rgKarat.SelectedIndex = 2; // عيار 21 هو الافتراضي
            rgKarat.SelectedIndexChanged += async (s, e) => await LoadAndDrawAsync();

            rgSide = new DevExpress.XtraEditors.RadioGroup
            {
                Location = new Point(10, 50),
                Width = 160,
                Height = 32
            };
            rgSide.Properties.Items.Clear();
            rgSide.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "سعر البيع"));
            rgSide.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "سعر الشراء"));
            rgSide.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            rgSide.SelectedIndex = 0;
            rgSide.SelectedIndexChanged += async (s, e) => await LoadAndDrawAsync();

            rgPeriod = new DevExpress.XtraEditors.RadioGroup
            {
                Location = new Point(360, 8),
                Width = 400,
                Height = 36
            };
            rgPeriod.Properties.Items.Clear();
            rgPeriod.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "اليوم"));
            rgPeriod.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "آخر أسبوع"));
            rgPeriod.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "آخر شهر"));
            rgPeriod.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "كل المدة"));
            rgPeriod.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            rgPeriod.SelectedIndex = 1;
            rgPeriod.SelectedIndexChanged += async (s, e) => await LoadAndDrawAsync();

            btnRefresh = new DevExpress.XtraEditors.SimpleButton
            {
                Text = "تحديث",
                Location = new Point(360, 52),
                Width = 110,
                Height = 30
            };
            btnRefresh.Click += async (s, e) => await LoadAndDrawAsync();

            lblLastValue = new Label
            {
                Location = new Point(480, 50),
                Width = 400,
                Height = 32,
                Font = new Font("Cairo", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            pnlFilters.Controls.Add(rgKarat);
            pnlFilters.Controls.Add(rgSide);
            pnlFilters.Controls.Add(rgPeriod);
            pnlFilters.Controls.Add(btnRefresh);
            pnlFilters.Controls.Add(lblLastValue);

            // ---- الشارت ----
            chart = new ChartControl { Dock = DockStyle.Fill };
            BuildSeries();

            // ---- شريط الحالة ----
            lblStatus = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 26,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkOrange,
                Font = new Font("Cairo", 9.5F, FontStyle.Regular)
            };

            this.Controls.Add(chart);
            this.Controls.Add(lblStatus);
            this.Controls.Add(pnlFilters);
        }

        /// <summary>
        /// بيبني خط الشارت بس (سيريز واحد من نوع Line، من غير أي سيريز نقاط/Points)،
        /// زي شاشات منصات التداول: خط واحد بيتلوّن أخضر أو أحمر حسب اتجاه السعر
        /// خلال المدة المختارة، من غير ما يبقى فيه أي نقط/دوائر على الخط.
        /// </summary>
        private void BuildSeries()
        {
            chart.Series.Clear();
            chart.Legends.Clear();

            lineSeries = new Series("trend", ViewType.Line) { ArgumentScaleType = ScaleType.DateTime };
            var lineView = (LineSeriesView)lineSeries.View;
            lineView.LineStyle.Thickness = 2;
            lineView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False; // من غير نقاط على الخط
            lineView.Color = Color.FromArgb(120, 90, 10);

            chart.Series.Add(lineSeries);

            var diagram = (XYDiagram)chart.Diagram;
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Automatic;
            diagram.AxisX.Label.TextPattern = "{A:dd/MM HH:mm}";
            diagram.AxisX.Title.Text = "التاريخ والوقت";
            diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            diagram.AxisY.NumericScaleOptions.AutoGrid = true;
            diagram.AxisY.Title.Text = "السعر ج.م";
            diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

            chart.Legend.Visible = false;
        }

        // ===================== تحميل البيانات ورسمها =====================
        private async System.Threading.Tasks.Task LoadAndDrawAsync()
        {
            try
            {
                btnRefresh.Enabled = false;
                lblStatus.Text = "جاري تحميل البيانات...";
                lblStatus.ForeColor = Color.DarkOrange;

                string karat = rgKarat.EditValue?.ToString() ?? "21";
                bool sell = rgSide.EditValue is bool b ? b : true;
                int periodIndex = rgPeriod.EditValue is int i ? i : 1;

                DateTime? fromUtc;
                switch (periodIndex)
                {
                    case 0: fromUtc = DateTime.UtcNow.Date; break;
                    case 1: fromUtc = DateTime.UtcNow.AddDays(-7); break;
                    case 2: fromUtc = DateTime.UtcNow.AddMonths(-1); break;
                    default: fromUtc = null; break; // كل المدة
                }

                var history = await GoldPriceHistoryRepository.GetHistoryAsync(fromUtc);

                var series = history
                    .Select(p => (Time: p.CapturedAtUtc.ToLocalTime(), Price: p.GetPrice(karat, sell)))
                    .ToList();

                var downsampled = Downsample(series, MaxChartPoints);

                lineSeries.Points.Clear();
                foreach (var point in downsampled)
                    lineSeries.Points.Add(new SeriesPoint(point.Time, (double)point.Price));

                var lineView = (LineSeriesView)lineSeries.View;

                if (downsampled.Count == 0)
                {
                    lblStatus.Text = "لا يوجد سجل أسعار محفوظ لهذه المدة بعد، سيبدأ التسجيل تلقائيًا من الآن.";
                    lblLastValue.Text = "";
                    lineView.Color = Color.FromArgb(120, 90, 10);
                }
                else
                {
                    var first = downsampled.First().Price;
                    var last = downsampled.Last().Price;
                    var changePct = first == 0 ? 0 : (last - first) / first * 100M;
                    var arrow = last > first ? "▲" : (last < first ? "▼" : "―");
                    var trendColor = last > first
                        ? Color.FromArgb(46, 125, 50)   // أخضر: ارتفع
                        : (last < first ? Color.FromArgb(198, 40, 40) : Color.FromArgb(120, 90, 10)); // أحمر: نزل / ثابت

                    lblLastValue.Text = $"آخر سعر: {last.ToString("N0", CultureInfo.InvariantCulture)} جنيه   {arrow} {Math.Abs(changePct).ToString("N2")}%";
                    lblLastValue.ForeColor = trendColor;
                    lblStatus.Text = $"عدد النقاط المعروضة: {downsampled.Count}";
                    lblStatus.ForeColor = Color.Gray;

                    // بنلوّن الخط كله حسب اتجاه السعر خلال المدة، زي شاشات التداول
                    lineView.Color = trendColor;
                }
            }
            catch (Exception)
            {
                lblStatus.Text = "تعذر تحميل سجل الأسعار، تأكد من الاتصال بقاعدة البيانات.";
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnRefresh.Enabled = true;
            }
        }

        /// <summary>
        /// بيقلل عدد النقاط لأقصى حد معقول للشارت عن طريق تقسيم المدة لدلاء زمنية متساوية،
        /// وياخد آخر قراءة في كل دلو (زي إغلاق الشمعة). مهم عشان "آخر أسبوع/شهر" ما يبقاش فيها
        /// آلاف النقاط (السعر بيتسجل كل دقيقة).
        /// </summary>
        private static List<(DateTime Time, decimal Price)> Downsample(List<(DateTime Time, decimal Price)> series, int maxPoints)
        {
            if (series.Count <= maxPoints)
                return series;

            var span = series[series.Count - 1].Time - series[0].Time;
            if (span <= TimeSpan.Zero)
                return series;

            var bucketSpan = TimeSpan.FromTicks(span.Ticks / maxPoints);
            if (bucketSpan <= TimeSpan.Zero)
                return series;

            var result = new List<(DateTime, decimal)>();
            var bucketStart = series[0].Time;
            (DateTime Time, decimal Price)? lastInBucket = null;

            foreach (var point in series)
            {
                if (point.Time - bucketStart > bucketSpan)
                {
                    if (lastInBucket.HasValue) result.Add(lastInBucket.Value);
                    bucketStart = point.Time;
                }
                lastInBucket = point;
            }
            if (lastInBucket.HasValue) result.Add(lastInBucket.Value);

            return result;
        }
    }
}