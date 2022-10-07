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
using System.Drawing.Printing;

namespace NotarisWordAddIn2019
{
    public partial class frmSettingPrinter : DevExpress.XtraEditors.XtraForm
    {
        public frmSettingPrinter()
        {
            InitializeComponent();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {

                cmbListPrinter.Properties.Items.Add(printer);

            }
            GetSetting();
        }


   
        private void GetSetting()
        {
            //Printer
            cmbListPrinter.Text = Fungsi.GetSetting("ListPrinter", GVar.myPath);
            cmbTypePrinter.Text = Fungsi.GetSetting("TypePrinter", GVar.myPath);

            //Kertas
            cmbUkuranKertas.Text = Fungsi.GetSetting("UkuranKertas", GVar.myPath);
            txtPanjangKertas.EditValue = Fungsi.GetSetting("PanjangKertas", GVar.myPath).ToFloat();
            txtLebarKertas.EditValue = Fungsi.GetSetting("LebarKertas", GVar.myPath).ToFloat();

            //Informasi
            txtJmlHalaman.EditValue = Fungsi.GetSetting("JumlahHalaman", GVar.myPath).ToFloat();
            txtJmlKertas.EditValue = Fungsi.GetSetting("JumlahKertas", GVar.myPath).ToFloat();

            //Print Section
            chkCetakSisiAtas.Checked = Fungsi.GetSetting("CetakSisiAtas", GVar.myPath).IsEmpty();
            chkCetakSisiBawah.Checked = Fungsi.GetSetting("CetakSisiBawah", GVar.myPath).IsEmpty();

            //Print Opsi
            cmbPrintOpsi.Text = Fungsi.GetSetting("PrintOpsi", GVar.myPath);
            txtPage1.EditValue = Fungsi.GetSetting("Page1", GVar.myPath).ToFloat();
            txtPage2.EditValue = Fungsi.GetSetting("Page2", GVar.myPath).ToFloat();
            txtManual.EditValue = Fungsi.GetSetting("Manual", GVar.myPath).ToFloat();
        }
        public void SaveSetting()
        {
            //Printer
            Fungsi.SetSetting("ListPrinter", cmbListPrinter.Text, GVar.myPath);
            Fungsi.SetSetting("TypePrinter", cmbTypePrinter.Text, GVar.myPath);

            //Kertas
            Fungsi.SetSetting("UkuranKertas", cmbUkuranKertas.Text, GVar.myPath);
            Fungsi.SetSetting("PanjangKertas", txtPanjangKertas.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("LebarKertas", txtLebarKertas.EditValue.ToString(), GVar.myPath);

            //Informasi
            Fungsi.SetSetting("JumlahHalaman", txtJmlHalaman.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("JumlahKertas", txtJmlKertas.EditValue.ToString(), GVar.myPath);

            //Print Section
            Fungsi.SetSetting("CetakSisiAtas", chkCetakSisiAtas.IsEmpty().ToString(), GVar.myPath);
            Fungsi.SetSetting("CetakSisiBawah", chkCetakSisiBawah.IsEmpty().ToString(), GVar.myPath);

            //Print Opsi
            Fungsi.SetSetting("PrintOpsi", cmbPrintOpsi.Text, GVar.myPath);
            Fungsi.SetSetting("Page1", txtPage1.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("Page2", txtPage2.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("Manual", txtManual.EditValue.ToString(), GVar.myPath);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.ShowDialog();
           
        }

        private void cmbUkuranKertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Private Sub CmbKertas_Change()
            //Select Case CmbKertas
            //    Case "A3 29.7x42 cm"
            //TxtLebar.Value = 16839
            //TxtPanjang.Value = 23814
            //Case "A3+ 29.7x43 cm"
            //TxtLebar.Value = 16840
            //TxtPanjang.Value = 24381
            //End Select

            //End Sub
        }

        private void cmbListPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

            //chkSide1 = sisi atas
            //chkSide2 = sisi bawah
            //Private Sub CmbPrinter_Change()
            //Select Case CmbPrinter
            //    Case "Dot Matrix/Duplex"
            //Print_Section.Enabled = False
            //    ChkSide1.Value = False
            //    ChkSide2.Value = False
            //    LblStatus.Caption = "Jenis printer Dot Matrix atau printer laser yg mempunyai fasilitas duplex, Contoh Dot Matrix : printer Epson LQ-2180 atau Epson LQ-2170, Contoh LaserJet: Xerox DP 2065, Xerox DP 3035, HP 8150 ND"
            //Case "LaserJet/DeskJet [Depan]"
            //Print_Section.Enabled = True
            //    ChkSide1.Value = True
            //    ChkSide2.Value = False
            //    LblStatus.Caption = "Jenis Printer DeskJet atau LaserJet yang dapat menggunakan Kertas A3 dan posisi penyimpan kertas di Depan Printer, Contoh: HP DeskJet 7100, HP DeskJet 1280"
            //Case "LaserJet/DeskJet [Belakang]"
            //Print_Section.Enabled = True
            //    ChkSide1.Value = True
            //    ChkSide2.Value = False
            //    LblStatus.Caption = "Jenis Printer DeskJet atau LaserJet yang dapat menggunakan Kertas A3 dan posisi penyimpan kertas di Belakang Printer, Contoh: Canon iX4000, Epson Stylus Photo 1390"
            //End Select
            //End Sub
        }





    }
}