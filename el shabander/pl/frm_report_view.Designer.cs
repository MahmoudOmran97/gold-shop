
namespace el_shabander.pl
{
    partial class frm_report_view
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_report_view));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbsellBindingSource = new System.Windows.Forms.BindingSource(this.components);
           // this.tb_sellTableAdapter = new el_shabander.DB_elshDataSetTableAdapters.tb_sellTableAdapter();
            this.tb_sellBindingSource = new System.Windows.Forms.BindingSource(this.components);
          //  this.dB_elshDataSet = new el_shabander.DB_elshDataSet();
            this.tbsellBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbsellBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sellBindingSource)).BeginInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.dB_elshDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsellBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbsellBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "el_shabander.pl.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(821, 719);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_sellTableAdapter
            // 
          //  this.tb_sellTableAdapter.ClearBeforeFill = true;
            // 
            // dB_elshDataSet
            // 
          //  this.dB_elshDataSet.DataSetName = "DB_elshDataSet";
          //  this.dB_elshDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbsellBindingSource1
            // 
            this.tbsellBindingSource1.DataMember = "tb_sell";
           // this.tbsellBindingSource1.DataSource = this.dB_elshDataSet;
            // 
            // frm_report_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(821, 719);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_report_view";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_report_view_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbsellBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_sellBindingSource)).EndInit();
           // ((System.ComponentModel.ISupportInitialize)(this.dB_elshDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsellBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbsellBindingSource;
       
        private System.Windows.Forms.BindingSource tb_sellBindingSource;
        private System.Windows.Forms.BindingSource tbsellBindingSource1;
        
    }
}