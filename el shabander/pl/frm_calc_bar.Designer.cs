
namespace el_shabander.pl
{
    partial class frm_calc_bar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_calc_bar));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.edt_cat = new System.Windows.Forms.ComboBox();
            this.btn_changecus = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tax_txt = new System.Windows.Forms.Label();
            this.value_cut = new System.Windows.Forms.NumericUpDown();
            this.tax = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_cut)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.Red;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl2.Controls.Add(this.edt_cat);
            this.groupControl2.Controls.Add(this.btn_changecus);
            this.groupControl2.Location = new System.Drawing.Point(12, 347);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl2.Size = new System.Drawing.Size(519, 141);
            this.groupControl2.TabIndex = 44;
            this.groupControl2.Text = "حذف عرض";
            // 
            // edt_cat
            // 
            this.edt_cat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_cat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_cat.BackColor = System.Drawing.Color.DimGray;
            this.edt_cat.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat.FormattingEnabled = true;
            this.edt_cat.Location = new System.Drawing.Point(9, 69);
            this.edt_cat.Name = "edt_cat";
            this.edt_cat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_cat.Size = new System.Drawing.Size(318, 38);
            this.edt_cat.TabIndex = 42;
            // 
            // btn_changecus
            // 
            this.btn_changecus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_changecus.Appearance.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changecus.Appearance.Options.UseFont = true;
            this.btn_changecus.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_changecus.ImageOptions.Image")));
            this.btn_changecus.Location = new System.Drawing.Point(371, 69);
            this.btn_changecus.Name = "btn_changecus";
            this.btn_changecus.Size = new System.Drawing.Size(116, 38);
            this.btn_changecus.TabIndex = 41;
            this.btn_changecus.Text = "حذف";
            this.btn_changecus.Click += new System.EventHandler(this.btn_changecus_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_add.ImageOptions.SvgImage")));
            this.btn_add.Location = new System.Drawing.Point(98, 266);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(330, 56);
            this.btn_add.TabIndex = 43;
            this.btn_add.Text = "حفظ العرض";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(34, 102);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(327, 31);
            this.edt_name.TabIndex = 42;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_titelpage.Location = new System.Drawing.Point(172, 19);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(189, 60);
            this.lb_titelpage.TabIndex = 41;
            this.lb_titelpage.Text = "اضافة عرض";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(379, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 50);
            this.label1.TabIndex = 45;
            this.label1.Text = "اسم العرض";
            // 
            // tax_txt
            // 
            this.tax_txt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tax_txt.AutoSize = true;
            this.tax_txt.BackColor = System.Drawing.Color.Transparent;
            this.tax_txt.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tax_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tax_txt.Location = new System.Drawing.Point(158, 187);
            this.tax_txt.Name = "tax_txt";
            this.tax_txt.Size = new System.Drawing.Size(58, 30);
            this.tax_txt.TabIndex = 82;
            this.tax_txt.Text = "الخصم";
            this.tax_txt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // value_cut
            // 
            this.value_cut.BackColor = System.Drawing.Color.Teal;
            this.value_cut.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value_cut.ForeColor = System.Drawing.Color.LightYellow;
            this.value_cut.Location = new System.Drawing.Point(225, 190);
            this.value_cut.Name = "value_cut";
            this.value_cut.Size = new System.Drawing.Size(130, 30);
            this.value_cut.TabIndex = 81;
            this.value_cut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tax
            // 
            this.tax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tax.BackColor = System.Drawing.Color.Lime;
            this.tax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tax.FormattingEnabled = true;
            this.tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tax.Items.AddRange(new object[] {
            "نقدى",
            "نسبة"});
            this.tax.Location = new System.Drawing.Point(34, 190);
            this.tax.Name = "tax";
            this.tax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tax.Size = new System.Drawing.Size(118, 28);
            this.tax.TabIndex = 80;
            this.tax.SelectedIndexChanged += new System.EventHandler(this.tax_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Cairo", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(415, 178);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 43);
            this.label20.TabIndex = 79;
            this.label20.Text = "الخصم";
            // 
            // frm_calc_bar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(543, 516);
            this.Controls.Add(this.tax_txt);
            this.Controls.Add(this.value_cut);
            this.Controls.Add(this.tax);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_calc_bar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_calc_bar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.value_cut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        public System.Windows.Forms.ComboBox edt_cat;
        public DevExpress.XtraEditors.SimpleButton btn_changecus;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        public System.Windows.Forms.TextBox edt_name;
        private System.Windows.Forms.Label lb_titelpage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tax_txt;
        private System.Windows.Forms.NumericUpDown value_cut;
        public System.Windows.Forms.ComboBox tax;
        private System.Windows.Forms.Label label20;
    }
}