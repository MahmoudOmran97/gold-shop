using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.CodeParser;
using DevExpress.DataAccess.Native.Excel;
using el_shabander.epl;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Net.Mail;
using System.Net;

namespace el_shabander.pl
{
    public partial class frm_pur_add: Form
    {
        gold_shopEntities db = new gold_shopEntities();
        tb_stuk tb_stuk = new tb_stuk();
        tb_pur tb_Pur = new tb_pur();
       // bl.methods methods = new bl.methods();
        tb_supp tb_Supp = new tb_supp();
        tb_safe tb_Safe = new tb_safe();
        Notfication notfication = new Notfication();
        DataTable datasells = new DataTable();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        double qtp, qtn, qtr, qts;
        double oldamount = 0;
        int selectrowindex;
        double curnt, prives;
        tb_ordersellpop tb_Ordersell = new tb_ordersellpop();
        private bool saveButtonClicked = false;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_pur_add ()

        {
            InitializeComponent();
        }
        public List<tb_ordersellpop> listorder;
       

        

       

       

       

      

      

        private void frm_pur_add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            comboBox1.Text = "اجل";
           
            if (id == 0)
            {

                datasells.Columns.Add("اسم المادة");
                datasells.Columns.Add("سعر الجرام");
                datasells.Columns.Add("الوحدة");
                datasells.Columns.Add("الوزن");
                datasells.Columns.Add("(21)الوزن");
                datasells.Columns.Add("الاجمالى");
                datasells.Columns.Add("العيار");
                dataGridView1.DataSource = datasells;
                dataGridView1.DefaultCellStyle.Font = new Font("cairo", 14);  // تكبير حجم الخط إلى 16
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);  // تكبير خط رؤوس الأعمدة
                dataGridView1.ReadOnly = true;
                // تكبير المسافة بين الصفوف
                dataGridView1.RowTemplate.Height = 30;
              
                save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
                var r1 = db.tb_stuk.Select(x => x.stuk_name).ToList();
                var r2 = db.tb_supp.Select(x => x.supp_name).ToList();

                edt_name.DataSource = r1;
                edt_supp.DataSource = r2;

                AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();

                acsc1.AddRange(r1.ToArray());
                acsc2.AddRange(r2.ToArray());

                edt_name.AutoCompleteCustomSource = acsc1;
                edt_supp.AutoCompleteCustomSource = acsc2;

                edt_date.Text = (DateTime.Now).ToString();
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                // edt_big.ReadOnly = true;
                // big.Checked = true;
                // unit_small.Enabled = false;
                pro_call();
              
                saveButtonClicked = false;
            }
            else
            {
                datasells.Columns.Add("اسم المادة");
                datasells.Columns.Add("سعر الجرام");
                datasells.Columns.Add("الوحدة");
                datasells.Columns.Add("الوزن");
                datasells.Columns.Add("(21)الوزن");
                datasells.Columns.Add("الاجمالى");
                datasells.Columns.Add("العيار");
                dataGridView1.DataSource = datasells;
                dataGridView1.DefaultCellStyle.Font = new Font("cairo", 14);  // تكبير حجم الخط إلى 16
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);  // تكبير خط رؤوس الأعمدة
                dataGridView1.ReadOnly = true;
                // تكبير المسافة بين الصفوف
                dataGridView1.RowTemplate.Height = 30;
                listorder = db.tb_ordersellpop.Where(x => x.sell_id == id).ToList();
                edt_supp.Enabled = false;
                groupControl3.Visible = true;
               
                var r2 = db.tb_supp.Select(x => x.supp_name).ToList();

                edt_chancus.DataSource = r2;

                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();

                acsc2.AddRange(r2.ToArray());

                edt_chancus.AutoCompleteCustomSource = acsc2;

