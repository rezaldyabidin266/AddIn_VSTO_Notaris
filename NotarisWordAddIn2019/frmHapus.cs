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

namespace NotarisWordAddIn2019
{
    public partial class frmHapus : DevExpress.XtraEditors.XtraForm
    {
        public frmHapus()
        {
            InitializeComponent();
        }

        private void btnHapusSisaBarisKosong_Click(object sender, EventArgs e)
        {
            Umum.DeleteBarisKosongDiAkhir();
            this.Close();
        }

        private void btnHapusGarisDatar_Click(object sender, EventArgs e)
        {
            Umum.DeleteBarisDatar();
            this.Close();
        }

        private void btnHapusGarisPinggir_Click(object sender, EventArgs e)
        {
            Umum.DeleteGarisPinggir();
            this.Close();
        }

        private void btnHapusGrsDatardanPinggir_Click(object sender, EventArgs e)
        {
            Umum.DeleteGarisPinggirAndGarisDatar();
            this.Close();
        }

        private void btnHapusTrackChanges_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHapusGarisAtas_Click(object sender, EventArgs e)
        {
            Umum.DeleteGarisAtas();
            this.Close();
        }

        private void btnGarisBawah_Click(object sender, EventArgs e)
        {
            Umum.DeleteGarisBawah();
            this.Close();
        }
    }
}