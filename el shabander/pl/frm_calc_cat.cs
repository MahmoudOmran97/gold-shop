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
using Microsoft.Reporting.WinForms;
namespace el_shabander.pl
{
    public partial class frm_calc_cat : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
       tb_stuk tb_stuk = new tb_stuk();
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_cat()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
           // report1.la_cus_price.Text = tb_stuk.total_price.ToString();
            FetchAndCombineData();
           

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }





        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
            var r2 = db.tb_stuk.Select(x => x.stuk_name).ToList();

            edt_cus.DataSource = r2;

            AutoCompleteStringCollection acsc2 = new AutoCompleteStringCollection();

            acsc2.AddRange(r2.ToArray());

            edt_cus.AutoCompleteCustomSource = acsc2;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        public void FetchAndCombineData()
        {
            string customerName = edt_cus.Text; // فرضًا أن اسم TextBox هو textBoxCustomerName


            // جلب البيانات من الجداول الثلاثة بناءً على اسم العميل


            var spends = db.tb_ordersell
              .Where(x => x.name_sell == customerName)
              .Select(x => new
              {
                  x.sell_id,
                  x.price_sell,
                  x.qt_sell,
                  x.tprice_sell,
                  x.weight
              }).ToList();

            // دمج البيانات في قائمة واحدة وترتيبها حسب التاريخ
            var combinedData = (from s in spends
                                join se in db.tb_sell on s.sell_id equals se.id
                                select new
                                {
                                    IdInvoice = se.invocie_id,
                                    Date = se.sell_date,
                                    PreviousBalance = s.price_sell,
                                    PaidAmount = s.qt_sell,
                                    Remaining = s.tprice_sell,
                                    Returned = s.weight
                                }).OrderBy(x => x.Date).ToList();

            // إنشاء DataTable وإضافة الأعمدة
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_cat_card"].Clear();
            frm_report_view10 reportForm = new frm_report_view10();
            foreach (var item in combinedData)
            {
                dataSet.Tables["tb_cat_card"].Rows.Add(id, item.IdInvoice, item.Date, item.PreviousBalance, item.PaidAmount, item.Remaining, item.Returned);
            }
            tb_stuk = db.tb_stuk.Where(x => x.stuk_name == edt_cus.Text).FirstOrDefault();
           

            string customername = edt_cus.Text;
            
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_cat_card"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(customerName);
            this.Close();
            reportForm.ShowDialog();


        }
    }
}