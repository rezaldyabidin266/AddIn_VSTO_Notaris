using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing.Imaging;

namespace MyHelper
{

    public static class Fungsi
    {

        #region 'Extension Methode'

        public static bool IsNullOrZero(this object value)
        {
            if (value.IsEmpty()) return true;
            else if (value.GetType() == typeof(int) && value.IsZero()) return true;
            else if (value.GetType() == typeof(decimal) && value.IsZero()) return true;
            else if (value.GetType() == typeof(Double) && value.IsZero()) return true;
            else if (value.GetType() == typeof(DateTime) && value == null) return true;
            else return false;
        }

        public static bool IsZero(this object value)
        {
            bool result;

            if (value.ToDecimal() == 0)
                result = true;
            else
                result = false;

            return result;
        }

        public static bool IsNotZero(this object value)
        {
            bool result;

            if (value.ToInteger() == 0)
                result = false;
            else
                result = true;

            return result;
        }

        public static bool IsEmpty(this object value)
        {
            bool result = true;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                result = true;
            else
                result = false;

            return result;
        }

        public static bool IsNotEmpty(this object value)
        {
            return !IsEmpty(value);
        }

        public static decimal ToDecimal(this object value)
        {
            decimal result;

            try
            {
                result = Convert.ToDecimal(value);
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public static float ToFloat(this object value)
        {
            float result;

            try
            {
                result = Convert.ToSingle(value);
            }
            catch
            {
                result = 0;
            }

            return result;

        }

        public static int ToInteger(this object value)
        {
            int result;

            try
            {
                result = Convert.ToInt32(value);
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public static bool ToBool(this int value)
        {
            if (value == 1)
                return true;
            else
                return false;
        }

        public static int To1(this object value)
        {
            int result;

            try
            {
                result = Convert.ToInt32(value);
                if (result == 0) result = 1;
            }
            catch
            {
                result = 1;
            }

            return result;
        }

        public static string Safe(this object value)
        {
            string result;

            if (value.IsEmpty())
                result = string.Empty;
            else
                result = value.ToString();

            return result;
        }

        public static string Num(this decimal value)
        {
            return value.ToString("#,#0.####");
        }

        public static string Num(this int value)
        {
            return value.ToString("#,#0.####");
        }

        public static string Num0(this decimal value)
        {
            return value.ToString("#,#0");
        }

        public static string Num2(this decimal value)
        {
            return value.ToString("#,#0.##");
        }

        public static int ToGetIntOnly(this string value)
        {
            string returnVal = string.Empty;
            MatchCollection collection = Regex.Matches(value, "\\d+");

            foreach (Match m in collection)
            {
                returnVal += m.ToString();
            }
            return Convert.ToInt32(returnVal);
        }

        public static string ToGetStringOnly(this string value)
        {
            return new String(value.Where(Char.IsLetter).ToArray());
        }

        public static int ToGetId(this string value)
        {
            try
            {
                return Convert.ToInt32(value.Split('{')[1].Split('}')[0].Trim());
            }
            catch
            {
                return 0;
            }
        }

        public static string ToGetIdStr(this string value)
        {
            try
            {
                return value.Split('{')[1].Split('}')[0].Trim();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Left(this string text, int length)
        {
            string result = string.Empty;

            if (text.Length == length)
                result = text;
            else if (text.Length > length)
                result = text.Substring(0, length);
            else if (text.Length < length)
                result = text.PadRight(length);

            return result;
        }

        public static string Right(this string text, int length)
        {
            string result = string.Empty;

            if (text.Length == length)
                result = text;
            else if (text.Length > length)
                result = text.Substring(text.Length - length, length);
            else if (text.Length < length)
                result = text.PadLeft(length);

            return result;
        }

        public static string Center(this string text, int length)
        {
            string result = string.Empty;

            if (text.Length == length)
                result = text;
            else if (text.Length > length)
                result = text.Substring(0, length);
            else if (text.Length < length)
            {
                int space = (length - text.Length) / 2;
                for (int i = 0; i < space; i++)
                    result += " ";
                result += text;
            }

            return result;
        }

        public static string ToUpperFirstLetter(this string value)
        {
            // Test for nothing or empty.
            if (string.IsNullOrEmpty(value))
                return value;
            else
                value = value.ToLower();

            // Convert to character array.
            char[] array = value.ToCharArray();

            // Uppercase first character.
            array[0] = char.ToUpper(array[0]);

            // Return new string.
            return new string(array);

        }

        public static string ToUpperEverySentence(this string Value)
        {
            if (string.IsNullOrEmpty(Value)) return string.Empty;
            Value = Value.ToLower();
            string pattern = "\\b(\\w|['-])+\\b";
            return Regex.Replace(Value, pattern, m => m.Value[0].ToString().ToUpper() + m.Value.Substring(1));
        }

        public static List<string> ToWarp(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();

            string SetFormat = text.Replace(Environment.NewLine, " ");
            List<string> words = SetFormat.Split(' ').ToList();
            List<string> lines = new List<string>();
            string currentline = string.Empty;

            foreach (string currentword in words)
            {
                if ((currentline.Length > maxLength) || ((currentline.Length + currentword.Length + 1) > maxLength))
                {
                    lines.Add(currentline);
                    currentline = "";
                }

                if (currentline.Length > 0)
                    currentline += " " + currentword;
                else
                    currentline += currentword;
            }

            if (currentline.Length > 0) lines.Add(currentline);

            return lines;
        }

        public static string Loop(this string text, int length)
        {
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                result = result + text;
            }

            return result;
        }

        public static decimal ToPembulatan(this decimal value, decimal pembulatan, bool isUp)
        {
            if (isUp)
                return ToUpDecimal(value, pembulatan);
            else
                return ToDownDecimal(value, pembulatan);
        }

        public static decimal ToUpDecimal(this decimal Value, decimal Pembulatan = 0)
        {
            return Math.Ceiling(Value / Pembulatan.To1()) * Pembulatan.To1();
        }

        public static decimal ToDownDecimal(this decimal Value, decimal Pembulatan = 0)
        {
            return Math.Floor(Value / Pembulatan.To1()) * Pembulatan.To1();
        }

        public static System.Drawing.Imaging.ImageFormat GetImageFormat(this Image img)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return System.Drawing.Imaging.ImageFormat.Bmp;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return System.Drawing.Imaging.ImageFormat.Png;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
                return System.Drawing.Imaging.ImageFormat.Emf;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
                return System.Drawing.Imaging.ImageFormat.Exif;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return System.Drawing.Imaging.ImageFormat.Gif;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                return System.Drawing.Imaging.ImageFormat.Icon;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
                return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return System.Drawing.Imaging.ImageFormat.Tiff;
            else
                return System.Drawing.Imaging.ImageFormat.Wmf;
        }

        public static string GetImageExtension(this System.Drawing.Image img)
        {
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                return "jpg";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
                return "bmp";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                return "png";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Emf))
                return "emf";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Exif))
                return "exif";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                return "gif";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
                return "ico";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
                return "bmp";
            if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
                return "tiff";
            else
                return "wmf";
        }

