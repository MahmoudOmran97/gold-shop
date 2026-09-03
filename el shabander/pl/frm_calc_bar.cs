using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using el_shabander.epl;
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_calc_bar : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_offer tb_Offer = new tb_offer();
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_bar()

        {
            InitializeComponent();
        }

       





        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            if (edt_name.Text == "")
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "اسم العرض مطلوب";
                dialog.Show();
            }
            else
            {
                tb_Offer.name_offer = edt_name.Text;
                tb_Offer.type_offer = tax.Text;
                tb_Offer.quontity = Convert.ToDouble(value_cut.Value);
                db.tb_offer.Add(tb_Offer);
                db.SaveChanges();
                this.Close();
                toast.txt_caption.Text = "تم اضافة عرض جديد";
                toast.Show();
               
                this.Close();

            }
        }

        private void frm_calc_bar_Load(object sender, EventArgs e)
        {
            var r1 = db.tb_offer.Select(x => x.name_offer).ToList();
            edt_cat.DataSource = r1;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_cat.AutoCompleteCustomSource = acsc1;

            tax.Text = "نقدى";
            tax_txt.Text = "$";
        }

        private void btn_changecus_Click(object sender, EventArgs e)
        {
            var tb_offer = db.tb_offer.FirstOrDefault(x => x.name_offer == edt_cat.Text);
            if (tb_offer == null)
            {
                MessageBox.Show("العرض غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // تحقق مما إذا كان الصنف مستخدمًا في جدول tb_stuk
        

            // إذا لم يكن الصنف مستخدمًا، قم بحذفه
            db.Entry(tb_offer).State = EntityState.Deleted;
            db.SaveChanges();

            // تحديث بيانات القائمة بعد الحذف
            var r1 = db.tb_offer.Select(x => x.name_offer).ToList();
            edt_cat.DataSource = r1;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            edt_cat.AutoCompleteCustomSource = acsc1;

            MessageBox.Show("تم حذف العرض بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tax.Text == "نقدى")
            {
                tax_txt.Text = "$";

            }
            else
            {
                tax_txt.Text = "%";
            }
        }
    }
}