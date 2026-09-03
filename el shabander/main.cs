using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using Timer = System.Windows.Forms.Timer;
using DevExpress.XtraBars;
using DevExpress.Utils.VisualEffects;
using System.Media;
using DevExpress.LookAndFeel;
using System.IO;
using System.Data.SqlClient;

namespace el_shabander
{
    public partial class main : Form
    {
       
        pl.frm_cat frm_Cat = new pl.frm_cat();
        pl.frm_supp frm_supp = new pl.frm_supp();
        pl.frm_home frm_home =new pl.frm_home();
        pl.frm_pur frm_Pur = new pl.frm_pur();
        pl.frm_cus frm_cus = new pl.frm_cus();
        pl.frm_sell frm_sell = new pl.frm_sell();
        pl.frm_report frm_report = new pl.frm_report();
        pl.frm_user frm_user = new pl.frm_user();
        pl.frm_stuk frm_stuk = new pl.frm_stuk();
        pl.frm_stor frm_Stor = new pl.frm_stor();
        pl.frm_factory frm_factory = new pl.frm_factory();
        pl.frm_safe_as frm_Safe_As = new pl.frm_safe_as();
        pl.frm_cashbox cashbox = new pl.frm_cashbox();
        private  DateTime trialStartDate;
        private Timer notificationTimer;
        pl.frm_employees frm_Employees = new pl.frm_employees();
        tb_user tB_user = new tb_user();
      
        private System.Timers.Timer emailTimer;
        DB_storeEntities db = new DB_storeEntities();
        
        public main()
        {
            InitializeComponent();

            // Update the user state to "Closed" when the application starts


          

            // تفعيل التمرير العمودي
            CheckUserStatesAtStartup();
            emailTimer = new System.Timers.Timer(Properties.Settings.Default.EmailInterval * 60  * 60 * 1000); // 3 ساعات بالمللي ثانية
            emailTimer.Elapsed += OnTimedEvent;
            emailTimer.AutoReset = true; // إعادة تعيين المؤقت تلقائيًا
            emailTimer.Enabled = true;
            // إنشاء المؤقت لتحديث الإشعارات كل 5 ثوانٍ
            notificationTimer = new Timer();
            notificationTimer.Interval = 3000; // كل 5 ثوانٍ
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();
        }
       
        private void main_Load(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_home.tileControl1);

            frm_home.tileItem1.Frames[0].Elements[1].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem1.Frames[1].Elements[1].Text = db.tb_employees.Count().ToString();
            frm_home.tileItem1.Frames[2].Elements[1].Text = db.tb_cus.Count().ToString();
            //pur
            frm_home.tileItem2.Frames[0].Elements[2].Text = db.tb_pur.Count().ToString();
            frm_home.tileItem2.Frames[1].Elements[2].Text = db.tb_sell.Count().ToString();
            frm_home.tileItem2.Frames[2].Elements[2].Text = db.tb_stuk.Count().ToString();
            //sell
            frm_home.tileItem6.Frames[2].Elements[2].Text = db.tb_pur.Count().ToString();
            frm_home.tileItem6.Frames[0].Elements[2].Text = db.tb_sell.Count().ToString();
            frm_home.tileItem6.Frames[1].Elements[2].Text = db.tb_stuk.Count().ToString();
            //cus
            frm_home.tileItem10.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem10.Frames[2].Elements[2].Text = db.tb_employees.Count().ToString();
            frm_home.tileItem10.Frames[0].Elements[2].Text = db.tb_cus.Count().ToString();
            //car
            frm_home.tileItem4.Frames[2].Elements[2].Text = db.tb_pur.Count().ToString();
            frm_home.tileItem4.Frames[1].Elements[2].Text = db.tb_sell.Count().ToString();
            frm_home.tileItem4.Frames[0].Elements[2].Text = db.tb_stuk.Count().ToString();
            //driver
            frm_home.tileItem7.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem7.Frames[0].Elements[2].Text = db.tb_employees.Count().ToString();
            frm_home.tileItem7.Frames[2].Elements[2].Text = db.tb_cus.Count().ToString();





