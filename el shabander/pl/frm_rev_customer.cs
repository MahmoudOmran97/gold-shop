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
using DevExpress.DataAccess.Native.Excel;
using static System.Net.WebRequestMethods;
namespace el_shabander.pl
{
    public partial class frm_rev_customer : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        double stay, ss, bb,rr;
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_rev_cus tb_Rev_Cus = new tb_rev_cus();
        tb_cus tb_Cus = new tb_cus();
        tb_stuk tb_Stuk = new tb_stuk();
        Notfication notfication = new Notfication();
        frm_sell_add send = new frm_sell_add();
        public int id;
        public frm_rev_customer()
        {
            InitializeComponent();






           
            el_shabander.DB_storeEntities dbContext = new el_shabander.DB_storeEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_rev_cus.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_rev_cus.Local.ToBindingList().Reverse();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
        }

       

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }

       

        private void updata_data()
        {
          //  db = new DB_storeEntities();
            db = new DB_storeEntities();
            List<tb_rev_cus> data = db.tb_rev_cus.ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;
           
        }

        

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            List<tb_rev_cus> data = db.tb_rev_cus.Where(x => x.name_cus.Contains(_search)).ToList();
            data.Reverse();

            gridControl1.DataSource = data;
           // var _search = edit_txt.Text;
           
        }

        

        private void frm_spend_cus_Activated(object sender, EventArgs e)
        {
          
           

        }

       
       
       

       

       
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void edt_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Cus = db.tb_cus.Where(x => x.cus_name == edt_name.Text).FirstOrDefault();
            text_mony.Text = tb_Cus.total_price.ToString();
            sumsaler();
        }

       

        private void text_qt_EditValueChanged(object sender, EventArgs e)
        {
           
            sumsaler();
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            if (id == 0)
            {
                sumsaler();
                tb_Rev_Cus.name_cus = edt_name.Text;
                tb_Rev_Cus.name_type = edt_type.Text;
                tb_Rev_Cus.qt = Convert.ToDouble(text_qt.Text);
                tb_Rev_Cus.price = stay;
                tb_Rev_Cus.qt_stuk = Convert.ToDouble(edt_countsafe.Text);
                tb_Rev_Cus.date = Convert.ToDateTime(edt_date.Text);
                tb_Rev_Cus.mony_cust = Convert.ToDouble(text_mony.Text);
                tb_Rev_Cus.stay_mony = Convert.ToDouble(text_stay.Text);
                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null)
                {
                    // التحقق من أن la_roll يحتوي على قيمة
                    if (!string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    {
                        tb_Rev_Cus.namecasher = frm_supp_Add.la_username.Text;
                    }
                }
                if (small.Checked)
                {
                    tb_Rev_Cus.unit = "صغرى";
                }else if (big.Checked)
                {
                    tb_Rev_Cus.unit = "كبرى";
                }
                    db.tb_rev_cus.Add(tb_Rev_Cus);
                db.SaveChanges();


                // tb_Supp.total_price = Convert.ToDouble(txt_stay.Text) ;

                tb_Cus.total_price = Convert.ToDouble(text_stay.Text);
                db.Entry(tb_Cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
               
                    tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
                    tb_Stuk.stuk_qt = bb;
                    db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                string notificationMessage = $"لقد قام :  {frm_supp_Add.la_username.Text}   بارجاع مبيعات من عميل : {tb_Rev_Cus.name_cus} اسم الصنف : {tb_Rev_Cus.name_type}  ";
                send.SendEmailWithHtmlGridData(notificationMessage);
                notfication.notfication1 = notificationMessage;
                notfication.CreatedAt = DateTime.Now;


                db.Notfications.Add(notfication);
                db.SaveChanges();


                toast.Width = this.Width;
                toast.txt_caption.Text = "تم اضافة مرتجعات الى المخزن";
                toast.Show();
                this.Close();

            }
        }

        private void small_CheckedChanged(object sender, EventArgs e)
        {
            tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
            if (small.Checked)
            {
                if (tb_Stuk.unit == "كبرى")
                {

                    small.Checked = false;
                    big.Checked = true;


                }

                else
                {





                    tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
                    edt_price.Text = tb_Stuk.stuk_sell.ToString();
                    big.Checked = false;
                }
            }
        }

        private void big_CheckedChanged(object sender, EventArgs e)
        {
            if (big.Checked)
            {
                tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
                edt_price.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();
                small.Checked = false;
            }
        }

        private void edt_price_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_price.Text))
            {
               

                if (big.Checked)
                {
                    tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                    edt_price.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();


                }
                else if (small.Checked)
                {
                    tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                    edt_price.Text = tb_Stuk.stuk_sell.ToString();
                    //  big.Checked = false;
                }
               
            }
            sumsaler();
        }

        private void frm_rev_customer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            var r1 = db.tb_cus.Select(x => x.cus_name).ToList();
            var r2 = db.tb_stuk.Select(x => x.stuk_name).ToList();
            edt_name.DataSource = r1;
            edt_type.DataSource = r2;
            AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
            acsc1.AddRange(r1.ToArray());
            acsc2.AddRange(r2.ToArray());
            edt_name.AutoCompleteCustomSource = acsc1;
            edt_type.AutoCompleteCustomSource = acsc2;
            edt_date.Text = (DateTime.Now).ToString();
            big.Checked = true;
        }

        private void small_MouseUp(object sender, MouseEventArgs e)
        {
            if (!small.Checked)
            {
                small.Checked = true;

            }
        }

        private void big_MouseUp(object sender, MouseEventArgs e)
        {
            if (!big.Checked)
            {
                big.Checked = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
                var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    tb_Rev_Cus = db.tb_rev_cus.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_Rev_Cus).State = EntityState.Deleted;
                    db.SaveChanges();
                    toast.txt_caption.Text = "تم الحذف بنجاح";
                    toast.Show();
                    updata_data();

                    /*  tb_stuk = db.tb_stuk.Where(x => x.stuk_name == tb_Pur.pur_name).FirstOrDefault();
                      tb_stuk.stuk_buy -= tb_Pur.pur_buy;
                          tb_stuk.stuk_qt -= tb_Pur.pur_qt;
                          tb_stuk.stuk_tbuy -= tb_Pur.pur_tbuy;*/





                   
                    if (tb_Rev_Cus.unit == "صغرى")
                    {
                        tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == tb_Rev_Cus.name_type).FirstOrDefault();
                        tb_Stuk.stuk_qt -= tb_Rev_Cus.qt;
                        db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (tb_Rev_Cus.unit == "كبرى")
                    {
                        tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == tb_Rev_Cus.name_type).FirstOrDefault();
                        rr= Convert.ToDouble(tb_Rev_Cus.qt )* Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);
                        tb_Stuk.stuk_qt -= rr;
                        db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }



                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    string notificationMessage = $"لقد قام :  {frm_supp_Add.la_username.Text}   بحذف عملية ارجاع مبيعات  : {tb_Rev_Cus.name_cus} اسم الصنف : {tb_Rev_Cus.name_type}  ";
                    send.SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;


                    db.Notfications.Add(notfication);
                    db.SaveChanges();






                    tb_Cus = db.tb_cus.Where(x => x.cus_name == tb_Rev_Cus.name_cus).FirstOrDefault();
                    tb_Cus.total_price +=tb_Rev_Cus.price;
                    // tb_Cus.total_price += tb_Rev_Cus.pay;
                    db.Entry(tb_Cus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }








            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد مرتجعات لحزفها ";
                dialog.Show();
            } 
        }

        private void sumsaler()
        {
            
            if (small.Checked)
            {

                stay = Convert.ToDouble(text_qt.Text) * Convert.ToDouble(edt_price.Text);
                tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
                bb = Convert.ToDouble(edt_countsafe.Text) + Convert.ToDouble(text_qt.Text);
                ss = Convert.ToDouble(text_mony.Text) - stay;
                text_stay.Text = ss.ToString();

            }
            else if (big.Checked)
            {
                stay = Convert.ToDouble(text_qt.Text) * Convert.ToDouble(edt_price.Text);
                tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
                bb = Convert.ToDouble(edt_countsafe.Text) + (Convert.ToDouble(text_qt.Text)*Convert.ToDouble (tb_Stuk.stuk_qtfacttotal));
                ss = Convert.ToDouble(text_mony.Text) - stay;
                text_stay.Text = ss.ToString();
            }
          
            
            


        }

        private void edt_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_type.Text).FirstOrDefault();
            edt_countsafe.Text = tb_Stuk.stuk_qt.ToString();
            // edt_price.Text = tb_Stuk.stuk_sell.ToString();
            if (big.Checked)
            {
                edt_price.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();

                // sumsaler();
            }
            else if (small.Checked)
            {
                //  tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                edt_price.Text = tb_Stuk.stuk_sell.ToString();
                // sumsaler();
            }
            sumsaler();

        }
    }
}
