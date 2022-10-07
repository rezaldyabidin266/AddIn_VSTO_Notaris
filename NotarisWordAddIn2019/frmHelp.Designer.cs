namespace NotarisWordAddIn2019
{
    partial class frmHelp
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
            this.components = new System.ComponentModel.Container();
            this.txtHelp = new DevExpress.XtraEditors.MemoEdit();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.btnBrowser = new DevExpress.XtraEditors.XtraFolderBrowserDialog(this.components);
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.openFile = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.Location = new System.Drawing.Point(-4, 158);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelp.Properties.Appearance.Options.UseFont = true;
            this.txtHelp.Size = new System.Drawing.Size(327, 174);
            this.txtHelp.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnBrowser
            // 
            this.btnBrowser.SelectedPath = "xtraFolderBrowserDialog1";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "btnTest";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 329);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            ((System.ComponentModel.ISupportInitialize)(this.txtHelp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtHelp;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private DevExpress.XtraEditors.XtraFolderBrowserDialog btnBrowser;
        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.XtraOpenFileDialog openFile;
    }
}