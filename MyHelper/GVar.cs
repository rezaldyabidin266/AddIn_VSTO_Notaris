using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHelper
{
    public class GVar
    {
        //Connection Data
        public static string conData;
        public static string conLogin;
        public static string conSDM;
        public static string conSMS;
     
        //No Registrasi
        public static string serial;
        public static string version;
        public static string activation;

        public static string loginUsername;
        //Kode UserId Login
        public static string loginUserId;
        //Kode Group Login
        public static string loginGroupId;
        public static string loginGroupName;
        public static int levelGroup;
        public static string loginPassword;

        public static string skinProg = "iMaginary";
        //Nama Applikasi Utama
        public static string namaAppUtama;
        public static string comDisplay;
        public static string printerKasir;
        public static string printerDapur;
        public static string printerAgen;
        public static string printerResep;
        public static string cpuName;
        public static string DrawerId;
        public static int jmlCharPrinterKasir;

        //Setting Tambahan
        public static string NamaToko;
        public static string AlamatToko;
        public static string TlpToko;
        public static string FooterToko;
        public static string MethodePrintSetoran;

        //Setting Tambahan Sisfo Apotik
        public static string Footer1;
        public static string Footer2;
        public static string Apoteker;
        public static string SIPA;

        public static string NamaAgen;
        public static string AlamatAgen;
        public static string TlpAgen;
        public static string FaxAgen;
        public static string FooterAgen;

        public static decimal chargeCr;
        public static int stockAgen;
        public static int stockRusak;
        public static int stockKeliling; // Untuk Kelilingan Agen
        public static int stockKasir; // Untuk Transaksi Kasir
        public static int stockGudang; // Untuk Software Apotik Stock Gudang

        public static bool isOutsider = false;
        public static bool isConStringSave = false;

        public static bool isLogin = false;
        public static bool isDataCon = false;
        
        public static bool iserror = false;

        //Setting Tampilan
        public static bool isKeyMap = false;

        public static string myPath = null;
    }
}
