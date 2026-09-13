using System;
using System.Drawing;
using System.Windows.Forms;

namespace el_shabander.pl
{
    /// <summary>
    /// شاشة واحدة مخصصة فقط لإدارة الاشتراك: عرض الرقم التسلسلي، عرض حالة الاشتراك
    /// الحالية، وإدخال كود التفعيل/التجديد. كل منطق الاشتراك بقى في مكان واحد
    /// بدل ما يكون متوزّع جوه شاشة الإعدادات العامة.
    /// لا تعتمد هذه الشاشة على Designer/resx، وكل عناصرها تُنشأ بالكود مباشرة.
    /// </summary>
    public partial class frm_subscription : Form
    {
        private TextBox txt_serial;
        private Button btn_copy_serial;
        private Label lbl_status;
        private TextBox txt_code;
        private Button btn_activate;
        private Button btn_close;

        public frm_subscription()
        {
            InitializeComponent();
            this.Load += frm_subscription_Load;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Text = "الاشتراك في البرنامج";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Font = new Font("Segoe UI", 10F);
            this.ClientSize = new Size(440, 300);

            var lblSerialTitle = new Label
            {
                Text = "الرقم التسلسلي لهذا الجهاز:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txt_serial = new TextBox
            {
                Location = new Point(20, 45),
                Size = new Size(300, 27),
                ReadOnly = true
            };

            btn_copy_serial = new Button
            {
                Text = "نسخ",
                Location = new Point(330, 44),
                Size = new Size(90, 29)
            };
            btn_copy_serial.Click += btn_copy_serial_Click;

            lbl_status = new Label
            {
                Location = new Point(20, 90),
                Size = new Size(400, 50),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };

            var lblCodeTitle = new Label
            {
                Text = "أدخل كود التفعيل / التجديد:",
                Location = new Point(20, 155),
                AutoSize = true
            };

            txt_code = new TextBox
            {
                Location = new Point(20, 180),
                Size = new Size(400, 27)
            };

            btn_activate = new Button
            {
                Text = "تفعيل / تجديد الاشتراك",
                Location = new Point(220, 225),
                Size = new Size(200, 35),
                BackColor = Color.FromArgb(0, 150, 90),
                ForeColor = Color.White
            };
            btn_activate.Click += btn_activate_Click;

            btn_close = new Button
            {
                Text = "إغلاق",
                Location = new Point(20, 225),
                Size = new Size(100, 35)
            };
            btn_close.Click += (s, e) => this.Close();

            this.Controls.Add(lblSerialTitle);
            this.Controls.Add(txt_serial);
            this.Controls.Add(btn_copy_serial);
            this.Controls.Add(lbl_status);
            this.Controls.Add(lblCodeTitle);
            this.Controls.Add(txt_code);
            this.Controls.Add(btn_activate);
            this.Controls.Add(btn_close);

            this.ResumeLayout(false);
        }

        private void frm_subscription_Load(object sender, EventArgs e)
        {
            txt_serial.Text = main.GetSerialNumber();
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            bl.SubscriptionStatus status;
            try
            {
                status = bl.SubscriptionManager.GetStatus();
            }
            catch (Exception ex)
            {
                lbl_status.ForeColor = Color.DarkRed;
                lbl_status.Text = "تعذر قراءة حالة الاشتراك: " + ex.Message;
                return;
            }

            if (!status.HasSubscriptionRecord)
            {
                lbl_status.ForeColor = Color.DimGray;
                lbl_status.Text = "لم يتم تفعيل أي اشتراك بعد على هذا الجهاز.\nأدخل كود التفعيل بالأسفل لبدء الاشتراك.";
                return;
            }

            if (status.TamperDetected)
            {
                lbl_status.ForeColor = Color.DarkRed;
                lbl_status.Text = "تم اكتشاف تغيير في تاريخ الجهاز. برجاء التواصل للدعم.";
                return;
            }

            if (status.IsActive)
            {
                lbl_status.ForeColor = Color.FromArgb(0, 130, 60);
                lbl_status.Text = $"الاشتراك مفعل - متبقي {status.RemainingDays} يوم\n(ينتهي في {status.EndDate:yyyy-MM-dd})";
            }
            else
            {
                lbl_status.ForeColor = Color.DarkRed;
                lbl_status.Text = $"انتهى الاشتراك بتاريخ {status.EndDate:yyyy-MM-dd}.\nبرجاء إدخال كود تجديد.";
            }
        }

        private void btn_copy_serial_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_serial.Text))
            {
                Clipboard.SetText(txt_serial.Text);
                MessageBox.Show("تم نسخ الرقم التسلسلي.", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_activate_Click(object sender, EventArgs e)
        {
            if (bl.SubscriptionManager.TryActivate(txt_code.Text, out string message))
            {
                MessageBox.Show(message, "تم التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_code.Clear();
                RefreshStatus();
            }
            else
            {
                MessageBox.Show(message, "تعذر التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
