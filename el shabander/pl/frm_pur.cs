using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using el_shabander.epl;
using System.Net.Mail;
using System.Net;
namespace el_shabander.pl
{
    public partial class frm_pur : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_pur tb_Pur = new tb_pur();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_safe tb_Safe = new tb_safe();
        tb_stuk tb_stuk = new tb_stuk();
        tb_supp tb_Supp = new tb_supp();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        Notfication notfication = new Notfication();
        frm_sell_add send = new frm_sell_add();
        int id;
        public frm_pur()
        {
            InitializeComponent();

           
            el_shabander.DB_storeEntities dbContext = new el_shabander.DB_storeEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_pur.LoadAsync().ContinueWith(loadTask =>
            {
                gridControl1.DataSource = dbContext.tb_pur.Local.ToBindingList().Reverse();
               
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
           // gridView1.OptionsBehavior.ReadOnly = true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }
            var tb_supp = db.tb_supp.ToList();
            if (!tb_supp.Any())
            {
                MessageBox.Show("الرجاء اضافة موردين", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // الخروج من العملية إذا لم يتم العثور على العميل
            }
            var tbstuck = db.tb_stuk.ToList();
            if (!tbstuck.Any())
            {
                MessageBox.Show("الرجاء اضافة اصناف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // الخروج من العملية إذا لم يتم العثور على العميل
            }
            pl.frm_pur_add frm_supp_Add = new frm_pur_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }
        public List<tb_ordersellpop> listorder;
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
        private void btn_delete_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }

            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
                main frm_supp_Add = (main)Application.OpenForms["main"];

                string passwordInput = ShowPasswordDialog("تأكيد كلمة المرور", "الرجاء إدخال كلمة المرور:");
                if (passwordInput == "CANCELLED")
                {
                    MessageBox.Show("تم إلغاء العملية.");
                    return; // يوقف تنفيذ باقي الكود
                }

                var tB_user = db.tb_user
                               .Where(x => x.user_name == frm_supp_Add.la_username.Text
                                        && x.user_pass == passwordInput)
                               .FirstOrDefault();
                if (tB_user != null)
                {
                    tb_Pur = db.tb_pur.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_Pur).State = EntityState.Deleted;
                    db.SaveChanges();
                   

                  /*  tb_stuk = db.tb_stuk.Where(x => x.stuk_name == tb_Pur.pur_name).FirstOrDefault();
                    tb_stuk.stuk_buy -= tb_Pur.pur_buy;
                        tb_stuk.stuk_qt -= tb_Pur.pur_qt;
                        tb_stuk.stuk_tbuy -= tb_Pur.pur_tbuy;*/
                    listorder = db.tb_ordersellpop.Where(x => x.sell_id == tb_Pur.id).ToList();
                    for (int i = 0; i < listorder.Count; i++)
                    {

                        string dd = listorder[i].name_sell;

                        tb_stuk= db.tb_stuk.Where(x => x.stuk_name == dd).FirstOrDefault();

                        //  MessageBox.Show("ghg" + listorder[i].name_sell);
                        double ss = Convert.ToDouble(listorder[i].qt_sell);
                        tb_stuk.stuk_qt -= ss;
                        try
                        {
                            db.Entry(tb_stuk).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("ghg");
                        }

                      
                     
                    }
                    tb_Supp = db.tb_supp.Where(x => x.supp_name == tb_Pur.pur_supp).FirstOrDefault();

                    tb_Supp.total_price -= (tb_Pur.total_price - tb_Pur.pay);
                    db.Entry(tb_Supp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == tb_Pur.safe).FirstOrDefault();
                    tb_Safe.safe_count += tb_Pur.pay;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    main user1 = (main)Application.OpenForms["main"];
                    string casherName1 = user1?.la_username.Text;
                    var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
                    if (openSession1 != null)
                    {
                        tb_OperationLog.SessionID = openSession1.SessionID;
                        tb_OperationLog.OperationType = "حذف";
                        tb_OperationLog.TableName = "عملية شراء";
                        tb_OperationLog.OldValue = openSession1.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount + tb_Pur.pay);
                        tb_OperationLog.AmountDifference = tb_Pur.pay;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession1.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }

                    string notificationMessage = $" تم حذف عملية شراء فاتورة رقم: {tb_Pur.invocie_id} عن طريق : {frm_supp_Add.la_username.Text}   التاريخ والوقت: {DateTime.Now:yyyy/MM/dd hh:mm tt}.  ";

                    send.SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;


                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                    ShowToastMessage("تم الحذف بنجاح");
                    updata_data();
                }
                else
                {
                    MessageBox.Show("كلمة المرور غير صحيحة.");
                }







            }
            catch
            {
                ShowDialogMessage("لا يوجد عملية شراء لحذفها.");
            }
        }
        private void ShowToastMessage(string message)
        {
            toast toast = new toast();
            toast.txt_caption.Text = message;
            toast.Show();
        }

        // 🔹 دالة لإظهار رسالة Dialog
        private void ShowDialogMessage(string message)
        {
            dialog dialog = new dialog();
            dialog.Width = this.Width;
            dialog.txt_capthion.Text = message;
            dialog.ShowDialog();  // 🔥 استخدام ShowDialog بدلاً من Show لضمان بقاء الرسالة حتى يضغط المستخدم
        }
        public void updata_data()
        {
            
            db = new DB_storeEntities();
            List<tb_pur> data = db.tb_pur.ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
        }

        

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_pur> data = db.tb_pur.Where(x =>  x.pur_supp.Contains(_search) || x.invocie_id.ToString().Contains(_search)).ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            main user = (main)Application.OpenForms["main"];
            string casherName = user?.la_username.Text;
            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
            if (openSession == null)
            {
                MessageBox.Show("يرجى فتح الكاش بوكس أولاً");
                return;
            }
            pl.frm_pur_add frm_supp_Add = new frm_pur_add();
            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_Pur = db.tb_pur.Where(x => x.id == id).FirstOrDefault();
            // frm_supp_Add.edt_name.Text = tb_sell.sell_name;
            // tb_sell = db.tb_sell.Where(x => x.sell_cus == edt_cus.Text).FirstOrDefault();
            // 
            //frm_supp_Add.edt_sell.Text = tb_sell.sell_price.ToString();
            // frm_supp_Add.edt_cat.Text = tb.sell_qt.ToString();
            frm_supp_Add.edt_date.Text = (tb_Pur.pur_dat).ToString();
            frm_supp_Add.edt_pay.Text = tb_Pur.pay.ToString();
            frm_supp_Add.txt_totaldata.Text = tb_Pur.total_price.ToString();
            frm_supp_Add.edt_stay.Text = tb_Pur.pur_tbuy.ToString();
            tb_Supp = db.tb_supp.Where(x => x.id == tb_Pur.supp_id).FirstOrDefault();
            frm_supp_Add.save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
            frm_supp_Add.save.Text = tb_Pur.safe;
            frm_supp_Add.edt_supp.Text = tb_Pur.pur_supp;
            // tb_Cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();

            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "حفظ";
            frm_supp_Add.Show();
        }
        public string GetHtmlFromTileView()
        {
            // الحصول على تاريخ اليوم
            var today = DateTime.Today;

            // استرجاع الفواتير التي تتطابق مع تاريخ اليوم
            var data = db.tb_pur
               .Where(s => DbFunctions.TruncateTime(s.pur_dat) == today) // استرجاع الفواتير الخاصة بتاريخ اليوم
               .ToList();

            // بداية إنشاء هيكل HTML
            string html = "<html><head><style>";
            html += "body { font-family: Arial, sans-serif; direction: rtl; text-align: right; background: linear-gradient(to right, #27ae60, #2ecc71, #a8e063); padding: 20px; }"; // إضافة اتجاه النص من اليمين لليسار
            html += ".email-container { background-color: rgba(255, 255, 255, 0.85); padding: 20px; border-radius: 10px; max-width: 800px; margin: auto; box-shadow: 0 0 15px rgba(0, 0, 0, 0.3); }";
            html += "h2 { color: #333; text-align: center; font-size: 28px; }";
            html += "h3 { color: #27ae60; text-align: center; font-size: 24px; margin-bottom: 30px; }";
            html += "table { border-collapse: collapse; width: 100%; margin: 20px 0; font-size: 18px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }";
            html += "th, td { border: 1px solid #ddd; padding: 12px; text-align: right; }"; // تغيير اتجاه النص داخل الجدول
            html += "th { background-color: #4CAF50; color: white; text-transform: uppercase; letter-spacing: 1px; }";
            html += "tr:nth-child(even) { background-color: #f2f2f2; }";
            html += "tr:hover { background-color: #ddd; }";
            html += "</style></head><body>";
            html += "<div class='email-container'>"; // بداية حاوية البريد
            html += "<h2>EngineeCode for Software</h2>";
            html += "<h3>فواتير المشتريات اليوم</h3>";
            html += "<table>";

            // إضافة عناوين الأعمدة
            html += "<tr><th>المتبقى</th><th>المدفوع</th><th>الاجمالى</th><th>اجمالى الفاتورة</th><th>التاريخ</th><th>اسم المورد</th><th>رقم الفاتورة</th></tr>";

            // إضافة البيانات الصفية
            foreach (var item in data)
            {
                html += "<tr>";

                html += $"<td>{item.stay}</td>";
                html += $"<td>{item.pay}</td>";
                html += $"<td>{item.pur_tbuy}</td>";
                html += $"<td>{item.total_price}</td>";
                html += $"<td>{item.pur_dat}</td>";
                html += $"<td>{item.pur_supp}</td>";
                html += $"<td>{item.invocie_id}</td>";
                html += "</tr>";
            }

            // إغلاق هيكل HTML
            html += "</table>";
            html += "</div>"; // إغلاق حاوية البريد
            html += "</body></html>";

            return html;
        }

        public void SendEmailWithHtmlGridData()
        {
            string htmlContent = GetHtmlFromTileView();  // استخراج البيانات كـ HTML
            SendEmailWithHtml(htmlContent);  // إرسال البريد الإلكتروني مع HTML
        }

        public void SendEmailWithHtml(string htmlContent)
        {
            Console.WriteLine(htmlContent);
            var userEmails = db.tb_user
                 .Where(u => u.user_roll == "مدير" ) // استبدل حسب الحاجة
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
                mail.Subject = $"فواتير المشتريات اليوم {DateTime.Today}";
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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }
    }
}