            lb_titelpage.Text = " EngineeCode ";
            StoreSerialNumber();

            
            main frm_supp_Add = (main)Application.OpenForms["main"];
            if (frm_supp_Add != null)
            {
                // التحقق من أن la_roll يحتوي على قيمة
                if (!string.IsNullOrEmpty(frm_supp_Add.la_roll.Text))
                {
                    // البحث عن المستخدم بناءً على الحالة
                    tB_user = db.tb_user.Where(x => x.user_state == frm_supp_Add.la_roll.Text).FirstOrDefault();

                    // التحقق من حالة المستخدم
                    if (frm_supp_Add.la_roll.Text == "مستخدم")
                    {
                        simpleButton9.Visible = false;
                        simpleButton13.Visible = false;
                        whats.Visible = false;
                        btn_employees.Visible = false;
                        simpleButton1.Visible = false;
                        btn_supp.Visible = false;
                        frm_home.tileItem1.Enabled = false;
                        frm_home.tileItem4.Enabled = false;
                        frm_home.tileItem2.Enabled = false;
                        frm_home.tileItem7.Enabled = false;
                        frm_home.tileItem8.Enabled = false;
                        frm_home.tileItem9.Enabled = false;
                        frm_home.tileItem10.Enabled = false;
                        frm_home.tileItem6.Enabled = false;
                        cashbox.btn_serchcasher.Visible = false;
                        cashbox.edt_namecasher.Visible = false;
                        frm_Stor.btn_delete.Enabled = false;
                        simpleButton2.Visible = false;
                        frm_report.tileItem8.Visible = false;
                        frm_report.tileItem6.Visible = false;
                        frm_report.tileItem7.Visible = false;
                        frm_report.tileItem12.Visible = false;
                        frm_report.tileItem10.Visible = false;
                        frm_report.tileItem5.Visible = false;
                        frm_report.tileItem11.Visible = false;

                    }
                    else if (frm_supp_Add.la_roll.Text == "مدير حسابات")
                    {
                        frm_report.tileItem8.Visible = false;
                        frm_user.btn_add.Enabled = false;

                    }
                }
            }
            if (Properties.Settings.Default.isfirestopen == true)
            {
                Properties.Settings.Default.TrialStartDate = DateTime.Now;
                Properties.Settings.Default.isfirestopen = false;
                Properties.Settings.Default.Save();
            }
            trialStartDate = Properties.Settings.Default.TrialStartDate;
            CheckTrialExpiration(trialStartDate, la_trile);
           
        }
        private  void NotificationTimer_Tick(object sender, EventArgs e)
        {
            CheckForNewNotifications();
            
        }
        private void CheckForNewNotifications()
        {
            try
            {
                // الحصول على التاريخ قبل نصف ثانية

                DateTime oneSecondAgo = DateTime.Now.AddSeconds(-1);

                // التحقق إذا كان جدول Notifications يحتوي على أي بيانات أولاً
                bool tableHasData = db.Notfications.Any();

                if (tableHasData)
                {
                    // التحقق إذا كان هناك إشعارات جديدة في آخر نصف ثانية
                    bool hasNotifications = db.Notfications.Any(n => n.CreatedAt >= oneSecondAgo);

                    if (hasNotifications)
                    {
                        // استرجاع الإشعارات الجديدة في آخر نصف ثانية
                        var notifications = db.Notfications
                                              .Where(n => n.CreatedAt >= oneSecondAgo)
                                              .ToList();

                        if (notifications.Count > 0)
                        {
                            // التأكد من إضافة العدد مرة واحدة فقط
                            int currentCount = int.TryParse(lblNotificationCount.Text, out int parsedCount) ? parsedCount : 0;

                            // تحديث عداد الإشعارات
                            lblNotificationCount.Invoke((MethodInvoker)delegate
                            {
                                lblNotificationCount.Text = (currentCount + notifications.Count).ToString();
                                lblNotificationCount.Visible = true;
                            });

                            // تشغيل صوت الإشعار
                            PlayNotificationSound();
                        }
                    }
                }
                else
                {
                    // إذا لم يحتوي الجدول على بيانات، يمكن التعامل مع الحالة هنا
                    lblNotificationCount.Invoke((MethodInvoker)delegate
                    {
                        lblNotificationCount.Text = "0";
                        lblNotificationCount.Visible = false;
                    });
                }
            }
            catch (Exception ex)
            {
                // معالجة أي أخطاء غير متوقعة

            }
        }

