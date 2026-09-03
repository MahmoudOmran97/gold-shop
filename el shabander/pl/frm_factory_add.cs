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
    public partial class frm_factory_add : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        frm_sell_add send = new frm_sell_add();
        tb_stuk tb_stuk = new tb_stuk();
        tb_factory tb_Factory = new tb_factory();
        Notfication notfication = new Notfication();
        public int id;
        public frm_factory_add()

        {
            InitializeComponent();
        }

        // دالة لتوليد رقم عشوائي مكون من 5 أرقام وغير مكرر




        private void btn_add_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();

            // التحقق من الحقول المطلوبة وعرض رسالة مخصصة
            if (string.IsNullOrWhiteSpace(edt_cost.Text))
            {
                ShowDialogMessage("اسم المادة مطلوب.");
                return;
            }
            if (string.IsNullOrWhiteSpace(edt_cat.Text))
            {
                ShowDialogMessage("نوع الصنف مطلوب.");
                return;
            }
            if (string.IsNullOrWhiteSpace(edt_cat_fact.Text))
            {
                ShowDialogMessage("نوع المادة مطلوب.");
                return;
            }


            // باقي الكود لإضافة أو تعديل الصنف
            if (id == 0)
            {


               

                var tb_stuk = db.tb_stuk.FirstOrDefault(x => x.stuk_name == edt_cat.Text);

                if (small.Checked)
                {
                    if(tb_stuk.stuk_qt< Convert.ToDouble(edt_qt.Text))
                    {
                        MessageBox.Show("لا يمكن تصنيع هذة العملية الكمية فى المخزن اقل من كمية التصنيع ");
                        return;
                    }
                    tb_stuk.stuk_qt -= Convert.ToDouble(edt_qt.Text);

                }
                else if (big.Checked)
                {
                    if (tb_stuk.stuk_qt < Convert.ToDouble(edt_qt.Text) * tb_stuk.stuk_qtfacttotal)
                    {
                        MessageBox.Show("لا يمكن تصنيع هذة العملية الكمية فى المخزن اقل من كمية التصنيع ");
                        return;
                    }
                    tb_stuk.stuk_qt -= Convert.ToDouble(edt_qt.Text) * tb_stuk.stuk_qtfacttotal;

                }


                db.Entry(tb_stuk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var tb_stuk2 = db.tb_stuk.FirstOrDefault(x => x.stuk_name == edt_cat_fact.Text);

                if (small.Checked)
                {
                    tb_stuk2.stuk_qt += Convert.ToDouble(edt_qt.Text);

                }
                else if (big.Checked)
                {

                    tb_stuk2.stuk_qt += Convert.ToDouble(edt_qt.Text) * tb_stuk.stuk_qtfacttotal;

                }
                tb_stuk2.stuk_buy = (Convert.ToDouble(edt_cost.Text) / (Convert.ToDouble(edt_qt.Text) ) + Convert.ToDouble(tb_stuk.stuk_buy));
                tb_stuk2.stuk_sell = (Convert.ToDouble(edt_cost.Text) / (Convert.ToDouble(edt_qt.Text)) + Convert.ToDouble(tb_stuk.stuk_sell));


                db.Entry(tb_stuk2).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                tb_Factory.cat_name = edt_cat.Text;
                tb_Factory.cat_name_fact = edt_cat_fact.Text;
                tb_Factory.date = Convert.ToDateTime(edt_date.Text);
                tb_Factory.cost_all = Convert.ToDouble(edt_cost.Text);
                tb_Factory.qt = Convert.ToDouble(edt_qt.Text);

                if (small.Checked)
                {

                    tb_Factory.unit = "صغرى";
                }
                else
                {

                    tb_Factory.unit = "كبرى";

                }
                db.tb_factory.Add(tb_Factory);
                db.SaveChanges();

               

                ShowToastMessage("تم إضافة عملية تصنيع ");
                this.Close();
                string notificationMessage = $"تم تصنيع كمية {tb_Factory.qt} من الصنف {tb_Factory.cat_name} إلى الصنف {tb_Factory.cat_name_fact} بتاريخ {tb_Factory.date}";
                send.SendEmailWithHtmlGridData(notificationMessage);
                notfication.notfication1 = notificationMessage;
                notfication.CreatedAt = DateTime.Now;


                db.Notfications.Add(notfication);
                db.SaveChanges();
            }
            else
            {
                var tb_Factory = db.tb_factory.FirstOrDefault(x => x.id == id);

                if (tb_Factory != null)
                {
                    // استرجاع الكمية القديمة والوحدة قبل التعديل
                    double oldQuantity = Convert.ToDouble(tb_Factory.qt);
                    bool oldUnitIsSmall = tb_Factory.unit == "صغرى";

                    // العثور على المنتج الأول لإرجاع الكمية القديمة
                    var tb_stuk = db.tb_stuk.FirstOrDefault(x => x.stuk_name == tb_Factory.cat_name);
                    if (tb_stuk != null)
                    {
                        if (oldUnitIsSmall) // في حالة الوحدة القديمة كانت "صغرى"
                        {
                            tb_stuk.stuk_qt += oldQuantity;
                        }
                        else // في حالة الوحدة القديمة كانت "كبرى"
                        {
                            tb_stuk.stuk_qt += oldQuantity * tb_stuk.stuk_qtfacttotal;
                        }
                        db.Entry(tb_stuk).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    // العثور على المنتج الثاني لحذف الكمية القديمة من tb_stuk2
                    var tb_stuk2 = db.tb_stuk.FirstOrDefault(x => x.stuk_name == tb_Factory.cat_name_fact);
                    if (tb_stuk2 != null)
                    {
                        if (oldUnitIsSmall) // في حالة الوحدة القديمة كانت "صغرى"
                        {
                            tb_stuk2.stuk_qt -= oldQuantity;
                        }
                        else // في حالة الوحدة القديمة كانت "كبرى"
                        {
                            tb_stuk2.stuk_qt -= oldQuantity * tb_stuk.stuk_qtfacttotal;
                        }
                        db.Entry(tb_stuk2).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    // تحديث بيانات التصنيع بالقيم الجديدة
                   

                    // تحديث الكمية الجديدة في المخزون
                    tb_stuk = db.tb_stuk.FirstOrDefault(x => x.stuk_name == edt_cat.Text);
                    if (tb_stuk != null)
                    {
                        if (small.Checked)
                        {
                           
                            tb_stuk.stuk_qt -= Convert.ToDouble(edt_qt.Text);
                        }
                        else
                        {
                           
                            tb_stuk.stuk_qt -= Convert.ToDouble(edt_qt.Text) * tb_stuk.stuk_qtfacttotal;
                        }

                        db.Entry(tb_stuk).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    tb_stuk2 = db.tb_stuk.FirstOrDefault(x => x.stuk_name == edt_cat_fact.Text);
                    if (tb_stuk2 != null)
                    {
                        if (small.Checked)
                        {
                            tb_stuk2.stuk_qt += Convert.ToDouble(edt_qt.Text);
                        }
                        else
                        {
                            tb_stuk2.stuk_qt += Convert.ToDouble(edt_qt.Text) * tb_stuk.stuk_qtfacttotal;
                        }

                        tb_stuk2.stuk_buy = (Convert.ToDouble(edt_cost.Text) / (Convert.ToDouble(edt_qt.Text)) + Convert.ToDouble(tb_stuk2.stuk_buy));
                        tb_stuk2.stuk_sell = (Convert.ToDouble(edt_cost.Text) / (Convert.ToDouble(edt_qt.Text)) + Convert.ToDouble(tb_stuk2.stuk_sell));

                        db.Entry(tb_stuk2).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    tb_Factory.cat_name = edt_cat.Text;
                    tb_Factory.cat_name_fact = edt_cat_fact.Text;
                    tb_Factory.date = Convert.ToDateTime(edt_date.Text);
                    tb_Factory.cost_all = Convert.ToDouble(edt_cost.Text);
                    tb_Factory.qt = Convert.ToDouble(edt_qt.Text);
                    tb_Factory.unit = small.Checked ? "صغرى" : "كبرى";

                    db.Entry(tb_Factory).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ShowToastMessage("تم تعديل عملية التصنيع ");
                    this.Close();
                }
            }
        }
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
        {
            /* edt_cat.DataSource = db.TB_cat.Select(x => x.cat_name).ToList();
             if (id == 0)
             {
                 edt_cat_fact.Text = "منتج خام";
             }*/
            small.Checked = false;
            big.Checked = true;
            if (id == 0)
            {
                var r1 = db.tb_stuk.Where(x => x.type_fact=="منتج خام").Select(x => x.stuk_name).ToList();
                edt_cat.DataSource = r1;
                AutoCompleteStringCollection acsc1 = new AutoCompleteStringCollection();
                acsc1.AddRange(r1.ToArray());
                edt_cat.AutoCompleteCustomSource = acsc1;
                var r2 = db.tb_stuk.Where(x => x.type_fact == "منتج تصنيع محلى").Select(x => x.stuk_name).ToList();
                edt_cat_fact.DataSource = r2;
                AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();
                acsc1.AddRange(r2.ToArray());
                edt_cat_fact.AutoCompleteCustomSource = acsc2;
                edt_date.Text = (DateTime.Now).ToString();
            }
            
        }

       

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void small_CheckedChanged(object sender, EventArgs e)
        {
            if (small.Checked)
            {

                small.Checked = true;
                big.Checked = false;


            }
        }

        private void big_CheckedChanged(object sender, EventArgs e)
        {
            if (big.Checked)
            {

                    small.Checked = false;
                    big.Checked = true;


            }
        }
        private void big_MouseUp(object sender, MouseEventArgs e)
        {
            if (!big.Checked)
            {
                big.Checked = true;
            }
        }
        private void small_MouseUp(object sender, MouseEventArgs e)
        {
            if (!small.Checked)
            {
                small.Checked = true;


            }

        }

        private void edt_cost_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_cost.Text))
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_cost.Text = "0";
                
            }
        }

        private void edt_qt_EditValueChanged(object sender, EventArgs e)
        {
            if (edt_qt.Text=="0")
            {
                // إذا كانت القيمة فارغة، يمكنك تعيين القيمة الافتراضية مرة أخرى
                edt_qt.Text = "1";

            }
        }
    }
}
