
namespace el_shabander.pl
{
    partial class frm_user_add 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_user_add));
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.pic_cover = new DevExpress.XtraEditors.PictureEdit();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.edt_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_roll = new System.Windows.Forms.ComboBox();
            this.edt_mail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddImage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_titelpage.Location = new System.Drawing.Point(840, 122);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(202, 50);
            this.lb_titelpage.TabIndex = 7;
            this.lb_titelpage.Text = "اسم المستخدم";
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(493, 134);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(339, 31);
            this.edt_name.TabIndex = 8;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_name.TextChanged += new System.EventHandler(this.edt_name_TextChanged);
            // 
            // pic_cover
            // 
            this.pic_cover.EditValue = ((object)(resources.GetObject("pic_cover.EditValue")));
            this.pic_cover.Location = new System.Drawing.Point(30, 111);
            this.pic_cover.Name = "pic_cover";
            this.pic_cover.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.pic_cover.Properties.InitialImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pic_cover.Properties.InitialImageOptions.Image")));
            this.pic_cover.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_cover.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_cover.Size = new System.Drawing.Size(332, 359);
            this.pic_cover.TabIndex = 9;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(478, 516);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(564, 56);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "اضافة مستخدم";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(857, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "كلمة المرور";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // edt_pass
            // 
            this.edt_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_pass.BackColor = System.Drawing.Color.LavenderBlush;
            this.edt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_pass.Location = new System.Drawing.Point(493, 213);
            this.edt_pass.Name = "edt_pass";
            this.edt_pass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_pass.Size = new System.Drawing.Size(339, 31);
            this.edt_pass.TabIndex = 8;
            this.edt_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_pass.TextChanged += new System.EventHandler(this.edt_pass_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(883, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 50);
            this.label2.TabIndex = 7;
            this.label2.Text = "الصلاحية";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(323, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 90);
            this.label3.TabIndex = 7;
            this.label3.Text = "اضافة مستخدم";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // edt_roll
            // 
            this.edt_roll.BackColor = System.Drawing.Color.Lime;
            this.edt_roll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edt_roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_roll.FormattingEnabled = true;
            this.edt_roll.Items.AddRange(new object[] {
            "مدير",
            "مدير حسابات",
            "مستخدم"});
            this.edt_roll.Location = new System.Drawing.Point(493, 292);
            this.edt_roll.Name = "edt_roll";
            this.edt_roll.Size = new System.Drawing.Size(339, 33);
            this.edt_roll.TabIndex = 11;
            this.edt_roll.SelectedIndexChanged += new System.EventHandler(this.edt_roll_SelectedIndexChanged);
            // 
            // edt_mail
            // 
            this.edt_mail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_mail.BackColor = System.Drawing.Color.Aquamarine;
            this.edt_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_mail.Location = new System.Drawing.Point(493, 373);
            this.edt_mail.Name = "edt_mail";
            this.edt_mail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_mail.Size = new System.Drawing.Size(339, 31);
            this.edt_mail.TabIndex = 13;
            this.edt_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_mail.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(899, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 50);
            this.label4.TabIndex = 12;
            this.label4.Text = "Email";
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddImage.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Appearance.Options.UseFont = true;
            this.btnAddImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnAddImage.Location = new System.Drawing.Point(100, 476);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(166, 45);
            this.btnAddImage.TabIndex = 14;
            this.btnAddImage.Text = "اضافة صورة";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // frm_user_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1054, 584);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.edt_mail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edt_roll);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.pic_cover);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edt_pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edt_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_titelpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_user_add";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_user_add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_cover.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        public System.Windows.Forms.TextBox edt_name;
        public DevExpress.XtraEditors.PictureEdit pic_cover;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox edt_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox edt_roll;
        public System.Windows.Forms.TextBox edt_mail;
        private System.Windows.Forms.Label label4;
        public DevExpress.XtraEditors.SimpleButton btnAddImage;
    }
}