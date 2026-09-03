
namespace el_shabander.pl
{
    partial class frm_factory_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_factory_add));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_cost = new System.Windows.Forms.TextBox();
            this.edt_qt = new DevExpress.XtraEditors.SpinEdit();
            this.edt_cat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edt_date = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edt_cat_fact = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label15 = new System.Windows.Forms.Label();
            this.small = new DevExpress.XtraEditors.CheckEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.big = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_qt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.small.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.big.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_titelpage.Location = new System.Drawing.Point(549, 377);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(137, 60);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "التكلفة";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(158, 576);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(499, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "حفظ ";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(480, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 60);
            this.label1.TabIndex = 7;
            this.label1.Text = "اسم الصنف الخام ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(181, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(455, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "اضافة عملية تصنيع";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // edt_cost
            // 
            this.edt_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_cost.BackColor = System.Drawing.Color.LightYellow;
            this.edt_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cost.ForeColor = System.Drawing.Color.Red;
            this.edt_cost.Location = new System.Drawing.Point(96, 394);
            this.edt_cost.Name = "edt_cost";
            this.edt_cost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_cost.Size = new System.Drawing.Size(344, 31);
            this.edt_cost.TabIndex = 16;
            this.edt_cost.Text = "0";
            this.edt_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_cost.TextChanged += new System.EventHandler(this.edt_cost_TextChanged);
            // 
            // edt_qt
            // 
            this.edt_qt.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edt_qt.Location = new System.Drawing.Point(96, 327);
            this.edt_qt.Name = "edt_qt";
            this.edt_qt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_qt.Properties.Appearance.Options.UseFont = true;
            this.edt_qt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edt_qt.Size = new System.Drawing.Size(344, 32);
            this.edt_qt.TabIndex = 56;
            this.edt_qt.EditValueChanged += new System.EventHandler(this.edt_qt_EditValueChanged);
            // 
            // edt_cat
            // 
            this.edt_cat.BackColor = System.Drawing.Color.SpringGreen;
            this.edt_cat.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat.FormattingEnabled = true;
            this.edt_cat.Location = new System.Drawing.Point(96, 127);
            this.edt_cat.Name = "edt_cat";
            this.edt_cat.Size = new System.Drawing.Size(344, 32);
            this.edt_cat.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(553, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 60);
            this.label2.TabIndex = 61;
            this.label2.Text = "الكمية";
            // 
            // edt_date
            // 
            this.edt_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_date.BackColor = System.Drawing.Color.DimGray;
            this.edt_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_date.ForeColor = System.Drawing.Color.Red;
            this.edt_date.Location = new System.Drawing.Point(96, 194);
            this.edt_date.Name = "edt_date";
            this.edt_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_date.Size = new System.Drawing.Size(344, 31);
            this.edt_date.TabIndex = 65;
            this.edt_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(561, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 60);
            this.label6.TabIndex = 64;
            this.label6.Text = "التاريخ";
            // 
            // edt_cat_fact
            // 
            this.edt_cat_fact.BackColor = System.Drawing.Color.Orange;
            this.edt_cat_fact.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat_fact.FormattingEnabled = true;
            this.edt_cat_fact.Items.AddRange(new object[] {
            "منتج خام",
            "منتج مصنع"});
            this.edt_cat_fact.Location = new System.Drawing.Point(96, 260);
            this.edt_cat_fact.Name = "edt_cat_fact";
            this.edt_cat_fact.Size = new System.Drawing.Size(344, 32);
            this.edt_cat_fact.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(462, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(311, 60);
            this.label7.TabIndex = 66;
            this.label7.Text = "اسم الصنف المصنع ";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.CadetBlue;
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl2.Controls.Add(this.label15);
            this.groupControl2.Controls.Add(this.small);
            this.groupControl2.Controls.Add(this.label16);
            this.groupControl2.Controls.Add(this.big);
            this.groupControl2.Location = new System.Drawing.Point(207, 452);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(4);
            this.groupControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl2.Size = new System.Drawing.Size(389, 109);
            this.groupControl2.TabIndex = 70;
            this.groupControl2.Text = "الوحدة للصنف الخام";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Cairo", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(263, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 55);
            this.label15.TabIndex = 42;
            this.label15.Text = "صغرى";
            // 
            // small
            // 
            this.small.Location = new System.Drawing.Point(235, 62);
            this.small.Name = "small";
            this.small.Properties.Caption = "";
            this.small.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.small.Size = new System.Drawing.Size(26, 20);
            this.small.TabIndex = 41;
            this.small.CheckedChanged += new System.EventHandler(this.small_CheckedChanged);
            this.small.MouseUp += new System.Windows.Forms.MouseEventHandler(this.small_MouseUp);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Cairo", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(77, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 55);
            this.label16.TabIndex = 43;
            this.label16.Text = "كبرى";
            // 
            // big
            // 
            this.big.Location = new System.Drawing.Point(29, 62);
            this.big.Name = "big";
            this.big.Properties.Caption = "";
            this.big.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.big.Size = new System.Drawing.Size(30, 20);
            this.big.TabIndex = 40;
            this.big.CheckedChanged += new System.EventHandler(this.big_CheckedChanged);
            this.big.MouseUp += new System.Windows.Forms.MouseEventHandler(this.big_MouseUp);
            // 
            // frm_factory_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(807, 644);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.edt_cat_fact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edt_date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edt_qt);
            this.Controls.Add(this.edt_cat);
            this.Controls.Add(this.edt_cost);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_factory_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edt_qt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.small.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.big.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox edt_cost;
        public DevExpress.XtraEditors.SpinEdit edt_qt;
        public System.Windows.Forms.ComboBox edt_cat;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox edt_date;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox edt_cat_fact;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public DevExpress.XtraEditors.CheckEdit small;
        public DevExpress.XtraEditors.CheckEdit big;
    }
}