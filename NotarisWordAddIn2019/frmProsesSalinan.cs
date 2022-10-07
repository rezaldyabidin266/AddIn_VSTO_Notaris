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
using Microsoft.Office.Interop.Word;

namespace NotarisWordAddIn2019
{
    public partial class frmProsesSalinan : DevExpress.XtraEditors.XtraForm
    {

        private static Microsoft.Office.Interop.Word.Selection _mySelection = Globals.ThisAddIn.Application.Selection;
        public frmProsesSalinan()
        {
            InitializeComponent();

            GetSetting();
        }

        private void GetSetting()
        {
            //Proses Akta
            var listProsesAkta = rbtProsesAkta.Properties.Items.Select(x => x.Description);
            var valueProsesAkta = Fungsi.GetSetting("ProsesAkta", GVar.myPath);
            if (listProsesAkta.Contains(valueProsesAkta))
            {
                SettingEnum.ProsesAkta value = (SettingEnum.ProsesAkta)Enum.Parse(typeof(SettingEnum.ProsesAkta), valueProsesAkta);
                rbtProsesAkta.SelectedIndex = value.ToInteger();
            }

            //Posisi Vertikal No Halaman
            var listVertikalNo = rbtPosisiVertikal.Properties.Items.Select(x => x.Description);
            var valueVertikalNo = Fungsi.GetSetting("PosisiVertikalNoHalaman", GVar.myPath);
            if (listVertikalNo.Contains(valueVertikalNo))
            {
                SettingEnum.PosisiVertikalNomorHalaman value = (SettingEnum.PosisiVertikalNomorHalaman)Enum.Parse(typeof(SettingEnum.PosisiVertikalNomorHalaman), valueVertikalNo.Replace(" ", string.Empty));
                rbtPosisiVertikal.SelectedIndex = value.ToInteger();
            }

            //Posisi Horisontal No Halaman
            var listHorisontalNo = rbtPosisiHorisontal.Properties.Items.Select(x => x.Description);
            var valueHorisontalNo = Fungsi.GetSetting("PosisiHorisontalNoHalaman", GVar.myPath);
            if (listHorisontalNo.Contains(valueHorisontalNo))
            {
                SettingEnum.PosisiHorisontalNomorHalaman value = (SettingEnum.PosisiHorisontalNomorHalaman)Enum.Parse(typeof(SettingEnum.PosisiHorisontalNomorHalaman), valueHorisontalNo.Replace(" ", string.Empty));
                rbtPosisiHorisontal.SelectedIndex = value.ToInteger();
            }

            //Warna Garis Tepi
            var listWarnaGaris = rbtWarnaGarisTepi.Properties.Items.Select(x => x.Description);
            var valueWarna = Fungsi.GetSetting("WarnaGaris", GVar.myPath);
            if (listWarnaGaris.Contains(valueWarna))
            {
                SettingEnum.WarnaGaris value = (SettingEnum.WarnaGaris)Enum.Parse(typeof(SettingEnum.WarnaGaris), valueWarna);
                rbtWarnaGarisTepi.SelectedIndex = value.ToInteger();
            }

            //Model Salinan
            var listModel = rbtModel.Properties.Items.Select(x => x.Description);
            var valueModel = Fungsi.GetSetting("ModelSalinan", GVar.myPath);
            if (listModel.Contains(valueModel))
            {
                SettingEnum.ModelSalinan value = (SettingEnum.ModelSalinan)Enum.Parse(typeof(SettingEnum.ModelSalinan), valueModel.Replace(" ", string.Empty));
                rbtModel.SelectedIndex = value.ToInteger();
            }
            //Garis
            chkGarisDatar.Checked = Fungsi.GetSetting("GarisDatar", GVar.myPath).ToInteger().ToBool();
            chkGarisPinggir.Checked = Fungsi.GetSetting("GarisPinggir", GVar.myPath).ToInteger().ToBool();
            //chkGarisIndent.Checked = Fungsi.GetSetting("GarisIndent", GVar.myPath).ToInteger().ToBool();

            //Atas
            txtPanjangGrsAts.EditValue = Fungsi.GetSetting("PanjangGarisAtasCm", GVar.myPath).ToDecimal();
            txtSudutAts.EditValue = Fungsi.GetSetting("SudutGarisAtasPts", GVar.myPath).ToInteger();
            txtPosisiAts.EditValue = Fungsi.GetSetting("PosisiGarisAtasPts", GVar.myPath).ToInteger();

            //Bawah
            txtPanjangGrsBwh.EditValue = Fungsi.GetSetting("PanjangGarisBawahCm", GVar.myPath).ToDecimal();
            txtSudutBwh.EditValue = Fungsi.GetSetting("SudutGarisBawahPts", GVar.myPath).ToInteger();
            txtPosisiBwh.EditValue = Fungsi.GetSetting("PosisiGarisBawahPts", GVar.myPath).ToInteger();

            //Halaman
            //txtBarisJudul.EditValue = Fungsi.GetSetting("BarisJudul", GVar.myPath).ToInteger();
            //txtJumlahHalaman.EditValue = Fungsi.GetSetting("JumlahHalaman",GVar.myPath).ToInteger();

            txtJumlahHalaman.EditValue = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            txtBarisJudul.EditValue = _mySelection.Range.Information[WdInformation.wdFirstCharacterLineNumber] - 1;

            txtNamaNotaris1.Text = Fungsi.GetSetting("NamaNotaris1", GVar.myPath);
            txtNamaNotaris2.Text = Fungsi.GetSetting("NamaNotaris2", GVar.myPath);

            txtBatasKiriNamaNotaris.Text = Fungsi.GetSetting("BatasKiriNamaNotaris", GVar.myPath);

            chkSimpanHasilProses.Checked = Fungsi.GetSetting("SimpanProsesKeFileSementara", GVar.myPath).ToInteger().ToBool();
            chkCap.Checked = Fungsi.GetSetting("Cap", GVar.myPath).ToInteger().ToBool();
            chkStempel.Checked = Fungsi.GetSetting("Stempel", GVar.myPath).ToInteger().ToBool();
            cmbPosisiCapdanStempel.Text = Fungsi.GetSetting("PosisiCapdanStempel", GVar.myPath);

            GetSettingKalimatPenutup();

            if (string.IsNullOrWhiteSpace(txtNamaNotaris1.Text))
                txtNamaNotaris1.Text = "Applikasi Software Notaris Add On";

            if (string.IsNullOrWhiteSpace(txtNamaNotaris2.Text))
                txtNamaNotaris2.Text = "Create By Brasil Soft Devlopment (0815-8899-672)";

            CekKalimatPenutupIsEmpty();
        }

