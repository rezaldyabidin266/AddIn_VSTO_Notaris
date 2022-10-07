using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHelper
{
    public class MyEnum
    {

        public enum cashDrawer
        {
            Kredit = 0,
            Debet = 1,
            Jual = 2,
            Retur = 3,
        }

        public enum OpenDrawer
        {
            Manual = 0,
            Button = 1,
            Transaction = 2,
        }

        public enum TglHistory
        {
            Semua = 0,
            Hari_ini = 1,
            Minggu_ini = 2,
            Last_2Weeks = 3,
            Bulan_ini = 4,
        }

        public enum SizeGambar
        {
            Low = 0,
            Medium = 1,
            High = 2,
            Original = 3
        }


        public enum StatePole
        {
            PilihItem,
            Subtotal,
            Kembalian,
            Iklan,
            Tunda,
            DineIn,
            None,
        }

        public enum JenisKelamin
        {
            Pria = 0,
            Wanita = 1,
        }

        public enum WargaNegara
        {
            WNI = 0,
            WNA =1,
        }

        public enum NamaKas
        {
            KasKecil,
            KasBox,
        }       
    }
}
