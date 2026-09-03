using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using System.Threading;
using el_shabander.epl;
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_calc_sell : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
       tb_stuk tb_stuk = new tb_stuk();
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_sell()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            // report1.la_cus_price.Text = tb_stuk.total_price.ToString();
            FetchAndCombineData();
           

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }





        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
            ApplyArabicCulture();

            // ضبط DateTimePicker
            SetArabicDateFormat(edt_from);
            SetArabicDateFormat(edt_to);
            // edt_to.Text=(DateTime.Now).ToString();
        }

        private void ApplyArabicCulture()
        {
            CultureInfo arabicCulture = new CultureInfo("ar-EG");
            Thread.CurrentThread.CurrentCulture = arabicCulture;
            Thread.CurrentThread.CurrentUICulture = arabicCulture;
        }
        private void SetArabicDateFormat(DateTimePicker picker)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = GetArabicFormattedDate(picker.Value);

            // إجبار النصوص على أن تكون باللغة العربية وعدم الانعكاس
            picker.RightToLeft = RightToLeft.No;
            picker.RightToLeftLayout = false;

            // تحديث عند تغيير التاريخ
            picker.ValueChanged += (s, e) =>
            {
                picker.CustomFormat = GetArabicFormattedDate(picker.Value);
            };
        }

        // دالة لتنسيق التاريخ يدويًا باللغة العربية
        private string GetArabicFormattedDate(DateTime date)
        {
            string[] arabicDays = { "الأحد", "الإثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            string[] arabicMonths = { "", "يناير", "فبراير", "مارس", "أبريل", "مايو", "يونيو", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر" };

            string dayName = arabicDays[(int)date.DayOfWeek];
            string monthName = arabicMonths[date.Month];

            return $"{dayName}, {date.Day} {monthName} {date.Year}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        public void FetchAndCombineData()
        {
            DateTime fromDate = edt_from.Value.Date;
            DateTime toDate = edt_to.Value.Date;

            var sells = db.tb_sell
                .ToList() // ← هنا بنحول الاستعلام لـ LINQ to Objects علشان نقدر نستخدم .Date
                .Where(x => x.sell_date.HasValue &&
                            x.sell_date.Value.Date >= fromDate &&
                            x.sell_date.Value.Date <= toDate)
                .Select(x => new
                {
                    cus_name = x.sell_cus,
                    Date = x.sell_date,
                    totall = x.total_sell,
                    PaidAmount = x.pay,
                    Remaining = x.stay
                }).ToList();

            frm_report_view14 reportForm = new frm_report_view14();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_sell"].Clear();
            var totalPaidAmount =sells.Sum(x => x.PaidAmount);
            var PreviousBalance =sells.Sum(x => x.Remaining);
           
            tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_from.Text).FirstOrDefault();
            
            string customername = edt_from.Text;
            string customername1 = edt_to.Text;
            string totallsum1 = (totalPaidAmount).ToString();
            string totallsum2 = (PreviousBalance).ToString();
            foreach (var item in sells)
            {
                dataSet.Tables["tb_sell"].Rows.Add(item.cus_name, item.Date, item.totall, item.PaidAmount, item.Remaining);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_sell"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(customername, customername1, totallsum1, totallsum2);
            this.Close();
            reportForm.ShowDialog();



        }

        private void frm_calc_earning_Load(object sender, EventArgs e)
        {
            edt_to.Text = (DateTime.Now).ToString();
            edt_from.Text = (DateTime.Now).ToString();
        }
    }
}