        private void PlayNotificationSound()
        {
            try
            {
                // قم بتحميل ملف الصوت من مسار المشروع أو من مسار محدد
                SoundPlayer player = new SoundPlayer(@"sound\notification.wav");

                // تشغيل الصوت
                player.Play();
            }
            catch (Exception ex)
            {
                // في حالة حدوث خطأ، يمكنك عرض رسالة أو تجاهلها
                MessageBox.Show("حدث خطأ أثناء محاولة تشغيل الصوت: " + ex.Message);
            }
        }


        private void pn_cont_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       




        private void btn_collaps_Click(object sender, EventArgs e)
        {
            if (pn_navbar.Width == 250)
            {
                pn_navbar.Width = 50;
                pn_titelnavbar.Visible = false;
               pn_headernavbar.Height = 150;
            }
            else
            {
                pn_navbar.Width = 250;
                pn_titelnavbar.Visible = true;
                pn_headernavbar.Height = 200;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_home.tileControl1);
            //supp
            frm_home.tileItem1.Frames[0].Elements[1].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem1.Frames[1].Elements[1].Text = db.tb_employees.Count().ToString();
            frm_home.tileItem1.Frames[2].Elements[1].Text = db.tb_cus.Count().ToString();
            //pur
            frm_home.tileItem2.Frames[0].Elements[2].Text = db.tb_pur.Count().ToString();
            frm_home.tileItem2.Frames[1].Elements[2].Text = db.tb_sell.Count().ToString();
            frm_home.tileItem2.Frames[2].Elements[2].Text = db.tb_stuk.Count().ToString();
            //sell
            frm_home.tileItem6.Frames[2].Elements[2].Text = db.tb_pur.Count().ToString();
            frm_home.tileItem6.Frames[0].Elements[2].Text = db.tb_sell.Count().ToString();
            frm_home.tileItem6.Frames[1].Elements[2].Text = db.tb_stuk.Count().ToString();
            //cus
            frm_home.tileItem10.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem10.Frames[2].Elements[2].Text = db.tb_employees.Count().ToString();
            frm_home.tileItem10.Frames[0].Elements[2].Text = db.tb_cus.Count().ToString();
            //car
            frm_home.tileItem4.Frames[2].Elements[2].Text = db.tb_pur.Count().ToString();
            frm_home.tileItem4.Frames[1].Elements[2].Text = db.tb_sell.Count().ToString();
            frm_home.tileItem4.Frames[0].Elements[2].Text = db.tb_stuk.Count().ToString();
            //driver
            frm_home.tileItem7.Frames[1].Elements[2].Text = db.tb_supp.Count().ToString();
            frm_home.tileItem7.Frames[0].Elements[2].Text = db.tb_employees.Count().ToString();
            frm_home.tileItem7.Frames[2].Elements[2].Text = db.tb_cus.Count().ToString();

            db = new DB_storeEntities();
            lb_titelpage.Text = " EngineeCode ";
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Cat.pn_cat);
            db = new DB_storeEntities();
            frm_Cat.updata_data();
            lb_titelpage.Text = "الاصناف";
           //frm_Cat.gridControl1.DataSource = db.TB_cat.ToList();
        
        }

        private void pn_topbar_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private async void btn_close_Click_1(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("هل تريد اخذ نسخة احتياطية", "عملية نسخ", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {

                FolderBrowserDialog folder = new FolderBrowserDialog();
                var rb = folder.ShowDialog();
                if (rb == DialogResult.OK)
                {

                    var result = await Task.Run(() => BackUp(folder));

                    if (result)
                    {
                        MessageBox.Show("تم النسخ بنجاح");
                        UpdateUserState("مغلق");

                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("هناك مشكلة في عملية النسخ. حاول تغيير المسار وتجنب اختيار برتشن النسخة.");
                    }
                }
            }
            else
            {
                UpdateUserState("مغلق");

                Application.Exit();
            }


        }
        private bool BackUp(FolderBrowserDialog folder)
        {
            try
            {
                using (var db = new DB_storeEntities())
                {
                    string dbname = db.Database.Connection.Database;
                    string dbbackup = "DMMback" + DateTime.Now.ToString("yyyyMMddHHmm");
                    var fullpath = Path.Combine(folder.SelectedPath, dbbackup + ".bak");

                    // يمكنك اختيار أحد الخيارين بناءً على حاجتك:
                    // استخدم FORMAT إذا كنت تريد تهيئة النسخة الاحتياطية الجديدة (كتابة فوق النسخة القديمة)
                    // استخدم NOINIT إذا كنت تريد إلحاق النسخة الجديدة بالنسخ الاحتياطية السابقة

                    // في هذا المثال، سأستخدم FORMAT
                    string sqlcommand = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}' WITH FORMAT, NAME = N'DB_store', SKIP, NOREWIND, STATS = 10", dbname, fullpath);

                    db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, sqlcommand);
                }

                return true;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"خطأ أثناء عملية النسخ الاحتياطي للقاعدة: {sqlEx.Message}\n{sqlEx.StackTrace}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء عملية النسخ الاحتياطي: {ex.Message}");
                return false;
            }
        }
        private void btn_max_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
               
            }
        }

        private void btn_min_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_supp_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_supp.pn_cat);
            db = new DB_storeEntities();
            frm_supp.updata_data();
            lb_titelpage.Text = "الموردين";
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (lb_titelpage.Text == "المشتريات")
            {
                return;
            }
            string passwordInput = ShowPasswordDialog("تأكيد كلمة المرور", "الرجاء إدخال كلمة المرور:");
            if (passwordInput == "CANCELLED")
            {
                MessageBox.Show("تم إلغاء الدخول.");
                return; // يوقف تنفيذ باقي الكود
            }
            var tB_user = db.tb_user
                              .Where(x => x.user_name == la_username.Text
                                       && x.user_pass == passwordInput)
                              .FirstOrDefault();

            if (tB_user != null)
            {
                pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Pur.pn_cat);
            db = new DB_storeEntities();
            frm_Pur.updata_data();
            lb_titelpage.Text = "المشتريات";
            }
            else
            {
                MessageBox.Show("كلمة المرور غير صحيحة.");
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_cus.pn_cat);
            db = new DB_storeEntities();
            frm_cus.updata_data();
            lb_titelpage.Text = "العملاء";
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_sell.pn_cat);
            db = new DB_storeEntities();
            frm_sell.updata_data();
            lb_titelpage.Text = "المبيعات";
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (lb_titelpage.Text == "التقارير")
            {
                return;
            }
            string passwordInput = ShowPasswordDialog("تأكيد كلمة المرور", "الرجاء إدخال كلمة المرور:");
            if (passwordInput == "CANCELLED")
            {
                MessageBox.Show("تم إلغاء الدخول.");
                return; // يوقف تنفيذ باقي الكود
            }
            var tB_user = db.tb_user
                              .Where(x => x.user_name == la_username.Text 
                                       && x.user_pass == passwordInput)
                              .FirstOrDefault();

            if (tB_user != null)
            {
                pn_cont.Controls.Clear();
                pn_cont.Controls.Add(frm_report.tileControl1);
                db = new DB_storeEntities();

                lb_titelpage.Text = "التقارير";
            }
            else
            {
                MessageBox.Show("كلمة المرور غير صحيحة.");
            }

        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (lb_titelpage.Text == "المستخدمين")
            {
                return;
            }
            string passwordInput = ShowPasswordDialog("تأكيد كلمة المرور", "الرجاء إدخال كلمة المرور:");
            if (passwordInput == "CANCELLED")
            {
                MessageBox.Show("تم إلغاء الدخول.");
                return; // يوقف تنفيذ باقي الكود
            }
            var tB_user = db.tb_user
                              .Where(x => x.user_name == la_username.Text
                                       && x.user_pass == passwordInput)
                              .FirstOrDefault();

            if (tB_user != null)
            {
                pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_user.pn_cat);
            db = new DB_storeEntities();
            frm_user.updata_data();
            lb_titelpage.Text = "المستخدمين";
            }
            else
            {
                MessageBox.Show("كلمة المرور غير صحيحة.");
            }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            pl.frm_settingpro frm_settingpro = new pl.frm_settingpro();
            frm_settingpro.Show();
          
           
        }
       
        private void btn_logout_Click(object sender, EventArgs e)
        {
            pl.frm_login login = new pl.frm_login();

            UpdateUserState("مغلق");
            Application.Restart();

        }
        public static string ShowPasswordDialog(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Width = 250;
            textBox.PasswordChar = '*'; // لإخفاء النص كنقاط

            buttonOk.Text = "موافق";
            buttonCancel.Text = "إلغاء";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text : "CANCELLED";
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (lb_titelpage.Text == "المخزن")
            {
                return;
            }
            string passwordInput = ShowPasswordDialog("تأكيد كلمة المرور", "الرجاء إدخال كلمة المرور:");
            if (passwordInput == "CANCELLED")
            {
                MessageBox.Show("تم إلغاء الدخول.");
                return; // يوقف تنفيذ باقي الكود
            }
            var tB_user = db.tb_user
                              .Where(x => x.user_name == la_username.Text 
                                       && x.user_pass == passwordInput)
                              .FirstOrDefault();
                           
            if (tB_user != null)
            {
                pn_cont.Controls.Clear();
                pn_cont.Controls.Add(frm_stuk.pn_cat);
                db = new DB_storeEntities();
                frm_stuk.updata_data();
                lb_titelpage.Text = "المخزن";
            }
            else
            {
                MessageBox.Show("كلمة المرور غير صحيحة.");
            }
        }
        public  List<tb_sellpop> list_sellpop;
        public List<tb_sell> list_sell;
        public List<tb_pur> list_pur;
        public List<tb_supp> list_supp;
        public List<tb_cus> list_cus;
        public List<tb_stuk> list_cat;
        private void main_Activated(object sender, EventArgs e)
        {
             list_cat = db.tb_stuk.ToList();
            UpdateUserState("مفتوح");
            
           
        }

        private void btn_employees_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Employees.pn_cat);
            db = new DB_storeEntities();
            frm_Employees.updata_data();
            lb_titelpage.Text = "الموظفين";
        }

        private void btn_stor_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Stor.pn_cat);
            db = new DB_storeEntities();
            frm_Stor.updata_data();
            lb_titelpage.Text = "المصاريف";
        }

        public tb_user CurrentUser { get; set; }
        private void UpdateUserState(string state)
        {

                if (CurrentUser != null)
                {
                    CurrentUser.user_state = state;
                    db.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

           
            
        }
        private void CheckUserStatesAtStartup()
        {
           
            try
            {
                bool hasUsers = db.tb_user.Any();
                if (!hasUsers)
                {
                    // إذا لم يتم العثور على مستخدم بحالة "مفتوح"
                    pl.frm_user_add frm_Setting = new pl.frm_user_add();
                    frm_Setting.ShowDialog();
                }
                if (Properties.Settings.Default.darkmode == true)
                {
                    UserLookAndFeel.Default.SetSkinStyle("Office 2019 Black");
                   
                   pn_headernavbar.BackColor = Color.Black;
                    pn_topbar.BackColor = Color.Black;
                    flowLayoutPanel1.BackColor = Color.Black;
                }
                else
                {
                   
                    pn_headernavbar.BackColor = Color.FromArgb(64, 64, 64);
                   pn_topbar.BackColor = Color.FromArgb(64, 64, 64);
                   flowLayoutPanel1.BackColor = Color.FromArgb(64, 64, 64);
                    UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");

                }
            }
            catch 
            {
                // في حالة حدوث خطأ أثناء محاولة الاتصال بقاعدة البيانات أو الاستعلام
                MessageBox.Show("فشل الاتصال بقاعدة البيانات أو حدوث خطأ في الاستعلام. سيتم فتح نافذة الإعدادات.");
                pl.frm_setting frm_Setting = new pl.frm_setting();
                frm_Setting.ShowDialog();
            }
        }
        public static string GetSerialNumber()
        {
            try
            {
                // الحصول على سيريال نمبر للجهاز
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["SerialNumber"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting serial number: " + ex.Message);
            }
            return null;
        }
        private  void CheckTrialExpiration(DateTime trialStartDate, Label label)
        {
            // هنا يمكنك تنفيذ منطق لفحص فترة التجربة باستخدام السيريال نمبر وتاريخ بدء الفترة التجريبية
            // هذا مجرد مثال بسيط على كيفية الفحص
            // DateTime trialStartDate = DateTime.Parse("2024-05-17");
           
            DateTime currentDate = DateTime.Now;
          //  trialStartDate = currentDateTime.AddMinutes(2);
            TimeSpan trialPeriod = currentDate - trialStartDate;
           
            
            int trialDays = 7; // 7 أيام
            string currentSerial = Properties.Settings.Default.serail;

            string licenseKey = Encrypt(currentSerial, "omran");

            if (Properties.Settings.Default.license == licenseKey)
            {
                label.Text = "مفعل";
            }
            else
            {
                if (trialPeriod.TotalDays > trialDays)
                {
                    // يمكنك هنا تنفيذ الإجراءات اللازمة عند انتهاء فترة التجربة
                    MessageBox.Show("انتهت فترة التجربة.");

                    simpleButton13.Enabled = false;
                    whats.Enabled = true;
                    btn_employees.Enabled = false;
                    btn_stor.Enabled = false;
                    simpleButton1.Enabled = false;
                    simpleButton12.Enabled = false;
                    simpleButton11.Enabled = false;
                    simpleButton10.Enabled = false;
                    simpleButton4.Enabled = false;
                    simpleButton9.Enabled = false;
                    btn_supp.Enabled = false;
                    simpleButton7.Enabled = false;
                    btn_factory.Enabled = false;
                    frm_home.tileItem1.Enabled = false;
                    frm_home.tileItem4.Enabled = false;
                    frm_home.tileItem2.Enabled = false;
                    frm_home.tileItem7.Enabled = false;
                    frm_home.tileItem8.Enabled = false;
                    frm_home.tileItem9.Enabled = false;
                    frm_home.tileItem10.Enabled = false;
                    frm_home.tileItem6.Enabled = false;
                    simpleButton2.Enabled = false;

                    label.Text = "انتهت الفترة التجريبية";
                }
                else
                {

                    // حساب الأيام المتبقية
                    int remainingDays = (int)(trialDays - trialPeriod.TotalDays);
                    // تحديث النص في الليبل
                    label.Text = $"الأيام المتبقية: {remainingDays} يوم";

                }
                
            }
        }
        private void StoreSerialNumber()
        {
            string serialNumber = GetSerialNumber();
            if (!string.IsNullOrEmpty(serialNumber))
            {
                if (Properties.Settings.Default.serail != serialNumber)
                {
                    Properties.Settings.Default.serail = serialNumber;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                MessageBox.Show("خطأ في الحصول على السيريال نمبر.");
            }
        }
        private string Encrypt(string input, string key)
        {
            // تحويل النص إلى مصفوفة بايت
            byte[] data = Encoding.UTF8.GetBytes(input);

            // تحويل المفتاح إلى مصفوفة بايت
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            // التشفير باستخدام مفتاح السري
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= keyBytes[i % keyBytes.Length];
            }

            // تحويل المصفوفة المشفرة إلى سلسلة نصية
            return Convert.ToBase64String(data);
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateUserState("مغلق");
            
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
           
            frm_cus.SendEmailWithHtmlGridData();
            frm_sell.SendEmailWithHtmlGridData();
            frm_supp.SendEmailWithHtmlGridData();
            frm_Pur.SendEmailWithHtmlGridData();

        }
        private void btn_factory_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_factory.pn_cat);
            db = new DB_storeEntities();
            frm_factory.updata_data();
            lb_titelpage.Text = "المصنع";
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
           
            
            lblNotificationCount.Visible = false;
            lblNotificationCount.Text = "0";
            // التحقق مما إذا كان نموذج الإشعارات مفتوحًا بالفعل
            foreach (Form form in Application.OpenForms)
            {
                if (form is epl.notifaction)
                {
                    // إذا كان النموذج مفتوحًا، قم بإغلاقه
                    form.Close();
                    return; // الخروج من الدالة
                }
            }

            // إنشاء نموذج الإشعارات
            epl.notifaction notificationForm = new epl.notifaction();
            notificationForm.updata_data();

            // تعيين موقع النموذج ليظهر تحت الزر وفي منتصفه
            notificationForm.StartPosition = FormStartPosition.Manual;

            // الحصول على موقع الزر وحجم النموذج
            Point buttonLocation = btn_note.PointToScreen(Point.Empty); // تحويل موقع الزر إلى إحداثيات الشاشة
            int formWidth = notificationForm.Width;
            int buttonWidth = btn_note.Width;

            // حساب الموقع الجديد للنموذج بحيث يكون في منتصف الزر من الأسفل
            int newX = buttonLocation.X + (buttonWidth / 2) - (formWidth / 2);
            int newY = buttonLocation.Y + btn_note.Height;

            // تعيين موقع النموذج الجديد
            notificationForm.Location = new Point(newX, newY);

            // تعيين خاصية RightToLeft للنموذج
            notificationForm.RightToLeft = RightToLeft.Yes;

            // عرض النموذج
            notificationForm.Show();
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession == null)
                {
                    MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                    return;
                }
                var tb_cus = db.tb_cus.ToList();
                if (!tb_cus.Any())
                {
                    MessageBox.Show("الرجاء اضافة عملاء", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // الخروج من العملية إذا لم يتم العثور على العميل
                }
                var tbstuck = db.tb_stuk.ToList();
                if (!tbstuck.Any())
                {
                    MessageBox.Show("الرجاء اضافة اصناف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // الخروج من العملية إذا لم يتم العثور على العميل
                }
                pl.frm_sell_add frm_supp_Add = new pl.frm_sell_add();
                frm_supp_Add.id = 0;
                // frm_supp_Add.btn_save.Text = "إضافة"; // يجب أن يكون btn_save وليس btn_add
                frm_supp_Add.Show();
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            if (lb_titelpage.Text == "الخزينة")
            {
                return;
            }
            string passwordInput = ShowPasswordDialog("تأكيد كلمة المرور", "الرجاء إدخال كلمة المرور:");
            if (passwordInput == "CANCELLED")
            {
                MessageBox.Show("تم إلغاء الدخول.");
                return; // يوقف تنفيذ باقي الكود
            }
            var tB_user = db.tb_user
                              .Where(x => x.user_name == la_username.Text
                                       && x.user_pass == passwordInput)
                              .FirstOrDefault();

            if (tB_user != null)
            {
                pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_Safe_As.pn_cat);
            db = new DB_storeEntities();
            frm_Safe_As.updata_data();
            lb_titelpage.Text = "الخزينة";
            }
            else
            {
                MessageBox.Show("كلمة المرور غير صحيحة.");
            }
        }

        private void whats_Click(object sender, EventArgs e)
        {
            pl.frm_whats frm_settingpro = new pl.frm_whats();
            frm_settingpro.Show();
        }
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;
        private void pn_topbar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pn_topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void pn_topbar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(cashbox.pn_cat);
            db = new DB_storeEntities();
            cashbox.updata_data();
            lb_titelpage.Text = "الكاش بوكس";
        }
    }

}