        private void CekKalimatPenutupIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(txtPenutup1.Text))
            {
                if (rbtBahasaPilihan.SelectedIndex == 0)
                    txtPenutup1.Text = "-Minuta akta ini telah ditandatangani dengan sempurna.";
                else
                    txtPenutup1.Text = "-The original of this deed has been properly signed.";
            }

            if (string.IsNullOrWhiteSpace(txtPenutup2.Text))
            {
                if (rbtBahasaPilihan.SelectedIndex == 0)
                    txtPenutup2.Text = "-Diberikan sebagai salinan yang sama bunyinya.";
                else
                    txtPenutup2.Text = "-Issued as a copy of the same tenor.";
            }
        }

        private void GetSettingKalimatPenutup()
        {
            //Bahasa Penutup
            var listBahasa = rbtBahasaPilihan.Properties.Items.Select(x => x.Description);
            var valueBahasa = Fungsi.GetSetting("BahasaPenutup", GVar.myPath);
            if (listBahasa.Contains(valueBahasa))
            {
                SettingEnum.Bahasa value = (SettingEnum.Bahasa)Enum.Parse(typeof(SettingEnum.Bahasa), valueBahasa);
                rbtBahasaPilihan.SelectedIndex = value.ToInteger();
            }

            if (rbtBahasaPilihan.SelectedIndex == 0) //Indonesia
            {
                txtPenutup1.Text = Fungsi.GetSetting("PenutupINA_1", GVar.myPath);
                txtPenutup2.Text = Fungsi.GetSetting("PenutupINA_2", GVar.myPath);
            }
            else
            {
                txtPenutup1.Text = Fungsi.GetSetting("PenutupENG_1", GVar.myPath);
                txtPenutup2.Text = Fungsi.GetSetting("PenutupENG_2", GVar.myPath);
            }

            chkHideKalimatPenutup.Checked = Fungsi.GetSetting("HideKalimatPenutupAkta", GVar.myPath).ToInteger().ToBool();
            chkHideNamaNotaris.Checked = Fungsi.GetSetting("HideNamaNotaris", GVar.myPath).ToInteger().ToBool();

        }
        private void SaveSetting()
        {
            Fungsi.SetSetting("ProsesAkta", rbtProsesAkta.Properties.Items[rbtProsesAkta.SelectedIndex].Description, GVar.myPath);
            Fungsi.SetSetting("PosisiVertikalNoHalaman", rbtPosisiVertikal.Properties.Items[rbtPosisiVertikal.SelectedIndex].Description, GVar.myPath);
            Fungsi.SetSetting("PosisiHorisontalNoHalaman", rbtPosisiHorisontal.Properties.Items[rbtPosisiHorisontal.SelectedIndex].Description, GVar.myPath);
            Fungsi.SetSetting("WarnaGaris", rbtWarnaGarisTepi.Properties.Items[rbtWarnaGarisTepi.SelectedIndex].Description, GVar.myPath);
            Fungsi.SetSetting("ModelSalinan", rbtModel.Properties.Items[rbtModel.SelectedIndex].Description, GVar.myPath);

            //Atas
            Fungsi.SetSetting("PanjangGarisAtasCm", txtPanjangGrsAts.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("SudutGarisAtasPts", txtSudutAts.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("PosisiGarisAtasPts", txtPosisiAts.EditValue.ToString(), GVar.myPath);

            //Bawah
            Fungsi.SetSetting("PanjangGarisBawahCm", txtPanjangGrsBwh.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("SudutGarisBawahPts", txtSudutBwh.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("PosisiGarisBawahPts", txtPosisiBwh.EditValue.ToString(), GVar.myPath);

            //Garis
            Fungsi.SetSetting("GarisDatar", chkGarisDatar.EditValue.ToInteger().ToString(), GVar.myPath);
            Fungsi.SetSetting("GarisPinggir", chkGarisPinggir.EditValue.ToInteger().ToString(), GVar.myPath);
            //Fungsi.SetSetting("GarisIndent", chkGarisIndent.EditValue.ToInteger().ToString(), GVar.myPath);

            //Notaris
            Fungsi.SetSetting("NamaNotaris1", txtNamaNotaris1.Text, GVar.myPath);
            Fungsi.SetSetting("NamaNotaris2", txtNamaNotaris2.Text, GVar.myPath);
            Fungsi.SetSetting("BatasKiriNamaNotaris", txtBatasKiriNamaNotaris.Text, GVar.myPath);

            //Other
            Fungsi.SetSetting("SimpanProsesKeFileSementara", chkSimpanHasilProses.EditValue.ToInteger().ToString(), GVar.myPath);
            Fungsi.SetSetting("Cap", chkCap.EditValue.ToInteger().ToString(), GVar.myPath);
            Fungsi.SetSetting("Stempel", chkStempel.EditValue.ToInteger().ToString(), GVar.myPath);
            Fungsi.SetSetting("PosisiCapdanStempel", cmbPosisiCapdanStempel.Text, GVar.myPath);

            //Halaman
            //Fungsi.SetSetting("BarisJudul", txtBarisJudul.EditValue.ToString(), GVar.myPath);
            //Fungsi.SetSetting("JumlahHalaman", txtJumlahHalaman.EditValue.ToString(), GVar.myPath);

            Fungsi.SetSetting("BahasaPenutup", rbtBahasaPilihan.Properties.Items[rbtBahasaPilihan.SelectedIndex].Description, GVar.myPath);

            if (rbtBahasaPilihan.SelectedIndex == 0) //Indonesia
            {
                Fungsi.SetSetting("PenutupINA_1", txtPenutup1.Text, GVar.myPath);
                Fungsi.SetSetting("PenutupINA_2", txtPenutup2.Text, GVar.myPath);
            }
            else
            {
                Fungsi.SetSetting("PenutupENG_1", txtPenutup1.Text, GVar.myPath);
                Fungsi.SetSetting("PenutupENG_2", txtPenutup2.Text, GVar.myPath);
            }

            Fungsi.SetSetting("HideKalimatPenutupAkta", chkHideKalimatPenutup.EditValue.ToInteger().ToString(), GVar.myPath);
            Fungsi.SetSetting("HideNamaNotaris", chkHideNamaNotaris.EditValue.ToInteger().ToString(), GVar.myPath);

            MyHelper.Dx.InfoBerhasilDx("Berhasil Simpan Setting");
        }
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            SaveSetting();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSetting();
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Umum.GetSetting();
            this.Close();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {

            //frmProsesSalinan.ActiveForm.Dispose();
            //frmProsesSalinan.ActiveForm.Dispose();
            //this.Hide();
            //this.Close();
            this.Dispose();
            //this.Visible = false;
            //DialogResult = DialogResult.Cancel;
            //this.Close();

            var prosesAktaValue = rbtProsesAkta.Properties.Items[rbtProsesAkta.SelectedIndex].Description;
            var HideKalimatPenutupAktaSelected = chkHideKalimatPenutup.EditValue.ToInteger();
            var bahasaSelected = rbtBahasaPilihan.Properties.Items[rbtBahasaPilihan.SelectedIndex].Description;
            //var chkGarisIndentSelected = chkGarisIndent.Checked;
            var chkGarisDatarSelected = chkGarisDatar.Checked;
            var chkGarisPinggirSelected = chkGarisPinggir.Checked;
            var chkWarnaGarisTepi = rbtWarnaGarisTepi.Properties.Items[rbtWarnaGarisTepi.SelectedIndex].Description;
            var chkHideNamaNotarisSelected = chkHideNamaNotaris.Checked;
            var modelSalinanSelected = rbtModel.Properties.Items[rbtModel.SelectedIndex].Description;
            var batasKiriNamaNotarisSelected = txtBatasKiriNamaNotaris.Text;
            var stempelSelected = chkStempel.Checked;
            var capSelected = chkCap.Checked;
            var posisiNomorHalaman = rbtPosisiVertikal.Properties.Items[rbtPosisiVertikal.SelectedIndex].Description;
            var rataPosisiHalaman = rbtPosisiHorisontal.Properties.Items[rbtPosisiHorisontal.SelectedIndex].Description;
            var barisJudul = txtBarisJudul.EditValue.ToString();
            var jumlahHalaman = txtJumlahHalaman.EditValue.ToString();
            var posisiCap = cmbPosisiCapdanStempel.Text;

            //Garis
            var panjangGarisAtas = txtPanjangGrsAts.EditValue.ToString();
            var sudutGarisAtas = txtSudutAts.EditValue.ToString();
            var posisiAtas = txtPosisiAts.EditValue.ToString();

            var panjangGarisBawah = txtPanjangGrsBwh.EditValue.ToString();
            var suduGarisBawah = txtSudutBwh.EditValue.ToString();
            var posisiBawah = txtPosisiBwh.EditValue.ToString();

            //txtNotaris
            var txtNotaris1 = txtNamaNotaris1.Text;
            var txtNotaris2 = txtNamaNotaris2.Text;

            Umum.prosesMinuta(
                prosesAktaValue,
                HideKalimatPenutupAktaSelected,
                bahasaSelected,
                chkGarisDatarSelected,
                chkGarisPinggirSelected,
                chkWarnaGarisTepi,
                chkHideNamaNotarisSelected,
                modelSalinanSelected,
                batasKiriNamaNotarisSelected,
                stempelSelected,
                capSelected,
                posisiNomorHalaman,
                rataPosisiHalaman,
                barisJudul,
                jumlahHalaman,
                posisiCap,
                txtNotaris1,
                txtNotaris2,
                panjangGarisAtas,
                sudutGarisAtas,
                posisiAtas,
                panjangGarisBawah,
                suduGarisBawah,
                posisiBawah
                );
        }

        private void rbtBahasaPilihan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtBahasaPilihan.SelectedIndex == 0) //Indonesia
            {
                txtPenutup1.Text = Fungsi.GetSetting("PenutupINA_1");
                txtPenutup2.Text = Fungsi.GetSetting("PenutupINA_2");
            }
            else
            {
                txtPenutup1.Text = Fungsi.GetSetting("PenutupENG_1");
                txtPenutup2.Text = Fungsi.GetSetting("PenutupENG_2");
            }

            CekKalimatPenutupIsEmpty();
        }

        private void txtNamaNotaris1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNamaNotaris2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPanjangGrsAts_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSudutAts_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPosisiAts_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPanjangGrsBwh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSudutBwh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPosisiBwh_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmProsesSalinan_Load(object sender, EventArgs e)
        {

        }

        private void txtBatasKiriNamaNotaris_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}