                // save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
                for (int i = 0; i < listorder.Count; i++)
                {
                    //tb_Ordersell.sell_id = tB_sell.id;
                    datasells.Rows.Add(listorder[i].name_sell,
                        listorder[i].price_sell, listorder[i].wight, listorder[i].qt_sell,
                        listorder[i].tprice_sell, listorder[i].sell_price_sell);

                }
                dataGridView1.DataSource = datasells;
                tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                //edt_staybehaver.Text = (tb_Supp.total_price - Convert.ToDouble(txt_totaldata.Text) + Convert.ToDouble(edt_pay.Text)).ToString();
               /* tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();*/
                var r1 = db.tb_stuk.Select(x => x.stuk_name).ToList();
                edt_name.DataSource = r1;
                AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                acsc1.AddRange(r1.ToArray());
                edt_name.AutoCompleteCustomSource = acsc1;
                oldamount = Convert.ToDouble(edt_pay.Text);

                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                var tb_pur = db.tb_pur.Where(x => x.id == id).FirstOrDefault();
                var tb_supp = db.tb_supp.Where(x => x.id == tb_Pur.supp_id).FirstOrDefault();
                curnt = Convert.ToDouble(tb_pur.stay);
                edt_staybehaver.Text = tb_pur.supp_price.ToString();
                edt_date.Text = tb_pur.pur_dat.ToString();
                invice_id.Visible = true;
                invice_id.Text = tb_pur.invocie_id.ToString();
                chack.Text = curnt.ToString();
                txt_id.Text = id.ToString();
                pro_call();
              

