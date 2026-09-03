
namespace el_shabander.pl
{
    partial class frm_settingpro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_settingpro));
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.edt_des = new System.Windows.Forms.TextBox();
            this.btnAddImage = new DevExpress.XtraEditors.SimpleButton();
            this.edt_phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edt_addres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edt_logo = new DevExpress.XtraEditors.PictureEdit();
            this.edt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.edt_max_qt = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.edt_time = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_send = new DevExpress.XtraEditors.SimpleButton();
            this.btn_restor = new DevExpress.XtraEditors.SimpleButton();
            this.btn_backup = new DevExpress.XtraEditors.SimpleButton();
            this.dark = new DevExpress.XtraEditors.ToggleSwitch();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.edt_serildevice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edt_serilnam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.frm_cat = new System.Windows.Forms.Panel();
            this.txt_print = new System.Windows.Forms.ComboBox();
            this.pn_prog = new DevExpress.XtraWaitForm.ProgressPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_printcode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_a5 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_invoce = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.fast_print = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_logo.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_max_qt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dark.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.frm_cat.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_save.Appearance.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.Location = new System.Drawing.Point(393, 750);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(370, 46);
            this.btn_save.TabIndex = 20;
            this.btn_save.Text = "حفظ";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.edt_des);
            this.groupBox1.Controls.Add(this.btnAddImage);
            this.groupBox1.Controls.Add(this.edt_phone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.edt_addres);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edt_logo);
            this.groupBox1.Controls.Add(this.edt_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(596, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(562, 732);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اعدادات عامة";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(463, 402);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 36);
            this.label13.TabIndex = 35;
            this.label13.Text = "الوصف";
            // 
            // edt_des
            // 
            this.edt_des.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_des.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.edt_des.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_des.Location = new System.Drawing.Point(43, 363);
            this.edt_des.Multiline = true;
            this.edt_des.Name = "edt_des";
            this.edt_des.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_des.Size = new System.Drawing.Size(382, 108);
            this.edt_des.TabIndex = 34;
            this.edt_des.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddImage.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Appearance.Options.UseFont = true;
            this.btnAddImage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.ImageOptions.Image")));
            this.btnAddImage.Location = new System.Drawing.Point(378, 601);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(166, 45);
            this.btnAddImage.TabIndex = 33;
            this.btnAddImage.Text = "اضافة شعار";
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // edt_phone
            // 
            this.edt_phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_phone.Location = new System.Drawing.Point(43, 269);
            this.edt_phone.Name = "edt_phone";
            this.edt_phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_phone.Size = new System.Drawing.Size(382, 31);
            this.edt_phone.TabIndex = 32;
            this.edt_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(440, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 36);
            this.label4.TabIndex = 31;
            this.label4.Text = "رقم الهاتف";
            // 
            // edt_addres
            // 
            this.edt_addres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_addres.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_addres.Location = new System.Drawing.Point(43, 164);
            this.edt_addres.Name = "edt_addres";
            this.edt_addres.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_addres.Size = new System.Drawing.Size(382, 31);
            this.edt_addres.TabIndex = 30;
            this.edt_addres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(456, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 36);
            this.label3.TabIndex = 29;
            this.label3.Text = "العنوان";
            // 
            // edt_logo
            // 
            this.edt_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.edt_logo.Location = new System.Drawing.Point(81, 483);
            this.edt_logo.Name = "edt_logo";
            this.edt_logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.edt_logo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.edt_logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.edt_logo.Size = new System.Drawing.Size(249, 227);
            this.edt_logo.TabIndex = 28;
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.Location = new System.Drawing.Point(43, 59);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(382, 31);
            this.edt_name.TabIndex = 26;
            this.edt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(437, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 36);
            this.label1.TabIndex = 24;
            this.label1.Text = "اسم الشركة";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.edt_max_qt);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.edt_time);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Controls.Add(this.btn_restor);
            this.groupBox2.Controls.Add(this.btn_backup);
            this.groupBox2.Controls.Add(this.dark);
            this.groupBox2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 451);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(564, 293);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "قاعدة البيانات";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(109, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 36);
            this.label9.TabIndex = 30;
            this.label9.Text = "active dark mode";
            // 
            // edt_max_qt
            // 
            this.edt_max_qt.BackColor = System.Drawing.Color.Gray;
            this.edt_max_qt.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_max_qt.ForeColor = System.Drawing.Color.LightYellow;
            this.edt_max_qt.Location = new System.Drawing.Point(127, 173);
            this.edt_max_qt.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.edt_max_qt.Name = "edt_max_qt";
            this.edt_max_qt.Size = new System.Drawing.Size(147, 43);
            this.edt_max_qt.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(280, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(274, 36);
            this.label11.TabIndex = 29;
            this.label11.Text = "الحد الاقص للكمية فى المخزن ";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(293, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 50);
            this.label12.TabIndex = 27;
            this.label12.Text = "كل";
            // 
            // edt_time
            // 
            this.edt_time.BackColor = System.Drawing.Color.Teal;
            this.edt_time.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_time.ForeColor = System.Drawing.Color.LightYellow;
            this.edt_time.Location = new System.Drawing.Point(127, 120);
            this.edt_time.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.edt_time.Name = "edt_time";
            this.edt_time.Size = new System.Drawing.Size(147, 43);
            this.edt_time.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(37, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 50);
            this.label2.TabIndex = 26;
            this.label2.Text = " ساعة";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(381, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 36);
            this.label8.TabIndex = 25;
            this.label8.Text = "فترة ارسال البيانات";
            // 
            // btn_send
            // 
            this.btn_send.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_send.Appearance.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Appearance.Options.UseFont = true;
            this.btn_send.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_send.ImageOptions.Image")));
            this.btn_send.Location = new System.Drawing.Point(15, 54);
            this.btn_send.Name = "btn_send";
            this.btn_send.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_send.Size = new System.Drawing.Size(157, 46);
            this.btn_send.TabIndex = 23;
            this.btn_send.Text = "ارسال البيانات";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_restor
            // 
            this.btn_restor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_restor.Appearance.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restor.Appearance.Options.UseFont = true;
            this.btn_restor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_restor.ImageOptions.Image")));
            this.btn_restor.Location = new System.Drawing.Point(182, 54);
            this.btn_restor.Name = "btn_restor";
            this.btn_restor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_restor.Size = new System.Drawing.Size(189, 46);
            this.btn_restor.TabIndex = 22;
            this.btn_restor.Text = "استعادة نسخة احتياطية";
            this.btn_restor.Click += new System.EventHandler(this.btn_restor_Click);
            // 
            // btn_backup
            // 
            this.btn_backup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_backup.Appearance.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_backup.Appearance.Options.UseFont = true;
            this.btn_backup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_backup.ImageOptions.Image")));
            this.btn_backup.Location = new System.Drawing.Point(381, 53);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_backup.Size = new System.Drawing.Size(171, 46);
            this.btn_backup.TabIndex = 21;
            this.btn_backup.Text = "اخذ نسخة احتياطية";
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // dark
            // 
            this.dark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dark.EditValue = null;
            this.dark.Location = new System.Drawing.Point(270, 229);
            this.dark.Name = "dark";
            this.dark.Properties.AutoHeight = false;
            this.dark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.dark.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.dark.Properties.OffText = "Off";
            this.dark.Properties.OnText = "On";
            this.dark.Size = new System.Drawing.Size(73, 45);
            this.dark.TabIndex = 31;
            this.dark.Toggled += new System.EventHandler(this.dark_Toggled);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.edt_serildevice);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.edt_serilnam);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(564, 131);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ترخيص النسخة";
            // 
            // edt_serildevice
            // 
            this.edt_serildevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_serildevice.BackColor = System.Drawing.Color.Lime;
            this.edt_serildevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_serildevice.Location = new System.Drawing.Point(13, 49);
            this.edt_serildevice.Name = "edt_serildevice";
            this.edt_serildevice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_serildevice.Size = new System.Drawing.Size(382, 31);
            this.edt_serildevice.TabIndex = 31;
            this.edt_serildevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(425, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 36);
            this.label6.TabIndex = 30;
            this.label6.Text = "سريل الجهاز";
            // 
            // edt_serilnam
            // 
            this.edt_serilnam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_serilnam.BackColor = System.Drawing.Color.Crimson;
            this.edt_serilnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_serilnam.Location = new System.Drawing.Point(13, 90);
            this.edt_serilnam.Name = "edt_serilnam";
            this.edt_serilnam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_serilnam.Size = new System.Drawing.Size(382, 31);
            this.edt_serilnam.TabIndex = 29;
            this.edt_serilnam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(449, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 36);
            this.label5.TabIndex = 28;
            this.label5.Text = "الترخيص";
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(38, 547);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(564, 131);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ترخيص النسخة";
            // 
            // frm_cat
            // 
            this.frm_cat.BackColor = System.Drawing.Color.LightCyan;
            this.frm_cat.Controls.Add(this.pn_prog);
            this.frm_cat.Controls.Add(this.groupBox5);
            this.frm_cat.Controls.Add(this.groupBox3);
            this.frm_cat.Controls.Add(this.groupBox2);
            this.frm_cat.Controls.Add(this.groupBox1);
            this.frm_cat.Controls.Add(this.btn_save);
            this.frm_cat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frm_cat.Location = new System.Drawing.Point(0, 0);
            this.frm_cat.Name = "frm_cat";
            this.frm_cat.Size = new System.Drawing.Size(1170, 799);
            this.frm_cat.TabIndex = 20;
            // 
            // txt_print
            // 
            this.txt_print.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_print.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_print.FormattingEnabled = true;
            this.txt_print.Items.AddRange(new object[] {
            "A5",
            "XP(PRINTER)"});
            this.txt_print.Location = new System.Drawing.Point(6, 63);
            this.txt_print.Name = "txt_print";
            this.txt_print.Size = new System.Drawing.Size(376, 33);
            this.txt_print.TabIndex = 31;
            // 
            // pn_prog
            // 
            this.pn_prog.Appearance.BackColor = System.Drawing.Color.Gray;
            this.pn_prog.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_prog.Appearance.Options.UseBackColor = true;
            this.pn_prog.Appearance.Options.UseFont = true;
            this.pn_prog.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_prog.AppearanceCaption.Options.UseFont = true;
            this.pn_prog.AppearanceCaption.Options.UseTextOptions = true;
            this.pn_prog.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pn_prog.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.pn_prog.AppearanceCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pn_prog.AppearanceDescription.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_prog.AppearanceDescription.Options.UseFont = true;
            this.pn_prog.AppearanceDescription.Options.UseTextOptions = true;
            this.pn_prog.AppearanceDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.pn_prog.AppearanceDescription.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.pn_prog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pn_prog.Caption = "                      الرجاء الانتظار  ";
            this.pn_prog.Description = "تحتاج هذة العملية بعض الوقت";
            this.pn_prog.Location = new System.Drawing.Point(393, 302);
            this.pn_prog.Name = "pn_prog";
            this.pn_prog.Size = new System.Drawing.Size(364, 85);
            this.pn_prog.TabIndex = 33;
            this.pn_prog.Text = "progress";
            this.pn_prog.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_barcode);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.fast_print);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txt_print);
            this.groupBox5.Controls.Add(this.txt_a5);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.txt_invoce);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txt_printcode);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Font = new System.Drawing.Font("Cairo", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(564, 317);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "نوع الطباعة";
            // 
            // txt_printcode
            // 
            this.txt_printcode.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_printcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_printcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_printcode.FormattingEnabled = true;
            this.txt_printcode.Items.AddRange(new object[] {
            "50mm x 25mm",
            "40mm × 20mm"});
            this.txt_printcode.Location = new System.Drawing.Point(6, 102);
            this.txt_printcode.Name = "txt_printcode";
            this.txt_printcode.Size = new System.Drawing.Size(376, 33);
            this.txt_printcode.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(387, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 36);
            this.label10.TabIndex = 31;
            this.label10.Text = "نوع طباعة الباركود";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(386, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 36);
            this.label7.TabIndex = 30;
            this.label7.Text = "نوع طباعة الفاتورة";
            // 
            // txt_a5
            // 
            this.txt_a5.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_a5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_a5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_a5.FormattingEnabled = true;
            this.txt_a5.Location = new System.Drawing.Point(6, 180);
            this.txt_a5.Name = "txt_a5";
            this.txt_a5.Size = new System.Drawing.Size(376, 33);
            this.txt_a5.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(425, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 36);
            this.label14.TabIndex = 44;
            this.label14.Text = "طابعة A5";
            // 
            // txt_invoce
            // 
            this.txt_invoce.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_invoce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_invoce.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoce.FormattingEnabled = true;
            this.txt_invoce.Location = new System.Drawing.Point(6, 141);
            this.txt_invoce.Name = "txt_invoce";
            this.txt_invoce.Size = new System.Drawing.Size(376, 33);
            this.txt_invoce.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(403, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(139, 36);
            this.label15.TabIndex = 42;
            this.label15.Text = "طابعة xprinter";
            // 
            // fast_print
            // 
            this.fast_print.BackColor = System.Drawing.Color.PeachPuff;
            this.fast_print.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fast_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fast_print.FormattingEnabled = true;
            this.fast_print.Items.AddRange(new object[] {
            "FAST",
            "SLOW"});
            this.fast_print.Location = new System.Drawing.Point(6, 258);
            this.fast_print.Name = "fast_print";
            this.fast_print.Size = new System.Drawing.Size(376, 33);
            this.fast_print.TabIndex = 47;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(406, 254);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 36);
            this.label16.TabIndex = 46;
            this.label16.Text = "سرعة الطباعة";
            // 
            // txt_barcode
            // 
            this.txt_barcode.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_barcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_barcode.FormattingEnabled = true;
            this.txt_barcode.Location = new System.Drawing.Point(6, 219);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(376, 33);
            this.txt_barcode.TabIndex = 49;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(401, 215);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(142, 36);
            this.label17.TabIndex = 48;
            this.label17.Text = "طابعة BarCode";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // frm_settingpro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 799);
            this.Controls.Add(this.frm_cat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_settingpro";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاعدادات";
            this.Load += new System.EventHandler(this.frm_setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_logo.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edt_max_qt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edt_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dark.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.frm_cat.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_save;
        private System.Windows.Forms.GroupBox groupBox1;
        public DevExpress.XtraEditors.SimpleButton btnAddImage;
        public System.Windows.Forms.TextBox edt_phone;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox edt_addres;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.PictureEdit edt_logo;
        public System.Windows.Forms.TextBox edt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown edt_max_qt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown edt_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SimpleButton btn_send;
        private DevExpress.XtraEditors.SimpleButton btn_restor;
        private DevExpress.XtraEditors.SimpleButton btn_backup;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox edt_serildevice;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox edt_serilnam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel frm_cat;
        private System.Windows.Forms.ComboBox txt_print;
        private DevExpress.XtraWaitForm.ProgressPanel pn_prog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        public DevExpress.XtraEditors.ToggleSwitch dark;
        private System.Windows.Forms.ComboBox txt_printcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox edt_des;
        private System.Windows.Forms.ComboBox txt_barcode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox fast_print;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox txt_a5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox txt_invoce;
        private System.Windows.Forms.Label label15;
    }
}