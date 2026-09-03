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
    public partial class frm_sell : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_sell tb_sell = new tb_sell();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_cus tb_Cus = new tb_cus();
        tb_ordersell tb_Ordersell = new tb_ordersell();
        tb_stuk tb_Stuk = new tb_stuk();
        tb_safe tb_Safe = new tb_safe();
        Notfication notfication = new Notfication();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        frm_sell_add send = new frm_sell_add();
        int id;
        public frm_sell()
        {
            InitializeComponent();

            

            el_shabander.DB_storeEntities dbContext = new el_shabander.DB_storeEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_sell.LoadAsync().ContinueWith(loadTask =>
            {
               /* List<tb_sell> data = db.tb_sell.ToList(); // جلب البيانات
                data.Reverse();
                gridControl1.DataSource = data;*/
                // Bind data to control when loading complete
                gridControl1.DataSource = dbContext.tb_sell.Local.ToBindingList().Reverse();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
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
            pl.frm_sell_add frm_supp_Add = new frm_sell_add();
            frm_supp_Add.id = 0;
           // frm_supp_Add.btn_save.Text = "إضافة"; // يجب أن يكون btn_save وليس btn_add
            frm_supp_Add.Show();

        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }
        public List<tb_ordersell> listorder;
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
                    tb_sell = db.tb_sell.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_sell).State = EntityState.Deleted;

                    db.SaveChanges();

                    listorder = db.tb_ordersell.Where(x => x.sell_id ==tb_sell.id).ToList();
                    for (int i = 0; i < listorder.Count; i++)
                    {
                    
                       string dd = listorder[i].name_sell;

                      tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == dd).FirstOrDefault();

                    //  MessageBox.Show("ghg" + listorder[i].name_sell);
                      double ss=Convert.ToDouble (listorder[i].qt_sell);
                        if (listorder[i].weight == "كبرى")
                        {
                            //tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                           ss *= Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);

                        }
                        tb_Stuk.stuk_qt += ss;
                      try
                      {
                        db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                          db.SaveChanges();
                      }
                      catch
                      {
                         MessageBox.Show("ghg");
                     }


                     }
                    tb_Cus = db.tb_cus.Where(x => x.cus_name == tb_sell.sell_cus).FirstOrDefault();
                  // tb_Cus.total_price += tb_sell.cus_price;
                    tb_Cus.total_price -= tb_sell.total_sell-tb_sell.pay;
                   
                    db.Entry(tb_Cus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    tb_Safe = db.tb_safe.Where(x => x.safe_name ==tb_sell.safe).FirstOrDefault();
                    tb_Safe.safe_count -= tb_sell.pay;
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user1 = (main)Application.OpenForms["main"];
                    string casherName1 = user1?.la_username.Text;
                    var openSession1 = db.Sessions.FirstOrDefault(x => x.namecasher == casherName1 && x.IsClosed == true);
                    if (openSession1 != null)
                    {
                        tb_OperationLog.SessionID = openSession1.SessionID;
                        tb_OperationLog.OperationType = "حذف";
                        tb_OperationLog.TableName = "عملية بيع ";
                        tb_OperationLog.OldValue = openSession1.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession1.ClosingAmount - tb_sell.pay);
                        tb_OperationLog.AmountDifference = -tb_sell.pay;
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();

                        openSession1.ClosingAmount = tb_OperationLog.NewValue;

                        db.SaveChanges();

                    }

                    string notificationMessage = $" تم حذف عملية بيع فاتورة رقم: {tb_sell.invocie_id} عن طريق : {frm_supp_Add.la_username.Text}   التاريخ والوقت: {DateTime.Now:yyyy/MM/dd hh:mm tt}.  ";

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
                ShowDialogMessage("لا يوجد عملية بيع لحذفها.");
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
            List<tb_sell> data = db.tb_sell.ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
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
            pl.frm_sell_add frm_supp_Add = new frm_sell_add();
            int selectedIndex = gridView1.FocusedRowHandle;

            if (selectedIndex >= 0 && selectedIndex < gridView1.RowCount)
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));

                frm_supp_Add.Invoices = db.tb_sell.ToList();
                frm_supp_Add.CurrentInvoiceIndex = frm_supp_Add.Invoices.FindIndex(x => x.id == id);

                if (frm_supp_Add.CurrentInvoiceIndex >= 0)
                {
                    frm_supp_Add.id = id;
                   // frm_supp_Add.btn_save.Text = "حفظ";
                    frm_supp_Add.Show();
                }
                else
                {
                    MessageBox.Show("لا يمكن العثور على الفاتورة المحددة.");
                }
            }
            else
            {
                MessageBox.Show("لم يتم تحديد فاتورة.");
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_sell> data = db.tb_sell.Where(x => x.sell_name.Contains(_search) || x.sell_cus.Contains(_search) || x.invocie_id.ToString().Contains(_search) ).ToList(); // جلب البيانات
            data.Reverse();

            gridControl1.DataSource = data;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public string GetHtmlFromTileView()
        {
            // الحصول على تاريخ اليوم
            var today = DateTime.Today;

            // استرجاع الفواتير التي تتطابق مع تاريخ اليوم
            var data = db.tb_sell
               .Where(s => DbFunctions.TruncateTime(s.sell_date) == today) // استرجاع الفواتير الخاصة بتاريخ اليوم
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
            html += "<h3>فواتير المبيعات اليوم</h3>";
            html += "<table>";

            // إضافة عناوين الأعمدة
            html += "<tr><th>المتبقى</th><th>المدفوع</th><th>الاجمالى</th><th>اجمالى الفاتورة</th><th>التاريخ</th><th>اسم العميل</th><th>رقم الفاتورة</th></tr>";

            // إضافة البيانات الصفية
            foreach (var item in data)
            {
                html += "<tr>";
                
                html += $"<td>{item.stay}</td>";
                html += $"<td>{item.pay}</td>";
                html += $"<td>{item.total_price}</td>";
                html += $"<td>{item.total_sell}</td>";
                html += $"<td>{item.sell_date}</td>";
                html += $"<td>{item.sell_cus}</td>";
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
                mail.Subject = $"فواتير المبيعات اليوم {DateTime.Today}";
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

        private void frm_sell_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }
    }
}
