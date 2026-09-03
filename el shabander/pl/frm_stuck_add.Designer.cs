
namespace el_shabander.pl
{
    partial class frm_stuck_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stuck_add));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.unit_small = new System.Windows.Forms.ComboBox();
            this.unit_big = new System.Windows.Forms.ComboBox();
            this.edt_big = new DevExpress.XtraEditors.SpinEdit();
            this.edt_cat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.edt_code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edt_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.edt_name_old = new System.Windows.Forms.Label();
            this.pic_cover = new DevExpress.XtraEditors.PictureEdit();
            this.btn_createcode = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edt_big.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lb_titelpage.Location = new System.Drawing.Point(518, 88);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(190, 60);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "اسم المادة ";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(171, 668);
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
            this.label1.Location = new System.Drawing.Point(552, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 60);
            this.label1.TabIndex = 7;
            this.label1.Text = "الصنف";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(242, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "اضافة صنف ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.BackColor = System.Drawing.Color.LimeGreen;
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.ForeColor = System.Drawing.Color.Red;
            this.edt_name.Location = new System.Drawing.Point(110, 111);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(344, 31);
            this.edt_name.TabIndex = 16;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // unit_small
            // 
            this.unit_small.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unit_small.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.unit_small.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unit_small.FormattingEnabled = true;
            this.unit_small.Items.AddRange(new object[] {
            "شكارة",
            "كرتونة",
            "طبق",
            "كيلو",
            "قاروصة",
            "قطعة",
            "علبة",
            "كيلو",
            "جرام"});
            this.unit_small.Location = new System.Drawing.Point(110, 618);
            this.unit_small.Name = "unit_small";
            this.unit_small.Size = new System.Drawing.Size(344, 32);
            this.unit_small.TabIndex = 60;
            // 
            // unit_big
            // 
            this.unit_big.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unit_big.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.unit_big.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unit_big.FormattingEnabled = true;
            this.unit_big.Items.AddRange(new object[] {
            "شكارة",
            "كرتونة",
            "طبق",
            "كيلو",
            "قاروصة",
            "قطعة",
            "علبة",
            "كيلو",
            "جرام"});
            this.unit_big.Location = new System.Drawing.Point(110, 559);
            this.unit_big.Name = "unit_big";
            this.unit_big.Size = new System.Drawing.Size(344, 32);
            this.unit_big.TabIndex = 59;
            // 
            // edt_big
            // 
            this.edt_big.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edt_big.Location = new System.Drawing.Point(110, 500);
            this.edt_big.Name = "edt_big";
            this.edt_big.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_big.Properties.Appearance.Options.UseFont = true;
            this.edt_big.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edt_big.Size = new System.Drawing.Size(344, 32);
            this.edt_big.TabIndex = 56;
            // 
            // edt_cat
            // 
            this.edt_cat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.edt_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_cat.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_cat.FormattingEnabled = true;
            this.edt_cat.Location = new System.Drawing.Point(110, 169);
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
            this.label2.Location = new System.Drawing.Point(510, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 60);
            this.label2.TabIndex = 61;
            this.label2.Text = "القيمه الكبرى";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(512, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 60);
            this.label4.TabIndex = 62;
            this.label4.Text = "الوحدة الكبرى";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(506, 599);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 60);
            this.label5.TabIndex = 63;
            this.label5.Text = "الوحدة الصغرى";
            // 
            // edt_code
            // 
            this.edt_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_code.BackColor = System.Drawing.Color.DimGray;
            this.edt_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_code.ForeColor = System.Drawing.Color.Red;
            this.edt_code.Location = new System.Drawing.Point(110, 228);
            this.edt_code.Name = "edt_code";
            this.edt_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_code.Size = new System.Drawing.Size(344, 31);
            this.edt_code.TabIndex = 65;
            this.edt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_code.TextChanged += new System.EventHandler(this.edt_code_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(564, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 60);
            this.label6.TabIndex = 64;
            this.label6.Text = "الكود";
            // 
            // edt_type
            // 
            this.edt_type.BackColor = System.Drawing.Color.Orange;
            this.edt_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_type.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_type.FormattingEnabled = true;
            this.edt_type.Items.AddRange(new object[] {
            "منتج خام",
            "منتج مصنع",
            "منتج تصنيع محلى"});
            this.edt_type.Location = new System.Drawing.Point(110, 441);
            this.edt_type.Name = "edt_type";
            this.edt_type.Size = new System.Drawing.Size(344, 32);
            this.edt_type.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(537, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 60);
            this.label7.TabIndex = 66;
            this.label7.Text = "نوع المنتج ";
            // 
            // edt_name_old
            // 
            this.edt_name_old.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.edt_name_old.AutoSize = true;
            this.edt_name_old.BackColor = System.Drawing.Color.Transparent;
            this.edt_name_old.Font = new System.Drawing.Font("Cairo", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name_old.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.edt_name_old.Location = new System.Drawing.Point(106, 88);
            this.edt_name_old.Name = "edt_name_old";
            this.edt_name_old.Size = new System.Drawing.Size(93, 20);
            this.edt_name_old.TabIndex = 68;
            this.edt_name_old.Text = "الحساب الباقى لة";
            this.edt_name_old.Visible = false;
            // 
            // pic_cover
            // 
            this.pic_cover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_cover.EditValue = ((object)(resources.GetObject("pic_cover.EditValue")));
            this.pic_cover.Location = new System.Drawing.Point(110, 286);
            this.pic_cover.Name = "pic_cover";
            this.pic_cover.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.pic_cover.Properties.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pic_cover.Properties.InitialImageOptions.Image")));
            this.pic_cover.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_cover.Properties.ShowMenu = false;
            this.pic_cover.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_cover.Size = new System.Drawing.Size(344, 128);
            this.pic_cover.TabIndex = 69;
            // 
            // btn_createcode
            // 
            this.btn_createcode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_createcode.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createcode.Appearance.Options.UseFont = true;
            this.btn_createcode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.ImageOptions.Image")));
            this.btn_createcode.Location = new System.Drawing.Point(528, 215);
            this.btn_createcode.Name = "btn_createcode";
            this.btn_createcode.Size = new System.Drawing.Size(158, 48);
            this.btn_createcode.TabIndex = 70;
            this.btn_createcode.Text = "تفعيل كود";
            this.btn_createcode.Click += new System.EventHandler(this.btn_createcode_Click);
            // 
            // frm_stuck_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(807, 736);
            this.Controls.Add(this.btn_createcode);
            this.Controls.Add(this.pic_cover);
            this.Controls.Add(this.edt_name_old);
            this.Controls.Add(this.edt_type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edt_code);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.unit_small);
            this.Controls.Add(this.unit_big);
            this.Controls.Add(this.edt_big);
            this.Controls.Add(this.edt_cat);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_stuck_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frm_stor_add_Activated);
            this.Load += new System.EventHandler(this.frm_stor_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edt_big.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox edt_name;
        public System.Windows.Forms.ComboBox unit_small;
        public System.Windows.Forms.ComboBox unit_big;
        public DevExpress.XtraEditors.SpinEdit edt_big;
        public System.Windows.Forms.ComboBox edt_cat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox edt_code;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox edt_type;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label edt_name_old;
        public DevExpress.XtraEditors.PictureEdit pic_cover;
        public DevExpress.XtraEditors.SimpleButton btn_createcode;
    }
}