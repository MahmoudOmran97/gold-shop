using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.epl;
using System.Data.Entity;
using DevExpress.XtraReports.UI;
using System.Collections;
using DevExpress.CodeParser;
using System.IO;
using System.Data.Entity.Validation;
using Microsoft.Reporting.WinForms;
using DevExpress.XtraBars;
using System.Net.Mail;
using System.Net;

namespace el_shabander.pl
{
    public partial class frm_sell_add : Form
    {
        DB_storeEntities db = new DB_storeEntities();
        tb_sell tB_sell = new tb_sell();
        tb_pur tb_Pur = new tb_pur();
        tb_cus tb_cus = new tb_cus();
        tb_stuk tb_Stuk = new tb_stuk();
        tb_ordersell tb_Ordersell = new tb_ordersell();
        tb_safe tb_Safe = new tb_safe();
        tb_offer tb_Offer = new tb_offer();
        bl.methods methods = new bl.methods();
        Notfication notfication = new Notfication();
        tb_OperationLog tb_OperationLog = new tb_OperationLog();
        double qtp, qtn, qtr;
        double curnt, prives;
        private bool saveButtonClicked = false;
        double totalinvocie = 0;
        double oldamount = 0;
        double safe;
        string safename;
        public int id;
        DataTable datasells = new DataTable();
        int selectrowindex;

        public frm_sell_add()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }

        private void edt_buy_TextChanged(object sender, EventArgs e) { pro_call(); }
        private void edt_sell_TextChanged(object sender, EventArgs e) { pro_call(); }
        private void frm_sell_add_Activated(object sender, EventArgs e) { }
        private void edt_qt_EditValueChanged(object sender, EventArgs e) { }

        // ✅ Load محسّن
        private void frm_pur_add_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // ✅ 1. تهيئة DataTable
            InitializeDataTable();

            // ✅ 2. تحميل الإعدادات الأساسية
            LoadBasicSettings();

            // ✅ 3. تحميل البيانات حسب الوضع
            if (id == 0)
            {
                InitializeNewInvoice();
            }
            else
            {
                LoadInvoiceData(id);
                groupControl2.Visible = true;
                edt_cus.Enabled = false;
                txt_id.Text = id.ToString();
            }

            // ✅ 4. تحديث أزرار التنقل
            if (Invoices != null && CurrentInvoiceIndex >= 0 && CurrentInvoiceIndex < Invoices.Count)
                DisplayCurrentInvoice();

