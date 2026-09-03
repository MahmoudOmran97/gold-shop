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
    public partial class frm_user_add : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        tb_user tB_user = new tb_user();
        bl.methods methods = new bl.methods();
       
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_user_add  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (string.IsNullOrEmpty(edt_name.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم المستخدم مطلوب";
                dialog.Show();
                return;
            }

            if (string.IsNullOrEmpty(edt_pass.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "كلمة المرور مطلوبة";
                dialog.Show();
                return;
            }

            if (edt_pass.Text.Length < 8)
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "كلمة المرور يجب ألا تقل عن 8 أحرف";
                dialog.Show();
                return;
            }

            if (string.IsNullOrEmpty(edt_mail.Text))
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "الإيميل مطلوب";
                dialog.Show();
                return;
            }
            if (id == 0)
            {
                tB_user.user_name = edt_name.Text;
                tB_user.user_pass = edt_pass.Text;
                tB_user.user_roll = edt_roll.Text;
                tB_user.user_state = "مغلق";
                tB_user.user_mail = edt_mail.Text;

                // التحقق من وجود صورة
                if (pic_cover.Image != null)
                {
                    System.Drawing.Imaging.ImageFormat format = pic_cover.Image.RawFormat;

                    // حفظ الصورة بنفس الفورمات اللي جاي بيه
                    tB_user.user_image = methods.convert_byte(pic_cover.Image);

                }

                else
                {
                    tB_user.user_image = null; // أو صورة default من Resources
                }

                db.tb_user.Add(tB_user);
                db.SaveChanges();
                toast.Width = this.Width;
                toast.txt_caption.Text = "تم اضافة مستخدم جديد";
                toast.Show();
                this.Close();
            }
            else
            {
                tB_user = db.tb_user.FirstOrDefault(x => x.id == id);
                tB_user.user_name = edt_name.Text;
                tB_user.user_pass = edt_pass.Text;
                tB_user.user_roll = edt_roll.Text;
                tB_user.user_state = "مغلق";
                tB_user.user_mail = edt_mail.Text;

                // نفس التحقق في التعديل
                if (pic_cover.Image != null)
                {
                    System.Drawing.Imaging.ImageFormat format = pic_cover.Image.RawFormat;

                    // حفظ الصورة بنفس الفورمات اللي جاي بيه
                    tB_user.user_image = methods.convert_byte(pic_cover.Image);

                }



                // لو المستخدم ما غيرش الصورة، سيبها زي ما هي
                // يعني ما تعملش أي حاجة هنا

                db.Entry(tB_user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                toast.Width = this.Width;
                toast.txt_caption.Text = "تم تعديل مستخدم حالى";
                toast.Show();
                db = new gold_shopEntities();
                this.Close();
            }


        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_user_add_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                edt_roll.Text = "مدير";
            }
            else
            {
                // هات المستخدم بالـ ID مش بالحالة
                tB_user = db.tb_user.FirstOrDefault(x => x.id == id);
                if (tB_user != null)
                {
                    edt_name.Text = tB_user.user_name;
                    edt_pass.Text = tB_user.user_pass;
                    edt_mail.Text = tB_user.user_mail;
                    edt_roll.Text = tB_user.user_roll;

                    // تحميل الصورة لو موجودة
                    if (tB_user.user_image != null)
                    {
                        methods.by = tB_user.user_image;
                        Image.FromStream(methods.convert_image());
                    }
                }

                // تحكم في الصلاحيات بناءً على رول المستخدم المفتوح
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_roll.Text))
                {
                    if (frm_supp_Add.la_roll.Text == "مدير حسابات")
                    {
                        for (int i = edt_roll.Items.Count - 1; i >= 0; i--)
                        {
                            if (edt_roll.Items[i].ToString() == "مدير")
                            {
                                edt_roll.Items.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void edt_roll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void edt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void edt_name_TextChanged(object sender, EventArgs e)
        {

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
