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
    public partial class frmWaktu : DevExpress.XtraEditors.XtraForm
    {
        public frmWaktu()
        {
            InitializeComponent();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (rbtOpsi.SelectedIndex)
            {
                case 0:
                    Umum.InsertText(dtpWaktu.Time.ToString("HH:mm WIB") + Fungsi.TerbilangJam(dtpWaktu.Time.TimeOfDay, Fungsi.infotime.WIB));
                    break;
                case 1:
                    Umum.InsertText(dtpWaktu.Time.ToString("HH:mm WITA") + Fungsi.TerbilangJam(dtpWaktu.Time.TimeOfDay, Fungsi.infotime.WITA));
                    break;
                case 2:
                    Umum.InsertText(dtpWaktu.Time.ToString("HH:mm WIT") + Fungsi.TerbilangJam(dtpWaktu.Time.TimeOfDay, Fungsi.infotime.WIT));
                    break;
                default:
                    break;
            }

            Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}