        public static byte[] ImageToByteArray(this Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static byte[] ToByte(this Image MyImage)
        {
            if (MyImage == null) return null;

            MemoryStream mstream = new MemoryStream();
            MyImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] msbytes = new byte[Convert.ToInt32(mstream.Length - 1) + 1];
            mstream.Position = 0;
            mstream.Read(msbytes, 0, Convert.ToInt32(mstream.Length));
            return msbytes;
        }


        public static Image SetSizeImage(Image picImage, MyEnum.SizeGambar sizeGambar)
        {
            Size resizeImage;
            Image result = default(Image);

            if (picImage == null) return null;

            switch (sizeGambar)
            {
                case MyEnum.SizeGambar.Low:
                    resizeImage = new Size(340, 240);
                    result = new Bitmap(picImage, resizeImage);
                    break;
                case MyEnum.SizeGambar.Medium:
                    resizeImage = new Size(480, 800);
                    result = new Bitmap(picImage, resizeImage);
                    break;
                case MyEnum.SizeGambar.High:
                    resizeImage = new Size(800, 600);
                    result = new Bitmap(picImage, resizeImage);
                    break;
                case MyEnum.SizeGambar.Original:
                    result = new Bitmap(picImage);
                    break;
                default:
                    break;
            }

            return result;
        }

