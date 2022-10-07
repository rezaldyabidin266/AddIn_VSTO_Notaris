namespace NotarisWordAddIn2019
{
    partial class frmNominal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNominal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNominal = new DevExpress.XtraEditors.TextEdit();
            this.rbtOpsi = new DevExpress.XtraEditors.RadioGroup();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNominal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtOpsi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNominal);
            this.groupBox1.Controls.Add(this.rbtOpsi);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Isi Angka";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtNominal
            // 
            this.txtNominal.Location = new System.Drawing.Point(3, 18);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNominal.Properties.Appearance.Options.UseFont = true;
            this.txtNominal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNominal.Size = new System.Drawing.Size(205, 20);
            this.txtNominal.TabIndex = 1;
            this.txtNominal.EditValueChanged += new System.EventHandler(this.txtNominal_EditValueChanged);
            // 
            // rbtOpsi
            // 
            this.rbtOpsi.Location = new System.Drawing.Point(3, 38);
            this.rbtOpsi.Name = "rbtOpsi";
            this.rbtOpsi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtOpsi.Properties.Appearance.Options.UseFont = true;
            this.rbtOpsi.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Rupiah"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Meter"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Empty")});
            this.rbtOpsi.Size = new System.Drawing.Size(205, 25);
            this.rbtOpsi.TabIndex = 0;
            this.rbtOpsi.SelectedIndexChanged += new System.EventHandler(this.rbtOpsi_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(93, 81);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(44, 32);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(140, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "CLOSE";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmNominal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 118);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNominal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terbilang";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNominal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtOpsi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.RadioGroup rbtOpsi;
        private DevExpress.XtraEditors.TextEdit txtNominal;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}