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
namespace el_shabander.pl
{
    public partial class frm_safe_as : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        // tb_user tb_user = new tb_user();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        tb_user tb_User = new tb_user();
        tb_add_mony tb_Add_Mony = new tb_add_mony();
        Notfication notfication = new Notfication();
        frm_sell_add send = new frm_sell_add();
        int id;
        public frm_safe_as()
        {
            InitializeComponent();





           
            el_shabander.gold_shopEntities dbContext = new el_shabander.gold_shopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_add_mony.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_add_mony.Local.ToBindingList().Reverse();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            gridView1.OptionsBehavior.Editable = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pl.frm_stor_addmany frm_supp_Add = new frm_stor_addmany();
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
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
                var rs = MessageBox.Show("عملية حذف", "هل انت متاكد من هذة العملية", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    tb_Add_Mony = db.tb_add_mony.Where(x => x.id == id).FirstOrDefault();
                    db.Entry(tb_Add_Mony).State = EntityState.Deleted;
                    db.SaveChanges();
                    tb_Safe = db.tb_safe.Where(x => x.safe_name == tb_Add_Mony.name_type).FirstOrDefault();
                    if (tb_Add_Mony.typemotion == "سحب")
                    {
                        tb_Safe.safe_count += tb_Add_Mony.price;
                        db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        tb_Safe.safe_count -= tb_Add_Mony.price;
                        db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    main frm_supp_Add = (main)Application.OpenForms["main"];

                    string notificationMessage = $" تم حذف عملية: {tb_Add_Mony.typemotion} عن طريق : {frm_supp_Add.la_username.Text} المبلغ : {tb_Add_Mony.price}  التاريخ والوقت: {DateTime.Now:yyyy/MM/dd hh:mm tt}.  ";

                    send.SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;


                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                    toast.txt_caption.Text = "تم الحذف بنجاح";
                    toast.Show();
                    updata_data();
                }

            }
            catch
            {
                dialog.Width = this.Width;
                dialog.txt_capthion.Text = "لا يوجد خزنة لحزفه ";
                dialog.Show();
            }
        }

        public void updata_data()
        {
            db = new gold_shopEntities();
            List<tb_add_mony> data = db.tb_add_mony.ToList();
            data.Reverse();
            gridControl1.DataSource = data;
            save.DataSource = db.tb_safe.Select(x => x.safe_name).ToList();
            tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
            total_save.Text = tb_Safe.safe_count.ToString();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pl.frm_stor_addmanyedit frm_supp_Add = new frm_stor_addmanyedit();
            frm_supp_Add.id = 0;
            frm_supp_Add.Show();


        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            gridControl1.DataSource = db.tb_add_mony.Where(x => x.name_type.Contains(_search)  ).ToList();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frm_safe_as_Load(object sender, EventArgs e)
        {

            main frm_supp_Add = (main)Application.OpenForms["main"];

            if (frm_supp_Add != null)
            {
               // MessageBox.Show("تم العثور على النموذج الرئيسي.");

                // التحقق من أن la_roll يحتوي على قيمة
                if (!string.IsNullOrEmpty(frm_supp_Add.la_roll.Text))
                {
                   // MessageBox.Show($"قيمة la_roll.Text: {frm_supp_Add.la_roll.Text}");

                    // البحث عن المستخدم بناءً على الحالة
                    tb_User = db.tb_user.Where(x => x.user_state == frm_supp_Add.la_roll.Text).FirstOrDefault();

                    // التحقق من حالة المستخدم
                    if (frm_supp_Add.la_roll.Text == "مدير")
                    {
                        btn_edit.Enabled = true;
                       // MessageBox.Show("تم تفعيل زر التحرير");
                    }
                    else if(frm_supp_Add.la_roll.Text == "مستخدم")
                    {
                        btn_edit.Enabled = false;
                      //  MessageBox.Show("تم تعطيل زر التحرير");
                    }
                }
               
            }
            else
            {
                MessageBox.Show("النموذج الرئيسي غير مفتوح أو لم يتم العثور عليه.");
            }
        }

        private void frm_safe_as_Activated(object sender, EventArgs e)
        {
           
        }

        private void edit_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void save_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
            total_save.Text = tb_Safe.safe_count.ToString();
        }
    }
}