        public static Image ToImage(this System.Data.Linq.Binary binary)
        {
            if (binary.IsNullOrZero() || binary.Length == 0) return null;

            using (var gambar = new System.IO.MemoryStream(binary.ToArray()))
            {
                return Image.FromStream(gambar);
            }

        }


        public static void CompressAndSaveImage(Image image, string filename, long quality)
        {
            try
            {
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                image.Save(filename, GetCodecInfo("image/jpeg"), parameters);
            }
            catch { }
        }


        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
                if (encoder.MimeType == mimeType)
                    return encoder;

            throw new ArgumentOutOfRangeException(string.Format("'{0}' not supported", mimeType));
        }

        public static Image ToImageSave(this System.Data.Linq.Binary binary)
        {
            if (binary.IsNullOrZero() || binary.Length == 0) return null;
            try
            {
                GVar.iserror = false;
                Stream gambar = new System.IO.MemoryStream(binary.ToArray());
                return Image.FromStream(gambar);
            }
            catch
            {
                GVar.iserror = true;
                return null;

            }

        }

        public static T[] ToArrayOrNull<T>(this IEnumerable<T> seq)
        {
            var result = seq.ToArray();

            if (result.Length == 0)
                return null;

            return result;
        }

        public static DateTime? ToValidDate(this DateTime value)
        {

            if (value.Year > 1990 && value.Year < 3000)
                return value;
            else
                return null;
        }

        //public static string ToCleanIllegalChar(this string value)
        //{
        //    if (value != null)
        //    {
        //        Regex illegalInFileName = new Regex(@"[\\/:*?""<>|]");
        //        value = illegalInFileName.Replace(value, "");
        //    }

        //    return value;
        //}

