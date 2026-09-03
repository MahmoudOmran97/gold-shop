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
using DevExpress.XtraGrid.Views.Tile;
using System.Net.Mail;
using System.Net;

namespace el_shabander.pl
{
    public partial class frm_supp : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_supp tB_supp = new tb_supp();
        bl.methods methods = new bl.methods();
        
        Notfication notfication = new Notfication();
        frm_sell_add send = new frm_sell_add();
        int id;
        public frm_supp()
        {
            InitializeComponent();
            
            el_shabander.DB_storeEntities dbContext = new el_shabander.DB_storeEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_supp.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_supp.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
             tileView1.ItemCustomize += tileView1_ItemCustomize;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl.frm_supp_add frm_supp_Add = new frm_supp_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("id"));

                // جلب المورد للتحقق من القيمة
                tB_supp = db.tb_supp.FirstOrDefault(x => x.id == id);

                if (tB_supp != null)
                {
                    // التحقق إذا كان total_price أكبر من 0
                    if (tB_supp.total_price > 0)
                    {
                        main frm_supp_Add = (main)Application.OpenForms["main"];

                        string notificationMessage = $"لقد حاول :  {frm_supp_Add.la_username.Text}   حذف المورد : {tB_supp.supp_name} من البيانات  ";
                        send.SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;


                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                        MessageBox.Show("لا يمكن حذف هذا المورد لأنه لديه باقي حساب", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                    if (rs == DialogResult.Yes)
                    {
                        db.Entry(tB_supp).State = EntityState.Deleted;
                        db.SaveChanges();
                        main frm_supp_Add = (main)Application.OpenForms["main"];

                        string notificationMessage = $"تم حذف المورد : {tB_supp.supp_name} عن طريق : {frm_supp_Add.la_username.Text}  ";
                        send.SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;


                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                        // عرض رسالة النجاح
                        toast.txt_caption.Text = "تم الحذف بنجاح";
                        toast.Show();
                        updata_data();
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد مورد لحذفه";
                dialog.Show();
            }
        }

        public void updata_data()
        {
            db = new DB_storeEntities();
            gridControl1.DataSource = db.tb_supp.ToList();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pl.frm_supp_add frm_supp_Add = new frm_supp_add();
            id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("id"));
           tB_supp= db.tb_supp.Where(x => x.id == id).FirstOrDefault();
            frm_supp_Add.edt_name.Text = tB_supp.supp_name.ToString();
            frm_supp_Add.edt_name_old.Text = tB_supp.supp_name.ToString();
            frm_supp_Add.edt_phone.Text = tB_supp.supp_phone.ToString();
            frm_supp_Add.edt_email.Text = tB_supp.supp_email.ToString();
            methods.by = tB_supp.supp_image;
            frm_supp_Add.edt_sales.ReadOnly = true;
            frm_supp_Add.edt_sales.Text = tB_supp.total_price.ToString();
            frm_supp_Add.edt_max.Text = tB_supp.supp_max.ToString();
            frm_supp_Add.pic_cover.Image = Image.FromStream(methods.convert_image());
            frm_supp_Add.id = id;
            frm_supp_Add.btn_add.Text = "تعديل";
            frm_supp_Add.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            gridControl1.DataSource = db.tb_supp.Where(x => x.supp_name.Contains(_search) || x.supp_phone.Contains(_search) || x.supp_email.Contains(_search) ).ToList();
        }

        private void btn_spend_Click(object sender, EventArgs e)
        {
            pl.frm_spend_supp frm_supp_Add = new frm_spend_supp();
            //frm_supp_Add.id = 0;
            // frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }
        public string GetHtmlFromTileView()
        {
            // استرجاع البيانات من الجدول المطلوب
            var data = db.tb_supp.ToList(); // أو استبدال tb_cus بالجدول الذي تحتاجه

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
            html += "<h3>الموردين</h3>";
            html += "<table>";

            // إضافة عناوين الأعمدة
            html += "<tr><th>الحساب المتبقي</th><th>العنوان</th><th>رقم الهاتف</th><th>اسم المورد </th></tr>";

            // إضافة البيانات الصفية
            foreach (var item in data)
            {
                html += "<tr>";

                html += $"<td>{item.total_price}</td>";
                html += $"<td>{item.supp_email}</td>";
                html += $"<td>{item.supp_phone}</td>";
                html += $"<td>{item.supp_name}</td>";
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
                mail.Subject = "حسابات الموردين ";
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
        private void tileView1_ItemCustomize(object sender, TileViewItemCustomizeEventArgs e)
        {
            // افترض أن tileView1 هو الـ TileView الخاص بك
            var view = sender as TileView;
            if (view == null)
                return;

            // الحصول على قيم total_price و supp_max
            var currentRow = view.GetRow(e.RowHandle) as tb_supp;
            if (currentRow == null)
                return;

            // الحصول على قيم total_price و supp_max
            double totalPrice = Convert.ToDouble(currentRow.total_price);
            double suppMax = Convert.ToDouble(currentRow.supp_max);

            // تحقق من الشرط لتغيير اللون
            if (totalPrice > suppMax)
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.Red;
                e.Item.AppearanceItem.Normal.ForeColor = Color.White;
            }
            else if (totalPrice >= (suppMax / 2) && totalPrice <= suppMax)
            {
                e.Item.AppearanceItem.Normal.BackColor = Color.Yellow;
                e.Item.AppearanceItem.Normal.ForeColor = Color.Black;
            }
            else
            {
                // تعيين اللون الافتراضي
                e.Item.AppearanceItem.Normal.BackColor = Color.White;
                e.Item.AppearanceItem.Normal.ForeColor = Color.Black;
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }
    }
}
