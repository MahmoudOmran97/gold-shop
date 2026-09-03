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
    public partial class frm_stor_addmanyedit : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
        Notfication notfication = new Notfication();
        frm_sell_add send = new frm_sell_add();
        tb_add_mony tb_Add_Mony = new tb_add_mony();
        double storadd, stortotal;
       // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_stor_addmanyedit  ()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();



            tb_Add_Mony.name_type = edt_name.Text;
            tb_Add_Mony.price = Convert.ToDouble(edt_add.Text);
            tb_Add_Mony.date = Convert.ToDateTime(date.Text);
            tb_Add_Mony.typemotion = edt_move.Text;
            db.tb_add_mony.Add(tb_Add_Mony);
            db.SaveChanges();


            tb_Safe.safe_count = Convert.ToDouble(edt_stay.Text);

            db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
           
            main frm_supp_Add = (main)Application.OpenForms["main"];

            string notificationMessage = $"لقد اضاف :  {frm_supp_Add.la_username.Text}   مبلغ الى الخزينه : {tb_Add_Mony.price}   ";
            send.SendEmailWithHtmlGridData(notificationMessage);
            notfication.notfication1 = notificationMessage;
            notfication.CreatedAt = DateTime.Now;


            db.Notfications.Add(notfication);
            db.SaveChanges();
            toast.Width = this.Width;
            toast.txt_caption.Text = "تم اضافة مبلغ للخزنة";
            toast.Show();
            this.Close();




        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void edt_salery_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_add.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_add.Text = "0";
            }
            sumsaler();
        }

        private void edt_salerypay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void edt_salerystay_TextChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
             var r1 = db.tb_safe.Select(x => x.safe_name).ToList();
             edt_name.DataSource = r1;
              AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
              acsc1.AddRange(r1.ToArray());
            edt_move.Text = "سحب";
            date.Text = DateTime.Now.ToString();

        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Safe = db.tb_safe.Where(x => x.safe_name == edt_name.Text).FirstOrDefault();
            edt_stay.Text = tb_Safe.safe_count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void edt_add_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_add.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_add.Text = "0";
            }
            sumsaler();
        }

        private void edt_move_SelectedIndexChanged(object sender, EventArgs e)
        {
            sumsaler();
        }

        private void sumsaler()
        {
            storadd = Convert.ToDouble(edt_add.Text);
            stortotal = Convert.ToDouble(tb_Safe.safe_count);
            if (edt_move.Text == "سحب")
            {
                stortotal -= storadd;
            }
            else
            {
                stortotal += storadd;
            }

            edt_stay.Text = stortotal.ToString();

        }
    }
}
