using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


using el_shabander.epl;

namespace el_shabander.pl
{
    public partial class frm_report_view : Form
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
        public frm_report_view()

        {
            InitializeComponent();
        }

        



       




        private void frm_stor_add_Activated(object sender, EventArgs e)
        {
           
        }

        private void frm_report_view_Load(object sender, EventArgs e)
        {
            try
            {
                // تكبير النافذة
                this.WindowState = FormWindowState.Maximized;

                // محاولة ملء البيانات
             //   this.tb_sellTableAdapter.Fill(this.dB_elshDataSet.tb_sell);

                // تحديث التقرير
                this.reportViewer1.RefreshReport();

                // تعيين وضع العرض
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            }
          
            catch (Exception ex)
            {
                // عرض رسالة خطأ مع تفاصيل الاستثناء
                MessageBox.Show("An unexpected error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}