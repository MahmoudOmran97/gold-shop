using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using DevExpress.Utils.Extensions;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Management;
using DevExpress.Utils.About;
using System.Drawing.Printing;

namespace el_shabander.pl
{
    public partial class frm_settingpro : Form
    {

        // private DB_storeEntities db;
        DB_storeEntities db = new DB_storeEntities();
        bl.methods methods = new bl.methods();
        public frm_settingpro()
        {
            InitializeComponent();
            //check_serile.Text = (Properties.Settings.Default.serail += 50).ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {

            savesetting();
            MessageBox.Show("تم الحفظ بنجاح", "تاكيد");
            


            string encryptedSerial = Encrypt(edt_serildevice.Text, "omran");

            // التحقق من مطابقة القيمة المشفرة مع الترخيص المدخل
            if (encryptedSerial == edt_serilnam.Text)
            {
                // عرض رسالة تفعيل البرنامج بنجاح
                MessageBox.Show("تم تفعيل البرنامج بنجاح.");

                // تحديث حالة الترخيص في الواجهة الرئيسية
                main frm = new main();
                frm.la_trile.Text = "مفعل";
                pn_prog.Visible = true;
                // حفظ القيم في الإعدادات
                Properties.Settings.Default.license = edt_serilnam.Text;
                Properties.Settings.Default.EmailInterval = (int)edt_time.Value;
                Properties.Settings.Default.invoceprint = txt_invoce.Text;
                Properties.Settings.Default.barcodeprint = txt_barcode.Text;
                Properties.Settings.Default.a5print = txt_a5.Text;
                Properties.Settings.Default.checkinprint = fast_print.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
               
                // عرض رسالة بأن الترخيص غير صحيح
                MessageBox.Show("الترخيص غير صحيح.");
            }
            pn_prog.Visible = false;
            this.Close();
        }
        private string Encrypt(string input, string key)
        {
            // تحويل النص إلى مصفوفة بايت
            byte[] data = Encoding.UTF8.GetBytes(input);

            // تحويل المفتاح إلى مصفوفة بايت
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            // التشفير باستخدام مفتاح السري
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= keyBytes[i % keyBytes.Length];
            }

            // تحويل المصفوفة المشفرة إلى سلسلة نصية
            return Convert.ToBase64String(data);
        }

        private void frm_setting_Load(object sender, EventArgs e)
        {
           
            setsetting();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                txt_invoce.Items.Add(printer);
            }


