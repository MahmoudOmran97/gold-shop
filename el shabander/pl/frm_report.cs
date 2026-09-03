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
using DevExpress.XtraReports.UI;
using Microsoft.Reporting.WinForms;

namespace el_shabander.pl
{
    public partial class frm_report : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_safe tb_Safe = new tb_safe();

        public int id;
        public frm_report()
        {
            InitializeComponent();

        }






        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view reportForm = new frm_report_view();
            var sells = db.tb_sell.Select(x => new
            {
                cus_name = x.sell_cus,
                Date = x.sell_date,
                totall = x.total_sell,
                PaidAmount = x.pay,
                Remaining = x.stay,
                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_sell"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_sell"].Rows.Add(item.cus_name, item.Date, item.totall, item.PaidAmount, item.Remaining);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_sell"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            reportForm.ShowDialog();
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view2 reportForm = new frm_report_view2();
            var sells = db.tb_pur.Select(x => new
            {
                cus_name = x.pur_supp,
                Date = x.pur_dat,
                totall = x.pur_tbuy,
                PaidAmount = x.pay,
                Remaining = x.stay,
                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_pur"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_pur"].Rows.Add(item.cus_name, item.Date, item.totall, item.PaidAmount, item.Remaining);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_pur"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

            frm_report_view3 reportForm = new frm_report_view3();
            var sells = db.tb_cus.Select(x => new
            {
                cus_name = x.cus_name,
                address = x.cus_email,
                totall = x.total_price,
                phone = x.cus_phone

                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_cus"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_cus"].Rows.Add(item.cus_name, item.address, item.totall, item.phone);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_cus"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();
        }

        private void tileItem7_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view4 reportForm = new frm_report_view4();
            var sells = db.tb_supp.Select(x => new
            {
                cus_name = x.supp_name,
                address = x.supp_email,
                totall = x.total_price,
                phone = x.supp_phone

                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_supp"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_supp"].Rows.Add(item.cus_name, item.address, item.totall, item.phone);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_supp"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {


            pl.frm_calc_cus frm_Calc_Cus = new frm_calc_cus();
            frm_Calc_Cus.Show();
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_supp frm_Calc_Cus = new frm_calc_supp();
            frm_Calc_Cus.Show();
        }

        private void فاتورة_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_cat frm_Calc_Cus = new frm_calc_cat();
            frm_Calc_Cus.Show();
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_earning frm_Calc_Cus = new frm_calc_earning();
            frm_Calc_Cus.Show();
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frm_report_view5 reportForm = new frm_report_view5();
            var sells = db.tb_stuk.Select(x => new
            {
                cus_name = x.stuk_name,
                address = x.stuk_qt,
                totall = x.stuk_buy,
                phone = x.stuk_sell,
                atf = x.stuk_qtfacttotal
                // فرضًا لا يوجد مرتجع في عملية البيع
            }).ToList();
            DataSet1 dataSet = new DataSet1();
            dataSet.Tables["tb_stuk"].Clear();


            foreach (var item in sells)
            {
                dataSet.Tables["tb_stuk"].Rows.Add(item.cus_name, item.address, item.totall, item.phone, item.atf);
            }
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet.Tables["tb_stuk"]);

            reportForm.reportViewer1.LocalReport.DataSources.Clear();
            reportForm.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportForm.ShowDialog();
        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_safe frm_Calc_Cus = new frm_calc_safe();
            frm_Calc_Cus.Show();
        }






        private void frm_report_Load(object sender, EventArgs e)
        {

        }

        private void tileItem11_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_buy frm_Calc_Cus = new frm_calc_buy();
            frm_Calc_Cus.Show();
        }

        private void tileItem13_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            pl.frm_calc_sell frm_Calc_Cus = new frm_calc_sell();
            frm_Calc_Cus.Show();
        }
    }
       
}