        //Another Methode to remove illegalInFileName
        public static Regex illegalInFileName = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))), RegexOptions.Compiled);
        public static string ToRemoveIllegalFileName(this string value)
        {

            return illegalInFileName.Replace(value, "");
        }
        #endregion

        public static void PrintToText(string text)
        {
            PrintToText(text, "print.txt");
        }

        public static void PrintToText(string text, string filename)
        {
            try
            {
                StreamWriter file = new StreamWriter(filename);
                file.WriteLine(text);
                file.Close();
            }
            catch { }
        }

        public static string Line(int length)
        {
            return "-".Loop(length);
        }

        public static string Line2(int length)
        {
            return "=".Loop(length);
        }

        public static void AddLog(DateTime tanggal, string modul, string keterangan)
        {
            try
            {
                using (StreamWriter log = new StreamWriter("log.txt", true))
                {
                    log.WriteLine(String.Format("=> {0:dd/MM/yyyy} - {1} | {2} | {3}", tanggal, tanggal.ToShortTimeString(), modul, keterangan));
                    log.Close();
                }
            }
            catch { }
        }


        public static decimal HitungNominalDisc(decimal Harga, decimal Disc)
        {
            return Harga * Disc / 100;
        }

        public static decimal HargaMarkup(decimal harga, decimal markup)
        {
            return harga * (1 + (markup / 100));
        }

        public static decimal HargaNett(decimal Harga, decimal Disc1, decimal Disc2)
        {
            decimal Disc = SetaraDisc(Disc1, Disc2);
            return Convert.ToDecimal(Harga - (Harga * Disc / 100));
        }

        public static decimal HargaNett(decimal Harga, decimal Disc1, decimal Disc2, decimal disc3)
        {
            decimal Disc12 = SetaraDisc(Disc1, Disc2);
            decimal Disc = SetaraDisc(Disc12, disc3);
            return Convert.ToDecimal(Harga - (Harga * Disc / 100));
        }

        public static decimal SetaraDisc(decimal Disc1, decimal Disc2)
        {
            decimal HslKali = 0;
            decimal HslJml = 0;

            HslJml = Disc1 + Disc2;

            Disc1 = Disc1 / 10;
            Disc2 = Disc2 / 10;
            HslKali = Disc1 * Disc2;

            return HslJml - HslKali;
        }

        public static decimal SetaraDisc(decimal Disc1, decimal Disc2, decimal Disc3)
        {
            decimal Disc12 = SetaraDisc(Disc1, Disc2);
            return SetaraDisc(Disc12, Disc3);
        }

        public static decimal SetaraDisc(decimal Disc1, decimal Disc2, decimal Disc3, decimal DiscCash)
        {
            decimal Disc12 = SetaraDisc(Disc1, Disc2);
            decimal Disc123 = SetaraDisc(Disc12, Disc3);
            return SetaraDisc(Disc123, DiscCash);
        }

        #region 'Terbilang'

        public static string Terbilang(decimal value)
        {
            string[] bilangan = {
                                 "",
                                 "SATU",
                                 "DUA",
                                 "TIGA",
                                 "EMPAT",
                                 "LIMA",
                                 "ENAM",
                                 "TUJUH",
                                 "DELAPAN",
                                 "SEMBILAN",
                                 "SEPULUH",
                                 "SEBELAS"
                                };

            if (value < 12)
            {
                return " " + bilangan[Convert.ToInt32(value)];
            }
            else if (value < 20)
            {
                return Terbilang(value - 10) + " BELAS";
            }
            else if (value < 100)
            {
                return (Terbilang(Math.Floor(value / 10)) + " PULUH") + Terbilang(value % 10);
            }
            else if (value < 200)
            {
                return " SERATUS" + Terbilang(value - 100);
            }
            else if (value < 1000)
            {
                return (Terbilang(Math.Floor(value / 100)) + " RATUS") + Terbilang(value % 100);
            }
            else if (value < 2000)
            {
                return " SERIBU" + Terbilang(value - 1000);
            }
            else if (value < 1000000)
            {
                return (Terbilang(Math.Floor(value / 1000)) + " RIBU") + Terbilang(value % 1000);
            }
            else if (value < 1000000000)
            {
                return (Terbilang(Math.Floor(value / 1000000)) + " JUTA") + Terbilang(value % 1000000);
            }
            else if (value < 1000000000000L)
            {
                return (Terbilang(Math.Floor(value / 1000000000)) + " MILYAR") + Terbilang(value % 1000000000);
            }
            else if (value < 1000000000000000L)
            {
                return (Terbilang(Math.Floor(value / 1000000000000L)) + " TRILYUN") + Terbilang(value % 1000000000000L);
            }
            else
            {
                return "";
            }

        }

        public static string TerbilangRupiah(decimal NilaiTerbilang)
        {
            return (Terbilang(NilaiTerbilang).Replace("  ", " ").Trim()) + " RUPIAH";
        }

        public static string TerbilangRupiahSen(decimal Value, bool IsInfoRupiahSen)
        {

            int Nominal = Convert.ToInt32(Math.Truncate(Value));
            int Point = 0;

            StringBuilder Temp = new StringBuilder();

            if (IsInfoRupiahSen)
                Temp.Append("Rp ");

            try
            {
                Point = Convert.ToInt32(Value.ToString().Split(('.'))[1]);
                if (Point < 10)
                    Point = Point * 10;
                Temp = Temp.Append(string.Format("{0:n2}", Value));
            }
            catch
            {
                Point = 0;
                Temp = Temp.Append(string.Format("{0:n0}", Value));
            }

            if (IsInfoRupiahSen)
                Temp.Append(",-");

            Temp = Temp.Append(" (").Append(Terbilang(Nominal).TrimStart());

            if (IsInfoRupiahSen)
            {
                Temp = Temp.Append(" RUPIAH");
            }

            if (Point != 0)
            {
                Temp = Temp.Append(" KOMA").Append(Terbilang(Point));

                if (IsInfoRupiahSen)
                {
                    Temp = Temp.Append(" SEN");
                }
            }

            Temp = Temp.Append(")");

            return Temp.ToString().ToLower().Replace("  ", " ").Trim().ToUpperFirstLetter();

        }

        public static string TerbilangBulan(int Value)
        {
            string[] Bulan = {
                              " JANUARI",
                              " FEBRUARI",
                              " MARET",
                              " APRIL",
                              " MEI",
                              " JUNI",
                              " JULI",
                              " AGUSTUS",
                              " SEPTEMBER",
                              " OKTOBER",
                              " NOVEMBER",
                              " DESEMBER"
                             };
            return Bulan[Value - 1];
        }

        public static string TerbilangMeterPersegi(decimal Value)
        {
            // Math.Truncate / Math.Floor
            // decimalNumber = -32.9012m;
            // Displays -32   
            Value = Math.Truncate(Value);
            StringBuilder Temp = new StringBuilder();
            Temp = Temp.Append(string.Format("{0:n0}", Value)).Append(" M2 (").Append(Terbilang(Convert.ToInt64(Value)).Trim()).Append(" Meter Persegi)");
            return Temp.ToString().ToLower();
        }

        public static string TerbilangTgl(DateTime Tgl, bool IsPpat)
        {
            StringBuilder Temp = new StringBuilder();

            string Tanggal = Terbilang(Tgl.Day).Trim();
            string Bulan = TerbilangBulan(Tgl.Month).Trim();
            string Tahun = Terbilang(Tgl.Year).Trim();

            if (IsPpat)
                Temp = Temp.Append(Tgl.Day).Append(" (").Append(Tanggal).Append(") ").Append(Bulan).Append(" ").Append(Tgl.Year).Append(" (").Append(Tahun).Append(")");
            else
                Temp = Temp.Append(Tanggal).Append(" ").Append(Bulan).Append(" ").Append(Tahun);

            Temp = Temp.Append(" ");
            return Temp.ToString().ToLower().ToUpperFirstLetter();
        }


        public static string ConvertDayName(string dayEng)
        {
            switch (dayEng)
            {
                case "Mon":
                    return "Senin";
                case "Tue":
                    return "Senin";
                case "Wed":
                    return "Senin";
                case "Thu":
                    return "Senin";
                case "Fri":
                    return "Senin";
                case "Sat":
                    return "Senin";
                case "Sun":
                    return "Senin";
                default:
                    return string.Empty;
            }


        }


        public enum infotime
        {
            WIB,
            WITA,
            WIT,
        };

        public static string TerbilangJam(TimeSpan Waktu, infotime Info)
        {

            StringBuilder Temp = new StringBuilder();

            string Jam = Terbilang(Waktu.Hours).Trim();
            string Menit = Terbilang(Waktu.Minutes).Trim();
            string Detik = Terbilang(Waktu.Seconds).Trim();

            if (string.IsNullOrEmpty(Jam))
                Jam = "Nol";

            Temp = Temp.Append("(Pukul ").Append(Jam);

            if (!string.IsNullOrEmpty(Menit))
            {
                Temp = Temp.Append(" Lewat ").Append(Menit).Append(" Menit");
            }

            //if (!string.IsNullOrEmpty(Detik))

            switch (Info)
            {
                case infotime.WIB:
                    Temp = Temp.Append(" Waktu Indonesia Barat");
                    break;
                case infotime.WITA:
                    Temp = Temp.Append(" Waktu Indonesia Tengah");
                    break;
                case infotime.WIT:
                    Temp = Temp.Append(" Waktu Indonesia Timur");
                    break;
            }

            Temp = Temp.Append(") ");

            return Temp.ToString().ToLower().ToUpperFirstLetter();

        }

        #endregion

        public static List<string> GetPortNames()
        {
            return SerialPort.GetPortNames().ToList();
        }

        public static DateTime GetServerTime()
        {
            //1 ambil waktu dari server data yang aktifKD
            string ConServerAktiv = GVar.conData;

            //2 bila server data kosong maka ambil dari login aktif
            if (string.IsNullOrEmpty(ConServerAktiv))
            {
                ConServerAktiv = GVar.conLogin;
            }

            DataContext db = new DataContext(ConServerAktiv);
            IEnumerable<DateTime> result = (System.Collections.Generic.IEnumerable<DateTime>)db.ExecuteQuery(typeof(DateTime), "SELECT GETDATE() AS CurrentSQLDateTime");

            return result.FirstOrDefault();
        }

        public static void SetCreate(object obj, string AddInfoUser = "")
        {
            var usercreate = obj.GetType().GetProperty("UserCreate");
            var datecreate = obj.GetType().GetProperty("DateCreate");

            string UserId = GVar.loginUsername;
            if (!string.IsNullOrEmpty(AddInfoUser))
            {
                UserId = UserId + " " + AddInfoUser;
            }

            if (usercreate != null & usercreate.CanWrite)
                usercreate.SetValue(obj, UserId, null);
            if (datecreate != null & datecreate.CanWrite)
                datecreate.SetValue(obj, GetServerTime(), null);
        }

        public static void SetUpdate(object obj, string AddInfoUser = "")
        {
            var userupdate = obj.GetType().GetProperty("UserUpdate");
            var dateupdate = obj.GetType().GetProperty("DateUpdate");

            string UserId = MyHelper.GVar.loginUsername;
            if (!string.IsNullOrEmpty(AddInfoUser))
            {
                UserId = UserId + " " + AddInfoUser;
            }

            if (userupdate != null & userupdate.CanWrite)
                userupdate.SetValue(obj, UserId, null);
            if (dateupdate != null & dateupdate.CanWrite)
                dateupdate.SetValue(obj, GetServerTime(), null);
        }

        public static void SetCreateUpdate(object obj, string AddInfoUser = "")
        {
            SetCreate(obj, AddInfoUser);
            SetUpdate(obj, AddInfoUser);
        }

        #region setting program

        private static void CheckSetting(string namaFile, string path = null)
        {
            if (!System.IO.File.Exists(path + namaFile))
            {
                if (!string.IsNullOrEmpty(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                System.IO.File.Create(path + namaFile);
            }
        }

        public static string GetSetting(string key, string path = null, string namaFile = "D:\\setting_apk_notaris.txt") //@"\setting_apk_notaris.txt"
        {
            string result = string.Empty;
            try
            {
                CheckSetting(namaFile,path);
                using (StreamReader file = new StreamReader(path + namaFile))
                {
                    string line = string.Empty;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("="))
                        {
                            var split = line.Split('=');
                            if (split.GetValue(0).ToString() == key) result = split.GetValue(1).ToString();
                        }

                    }
                }
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }
        public static void SetSetting(string key, string value, string path = null, string namaFile = "D:\\setting_apk_notaris.txt" ) //@"\setting_apk_notaris.txt"
        {
            CheckSetting(namaFile);
            StreamReader fileread = new StreamReader(path + namaFile);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string line = string.Empty;
            while ((line = fileread.ReadLine()) != null)
            {
                var split = line.Split('=');
                dictionary.Add(split.GetValue(0).ToString(), split.GetValue(1).ToString());
            }

            fileread.Close();

            if (dictionary.Any(x => x.Key == key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);


            StreamWriter filewrite = new StreamWriter(path + namaFile, false);
            foreach (var item in dictionary)
                filewrite.WriteLine(item.Key + "=" + item.Value);

            filewrite.Close();
        }


        #endregion

        #region Waktu

        public static string HitungWaktu(System.DateTime TglAwal, bool ShowDay = false)
        {
            return HitungWaktu(TglAwal, System.DateTime.Today, ShowDay);
        }

        public static string HitungWaktu(System.DateTime TglAwal, System.DateTime TglAkhir, bool ShowDay = false)
        {
            try
            {
                TimeSpan JarakWaktu = TglAkhir.Date - TglAwal.Date;
                System.DateTime Umur = System.DateTime.MinValue + JarakWaktu;

                int Tahun = Umur.Year - 1;
                int bulan = Umur.Month - 1;
                int Hari = Umur.Day - 1;

                if (ShowDay == true)
                {
                    if (Tahun == 0)
                    {
                        if (bulan == 0)
                            return Hari + " HR";
                        else
                            return bulan + " BLN | " + Hari + " HR";
                    }
                    else
                        return Tahun + " THN | " + bulan + " BLN | " + Hari + " HR";
                }
                else
                {
                    if (Tahun == 0)
                    {
                        if (bulan == 0)
                            return Hari + " HR";
                        else
                            return bulan + " BLN | " + Hari + " HR";
                    }
                    else
                        return Tahun + " THN " + bulan + " BLN";
                }
            }
            catch
            {
                return "---";
            }
        }

        public static string TotalWaktu(DateTime Awal, DateTime Akhir)
        {
            TimeSpan Value = default(TimeSpan);
            Value = Akhir - Awal;
            return TotalWaktu(Value);
        }

        public static string TotalWaktu(System.TimeSpan Detik)
        {
            var Hari = Detik.Days;
            var Jam = Detik.Hours;
            var Min = Detik.Minutes;
            var Sec = Detik.Seconds;

            if (Hari == 0)
                return Jam + ":" + Min.ToString("00") + ":" + Sec.ToString("00");
            else
                return Hari + ".D " + Jam + ":" + Min.ToString("00") + ":" + Sec.ToString("00");
        }

        public static int AmbilBulan(System.DateTime Tgl)
        {
            return AmbilBulan(Tgl, System.DateTime.Now);
        }

        public static int AmbilBulan(System.DateTime TglAwal, System.DateTime TglAkhir)
        {
            var Waktu = TglAkhir - TglAwal;
            var Umur = System.DateTime.MinValue + Waktu;
            return Umur.Month - 1;
        }

        public static System.DateTime IsiTgl(int Tahun, int Bulan, int Hari, int Jam, int Menit, int Detik)
        {
            return new System.DateTime(Tahun, Bulan, Hari, Jam, Menit, Detik);
        }

        public static string CekPagiSiangMalam(int Jam)
        {

            switch (Jam)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    return "SUBUH";
                case 6:
                case 7:
                case 8:
                case 9:
                    return "PAGI";
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    return "SIANG";
                case 15:
                case 16:
                case 17:
                case 18:
                    return "SORE";
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    return "MALAM";
                default:
                    return "JAM OVERLOAD SALAH CODE HUB MARTIN : 0815-8899672";
            }

        }

        public static DateTime GetFirstDayOfMonth(DateTime dtDate)
        {
            DateTime dtFrom = dtDate;
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
            return dtFrom;
        }

        public static DateTime GetLastDayOfMonth(DateTime dtDate)
        {
            DateTime dtTo = new DateTime(dtDate.Year, dtDate.Month, 1);
            dtTo = dtTo.AddMonths(1);
            dtTo = dtTo.AddDays(-(dtTo.Day));
            return dtTo;
        }

        public static DateTime GetFirstDateOfWeek(DateTime dtDate)
        {
            int delta = DayOfWeek.Monday - dtDate.DayOfWeek;
            return dtDate.AddDays(delta);
        } // Start Monday

        public static DateTime GetLastDateOfWeek(DateTime dtDate)
        {
            int delta = DayOfWeek.Monday - dtDate.DayOfWeek + 6;
            return dtDate.AddDays(delta);
        } // End Sunday

        public static DateTime WeekStart(DateTime dtDate)
        {
            return dtDate.AddDays(-(int)dtDate.DayOfWeek);
        } // Start Sunday

        public static DateTime WeekEnd(DateTime dtDate)
        {
            return WeekStart(dtDate).AddDays(7).AddSeconds(-1);
        } // End Saturday


        #region Absen hitung Selasa bayar ke senin
        public static DateTime WeekStartTuesday(DateTime dtDate)
        {
            int delta = DayOfWeek.Tuesday - dtDate.DayOfWeek;
            return dtDate.AddDays(delta);
        } // Start Tuesday

        public static DateTime WeekEndMonday(DateTime dtDate)
        {
            return WeekStartTuesday(dtDate).AddDays(7).AddSeconds(-1);
        } // End Monday
        #endregion

        public static DateTime Yesterday()
        {
            return DateTime.Today.AddDays(-1);
        }

        public static DateTime LastWeekStart(DateTime dtDate)
        {
            return WeekStart(dtDate).AddDays(-7);
        }

        public static int LastMonth()
        {
            int month = DateTime.Today.Month;
            if (month == 1) return 12;
            else return month - 1;
        }

        public static int LastMonthYear()
        {
            int month = DateTime.Today.Month;
            if (month == 1) return DateTime.Today.Year - 1;
            else return DateTime.Today.Year;
        }

        public static int LastYear()
        {
            return DateTime.Today.Year - 1;
        }

        public static DateTime LastWeekEnd(DateTime dtDate)
        {
            return WeekStart(dtDate).AddSeconds(-1);
        }

        public static string GetWeekInMonthAndYear(this DateTime date)
        {
            DateTime tempdate = date.AddDays(-date.Day + 1);

            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNumStart = ciCurr.Calendar.GetWeekOfYear(tempdate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int weekInMonth = weekNum - weekNumStart + 1;
            return "M" + weekInMonth + "/" + date.Month + "/" + date.Year;
        }

        public static int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            return (date - firstMonthMonday).Days / 7 + 1;
        }

        public static int MondaysInMonth(DateTime thisMonth)
        {
            int mondays = 0;
            int month = thisMonth.Month;
            int year = thisMonth.Year;
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                    mondays++;
            return mondays;
        }

        public static int SaturdayInMonth(DateTime thisMonth)
        {
            int saturday = 0;
            int month = thisMonth.Month;
            int year = thisMonth.Year;
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                    saturday++;
            return saturday;
        }

        public static DateTime FirstDateOfWeekISO8601Monday(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Thursday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        public static DateTime FirstDateOfWeekISO8601Saturday(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Saturday - jan1.DayOfWeek;

            DateTime firstSaturday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstSaturday, CalendarWeekRule.FirstFullWeek, DayOfWeek.Saturday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstSaturday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }


        public static void GetTglSeminggu(DateTime tgl, out DateTime tglAwal, out DateTime tglAkhir)
        {
            tglAwal = GetFirstDateOfWeek(tgl);
            tglAkhir = GetLastDateOfWeek(tgl);
        }

        public static void GetTglSeminggu(int tahun, int bulan, int mingguke, out DateTime tglAwal, out DateTime tglAkhir)
        {
            int jmlMinggu = 0;
            DateTime tglSementara;

            for (int i = 1; i < bulan; i++)
            {
                tglSementara = new DateTime(tahun, i, 1);
                jmlMinggu += SaturdayInMonth(tglSementara);
            }

            jmlMinggu = jmlMinggu + mingguke;
            DateTime tgl = FirstDateOfWeekISO8601Saturday(tahun, jmlMinggu);

            tglAwal = WeekStart(tgl);
            tglAkhir = WeekEnd(tgl);
        }


        public static void GetTglSemingguSelasaKeSenin(int tahun, int bulan, int mingguke, out DateTime tglAwal, out DateTime tglAkhir)
        {
            int jmlMinggu = 0;
            DateTime tglSementara;

            for (int i = 1; i < bulan; i++)
            {
                tglSementara = new DateTime(tahun, i, 1);
                jmlMinggu += SaturdayInMonth(tglSementara);
            }

            jmlMinggu = jmlMinggu + mingguke;
            DateTime tgl = FirstDateOfWeekISO8601Saturday(tahun, jmlMinggu);

            tglAwal = WeekStartTuesday(tgl);
            tglAkhir = WeekEndMonday(tgl);
        }



        //static GregorianCalendar _gc = new GregorianCalendar();
        //public static int GetWeekOfMonth(this DateTime time)
        //{
        //    DateTime first = new DateTime(time.Year, time.Month, 1);
        //    return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        //}

        //static int GetWeekOfYear(this DateTime time)
        //{
        //    return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        //}


        #endregion


    }
}
