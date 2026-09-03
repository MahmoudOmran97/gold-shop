using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_cat_add : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        TB_cat tb_cat = new TB_cat();
        bl.methods methods = new bl.methods();
       
        pl.frm_cat frm_Cat = new frm_cat();
        public int id;
        public frm_cat_add()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            if (edt_name.Text=="")
            {
               dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم الصنف مطلوب";
                dialog.Show();
            }else
            {
                if(id==0)
                {
                    
                    tb_cat.cat_name = edt_name.Text;
                    tb_cat.cat_cover = methods.convert_byte(pic_cover.Image);
                    db.TB_cat.Add(tb_cat);
                    db.SaveChanges();
                   // toast.Width = this.Width;
                    toast.txt_caption.Text = "تم اضافة صنف جديد";
                    toast.Show();
                    db = new gold_shopEntities();
                   frm_Cat.gridControl1.DataSource = db.TB_cat.ToList();
                    
                    this.Close();

                }
               
            }
        }

        private void edt_chancus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frm_cat_add_Load(object sender, EventArgs e)
        {
            var r1 = db.TB_cat.Select(x => x.cat_name).ToList();
            edt_cat.DataSource = r1;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_cat.AutoCompleteCustomSource = acsc1;
        }

        private void btn_changecus_Click(object sender, EventArgs e)
        {
            var tb_cat = db.TB_cat.FirstOrDefault(x => x.cat_name == edt_cat.Text);
            if (tb_cat == null)
            {
                MessageBox.Show("الصنف غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // تحقق مما إذا كان الصنف مستخدمًا في جدول tb_stuk
            bool isUsedInStuk = db.tb_stuk.Any(x => x.stuk_cat == edt_cat.Text);
            if (isUsedInStuk)
            {
                MessageBox.Show("لا يمكن حذف هذاالتصنيف لأنه مستخدم في الاصناف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // إذا لم يكن الصنف مستخدمًا، قم بحذفه
            db.Entry(tb_cat).State = EntityState.Deleted;
            db.SaveChanges();

            // تحديث بيانات القائمة بعد الحذف
            var r1 = db.TB_cat.Select(x => x.cat_name).ToList();
            edt_cat.DataSource = r1;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_cat.AutoCompleteCustomSource = acsc1;

            MessageBox.Show("تم حذف الصنف بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
