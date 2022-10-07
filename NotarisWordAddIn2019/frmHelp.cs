using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MyHelper;
namespace NotarisWordAddIn2019
{
    public partial class frmHelp : DevExpress.XtraEditors.XtraForm
    {
        public frmHelp()
        {
            InitializeComponent();
            StringBuilder notehelp = new StringBuilder();
            notehelp.Append("1. Ubah measurements unit ke Cm.").AppendLine();
            notehelp.Append("   Options -> Advance -> Display");
            txtHelp.Text = notehelp.ToString();
            txtHelp.ReadOnly = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            openFile.Multiselect = false;
            string pathCap = openFile.FileName;
            Umum.getPathCap(pathCap);
        }
    }
}