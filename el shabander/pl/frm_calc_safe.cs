using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace el_shabander.pl
{
    public partial class frm_calc_safe : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        tb_safe tb_Safe = new tb_safe();
        bl.methods methods = new bl.methods();
        tb_employees tb_Employees = new tb_employees();
       tb_stuk tb_stuk = new tb_stuk();
        // double storadd, stortotal, storstay;
        // DateTime time;
        //pl.frm_supp frm_Cat = new frm_supp();
        public int id;
        public frm_calc_safe()

        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           
            FetchAndCombineData();
           

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }





        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
            var r2 = db.tb_safe.Select(x => x.safe_name).ToList();

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


            var sells = db.tb_sell
                .Where(x => x.safe == edt_cus.Text)
                .Select(x => new
                {
                    OperationType = "عملية بيع",
                    name = x.sell_cus,
                    Date = x.sell_date,
                    PreviousBalance = x.cus_price,
                    Returned = x.total_sell,
                    PaidAmount = x.pay,
                    Remaining = x.stay
                   // فرضًا لا يوجد مرتجع في عملية البيع
               }).ToList();

            var spendcus = db.tb_spend_cus
                .Where(x => x.safe == edt_cus.Text)
                .Select(x => new
                {
                    OperationType = "سداد عميل",
                    name = x.name_cus,
                    Date = x.date,
                    PreviousBalance = x.mony_rev,
                    Returned = x.mony_spend - x.mony_spend,
                    PaidAmount = x.mony_spend,
                    Remaining = x.mony_stay
                    // فرضًا لا يوجد مرتجع في سداد العميل
                }).ToList();
            var spendsupp = db.tb_spend_supp
               .Where(x => x.safe == edt_cus.Text)
               .Select(x => new
               {
                   OperationType = "سداد مورد",
                   name = x.name_supp,
                   Date = x.date,
                   PreviousBalance = x.mony_rev,
                   Returned = x.mony_spend - x.mony_spend,
                   PaidAmount = x.mony_spend,
                   Remaining = x.mony_stay
                   // فرضًا لا يوجد مرتجع في سداد العميل
               }).ToList();
            var pay = db.tb_pur
              .Where(x => x.safe == edt_cus.Text)
              .Select(x => new
              {
                  OperationType = "عملية شراء",
                  name = x.pur_supp,
                  Date = x.pur_dat,
                  PreviousBalance = x.supp_price,
                  Returned = x.total_price,
                  PaidAmount = x.pay,
                  Remaining = x.stay
                  // فرضًا لا يوجد مرتجع في عملية البيع
              }).ToList();
            var stor = db.tb_stor
             .Where(x => x.safe_name == edt_cus.Text)
             .Select(x => new
             {
                 OperationType = "مصاريف",
                 name = x.stor_empname,
                 Date = x.stor_dete,
                 PreviousBalance = x.stor_spen - x.stor_spen,
                 Returned = x.stor_spen - x.stor_spen,
                 PaidAmount = x.stor_spen,
                 Remaining = x.stor_spen - x.stor_spen
                 // فرضًا لا يوجد مرتجع في عملية البيع
             }).ToList();
            var addmony = db.tb_add_mony
            .Where(x => x.name_type == edt_cus.Text)
            .Select(x => new
            {
                OperationType = "حركة نقدية",
                name = x.typemotion,
                Date = x.date,
                PreviousBalance = x.price - x.price,
                Returned = x.price - x.price,
                PaidAmount = x.price,
                Remaining = x.price - x.price
                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            // دمج البيانات في قائمة واحدة وترتيبها حسب التاريخ
            var combinedData = sells
                .Concat(spendcus)
                .Concat(spendsupp)
                .Concat(pay)
                .Concat(stor)
                .Concat(addmony)
                .OrderBy(x => x.Date)
                .ToList();
            // إنشاء DataTable وإضافة الأعمدة
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_import_export"].Clear();
            frm_report_view9 reportForm = new frm_report_view9();
            foreach (var item in combinedData)
            {
                dataSet.Tables["tb_import_export"].Rows.Add(id, item.OperationType, item.Date, item.PreviousBalance, item.Returned, item.PaidAmount, item.Remaining, item.name);
            }
            tb_Safe = db.tb_safe.Where(x => x.safe_name == edt_cus.Text).FirstOrDefault();
            string customername = edt_cus.Text;
            string totall_price = tb_Safe.safe_count.ToString();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_import_export"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.LoadReport(customerName, totall_price);
            this.Close();
            reportForm.ShowDialog();

        }
    }
}