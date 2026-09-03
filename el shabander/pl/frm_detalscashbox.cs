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
    public partial class frm_detalscashbox : Form
    {
        gold_shopEntities db = new gold_shopEntities();
        TB_cat tB_Cat = new TB_cat();
        bl.methods methods = new bl.methods();
        //toast toast = new toast();

        public int id;
        public frm_detalscashbox()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
        }



        public void updata_data()
        {

            db = new gold_shopEntities();
            List<tb_OperationLog> data = db.tb_OperationLog.Where(x => x.SessionID == id).ToList(); // جلب البيانات
            data.Reverse();
            gridControl1.DataSource = data;

            var openSession = db.Sessions.FirstOrDefault(x => x.SessionID == id);
            if (openSession != null)
            {
                newamount.Text = openSession.ClosingAmount.ToString();
                oldamount.Text = openSession.OpeningAmount.ToString();
            }

        }

        private void frm_detalscashbox_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
