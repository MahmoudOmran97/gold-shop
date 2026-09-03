using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using el_shabander.epl;
using Microsoft.Reporting.WinForms;

namespace el_shabander.pl
{
    public partial class frm_report_view5 : Form
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
        public frm_report_view5()

        {
            InitializeComponent();
        }

        



       




        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
           
        }

        private void frm_report_view_Load(object sender, EventArgs e)
        {
          

            var allItems = db.tb_stuk.ToList();

            // احسب الإجماليات
            double totall_price = allItems.Sum(x => (x.stuk_qt ?? 0) * (x.stuk_buy ?? 0));
            double totall_price2 = allItems.Sum(x => (x.stuk_qt ?? 0) * (x.stuk_sell ?? 0));
            double totall_price3 = totall_price2 - totall_price;

            // حدد الـ DataSource للـ Report
            
          

            // ابعت الـ Parameters
            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("totall_price",  totall_price.ToString()),
        new ReportParameter("totall_price2", totall_price2.ToString()),
        new ReportParameter("totall_price3", totall_price3.ToString())
            };

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();

            this.WindowState = FormWindowState.Maximized;
            

            
           ;
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }
    }
}