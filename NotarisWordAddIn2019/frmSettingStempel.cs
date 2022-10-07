using DevExpress.XtraEditors;
using MyHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotarisWordAddIn2019
{
    public partial class frmSettingStempel : DevExpress.XtraEditors.XtraForm
    {
        public frmSettingStempel()
        {
            InitializeComponent();

            GetSetting();
        }

        protected float naikBaris;
        protected float batasMarginAtas;
        protected float batasMarginKiri;
        protected float panjangStempel;
        protected float lebarStempel;

        private void GetSetting()
        {
            //Posisi Stempel
            txtNaikBaris.EditValue = Fungsi.GetSetting("NaikBaris", GVar.myPath).ToFloat();

            //Batas Margin Stempel
            txtBatasMarginAtas.EditValue = Fungsi.GetSetting("BatasMarginAtas", GVar.myPath).ToFloat();
            txtBatasMarginKiri.EditValue = Fungsi.GetSetting("BatasMarginKiri", GVar.myPath).ToFloat();

            //Ukuran Stempel
            txtPanjangStempel.EditValue = Fungsi.GetSetting("PanjangStempel", GVar.myPath).ToFloat();
            txtLebarStempel.EditValue = Fungsi.GetSetting("LebarStempel", GVar.myPath).ToFloat();

        }

        private void SaveSetting()
        {
            Fungsi.SetSetting("NaikBaris", txtNaikBaris.EditValue.ToString(), GVar.myPath);

            Fungsi.SetSetting("BatasMarginAtas", txtBatasMarginAtas.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("BatasMarginKiri", txtBatasMarginKiri.EditValue.ToString(), GVar.myPath);

            Fungsi.SetSetting("PanjangStempel", txtPanjangStempel.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("LebarStempel", txtLebarStempel.EditValue.ToString(), GVar.myPath);
        }

            private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void txtNaikBaris_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtBatasMarginKiri_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtBatasMarginAtas_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPanjangStempel_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLebarStempel_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveFormat_Click(object sender, EventArgs e)
        {

            naikBaris = txtNaikBaris.EditValue.ToFloat();
            batasMarginAtas = txtBatasMarginAtas.EditValue.ToFloat();
            batasMarginKiri = txtBatasMarginKiri.EditValue.ToFloat();
            panjangStempel = txtPanjangStempel.EditValue.ToFloat();
            lebarStempel = txtLebarStempel.EditValue.ToFloat();

            Umum.getSettingStempel(
                naikBaris,
                batasMarginAtas,
                batasMarginKiri,
                panjangStempel,
                lebarStempel
                );

            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            SaveSetting();
            this.Close();
        }
    }
}