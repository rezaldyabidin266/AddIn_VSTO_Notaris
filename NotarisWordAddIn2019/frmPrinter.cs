using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Word;
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
    public partial class frmPrinter : DevExpress.XtraEditors.XtraForm
    {

        private static Document _myDocument = Globals.ThisAddIn.Application.ActiveDocument;
        private static Window _myWindow = Globals.ThisAddIn.Application.ActiveWindow;
        private static Microsoft.Office.Interop.Word.Selection _mySelection = Globals.ThisAddIn.Application.Selection;
        private static Dialogs _Dialogs = Globals.ThisAddIn.Application.Dialogs;

        public frmPrinter()
        {
            InitializeComponent();

            GetSetting();
            txtJmlHalaman.EditValue = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //Jumlah Halaman
            txtJmlKertas.EditValue = txtJmlHalaman.EditValue.ToInteger() / 4; //Jumlah Kertas
        }
        private void GetSetting()
        {

        }

        public void SaveSetting()
        {

            //Informasi
            Fungsi.SetSetting("JumlahHalaman", txtJmlHalaman.EditValue.ToString(), GVar.myPath);
            Fungsi.SetSetting("JumlahKertas", txtJmlKertas.EditValue.ToString(), GVar.myPath);

        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            Close();
            Umum.PrintDocDialogs();
        }

        private void txtJmlKertas_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}