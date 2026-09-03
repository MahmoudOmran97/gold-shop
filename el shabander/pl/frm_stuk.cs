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
using System.IO;
using Microsoft.Reporting.WebForms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Drawing;

namespace el_shabander.pl
{
    public partial class frm_stuk : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        // tb_pur tb_Pur = new tb_pur();
        tb_stuk tb_Stuk = new tb_stuk();
        bl.methods methods = new bl.methods();
        toast toast = new toast();
        
        int id;
        public frm_stuk()
        {
            InitializeComponent();



         
            el_shabander.gold_shopEntities dbContext = new el_shabander.gold_shopEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.tb_stuk.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.tb_stuk.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
            
        }

       

        private void btn_updata_Click(object sender, EventArgs e)
        {
            updata_data();
        }

       

        public void updata_data()
        {
            db = new gold_shopEntities();
            gridControl1.DataSource = db.tb_stuk.ToList();
        }

       

        private void btn_search_Click(object sender, EventArgs e)
        {
            var _search = edit_txt.Text;
            gridControl1.DataSource = db.tb_stuk.Where(x => x.stuk_name.Contains(_search)   ).ToList();
        }

       

      

        private void btn_rev_Click(object sender, EventArgs e)
        {
            pl.frm_rev_customer frm_supp_Add = new frm_rev_customer();
            //frm_supp_Add.id = 0;
            //frm_supp_Add.btn_add.Text = "تصنيع";
            frm_supp_Add.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            pl.frm_edtitstuck frm_supp_Add = new frm_edtitstuck();
            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_Stuk= db.tb_stuk.Where(x => x.id == id).FirstOrDefault();
            // frm_supp_Add.edt_name.Text = tb_sell.sell_name;
            // tb_sell = db.tb_sell.Where(x => x.sell_cus == edt_cus.Text).FirstOrDefault();
            // 
            //frm_supp_Add.edt_sell.Text = tb_sell.sell_price.ToString();
            // frm_supp_Add.edt_qt.Text = tb_sell.sell_qt.ToString();
            frm_supp_Add.edt_name.Text = tb_Stuk.stuk_name.ToString();
            frm_supp_Add.edt_cat.Text = tb_Stuk.stuk_cat.ToString();
            frm_supp_Add.edt_buy.Text = tb_Stuk.stuk_buy.ToString();
            frm_supp_Add.edt_sell.Text = tb_Stuk.stuk_sell.ToString();
            frm_supp_Add.edt_qt.Text = tb_Stuk.stuk_qt.ToString();
            
           



            frm_supp_Add.id = id;
           // frm_supp_Add.btn_save.Text = "حفظ";
            frm_supp_Add.Show();
        }

        private void frm_stuk_Load(object sender, EventArgs e)
        {

            main frm_supp_Add = new main();
            if (frm_supp_Add.la_roll.Text == "مدير")
            {
                btn_edit.Enabled = true;
                // simpleButton14.Enabled = true;
                // btn_employees.Enabled = true;
            }
            else
            {
                btn_edit.Enabled = false;
                //  simpleButton14.Enabled = false;
                //  btn_employees.Enabled = false;
            }
        }

        private void frm_stuk_Activated(object sender, EventArgs e)
        {
            
            btn_edit.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pl.frm_rev_support frm_supp_Add = new frm_rev_support();
            //frm_supp_Add.id = 0;
            //frm_supp_Add.btn_add.Text = "تصنيع";
            frm_supp_Add.Show();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_Click(sender, e);
        }




        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }




        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("id"));
            tb_Stuk = db.tb_stuk.Where(x => x.id == id).FirstOrDefault();
            Image logoImage = ByteArrayToImage(tb_Stuk.barcode_img);

            // جلب إعدادات الشركة
            var setting = db.AppSettings.FirstOrDefault(s => s.id == 1);
            if (setting == null)
            {
                MessageBox.Show("Settings not found in the database.");
                return;
            }

            // إنشاء التقرير
            using (MemoryStream ms = new MemoryStream(tb_Stuk.barcode_img))
            {
                if (setting.printcod == "50mm x 25mm")
                {
                    XtraReport1 report = new XtraReport1();

                    // بيانات عادية
                    report.productName.Text = tb_Stuk.stuk_name;
                    report.price.Text = tb_Stuk.stuk_sell.ToString();
                    report.company.Text = setting.namecomp;

                    // الصورة
                    report.barcodeImage.Image = Image.FromStream(ms);  // ✅ بدل ImageSource استخدم Image عادي
                    report.barcodeImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;  // عشان تتظبط بالحجم المطلوب
                    report.PrinterName = Properties.Settings.Default.barcodeprint;
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PreviewForm.PrintControl.Zoom = 2.5f;
                    printTool.ShowPreviewDialog();
                }else
                {
                    XtraReport2 report = new XtraReport2();

                    // بيانات عادية
                    report.productName.Text = tb_Stuk.stuk_name;
                    report.price.Text = tb_Stuk.stuk_sell.ToString();
                    report.company.Text = setting.namecomp;

                    // الصورة
                    report.barcodeImage.Image = Image.FromStream(ms);  // ✅ بدل ImageSource استخدم Image عادي
                    report.barcodeImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;  // عشان تتظبط بالحجم المطلوب
                    report.PrinterName = Properties.Settings.Default.barcodeprint;
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.PreviewForm.PrintControl.Zoom = 2.5f;
                    printTool.ShowPreviewDialog();
                }
            }

        }

        private void btn_offer_Click(object sender, EventArgs e)
        {
            pl.frm_calc_bar frm_supp_Add = new frm_calc_bar();
            
            frm_supp_Add.Show();
        }
    }
}