            UpdateButtonStates();
            edt_code.Clear();
        }

        // ✅ تهيئة DataTable
        private void InitializeDataTable()
        {
            datasells.Columns.Add("اسم المادة");
            datasells.Columns.Add("سعر الوحدة");
            datasells.Columns.Add("الوحدة");
            datasells.Columns.Add("الكمية");
            datasells.Columns.Add("الاجمالى");
            datasells.Columns.Add("عمود مخفي");
            datasells.Columns.Add("قيمة الخصم");

            dataGridView1.DataSource = datasells;
            dataGridView1.DefaultCellStyle.Font = new Font("cairo", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("cairo", 16, FontStyle.Bold);
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.Columns["عمود مخفي"].Visible = false;
        }

        // ✅ تحميل الإعدادات الأساسية
        private void LoadBasicSettings()
        {
            var setting = db.AppSettings.AsNoTracking()
                            .Select(s => new { s.printty })
                            .FirstOrDefault();
            if (setting != null)
                print_check.Text = setting.printty;

            tax.Text = "نقدى";
            tax_txt.Text = "$";
            LoadOffers();
        }

        // ✅ تحميل العروض
        private void LoadOffers()
        {
            var offers = db.tb_offer.AsNoTracking()
                           .Select(x => x.name_offer)
                           .ToList();
            offers.Insert(0, "بدون عرض");
            edt_offer.DataSource = offers;
            edt_offer.SelectedIndex = 0;
        }

        // ✅ تهيئة فاتورة جديدة
        private void InitializeNewInvoice()
        {
            txt_id.Visible = false;
            id_invioce.Visible = false;
            comboBox1.Text = "نقدى";
            FAST.Text = "FAST";
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            big.Checked = true;
            saveButtonClicked = false;

            LoadSafes();
            LoadCustomersLazy();
            LoadProductsLazy();
            ClearFields();
        }

        // ✅ تحميل الخزائن
        private void LoadSafes()
        {
            var safes = db.tb_safe.AsNoTracking()
                          .Select(x => x.safe_name)
                          .ToList();
            save.DataSource = safes;
        }

        // ✅ تحميل العملاء بكفاءة
        private void LoadCustomersLazy()
        {
            var customerNames = db.tb_cus.AsNoTracking()
                                  .Select(x => x.cus_name)
                                  .ToList();
            edt_cus.DataSource = customerNames;

            edt_cus.GotFocus += (s, e) =>
            {
                if (edt_cus.AutoCompleteCustomSource.Count == 0)
                    SetupCustomerAutoComplete();
            };
        }

        // ✅ إعداد AutoComplete للعملاء عند الحاجة
        private void SetupCustomerAutoComplete()
        {
            var customers = db.tb_cus.AsNoTracking()
                              .Select(x => new { x.cus_name, x.cus_phone })
                              .ToList();
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (var c in customers)
            {
                acsc.Add(c.cus_name);
                acsc.Add(c.cus_phone);
            }
            edt_cus.AutoCompleteCustomSource = acsc;
            edt_cus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            edt_cus.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        // ✅ تحميل الأصناف بكفاءة
        private void LoadProductsLazy()
        {
            var productNames = db.tb_stuk.AsNoTracking()
                                 .Select(x => x.stuk_name)
                                 .ToList();
            edt_name.DataSource = productNames;

            edt_name.GotFocus += (s, e) =>
            {
                if (edt_name.AutoCompleteCustomSource.Count == 0)
                    SetupProductAutoComplete();
            };
        }

        // ✅ إعداد AutoComplete للأصناف
        private void SetupProductAutoComplete()
        {
            var productNames = db.tb_stuk.AsNoTracking()
                                 .Select(x => x.stuk_name)
                                 .ToList();
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            acsc.AddRange(productNames.ToArray());
            edt_name.AutoCompleteCustomSource = acsc;
        }

        // ✅ تحميل بيانات الفاتورة (محسّن)
        public void LoadInvoiceData(int invoiceId)
        {
            var tb_sell = db.tb_sell.AsNoTracking()
                            .FirstOrDefault(x => x.id == invoiceId);
            if (tb_sell == null)
            {
                MessageBox.Show("فاتورة غير موجودة");
                return;
            }

            txt_total.Text = tb_sell.total_price.ToString();
            edt_pay.Text = tb_sell.pay.ToString();
            txt_totaldata.Text = tb_sell.total_sell.ToString();
            txt_add.Text = tb_sell.sell_add.ToString();
            txt_cut.Text = tb_sell.cut.ToString();
            txt_manycus.Text = tb_sell.cus_price.ToString();

            LoadSafes();
            save.Text = tb_sell.safe;

            edt_cus.Text = tb_sell.sell_cus;
            id_invioce.Text = tb_sell.invocie_id.ToString();
            totall_buy.Text = tb_sell.total_earnings.ToString();
            safe = Convert.ToDouble(tb_sell.pay);
            safename = tb_sell.safe;
            oldamount = Convert.ToDouble(edt_pay.Text);
            curnt = Convert.ToDouble(tb_sell.stay);
            edt_date.Text = tb_sell.sell_date.ToString();
            datesave.Text = tb_sell.sell_date.ToString();
            chack.Text = curnt.ToString();
            comboBox1.Text = "نقدى";
            FAST.Text = "FAST";
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;

            // تحميل عناصر الفاتورة
            listorder = db.tb_ordersell.AsNoTracking()
                          .Where(x => x.sell_id == invoiceId)
                          .ToList();
            datasells.Rows.Clear();
            foreach (var item in listorder)
                datasells.Rows.Add(item.name_sell, item.price_sell, item.weight,
                    item.qt_sell, item.tprice_sell, item.total_earnings, item.cut);
            dataGridView1.DataSource = datasells;

            // تحميل العملاء في وضع التعديل
            var customerNames = db.tb_cus.AsNoTracking()
                                  .Select(x => x.cus_name).ToList();
            edt_chancus.DataSource = customerNames;
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            acsc.AddRange(customerNames.ToArray());
            edt_chancus.AutoCompleteCustomSource = acsc;

            LoadProductsLazy();
            pro_call();
        }

        private void ClearFields()
        {
            edt_pay.Text = string.Empty;
            txt_add.Text = string.Empty;
            txt_cut.Text = string.Empty;
            edt_date.Text = DateTime.Now.ToString();
            datesave.Text = DateTime.Now.ToString();
            datasells.Rows.Clear();

            var customer = db.tb_cus.AsNoTracking()
                             .Where(x => x.cus_name == edt_cus.Text)
                             .Select(x => new { x.total_price })
                             .FirstOrDefault();
            if (customer != null)
                txt_manycus.Text = customer.total_price.ToString();

            pro_call();
        }

        // ✅ edt_name محسّن - بيستخدم LoadLastCustomerPrice
        private void edt_name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tb_Stuk = db.tb_stuk.AsNoTracking()
                        .FirstOrDefault(x => x.stuk_name == edt_name.Text);
            if (tb_Stuk == null) return;

            txt_sell.Text = tb_Stuk.stuk_sell.ToString();
            txt_qt.Text = tb_Stuk.stuk_qt.ToString();
            txt_buy.Text = tb_Stuk.stuk_buy.ToString();

            if (tb_Stuk.unit == "كبرى")
            {
                small.Checked = false;
                big.Checked = true;
            }
            else
            {
                small.Checked = true;
                big.Checked = false;
            }

            UpdatePriceByUnit();

            // ✅ استدعاء الدالة المحسّنة بدلاً من الـ loop القديم
            LoadLastCustomerPrice();
        }

        // ✅ تحديث السعر حسب الوحدة
        private void UpdatePriceByUnit()
        {
            if (tb_Stuk == null) return;
            if (big.Checked)
            {
                edt_sell.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();
                edt_buy.Text = (tb_Stuk.stuk_buy * tb_Stuk.stuk_qtfacttotal).ToString();
            }
            else if (small.Checked)
            {
                edt_sell.Text = tb_Stuk.stuk_sell.ToString();
                edt_buy.Text = tb_Stuk.stuk_buy.ToString();
            }
        }

        // ✅ الدالة المحسّنة - query واحدة بدلاً من N+1 queries
        private void LoadLastCustomerPrice()
        {
            try
            {
                if (string.IsNullOrEmpty(edt_cus.Text) ||
                    string.IsNullOrEmpty(edt_name.Text) ||
                    tb_Stuk == null)
                    return;

                // ✅ JOIN واحد بدلاً من loop على كل الفواتير
                var lastOrder = (from sell in db.tb_sell
                                 join order in db.tb_ordersell on sell.id equals order.sell_id
                                 where sell.sell_cus == edt_cus.Text
                                       && order.name_sell == edt_name.Text
                                 orderby sell.id descending
                                 select new
                                 {
                                     order.price_sell,
                                     order.weight
                                 })
                                .AsNoTracking()
                                .FirstOrDefault();

                if (lastOrder == null)
                {
                    txt_behaver.Text = "";
                    return;
                }

                double displayPrice = CalculatePriceByUnit(
                    lastOrder.price_sell ?? 0,
                    lastOrder.weight,
                    big.Checked
                );

                txt_behaver.Text = displayPrice.ToString();
            }
            catch (Exception ex)
            {
                txt_behaver.Text = "";
            }
        }

        // ✅ حساب السعر حسب الوحدة
        private double CalculatePriceByUnit(double basePrice, string sourceUnit, bool isBigUnit)
        {
            if (tb_Stuk == null) return 0;
            double conversionFactor = tb_Stuk.stuk_qtfacttotal ?? 1;
            if (conversionFactor <= 0) conversionFactor = 1;

            if (sourceUnit == "كبرى" && !isBigUnit)
                return basePrice / conversionFactor;
            else if (sourceUnit == "صغرى" && isBigUnit)
                return basePrice * conversionFactor;
            else
                return basePrice;
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
            if (tb_Stuk == null)
            {
                MessageBox.Show("هذا الصنف غير موجود في الأصناف، الرجاء التأكد من الاسم.");
                return;
            }

            qtp = Convert.ToDouble(txt_qt.Text);
            qtn = Convert.ToDouble(edt_qt.Text);
            bool isDuplicate = false;

            if (big.Checked)
                qtn *= Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);

            qtr = qtp - qtn;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == edt_name.Text && qtr >= 0 &&
                    ((row.Cells[2].Value.ToString() == "صغرى" && small.Checked) ||
                     (row.Cells[2].Value.ToString() == "كبرى" && big.Checked)))
                {
                    row.Cells[6].Value = Convert.ToDouble(row.Cells[6].Value) +
                                         (Convert.ToDouble(row.Cells[6].Value) / Convert.ToDouble(row.Cells[3].Value));
                    row.Cells[3].Value = (Convert.ToDouble(row.Cells[3].Value) + Convert.ToDouble(edt_qt.Text)).ToString();
                    row.Cells[4].Value = (Convert.ToDouble(row.Cells[1].Value) * Convert.ToDouble(row.Cells[3].Value)).ToString();
                    row.Cells[5].Value = (Convert.ToDouble(edt_buy.Text) * Convert.ToDouble(row.Cells[3].Value)).ToString();
                    isDuplicate = true;
                    break;
                }
            }

            if (qtr >= 0)
            {
                label2.Visible = false;

                tb_Stuk.stuk_qt = qtr;
                db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var setting = db.AppSettings.AsNoTracking()
                                .Select(s => new { s.max_qt })
                                .FirstOrDefault();
                if (setting != null && qtr < setting.max_qt)
                {
                    string notificationMessage = $"المنتج: {tb_Stuk.stuk_name} كميته أقل من {setting.max_qt} (الكمية الحالية: {tb_Stuk.stuk_qt})";
                    SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }

                if (!isDuplicate)
                {
                    DataRow row = datasells.NewRow();
                    row[0] = edt_name.Text;
                    if (tax.Text == "نقدى")
                    {
                        row[1] = Convert.ToDouble(edt_sell.Text) - Convert.ToDouble(value_cut.Text);
                        row[6] = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(value_cut.Text);
                    }
                    else
                    {
                        row[1] = Convert.ToDouble(edt_sell.Text) - (Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(value_cut.Text) / 100);
                        row[6] = Convert.ToDouble(edt_qt.Text) * (Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(value_cut.Text) / 100);
                    }
                    double totall_buy_val = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(edt_buy.Text);
                    double totall_sell_val = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(row[1]);
                    row[2] = small.Checked ? "صغرى" : big.Checked ? "كبرى" : "";
                    row[3] = edt_qt.Text;
                    row[4] = totall_sell_val.ToString();
                    row[5] = totall_buy_val.ToString();
                    datasells.Rows.Add(row);
                }
                txt_qt.Text = qtr.ToString();
            }
            else
            {
                label2.Visible = true;
            }

            pro_call();
            if (comboBox1.Text == "نقدى")
                edt_pay.Text = txt_totaldata.Text;

            edt_name_SelectedIndexChanged_1(this, EventArgs.Empty);
            edt_code.Clear();
            edt_qt.Value = 1;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (selectrowindex < 0 || selectrowindex >= dataGridView1.Rows.Count)
            {
                MessageBox.Show("يرجى تحديد صف للتعديل.");
                return;
            }

            DataGridViewRow newrow = dataGridView1.Rows[selectrowindex];
            if (newrow.Cells[0].Value == null || string.IsNullOrEmpty(newrow.Cells[0].Value.ToString()))
            {
                MessageBox.Show("لا يمكن تعديل صف فارغ.");
                return;
            }

            tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
            if (tb_Stuk == null)
            {
                MessageBox.Show("هذا الصنف غير موجود في الأصناف، الرجاء التأكد من الاسم.");
                return;
            }

            qtp = Convert.ToDouble(txt_qt.Text);

            if (small.Checked)
            {
                qtn = Convert.ToDouble(edt_qt.Text);
                qtr = qtp - qtn + Convert.ToDouble(qts_qt.Text);

                if (qtr >= 0)
                {
                    newrow.Cells[2].Value = "صغرى";
                    newrow.Cells[0].Value = edt_name.Text;
                    double y;
                    if (tax.Text == "نقدى")
                    {
                        newrow.Cells[1].Value = Convert.ToDouble(edt_sell.Text) - Convert.ToDouble(value_cut.Text);
                        y = (Convert.ToDouble(newrow.Cells[6].Value) / Convert.ToDouble(newrow.Cells[3].Value)) + Convert.ToDouble(value_cut.Text);
                    }
                    else
                    {
                        newrow.Cells[1].Value = Convert.ToDouble(edt_sell.Text) - (Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(value_cut.Text) / 100);
                        y = (Convert.ToDouble(newrow.Cells[6].Value) / Convert.ToDouble(newrow.Cells[3].Value)) + (Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(value_cut.Text) / 100);
                    }
                    newrow.Cells[3].Value = edt_qt.Text;
                    newrow.Cells[6].Value = y * Convert.ToDouble(edt_qt.Text);
                    newrow.Cells[4].Value = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(newrow.Cells[1].Value);
                    newrow.Cells[5].Value = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(edt_buy.Text);

                    tb_Stuk.stuk_qt = qtr;
                    db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    txt_qt.Text = qtr.ToString();

                    var setting = db.AppSettings.AsNoTracking().Select(s => new { s.max_qt }).FirstOrDefault();
                    if (setting != null && qtr < setting.max_qt)
                    {
                        string notificationMessage = $"المنتج: {tb_Stuk.stuk_name} كميته أقل من {setting.max_qt} (الكمية الحالية: {tb_Stuk.stuk_qt})";
                        SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;
                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("لا يمكن تعديل الصنف لأن الكمية غير كافية.");
                    return;
                }
            }
            else if (big.Checked)
            {
                qtn = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);
                qtr = qtp - qtn + Convert.ToDouble(qts_qt.Text);

                if (qtr >= 0)
                {
                    newrow.Cells[2].Value = "كبرى";
                    newrow.Cells[0].Value = edt_name.Text;
                    double y;
                    if (tax.Text == "نقدى")
                    {
                        newrow.Cells[1].Value = Convert.ToDouble(edt_sell.Text) - Convert.ToDouble(value_cut.Text);
                        y = (Convert.ToDouble(newrow.Cells[6].Value) / Convert.ToDouble(newrow.Cells[3].Value)) + Convert.ToDouble(value_cut.Text);
                    }
                    else
                    {
                        newrow.Cells[1].Value = Convert.ToDouble(edt_sell.Text) - (Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(value_cut.Text) / 100);
                        y = (Convert.ToDouble(newrow.Cells[6].Value) / Convert.ToDouble(newrow.Cells[3].Value)) + (Convert.ToDouble(edt_sell.Text) * Convert.ToDouble(value_cut.Text) / 100);
                    }
                    newrow.Cells[3].Value = edt_qt.Text;
                    newrow.Cells[6].Value = y * Convert.ToDouble(edt_qt.Text);
                    newrow.Cells[4].Value = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(newrow.Cells[1].Value);
                    newrow.Cells[5].Value = Convert.ToDouble(edt_qt.Text) * Convert.ToDouble(edt_buy.Text);

                    tb_Stuk.stuk_qt = qtr;
                    db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    txt_qt.Text = qtr.ToString();

                    var setting = db.AppSettings.AsNoTracking().Select(s => new { s.max_qt }).FirstOrDefault();
                    if (setting != null && qtr < setting.max_qt)
                    {
                        string notificationMessage = $"المنتج: {tb_Stuk.stuk_name} كميته أقل من {setting.max_qt} (الكمية الحالية: {tb_Stuk.stuk_qt})";
                        SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;
                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("لا يمكن تعديل الصنف لأن الكمية غير كافية.");
                    return;
                }
            }

            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add.Enabled = true;
            edt_name.Enabled = true;
            value_cut.Value = 0;
            if (comboBox1.Text == "نقدى")
                edt_pay.Text = txt_totaldata.Text;

            edt_name_SelectedIndexChanged_1(this, EventArgs.Empty);
            edt_code.Clear();
            edt_qt.Value = 1;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            qtp = Convert.ToDouble(txt_qt.Text);
            qtn = Convert.ToDouble(edt_qt.Text);
            if (big.Checked)
                qtn *= Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);

            qtr = qtp + qtn;
            txt_qt.Text = qtr.ToString();

            tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
            tb_Stuk.stuk_qt = qtr;
            db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            int rowindex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowindex);
            pro_call();
            btn_edit.Enabled = false;
            btn_delete.Enabled = false;
            btn_add.Enabled = true;
            edt_name.Enabled = true;
            if (comboBox1.Text == "نقدى")
                edt_pay.Text = txt_totaldata.Text;

            edt_name_SelectedIndexChanged_1(this, EventArgs.Empty);
            edt_code.Clear();
            edt_qt.Value = 1;
        }

        private void cell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                selectrowindex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                {
                    edt_name.Text = row.Cells[0].Value.ToString();
                    edt_sell.Text = row.Cells[1].Value.ToString();
                    edt_qt.Text = row.Cells[3].Value.ToString();
                    if (row.Cells[2].Value.ToString() == "صغرى")
                    {
                        small.Checked = true;
                        big.Checked = false;
                        qts_qt.Text = row.Cells[3].Value.ToString();
                    }
                    else if (row.Cells[2].Value.ToString() == "كبرى")
                    {
                        small.Checked = false;
                        big.Checked = true;
                        tb_Stuk = db.tb_stuk.Where(x => x.stuk_name == edt_name.Text).FirstOrDefault();
                        qts_qt.Text = (Convert.ToDouble(row.Cells[3].Value) * Convert.ToDouble(tb_Stuk.stuk_qtfacttotal)).ToString();
                    }
                    edt_name.Enabled = false;
                    btn_edit.Enabled = true;
                    btn_delete.Enabled = true;
                    btn_add.Enabled = false;
                }
                else
                {
                    MessageBox.Show("الصف الذي قمت بالنقر عليه يحتوي على بيانات غير صالحة.");
                }
            }
            value_cut.Value = 0;
        }

        private void edt_cus_SelectedIndexChanged(object sender, EventArgs e) { }

        public DataSet da;
        public List<tb_ordersell> listorder;

        private void btn_print_Click(object sender, EventArgs e)
        {
            list_sell = db.tb_sell.ToList();
            dialog dialog = new dialog();
            if (id == 0)
            {
                if (dataGridView1.Rows.Count - 1 != 0)
                {
                    tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
                    if (tb_cus == null)
                    {
                        MessageBox.Show("لا يوجد بيانات لهذا العميل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tB_sell.sell_cus = edt_cus.Text;
                    tB_sell.cus_id = tb_cus.id;
                    tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
                    tB_sell.pay = Convert.ToDouble(edt_pay.Text);
                    tB_sell.total_price = Convert.ToDouble(txt_total.Text);
                    tB_sell.cut = Convert.ToDouble(txt_cut.Text);
                    tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
                    tB_sell.sell_date = DateTime.Now;
                    tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
                    tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
                    tB_sell.total_earnings = Convert.ToDouble(totall_buy.Text);
                    tB_sell.safe = save.Text;
                    tB_sell.invocie_id = db.tb_sell.Any() ? db.tb_sell.Max(x => x.invocie_id) + 1 : 1;

                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        tB_sell.name_cascher = frm_supp_Add.la_username.Text;

                    db.tb_sell.Add(tB_sell);
                    tb_cus.total_price = tB_sell.stay;
                    db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    if (tb_cus.cus_max <= tb_cus.total_price && tb_cus.cus_max != 0)
                    {
                        string notificationMessage = $"العميل: {tb_cus.cus_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_cus.cus_max})، الرجاء تحصيل مبلغ {tb_cus.total_price} منه.";
                        SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;
                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                    }

                    tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "اضافة";
                        tb_OperationLog.TableName = "عملية بيع ";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + Convert.ToDouble(edt_pay.Text));
                        tb_OperationLog.AmountDifference = Convert.ToDouble(edt_pay.Text);
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();
                        openSession.ClosingAmount = tb_OperationLog.NewValue;
                        db.SaveChanges();
                    }

                    ss();

                    listorder = db.tb_ordersell.Where(x => x.sell_id == tB_sell.id).ToList();
                    da = new DataSet1();
                    da.Tables["tb_order"].Clear();

                    int s = 1;
                    // ✅ جلب بيانات الأصناف دفعة واحدة بدلاً من query لكل صنف
                    var productNames = listorder.Select(o => o.name_sell).Distinct().ToList();
                    var productsDict = db.tb_stuk.AsNoTracking()
                                        .Where(x => productNames.Contains(x.stuk_name))
                                        .ToDictionary(x => x.stuk_name);

                    foreach (var order in listorder)
                    {
                        if (productsDict.TryGetValue(order.name_sell, out var stuk))
                        {
                            string col6 = order.weight == "صغرى" ? stuk.stuk_type : stuk.stuk_supp;
                            da.Tables["tb_order"].Rows.Add(s++, order.name_sell, order.price_sell, order.qt_sell, order.tprice_sell, col6);
                        }
                    }

                    PrintInvoice(tB_sell);
                }
                else
                {
                    dialog.txt_capthion.Text = "لا يمكن حفظ فاتورة بدون بيانات";
                    dialog.Show();
                }
            }
            else
            {
                int invoiceId;
                if (int.TryParse(txt_id.Text, out invoiceId))
                    tB_sell = db.tb_sell.FirstOrDefault(x => x.id == invoiceId);

                tB_sell.sell_cus = edt_cus.Text;
                tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
                tB_sell.cus_id = tb_cus.id;
                tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
                tB_sell.pay = Convert.ToDouble(edt_pay.Text);
                tB_sell.total_price = Convert.ToDouble(txt_total.Text);
                tB_sell.cut = Convert.ToDouble(txt_cut.Text);
                tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
                tB_sell.sell_date = Convert.ToDateTime(edt_date.Text);
                tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
                tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
                tB_sell.total_earnings = Convert.ToDouble(totall_buy.Text);
                tB_sell.safe = save.Text;
                tB_sell.invocie_id = Convert.ToInt32(id_invioce.Text);

                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    tB_sell.name_cascher = frm_supp_Add.la_username.Text;

                db.Entry(tB_sell).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                prives = Convert.ToDouble(tB_sell.stay);
                double difference = prives - curnt;
                tb_cus.total_price += difference;
                db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (tb_cus.cus_max <= tb_cus.total_price && tb_cus.cus_max != 0)
                {
                    string notificationMessage = $"العميل: {tb_cus.cus_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_cus.cus_max})، الرجاء تحصيل مبلغ {tb_cus.total_price} منه.";
                    SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }

                UpdateSafeBalance();

                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession != null)
                {
                    tb_OperationLog.SessionID = openSession.SessionID;
                    tb_OperationLog.OperationType = "تعديل";
                    tb_OperationLog.TableName = "عملية بيع";
                    tb_OperationLog.OldValue = openSession.ClosingAmount;
                    tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + (Convert.ToDouble(edt_pay.Text) - safe));
                    tb_OperationLog.AmountDifference = Convert.ToDouble(edt_pay.Text) - oldamount;
                    db.tb_OperationLog.Add(tb_OperationLog);
                    db.SaveChanges();
                    openSession.ClosingAmount = tb_OperationLog.NewValue;
                    db.SaveChanges();
                }

                ss();

                listorder = db.tb_ordersell.Where(x => x.sell_id == tB_sell.id).ToList();
                da = new DataSet1();
                da.Tables["tb_order"].Clear();

                int s = 1;
                var productNames2 = listorder.Select(o => o.name_sell).Distinct().ToList();
                var productsDict2 = db.tb_stuk.AsNoTracking()
                                    .Where(x => productNames2.Contains(x.stuk_name))
                                    .ToDictionary(x => x.stuk_name);

                foreach (var order in listorder)
                {
                    if (productsDict2.TryGetValue(order.name_sell, out var stuk))
                    {
                        string col6 = order.weight == "صغرى" ? stuk.stuk_type : stuk.stuk_supp;
                        da.Tables["tb_order"].Rows.Add(s++, order.name_sell, order.price_sell, order.qt_sell, order.tprice_sell, col6);
                    }
                }

                PrintInvoice(tB_sell);
            }
        }

        // ✅ دالة مشتركة للطباعة بدلاً من التكرار
        private void PrintInvoice(tb_sell sellData)
        {
            var setting = db.AppSettings.FirstOrDefault(y => y.id == 1);
            using (MemoryStream ms = new MemoryStream(setting.logocomp))
            {
                ReportPrintTool printTool;

                if (print_check.Text == "A5")
                {
                    XtraReport4 report = new XtraReport4();
                    FillReportData(report.aftercut, report.cut, report.tax, report.Remaining,
                        report.customer, report.cutomeraddress, report.customernum, report.casher,
                        report.date, report.Total, report.TotalAll, report.Payment, report.StayCustomer,
                        report.namecompany, report.companyaddress, report.companymob, report.description,
                        report.invo_num, report.logo, sellData, setting, ms);
                    report.DataSource = da;
                    report.DataMember = "tb_order";
                    report.PrinterName = Properties.Settings.Default.a5print;
                    printTool = new ReportPrintTool(report);
                }
                else
                {
                    XtraReport3 report = new XtraReport3();
                    FillReportData(report.aftercut, report.cut, report.tax, report.Remaining,
                        report.customer, report.cutomeraddress, report.customernum, report.casher,
                        report.date, report.Total, report.TotalAll, report.Payment, report.StayCustomer,
                        report.namecompany, report.companyaddress, report.companymob, report.description,
                        report.invo_num, report.logo, sellData, setting, ms);
                    report.DataSource = da;
                    report.DataMember = "tb_order";
                    report.PrinterName = Properties.Settings.Default.invoceprint;
                    printTool = new ReportPrintTool(report);
                }

                saveButtonClicked = true;
                this.Close();

                printTool.AutoShowParametersPanel = false;
                printTool.PrintingSystem.StartPrint += (senderPreview, eventArgsPreview) =>
                {
                    eventArgsPreview.PrintDocument.DefaultPageSettings.Margins =
                        new System.Drawing.Printing.Margins(25, 25, 25, 25);
                };

                if (Properties.Settings.Default.checkinprint == "FAST")
                {
                    printTool.PrintingSystem.ShowMarginsWarning = false;
                    printTool.Print();
                }
                else
                {
                    printTool.PrintingSystem.ShowMarginsWarning = false;
                    printTool.PreviewForm.Shown += (senderPreview, eventArgsPreview) =>
                    {
                        if (print_check.Text != "A5")
                            printTool.PreviewForm.PrintControl.Zoom = 1.5f;
                        printTool.PrintDialog();
                    };
                    printTool.ShowPreview();
                }
            }
        }

        // ✅ تعبئة بيانات التقرير
        private void FillReportData(
            DevExpress.XtraReports.UI.XRLabel aftercut, DevExpress.XtraReports.UI.XRLabel cut,
            DevExpress.XtraReports.UI.XRLabel tax_lbl, DevExpress.XtraReports.UI.XRLabel remaining,
            DevExpress.XtraReports.UI.XRLabel customer_lbl, DevExpress.XtraReports.UI.XRLabel customerAddress,
            DevExpress.XtraReports.UI.XRLabel customerNum, DevExpress.XtraReports.UI.XRLabel casher_lbl,
            DevExpress.XtraReports.UI.XRLabel date_lbl, DevExpress.XtraReports.UI.XRLabel total_lbl,
            DevExpress.XtraReports.UI.XRLabel totalAll, DevExpress.XtraReports.UI.XRLabel payment,
            DevExpress.XtraReports.UI.XRLabel stayCustomer, DevExpress.XtraReports.UI.XRLabel nameCompany,
            DevExpress.XtraReports.UI.XRLabel companyAddress, DevExpress.XtraReports.UI.XRLabel companyMob,
            DevExpress.XtraReports.UI.XRLabel description_lbl, DevExpress.XtraReports.UI.XRLabel invoNum,
            DevExpress.XtraReports.UI.XRPictureBox logo_lbl,
            tb_sell sellData, dynamic setting, MemoryStream ms)
        {
            aftercut.Text = (sellData.cut + totalinvocie).ToString();
            cut.Text = txt_cut.Text;
            tax_lbl.Text = txt_add.Text;
            remaining.Text = (Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text)).ToString();
            customer_lbl.Text = edt_cus.Text;
            customerAddress.Text = tb_cus.cus_email.ToString();
            customerNum.Text = tb_cus.cus_phone.ToString();
            casher_lbl.Text = sellData.name_cascher;
            date_lbl.Text = sellData.sell_date.Value.ToString("yyyy-MM-dd hh:mm tt");
            total_lbl.Text = totalinvocie.ToString();
            totalAll.Text = txt_total.Text;
            payment.Text = edt_pay.Text;
            stayCustomer.Text = txt_manycus.Text;
            nameCompany.Text = setting.namecomp;
            companyAddress.Text = setting.address;
            companyMob.Text = setting.phonenam;
            description_lbl.Text = setting.description;
            invoNum.Text = sellData.invocie_id.ToString();
            logo_lbl.Image = Image.FromStream(ms);
        }

        // ✅ دالة مشتركة لتحديث الخزينة
        private void UpdateSafeBalance()
        {
            if (safename == save.Text)
            {
                tb_Safe = db.tb_safe.Where(x => x.safe_name == safename).FirstOrDefault();
                tb_Safe.safe_count -= safe;
                tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                tb_Safe = db.tb_safe.Where(x => x.safe_name == safename).FirstOrDefault();
                tb_Safe.safe_count -= safe;
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public string GetHtmlFromTextBoxContent(string messageContent)
        {
            string html = "<html><head><style>";
            html += "@import url('https://fonts.googleapis.com/css2?family=Cairo:wght@700&display=swap');";
            html += "body { font-family: 'Cairo', sans-serif; background: linear-gradient(to right, #38ef7d, #38ef7d); padding: 20px; color: #38ef7d; }";
            html += ".email-container { background-color: #34495e; padding: 30px; border-radius: 15px; max-width: 700px; margin: auto; box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3); color: #ffffff; }";
            html += "h2 { color: #f39c12; text-align: center; font-size: 28px; margin-bottom: 20px; font-weight: bold; }";
            html += "h3 { color: #ecf0f1; text-align: center; font-size: 20px; margin-bottom: 20px; font-weight: bold; }";
            html += ".message-box { background-color: #2c3e50; padding: 25px; border-radius: 10px; text-align: center; box-shadow: inset 0 0 15px rgba(0, 0, 0, 0.3); margin: auto; max-width: 600px; font-size: 20px; font-weight: bold; color: #f1c40f; }";
            html += "footer { text-align: center; font-size: 14px; color: #bdc3c7; margin-top: 20px; padding-top: 10px; border-top: 1px solid #7f8c8d; }";
            html += "</style></head><body>";
            html += "<div class='email-container'>";
            html += "<h2>EngineeCode for Software</h2>";
            html += "<h3>تنبيه</h3>";
            html += $"<div class='message-box'><p>{messageContent}</p></div>";
            html += "<footer>Thank you for using our services. We appreciate your support!</footer>";
            html += "</div></body></html>";
            return html;
        }

        public void SendEmailWithHtmlGridData(string messageContent)
        {
            string htmlContent = GetHtmlFromTextBoxContent(messageContent);
            if (!string.IsNullOrEmpty(htmlContent))
                SendEmailWithHtml(htmlContent);
        }

        public void SendEmailWithHtml(string htmlContent)
        {
            // ✅ إصلاح الـ bug القديم: && بدل || (كان بيرجع قائمة فاضية دايماً)
            var userEmails = db.tb_user
                 .Where(u => u.user_roll == "مدير" || u.user_roll == "مدير حسابات")
                 .Select(u => u.user_mail)
                 .ToList();
            try
            {
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("engineecode12@gmail.com", "shjhvhnebtuisfsg"),
                    EnableSsl = true
                };
                foreach (var userEmail in userEmails)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("engineecode12@gmail.com");
                        mail.To.Add(userEmail);
                        mail.Subject = "تنبيهات";
                        mail.Body = htmlContent;
                        mail.IsBodyHtml = true;
                        smtpServer.Send(mail);
                    }
                }
            }
            catch { }
        }

        // ✅ small_CheckedChanged محسّن
        private void small_CheckedChanged(object sender, EventArgs e)
        {
            if (!small.Checked) return;
            if (string.IsNullOrEmpty(edt_name.Text)) return;

            tb_Stuk = db.tb_stuk.AsNoTracking()
                        .FirstOrDefault(x => x.stuk_name == edt_name.Text);
            if (tb_Stuk == null) return;

            if (tb_Stuk.unit == "كبرى")
            {
                small.Checked = false;
                big.Checked = true;
                return;
            }

            edt_buy.Text = tb_Stuk.stuk_buy.ToString();
            edt_sell.Text = tb_Stuk.stuk_sell.ToString();
            big.Checked = false;

            // ✅ استخدام الدالة المحسّنة
            LoadLastCustomerPrice();
        }

        // ✅ big_CheckedChanged محسّن
        private void big_CheckedChanged(object sender, EventArgs e)
        {
            if (!big.Checked) return;
            if (string.IsNullOrEmpty(edt_name.Text)) return;

            tb_Stuk = db.tb_stuk.AsNoTracking()
                        .FirstOrDefault(x => x.stuk_name == edt_name.Text);
            if (tb_Stuk == null) return;

            edt_buy.Text = (tb_Stuk.stuk_buy * tb_Stuk.stuk_qtfacttotal).ToString();
            edt_sell.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();
            small.Checked = false;

            // ✅ استخدام الدالة المحسّنة
            LoadLastCustomerPrice();
        }

        private void edt_sell_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_sell.Text))
            {
                if (string.IsNullOrEmpty(edt_name.Text)) return;
                tb_Stuk = db.tb_stuk.AsNoTracking()
                            .FirstOrDefault(x => x.stuk_name == edt_name.Text);
                if (tb_Stuk == null) return;

                if (big.Checked)
                {
                    edt_sell.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();
                    edt_buy.Text = (tb_Stuk.stuk_buy * tb_Stuk.stuk_qtfacttotal).ToString();
                }
                else if (small.Checked)
                {
                    edt_sell.Text = tb_Stuk.stuk_sell.ToString();
                    edt_buy.Text = tb_Stuk.stuk_buy.ToString();
                }
            }
        }

        private void frm_sell_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            list_sell = db.tb_sell.ToList();
            if (!saveButtonClicked)
            {
                try
                {
                    if (id == 0)
                    {
                        if (dataGridView1.Rows.Count - 1 != 0)
                        {
                            tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
                            if (tb_cus == null)
                            {
                                // إرجاع الكميات
                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                                {
                                    if (dataGridView1.Rows[i].Cells[0].Value == null ||
                                        dataGridView1.Rows[i].Cells[2].Value == null ||
                                        dataGridView1.Rows[i].Cells[3].Value == null) continue;

                                    string stukName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                    tb_Stuk = db.tb_stuk.FirstOrDefault(x => x.stuk_name == stukName);
                                    if (tb_Stuk == null) continue;

                                    double qty = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "كبرى")
                                        qty *= Convert.ToDouble(tb_Stuk.stuk_qtfacttotal);

                                    tb_Stuk.stuk_qt += qty;
                                    try
                                    {
                                        db.Entry(tb_Stuk).State = System.Data.Entity.EntityState.Modified;
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                                }
                                MessageBox.Show("لا يوجد بيانات لهذا العميل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            tB_sell.sell_cus = edt_cus.Text;
                            tB_sell.cus_id = tb_cus.id;
                            tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
                            tB_sell.pay = Convert.ToDouble(edt_pay.Text);
                            tB_sell.total_price = Convert.ToDouble(txt_total.Text);
                            tB_sell.cut = Convert.ToDouble(txt_cut.Text);
                            tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
                            tB_sell.sell_date = DateTime.Now;
                            tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
                            tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
                            tB_sell.total_earnings = Convert.ToDouble(totall_buy.Text);
                            tB_sell.safe = save.Text;
                            tB_sell.invocie_id = db.tb_sell.Any() ? db.tb_sell.Max(x => x.invocie_id) + 1 : 1;

                            main frm_supp_Add = (main)Application.OpenForms["main"];
                            if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                                tB_sell.name_cascher = frm_supp_Add.la_username.Text;

                            db.tb_sell.Add(tB_sell);
                            tb_cus.total_price = tB_sell.stay;
                            db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            if (tb_cus.cus_max <= tb_cus.total_price && tb_cus.cus_max != 0)
                            {
                                string notificationMessage = $"العميل: {tb_cus.cus_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_cus.cus_max})، الرجاء تحصيل مبلغ {tb_cus.total_price} منه.";
                                SendEmailWithHtmlGridData(notificationMessage);
                                notfication.notfication1 = notificationMessage;
                                notfication.CreatedAt = DateTime.Now;
                                db.Notfications.Add(notfication);
                                db.SaveChanges();
                            }

                            tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                            if (tb_Safe != null)
                            {
                                tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                                db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }

                            main user = (main)Application.OpenForms["main"];
                            string casherName = user?.la_username.Text;
                            var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                            if (openSession != null)
                            {
                                tb_OperationLog.SessionID = openSession.SessionID;
                                tb_OperationLog.OperationType = "اضافة";
                                tb_OperationLog.TableName = "عملية بيع ";
                                tb_OperationLog.OldValue = openSession.ClosingAmount;
                                tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + Convert.ToDouble(edt_pay.Text));
                                tb_OperationLog.AmountDifference = Convert.ToDouble(edt_pay.Text);
                                db.tb_OperationLog.Add(tb_OperationLog);
                                db.SaveChanges();
                                openSession.ClosingAmount = tb_OperationLog.NewValue;
                                db.SaveChanges();
                            }
                            ss();
                        }
                    }
                    else
                    {
                        int invoiceId;
                        if (int.TryParse(txt_id.Text, out invoiceId))
                            tB_sell = db.tb_sell.FirstOrDefault(x => x.id == invoiceId);

                        tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
                        tB_sell.sell_cus = edt_cus.Text;
                        tB_sell.cus_id = tb_cus.id;
                        tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
                        tB_sell.pay = Convert.ToDouble(edt_pay.Text);
                        tB_sell.total_price = Convert.ToDouble(txt_total.Text);
                        tB_sell.cut = Convert.ToDouble(txt_cut.Text);
                        tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
                        tB_sell.sell_date = Convert.ToDateTime(edt_date.Text);
                        tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
                        tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
                        tB_sell.total_earnings = Convert.ToDouble(totall_buy.Text);
                        tB_sell.safe = save.Text;
                        tB_sell.invocie_id = Convert.ToInt32(id_invioce.Text);

                        main frm_supp_Add = (main)Application.OpenForms["main"];
                        if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                            tB_sell.name_cascher = frm_supp_Add.la_username.Text;

                        db.Entry(tB_sell).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        if (tb_cus != null)
                        {
                            double difference = Convert.ToDouble(tB_sell.stay) - curnt;
                            tb_cus.total_price += difference;
                            db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            if (tb_cus.cus_max <= tb_cus.total_price && tb_cus.cus_max != 0)
                            {
                                string notificationMessage = $"العميل: {tb_cus.cus_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_cus.cus_max})، الرجاء تحصيل مبلغ {tb_cus.total_price} منه.";
                                SendEmailWithHtmlGridData(notificationMessage);
                                notfication.notfication1 = notificationMessage;
                                notfication.CreatedAt = DateTime.Now;
                                db.Notfications.Add(notfication);
                                db.SaveChanges();
                            }
                        }

                        UpdateSafeBalance();

                        main user = (main)Application.OpenForms["main"];
                        string casherName = user?.la_username.Text;
                        var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                        if (openSession != null)
                        {
                            tb_OperationLog.SessionID = openSession.SessionID;
                            tb_OperationLog.OperationType = "تعديل";
                            tb_OperationLog.TableName = "عملية بيع";
                            tb_OperationLog.OldValue = openSession.ClosingAmount;
                            tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + (Convert.ToDouble(edt_pay.Text) - safe));
                            tb_OperationLog.AmountDifference = Convert.ToDouble(edt_pay.Text) - oldamount;
                            db.tb_OperationLog.Add(tb_OperationLog);
                            db.SaveChanges();
                            openSession.ClosingAmount = tb_OperationLog.NewValue;
                            db.SaveChanges();
                        }
                        ss();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void txt_cut_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_cut.Text))
                txt_cut.Text = "0";
            pro_call();
            if (comboBox1.Text == "نقدى")
                edt_pay.Text = txt_totaldata.Text;
        }

        private void txt_add_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_add.Text))
                txt_add.Text = "0";
            pro_call();
            if (comboBox1.Text == "نقدى")
                edt_pay.Text = txt_totaldata.Text;
        }

        public List<tb_sell> list_sell;

        private void btn_save_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            dialog dialog = new dialog();
            list_sell = db.tb_sell.ToList();

            if (id == 0)
            {
                if (dataGridView1.Rows.Count - 1 != 0)
                {
                    tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
                    if (tb_cus == null)
                    {
                        MessageBox.Show("لا يوجد بيانات لهذا العميل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tB_sell.sell_cus = edt_cus.Text;
                    tB_sell.cus_id = tb_cus.id;
                    tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
                    tB_sell.pay = Convert.ToDouble(edt_pay.Text);
                    tB_sell.total_price = Convert.ToDouble(txt_total.Text);
                    tB_sell.cut = Convert.ToDouble(txt_cut.Text);
                    tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
                    tB_sell.sell_date = DateTime.Now;
                    tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
                    tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
                    tB_sell.total_earnings = Convert.ToDouble(totall_buy.Text);
                    tB_sell.safe = save.Text;
                    tB_sell.invocie_id = db.tb_sell.Any() ? db.tb_sell.Max(x => x.invocie_id) + 1 : 1;

                    main frm_supp_Add = (main)Application.OpenForms["main"];
                    if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                        tB_sell.name_cascher = frm_supp_Add.la_username.Text;

                    db.tb_sell.Add(tB_sell);
                    tb_cus.total_price = tB_sell.stay;
                    db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    if (tb_cus.cus_max <= tb_cus.total_price && tb_cus.cus_max != 0)
                    {
                        string notificationMessage = $"العميل: {tb_cus.cus_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_cus.cus_max})، الرجاء تحصيل مبلغ {tb_cus.total_price} منه.";
                        SendEmailWithHtmlGridData(notificationMessage);
                        notfication.notfication1 = notificationMessage;
                        notfication.CreatedAt = DateTime.Now;
                        db.Notfications.Add(notfication);
                        db.SaveChanges();
                    }

                    tb_Safe = db.tb_safe.Where(x => x.safe_name == save.Text).FirstOrDefault();
                    tb_Safe.safe_count += Convert.ToDouble(edt_pay.Text);
                    db.Entry(tb_Safe).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    main user = (main)Application.OpenForms["main"];
                    string casherName = user?.la_username.Text;
                    var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                    if (openSession != null)
                    {
                        tb_OperationLog.SessionID = openSession.SessionID;
                        tb_OperationLog.OperationType = "اضافة";
                        tb_OperationLog.TableName = "عملية بيع ";
                        tb_OperationLog.OldValue = openSession.ClosingAmount;
                        tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + Convert.ToDouble(edt_pay.Text));
                        tb_OperationLog.AmountDifference = Convert.ToDouble(edt_pay.Text);
                        db.tb_OperationLog.Add(tb_OperationLog);
                        db.SaveChanges();
                        openSession.ClosingAmount = tb_OperationLog.NewValue;
                        db.SaveChanges();
                    }

                    ss();
                    toast.txt_caption.Text = "تم اضافة عملية بيع";
                    toast.Show();
                    saveButtonClicked = true;
                    this.Close();
                }
                else
                {
                    dialog.txt_capthion.Text = "لا يمكن حفظ فاتورة بدون بيانات";
                    dialog.Show();
                }
            }
            else
            {
                int invoiceId;
                if (int.TryParse(txt_id.Text, out invoiceId))
                    tB_sell = db.tb_sell.FirstOrDefault(x => x.id == invoiceId);

                tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
                tB_sell.sell_cus = edt_cus.Text;
                tB_sell.cus_id = tb_cus.id;
                tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
                tB_sell.pay = Convert.ToDouble(edt_pay.Text);
                tB_sell.total_price = Convert.ToDouble(txt_total.Text);
                tB_sell.cut = Convert.ToDouble(txt_cut.Text);
                tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
                tB_sell.sell_date = Convert.ToDateTime(edt_date.Text);
                tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
                tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
                tB_sell.total_earnings = Convert.ToDouble(totall_buy.Text);
                tB_sell.safe = save.Text;
                tB_sell.invocie_id = Convert.ToInt32(id_invioce.Text);

                main frm_supp_Add = (main)Application.OpenForms["main"];
                if (frm_supp_Add != null && !string.IsNullOrEmpty(frm_supp_Add.la_username.Text))
                    tB_sell.name_cascher = frm_supp_Add.la_username.Text;

                db.Entry(tB_sell).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                prives = Convert.ToDouble(tB_sell.stay);
                double difference = prives - curnt;
                tb_cus.total_price += difference;
                db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (tb_cus.cus_max <= tb_cus.total_price && tb_cus.cus_max != 0)
                {
                    string notificationMessage = $"العميل: {tb_cus.cus_name} تجاوز الحد الأقصى المسموح له (الحد الأقصى: {tb_cus.cus_max})، الرجاء تحصيل مبلغ {tb_cus.total_price} منه.";
                    SendEmailWithHtmlGridData(notificationMessage);
                    notfication.notfication1 = notificationMessage;
                    notfication.CreatedAt = DateTime.Now;
                    db.Notfications.Add(notfication);
                    db.SaveChanges();
                }

                UpdateSafeBalance();

                main user = (main)Application.OpenForms["main"];
                string casherName = user?.la_username.Text;
                var openSession = db.Sessions.FirstOrDefault(x => x.namecasher == casherName && x.IsClosed == true);
                if (openSession != null)
                {
                    tb_OperationLog.SessionID = openSession.SessionID;
                    tb_OperationLog.OperationType = "تعديل";
                    tb_OperationLog.TableName = "عملية بيع";
                    tb_OperationLog.OldValue = openSession.ClosingAmount;
                    tb_OperationLog.NewValue = Convert.ToDouble(openSession.ClosingAmount + (Convert.ToDouble(edt_pay.Text) - safe));
                    tb_OperationLog.AmountDifference = Convert.ToDouble(edt_pay.Text) - oldamount;
                    db.tb_OperationLog.Add(tb_OperationLog);
                    db.SaveChanges();
                    openSession.ClosingAmount = tb_OperationLog.NewValue;
                    db.SaveChanges();
                }

                ss();
                toast.txt_caption.Text = "تم تعديل عملية بيع";
                toast.Show();
                saveButtonClicked = true;
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "نقدى")
                edt_pay.Text = txt_totaldata.Text;
        }

        private void big_MouseUp(object sender, MouseEventArgs e)
        {
            if (!big.Checked) big.Checked = true;
        }

        private void small_MouseUp(object sender, MouseEventArgs e)
        {
            if (!small.Checked) small.Checked = true;
        }

        public int CurrentInvoiceIndex { get; set; }
        public List<tb_sell> Invoices { get; set; }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (CurrentInvoiceIndex > 0)
            {
                CurrentInvoiceIndex--;
                DisplayCurrentInvoice();
                UpdateButtonStates();
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (CurrentInvoiceIndex < Invoices.Count - 1)
            {
                CurrentInvoiceIndex++;
                DisplayCurrentInvoice();
                UpdateButtonStates();
            }
        }

        private void DisplayCurrentInvoice()
        {
            if (CurrentInvoiceIndex >= 0 && CurrentInvoiceIndex < Invoices.Count)
            {
                var currentInvoice = Invoices[CurrentInvoiceIndex];
                txt_id.Text = currentInvoice.id.ToString();
                txt_total.Text = currentInvoice.total_price.ToString();
                edt_pay.Text = currentInvoice.pay.ToString();
                txt_totaldata.Text = currentInvoice.total_sell.ToString();
                txt_add.Text = currentInvoice.sell_add.ToString();
                txt_cut.Text = currentInvoice.cut.ToString();
                txt_manycus.Text = currentInvoice.cus_price.ToString();
                save.Text = currentInvoice.safe;
                edt_cus.Text = currentInvoice.sell_cus;
                curnt = Convert.ToDouble(currentInvoice.stay);
                id_invioce.Text = currentInvoice.invocie_id.ToString();
                edt_date.Text = currentInvoice.sell_date.ToString();
                chack.Text = curnt.ToString();
                safe = Convert.ToDouble(currentInvoice.pay);
                safename = currentInvoice.safe;

                listorder = db.tb_ordersell.AsNoTracking()
                              .Where(x => x.sell_id == currentInvoice.id).ToList();
                datasells.Rows.Clear();
                foreach (var item in listorder)
                    datasells.Rows.Add(item.name_sell, item.price_sell, item.weight,
                        item.qt_sell, item.tprice_sell, item.total_earnings, item.cut);
                dataGridView1.DataSource = datasells;
                datesave.Text = currentInvoice.sell_date.ToString();
            }
            pro_call();
        }

        private void UpdateButtonStates()
        {
            if (Invoices == null)
            {
                btn_Previous.Enabled = false;
                btn_Next.Enabled = false;
                return;
            }
            btn_Previous.Enabled = CurrentInvoiceIndex > 0;
            btn_Next.Enabled = CurrentInvoiceIndex < Invoices.Count - 1;
        }

        private void txt_id_Click(object sender, EventArgs e) { }

        private void btn_changecus_Click(object sender, EventArgs e)
        {
            toast toast = new toast();
            int invoiceId;
            if (int.TryParse(txt_id.Text, out invoiceId))
                tB_sell = db.tb_sell.FirstOrDefault(x => x.id == invoiceId);

            if (edt_cus.Text == edt_chancus.Text)
            {
                MessageBox.Show("لا يمكن تحويل الفاتورة إلى نفس العميل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
            if (tb_cus == null)
            {
                MessageBox.Show("لا يوجد بيانات لهذا العميل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tb_cus.total_price -= tB_sell.total_sell;
            tb_cus.total_price += tB_sell.pay;
            db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            edt_cus.Text = edt_chancus.Text;
            tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
            txt_manycus.Text = tb_cus.total_price.ToString();
            tb_cus.total_price += Convert.ToDouble(txt_totaldata.Text);
            tb_cus.total_price -= Convert.ToDouble(edt_pay.Text);
            db.Entry(tb_cus).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            pro_call();

            tb_cus = db.tb_cus.Where(x => x.cus_name == edt_cus.Text).FirstOrDefault();
            tB_sell.sell_cus = edt_cus.Text;
            tB_sell.cus_id = tb_cus.id;
            tB_sell.stay = Convert.ToDouble(txt_total.Text) - Convert.ToDouble(edt_pay.Text);
            tB_sell.pay = Convert.ToDouble(edt_pay.Text);
            tB_sell.total_price = Convert.ToDouble(txt_total.Text);
            tB_sell.cut = Convert.ToDouble(txt_cut.Text);
            tB_sell.sell_add = Convert.ToDouble(txt_add.Text);
            tB_sell.total_sell = Convert.ToDouble(txt_totaldata.Text);
            tB_sell.cus_price = Convert.ToDouble(txt_manycus.Text);
            tB_sell.invocie_id = Convert.ToInt32(id_invioce.Text);
            db.Entry(tB_sell).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            curnt = Convert.ToDouble(tB_sell.stay);
        }

        // ✅ edt_code_TextChanged محسّن
        private void edt_code_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edt_code.Text)) return;

            tb_Stuk = db.tb_stuk.AsNoTracking()
                        .FirstOrDefault(x => x.code == edt_code.Text);
            if (tb_Stuk == null) return;

            txt_qt.Text = tb_Stuk.stuk_qt.ToString();
            txt_buy.Text = tb_Stuk.stuk_buy.ToString();
            txt_sell.Text = tb_Stuk.stuk_sell.ToString();
            edt_name.Text = tb_Stuk.stuk_name;

            if (tb_Stuk.unit == "كبرى")
            {
                if (small.Checked) { small.Checked = false; big.Checked = true; }
            }
            else
            {
                if (big.Checked) { small.Checked = true; big.Checked = false; }
            }

            if (big.Checked)
            {
                edt_sell.Text = (tb_Stuk.stuk_sell * tb_Stuk.stuk_qtfacttotal).ToString();
                edt_buy.Text = (tb_Stuk.stuk_buy * tb_Stuk.stuk_qtfacttotal).ToString();
            }
            else
            {
                edt_sell.Text = tb_Stuk.stuk_sell.ToString();
                edt_buy.Text = tb_Stuk.stuk_buy.ToString();
            }

            // ✅ استخدام الدالة المحسّنة بدلاً من الـ loop
            LoadLastCustomerPrice();

            if (FAST.Text == "FAST")
                btn_add_Click_1(this, EventArgs.Empty);

            edt_code.Clear();
        }

        private void txt_behaver_Click(object sender, EventArgs e) { }

        private void frm_sell_add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                btn_print.PerformClick();
            else if (e.KeyCode == Keys.F1)
                btn_save.PerformClick();
        }

        private void txt_total_TextChanged(object sender, EventArgs e) { pro_call(); }

        private void add_cus_Click(object sender, EventArgs e)
        {
            pl.frm_cus_add frm_supp_Add = new frm_cus_add();
            frm_supp_Add.id = 0;
            frm_supp_Add.btn_add.Text = "اضافة";
            frm_supp_Add.Show();
        }

        private void edt_cus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedText = edt_cus.Text;
            var selectedCustomer = db.tb_cus.AsNoTracking()
                                    .FirstOrDefault(x => x.cus_name == selectedText || x.cus_phone == selectedText);
            if (selectedCustomer != null)
            {
                edt_cus.Text = selectedCustomer.cus_name;
                txt_manycus.Text = selectedCustomer.total_price.ToString();
                pro_call();
            }
        }

        private void edt_cus_Leave(object sender, EventArgs e)
        {
            string selectedText = edt_cus.Text;
            var selectedCustomer = db.tb_cus.AsNoTracking()
                                    .FirstOrDefault(x => x.cus_name == selectedText || x.cus_phone == selectedText);
            if (selectedCustomer != null)
            {
                edt_cus.Text = selectedCustomer.cus_name;
                txt_manycus.Text = selectedCustomer.total_price.ToString();
                pro_call();
            }
        }

        private void tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            tax_txt.Text = tax.Text == "نقدى" ? "$" : "%";
        }

        private void edt_offer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edt_offer.SelectedItem != null && edt_offer.SelectedItem.ToString() == "بدون عرض")
            {
                value_cut.Value = 0;
                tax.Text = "نقدى";
                tax_txt.Text = "$";
                value_cut.Enabled = true;
                tax.Enabled = true;
            }
            else
            {
                var offer = db.tb_offer.AsNoTracking()
                              .FirstOrDefault(x => x.name_offer == edt_offer.Text);
                if (offer != null)
                {
                    value_cut.Value = (decimal)offer.quontity;
                    tax.Text = offer.type_offer;
                }
                value_cut.Enabled = false;
                tax.Enabled = false;
            }
        }

        private void edt_pay_TextChanged(object sender, EventArgs e)
        {
            pro_call();
            if (string.IsNullOrWhiteSpace(edt_pay.Text))
                edt_pay.Text = "0";
        }

        public void ss()
        {
            if (id == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var tb_Ordersell = new tb_ordersell
                    {
                        sell_id = tB_sell.id,
                        name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        weight = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value),
                        tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value),
                        total_earnings = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value),
                        cut = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value)
                    };
                    try
                    {
                        db.tb_ordersell.Add(tb_Ordersell);
                        db.SaveChanges();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
            else
            {
                int invoiceId;
                if (int.TryParse(txt_id.Text, out invoiceId))
                {
                    var ordersToRemove = db.tb_ordersell.Where(x => x.sell_id == invoiceId).ToList();
                    if (ordersToRemove.Any())
                    {
                        db.tb_ordersell.RemoveRange(ordersToRemove);
                        db.SaveChanges();
                    }
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var tb_Ordersell = new tb_ordersell
                    {
                        sell_id = tB_sell.id,
                        name_sell = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        price_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value),
                        weight = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        qt_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value),
                        tprice_sell = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value),
                        total_earnings = Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value),
                        cut = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value)
                    };
                    try
                    {
                        db.tb_ordersell.Add(tb_Ordersell);
                        db.SaveChanges();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        private void pro_call()
        {
            double totallbuy = 0;
            double sum = 0;
            double totalcut = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[4].Value != null &&
                    dataGridView1.Rows[i].Cells[5].Value != null)
                {
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                    totallbuy += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                    totalcut += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                }
            }
            tot_buy.Text = totallbuy.ToString();
            totall_buy.Text = (sum - totallbuy).ToString();
            txt_totaldata.Text = (sum + Convert.ToDouble(txt_add.Text)).ToString();
            txt_cut.Text = totalcut.ToString();
            double sumall = Convert.ToDouble(txt_totaldata.Text) + Convert.ToDouble(txt_manycus.Text);
            txt_total.Text = sumall.ToString();
            totalinvocie = sum;
        }
    }
}