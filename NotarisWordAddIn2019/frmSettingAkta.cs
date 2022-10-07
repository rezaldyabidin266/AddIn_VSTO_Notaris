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
    public partial class frmSettingAkta : DevExpress.XtraEditors.XtraForm
    {
        public frmSettingAkta()
        {
            InitializeComponent();
            FontFamily[] fontArray = FontFamily.Families;
            foreach (var item in fontArray)
            {
                cmbFonts.Properties.Items.Add(item.Name);
            }
            cmbFonts.Text = "Courier New";
            GetSetting();
        }

        protected string Fontselected;
        protected string txtMarginKiriSelected;
        protected string txtMarginKananSelected;
        protected string txtMarginAtasSelected;
        protected string txtMarginBawahSelected;
        protected string txtFontSizeSelected;
        protected string txtPosisiHurufSelected;
        protected string txtPanjangKertasSelected;
        protected string txtLebarKertasSelected;
        protected string pathNameFileCap;
        protected string pathNameFileStempel;

        private void GetSetting()
        {
            //Margin
            txtMarginKiri.EditValue = Fungsi.GetSetting("MarginKiri", GVar.myPath).ToFloat();
            txtMarginKanan.EditValue = Fungsi.GetSetting("MarginKanan", GVar.myPath).ToFloat();
            txtMarginAtas.EditValue = Fungsi.GetSetting("MarginAtas", GVar.myPath).ToFloat();
            txtMarginBawah.EditValue = Fungsi.GetSetting("MarginBawah", GVar.myPath).ToFloat();

            //Kertas
            cmbUkuranKertas.Text = Fungsi.GetSetting("UkuranKertas", GVar.myPath);
            txtLebarKertas.EditValue = Fungsi.GetSetting("LebarKertas", GVar.myPath).ToFloat();
            txtPanjangKertas.EditValue = Fungsi.GetSetting("PanjangKertas", GVar.myPath).ToFloat();
            chkHapusBarisKosong.Checked = Fungsi.GetSetting("IsHapusBarisKosong", GVar.myPath).IsEmpty();

            //Huruf
            cmbFonts.Text = Fungsi.GetSetting("FontName", GVar.myPath);
            txtFontSize.EditValue = Fungsi.GetSetting("FontSize", GVar.myPath).ToFloat();
            txtPosisiHuruf.EditValue = Fungsi.GetSetting("PosisiHuruf", GVar.myPath).ToFloat();

            //Cap & Stempel
            browseFileCap.FileName = Fungsi.GetSetting("pathFileCap", GVar.myPath);
            txtPathCap.Text = Fungsi.GetSetting("pathFileCap", GVar.myPath);
            browseFileStempel.FileName = Fungsi.GetSetting("pathFileStempel", GVar.myPath);
            txtPathStempel.Text = Fungsi.GetSetting("pathFileStempel", GVar.myPath);

        }
        private void SaveSetting()
        {
            //Margin
            Fungsi.SetSetting("MarginKiri", txtMarginKiri.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("MarginKanan", txtMarginKanan.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("MarginAtas", txtMarginAtas.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("MarginBawah", txtMarginBawah.EditValue.ToString(), GVar.myPath);

            //Kertas
            Fungsi.SetSetting("UkuranKertas", cmbUkuranKertas.Text, GVar.myPath);
            Fungsi.SetSetting("LebarKertas", txtLebarKertas.Text, GVar.myPath);
            Fungsi.SetSetting("PanjangKertas", txtPanjangKertas.Text, GVar.myPath);
            Fungsi.SetSetting("IsHapusBarisKosong", chkHapusBarisKosong.IsEmpty().ToString(), GVar.myPath);

            //Huruf
            Fungsi.SetSetting("FontName", cmbFonts.Text, GVar.myPath);
            Fungsi.SetSetting("FontSize", txtFontSize.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("PosisiHuruf", txtPosisiHuruf.EditValue.ToString(), GVar.myPath);

            //Cap & Stempel
            Fungsi.SetSetting("pathFileCap", browseFileCap.FileName, GVar.myPath);
            Fungsi.SetSetting("pathFileStempel", browseFileStempel.FileName, GVar.myPath);
        
        }
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            SaveSetting();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkHapusBarisKosong_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSaveFormat_Click_1(object sender, EventArgs e)
        {
            Umum.SaveFormatAkta(Fontselected,
                     txtMarginKiriSelected,
                     txtMarginKananSelected,
                     txtMarginAtasSelected,
                     txtMarginBawahSelected,
                     txtFontSizeSelected,
                     txtPosisiHurufSelected,
                     txtPanjangKertasSelected,
                     txtLebarKertasSelected);

            this.Close();
        }

        private void txtMarginKiri_EditValueChanged_1(object sender, EventArgs e)
        {
            txtMarginKiriSelected = txtMarginKiri.EditValue.ToString();
        }

        private void txtMarginKanan_EditValueChanged(object sender, EventArgs e)
        {
            txtMarginKananSelected = txtMarginKanan.EditValue.ToString();
        }

        private void txtMarginAtas_EditValueChanged_1(object sender, EventArgs e)
        {
            txtMarginAtasSelected = txtMarginAtas.EditValue.ToString();
        }

        private void cmbUkuranKertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbUkuranKertas.Text)
            {
                case "Standart":
                    txtLebarKertas.Text = "29.7";
                    txtPanjangKertas.Text = "21";
                    break;
                case "Sutjipto":
                    txtLebarKertas.Text = "29.5";
                    txtPanjangKertas.Text = "19.5";
                    break;
                default:
                    break;

            }
        }

        private void txtMarginBawah_EditValueChanged(object sender, EventArgs e)
        {
            txtMarginBawahSelected = txtMarginBawah.EditValue.ToString();
        }

        private void txtLebarKertas_EditValueChanged(object sender, EventArgs e)
        {
            txtLebarKertasSelected = txtLebarKertas.Text;
        }

        private void txtPanjangKertas_EditValueChanged(object sender, EventArgs e)
        {
            txtPanjangKertasSelected = txtPanjangKertas.Text;
        }

        private void cmbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fontselected = cmbFonts.Text;
        }

        private void txtFontSize_EditValueChanged(object sender, EventArgs e)
        {
            txtFontSizeSelected = txtFontSize.EditValue.ToString();
        }

        private void txtPosisiHuruf_EditValueChanged(object sender, EventArgs e)
        {
            txtPosisiHurufSelected = txtPosisiHuruf.EditValue.ToString();
        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseCap_Click(object sender, EventArgs e)
        {
            browseFileCap.ShowDialog();
            browseFileCap.Multiselect = false;
            pathNameFileCap = browseFileCap.FileName;
            txtPathCap.Text = browseFileCap.FileName;
            Umum.getPathCap(pathNameFileCap);       
        }

        private void btnBrowseStempel_Click(object sender, EventArgs e)
        {
            browseFileStempel.ShowDialog();
            browseFileStempel.Multiselect = false;
            pathNameFileStempel = browseFileCap.FileName;
            txtPathStempel.Text = browseFileStempel.FileName;
            Umum.getPathStempel(browseFileStempel.FileName);
        }
    }
}