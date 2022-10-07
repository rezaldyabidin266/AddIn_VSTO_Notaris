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
    public partial class frmNominal : DevExpress.XtraEditors.XtraForm
    {
        public frmNominal()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            decimal value = txtNominal.EditValue.ToDecimal();

            switch (rbtOpsi.SelectedIndex)
            {
                case 0:
                    Umum.InsertText(Fungsi.TerbilangRupiahSen(value, IsInfoRupiahSen: true));
                    break;
                case 1:
                    Umum.InsertText(Fungsi.TerbilangMeterPersegi(value));
                    break;
                case 2:
                    Umum.InsertText(Fungsi.TerbilangRupiahSen(value, IsInfoRupiahSen: false));
                    break;
                default:
                    break;
            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbtOpsi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtNominal_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}