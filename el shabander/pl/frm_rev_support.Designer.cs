
namespace el_shabander.pl
{
    partial class frm_rev_support
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rev_support));
            this.pn_cat = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colname_cus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colqt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmony_cust = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstay_mony = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.small = new DevExpress.XtraEditors.CheckEdit();
            this.big = new DevExpress.XtraEditors.CheckEdit();
            this.text_qt = new DevExpress.XtraEditors.SpinEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.edt_price = new System.Windows.Forms.TextBox();
            this.text_stay = new System.Windows.Forms.Label();
            this.text_mony = new System.Windows.Forms.Label();
            this.edt_countsafe = new System.Windows.Forms.Label();
            this.edt_name = new System.Windows.Forms.ComboBox();
            this.edt_type = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_titelpage = new System.Windows.Forms.Label();
            this.edt_date = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_search = new DevExpress.XtraEditors.SimpleButton();
            this.edit_txt = new System.Windows.Forms.TextBox();
            this.btn_updata = new DevExpress.XtraEditors.SimpleButton();
            this.colid = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_name = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_phone = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_email = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_image = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pn_cat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.small.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.big.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_qt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_cat
            // 
            this.pn_cat.BackColor = System.Drawing.Color.Silver;
            this.pn_cat.Controls.Add(this.gridControl1);
            this.pn_cat.Controls.Add(this.panel1);
            this.pn_cat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_cat.Location = new System.Drawing.Point(0, 0);
            this.pn_cat.Name = "pn_cat";
            this.pn_cat.Size = new System.Drawing.Size(1164, 646);
            this.pn_cat.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = typeof(el_shabander.tb_rev_supp);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1164, 218);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.cardView1,
            this.tileView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colname_cus,
            this.gridColumn1,
            this.colname_type,
            this.colqt,
            this.colprice,
            this.colmony_cust,
            this.coldate,
            this.colstay_mony,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colname_cus
            // 
            this.colname_cus.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.colname_cus.AppearanceCell.Options.UseFont = true;
            this.colname_cus.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colname_cus.AppearanceHeader.Options.UseFont = true;
            this.colname_cus.Caption = "اسم المورد";
            this.colname_cus.FieldName = "name_supp";
            this.colname_cus.Name = "colname_cus";
            this.colname_cus.Visible = true;
            this.colname_cus.VisibleIndex = 0;
            this.colname_cus.Width = 99;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "الوحدة";
            this.gridColumn1.FieldName = "unit";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 82;
            // 
            // colname_type
            // 
            this.colname_type.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.colname_type.AppearanceCell.Options.UseFont = true;
            this.colname_type.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colname_type.AppearanceHeader.Options.UseFont = true;
            this.colname_type.Caption = "الصنف";
            this.colname_type.FieldName = "name_type";
            this.colname_type.Name = "colname_type";
            this.colname_type.Visible = true;
            this.colname_type.VisibleIndex = 2;
            this.colname_type.Width = 79;
            // 
            // colqt
            // 
            this.colqt.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.colqt.AppearanceCell.Options.UseFont = true;
            this.colqt.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colqt.AppearanceHeader.Options.UseFont = true;
            this.colqt.Caption = "الكمية";
            this.colqt.FieldName = "qt";
            this.colqt.Name = "colqt";
            this.colqt.Visible = true;
            this.colqt.VisibleIndex = 3;
            this.colqt.Width = 78;
            // 
            // colprice
            // 
            this.colprice.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.colprice.AppearanceCell.Options.UseFont = true;
            this.colprice.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colprice.AppearanceHeader.Options.UseFont = true;
            this.colprice.Caption = "اجمالى السعر";
            this.colprice.FieldName = "price";
            this.colprice.Name = "colprice";
            this.colprice.Visible = true;
            this.colprice.VisibleIndex = 4;
            this.colprice.Width = 91;
            // 
            // colmony_cust
            // 
            this.colmony_cust.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.colmony_cust.AppearanceCell.Options.UseFont = true;
            this.colmony_cust.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colmony_cust.AppearanceHeader.Options.UseFont = true;
            this.colmony_cust.Caption = "حساب سابق";
            this.colmony_cust.FieldName = "mony_cust";
            this.colmony_cust.Name = "colmony_cust";
            this.colmony_cust.Visible = true;
            this.colmony_cust.VisibleIndex = 5;
            this.colmony_cust.Width = 88;
            // 
            // coldate
            // 
            this.coldate.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.coldate.AppearanceCell.Options.UseFont = true;
            this.coldate.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.coldate.AppearanceHeader.Options.UseFont = true;
            this.coldate.Caption = "التاريخ";
            this.coldate.FieldName = "date";
            this.coldate.Name = "coldate";
            this.coldate.Visible = true;
            this.coldate.VisibleIndex = 7;
            this.coldate.Width = 100;
            // 
            // colstay_mony
            // 
            this.colstay_mony.AppearanceCell.Font = new System.Drawing.Font("Cairo", 9.749999F, System.Drawing.FontStyle.Bold);
            this.colstay_mony.AppearanceCell.Options.UseFont = true;
            this.colstay_mony.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colstay_mony.AppearanceHeader.Options.UseFont = true;
            this.colstay_mony.Caption = "الحساب الباقى";
            this.colstay_mony.FieldName = "stay_mony";
            this.colstay_mony.Name = "colstay_mony";
            this.colstay_mony.Visible = true;
            this.colstay_mony.VisibleIndex = 6;
            this.colstay_mony.Width = 85;
            // 
            // cardView1
            // 
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            // 
            // tileView1
            // 
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(326, 306);
            this.tileView1.TileColumns.Add(tableColumnDefinition1);
            tableRowDefinition1.Length.Value = 38D;
            tableRowDefinition2.Length.Value = 42D;
            tableRowDefinition3.Length.Value = 42D;
            tableRowDefinition4.Length.Value = 168D;
            this.tileView1.TileRows.Add(tableRowDefinition1);
            this.tileView1.TileRows.Add(tableRowDefinition2);
            this.tileView1.TileRows.Add(tableRowDefinition3);
            this.tileView1.TileRows.Add(tableRowDefinition4);
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "colsupp_name";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 1;
            tileViewItemElement2.Text = "colsupp_phone";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.RowIndex = 2;
            tileViewItemElement3.Text = "colsupp_email";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.RowIndex = 3;
            tileViewItemElement4.Text = "colsupp_image";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.TileTemplate.Add(tileViewItemElement4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.small);
            this.panel1.Controls.Add(this.big);
            this.panel1.Controls.Add(this.text_qt);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.edt_price);
            this.panel1.Controls.Add(this.text_stay);
            this.panel1.Controls.Add(this.text_mony);
            this.panel1.Controls.Add(this.edt_countsafe);
            this.panel1.Controls.Add(this.edt_name);
            this.panel1.Controls.Add(this.edt_type);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lb_titelpage);
            this.panel1.Controls.Add(this.edt_date);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.edit_txt);
            this.panel1.Controls.Add(this.btn_updata);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 428);
            this.panel1.TabIndex = 2;
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_delete.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Appearance.Options.UseFont = true;
            this.btn_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.ImageOptions.Image")));
            this.btn_delete.Location = new System.Drawing.Point(320, 354);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(159, 56);
            this.btn_delete.TabIndex = 36;
            this.btn_delete.Text = "حذف";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.Location = new System.Drawing.Point(92, 140);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 36);
            this.label16.TabIndex = 35;
            this.label16.Text = "كبرى";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Cairo", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(254, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 36);
            this.label15.TabIndex = 34;
            this.label15.Text = "صغرة";
            // 
            // small
            // 
            this.small.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.small.Location = new System.Drawing.Point(221, 151);
            this.small.Name = "small";
            this.small.Properties.Caption = "";
            this.small.Size = new System.Drawing.Size(16, 20);
            this.small.TabIndex = 33;
            this.small.CheckedChanged += new System.EventHandler(this.small_CheckedChanged);
            this.small.MouseUp += new System.Windows.Forms.MouseEventHandler(this.small_MouseUp);
            // 
            // big
            // 
            this.big.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.big.Location = new System.Drawing.Point(63, 151);
            this.big.Name = "big";
            this.big.Properties.Caption = "";
            this.big.Size = new System.Drawing.Size(16, 20);
            this.big.TabIndex = 32;
            this.big.CheckedChanged += new System.EventHandler(this.big_CheckedChanged);
            this.big.MouseUp += new System.Windows.Forms.MouseEventHandler(this.big_MouseUp);
            // 
            // text_qt
            // 
            this.text_qt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.text_qt.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.text_qt.Location = new System.Drawing.Point(40, 178);
            this.text_qt.Name = "text_qt";
            this.text_qt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_qt.Properties.Appearance.Options.UseFont = true;
            this.text_qt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.text_qt.Size = new System.Drawing.Size(307, 30);
            this.text_qt.TabIndex = 31;
            this.text_qt.EditValueChanged += new System.EventHandler(this.text_qt_EditValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cairo", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(469, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 66);
            this.label7.TabIndex = 30;
            this.label7.Text = "مرتجع مبيعات";
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.Location = new System.Drawing.Point(15, 354);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(288, 56);
            this.btn_add.TabIndex = 29;
            this.btn_add.Text = "سحب الكمية الى المخزن";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click_1);
            // 
            // edt_price
            // 
            this.edt_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_price.Location = new System.Drawing.Point(610, 235);
            this.edt_price.Name = "edt_price";
            this.edt_price.Size = new System.Drawing.Size(312, 29);
            this.edt_price.TabIndex = 28;
            this.edt_price.Text = "0";
            this.edt_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edt_price.TextChanged += new System.EventHandler(this.edt_price_TextChanged);
            // 
            // text_stay
            // 
            this.text_stay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.text_stay.BackColor = System.Drawing.Color.Silver;
            this.text_stay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_stay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_stay.ForeColor = System.Drawing.Color.Blue;
            this.text_stay.Location = new System.Drawing.Point(40, 296);
            this.text_stay.Name = "text_stay";
            this.text_stay.Size = new System.Drawing.Size(307, 28);
            this.text_stay.TabIndex = 26;
            this.text_stay.Text = "0";
            this.text_stay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_mony
            // 
            this.text_mony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.text_mony.BackColor = System.Drawing.Color.Silver;
            this.text_mony.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_mony.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_mony.ForeColor = System.Drawing.Color.Red;
            this.text_mony.Location = new System.Drawing.Point(40, 235);
            this.text_mony.Name = "text_mony";
            this.text_mony.Size = new System.Drawing.Size(307, 29);
            this.text_mony.TabIndex = 26;
            this.text_mony.Text = "0";
            this.text_mony.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edt_countsafe
            // 
            this.edt_countsafe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_countsafe.BackColor = System.Drawing.Color.Silver;
            this.edt_countsafe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edt_countsafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_countsafe.ForeColor = System.Drawing.Color.Green;
            this.edt_countsafe.Location = new System.Drawing.Point(610, 298);
            this.edt_countsafe.Name = "edt_countsafe";
            this.edt_countsafe.Size = new System.Drawing.Size(312, 31);
            this.edt_countsafe.TabIndex = 27;
            this.edt_countsafe.Text = "0";
            this.edt_countsafe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edt_name
            // 
            this.edt_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_name.BackColor = System.Drawing.Color.Gold;
            this.edt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_name.FormattingEnabled = true;
            this.edt_name.Items.AddRange(new object[] {
            "سولار",
            "نثريات",
            "اخرى"});
            this.edt_name.Location = new System.Drawing.Point(610, 94);
            this.edt_name.Name = "edt_name";
            this.edt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_name.Size = new System.Drawing.Size(312, 32);
            this.edt_name.TabIndex = 24;
            this.edt_name.SelectedIndexChanged += new System.EventHandler(this.edt_name_SelectedIndexChanged);
            // 
            // edt_type
            // 
            this.edt_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edt_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.edt_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.edt_type.BackColor = System.Drawing.Color.Lime;
            this.edt_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_type.FormattingEnabled = true;
            this.edt_type.Items.AddRange(new object[] {
            "سولار",
            "نثريات",
            "اخرى",
            "مرتبات",
            "نولون سيارات"});
            this.edt_type.Location = new System.Drawing.Point(39, 91);
            this.edt_type.Name = "edt_type";
            this.edt_type.Size = new System.Drawing.Size(307, 32);
            this.edt_type.TabIndex = 25;
            this.edt_type.SelectedIndexChanged += new System.EventHandler(this.edt_type_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(397, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 45);
            this.label8.TabIndex = 19;
            this.label8.Text = "الحساب الباقى";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(371, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 45);
            this.label4.TabIndex = 19;
            this.label4.Text = "حساب سابق للمورد";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(949, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 45);
            this.label1.TabIndex = 20;
            this.label1.Text = "الكمية فى المخزن";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(982, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 45);
            this.label6.TabIndex = 21;
            this.label6.Text = "سعر الشراء ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(435, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 45);
            this.label2.TabIndex = 21;
            this.label2.Text = "الكمية";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(411, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 45);
            this.label3.TabIndex = 22;
            this.label3.Text = "اسم الصنف";
            // 
            // lb_titelpage
            // 
            this.lb_titelpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_titelpage.AutoSize = true;
            this.lb_titelpage.BackColor = System.Drawing.Color.Transparent;
            this.lb_titelpage.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titelpage.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_titelpage.Location = new System.Drawing.Point(984, 85);
            this.lb_titelpage.Name = "lb_titelpage";
            this.lb_titelpage.Size = new System.Drawing.Size(139, 45);
            this.lb_titelpage.TabIndex = 23;
            this.lb_titelpage.Text = "اسم المورد";
            // 
            // edt_date
            // 
            this.edt_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edt_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edt_date.Location = new System.Drawing.Point(610, 161);
            this.edt_date.Name = "edt_date";
            this.edt_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edt_date.Size = new System.Drawing.Size(312, 31);
            this.edt_date.TabIndex = 17;
            this.edt_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cairo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(1010, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 45);
            this.label5.TabIndex = 16;
            this.label5.Text = "التاريخ";
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_search.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Appearance.Options.UseFont = true;
            this.btn_search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.ImageOptions.Image")));
            this.btn_search.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_search.Location = new System.Drawing.Point(1104, 354);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(47, 56);
            this.btn_search.TabIndex = 6;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // edit_txt
            // 
            this.edit_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_txt.Location = new System.Drawing.Point(666, 367);
            this.edit_txt.Name = "edit_txt";
            this.edit_txt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edit_txt.Size = new System.Drawing.Size(421, 31);
            this.edit_txt.TabIndex = 5;
            this.edit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_updata
            // 
            this.btn_updata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_updata.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updata.Appearance.Options.UseFont = true;
            this.btn_updata.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_updata.ImageOptions.Image")));
            this.btn_updata.Location = new System.Drawing.Point(497, 354);
            this.btn_updata.Name = "btn_updata";
            this.btn_updata.Size = new System.Drawing.Size(148, 56);
            this.btn_updata.TabIndex = 4;
            this.btn_updata.Text = "تحديث";
            this.btn_updata.Click += new System.EventHandler(this.btn_updata_Click);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colsupp_name
            // 
            this.colsupp_name.FieldName = "supp_name";
            this.colsupp_name.Name = "colsupp_name";
            this.colsupp_name.Visible = true;
            this.colsupp_name.VisibleIndex = 3;
            // 
            // colsupp_phone
            // 
            this.colsupp_phone.FieldName = "supp_phone";
            this.colsupp_phone.Name = "colsupp_phone";
            this.colsupp_phone.Visible = true;
            this.colsupp_phone.VisibleIndex = 4;
            // 
            // colsupp_email
            // 
            this.colsupp_email.FieldName = "supp_email";
            this.colsupp_email.Name = "colsupp_email";
            this.colsupp_email.Visible = true;
            this.colsupp_email.VisibleIndex = 1;
            // 
            // colsupp_image
            // 
            this.colsupp_image.FieldName = "supp_image";
            this.colsupp_image.Name = "colsupp_image";
            this.colsupp_image.Visible = true;
            this.colsupp_image.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "الكاشير";
            this.gridColumn2.FieldName = "namecasher";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            this.gridColumn2.Width = 112;
            // 
            // frm_rev_support
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1164, 646);
            this.Controls.Add(this.pn_cat);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_rev_support";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.frm_spend_cus_Activated);
            this.Load += new System.EventHandler(this.frm_rev_customer_Load);
            this.pn_cat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.small.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.big.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_qt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pn_cat;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_search;
        private System.Windows.Forms.TextBox edit_txt;
        private DevExpress.XtraEditors.SimpleButton btn_updata;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn colid;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_name;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_phone;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_email;
        private DevExpress.XtraGrid.Columns.TileViewColumn colsupp_image;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public System.Windows.Forms.TextBox edt_date;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label text_mony;
        public System.Windows.Forms.Label edt_countsafe;
        private System.Windows.Forms.ComboBox edt_name;
        private System.Windows.Forms.ComboBox edt_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_titelpage;
        public DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.TextBox edt_price;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn colname_cus;
        private DevExpress.XtraGrid.Columns.GridColumn colname_type;
        private DevExpress.XtraGrid.Columns.GridColumn colqt;
        private DevExpress.XtraGrid.Columns.GridColumn colprice;
        private DevExpress.XtraGrid.Columns.GridColumn colmony_cust;
        private DevExpress.XtraGrid.Columns.GridColumn coldate;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label text_stay;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn colstay_mony;
        public DevExpress.XtraEditors.SpinEdit text_qt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.CheckEdit small;
        private DevExpress.XtraEditors.CheckEdit big;
        private DevExpress.XtraEditors.SimpleButton btn_delete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}