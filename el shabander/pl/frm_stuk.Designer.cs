
namespace el_shabander.pl
{
    partial class frm_stuk
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_stuk));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.pn_cat = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colstuk_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstuk_qt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstuk_cat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstuk_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.printbarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_offer = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_rev = new DevExpress.XtraEditors.SimpleButton();
            this.btn_search = new DevExpress.XtraEditors.SimpleButton();
            this.edit_txt = new System.Windows.Forms.TextBox();
            this.btn_updata = new DevExpress.XtraEditors.SimpleButton();
            this.colid = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_name = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_phone = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_email = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colsupp_image = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.pn_cat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.pn_cat.Size = new System.Drawing.Size(1030, 720);
            this.pn_cat.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = typeof(el_shabander.tb_stuk);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit2});
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1030, 640);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.cardView1,
            this.tileView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
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
            this.colstuk_name,
            this.colstuk_qt,
            this.colstuk_cat,
            this.colstuk_type,
            this.gridColumn1,
            this.gridColumn2,
            this.printbarcode});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colstuk_name
            // 
            this.colstuk_name.AppearanceCell.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold);
            this.colstuk_name.AppearanceCell.Options.UseFont = true;
            this.colstuk_name.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colstuk_name.AppearanceHeader.Options.UseFont = true;
            this.colstuk_name.Caption = "اسم المادة";
            this.colstuk_name.FieldName = "stuk_name";
            this.colstuk_name.Name = "colstuk_name";
            this.colstuk_name.OptionsColumn.AllowEdit = false;
            this.colstuk_name.Visible = true;
            this.colstuk_name.VisibleIndex = 0;
            this.colstuk_name.Width = 163;
            // 
            // colstuk_qt
            // 
            this.colstuk_qt.AppearanceCell.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold);
            this.colstuk_qt.AppearanceCell.Options.UseFont = true;
            this.colstuk_qt.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colstuk_qt.AppearanceHeader.Options.UseFont = true;
            this.colstuk_qt.Caption = "الكمية";
            this.colstuk_qt.FieldName = "stuk_qt";
            this.colstuk_qt.Name = "colstuk_qt";
            this.colstuk_qt.OptionsColumn.AllowEdit = false;
            this.colstuk_qt.Visible = true;
            this.colstuk_qt.VisibleIndex = 1;
            this.colstuk_qt.Width = 122;
            // 
            // colstuk_cat
            // 
            this.colstuk_cat.AppearanceCell.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold);
            this.colstuk_cat.AppearanceCell.Options.UseFont = true;
            this.colstuk_cat.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colstuk_cat.AppearanceHeader.Options.UseFont = true;
            this.colstuk_cat.Caption = "الصنف";
            this.colstuk_cat.FieldName = "stuk_cat";
            this.colstuk_cat.Name = "colstuk_cat";
            this.colstuk_cat.OptionsColumn.AllowEdit = false;
            this.colstuk_cat.Visible = true;
            this.colstuk_cat.VisibleIndex = 2;
            this.colstuk_cat.Width = 121;
            // 
            // colstuk_type
            // 
            this.colstuk_type.AppearanceCell.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold);
            this.colstuk_type.AppearanceCell.Options.UseFont = true;
            this.colstuk_type.AppearanceHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.colstuk_type.AppearanceHeader.Options.UseFont = true;
            this.colstuk_type.Caption = "سعر البيع";
            this.colstuk_type.FieldName = "stuk_sell";
            this.colstuk_type.Name = "colstuk_type";
            this.colstuk_type.OptionsColumn.AllowEdit = false;
            this.colstuk_type.Visible = true;
            this.colstuk_type.VisibleIndex = 3;
            this.colstuk_type.Width = 115;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "القيمه الكبرى";
            this.gridColumn1.FieldName = "stuk_qtfacttotal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 112;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "الوحدة";
            this.gridColumn2.FieldName = "unit";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 124;
            // 
            // printbarcode
            // 
            this.printbarcode.Caption = "barcode";
            this.printbarcode.ColumnEdit = this.repositoryItemButtonEdit2;
            this.printbarcode.Name = "printbarcode";
            this.printbarcode.Visible = true;
            this.printbarcode.VisibleIndex = 6;
            this.printbarcode.Width = 80;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
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
            this.panel1.Controls.Add(this.btn_offer);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_rev);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.edit_txt);
            this.panel1.Controls.Add(this.btn_updata);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 80);
            this.panel1.TabIndex = 2;
            // 
            // btn_offer
            // 
            this.btn_offer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_offer.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_offer.Appearance.Options.UseFont = true;
            this.btn_offer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_offer.ImageOptions.SvgImage")));
            this.btn_offer.Location = new System.Drawing.Point(322, 11);
            this.btn_offer.Name = "btn_offer";
            this.btn_offer.Size = new System.Drawing.Size(125, 56);
            this.btn_offer.TabIndex = 12;
            this.btn_offer.Text = "العروض";
            this.btn_offer.Click += new System.EventHandler(this.btn_offer_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(3, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(156, 56);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "مرتجع مورد";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_edit.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Appearance.Options.UseFont = true;
            this.btn_edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit.ImageOptions.Image")));
            this.btn_edit.Location = new System.Drawing.Point(452, 11);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(125, 56);
            this.btn_edit.TabIndex = 10;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_rev
            // 
            this.btn_rev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_rev.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rev.Appearance.Options.UseFont = true;
            this.btn_rev.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_rev.ImageOptions.Image")));
            this.btn_rev.Location = new System.Drawing.Point(164, 11);
            this.btn_rev.Name = "btn_rev";
            this.btn_rev.Size = new System.Drawing.Size(153, 56);
            this.btn_rev.TabIndex = 9;
            this.btn_rev.Text = "مرتجع عميل";
            this.btn_rev.Click += new System.EventHandler(this.btn_rev_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_search.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Appearance.Options.UseFont = true;
            this.btn_search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.ImageOptions.Image")));
            this.btn_search.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_search.Location = new System.Drawing.Point(978, 11);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(47, 56);
            this.btn_search.TabIndex = 6;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // edit_txt
            // 
            this.edit_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_txt.Location = new System.Drawing.Point(722, 23);
            this.edit_txt.Name = "edit_txt";
            this.edit_txt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.edit_txt.Size = new System.Drawing.Size(250, 31);
            this.edit_txt.TabIndex = 5;
            this.edit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_updata
            // 
            this.btn_updata.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_updata.Appearance.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updata.Appearance.Options.UseFont = true;
            this.btn_updata.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_updata.ImageOptions.Image")));
            this.btn_updata.Location = new System.Drawing.Point(582, 11);
            this.btn_updata.Name = "btn_updata";
            this.btn_updata.Size = new System.Drawing.Size(132, 56);
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
            // frm_stuk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 720);
            this.Controls.Add(this.pn_cat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_stuk";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "frm_cat";
            this.Activated += new System.EventHandler(this.frm_stuk_Activated);
            this.Load += new System.EventHandler(this.frm_stuk_Load);
            this.pn_cat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private DevExpress.XtraGrid.Columns.GridColumn colstuk_name;
        private DevExpress.XtraGrid.Columns.GridColumn colstuk_qt;
        private DevExpress.XtraGrid.Columns.GridColumn colstuk_cat;
        private DevExpress.XtraGrid.Columns.GridColumn colstuk_type;
        private DevExpress.XtraEditors.SimpleButton btn_rev;
        public DevExpress.XtraEditors.SimpleButton btn_edit;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn printbarcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        public DevExpress.XtraEditors.SimpleButton btn_offer;
    }
}