            txt_barcode.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                txt_barcode.Items.Add(printer);
            }
            txt_a5.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                txt_a5.Items.Add(printer);
            }


            txt_invoce.SelectedItem = !string.IsNullOrEmpty(Properties.Settings.Default.invoceprint)
    ? Properties.Settings.Default.invoceprint
    : (txt_invoce.Items.Count > 0 ? txt_invoce.Items[0] : null);

            txt_barcode.SelectedItem = !string.IsNullOrEmpty(Properties.Settings.Default.barcodeprint)
                ? Properties.Settings.Default.barcodeprint
                : (txt_barcode.Items.Count > 0 ? txt_barcode.Items[0] : null);

            txt_a5.SelectedItem = !string.IsNullOrEmpty(Properties.Settings.Default.a5print)
                ? Properties.Settings.Default.a5print
                : (txt_a5.Items.Count > 0 ? txt_a5.Items[0] : null);
            fast_print.SelectedItem = !string.IsNullOrEmpty(Properties.Settings.Default.checkinprint)
     ? Properties.Settings.Default.checkinprint
     : "FAST";




            edt_serildevice.Text = Properties.Settings.Default.serail;
            edt_serilnam.Text = Properties.Settings.Default.license;
            edt_time.Value = Properties.Settings.Default.EmailInterval;
            if (Properties.Settings.Default.darkmode == true)
            {
                dark.IsOn = true;
            }
            else
            {
                dark.IsOn = false;
            }
        }
        private void setsetting()
        {
            
                var setting = db.AppSettings.FirstOrDefault(s => s.id == 1); // افتراضاً أن لديك CID فريد يمثل السجل

                if (setting != null)
                {
                    edt_name.Text = setting.namecomp; // اسم الشركة
                    edt_addres.Text = setting.address; // عنوان الشركة
                    edt_phone.Text = setting.phonenam; // رقم الهاتف
                    txt_print.Text = setting.printty;
                    edt_max_qt.Text = setting.max_qt.ToString();
                edt_des.Text = setting.description;
                txt_printcode.Text = setting.printcod;
                    try
                    {
                        // تحويل الشعار من بايت إلى صورة وعرضها
                        if (setting.logocomp != null)
                        {
                            using (MemoryStream ms = new MemoryStream(setting.logocomp))
                            {
                                edt_logo.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error loading logo image.");
                    }
                }
                else
                {
                    MessageBox.Show("Settings not found in the database.");
                }
           
        }

        private void savesetting()
        {
           
                var setting = db.AppSettings.FirstOrDefault(s => s.id == 1); // افتراض أن CID هو المفتاح الفريد
               
                if (setting != null)
                {
                    // حفظ البيانات المدخلة في الواجهة
                    setting.namecomp = edt_name.Text;
                    setting.address = edt_addres.Text;
                    setting.phonenam = edt_phone.Text;
                    setting.printty = txt_print.Text;
                    setting.max_qt =Convert.ToInt32( edt_max_qt.Text);
                setting.description = edt_des.Text;
                setting.printcod = txt_printcode.Text;
                    try
                    {
                        // تحويل صورة الشعار إلى بايت قبل الحفظ
                        using (MemoryStream ms = new MemoryStream())
                        {
                            edt_logo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            setting.logocomp = ms.ToArray();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error saving logo image.");
                    }
                    db.Entry(setting).State = System.Data.Entity.EntityState.Modified;
                   db.SaveChanges(); // حفظ التغييرات في قاعدة البيانات
                    MessageBox.Show("Settings saved successfully.");
                }
                else
                {
                    MessageBox.Show("Settings not found in the database.");
                }
           
        }

        private async void btn_backup_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                var rs = folder.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    pn_prog.Visible = true;
                    var result = await Task.Run(() => BackUp(folder));
                    pn_prog.Visible = false;
                    if (result)
                    {
                        MessageBox.Show("تم النسخ بنجاح");
                    }
                    else
                    {
                        MessageBox.Show("هناك مشكلة في عملية النسخ. حاول تغيير المسار وتجنب اختيار برتشن النسخة.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"هناك مشكلة في عملية النسخ: {ex.Message}");
                pn_prog.Visible = false;
            }
        }

        private bool BackUp(FolderBrowserDialog folder)
        {
            try
            {
                using (var db = new DB_storeEntities())
                {
                    string dbname = db.Database.Connection.Database;
                    string dbbackup = "DMMback" + DateTime.Now.ToString("yyyyMMddHHmm");
                    var fullpath = Path.Combine(folder.SelectedPath, dbbackup + ".bak");

                    // يمكنك اختيار أحد الخيارين بناءً على حاجتك:
                    // استخدم FORMAT إذا كنت تريد تهيئة النسخة الاحتياطية الجديدة (كتابة فوق النسخة القديمة)
                    // استخدم NOINIT إذا كنت تريد إلحاق النسخة الجديدة بالنسخ الاحتياطية السابقة

                    // في هذا المثال، سأستخدم FORMAT
                    string sqlcommand = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}' WITH FORMAT, NAME = N'DB_store', SKIP, NOREWIND, STATS = 10", dbname, fullpath);

                    db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, sqlcommand);
                }

                return true;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"خطأ أثناء عملية النسخ الاحتياطي للقاعدة: {sqlEx.Message}\n{sqlEx.StackTrace}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء عملية النسخ الاحتياطي: {ex.Message}");
                return false;
            }
        }

        private async void btn_restor_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Backup Files (*.bak)|*.bak",
                    Title = "Select Database Backup File"
                };
                var rs = fileDialog.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    pn_prog.Visible = true;
                    var result = await Task.Run(() => Restore(fileDialog.FileName));
                    pn_prog.Visible = false;

                    if (result)
                    {
                        MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح");
                    }
                    else
                    {
                        MessageBox.Show("هناك مشكلة في عملية الاستعادة. حاول مرة أخرى.");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"هناك مشكلة في عملية الاستعادة: {ex.Message}");
                pn_prog.Visible = false;
            }

           
        }
        private bool Restore(string backupFilePath)
        {
            try
            {
                using (var db = new DB_storeEntities())
                {
                    string dbname = db.Database.Connection.Database;

                    // إعداد الأمر لإعادة قاعدة البيانات باستخدام النسخة الاحتياطية
                    string sqlcommand = string.Format(
                        @"USE master;
                    ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH REPLACE;
                    ALTER DATABASE [{0}] SET MULTI_USER;",
                        dbname, backupFilePath);

                    db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlcommand);
                }

                return true;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"خطأ أثناء عملية استعادة النسخة الاحتياطية للقاعدة: {sqlEx.Message}\n{sqlEx.StackTrace}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء عملية استعادة النسخة الاحتياطية: {ex.Message}\n{ex.StackTrace}");
                return false;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",  // أنواع الصور المدعومة
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)  // مجلد الصور الافتراضي
            };

            // إظهار نافذة اختيار الملفات والتحقق إذا كان المستخدم قد اختار صورة
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // تحميل الصورة المختارة في PictureEdit
                edt_logo.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            pl.frm_cus frm_Pass1 = new frm_cus();
            frm_Pass1.SendEmailWithHtmlGridData();
            pl.frm_supp frm_Pass = new frm_supp();
            frm_Pass.SendEmailWithHtmlGridData();
            pl.frm_sell frm_Pass2 = new frm_sell();
            frm_Pass2.SendEmailWithHtmlGridData();
            pl.frm_pur frm_Pass3 = new frm_pur();
            frm_Pass3.SendEmailWithHtmlGridData();
        }

        private void dark_Toggled(object sender, EventArgs e)
        {
            if (dark.IsOn)
            {
                Properties.Settings.Default.darkmode = true;
                Properties.Settings.Default.Save();
                main frm_supp_Add = (main)Application.OpenForms["main"];
                frm_supp_Add.pn_headernavbar.BackColor = Color.Black;
                frm_supp_Add.pn_topbar.BackColor = Color.Black;
                frm_supp_Add.flowLayoutPanel1.BackColor = Color.Black;
            }
            else
            {
                main frm_supp_Add = (main)Application.OpenForms["main"];
                frm_supp_Add.pn_headernavbar.BackColor = Color.FromArgb(64, 64, 64);
                frm_supp_Add.pn_topbar.BackColor = Color.FromArgb(64, 64, 64);
                frm_supp_Add.flowLayoutPanel1.BackColor = Color.FromArgb(64, 64, 64);
                Properties.Settings.Default.darkmode = false;
                Properties.Settings.Default.Save();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }

}
