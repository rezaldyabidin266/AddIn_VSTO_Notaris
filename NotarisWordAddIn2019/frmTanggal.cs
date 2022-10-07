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
    public partial class frmTanggal : DevExpress.XtraEditors.XtraForm
    {
        public frmTanggal()
        {
            InitializeComponent();
            cmbOpsi.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (cmbOpsi.SelectedIndex)
            {
                case 0:
                    Umum.InsertText(dtpTanggal.DateTime.ToString("(dd-MM-yyyy)") + Fungsi.TerbilangTgl(dtpTanggal.DateTime.Date, IsPpat: false));
                    break;
                case 1:
                    Umum.InsertText(Fungsi.TerbilangTgl(dtpTanggal.DateTime.Date, IsPpat: false) + dtpTanggal.DateTime.ToString("(dd-MM-yyyy)"));
                    break;
                case 2:
                    Umum.InsertText(Fungsi.TerbilangTgl(dtpTanggal.DateTime.Date, IsPpat: true));
                    break;
                default:
                    break;
            }

            Close();
        }

        private void dtpTanggal_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbOpsi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sad_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}