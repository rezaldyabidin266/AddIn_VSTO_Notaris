using Microsoft.Office.Tools.Ribbon;

namespace NotarisWordAddIn2019
{
    partial class rbnNotaris : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public rbnNotaris()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rbnNotaris));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpFormat = this.Factory.CreateRibbonGroup();
            this.btnRapihkan = this.Factory.CreateRibbonButton();
            this.btnClear = this.Factory.CreateRibbonButton();
            this.grpSetting = this.Factory.CreateRibbonGroup();
            this.btnAkta = this.Factory.CreateRibbonButton();
            this.btnPrinterDialogs = this.Factory.CreateRibbonButton();
            this.btnSettingStempel = this.Factory.CreateRibbonButton();
            this.grpInsert = this.Factory.CreateRibbonGroup();
            this.btnNominal = this.Factory.CreateRibbonButton();
            this.btnTanggal = this.Factory.CreateRibbonButton();
            this.btnWaktu = this.Factory.CreateRibbonButton();
            this.grpSalinan = this.Factory.CreateRibbonGroup();
            this.btnSalinan = this.Factory.CreateRibbonButton();
            this.grpUmum = this.Factory.CreateRibbonGroup();
            this.btnHelp = this.Factory.CreateRibbonButton();
            this.btnGaris1baris = this.Factory.CreateRibbonButton();
            this.grpTestmodul = this.Factory.CreateRibbonGroup();
            this.btnUpline = this.Factory.CreateRibbonButton();
            this.btnVertikalline = this.Factory.CreateRibbonButton();
            this.btnDownline = this.Factory.CreateRibbonButton();
            this.btnHorisontalline = this.Factory.CreateRibbonButton();
            this.btnTopoint = this.Factory.CreateRibbonButton();
            this.btnSettingfontall = this.Factory.CreateRibbonButton();
            this.btnTextSesuaiCursor = this.Factory.CreateRibbonButton();
            this.btnGetTextSelect = this.Factory.CreateRibbonButton();
            this.btnGarisAtasTegaskBawah = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnPrintTest = this.Factory.CreateRibbonButton();
            this.btnPrintDialogs = this.Factory.CreateRibbonButton();
            this.btnPrinter = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.grpSetting.SuspendLayout();
            this.grpInsert.SuspendLayout();
            this.grpSalinan.SuspendLayout();
            this.grpUmum.SuspendLayout();
            this.grpTestmodul.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpFormat);
            this.tab1.Groups.Add(this.grpSetting);
            this.tab1.Groups.Add(this.grpInsert);
            this.tab1.Groups.Add(this.grpSalinan);
            this.tab1.Groups.Add(this.grpUmum);
            this.tab1.Groups.Add(this.grpTestmodul);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Notaris AddIn";
            this.tab1.Name = "tab1";
            // 
            // grpFormat
            // 
            this.grpFormat.Items.Add(this.btnRapihkan);
            this.grpFormat.Items.Add(this.btnClear);
            this.grpFormat.Label = "FORMAT";
            this.grpFormat.Name = "grpFormat";
            // 
            // btnRapihkan
            // 
            this.btnRapihkan.Image = ((System.Drawing.Image)(resources.GetObject("btnRapihkan.Image")));
            this.btnRapihkan.Label = "RAPIHKAN";
            this.btnRapihkan.Name = "btnRapihkan";
            this.btnRapihkan.ShowImage = true;
            this.btnRapihkan.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRapihkan_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Label = "CLEAR";
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowImage = true;
            // 
            // grpSetting
            // 
            this.grpSetting.Items.Add(this.btnAkta);
            this.grpSetting.Items.Add(this.btnPrinterDialogs);
            this.grpSetting.Items.Add(this.btnSettingStempel);
            this.grpSetting.Label = "SETTING";
            this.grpSetting.Name = "grpSetting";
            // 
            // btnAkta
            // 
            this.btnAkta.Image = ((System.Drawing.Image)(resources.GetObject("btnAkta.Image")));
            this.btnAkta.Label = "AKTA";
            this.btnAkta.Name = "btnAkta";
            this.btnAkta.ShowImage = true;
            this.btnAkta.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAkta_Click);
            // 
            // btnPrinterDialogs
            // 
            this.btnPrinterDialogs.Image = ((System.Drawing.Image)(resources.GetObject("btnPrinterDialogs.Image")));
            this.btnPrinterDialogs.Label = "PRINTER";
            this.btnPrinterDialogs.Name = "btnPrinterDialogs";
            this.btnPrinterDialogs.ShowImage = true;
            this.btnPrinterDialogs.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrinterDialogs_Click);
            // 
            // btnSettingStempel
            // 
            this.btnSettingStempel.Image = ((System.Drawing.Image)(resources.GetObject("btnSettingStempel.Image")));
            this.btnSettingStempel.Label = "STEMPEL";
            this.btnSettingStempel.Name = "btnSettingStempel";
            this.btnSettingStempel.ShowImage = true;
            this.btnSettingStempel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettingStempel_Click);
            // 
            // grpInsert
            // 
            this.grpInsert.Items.Add(this.btnNominal);
            this.grpInsert.Items.Add(this.btnTanggal);
            this.grpInsert.Items.Add(this.btnWaktu);
            this.grpInsert.Label = "INSERT";
            this.grpInsert.Name = "grpInsert";
            // 
            // btnNominal
            // 
            this.btnNominal.Image = ((System.Drawing.Image)(resources.GetObject("btnNominal.Image")));
            this.btnNominal.Label = "NOMINAL";
            this.btnNominal.Name = "btnNominal";
            this.btnNominal.ShowImage = true;
            this.btnNominal.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnNominal_Click);
            // 
            // btnTanggal
            // 
            this.btnTanggal.Image = ((System.Drawing.Image)(resources.GetObject("btnTanggal.Image")));
            this.btnTanggal.Label = "TANGGAL";
            this.btnTanggal.Name = "btnTanggal";
            this.btnTanggal.ShowImage = true;
            this.btnTanggal.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTanggal_Click);
            // 
            // btnWaktu
            // 
            this.btnWaktu.Image = ((System.Drawing.Image)(resources.GetObject("btnWaktu.Image")));
            this.btnWaktu.Label = "WAKTU";
            this.btnWaktu.Name = "btnWaktu";
            this.btnWaktu.ShowImage = true;
            this.btnWaktu.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnWaktu_Click);
            // 
            // grpSalinan
            // 
            this.grpSalinan.Items.Add(this.btnSalinan);
            this.grpSalinan.Label = "SALINAN";
            this.grpSalinan.Name = "grpSalinan";
            // 
            // btnSalinan
            // 
            this.btnSalinan.Image = ((System.Drawing.Image)(resources.GetObject("btnSalinan.Image")));
            this.btnSalinan.Label = "SALINAN";
            this.btnSalinan.Name = "btnSalinan";
            this.btnSalinan.ShowImage = true;
            this.btnSalinan.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSalinan_Click);
            // 
            // grpUmum
            // 
            this.grpUmum.Items.Add(this.btnHelp);
            this.grpUmum.Items.Add(this.btnGaris1baris);
            this.grpUmum.Label = "UMUM";
            this.grpUmum.Name = "grpUmum";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Label = "HELP";
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ShowImage = true;
            this.btnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHelp_Click);
            // 
            // btnGaris1baris
            // 
            this.btnGaris1baris.Image = ((System.Drawing.Image)(resources.GetObject("btnGaris1baris.Image")));
            this.btnGaris1baris.Label = "GARIS 1 BARIS";
            this.btnGaris1baris.Name = "btnGaris1baris";
            this.btnGaris1baris.ShowImage = true;
            this.btnGaris1baris.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGaris1baris_Click);
            // 
            // grpTestmodul
            // 
            this.grpTestmodul.Items.Add(this.btnUpline);
            this.grpTestmodul.Items.Add(this.btnVertikalline);
            this.grpTestmodul.Items.Add(this.btnDownline);
            this.grpTestmodul.Items.Add(this.btnHorisontalline);
            this.grpTestmodul.Items.Add(this.btnTopoint);
            this.grpTestmodul.Items.Add(this.btnSettingfontall);
            this.grpTestmodul.Items.Add(this.btnTextSesuaiCursor);
            this.grpTestmodul.Items.Add(this.btnGetTextSelect);
            this.grpTestmodul.Items.Add(this.btnGarisAtasTegaskBawah);
            this.grpTestmodul.Label = "TEST MODUL";
            this.grpTestmodul.Name = "grpTestmodul";
            // 
            // btnUpline
            // 
            this.btnUpline.Label = "Up Line";
            this.btnUpline.Name = "btnUpline";
            this.btnUpline.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUpline_Click);
            // 
            // btnVertikalline
            // 
            this.btnVertikalline.Label = "Vertikal Line";
            this.btnVertikalline.Name = "btnVertikalline";
            this.btnVertikalline.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnVertikalline_Click);
            // 
            // btnDownline
            // 
            this.btnDownline.Label = "Down Line";
            this.btnDownline.Name = "btnDownline";
            this.btnDownline.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDownline_Click);
            // 
            // btnHorisontalline
            // 
            this.btnHorisontalline.Label = "Horisontal Line";
            this.btnHorisontalline.Name = "btnHorisontalline";
            this.btnHorisontalline.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHorisontalline_Click);
            // 
            // btnTopoint
            // 
            this.btnTopoint.Label = "To Point";
            this.btnTopoint.Name = "btnTopoint";
            // 
            // btnSettingfontall
            // 
            this.btnSettingfontall.Label = "Setting Font All";
            this.btnSettingfontall.Name = "btnSettingfontall";
            this.btnSettingfontall.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettingfontall_Click);
            // 
            // btnTextSesuaiCursor
            // 
            this.btnTextSesuaiCursor.Label = "Add Text Sesuai Cursor";
            this.btnTextSesuaiCursor.Name = "btnTextSesuaiCursor";
            this.btnTextSesuaiCursor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTextSesuaiCursor_Click);
            // 
            // btnGetTextSelect
            // 
            this.btnGetTextSelect.Label = "Get Text Sesuai Select";
            this.btnGetTextSelect.Name = "btnGetTextSelect";
            this.btnGetTextSelect.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGetTextSelect_Click_1);
            // 
            // btnGarisAtasTegaskBawah
            // 
            this.btnGarisAtasTegaskBawah.Label = "Garis Atas Bawah Tegak";
            this.btnGarisAtasTegaskBawah.Name = "btnGarisAtasTegaskBawah";
            this.btnGarisAtasTegaskBawah.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGarisAtasTegaskBawah_Click_1);
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnPrintTest);
            this.group1.Items.Add(this.btnPrintDialogs);
            this.group1.Items.Add(this.btnPrinter);
            this.group1.Label = "TEST MODUL";
            this.group1.Name = "group1";
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Label = "Print Doc";
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrintTest_Click_1);
            // 
            // btnPrintDialogs
            // 
            this.btnPrintDialogs.Label = "Print Doc Dialogs";
            this.btnPrintDialogs.Name = "btnPrintDialogs";
            this.btnPrintDialogs.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrintDialogs_Click_1);
            // 
            // btnPrinter
            // 
            this.btnPrinter.Image = ((System.Drawing.Image)(resources.GetObject("btnPrinter.Image")));
            this.btnPrinter.Label = "PRINTER Lama";
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.ShowImage = true;
            this.btnPrinter.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrinter_Click_1);
            // 
            // rbnNotaris
            // 
            this.Name = "rbnNotaris";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.grpSetting.ResumeLayout(false);
            this.grpSetting.PerformLayout();
            this.grpInsert.ResumeLayout(false);
            this.grpInsert.PerformLayout();
            this.grpSalinan.ResumeLayout(false);
            this.grpSalinan.PerformLayout();
            this.grpUmum.ResumeLayout(false);
            this.grpUmum.PerformLayout();
            this.grpTestmodul.ResumeLayout(false);
            this.grpTestmodul.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpFormat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRapihkan;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnClear;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSetting;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAkta;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpInsert;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnNominal;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTanggal;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnWaktu;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSalinan;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSalinan;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpUmum;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnGaris1baris;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTestmodul;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpline;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnVertikalline;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDownline;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHorisontalline;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTopoint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettingfontall;
        internal RibbonButton btnTextSesuaiCursor;
        internal RibbonButton btnGetTextSelect;
        internal RibbonButton btnGarisAtasTegaskBawah;
        internal RibbonButton btnPrinterDialogs;
        internal RibbonButton btnPrinter;
        internal RibbonGroup group1;
        internal RibbonButton btnPrintTest;
        internal RibbonButton btnPrintDialogs;
        internal RibbonButton btnSettingStempel;
    }
    partial class ThisRibbonCollection
    {
        internal rbnNotaris rbnNotaris
        {
            get { return this.GetRibbon<rbnNotaris>(); }
        }
    }
}
