using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace el_shabander
{
    public partial class XtraReport5 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport5()
        {
            InitializeComponent();
        }

        private void price_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
