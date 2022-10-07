using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotarisWordAddIn2019
{
   public class SettingEnum
    {
        public enum WarnaGaris
        {
            Hitam = 0,
            Biru = 1,
            Merah = 2,
        }

        public enum PosisiVertikalNomorHalaman
        {
            Bawah = 0,
            Atas = 1,
            TanpaNomer = 2,
        }

        public enum PosisiHorisontalNomorHalaman
        {
            RataTengah = 0,
            RataKanan = 1,
        }

        public enum ModelSalinan
        {
            Model1 = 0,
            Model2 = 1,
        }

        public enum ProsesAkta
        {
            Minuta = 0,
            Salinan = 1,
            PPAT = 2,
        }

        public enum Bahasa
        {
            Indonesia = 0,
            Inggris = 1,
        }
    }
}
