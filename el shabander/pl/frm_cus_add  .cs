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
    public partial class frm_cus_add  : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        tb_cus tB_cus = new tb_cus();
        bl.methods methods = new bl.methods();
       
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_cus_add  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (edt_name.Text == "")
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم العميل مطلوب";
                dialog.Show();
            }
            else
            {
                bool customerExists = db.tb_cus.Any(x => x.cus_name == edt_name.Text && x.id != id);

                if (customerExists)
                {
                    MessageBox.Show("اسم العميل موجود مسبقًا، الرجاء اختيار اسم آخر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تعبئة الحقول الفارغة بكلمة "لا يوجد"
                tB_cus.cus_phone = string.IsNullOrWhiteSpace(edt_phone.Text) ? "لا يوجد" : edt_phone.Text;
                tB_cus.cus_email = string.IsNullOrWhiteSpace(edt_email.Text) ? "لا يوجد" : edt_email.Text;

                if (id == 0)
                {
                   
                    tB_cus.cus_name = edt_name.Text;
                    tB_cus.cus_image = methods.convert_byte(pic_cover.Image);
                    tB_cus.total_price = Convert.ToDouble(edt_sales.Text);
                    tB_cus.cus_max = Convert.ToDouble(edt_max.Text);
                    db.tb_cus.Add(tB_cus);
                    db.SaveChanges();

                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم إضافة عميل جديد";
                    toast.Show();
                    frm_sell_add sell = (frm_sell_add)Application.OpenForms["frm_sell_add"];
                    if (sell != null) // إذا كانت النافذة مفتوحة
                    {
                        var r2 = db.tb_cus.Select(x => new { x.cus_name, x.cus_phone }).ToList();

                        AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();

                        foreach (var customer in r2)
                        {
                            acsc2.Add(customer.cus_name);  // إضافة الاسم
                            acsc2.Add(customer.cus_phone); // إضافة رقم الهاتف
                        }

                        sell.edt_cus.AutoCompleteCustomSource = acsc2;
                        sell.edt_cus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        sell.edt_cus.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        sell.edt_cus.DataSource = r2.Select(c => c.cus_name).ToList();

                        sell.edt_cus.Text = edt_name.Text;
                    }

                    this.Close();
                }
                else
                {
                    
                    tB_cus.id = id;
                    tB_cus.cus_name = edt_name.Text;
                    tB_cus.cus_image = methods.convert_byte(pic_cover.Image);
                    tB_cus.total_price = Convert.ToDouble(edt_sales.Text);
                    tB_cus.cus_max = Convert.ToDouble(edt_max.Text);
                    db.Entry(tB_cus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    if (edt_name_old.Text != tB_cus.cus_name)
                    {
                        var purRecords = db.tb_sell.Where(x => x.sell_cus == edt_name_old.Text).ToList();
                        foreach (var pur in purRecords)
                        {
                            pur.sell_cus = tB_cus.cus_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        var spendRecords = db.tb_spend_cus.Where(x => x.name_cus == edt_name_old.Text).ToList();
                        foreach (var pur in spendRecords)
                        {
                            pur.name_cus = tB_cus.cus_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        var revRecords = db.tb_rev_cus.Where(x => x.name_cus == edt_name_old.Text).ToList();
                        foreach (var pur in revRecords)
                        {
                            pur.name_cus = tB_cus.cus_name;
                            db.Entry(pur).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }

                    }

                    toast.Width = this.Width;
                    toast.txt_caption.Text = "تم تعديل العميل بنجاح";
                    toast.Show();
                    this.Close();
                }
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_sales_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_sales.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_sales.Text = "0";
            }
        }

        private void edt_max_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_max.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_max.Text = "0";
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",  // أنواع الصور المدعومة
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)  // مجلد الصور الافتراضي
            };

            // إظهار نافذة اختيار الملفات والتحقق إذا كان المستخدم قد اختار صورة
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // تحميل الصورة المختارة في PictureEdit
                pic_cover.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
