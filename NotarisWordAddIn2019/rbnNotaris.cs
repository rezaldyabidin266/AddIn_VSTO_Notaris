using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using MyHelper;

namespace NotarisWordAddIn2019
{
    public partial class rbnNotaris
    {
        private void btnNominal_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmNominal));
        }
        private void btnTanggal_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmTanggal));
        }

        private void btnRapihkan_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmHapus));
        }

        private void btnAkta_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmSettingAkta));
        }

        private void btnWaktu_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmWaktu));
        }

        private void btnSalinan_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmProsesSalinan));
        }

        private void btnHelp_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmHelp));
        }

        private void btnGaris1baris_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.GarisSebaris();
        }

        private void btnUpline_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.Upline(Umum.warnaGarisTepi, Umum.panjangGarisAtas, Umum.sudutGarisAtas, Umum.posisiGarisAtas);
        }

        private void btnVertikalline_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.GarisVertikal(Umum.warnaGarisTepi);
        }

        private void btnDownline_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.Downline(Umum.warnaGarisTepi, Umum.panjangGarisBawah, Umum.sudutGarisBawah, Umum.posisiGarisBawah);
        }

        private void btnHorisontalline_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.GarisStripSeluruhAkta();
        }

        private void btnSettingfontall_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.SettingAkta();
        }

        private void btnPrinterDialogs_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmPrinter));
        }

        private void btnPrintTest_Click_1(object sender, RibbonControlEventArgs e)
        {
            Umum.PrintDocTest();
        }

        private void btnPrinter_Click_1(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmSettingPrinter));
        }

        private void btnTextSesuaiCursor_Click(object sender, RibbonControlEventArgs e)
        {
            Umum.AddTextAwalCursor();
        }

        private void btnGetTextSelect_Click_1(object sender, RibbonControlEventArgs e)
        {
            Umum.GetTextSesuaiSelect();
        }

        private void btnGarisAtasTegaskBawah_Click_1(object sender, RibbonControlEventArgs e)
        {
            Umum.GarisDatarTegakBawah();
        }

        private void btnPrintDialogs_Click_1(object sender, RibbonControlEventArgs e)
        {
            Umum.PrintDocDialogs();
        }

        private void btnSettingStempel_Click(object sender, RibbonControlEventArgs e)
        {
            MyForm.ShowDialogForm(typeof(frmSettingStempel));
        }
    }
}
