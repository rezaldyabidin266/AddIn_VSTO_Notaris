namespace NotarisWordAddIn2019
{
    partial class frmTanggal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTanggal));
            this.sad = new System.Windows.Forms.GroupBox();
            this.cmbOpsi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtpTanggal = new DevExpress.XtraEditors.DateEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.sad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOpsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTanggal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTanggal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sad
            // 
            this.sad.Controls.Add(this.cmbOpsi);
            this.sad.Controls.Add(this.dtpTanggal);
            this.sad.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.sad.Location = new System.Drawing.Point(4, 5);
            this.sad.Name = "sad";
            this.sad.Size = new System.Drawing.Size(182, 68);
            this.sad.TabIndex = 0;
            this.sad.TabStop = false;
            this.sad.Text = "Pilih Tanggal";
            this.sad.Enter += new System.EventHandler(this.sad_Enter);
            // 
            // cmbOpsi
            // 
            this.cmbOpsi.Location = new System.Drawing.Point(6, 41);
            this.cmbOpsi.Name = "cmbOpsi";
            this.cmbOpsi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cmbOpsi.Properties.Appearance.Options.UseFont = true;
            this.cmbOpsi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOpsi.Properties.Items.AddRange(new object[] {
            "Urai Tanggal Di Awal",
            "Urai Tanggal Di Akhir",
            "Tanggal PPAT"});
            this.cmbOpsi.Size = new System.Drawing.Size(170, 22);
            this.cmbOpsi.TabIndex = 1;
            this.cmbOpsi.SelectedIndexChanged += new System.EventHandler(this.cmbOpsi_SelectedIndexChanged);
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.EditValue = new System.DateTime(2015, 12, 7, 15, 3, 0, 0);
            this.dtpTanggal.Location = new System.Drawing.Point(6, 18);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.dtpTanggal.Properties.Appearance.Options.UseFont = true;
            this.dtpTanggal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTanggal.Properties.DisplayFormat.FormatString = "ddd, ddd-MMM-yyyy";
            this.dtpTanggal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTanggal.Properties.EditFormat.FormatString = "dddd, dd-MMM-yyyy";
            this.dtpTanggal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTanggal.Properties.Mask.EditMask = "dddd, dd-MMM-yyyy";
            this.dtpTanggal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpTanggal.Size = new System.Drawing.Size(170, 22);
            this.dtpTanggal.TabIndex = 0;
            this.dtpTanggal.EditValueChanged += new System.EventHandler(this.dtpTanggal_EditValueChanged);
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(73, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(44, 32);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(119, 79);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTanggal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 114);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.sad);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTanggal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanggal";
            this.sad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbOpsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTanggal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTanggal.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox sad;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOpsi;
        private DevExpress.XtraEditors.DateEdit dtpTanggal;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}