                saveButtonClicked = false;
            }

        }

        private void frm_pur_add_Activated(object sender, EventArgs e)
        {
           
            

        }

       
        

      

       
        public List<tb_pur> list_pur;
        private void btn_add_Click_1(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            // التحقق من أن اسم المورد غير فارغ
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم المورد مطلوب";
                dialog.Show();
                return;
            }

           
                // التحقق من أن الحقول الأخرى تحتوي على قيم صالحة
                double buyPrice = Convert.ToDouble(edt_buy.Text);
                double quantity = Convert.ToDouble(txt_qt.Text);
              double payment = Convert.ToDouble(edt_pay.Text);
               double totalData = Convert.ToDouble(txt_totaldata.Text);
                double stayAmount = Convert.ToDouble(edt_stay.Text);
            list_pur = db.tb_pur.ToList();
            if (id == 0)
                {
                
                 if (dataGridView1.Rows.Count - 1 != 0)
                {
                    tb_Pur.pur_supp = edt_supp.Text;
                tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                if (tb_Supp == null)
                {
                    MessageBox.Show("لا يوجد بيانات لهذا المورد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // الخروج من العملية إذا لم يتم العثور على العميل
                }
                tb_Pur.pur_name = edt_name.Text;
                   
                    tb_Pur.pur_supp = edt_supp.Text;
                    tb_Pur.supp_id = tb_Supp.id;
                    tb_Pur.pur_dat = DateTime.Now;
                    tb_Pur.pur_buy = buyPrice;
                    tb_Pur.safe = save.Text;
                    tb_Pur.pur_qt = quantity;
                    tb_Pur.pay = payment;
                    tb_Pur.pur_tbuy = stayAmount;
                    tb_Pur.supp_price= Convert.ToDouble(edt_staybehaver.Text);
                    tb_Pur.total_price = totalData;
                    tb_Pur.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                   tb_Pur.invocie_id = db.tb_pur.Any() ? db.tb_pur.Max(x => x.invocie_id) + 1 : 1;
                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null)
                    {
                        // التحقق من أن la_roll يحتوي على قيمة
                        if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        {
                            tb_Pur.namecasher = frm_supp_Add.la_username.Text;
                        }
                    }
                    db.tb_pur.Add(tb_Pur);
                //db.SaveChanges();
                   
                    tb_Supp.total_price = tb_Pur.stay;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                if (tb_Supp.supp_max <= tb_Supp.total_price && tb_Supp.supp_max != 0)
                {
                    // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                    string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price } له.";
                    SendEmailWithHtmlGridData(notificationMessage);
                    // إنشاء الإشعار وتحديد التاريخ
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;

                    // إضافة الإشعار إلى قاعدة البيانات
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                   
                }
                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count -= payment;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "اضافة";
                        tb_OperationLog.TableName = "عملية شراء";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - tb_Pur.pay);
                        tb_OperationLog.AmountDifference = -tb_Pur.pay;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }


                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم إجراء عملية الشراء";
                    toast.Show();
                    ss();
                    saveButtonClicked = true;
                    this.Close();

                }
                else
                {
                    dialog.txt_capthion.Text = "لا يمكن حفظ فاتورة بدون بيانات";
                    dialog.Show();
                }
                 }
                else
                {
                // تعديل عملية شراء موجودة
                tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                tb_Pur = db.tb_pur.Where(x => x.id == id).FirstOrDefault();
                    tb_Pur.pur_supp = edt_supp.Text;
                    tb_Pur.supp_id = tb_Supp.id;
                    tb_Pur.pur_name = edt_name.Text;
                    
                    tb_Pur.pur_dat = Convert.ToDateTime(edt_date.Text);
                    tb_Pur.pur_buy = buyPrice;
                    tb_Pur.safe = save.Text;
                    tb_Pur.pur_qt = quantity;
                    tb_Pur.pay = payment;
                    tb_Pur.pur_tbuy = stayAmount;
                    tb_Pur.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_Pur.total_price = totalData;
                    tb_Pur.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                    tb_Pur.invocie_id = Convert.ToInt32(invice_id.Text);
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null)
                {
                    // التحقق من أن la_roll يحتوي على قيمة
                    if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    {
                        tb_Pur.namecasher = frm_supp_Add.la_username.Text;
                    }
                }
                db.Entry(tb_Pur).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                   
                    prives = Convert.ToDouble(tb_Pur.stay);
                    double difference = prives - curnt;
                   
                    tb_Supp.total_price += difference;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                if (tb_Supp.supp_max <= tb_Supp.total_price && tb_Supp.supp_max != 0)
                {
                    // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                    string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price } له.";
                    SendEmailWithHtmlGridData(notificationMessage);
                    // إنشاء الإشعار وتحديد التاريخ
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;

                    // إضافة الإشعار إلى قاعدة البيانات
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                   
                }
                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count -= (tb_Pur.pay - oldamount);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession != null)
                {
                    tb_OperationLog.SessionID = openSession.SessionID;
                    tb_OperationLog.OperationType = "تعديل";
                    tb_OperationLog.TableName = "عملية شراء";
                    tb_OperationLog.OldValue = openSession.ClosingAmount;
                    tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - (tb_Pur.pay - oldamount));
                    tb_OperationLog.AmountDifference = oldamount - tb_Pur.pay;
                    db.tb_OperationLog.Add(tb_OperationLog);
                    db.SaveChanges();

                    openSession.ClosingAmount = tb_OperationLog.NewValue;

                    db.SaveChanges();

                }



                toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل عملية الشراء";
                    toast.Show();
                    ss();
                    saveButtonClicked = true;
                    this.Close();
                }
            
        }

      


        public string GetHtmlFromTextBoxContent(string messageContent)
        {
            // جلب محتوى TextBox
            // يمكنك استخدام ToList() للحصول على جميع البيانات
            // تهيئة المتغير المحتوي على الرسالة

            string html = "<html><head><style>";
            html += "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@700&display=swap');"; // استيراد خط كايرو
            html += "body { font-family: 'Cairo', sans-serif; background: linear-gradient(to right, #38ef7d, #38ef7d); padding: 20px; color: #38ef7d; }"; // تدرج بين الأخضر الفاتح والأخضر الداكن
            html += ".email-container { background-color: #34495e; padding: 30px; border-radius: 15px; max-width: 700px; margin: auto; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3); color: #ffffff; }";
            html += "h2 { color: #f39c12; text-align: center; font-size: 28px; margin-bottom: 20px; font-weight: bold; }"; // عنوان بلون برتقالي فاتح
            html += "h3 { color: #ecf0f1; text-align: center; font-size: 20px; margin-bottom: 20px; font-weight: bold; }"; // نص توضيحي بلون أبيض فاتح
            html += ".message-box { background-color: #2c3e50; padding: 25px; border-radius: 10px; text-align: center; box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); margin: auto; max-width: 600px; font-size: 20px; font-weight: bold; color: #f1c40f; }"; // صندوق الرسالة مع ظل داخلي ولون أصفر
            html += "footer { text-align: center; font-size: 14px; color: #bdc3c7; margin-top: 20px; padding-top: 10px; border-top: 1px solid #7f8c8d; }"; // فوتر بلون رمادي فاتح
            html += "</style></head><body>";

            // إضافة المحتوى إلى الحاوية
            html += "<div class='email-container'>";
            html += "<h2>EngineeCode for Software</h2>"; // العنوان الرئيسي
            html += $"<h3>تنبيه</h3>"; // النص الثانوي
            html += $"<div class='message-box'><p>{messageContent}</p></div>"; // صندوق الرسالة
            html += "<footer>Thank you for using our services. We appreciate your support!</footer>"; // الفوتر
            html += "</div>"; // إغلاق حاوية البريد
            html += "</body></html>";

            return html; // إرجاع المحتوى
        }
        public void SendEmailWithHtmlGridData(string messageContent)
        {
            string htmlContent = GetHtmlFromTextBoxContent(messageContent); // استخراج البيانات كـ HTML
            if (!string.IsNullOrEmpty(htmlContent)) // تحقق من عدم كون المحتوى فارغًا
            {
                SendEmailWithHtml(htmlContent); // إرسال البريد الإلكتروني مع HTML
            } // إرسال البريد الإلكتروني مع HTML
        }
        public void SendEmailWithHtml(string htmlContent)
        {
           
            var userEmails = db.tb_user
                 .Where(u => u.user_roll == "مدير"&& u.user_roll == "مدير حسابات") // استبدل حسب الحاجة
                 .Select(u => u.user_mail)
                 .ToList();

            // إضافة البريد الثابت
            //userEmails.Add(Properties.Settings.Default.Email);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("engineecode12@gmail.com");
                // mail.To.Add(userEmail);
                mail.Subject = "تنبيهات";
                mail.Body = htmlContent;
                mail.IsBodyHtml = true;
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("engineecode12@gmail.com", "shjhvhnebtuisfsg");
                smtpServer.EnableSsl = true; // Enable SSL for security
                foreach (var userEmail in userEmails)
                {
                    mail.To.Clear(); // امسح العناوين السابقة
                    mail.To.Add(userEmail); // أضف عنوان البريد الإلكتروني الحالي
                    smtpServer.Send(mail); // أرسل البريد الإلكتروني
                }



            }
            catch (Exception ex)
            {
                
            }
        }

        private void frm_pur_add_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            list_pur = db.tb_pur.ToList();
            // toast toast = new toast();
            //  dialog dialog = new dialog();
            if (!saveButtonClicked)
            {
                if (id == 0)
                {
                    if (dataGridView1.Rows.Count - 1 == 0)
                    {
                        // this.Close();


                    }
                    else
                    {
                        tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                        if (tb_Supp == null)
                        {
                            MessageBox.Show("لا يوجد بيانات لهذا المورد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // الخروج من العملية إذا لم يتم العثور على العميل
                        }
                        tb_Pur.pur_supp = edt_supp.Text;
                        tb_Pur.supp_id = tb_Supp.id;
                        tb_Pur.pur_name = edt_name.Text;
                        // tb_Pur.pur_type = edt_tybe.Text;
                        
                       // tb_Pur.pur_supp = edt_supp.Text;
                        tb_Pur.pur_dat = DateTime.Now;
                        tb_Pur.pur_buy = Convert.ToDouble(edt_buy.Text);
                        tb_Pur.safe = save.Text;
                        tb_Pur.pur_qt = Convert.ToDouble(txt_qt.Text);
                         // tb_Pur.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                        tb_Pur.pay = Convert.ToDouble(edt_pay.Text);
                        tb_Pur.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                        tb_Pur.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                        tb_Pur.total_price = Convert.ToDouble(txt_totaldata.Text);
                        tb_Pur.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                        tb_Pur.invocie_id = db.tb_pur.Any() ? db.tb_pur.Max(x => x.invocie_id) + 1 : 1;
                        main frm_supp_Add = (main)Application.OpenForms["main"];
                        if (frm_supp_Add != null)
                        {
                            // التحقق من أن la_roll يحتوي على قيمة
                            if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                            {
                                tb_Pur.namecasher = frm_supp_Add.la_username.Text;
                            }
                        }
                        db.tb_pur.Add(tb_Pur);
                        db.SaveChanges();

                        tb_Supp.total_price = tb_Pur.stay; 
                        db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        if (tb_Supp.supp_max <= tb_Supp.total_price && tb_Supp.supp_max != 0)
                        {
                            // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                            string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price } له.";
                            SendEmailWithHtmlGridData(notificationMessage);
                            // إنشاء الإشعار وتحديد التاريخ
                            notfication.notfication1 = notificationMessage;
                            notfication.CreatedAt = DateTime.Now;

                            // إضافة الإشعار إلى قاعدة البيانات
                            db.Notfications.Add(notfication);
                            db.SaveChanges();
                        }
                        tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                        tb_Safe.safe_count -= Convert.ToDouble(edt_pay.Text);
                        db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        main user = (main)Application.OpenForms["main"];
                        string casherName = user?.la_username.Text;
                        var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                        if (openSession != null)
                        {
                            tb_OperationLog.SessionID = openSession.SessionID;
                            tb_OperationLog.OperationType = "اضافة";
                            tb_OperationLog.TableName = "عملية شراء";
                            tb_OperationLog.OldValue = openSession.ClosingAmount;
                            tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - tb_Pur.pay);
                            tb_OperationLog.AmountDifference = -tb_Pur.pay;
                            db.tb_OperationLog.Add(tb_OperationLog);
                            db.SaveChanges();

                            openSession.ClosingAmount = tb_OperationLog.NewValue;

                            db.SaveChanges();

                        }
                        ss();
                        // this.Close();
                    }
                }
                else
                {
                    tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                    tb_Pur = db.tb_pur.Where(x => x.id == id).FirstOrDefault();
                    tb_Pur.pur_supp = edt_supp.Text;
                    tb_Pur.supp_id = tb_Supp.id;

                    tb_Pur.pur_name = edt_name.Text;
                    // tb_Pur.pur_type = edt_tybe.Text;
                    
                  //  tb_Pur.pur_supp = edt_supp.Text;
                    tb_Pur.pur_dat = Convert.ToDateTime(edt_date.Text);
                    tb_Pur.pur_buy = Convert.ToDouble(edt_buy.Text);
                    tb_Pur.safe = save.Text;
                    tb_Pur.pur_qt = Convert.ToDouble(txt_qt.Text);
                   // tb_Pur.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                    tb_Pur.pay = Convert.ToDouble(edt_pay.Text);
                    tb_Pur.pur_tbuy = Convert.ToDouble(edt_stay.Text);
                    tb_Pur.supp_price = Convert.ToDouble(edt_staybehaver.Text);
                    tb_Pur.total_price = Convert.ToDouble(txt_totaldata.Text);
                    tb_Pur.stay = (Convert.ToDouble(edt_stay.Text)) - Convert.ToDouble(edt_pay.Text);
                    tb_Pur.invocie_id = Convert.ToInt32(invice_id.Text);
                     main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null)
                    {
                        // التحقق من أن la_roll يحتوي على قيمة
                        if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        {
                            tb_Pur.namecasher = frm_supp_Add.la_username.Text;
                        }
                    }
                    db.Entry(tb_Pur).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                   // tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
                    prives = Convert.ToDouble(tb_Pur.stay);
                    double difference = prives - curnt;

                    tb_Supp.total_price += difference;
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    if (tb_Supp.supp_max <= tb_Supp.total_price && tb_Supp.supp_max != 0)
                    {
                        // إنشاء رسالة إشعار تتضمن اسم العميل والتحذير من تجاوز الحد الأقصى
                        string notificationMessage = $"المورد: {tb_Supp.supp_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_Supp.supp_max})، الرجاء دفع المبلغ هذا  {tb_Supp.total_price} له.";
                        SendEmailWithHtmlGridData(notificationMessage);
                        // إنشاء الإشعار وتحديد التاريخ
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;

                        // إضافة الإشعار إلى قاعدة البيانات
                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                    }
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count -= (tb_Pur.pay - oldamount);
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "تعديل";
                        tb_OperationLog.TableName = "عملية شراء";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount - (tb_Pur.pay - oldamount));
                        tb_OperationLog.AmountDifference = oldamount - tb_Pur.pay;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }

                    // toast.Width = this.Width;
                    // toast.txt_caption.Text = "تم تعديل عملية الشراء";
                    //  toast.Show();
                    ss();
                    //  this.Close();

                }
            }
        }





        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد من أن الصف المختار صحيح وليس خارج النطاق
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectrowindex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // التحقق من أن الخلايا لا تحتوي على قيم null قبل محاولة الوصول إليها
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    edt_name.Text = row.Cells[0].Value.ToString();
                    edt_buy.Text = row.Cells[1].Value.ToString();
                    txt_qt.Text = row.Cells[3].Value.ToString();

                    // التحقق من نوع الوحدة (صغرى أو كبرى)
                 /*   if (row.Cells[2].Value.ToString() == "صغرى")
                    {
                        tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();

                        small.Checked = true;
                        big.Checked = false;
                    }
                    else
                    {
                        tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();

                        small.Checked = false;
                        big.Checked = true;
                    }*/

                    qts_qt.Text = row.Cells[3].Value.ToString();
                   // edt_sell.Text = row.Cells[5].Value.ToString();
                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_add_pur.Enabled = false;
                    edt_name.Enabled = false;
                }
                else
                {
                    // عرض رسالة عند محاولة الوصول إلى خلايا فارغة أو تحتوي على قيم غير صالحة
                    MessageBox.Show("الصف الذي قمت بالنقر عليه يحتوي على بيانات غير صالحة.");
                }
            }
        }



      

      

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();

            // تحقق مما إذا كان الكائن موجودًا
            if (tb_stuk != null)
            {
                // إذا كان الكائن موجودًا، قم بتحديث الحقول والـ CheckBoxes بناءً على القيم المخزنة في قاعدة البيانات
                qtstuck.Text = tb_stuk.stuk_qt.ToString();
                staysafe.Text = tb_stuk.stuk_sell.ToString();
               
              //  edt_sell.Text = tb_stuk.stuk_sell.ToString();
               
               

                  /*  if (string.IsNullOrWhiteSpace(edt_buy.Text))
                {
                   
                  edt_buy.Text = "0";
                    edt_sell.Text = "0";
                }*/
            }
           
        }

        private void edt_cat_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void edt_supp_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
            edt_staybehaver.Text = tb_Supp.total_price.ToString();
            //edt_stay.Text = tb_Supp.total_price.ToString();
            pro_call();
        }

        private void edt_pay_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_pay.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_pay.Text = "0";
                pro_call();
            }
            else
            {
                pro_call();
            }
        }

        private void btn_add_pur_Click(object sender, EventArgs e)
        {
            tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();






            tb_stuk.stuk_name = edt_name.Text;


            double price = Convert.ToDouble(edt_buy.Text) - Convert.ToDouble(edt_cut.Text);

            double qt = Math.Round(
                Convert.ToDouble(txt_qt.Text) * Convert.ToDouble(edt_code.Text) / 875.0,
                2
            );

            DataRow row = datasells.NewRow();

            row[0] = edt_name.Text;
            row[1] = price;
            row[2] = tb_stuk.unit;
            row[3] = txt_qt.Text;
            row[4] = qt;
            row[5] = Math.Round(price * qt, 2);
            row[6] = edt_code.Text;

            datasells.Rows.Add(row);

          



          
           
            pro_call();

                if (comboBox1.Text == "نقدى")
                {
                    edt_pay.Text = txt_totaldata.Text;
                }
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
           
           
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowindex);
            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add_pur.Enabled = true;
            edt_name.Enabled = true;
            if (comboBox1.Text == "نقدى")
            {
                edt_pay.Text = txt_totaldata.Text;
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
          
            // txt_qt.Text = qtr.ToString();
            if (selectrowindex < 0 || selectrowindex >= dataGridView1.Rows.Count)
            {
                MessageBox.Show("يرجى تحديد صف للتعديل.");
                return; // إنهاء الوظيفة إذا كانت القيمة غير صحيحة
            }

            DataGridViewRow newrow = dataGridView1.Rows[selectrowindex];

            if (newrow.Cells[0].Value == null || string.IsNullOrEmpty(newrow.Cells[0].Value.ToString()))
            {
                MessageBox.Show("لا يمكن تعديل صف فارغ.");
                return; // إنهاء الوظيفة إذا كانت الخلايا فارغة
            }
            tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();

            tb_stuk.stuk_name = edt_name.Text;

            double price = Convert.ToDouble(edt_buy.Text) - Convert.ToDouble(edt_cut.Text);

            double qt = Math.Round(
                Convert.ToDouble(txt_qt.Text) * Convert.ToDouble(edt_code.Text) / 875.0,
                2
            );
            newrow.Cells[0].Value = edt_name.Text;
            newrow.Cells[1].Value = price;
            newrow.Cells[2].Value = tb_stuk.unit;
            newrow.Cells[3].Value = txt_qt.Text;
            newrow.Cells[4].Value = qt;
            newrow.Cells[5].Value = Math.Round(price * qt, 2);
            newrow.Cells[6].Value = edt_code.Text;
            // newrow.Cells[5].Value = edt_sell.Text;
            tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();

           
            


            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add_pur.Enabled = true;
            edt_name.Enabled = true;
            if (comboBox1.Text == "نقدى")
            {
                edt_pay.Text = txt_totaldata.Text;
            }
        }

      

        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_buy.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
              var  tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                if(tb_stuk==null)
                {
                    edt_buy.Text = "0";
                }else
                {
                    edt_buy.Text = tb_stuk.stuk_buy.ToString();
                    pro_call();
                }
                // edt_cat.Text = tb_stuk.stuk_cat;
               
            }
            else
            {
                pro_call();
            }
        }

        private void edt_stay_Click(object sender, EventArgs e)
        {
            pro_call();
        }

        private void txt_totaldata_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_qt_EditValueChanged(object sender, EventArgs e)
        {
            pro_call();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void save_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "نقدى")
            {
                edt_pay.Text = txt_totaldata.Text;
            }
        }

        private void edt_code_TextChanged(object sender, EventArgs e)
        {
            tb_stuk = db.tb_stuk.Where(x => x.code == edt_code.Text).FirstOrDefault();

            // تحقق مما إذا كان الكائن موجودًا
            if (tb_stuk != null)
            {
                // إذا كان الكائن موجودًا، قم بتحديث الحقول والـ CheckBoxes بناءً على القيم المخزنة في قاعدة البيانات
                qtstuck.Text = tb_stuk.stuk_qt.ToString();
                staysafe.Text = tb_stuk.stuk_sell.ToString();
                sell21.Text = tb_stuk.stuk_buy.ToString();
                edt_buy.Text = tb_stuk.stuk_buy.ToString();
              //  edt_sell.Text = tb_stuk.stuk_sell.ToString();
                edt_name.Text = tb_stuk.stuk_name;
               /* if (tb_stuk.unit == "صغرى")
                {
                    small.Checked = true;
                    big.Checked = false;
                }
                else
                {

                    small.Checked = false;
                    big.Checked = true;
                }

                if (string.IsNullOrWhiteSpace(edt_buy.Text))
                {

                    edt_buy.Text = "0";
                    edt_sell.Text = "0";
                }*/
            }
        }

        private void btn_changecus_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            int invoiceId;
            if (int.TryParse(txt_id.Text, out invoiceId))
            {
                // جلب الفاتورة من tb_pur باستخدام ID
                tb_Pur = db.tb_pur.FirstOrDefault(x => x.id == invoiceId);
            }

            // التحقق إذا كان المورد الحالي هو نفس المورد المطلوب تحويله
            if (edt_supp.Text == edt_chancus.Text)
            {
                MessageBox.Show("لا يمكن تحويل الفاتورة إلى نفس المورد.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // خروج من الدالة إذا كان المورد هو نفسه
            }

            // جلب المورد من tb_supp
            var tb_supp = db.tb_supp.FirstOrDefault(x => x.supp_name == edt_supp.Text);

            // تعديل total_price في tb_supp بناءً على البيانات القديمة في الفاتورة
            tb_supp.total_price -= tb_Pur.total_price;
            tb_supp.total_price += tb_Pur.pay;

            db.Entry(tb_supp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            // تحديث اسم المورد بعد التغيير
            edt_supp.Text = edt_chancus.Text;
            tb_supp = db.tb_supp.FirstOrDefault(x => x.supp_name == edt_supp.Text);
            edt_staybehaver.Text = tb_supp.total_price.ToString();

            // تعديل total_price في tb_supp بناءً على البيانات الجديدة
            tb_supp.total_price += Convert.ToDouble(txt_totaldata.Text);
            tb_supp.total_price -= Convert.ToDouble(edt_pay.Text);
            db.Entry(tb_supp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            // استدعاء دالة pro_call
            pro_call();
            double buyPrice = Convert.ToDouble(edt_buy.Text);
            double quantity = Convert.ToDouble(txt_qt.Text);
            double payment = Convert.ToDouble(edt_pay.Text);
            double totalData = Convert.ToDouble(txt_totaldata.Text);
            double stayAmount = Convert.ToDouble(edt_stay.Text);

            // تحديث بيانات الفاتورة في tb_pur بناءً على البيانات الجديدة
            tb_Supp = db.tb_supp.Where(x => x.supp_name == edt_supp.Text).FirstOrDefault();
            tb_Pur = db.tb_pur.Where(x => x.id == invoiceId).FirstOrDefault();
            tb_Pur.pur_supp = edt_supp.Text;
            tb_Pur.supp_id = tb_Supp.id;
            tb_Pur.pur_name = edt_name.Text;
            tb_Pur.pur_dat = Convert.ToDateTime(edt_date.Text);
            tb_Pur.pur_buy = buyPrice;
            tb_Pur.safe = save.Text;
            tb_Pur.pur_qt = quantity;
            tb_Pur.pay = payment;
            tb_Pur.pur_tbuy = stayAmount;
            tb_Pur.supp_price = Convert.ToDouble(edt_staybehaver.Text);
            tb_Pur.total_price = totalData;
            tb_Pur.stay = stayAmount - payment;
            tb_Pur.invocie_id = Convert.ToInt32(invice_id.Text);

            db.Entry(tb_Pur).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            curnt = Convert.ToDouble(tb_Pur.stay);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void edt_staybehaver_Click_1(object sender, EventArgs e)
        {
            pro_call();
        }

        private void edt_tbuy_Click(object sender, EventArgs e)
        {
            pro_call();
        }






        private void pro_call()
        {
            try
            {
                double sum = 0;

                // حلقة للتأكد من أن القيم صالحة قبل إضافتها إلى المجموع
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var cellValue = dataGridView1.Rows[i].Cells[5].Value;

                    // التحقق من أن الخلية غير فارغة ولديها قيمة قابلة للتحويل إلى double
                    if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        // محاولة تحويل القيمة إلى double
                        double value;
                        if (double.TryParse(cellValue.ToString(), out value))
                        {
                            sum += value;
                        }
                        else
                        {
                            MessageBox.Show($"الخلية في الصف {i + 1} تحتوي على قيمة غير صالحة.");
                            return; // الخروج من الدالة في حالة وجود خطأ
                        }
                    }
                }

                // عرض المجموع في txt_totaldata
                txt_totaldata.Text = sum.ToString();

                // التحقق من صحة قيمة edt_staybehaver قبل إضافتها إلى المجموع
                double edtStayBehaverValue;
                if (double.TryParse(edt_staybehaver.Text, out edtStayBehaverValue))
                {
                    double sumall = sum + edtStayBehaverValue;
                    edt_stay.Text = sumall.ToString();
                }
                else
                {
                    MessageBox.Show("قيمة الباقي في edt_staybehaver غير صالحة.");
                }
            }
            catch (Exception ex)
            {
                // عرض رسالة الخطأ في حالة وجود استثناء
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }
        public void ss()
        {
            if (id == 0)
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    //report1.
                    tb_Ordersell.sell_id = tb_Pur.id;
                    tb_Ordersell.name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    tb_Ordersell.price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    tb_Ordersell.wight = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    tb_Ordersell.qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    tb_Ordersell.tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    tb_Ordersell.sell_price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    // db.SaveChanges();

                    try
                    {
                        db.tb_ordersellpop.Add(tb_Ordersell);
                        db.SaveChanges();
                        // tb_Sellorder.id = x += 1;
                    }
                    catch
                    {
                        MessageBox.Show("ghg");

                    }
                }
                // db.SaveChanges();
            }
            else
            {



                db.tb_ordersellpop.RemoveRange(db.tb_ordersellpop.Where(x => x.sell_id == id));
                db.SaveChanges();



                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    //report1.
                    tb_Ordersell.sell_id = tb_Pur.id;
                    tb_Ordersell.name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    tb_Ordersell.price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                   tb_Ordersell.wight = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    tb_Ordersell.qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    tb_Ordersell.tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    tb_Ordersell.sell_price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    // db.SaveChanges();
                    try
                    {
                        db.tb_ordersellpop.Add(tb_Ordersell);
                        db.SaveChanges();
                        // tb_Sellorder.id = x += 1;
                    }
                    catch
                    {
                        MessageBox.Show("ghg");

                    }


                    // tb_Sellorder.id = x += 1;

                }


            }



        }
    }
}
