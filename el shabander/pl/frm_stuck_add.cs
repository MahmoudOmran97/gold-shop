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
using ZXing;

namespace el_shabander.pl
{
    public partial class frm_stuck_add : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        bl.methods methods = new bl.methods();
        tb_stuk tb_stuk = new tb_stuk();
        
        public int id;
        public frm_stuck_add()

        {
            InitializeComponent();
        }

        // دالة لتوليد رقم عشوائي مكون من 5 أرقام وغير مكرر
        private string GenerateUniqueCode()
        {
            Random random = new Random();
            string code;
            bool isUnique;

            do
            {
                code = random.Next(10000000, 99999999).ToString();
                isUnique = !db.tb_stuk.Any(x => x.code == code); // التحقق من أن الكود غير مكرر
            }
            while (!isUnique);

            return code;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            // التحقق من الحقول المطلوبة وعرض رسالة مخصصة
            if (string.IsNullOrWhiteSpace(edt_name.Text))
            {
                ShowDialogMessage("اسم المادة مطلوب.");
                return;
            }
            if (string.IsNullOrWhiteSpace(edt_cat.Text))
            {
                ShowDialogMessage("نوع الصنف مطلوب.");
                return;
            }
            if (string.IsNullOrWhiteSpace(edt_type.Text))
            {
                ShowDialogMessage("نوع المادة مطلوب.");
                return;
            }
            if (string.IsNullOrWhiteSpace(unit_small.Text))
            {
                ShowDialogMessage("نوع الوحدة الصغيرة مطلوب.");
                return;
            }
            if (string.IsNullOrWhiteSpace(unit_big.Text))
            {
                ShowDialogMessage("نوع الوحدة الكبيرة مطلوب.");
                return;
            }
            bool supplierExists = db.tb_stuk.Any(x => x.stuk_name == edt_name.Text && x.id != id);

            if (supplierExists)
            {
                MessageBox.Show("اسم الصنف موجود مسبقًا، الرجاء اختيار اسم آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // باقي الكود لإضافة أو تعديل الصنف
            if (id == 0)
            {
                // إضافة صنف جديد
               
                tb_stuk.stuk_name = edt_name.Text;
                tb_stuk.code = string.IsNullOrWhiteSpace(edt_code.Text) ? GenerateUniqueCode() : edt_code.Text;
                GenerateQRAndBarcodeSideBySide(tb_stuk.code);
                tb_stuk.barcode_img= methods.convert_byte2(pic_cover.Image);
                tb_stuk.stuk_cat = edt_cat.Text;
                tb_stuk.stuk_type = unit_small.Text;
                tb_stuk.stuk_supp = unit_big.Text;
                tb_stuk.type_fact = edt_type.Text;
                tb_stuk.stuk_qt = 0;

                if (Convert.ToDouble(edt_big.Text) > 1)
                {
                    tb_stuk.stuk_qtfacttotal = Convert.ToDouble(edt_big.Text);
                    tb_stuk.unit = "صغرى";
                }
                else
                {
                    tb_stuk.stuk_qtfacttotal = 1;
                    tb_stuk.unit = "كبرى";
                }

                db.tb_stuk.Add(tb_stuk);
                db.SaveChanges();
                ShowToastMessage("تم إضافة صنف");
                this.Close();
            }
            else
            {
                // تعديل الصنف
                var tb_stuk = db.tb_stuk.FirstOrDefault(x => x.id == id);

                if (tb_stuk != null)
                {
                    // حفظ القيمة الأصلية لـ stuk_qtfacttotal والكمية الحالية في المخزن
                    double originalQtfactTotal = Convert.ToDouble(tb_stuk.stuk_qtfacttotal);
                    double originalStukQt = Convert.ToDouble(tb_stuk.stuk_qt);

                    // تحديث معلومات الصنف
                   
                    tb_stuk.stuk_name = edt_name.Text;
                    tb_stuk.code = string.IsNullOrWhiteSpace(edt_code.Text) ? GenerateUniqueCode() : edt_code.Text;
                    GenerateQRAndBarcodeSideBySide(tb_stuk.code);
                    tb_stuk.barcode_img = methods.convert_byte2(pic_cover.Image);
                    tb_stuk.type_fact = edt_type.Text;
                    tb_stuk.stuk_cat = edt_cat.Text;
                    tb_stuk.stuk_type = unit_small.Text;
                    tb_stuk.stuk_supp = unit_big.Text;

                    // تحديث قيمة stuk_qtfacttotal والوحدة بناءً على المدخل
                    double newQtfactTotal = Convert.ToDouble(edt_big.Text) > 1 ? Convert.ToDouble(edt_big.Text) : 1;
                    tb_stuk.stuk_qtfacttotal = newQtfactTotal;
                    tb_stuk.unit = newQtfactTotal > 1 ? "صغرى" : "كبرى";

                    // التحقق مما إذا كانت القيمة الكبرى قد تحولت من 1 إلى قيمة أكبر
                    if (newQtfactTotal != originalQtfactTotal &&
                           (originalQtfactTotal == 1 || newQtfactTotal == 1))
                    {
                        // تحديث الكمية في المخزن بناءً على التغيير
                        tb_stuk.stuk_qt = originalStukQt * (newQtfactTotal / originalQtfactTotal);
                        if (newQtfactTotal > originalQtfactTotal)
                        {
                            tb_stuk.stuk_buy /= (newQtfactTotal / originalQtfactTotal);
                            tb_stuk.stuk_sell /= (newQtfactTotal / originalQtfactTotal);
                        }
                        else
                        {
                            tb_stuk.stuk_buy *= (originalQtfactTotal / newQtfactTotal);
                            tb_stuk.stuk_sell *= (originalQtfactTotal / newQtfactTotal);
                        }

                        MessageBox.Show("تم تعديل الكمية في المخزن بناءً على تغيير", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // حفظ التعديلات في قاعدة البيانات
                    db.Entry(tb_stuk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    if (edt_name_old.Text != tb_stuk.stuk_name)
                    {
                        var purRecords = db.tb_ordersell.Where(x => x.name_sell == edt_name_old.Text).ToList();
                        foreach (var pur in purRecords)
                        {
                            pur.name_sell = tb_stuk.stuk_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        var spendRecords = db.tb_ordersellpop.Where(x => x.name_sell == edt_name_old.Text).ToList();
                        foreach (var pur in spendRecords)
                        {
                            pur.name_sell = tb_stuk.stuk_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        

                    }
                    ShowToastMessage("تم تعديل صنف");

                    this.Close();
                }
            }
        }

        // دالة لإظهار رسالة في نافذة حوار
        private void ShowDialogMessage(string message)
        {
            dialog dialog = new dialog
            {
                Width = this.Width
            };
            dialog.txt_capthion.Text = message;
            dialog.Show();
        }

        // دالة لإظهار رسالة تنبيه عبر التوست
        private void ShowToastMessage(string message)
        {
            toast toast = new toast
            {
                Width = this.Width
            };
            toast.txt_caption.Text = message;
            toast.Show();
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

       

       

       

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
          
        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tb_Employees = db.tb_employees.Where(x => x.emp_name == edt_name.Text).FirstOrDefault();

        }

        private void frm_stor_add_Load(object sender, EventArgs e)
        {  if(id==0)
            {
                edt_cat.DataSource = db.TB_cat.Select(x => x.cat_name).ToList();
                edt_type.Text = "منتج خام";
            }
           
            
        }

       

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_createcode_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string code;
            bool isUnique;

            do
            {
                code = random.Next(10000000, 99999999).ToString();
                isUnique = !db.tb_stuk.Any(x => x.code == code); // التحقق من أن الكود غير مكرر
            }
            while (!isUnique);

            edt_code.Text = code;

        }

        private void edt_code_TextChanged(object sender, EventArgs e)
        {
           if( string.IsNullOrWhiteSpace(edt_code.Text))
            {
                ShowDialogMessage("الرجاءادخال كود");
            }
            else
            {
                GenerateQRAndBarcodeSideBySide(edt_code.Text);
            }
            
        }
        private void GenerateQRAndBarcodeSideBySide(string text)
        {
            // 1. إنشاء QR Code
            BarcodeWriter qrWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 200,  // ارتفاع QR Code
                    Width = 200   // عرض QR Code
                }
            };
            Bitmap qrCodeImage = qrWriter.Write(text);

            // 2. إنشاء Barcode (Code 128)
            BarcodeWriter barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 180,  // نفس ارتفاع QR Code
                    Width = 500    // عرض Barcode
                }
            };
            Bitmap barcodeImage = barcodeWriter.Write(text);

            // 3. دمج QR Code و Barcode جنبًا إلى جنب
            int width = qrCodeImage.Width + barcodeImage.Width + 10; // إجمالي العرض مع مسافة صغيرة
            int height = Math.Max(qrCodeImage.Height, barcodeImage.Height); // الارتفاع هو الأكبر بين الصورتين

            Bitmap combinedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(combinedImage))
            {
                g.Clear(Color.White);  // خلفية بيضاء

                // رسم QR Code على اليسار
                g.DrawImage(qrCodeImage, 0, (height - qrCodeImage.Height) / 2);

                // رسم Barcode على اليمين
                g.DrawImage(barcodeImage, qrCodeImage.Width + 10, (height - barcodeImage.Height) / 2);
            }

            // عرض الصورة المدمجة في PictureBox
            pic_cover.Image = combinedImage;

            // حفظ الصورة (اختياري)
            combinedImage.Save("QR_and_Barcode_SideBySide.png");
        }
    }
}
