namespace NotarisWordAddIn2019
{
    partial class frmSettingPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingPrinter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTypePrinter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbListPrinter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCetakSisiBawah = new DevExpress.XtraEditors.CheckEdit();
            this.chkCetakSisiAtas = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLebarKertas = new DevExpress.XtraEditors.TextEdit();
            this.txtPanjangKertas = new DevExpress.XtraEditors.TextEdit();
            this.cmbUkuranKertas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtJmlKertas = new DevExpress.XtraEditors.TextEdit();
            this.txtJmlHalaman = new DevExpress.XtraEditors.TextEdit();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtManual = new DevExpress.XtraEditors.TextEdit();
            this.txtPage2 = new DevExpress.XtraEditors.TextEdit();
            this.txtPage1 = new DevExpress.XtraEditors.TextEdit();
            this.cmbPrintOpsi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveSetting = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTypePrinter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbListPrinter.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCetakSisiBawah.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCetakSisiAtas.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLebarKertas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPanjangKertas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUkuranKertas.Properties)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlKertas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlHalaman.Properties)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtManual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPage2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPage1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrintOpsi.Properties)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTypePrinter);
            this.groupBox1.Controls.Add(this.cmbListPrinter);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Printer";
            // 
            // cmbTypePrinter
            // 
            this.cmbTypePrinter.Location = new System.Drawing.Point(7, 44);
            this.cmbTypePrinter.Name = "cmbTypePrinter";
            this.cmbTypePrinter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypePrinter.Properties.Appearance.Options.UseFont = true;
            this.cmbTypePrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTypePrinter.Properties.Items.AddRange(new object[] {
            "Dot Matrix/Duplex",
            "LaserJet/Deskjet (Depan)",
            "LaserJet/Deskjet (Belakang)"});
            this.cmbTypePrinter.Size = new System.Drawing.Size(180, 20);
            this.cmbTypePrinter.TabIndex = 1;
            // 
            // cmbListPrinter
            // 
            this.cmbListPrinter.Location = new System.Drawing.Point(7, 21);
            this.cmbListPrinter.Name = "cmbListPrinter";
            this.cmbListPrinter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListPrinter.Properties.Appearance.Options.UseFont = true;
            this.cmbListPrinter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbListPrinter.Size = new System.Drawing.Size(180, 20);
            this.cmbListPrinter.TabIndex = 0;
            this.cmbListPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbListPrinter_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkCetakSisiBawah);
            this.groupBox2.Controls.Add(this.chkCetakSisiAtas);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(209, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Section (Laser / Deskjet)";
            // 
            // chkCetakSisiBawah
            // 
            this.chkCetakSisiBawah.Location = new System.Drawing.Point(6, 46);
            this.chkCetakSisiBawah.Name = "chkCetakSisiBawah";
            this.chkCetakSisiBawah.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chkCetakSisiBawah.Properties.Appearance.Options.UseFont = true;
            this.chkCetakSisiBawah.Properties.Caption = "Cetak Sisi Bawah";
            this.chkCetakSisiBawah.Size = new System.Drawing.Size(124, 20);
            this.chkCetakSisiBawah.TabIndex = 1;
            // 
            // chkCetakSisiAtas
            // 
            this.chkCetakSisiAtas.Location = new System.Drawing.Point(6, 21);
            this.chkCetakSisiAtas.Name = "chkCetakSisiAtas";
            this.chkCetakSisiAtas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chkCetakSisiAtas.Properties.Appearance.Options.UseFont = true;
            this.chkCetakSisiAtas.Properties.Caption = "Cetak Sisi Atas";
            this.chkCetakSisiAtas.Size = new System.Drawing.Size(124, 20);
            this.chkCetakSisiAtas.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelControl5);
            this.groupBox3.Controls.Add(this.labelControl4);
            this.groupBox3.Controls.Add(this.txtLebarKertas);
            this.groupBox3.Controls.Add(this.txtPanjangKertas);
            this.groupBox3.Controls.Add(this.cmbUkuranKertas);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(5, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kertas";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl5.Location = new System.Drawing.Point(108, 42);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 16);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "L :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl4.Location = new System.Drawing.Point(9, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 16);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "P :";
            // 
            // txtLebarKertas
            // 
            this.txtLebarKertas.Location = new System.Drawing.Point(129, 41);
            this.txtLebarKertas.Name = "txtLebarKertas";
            this.txtLebarKertas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLebarKertas.Properties.Appearance.Options.UseFont = true;
            this.txtLebarKertas.Size = new System.Drawing.Size(55, 20);
            this.txtLebarKertas.TabIndex = 4;
            // 
            // txtPanjangKertas
            // 
            this.txtPanjangKertas.Location = new System.Drawing.Point(36, 41);
            this.txtPanjangKertas.Name = "txtPanjangKertas";
            this.txtPanjangKertas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPanjangKertas.Properties.Appearance.Options.UseFont = true;
            this.txtPanjangKertas.Size = new System.Drawing.Size(55, 20);
            this.txtPanjangKertas.TabIndex = 3;
            // 
            // cmbUkuranKertas
            // 
            this.cmbUkuranKertas.Location = new System.Drawing.Point(9, 20);
            this.cmbUkuranKertas.Name = "cmbUkuranKertas";
            this.cmbUkuranKertas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUkuranKertas.Properties.Appearance.Options.UseFont = true;
            this.cmbUkuranKertas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUkuranKertas.Properties.Items.AddRange(new object[] {
            "A3 297mm x 42mm",
            "A3+ 297mm x 43mm"});
            this.cmbUkuranKertas.Size = new System.Drawing.Size(175, 20);
            this.cmbUkuranKertas.TabIndex = 2;
            this.cmbUkuranKertas.SelectedIndexChanged += new System.EventHandler(this.cmbUkuranKertas_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelControl3);
            this.groupBox4.Controls.Add(this.labelControl2);
            this.groupBox4.Controls.Add(this.txtJmlKertas);
            this.groupBox4.Controls.Add(this.txtJmlHalaman);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(5, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 71);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informasi";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl3.Location = new System.Drawing.Point(23, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Jml Kertas :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl2.Location = new System.Drawing.Point(9, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Jml Halaman :";
            // 
            // txtJmlKertas
            // 
            this.txtJmlKertas.Location = new System.Drawing.Point(93, 41);
            this.txtJmlKertas.Name = "txtJmlKertas";
            this.txtJmlKertas.Size = new System.Drawing.Size(75, 20);
            this.txtJmlKertas.TabIndex = 9;
            // 
            // txtJmlHalaman
            // 
            this.txtJmlHalaman.Location = new System.Drawing.Point(93, 15);
            this.txtJmlHalaman.Name = "txtJmlHalaman";
            this.txtJmlHalaman.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJmlHalaman.Properties.Appearance.Options.UseFont = true;
            this.txtJmlHalaman.Size = new System.Drawing.Size(75, 20);
            this.txtJmlHalaman.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labelControl8);
            this.groupBox5.Controls.Add(this.labelControl7);
            this.groupBox5.Controls.Add(this.labelControl6);
            this.groupBox5.Controls.Add(this.txtManual);
            this.groupBox5.Controls.Add(this.txtPage2);
            this.groupBox5.Controls.Add(this.txtPage1);
            this.groupBox5.Controls.Add(this.cmbPrintOpsi);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox5.Location = new System.Drawing.Point(209, 77);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 140);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Printer Opsi";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl8.Location = new System.Drawing.Point(113, 49);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(18, 16);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "s/d";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl7.Location = new System.Drawing.Point(6, 75);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 16);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Manual :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl6.Location = new System.Drawing.Point(16, 49);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 16);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Page :";
            // 
            // txtManual
            // 
            this.txtManual.Location = new System.Drawing.Point(58, 72);
            this.txtManual.Name = "txtManual";
            this.txtManual.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManual.Properties.Appearance.Options.UseFont = true;
            this.txtManual.Size = new System.Drawing.Size(125, 20);
            this.txtManual.TabIndex = 7;
            // 
            // txtPage2
            // 
            this.txtPage2.Location = new System.Drawing.Point(134, 46);
            this.txtPage2.Name = "txtPage2";
            this.txtPage2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPage2.Properties.Appearance.Options.UseFont = true;
            this.txtPage2.Size = new System.Drawing.Size(49, 20);
            this.txtPage2.TabIndex = 6;
            // 
            // txtPage1
            // 
            this.txtPage1.Location = new System.Drawing.Point(58, 46);
            this.txtPage1.Name = "txtPage1";
            this.txtPage1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPage1.Properties.Appearance.Options.UseFont = true;
            this.txtPage1.Size = new System.Drawing.Size(48, 20);
            this.txtPage1.TabIndex = 5;
            // 
            // cmbPrintOpsi
            // 
            this.cmbPrintOpsi.Location = new System.Drawing.Point(6, 20);
            this.cmbPrintOpsi.Name = "cmbPrintOpsi";
            this.cmbPrintOpsi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrintOpsi.Properties.Appearance.Options.UseFont = true;
            this.cmbPrintOpsi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrintOpsi.Size = new System.Drawing.Size(177, 20);
            this.cmbPrintOpsi.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labelControl1);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.groupBox6.Location = new System.Drawing.Point(5, 220);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(409, 48);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Status";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl1.Location = new System.Drawing.Point(8, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Status Here";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(5, 274);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 28);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(78, 274);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "CLOSE";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveSetting.Image")));
            this.btnSaveSetting.Location = new System.Drawing.Point(331, 274);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(70, 28);
            this.btnSaveSetting.TabIndex = 7;
            this.btnSaveSetting.Text = "SAVE";
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // frmSettingPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 310);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettingPrinter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cek Minuta / Salinan";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbTypePrinter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbListPrinter.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkCetakSisiBawah.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCetakSisiAtas.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLebarKertas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPanjangKertas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUkuranKertas.Properties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlKertas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlHalaman.Properties)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtManual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPage2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPage1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrintOpsi.Properties)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTypePrinter;
        private DevExpress.XtraEditors.ComboBoxEdit cmbListPrinter;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.CheckEdit chkCetakSisiBawah;
        private DevExpress.XtraEditors.CheckEdit chkCetakSisiAtas;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtLebarKertas;
        private DevExpress.XtraEditors.TextEdit txtPanjangKertas;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUkuranKertas;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.TextEdit txtJmlKertas;
        private DevExpress.XtraEditors.TextEdit txtJmlHalaman;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevExpress.XtraEditors.TextEdit txtManual;
        private DevExpress.XtraEditors.TextEdit txtPage2;
        private DevExpress.XtraEditors.TextEdit txtPage1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPrintOpsi;
        private System.Windows.Forms.GroupBox groupBox6;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveSetting;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}