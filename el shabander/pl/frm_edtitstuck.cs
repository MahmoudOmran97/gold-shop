using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_edtitstuck: Form
    {
        gold_shopEntities db = new gold_shopEntities();
        private double _oldQuantity;
        private double _oldBuyPrice;
        private double _oldSellPrice;
        private string _oldCategory;
        tb_stuk tb_stuk = new tb_stuk();
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_edtitstuck ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            // ✅ Validation
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم المادة مطلوب";
                dialog.Show();
                return;
            }

            if (id == 0)
            {
                // وضع الإضافة (إذا كنت تريد إضافة منتج جديد)
                return;
            }

            // ✅ وضع التعديل
            using (var db = new gold_shopEntities())
            {
                var product = db.tb_stuk.Find(id);

                if (product == null)
                {
                    MessageBox.Show("المنتج غير موجود!");
                    return;
                }

                // ✅ تحديث البيانات
                double newQuantity = Convert.ToDouble(edt_qt.Text);
                double newBuyPrice = Convert.ToDouble(edt_buy.Text);
                double newSellPrice = Convert.ToDouble(edt_sell.Text);
                string newCategory = edt_cat.Text;

                product.stuk_name = edt_name.Text;
                product.stuk_cat = newCategory;
                product.stuk_buy = newBuyPrice;
                product.stuk_qt = newQuantity;
                product.stuk_sell = newSellPrice;

                db.SaveChanges();

                // ✅ إنشاء رسالة الإشعار التفصيلية
                var messages = BuildNotificationMessage(
      product.stuk_name,
      newQuantity,
      newBuyPrice,
      newSellPrice,
      newCategory
  );

                SendNotification(db, messages.HtmlMessage, messages.TextMessage);


                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تعديل المنتج بنجاح";
                toast.Show();

                this.Close();
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_sell.Text))
            {
                edt_sell.Text = _oldSellPrice.ToString();
            }
        }



        private void SendNotification(gold_shopEntities db, string htmlMsg, string textMsg)
        {
            // حفظ في قاعدة البيانات (نص فقط)
            var notification = new Notfication
            {
                notfication1 = textMsg,
                CreatedAt = DateTime.Now
            };
            db.Notfications.Add(notification);
            db.SaveChanges();

            // إرسال البريد (HTML)
            try
            {
                pl.frm_sell_add frm_Sell_Add = new pl.frm_sell_add();
                frm_Sell_Add.SendEmailWithHtmlGridData(htmlMsg);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"خطأ في إرسال البريد: {ex.Message}");
            }
        }

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
           /* var r1 = db.tb_employees.Select(x => x.emp_name).ToList();
            var r2 = db.tb_safe.Select(x => x.safe_name).ToList();
            edt_name.DataSource = r1;
            edt_safe.DataSource = r2;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            acsc2.AddRange(r2.ToArray());
            edt_name.AutoCompleteCustomSource = acsc1;
            edt_safe.AutoCompleteCustomSource = acsc2;
            edt_qt.Text = (DateTime.Now).ToString();
           // edt_countsafe.Text = tb_Safe.safe_count.ToString();*/
        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tb_Employees = db.tb_employees.Where(x => x.emp_name == edt_name.Text).FirstOrDefault();

        }

        private void frm_stor_add_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void LoadProductData()
        {
            using (var db = new gold_shopEntities())
            {
                var product = db.tb_stuk.AsNoTracking()
                                .FirstOrDefault(x => x.id == id);

                if (product != null)
                {
                    // ملء الحقول
                    edt_name.Text = product.stuk_name;
                    edt_cat.Text = product.stuk_cat;
                    edt_qt.Text = product.stuk_qt.ToString();
                    edt_buy.Text = product.stuk_buy.ToString();
                    edt_sell.Text = product.stuk_sell.ToString();

                    // ✅ حفظ القيم القديمة للمقارنة
                    _oldQuantity = Convert.ToDouble(product.stuk_qt);
                    _oldBuyPrice = Convert.ToDouble(product.stuk_buy);
                    _oldSellPrice = Convert.ToDouble(product.stuk_sell);
                    _oldCategory = product.stuk_cat;
                }
            }
        }
        private (string HtmlMessage, string TextMessage) BuildNotificationMessage(
    string productName,
    double newQuantity,
    double newBuyPrice,
    double newSellPrice,
    string newCategory)
        {
            main mainForm = (main)Application.OpenForms["main"];
            string userName = mainForm?.la_username.Text ?? "غير معروف";

            StringBuilder html = new StringBuilder();
            StringBuilder text = new StringBuilder();

            // HTML للـ Email
            html.AppendLine($"<div style='direction: rtl; text-align: right;'>");
            html.AppendLine($"<h3 style='color: #e74c3c;'>🔔 تنبيه: تم تعديل منتج</h3>");
            html.AppendLine($"<hr>");
            html.AppendLine($"<p><strong>👤 المستخدم:</strong> {userName}</p>");
            html.AppendLine($"<p><strong>📦 اسم المنتج:</strong> {productName}</p>");
            html.AppendLine($"<p><strong>🕐 التاريخ والوقت:</strong> {DateTime.Now:yyyy/MM/dd hh:mm tt}</p>");
            html.AppendLine($"<hr>");
            html.AppendLine($"<h4 style='color: #3498db;'>📝 التعديلات التي تمت:</h4>");
            html.AppendLine($"<ul style='list-style: none; padding: 0;'>");

            // نص بسيط للـ Notification
            text.AppendLine("🔔 تم تعديل منتج:");
            text.AppendLine($"📦 المنتج: {productName}");
            text.AppendLine($"👤 المستخدم: {userName}");
            text.AppendLine("----------------------");

            bool hasChanges = false;

            if (Math.Abs(_oldQuantity - newQuantity) > 0.001)
            {
                html.AppendLine($"<li>📊 <strong>الكمية:</strong> من {_oldQuantity} إلى {newQuantity}</li>");
                text.AppendLine($"📊 الكمية: من {_oldQuantity} إلى {newQuantity}");
                hasChanges = true;
            }

            if (Math.Abs(_oldBuyPrice - newBuyPrice) > 0.001)
            {
                html.AppendLine($"<li>💰 <strong>سعر الشراء:</strong> من {_oldBuyPrice} إلى {newBuyPrice}</li>");
                text.AppendLine($"💰 سعر الشراء: من {_oldBuyPrice} إلى {newBuyPrice}");
                hasChanges = true;
            }

            if (Math.Abs(_oldSellPrice - newSellPrice) > 0.001)
            {
                html.AppendLine($"<li>💵 <strong>سعر البيع:</strong> من {_oldSellPrice} إلى {newSellPrice}</li>");
                text.AppendLine($"💵 سعر البيع: من {_oldSellPrice} إلى {newSellPrice}");
                hasChanges = true;
            }

            if (_oldCategory != newCategory)
            {
                html.AppendLine($"<li>🏷️ <strong>الفئة:</strong> من {_oldCategory} إلى {newCategory}</li>");
                text.AppendLine($"🏷️ الفئة: من {_oldCategory} إلى {newCategory}");
                hasChanges = true;
            }

            if (!hasChanges)
            {
                html.AppendLine("<li>ℹ️ لم يتم إجراء أي تعديلات</li>");
                text.AppendLine("ℹ️ لم يتم إجراء أي تعديلات");
            }

            html.AppendLine("</ul></div>");

            return (html.ToString(), text.ToString());
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void edt_qt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_qt.Text))
            {
                edt_qt.Text = _oldQuantity.ToString();
            }
        }

        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_buy.Text))
            {
                edt_buy.Text = _oldBuyPrice.ToString();
            }
        }
    }
}
