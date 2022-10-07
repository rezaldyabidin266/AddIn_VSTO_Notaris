namespace NotarisWordAddIn2019
{
    partial class frmPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinter));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtJmlKertas = new DevExpress.XtraEditors.TextEdit();
            this.txtJmlHalaman = new DevExpress.XtraEditors.TextEdit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlKertas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlHalaman.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(83, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "CLOSE";
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.Location = new System.Drawing.Point(12, 93);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 28);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelControl3);
            this.groupBox4.Controls.Add(this.labelControl2);
            this.groupBox4.Controls.Add(this.txtJmlKertas);
            this.groupBox4.Controls.Add(this.txtJmlHalaman);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 71);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informasi";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(23, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Jml Kertas :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl2.Appearance.Options.UseFont = true;
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
            this.txtJmlKertas.EditValueChanged += new System.EventHandler(this.txtJmlKertas_EditValueChanged);
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
            // frmPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 130);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox4);
            this.Name = "frmPrinter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrinter";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlKertas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJmlHalaman.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtJmlKertas;
        private DevExpress.XtraEditors.TextEdit txtJmlHalaman;
    }
}