using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using MyHelper;
using System.IO;
using DevExpress.Entity.Model;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraRichEdit.API.Native.Implementation;
using DevExpress.Utils.Html.Internal;
using DevExpress.XtraPrinting.Native;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using static NotarisWordAddIn2019.SettingEnum;
using DevExpress.Pdf;
using DevExpress.XtraRichEdit.Model;
using static DevExpress.Office.PInvoke.Win32;
using System.Security.Cryptography;

namespace NotarisWordAddIn2019
{
    internal static class Umum
    {

        private static Document _myDocument = Globals.ThisAddIn.Application.ActiveDocument;
        private static Window _myWindow = Globals.ThisAddIn.Application.ActiveWindow;
        private static Microsoft.Office.Interop.Word.Selection _mySelection = Globals.ThisAddIn.Application.Selection;
        private static Dialogs _Dialogs = Globals.ThisAddIn.Application.Dialogs;

        //Margin
        public static float marginKiri;
        public static float marginKanan;
        public static float marginAtas;
        public static float marginBawah;

        //Kertas
        public static string ukuranKertas;
        public static float panjangKertas;
        public static float lebarKertas;
        public static bool isHapusBarisKosong;

        //Huruf
        public static string fontName;
        public static float fontSize;
        public static float fontPosisi;

        //Garis Shape Atas
        public static string warnaGarisTepi;
        public static float panjangGarisAtas;
        public static float sudutGarisAtas;
        public static float posisiGarisAtas;

        //Garis Shape Bawah
        public static float panjangGarisBawah;
        public static float sudutGarisBawah;
        public static float posisiGarisBawah;

        //KalimatPenutup
        public static string bahasaPenutup;
        public static string penutupINA_1;
        public static string penutupINA_2;
        public static string penutupENG_1;
        public static string penutupENG_2;

        //NamaNotaris
        public static string namaNotaris1;
        public static string namaNotaris2;

        //Other
        public static string prosesAkta;
        public static string nomorVertikalHalaman;
        public static string nomorHorisontalHalaman;
        public static string modelSalinan;
        public static bool hideNamaNotaris;
        public static string batasKiriNamaNotaris;

        //Var Local
        public static int jmlbrs;
        public static string txtSelect;
        public static bool varCapSelected;
        public static string varPosisiNomorHalaman;
        public static string varRataPosisiHalaman;
        public static string varJumlahHalaman;
        public static string varBarisJudul;
        public static string varPosisiCap;
        public static string pathCap;
        public static string pathStempel;

        public static float naikBaris;
        public static float batasMarginAtas;
        public static float batasMarginKiri;
        public static float panjangStempel;
        public static float lebarStempel;

        public static void CekSettingTextFile()
        {
            GVar.myPath = Directory.GetCurrentDirectory();
        }

        public static void GetSetting()
        {
            //Margin
            marginKiri = Fungsi.GetSetting("MarginKiri", GVar.myPath).ToFloat();
            marginKanan = Fungsi.GetSetting("MarginKanan", GVar.myPath).ToFloat();
            marginAtas = Fungsi.GetSetting("MarginAtas", GVar.myPath).ToFloat();
            marginBawah = Fungsi.GetSetting("MarginBawah", GVar.myPath).ToFloat();

            //Kertas
            ukuranKertas = Fungsi.GetSetting("UkuranKertas", GVar.myPath);
            panjangKertas = Fungsi.GetSetting("PanjangKertas", GVar.myPath).ToFloat();
            lebarKertas = Fungsi.GetSetting("LebarKertas", GVar.myPath).ToFloat();
            isHapusBarisKosong = Fungsi.GetSetting("IsHapusBarisKosong", GVar.myPath).IsEmpty();

            //Huruf
            fontName = Fungsi.GetSetting("FontName", GVar.myPath);
            fontSize = Fungsi.GetSetting("FontSize", GVar.myPath).ToFloat();
            fontPosisi = Fungsi.GetSetting("PosisiHuruf", GVar.myPath).ToFloat();

            //Garis Shape Atas
            warnaGarisTepi = Fungsi.GetSetting("WarnaGaris", GVar.myPath);
            panjangGarisAtas = Fungsi.GetSetting("PanjangGarisAtasCm", GVar.myPath).ToFloat().ToPoint();
            sudutGarisAtas = Fungsi.GetSetting("SudutGarisAtasPts", GVar.myPath).ToFloat();
            posisiGarisAtas = Fungsi.GetSetting("PosisiGarisAtasPts", GVar.myPath).ToFloat();

            //Garis Shape Bawah
            panjangGarisBawah = Fungsi.GetSetting("PanjangGarisBawahCm", GVar.myPath).ToFloat().ToPoint();
            sudutGarisBawah = Fungsi.GetSetting("SudutGarisBawahPts", GVar.myPath).ToFloat();
            posisiGarisBawah = Fungsi.GetSetting("PosisiGarisBawahPts", GVar.myPath).ToFloat();

            //KalimatPenutup
            bahasaPenutup = Fungsi.GetSetting("BahasaPenutup", GVar.myPath);
            penutupINA_1 = Fungsi.GetSetting("PenutupINA_1", GVar.myPath);
            penutupINA_2 = Fungsi.GetSetting("PenutupINA_2", GVar.myPath);
            penutupENG_1 = Fungsi.GetSetting("PenutupENG_1", GVar.myPath);
            penutupENG_2 = Fungsi.GetSetting("PenutupENG_2", GVar.myPath);

            //NamaNotaris
            namaNotaris1 = Fungsi.GetSetting("NamaNotaris1", GVar.myPath);
            namaNotaris2 = Fungsi.GetSetting("NamaNotaris2", GVar.myPath);

            //Cap & Stempel
            pathCap = Fungsi.GetSetting("pathFileCap", GVar.myPath);
            pathStempel = Fungsi.GetSetting("pathFileStempel", GVar.myPath);

            //Posisi Stempel
            naikBaris = Fungsi.GetSetting("NaikBaris", GVar.myPath).ToFloat();

            //Batas Margin Stempel
            batasMarginAtas = Fungsi.GetSetting("BatasMarginAtas", GVar.myPath).ToFloat();
            batasMarginKiri = Fungsi.GetSetting("BatasMarginKiri", GVar.myPath).ToFloat();

            //Ukuran Stempel
            panjangStempel = Fungsi.GetSetting("PanjangStempel", GVar.myPath).ToFloat();
            lebarStempel = Fungsi.GetSetting("LebarStempel", GVar.myPath).ToFloat();

            //Other
            prosesAkta = Fungsi.GetSetting("ProsesAkta", GVar.myPath);
            nomorVertikalHalaman = Fungsi.GetSetting("PosisiVertikalNoHalaman", GVar.myPath);
            nomorHorisontalHalaman = Fungsi.GetSetting("PosisiHorisontalNoHalaman", GVar.myPath);
            modelSalinan = Fungsi.GetSetting("ModelSalinan", GVar.myPath);
            hideNamaNotaris = Fungsi.GetSetting("HideNamaNotaris", GVar.myPath).ToInteger().ToBool();
            batasKiriNamaNotaris = Fungsi.GetSetting("BatasKiriNamaNotaris", GVar.myPath);

        }

        public static void Test()
        {
            //GarisHorisontal();
            //GarisStripSeluruhAkta();
        }

        public static void Upline(
            string warnaGaris,
            float panjangGaris,
            float sudut,
            float posisi)
        {
            // 1  point = 20 twips
            // 72 Point = 1 Inch

            if (panjangGaris == 0) panjangGaris = 72;
            if (sudut == 0) sudut = 3;
            if (posisi == 0) posisi = 5;

            float leftMargin = _mySelection.Information[WdInformation.wdHorizontalPositionRelativeToPage]; //Panjang X Dari Tepi Kiri Ke Cursor Terhadap Page
            float topMargin = _mySelection.Information[WdInformation.wdVerticalPositionRelativeToPage]; //Panjang Y Dari Tepi Atas Ke Cursor Terhadap Page
            float boundToCursorX = _mySelection.Information[WdInformation.wdHorizontalPositionRelativeToTextBoundary]; //Panjang X Dari Tepi Kiri ke Cursor Terhadap Text Boundary
            float boundToCursorY = _mySelection.Information[WdInformation.wdVerticalPositionRelativeToTextBoundary]; //Panjang y Dari Tepi Atas Ke Cursor Terhadap Text Boundary
            float firstLineIndent = _mySelection.Paragraphs.FirstLineIndent;
            float leftIndent = _mySelection.ParagraphFormat.LeftIndent;
            float rightIndent = _mySelection.ParagraphFormat.RightIndent;

            //Titik pertama
            float x1 = leftMargin + firstLineIndent + (leftIndent - boundToCursorX) - posisi; // -5 Karena garis harus mundur 5 point dari garis vertikal paragraph
            float y1 = topMargin;

            //Titik Kedua
            float x2 = x1 + panjangGaris; // di tambah 72 karena 1 inch = 72 point
            float y2 = topMargin - sudut; // Di kurang karena jarak dari pinggir page ke bawah harus lebih sedikit supaya y2 naik

            var lineAtas = _myDocument.Shapes.AddLine(x1, y1, x2, y2);
            lineAtas.Select();
            lineAtas.Name = "GarisAtas";

            SettingEnum.WarnaGaris value = (SettingEnum.WarnaGaris)Enum.Parse(typeof(SettingEnum.WarnaGaris), warnaGaris);

            switch (value)
            {
                case SettingEnum.WarnaGaris.Hitam:
                    _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
                    break;
                case SettingEnum.WarnaGaris.Merah:
                    _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Red);
                    break;
                case SettingEnum.WarnaGaris.Biru:
                    _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Blue);
                    break;
            }
            _mySelection.Collapse();
        }

        public static void Downline(string warnaGaris, float panjangGaris, float sudut, float posisi)
        {
            // 1  point = 20 twips
            // 72 Point = 1 Inch

            if (panjangGaris == 0) panjangGaris = 72;
            if (sudut == 0) sudut = 3;
            if (posisi == 0) posisi = 6;

            float leftMargin = _mySelection.Information[WdInformation.wdHorizontalPositionRelativeToPage]; //Panjang X Dari Tepi Kiri Ke Cursor
            float topMargin = _mySelection.Information[WdInformation.wdVerticalPositionRelativeToPage] + 24; // +24 untuk turun ke bawah sebanyak 25 point
            float boundToCursorX = _mySelection.Information[WdInformation.wdHorizontalPositionRelativeToTextBoundary]; //Panjang dari tepi X Boundris ke Cursor
            float boundToCursorY = _mySelection.Information[WdInformation.wdVerticalPositionRelativeToTextBoundary]; //Panjang dari tepi Y Boundaris ke Cursor
            float firstLineIndent = _mySelection.Paragraphs.FirstLineIndent;
            float leftIndent = _mySelection.ParagraphFormat.LeftIndent;
            float rightIndent = _mySelection.ParagraphFormat.RightIndent;

            //Titik Pertama
            float x1 = leftMargin + firstLineIndent + (leftIndent - boundToCursorX) - posisi;
            float y1 = topMargin;

            //Titik Kedua
            float x2 = x1 + panjangGaris;
            float y2 = topMargin + sudut;

            var lineBawah = _myDocument.Shapes.AddLine(x1, y1, x2, y2);
            lineBawah.Select();
            lineBawah.Name = "GarisBawah";

            SettingEnum.WarnaGaris value = (SettingEnum.WarnaGaris)Enum.Parse(typeof(SettingEnum.WarnaGaris), warnaGaris);

            switch (value)
            {
                case SettingEnum.WarnaGaris.Hitam:
                    _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
                    break;
                case SettingEnum.WarnaGaris.Merah:
                    _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Red);
                    break;
                case SettingEnum.WarnaGaris.Biru:
                    _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Blue);
                    break;
            }

            _mySelection.Collapse();
            PageNumbering(prosesAkta,
                varCapSelected,
                varPosisiNomorHalaman,
                varRataPosisiHalaman,
                varJumlahHalaman,
                varBarisJudul,
                varPosisiCap);

        }

        public static void GarisVertikal(string warnaGaris)
        {
            _mySelection.StartOf(WdUnits.wdParagraph, WdMovementType.wdMove); // Pindah Ke Posisi Awal Paragraph
            _mySelection.Bookmarks.Add("AwalGarisVertikal"); //Set Bookmark awal cursor

            int totalPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //Hitung Jumlah Page
            int activePage = _mySelection.Information[WdInformation.wdActiveEndPageNumber]; //Mengetahui Kursor Aktif di Page Berapa
            int pointerLineAwal = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber]; //Mengetahui Line number yang aktif di kursor

            _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Bookmarks.Add("AkhirGarisVertikal");
            int pointerLineAkhir = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            //Looping Setiap Page mulai dari bookmark awal
            _mySelection.GoTo(WdGoToItem.wdGoToBookmark, Name: "AwalGarisVertikal");

            do
            {
                _mySelection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
                _mySelection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].LineWidth = WdLineWidth.wdLineWidth100pt;
                _mySelection.ParagraphFormat.Borders.DistanceFromTop = 1;
                _mySelection.ParagraphFormat.Borders.DistanceFromLeft = 4;
                _mySelection.ParagraphFormat.Borders.DistanceFromBottom = 1;
                _mySelection.ParagraphFormat.Borders.DistanceFromRight = 4;
                _mySelection.ParagraphFormat.Borders.Shadow = false;

                SettingEnum.WarnaGaris value = (SettingEnum.WarnaGaris)Enum.Parse(typeof(SettingEnum.WarnaGaris), warnaGaris);

                switch (value)
                {
                    case SettingEnum.WarnaGaris.Hitam:
                        _mySelection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].Color = WdColor.wdColorAutomatic;
                        break;

                    case SettingEnum.WarnaGaris.Merah:
                        _mySelection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].Color = WdColor.wdColorRed;
                        break;

                    case SettingEnum.WarnaGaris.Biru:
                        _mySelection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].Color = WdColor.wdColorBlue;
                        break;
                }

                _mySelection.MoveDown(WdUnits.wdParagraph);

                if (_mySelection.Range.Bookmarks.Exists("AkhirGarisVertikal"))
                    break;

            } while (activePage <= totalPage);

            //Balik Ke Posisi Awal Sebelum di delete
            _mySelection.GoTo(WdGoToItem.wdGoToBookmark, Name: "AwalGarisVertikal");

            //Delete Bookmark yang baru di buat.
            if (_mySelection.Bookmarks.Exists("AwalGarisVertikal"))
                _mySelection.Bookmarks["AwalGarisVertikal"].Delete();

            if (_mySelection.Bookmarks.Exists("AkhirGarisVertikal"))
                _mySelection.Bookmarks["AkhirGarisVertikal"].Delete();

        }

        public static void SettingAkta()
        {
            _mySelection.WholeStory();
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Size = fontSize;
        }

        public static void RapihkanAkta()
        {
            SettingAkta();
            DeleteGarisStrip();
            DeleteDoubleSpace();
            RapihkanBarisKosong();
            //DeleteDoubleParagraph();
        }

        public static void GarisStripSeluruhAkta()
        {
            _mySelection.StartOf(WdUnits.wdParagraph, WdMovementType.wdMove); // Pindah Ke Posisi Awal Paragraph
            _mySelection.Bookmarks.Add("AwalGarisStrip"); //Set Bookmark awal cursor       

            int totalPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //Hitung Jumlah Page
            int activePage = _mySelection.Information[WdInformation.wdActiveEndPageNumber]; //Mengetahui Kursor Aktif di Page Berapa
            int pointerLineAwal = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber]; //Mengetahui Line number yang aktif di kursor

            _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdMove);
            // _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 13);
            _mySelection.Bookmarks.Add("AkhirGarisStrip");
            // _mySelection.InsertBreak(WdBreakType.wdSectionBreakContinuous);
            int pointerLineAkhir = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            //Looping Setiap Page mulai dari bookmark awal
            _mySelection.GoTo(WdGoToItem.wdGoToBookmark, Name: "AwalGarisStrip");

            while (activePage <= totalPage)
            {
                if (_mySelection.ParagraphFormat.Alignment == WdParagraphAlignment.wdAlignParagraphCenter)
                {
                    CenterLine();
                }
                else
                {
                    if (_mySelection.ParagraphFormat.Alignment != WdParagraphAlignment.wdAlignParagraphJustify)
                        _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                    RightLine();
                }

                _mySelection.MoveDown(WdUnits.wdParagraph);
                if (_mySelection.Bookmarks.Exists("AkhirGarisStrip"))
                {
                    break;
                }
            }

            //Balik Ke Posisi Awal Sebelum di delete
            _mySelection.GoTo(WdGoToItem.wdGoToBookmark, Name: "AwalGarisStrip");

            //Delete Bookmark yang baru di buat.
            if (_mySelection.Bookmarks.Exists("AwalGarisStrip"))
                _mySelection.Bookmarks["AwalGarisStrip"].Delete();

            if (_mySelection.Bookmarks.Exists("AkhirGarisStrip"))
                _mySelection.Bookmarks["AkhirGarisStrip"].Delete();
        }

        private static void DeleteGarisStrip()
        {
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("-", false, false, false, false, false, true, false, false, "", WdReplace.wdReplaceAll);
        }

        private static void DeleteDoubleSpace()
        {
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("  ", false, false, false, false, false, true, false, false, " ", WdReplace.wdReplaceAll);
        }

        private static void RapihkanBarisKosong()
        {
            //Paragraph Tab
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("^p^t", false, false, false, false, false, true, false, false, "^p", WdReplace.wdReplaceAll);

            //Tab Paragraph
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("^t^p", false, false, false, false, false, true, false, false, "^p", WdReplace.wdReplaceAll);

            //Paragarph Space
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("^p ", false, false, false, false, false, true, false, false, "^p", WdReplace.wdReplaceAll);

            //Space Paragarph
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute(" ^p", false, false, false, false, false, true, false, false, "^p", WdReplace.wdReplaceAll);

            //BreakLine
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("^l", false, false, false, false, false, true, false, false, "^p", WdReplace.wdReplaceAll);

            //Double Paragarph
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("^p^p", false, false, false, false, false, true, WdFindWrap.wdFindContinue, false, "^p", WdReplace.wdReplaceAll);
        }

        private static void DeleteSingleParagraph()
        {
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Find.Execute("^p", false, false, false, false, false, true, WdFindWrap.wdFindContinue, false, "", WdReplace.wdReplaceAll);
        }

        public static void CenterLine()
        {
            if (_mySelection.ParagraphFormat.Alignment != WdParagraphAlignment.wdAlignParagraphCenter)
                _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

            _mySelection.EndKey(WdUnits.wdLine);

            int pointerLine1 = _mySelection.Information[WdInformation.wdFirstCharacterColumnNumber];

            RightLine();

            int pointerLine2 = _mySelection.Information[WdInformation.wdFirstCharacterColumnNumber];

            int leftChar = (pointerLine2 - pointerLine1) / 2;

            if (leftChar <= 1) return;

            _mySelection.EndKey(WdUnits.wdLine);

            for (int i = 0; i < leftChar - 1; i++)
                _mySelection.TypeBackspace();

            _mySelection.HomeKey(WdUnits.wdLine);
            _mySelection.Font.Spacing = 0; //buang spacing antar font
            _mySelection.Font.Bold = 0;
            //_mySelection.Font.Size = fontSize;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineNone;

            for (int i = 0; i < leftChar - 1; i++)
                _mySelection.TypeText(Text: "-");

            _mySelection.EndKey(WdUnits.wdLine);
        }

        public static void RightLine()
        {
            var LineAwal = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            //Cara memindahakan Cursor Ke akhir Paragraf                       
            var x = _mySelection.Range;
            if (x.ListFormat.ListType == WdListType.wdListBullet || x.ListFormat.ListType == WdListType.wdListSimpleNumbering)
                _mySelection.MoveRight();
            else if (_mySelection.Information[WdInformation.wdFirstCharacterColumnNumber] == 1)
                _mySelection.MoveRight();


            //Cek apakah masih di line yang sama klo beda line pindah ke line atas nya
            int pointerLine1 = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber]; //Mengetahui Line number yang aktif di kursor
            _mySelection.EndOf(WdUnits.wdParagraph, WdMovementType.wdMove); // Kursor pindah ke akhir paragraf tapi bila ada paragarf di bawahnya akan pindah ke bawahnya
            int pointerLine2 = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            if (pointerLine1 != pointerLine2)
                _mySelection.MoveLeft();

            int pointerColCursor = _mySelection.Information[WdInformation.wdFirstCharacterColumnNumber]; //Mengetahui kursor berada di colom ke berapa mulai dari 1 sebelum huruf pertama

            _mySelection.Font.Spacing = 0; //buang spacing antar font
            _mySelection.Font.Bold = 0;
            //_mySelection.Font.Size = fontSize;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineNone;

            if (pointerColCursor <= 3) return;

            int counter = 0;

            while (_mySelection.Information[WdInformation.wdFirstCharacterColumnNumber] != 2)
            {
                counter++;
                _mySelection.TypeText(Text: "-");

                if (counter > 300)
                {
                    Dx.InfoErrorDx("Error in line " + _mySelection.Information[WdInformation.wdFirstCharacterLineNumber].ToString() + " Page " + _mySelection.Information[WdInformation.wdActiveEndAdjustedPageNumber].ToString() + Environment.NewLine + "Ada kesalahan prosedure pengetikan akta !!!");
                    return;
                }

            }

            _mySelection.TypeBackspace();

        }

        public static void GarisSebaris()
        {
            if (_mySelection.ParagraphFormat.Alignment == WdParagraphAlignment.wdAlignParagraphCenter)
            {
                if (_mySelection.Information[WdInformation.wdFirstCharacterLineNumber] == jmlbrs)
                {
                    var VZoom = _myWindow.ActivePane.View.Zoom.Percentage;
                    _myWindow.ActivePane.View.Type = WdViewType.wdNormalView;
                    _myWindow.ActivePane.View.Zoom.Percentage = 75;
                    CenterLine();
                    _myWindow.ActivePane.View.Type = WdViewType.wdPrintView;
                    _myWindow.ActivePane.View.Zoom.Percentage = VZoom;
                }
                else
                {
                    CenterLine();
                }
            }
            else
            {
                if (_mySelection.ParagraphFormat.Alignment != WdParagraphAlignment.wdAlignParagraphJustify)
                {
                    _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                }
                if (_mySelection.Information[WdInformation.wdFirstCharacterLineNumber] == jmlbrs)
                {
                    var VZoom = _myWindow.ActivePane.View.Zoom.Percentage;
                    _myWindow.ActivePane.View.Type = WdViewType.wdNormalView;
                    _myWindow.ActivePane.View.Zoom.Percentage = 75;
                    RightLine();
                    _myWindow.ActivePane.View.Type = WdViewType.wdPrintView;
                    _myWindow.ActivePane.View.Zoom.Percentage = VZoom;
                }
                RightLine();
            }

        }

        public static void HapusTrackChange()
        {
            _myDocument.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIRevisions);
            _myDocument.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIDocumentProperties);
            _myDocument.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIRemovePersonalInformation);
            _myDocument.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIAll);
            Dx.InfoBerhasilDx("Hapus Track Change Selesai.");
        }

        public static void DeleteBarisKosongDiAkhir()
        {
            if (@Dx.InfoQuestionDx("Posisi Kursor Harus Pada Akhir Akta!!, Lanjut?"))
            {
                _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdExtend);
                _mySelection.TypeBackspace();
            }
        }

        public static void DeleteBarisDatar()
        {
            DeleteGarisStrip();
        }

        public static void DeleteGarisPinggir()
        {
            _mySelection.WholeStory();
            _mySelection.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            _mySelection.HomeKey(WdUnits.wdLine);
            _myDocument.Shapes.SelectAll();
            //_mySelection.ShapeRange.Delete();
        }

        public static void DeleteGarisBawah()
        {

            for (int i = 1; i < _myDocument.Shapes.Count; i++) // Loop Total Shape
            {
                Console.WriteLine(_myDocument.Shapes[i]);
                if (_myDocument.Shapes[i].Name == "GarisBawah")
                {
                    _myDocument.Shapes[i].Delete();
                }
            }

        }

        public static void DeleteGarisAtas()
        {

            for (int i = 1; i < _myDocument.Shapes.Count; i++) // Loop Total Shape
            {
                Console.WriteLine(_myDocument.Shapes[i]);
                if (_myDocument.Shapes[i].Name == "GarisAtas")
                {
                    _myDocument.Shapes[i].Delete();
                }

            }

        }

        public static void DeleteGarisPinggirAndGarisDatar()
        {
            DeleteGarisStrip();
            DeleteGarisPinggir();
            DeleteGarisAtas();
            DeleteGarisBawah();
        }

        public static void InfomationMyCode()
        {
            // ^t tab
            // ^p paragraph
            // ^l break line

            _mySelection.WholeStory(); //Select All
            _mySelection.TypeBackspace(); // Hapus
            _mySelection.TypeParagraph(); // Insert Paragraf baru -> Mirip Enter

            // Formating Text
            _mySelection.Font.Name = "Courier New"; // Ubah Nama Font
            _mySelection.Font.Size = 12;
            _mySelection.Font.Bold = 1;
            _mySelection.Font.Italic = 1;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineSingle;
            _mySelection.Font.UnderlineColor = WdColor.wdColorBlueGray;

            //wdMove = Pindah
            //wdExtend = Select
            _mySelection.HomeKey(WdUnits.wdLine, WdMovementType.wdMove); // pindah ke line awal pada baris yang bersangkutan
            _mySelection.HomeKey(WdUnits.wdLine, WdMovementType.wdExtend); // select line yang bersangkutan ke kiri(karena HomeKey) dari letak terakhir kursor
            _mySelection.EndKey(WdUnits.wdLine); // pindah cursor ke colom terakhir pada baris yang bersangkutan

            int pointerLine = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber].ToInteger(); //Mengetahui Line number yang aktif di kursor
            int pointerColCursor = _mySelection.Information[WdInformation.wdFirstCharacterColumnNumber].ToInteger(); //Mengetahui kursor berada di colom ke berapa mulai dari 1 sebelum huruf pertama

            //Find and Replace
            _mySelection.Find.Execute("-", null, null, null, null, null, true, null, null, "", WdReplace.wdReplaceAll);

            //Find and Replace in Range
            var myRange = _mySelection.Range;
            myRange = _myDocument.Paragraphs[2].Range;
            myRange.Find.Execute("-", null, null, null, null, null, true, null, null, "", WdReplace.wdReplaceAll);


            /*Wd Goto       
            What : Kind of Item to Which The Range Or Selection Is Moved. can be one of the WdGoToItem
            Which : The item to which the range or selection is moved. can be one of the WdGoToDirection
            Count : The number of item in the document. the default value is 1.
            Name : os the what argumet is WdGoToBookmark, WdGoToComment, WdGoToField or WdGotoObject this argumet specifies a name             
            */
            _mySelection.GoTo(WdGoToItem.wdGoToHeading, WdGoToDirection.wdGoToFirst);

            //Move the selection to the fourt line in the documet
            _mySelection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToAbsolute, Count: 4);

            //Move selection up two line
            _mySelection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToPrevious, Count: 2);

            //Move to Page2
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Count: 2);

            //Move 1 line
            _mySelection.MoveUp(Unit: WdUnits.wdLine);

            //Hitung Jumlah Paragraph Harus Terselect Dulu Semuanya
            _mySelection.HomeKey(WdUnits.wdParagraph, WdMovementType.wdMove); //Pindah ke huruf pertama paragraph
            _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdExtend); //select all baru hitung jumlah paragraph
            int jmlParagraf = _mySelection.Paragraphs.Count;


            //Ambil Nilai Paragraph Kursor
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdExtend);
            int activeParagraph = _mySelection.Paragraphs.Count;
            _mySelection.GoTo(WdGoToItem.wdGoToHeading, WdGoToDirection.wdGoToFirst);
            _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdExtend);
            int totalParagraph = _mySelection.Paragraphs.Count;
        }

        public static void GoToEndOfPage()
        {
            int activePageNumber = _mySelection.Information[WdInformation.wdActiveEndAdjustedPageNumber].ToInteger();
            int totalPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument].ToInteger();

            if (activePageNumber < totalPage)
            {
                _mySelection.GoToNext(WdGoToItem.wdGoToPage);
                _mySelection.MoveLeft();
            }
            else
                _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdMove);

        }

        public static int ToPoint(this float value)
        {
            try
            {
                float result = 0;
                float inch = (value * 0.39370).ToFloat();
                result = inch * 72;
                return result.ToInteger();
            }
            catch
            {
                return 0;
            }
        }

        public static void InsertText(string value)
        {
            _mySelection.TypeText(value);
        }

        public static void CheckJustify()
        {
            var realpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            var Page = _mySelection.Information[WdInformation.wdActiveEndPageNumber];
            var Line = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber] - 1;

            _mySelection.EndKey(WdUnits.wdStory);
            if (_mySelection.Information[WdInformation.wdActiveEndPageNumber] == 1)
            {
                _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                return;
            }

            //_mySelection.InsertBreak(Type: WdBreakType.wdPageBreak);
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];

            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: Page);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: Line);

            LineJustify();
            if (_mySelection.Information[WdInformation.wdActiveEndPageNumber] < endpage)

                _mySelection.EndKey(Unit: WdUnits.wdStory);
            _mySelection.TypeBackspace();
            _mySelection.TypeParagraph();

            _mySelection.HomeKey(Unit: WdUnits.wdStory);
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: Line);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

        }

        public static void LineJustify()
        {
            if (_mySelection.ParagraphFormat.Alignment == WdParagraphAlignment.wdAlignParagraphCenter)
                _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
            else
            {
                if (_mySelection.ParagraphFormat.Alignment != WdParagraphAlignment.wdAlignParagraphJustify)
                    _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
            }
        }

        public static void SaveFormatAkta(
            string FontSelected,
            string marginKiriSelected,
            string marginKananSelected,
            string marginAtasSelected,
            string marginBawahSelected,
            string fontSize,
            string fontPositon,
            string panjangKertasSelected,
            string lebarKertasSelected)
        {

            _myDocument.RemoveDocumentInformation(WdRemoveDocInfoType.wdRDIAll);
            _mySelection.WholeStory();
            _mySelection.Font.Name = FontSelected;
            _mySelection.Font.Size = fontSize.ToFloat();
            _mySelection.Font.Position = fontPositon.ToInteger();

            var font = _myDocument.Styles[WdBuiltinStyle.wdStyleNormal].Font;
            if (font.NameFarEast == font.NameAscii)
            {
                font.NameAscii = "";
            }
            font.NameFarEast = "";

            _myDocument.PageSetup.LineNumbering.Active = 0;
            _myDocument.PageSetup.Orientation = WdOrientation.wdOrientPortrait;
            _myDocument.PageSetup.TopMargin = _myDocument.Application.CentimetersToPoints(marginAtasSelected.ToFloat());
            _myDocument.PageSetup.BottomMargin = _myDocument.Application.CentimetersToPoints(marginBawahSelected.ToFloat());
            _myDocument.PageSetup.LeftMargin = _myDocument.Application.CentimetersToPoints(marginKiriSelected.ToFloat());
            _myDocument.PageSetup.RightMargin = _myDocument.Application.CentimetersToPoints(marginKananSelected.ToFloat());
            _myDocument.PageSetup.Gutter = _myDocument.Application.CentimetersToPoints(0);
            _myDocument.PageSetup.HeaderDistance = _myDocument.Application.CentimetersToPoints((float)1.27);
            _myDocument.PageSetup.FooterDistance = _myDocument.Application.CentimetersToPoints((float)1.27);
            _myDocument.PageSetup.PageWidth = _myDocument.Application.CentimetersToPoints(panjangKertasSelected.ToFloat());
            _myDocument.PageSetup.PageHeight = _myDocument.Application.CentimetersToPoints(lebarKertasSelected.ToFloat());
            _myDocument.PageSetup.FirstPageTray = WdPaperTray.wdPrinterAutomaticSheetFeed;
            _myDocument.PageSetup.OtherPagesTray = WdPaperTray.wdPrinterAutomaticSheetFeed;
            _myDocument.PageSetup.SectionStart = WdSectionStart.wdSectionNewPage;
            _myDocument.PageSetup.OddAndEvenPagesHeaderFooter = 0;
            _myDocument.PageSetup.DifferentFirstPageHeaderFooter = 0;
            _myDocument.PageSetup.VerticalAlignment = WdVerticalAlignment.wdAlignVerticalTop;
            _myDocument.PageSetup.SuppressEndnotes = 0;
            _myDocument.PageSetup.MirrorMargins = 0;
            _myDocument.PageSetup.TwoPagesOnOne = false;
            _myDocument.PageSetup.BookFoldPrinting = false;
            _myDocument.PageSetup.BookFoldRevPrinting = false;
            _myDocument.PageSetup.BookFoldPrintingSheets = 1;
            _myDocument.PageSetup.GutterPos = WdGutterStyle.wdGutterPosLeft;

            var paragrafFormat = _mySelection.ParagraphFormat;
            paragrafFormat.SpaceBefore = 0;
            paragrafFormat.SpaceBeforeAuto = 0;
            paragrafFormat.SpaceAfter = 0;
            paragrafFormat.SpaceAfterAuto = 0;
            paragrafFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceExactly;
            paragrafFormat.LineSpacing = 24;
            paragrafFormat.WidowControl = 0;
            paragrafFormat.KeepWithNext = 0;
            paragrafFormat.KeepTogether = 0;
            paragrafFormat.PageBreakBefore = 0;
            paragrafFormat.NoLineNumber = 0;
            paragrafFormat.CharacterUnitLeftIndent = 0;
            paragrafFormat.CharacterUnitRightIndent = 0;
            paragrafFormat.CharacterUnitFirstLineIndent = 0;
            paragrafFormat.LineUnitBefore = 0;
            paragrafFormat.LineUnitAfter = 0;

            _mySelection.WholeStory();
            _mySelection.HomeKey(WdUnits.wdStory);
            _myWindow.ActivePane.View.Type = WdViewType.wdPrintView;
            _myWindow.ActivePane.View.Zoom.Percentage = 100;
            _myWindow.ActivePane.View.ShowSpaces = false;

            _myDocument.Application.Options.CheckGrammarAsYouType = false;
            _myDocument.Application.Options.CheckGrammarWithSpelling = false;
            _myDocument.Application.Options.CheckSpellingAsYouType = false;
            _myWindow.ActivePane.DisplayRulers = true;
            _myWindow.ActivePane.View.Zoom.Percentage = 100;

            CheckJustify();

        }
        public static void prosesMinuta(
            string prosesAktaSelected,
            int HideKalimatPenutupAktaSelected,
            string bahasaSelected,
            bool chkGarisDatarSelected,
            bool chkGarisPinggirSelected,
            string chkWarnaGarisTepi,
            bool chkHideNamaNotarisSelected,
            string modelSalinanSelected,
            string batasKiriNamaNotarisSelected,
            bool stempelSelected,
            bool capSelected,
            string posisiNomorHalaman,
            string rataPosisiHalaman,
            string barisJudul,
            string jumlahHalaman,
            string posisiCap,
            string txtNotaris1,
            string txtNotaris2,
            string panjangGarisAtas,
            string sudutGarisAtas,
            string posisiGarisAtas,
            string panjangGarisBawah,
            string sudutGarisBawah,
            string posisiGarisBawah
            )
        {

            if (@Dx.InfoQuestionDx("Lanjut?"))
            {

                _myWindow.ActivePane.View.Type = WdViewType.wdPrintView;
                _myWindow.ActivePane.View.Zoom.Percentage = 100;

                //CheckLinePage(prosesAktaSelected);
                SaveToTempFile(); //Save FIle Jika User blm Save File

                SettingEnum.ProsesAkta value = (SettingEnum.ProsesAkta)Enum.Parse(typeof(SettingEnum.ProsesAkta), prosesAktaSelected);
                if (value != SettingEnum.ProsesAkta.PPAT)
                {
                    if ((value == SettingEnum.ProsesAkta.Salinan) || (value == SettingEnum.ProsesAkta.Minuta))
                    {

                        if (HideKalimatPenutupAktaSelected == 0) // HIdeKalimatPenutup == false
                        {
                            SettingEnum.Bahasa bahasa = (SettingEnum.Bahasa)Enum.Parse(typeof(SettingEnum.Bahasa), bahasaSelected);
                            if (bahasa == SettingEnum.Bahasa.Inggris)
                            {
                                KalimatPenutupSalinanIng();
                            }
                            else
                            {
                                KalimatPenutupSalinanIna();
                            }
                        }
                    }

                    varCapSelected = capSelected;
                    varPosisiNomorHalaman = posisiNomorHalaman;
                    varRataPosisiHalaman = rataPosisiHalaman;
                    varJumlahHalaman = jumlahHalaman;
                    varBarisJudul = barisJudul;
                    varPosisiCap = posisiCap;

                    if (chkGarisDatarSelected == true)
                    {
                        GarisStripSeluruhAkta();
                    }

                    //BIKIN GARIS ATAS BAWAH VERTIKAL DAN JUGA STAMPEL
                    Misery(
                        chkGarisPinggirSelected,
                        chkWarnaGarisTepi,
                        chkHideNamaNotarisSelected,
                        prosesAktaSelected,
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
                        posisiGarisAtas,
                        panjangGarisBawah,
                        sudutGarisBawah,
                        posisiGarisBawah
                        );

                    if (capSelected == true)
                    {
                        //SettingEnum.PosisiCap psCap = (SettingEnum.PosisiCap)Enum.Parse(typeof(SettingEnum.PosisiCap),posisiCap);
                        Console.WriteLine(posisiCap);
                        if (posisiCap == "Cap di Awal & Akhir")
                        {
                            Cap(); // Cap Awal
                        }

                        else if (posisiCap == "Cap di Awal s/d Akhir")
                        {
                            var jumlahPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //totalPage
                            var counter = 0;

                            while (counter < jumlahPage)// cap awal -> akhir
                            {
                                CapAllPage();
                                counter = counter + 1;
                            }
                        }

                        else if (posisiCap == "Cap di Tegah Saja")
                        {
                            int jumlahPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //totalPage
                            CapTengahPage(jumlahPage); //Cap Tengah
                        }

                    }

                    //if (barisJudul.ToInteger() == 0) //==
                    //{
                    //    if (chkGarisDatarSelected == true)
                    //    {
                    //        _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
                    //        //Application.Run(MacroName: "f10");
                    //        GarisSebaris();
                    //    }
                    //}

                }
                else
                {
                    MiseryPPAT(
                        barisJudul,
                        posisiNomorHalaman,
                        jumlahHalaman);
                }

            }
        }

        public static void CheckLinePage(string prosesAktaSelected)
        {

            SettingEnum.ProsesAkta value = (SettingEnum.ProsesAkta)Enum.Parse(typeof(SettingEnum.ProsesAkta), prosesAktaSelected);
            if (value == SettingEnum.ProsesAkta.Minuta)
            {
                return;
            }

            var cpage = _mySelection.Information[WdInformation.wdActiveEndPageNumber];
            var cLine = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber] - 1;

            _mySelection.EndKey(Unit: WdUnits.wdStory);
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: cpage);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: cLine);
            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var BrsAkhir = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];
            _mySelection.HomeKey(Unit: WdUnits.wdStory);
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: cLine);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

            if (BrsAkhir > 24 & SettingEnum.ProsesAkta.PPAT != value)
            {
                if (@Dx.InfoQuestionDx("Baris Akhir Akta > 24 Baris, Penutup Nama Notaris akan tidak ditampilkan !!!, Lanjutkan?"))
                {
                    return;
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }

        }

        public static void SaveToTempFile()
        {
            _myDocument.Save();
            //if (ChkTmpFile.Value == true)
            //{
            //    Win = FileSystem.Dir(@"C:\Users", Constants.vbDirectory);
            //    if (Win == "Users")
            //        Fld = @"C:\Users\Public\" + Strings.Chr(131);
            //    else
            //        Fld = @"C:\Program Files\Internet Explorer\" + Strings.Chr(131);
            //    Fld = Fld + @"\";
            //    Open(Fld + "pthdrv.hlp"); Line(Input, drv);
            //    Close(); tmpfile = Mid(drv, 2, Len(drv) - 2) + @"\ThisProgramPresentByFielyBachriToMyWifeAndAllMyLovelySon";
            //    ActiveDocument.SaveAs(FileName: tmpfile, FileFormat: wdFormatDocument, LockComments: false, Password: "", AddToRecentFiles: true, WritePassword: "", ReadOnlyRecommended: false, EmbedTrueTypeFonts: false, SaveNativePictureFormat: false, SaveFormsData: false, SaveAsAOCELetter: false);
            //}

            SettingPageSalinan();
        }

        public static void SettingPageSalinan()
        {
            {
                var documentPageSetup = _myDocument.PageSetup;
                documentPageSetup.LineNumbering.Active = 0;
                documentPageSetup.Orientation = WdOrientation.wdOrientPortrait;
                documentPageSetup.TopMargin = _myDocument.Application.CentimetersToPoints(marginAtas);
                documentPageSetup.BottomMargin = _myDocument.Application.CentimetersToPoints(marginBawah);
                documentPageSetup.LeftMargin = _myDocument.Application.CentimetersToPoints(marginKiri);
                documentPageSetup.RightMargin = _myDocument.Application.CentimetersToPoints(marginKanan);
                documentPageSetup.Gutter = _myDocument.Application.CentimetersToPoints(0);
                documentPageSetup.HeaderDistance = _myDocument.Application.CentimetersToPoints((float)1.27);
                documentPageSetup.FooterDistance = _myDocument.Application.CentimetersToPoints((float)1.27);
                documentPageSetup.PageWidth = _myDocument.Application.CentimetersToPoints(panjangKertas);
                documentPageSetup.PageHeight = _myDocument.Application.CentimetersToPoints(lebarKertas);
                documentPageSetup.FirstPageTray = WdPaperTray.wdPrinterAutomaticSheetFeed;
                documentPageSetup.OtherPagesTray = WdPaperTray.wdPrinterAutomaticSheetFeed;
                documentPageSetup.SectionStart = WdSectionStart.wdSectionNewPage;
                documentPageSetup.OddAndEvenPagesHeaderFooter = 0;
                documentPageSetup.DifferentFirstPageHeaderFooter = 0;
                documentPageSetup.VerticalAlignment = WdVerticalAlignment.wdAlignVerticalTop;
                documentPageSetup.SuppressEndnotes = 0;
                documentPageSetup.MirrorMargins = 0;
                documentPageSetup.TwoPagesOnOne = false;
                documentPageSetup.GutterPos = WdGutterStyle.wdGutterPosLeft;
            }
        }

        public static void KalimatPenutupSalinanIng()
        {

            var cpage = _mySelection.Information[WdInformation.wdActiveEndPageNumber];
            var cLine = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber] - 1;

            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: cpage);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: cLine);
            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var BrsAkhir = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineNone;

            _mySelection.TypeText(Text: penutupENG_1);
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            RightLine();
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            _mySelection.TypeParagraph();

            _mySelection.TypeText(Text: penutupENG_2);
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            RightLine();
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            _mySelection.TypeParagraph();

            _mySelection.HomeKey(Unit: WdUnits.wdStory);
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: cLine);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

        }

        public static void KalimatPenutupSalinanIna()
        {
            var cpage = _mySelection.Information[WdInformation.wdActiveEndPageNumber];
            var cLine = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber] - 1;

            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: cpage);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: cLine);
            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var BrsAkhir = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineNone;

            _mySelection.TypeText(Text: penutupINA_1);
            RightLine();
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            _mySelection.TypeParagraph();

            _mySelection.TypeText(Text: penutupINA_2);
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;
            RightLine();
            _mySelection.TypeParagraph();
            _mySelection.Font.Size = fontSize;
            _mySelection.Font.Name = fontName;
            _mySelection.Font.Spacing = 0;

            _mySelection.HomeKey(Unit: WdUnits.wdStory);
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: cLine);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

        }

        public static void NewLeftIndentAllPage()
        {
            var totalPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            var ActivePage = _mySelection.Information[WdInformation.wdActiveEndPageNumber];
            var Line = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];

            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: ActivePage);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: Line);
            _mySelection.HomeKey(Unit: WdUnits.wdStory);

        ulang:
            var NoBrs = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];
            NewLeftIndent();
            if (_mySelection.Information[WdInformation.wdActiveEndPageNumber] < endpage)
            {
                if (_mySelection.Information[WdInformation.wdFirstCharacterLineNumber] == NoBrs)
                {
                    if (@Dx.InfoQuestionDx("Kesalahan pengaturan Indent, Lanjutkan?"))
                    {
                        var LeftInd2 = _myDocument.Application.PointsToInches(_mySelection.ParagraphFormat.LeftIndent);
                        _mySelection.ParagraphFormat.FirstLineIndent = LeftInd2;
                        _mySelection.HomeKey();
                    }
                    else
                    {
                        System.Environment.Exit(0);
                    }

                    var LeftInd = _myDocument.Application.PointsToInches(_mySelection.ParagraphFormat.LeftIndent);
                    _mySelection.ParagraphFormat.FirstLineIndent = LeftInd;
                    _mySelection.HomeKey();

                    if (_mySelection.Information[WdInformation.wdActiveEndPageNumber] == endpage - 1)
                        goto abis;
                    _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 2);
                }
                goto ulang;
            }

        abis:
            _mySelection.EndKey(Unit: WdUnits.wdStory);
            _mySelection.TypeBackspace();
            _mySelection.HomeKey(Unit: WdUnits.wdStory);
            Line = Line - 1;
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: Line);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

        }

        public static void NewLeftIndent()
        {
            var Lindent = _myDocument.Application.PointsToInches(_mySelection.ParagraphFormat.LeftIndent);
            var FIndent = _myDocument.Application.PointsToInches(_mySelection.ParagraphFormat.FirstLineIndent);

            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);
            var xLindent = _myDocument.Application.PointsToInches(_mySelection.ParagraphFormat.LeftIndent);
            var xFIndent = _myDocument.Application.PointsToInches(_mySelection.ParagraphFormat.FirstLineIndent);

            _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 1);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

            if ((Lindent >= 0 & FIndent == 0))
            {
                _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
                _mySelection.HomeKey(Unit: WdUnits.wdLine);
                return;
            }

            if (Lindent > FIndent & FIndent != 0)
            {
                _mySelection.HomeKey(Unit: WdUnits.wdLine);
                if (xFIndent == 0)
                {
                    _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
                    _mySelection.HomeKey(Unit: WdUnits.wdLine);
                    return;
                }

                _mySelection.EndKey(Unit: WdUnits.wdLine);
                _mySelection.TypeParagraph();
                _mySelection.Range.ListFormat.RemoveNumbers(NumberType: WdNumberType.wdNumberParagraph);
                {
                    _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(Lindent); // PixelsToPoints(lindent)
                    _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
                    _mySelection.ParagraphFormat.SpaceAfterAuto = 0;
                }
                {
                    _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(Lindent); // PixelsToPoints(lindent)
                    _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
                    _mySelection.ParagraphFormat.SpaceAfterAuto = 0;
                }
                _mySelection.EndKey(Unit: WdUnits.wdLine);
                var clmchr = _mySelection.Information[WdInformation.wdFirstCharacterColumnNumber];
                if (clmchr == 1)
                    _mySelection.Delete(Unit: WdUnits.wdCharacter, Count: 1);
                _mySelection.HomeKey(Unit: WdUnits.wdLine);
            }

            if (Lindent < FIndent)
            {
                if (xFIndent == FIndent)
                {
                    _mySelection.EndKey(Unit: WdUnits.wdLine);
                    _mySelection.TypeParagraph();
                    var prg1st = _mySelection.Paragraphs.First.ToString();
                    if (prg1st.Length != 1)
                    {
                        _mySelection.ParagraphFormat.FirstLineIndent = _myDocument.Application.InchesToPoints(0);
                        _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 1);
                        _mySelection.HomeKey(Unit: WdUnits.wdLine);
                        _mySelection.ParagraphFormat.FirstLineIndent = _myDocument.Application.InchesToPoints(0);
                        _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(FIndent);
                    }
                    else
                    {
                        _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 1);
                        _mySelection.EndKey(Unit: WdUnits.wdLine);
                        _mySelection.Delete();
                        _mySelection.HomeKey(Unit: WdUnits.wdLine);
                        _mySelection.ParagraphFormat.FirstLineIndent = _myDocument.Application.InchesToPoints(0);
                        _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(FIndent);
                    }
                }
                else
                {
                    _mySelection.ParagraphFormat.FirstLineIndent = _myDocument.Application.InchesToPoints(0);
                    _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(FIndent);
                }
                _mySelection.HomeKey(Unit: WdUnits.wdLine);
                _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
            }

            if (Lindent == FIndent & xLindent == xFIndent)
            {
                _mySelection.HomeKey(Unit: WdUnits.wdLine);
                if (xFIndent == 0)
                {
                    _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
                    _mySelection.HomeKey(Unit: WdUnits.wdLine);
                    return;
                }

                _mySelection.EndKey(Unit: WdUnits.wdLine);
                _mySelection.TypeParagraph();
                _mySelection.Range.ListFormat.RemoveNumbers(NumberType: WdNumberType.wdNumberParagraph);
                {

                    _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(Lindent); // PixelsToPoints(lindent)
                    _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
                    _mySelection.ParagraphFormat.SpaceAfterAuto = 0;
                }
                {
                    _mySelection.ParagraphFormat.LeftIndent = _myDocument.Application.InchesToPoints(Lindent); // PixelsToPoints(lindent)
                    _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
                    _mySelection.ParagraphFormat.SpaceAfterAuto = 0;
                }
                _mySelection.EndKey(Unit: WdUnits.wdLine);
                var clmchr = _mySelection.Information[WdInformation.wdFirstCharacterColumnNumber];
                if (clmchr == 1)
                    _mySelection.Delete(Unit: WdUnits.wdCharacter, Count: 1);
                _mySelection.HomeKey(Unit: WdUnits.wdLine);
            }
        }

        public static void RightLineAllPage()
        {

            var RealSize = _mySelection.Font.Size;
            var realpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            var Page = _mySelection.Information[WdInformation.wdActiveEndPageNumber];
            var Line = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber] - 1;
            var jumlahHalaman = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];

            _mySelection.EndKey(Unit: WdUnits.wdStory);
            _mySelection.InsertBreak(Type: WdBreakType.wdPageBreak);
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];

            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: 2);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: 1);
            jmlbrs = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Name: Page);
            _mySelection.Find.ClearFormatting();
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: Line);

            GarisStripSeluruhAkta();
            _mySelection.EndKey(Unit: WdUnits.wdStory);
            _mySelection.TypeBackspace();
            _mySelection.TypeBackspace();
            _mySelection.TypeBackspace();
            _mySelection.TypeParagraph();

            _mySelection.Font.Size = RealSize;
            _mySelection.HomeKey(Unit: WdUnits.wdStory);
            _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: Line);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

        }

        public static void MiseryPPAT(
            string barisJudul,
            string posisiNomorHalaman,
            string jumlahHalaman)
        {

            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];
            var blankpage = 0;

            PPAT_PageNo_New(posisiNomorHalaman, jumlahHalaman);

            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var pgmod = endpage % 4;

            if (pgmod == 0 | endpage == 4)
            {
                blankpage = 0;
            }
            else
            {
                blankpage = 2 - pgmod; //4
            };

            for (var x = 1; x <= blankpage; x++)
            {
                _mySelection.EndKey(Unit: WdUnits.wdStory);
                _mySelection.InsertBreak(Type: WdBreakType.wdPageBreak);
                _mySelection.EndKey(Unit: WdUnits.wdStory);
                var aw = _myDocument.PageSetup.FooterDistance + _myDocument.PageSetup.BottomMargin;
                var aX = _myDocument.PageSetup.LeftMargin - 20;
                var aY = _myDocument.PageSetup.PageHeight - aw;
                var aZ = _myDocument.PageSetup.PageWidth - _myDocument.PageSetup.RightMargin - _myDocument.PageSetup.LeftMargin + 30;
                _myDocument.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, aX, aY, aZ, aw).Select();
                _mySelection.ShapeRange.TextFrame.TextRange.Select();
                _mySelection.Collapse();
                _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            }

            var tutup = blankpage + 1;
            _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: tutup);
            _mySelection.HomeKey(Unit: WdUnits.wdStory);

        }

        public static void PPAT_PageNo_New(
            string posisiNomorHalaman,
            string jumlahHalaman)
        {

            // PageNumbering Macro
            SettingEnum.PosisiVertikalNomorHalaman posisiNomorHalamanValue = (SettingEnum.PosisiVertikalNomorHalaman)Enum.Parse(typeof(SettingEnum.PosisiVertikalNomorHalaman), posisiNomorHalaman);
            if (posisiNomorHalamanValue == SettingEnum.PosisiVertikalNomorHalaman.TanpaNomer)
                return;

            if (_myWindow.View.SplitSpecial != WdSpecialPane.wdPaneNone)
            {
                _myWindow.Panes[2].Close();
            }

            if (_myWindow.ActivePane.View.Type == WdViewType.wdNormalView | _myWindow.ActivePane.View.Type == WdViewType.wdOutlineView)
            {
                _myWindow.ActivePane.View.Type = WdViewType.wdPrintView;
            }

            _myWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
            if (_mySelection.HeaderFooter.IsHeader == true)
            {
                _myWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageFooter;
            }
            else
            {
                _myWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
            }

            _mySelection.ParagraphFormat.TabStops.ClearAll();
            var r1 = _myDocument.PageSetup.RightMargin;
            var l1 = _myDocument.PageSetup.LeftMargin;
            var LL = _mySelection.Application.PointsToCentimeters(_myDocument.PageSetup.PageWidth - r1 - l1);
            _mySelection.EndKey(Unit: WdUnits.wdLine);
            _mySelection.ParagraphFormat.TabStops.Add(Position: _mySelection.Application.CentimetersToPoints(LL), Alignment: WdTabAlignment.wdAlignTabRight, Leader: WdTabLeader.wdTabLeaderSpaces);
            _mySelection.EndKey(Unit: WdUnits.wdLine);
            _mySelection.Font.Bold = 0;
            _mySelection.Font.Italic = 1;
            _mySelection.Font.Name = "Bookman Old Style";
            _mySelection.Font.Size = 8;
            _mySelection.TypeText(Text: "\t" + "Halaman ");
            _mySelection.Fields.Add(Range: _mySelection.Range, Type: WdFieldType.wdFieldPage);
            _mySelection.MoveLeft(Unit: WdUnits.wdCharacter, Count: 1, Extend: WdMovementType.wdExtend);
            _mySelection.MoveRight(Unit: WdUnits.wdCharacter, Count: 1);
            _mySelection.TypeText(Text: " dari " + jumlahHalaman.Trim() + " halaman");
            _myWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;

        }

        public static void Misery(
            bool chkGarisSelected,
            string chkWarnaGarisTepi,
            bool chkHideNamaNotarisSelected,
            string prosesAktaSelected,
            string modelSalinanSelected,
            string batasKiriNamaNotarisSelected,
            bool stempelSelected,
            bool capSelected,
            string posisiNomorHalaman,
            string rataPosisiHalaman,
            string barisJudul,
            string jumlahHalaman,
            string posisiCap,
            string txtNotaris1,
            string txtNotaris2,
            string panjangGarisAtas,
            string sudutGarisAtas,
            string posisiGarisAtas,
            string panjangGarisBawahSelected,
            string sudutGarisBawahSelected,
            string posisiGarisBawahSelected
            )
        {

            var brsjdl = barisJudul;
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //totalPage
            var pg_end = endpage;

            if (chkGarisSelected == true)
            {
                GarisVertikal(chkWarnaGarisTepi); //garis tegak lurus
                _mySelection.HomeKey(Unit: WdUnits.wdStory);
                _mySelection.MoveDown(Unit: WdUnits.wdLine, Count: brsjdl);
                _mySelection.HomeKey(Unit: WdUnits.wdLine);

                var counter = 0;
                while (counter < endpage) //buat garis atas bawah
                {
                    Garis(
                        chkWarnaGarisTepi,
                        panjangGarisAtas,
                        sudutGarisAtas,
                        posisiGarisAtas,
                        panjangGarisBawahSelected,
                        sudutGarisBawahSelected,
                        posisiGarisBawahSelected
                        );
                    counter = counter + 1;
                }

            }


            _mySelection.EndKey(Unit: WdUnits.wdStory);
            var endlinepage = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            //if (endlinepage < 24) //Kurang darri 24 Halaman
            //{
            //    if (chkHideNamaNotarisSelected == false)
            //    {
            //        NotaryName(
            //            prosesAktaSelected,
            //            modelSalinanSelected,
            //            batasKiriNamaNotarisSelected,
            //            stempelSelected);
            //    }
            //}

            NotaryName(
                 prosesAktaSelected,
                 modelSalinanSelected,
                 batasKiriNamaNotarisSelected,
                 stempelSelected,
                 txtNotaris1,
                 txtNotaris2);

            SettingEnum.ProsesAkta prosesAktaValue = (SettingEnum.ProsesAkta)Enum.Parse(typeof(SettingEnum.ProsesAkta), prosesAktaSelected);

            PageNumbering(
              prosesAktaSelected,
              capSelected,
              posisiNomorHalaman,
              rataPosisiHalaman,
              jumlahHalaman,
              barisJudul,
              posisiCap);

            _mySelection.EndKey(Unit: WdUnits.wdStory); // go to end page

            if (prosesAktaValue == SettingEnum.ProsesAkta.Salinan)
            {
                if (capSelected == true)
                {
                    if (posisiCap == "Cap di Awal & Akhir")
                    {
                        Cap(); //Cap di Akhir    
                    }
                }
            }

            var pgmod = endpage % 4; //pgmod = 2

            int blankpage = 0;

            if (pgmod == 0 | endpage == 4)
            {
                blankpage = 0;
            }

            else
            {
                blankpage = 4 - pgmod;
            }


            SettingEnum.ModelSalinan modelSalinanValue = (SettingEnum.ModelSalinan)Enum.Parse(typeof(SettingEnum.ModelSalinan), modelSalinanSelected.Replace(" ", ""));
            int naik = 0;

            if (modelSalinanValue == SettingEnum.ModelSalinan.Model1)
            {
                naik = 8; //8
            }

            if (modelSalinanValue == SettingEnum.ModelSalinan.Model2)
            {
                naik = 6; //6
            }

            if (chkHideNamaNotarisSelected == true)
            {
                naik = 0;//0
            }

            if (endlinepage >= 24)
            {
                naik = 0;//10
            }

            var tutup = blankpage + 1 + naik;
            _mySelection.GoTo(What: WdGoToItem.wdGoToBookmark, Name: "EndDownLine");
            _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 1);


            if (prosesAktaValue != SettingEnum.ProsesAkta.Minuta) // minuta jangan dikasih downline
            {

                if (chkGarisSelected == true)
                {
                    Downline(
                    chkWarnaGarisTepi,
                    panjangGarisBawahSelected.ToFloat(),
                    sudutGarisBawahSelected.ToFloat(),
                    posisiGarisBawahSelected.ToFloat()
                    );
                    if (_mySelection.Bookmarks.Exists("EndDownLine"))
                        _mySelection.Bookmarks["EndDownLine"].Delete();
                }

            }
            _mySelection.HomeKey(Unit: WdUnits.wdStory);

        }

        public static void NotaryName(
            string prosesAktaSelected,
            string modelSalinanSelected,
            string batasKiriNamaNotarisSelected,
            bool stempelSelected,
            string txtNotaris1,
            string txtNotaris2)
        {
            SettingEnum.ProsesAkta prosesAktaValue = (SettingEnum.ProsesAkta)Enum.Parse(typeof(SettingEnum.ProsesAkta), prosesAktaSelected);
            SettingEnum.ModelSalinan modelSalinanValue = (SettingEnum.ModelSalinan)Enum.Parse(typeof(SettingEnum.ModelSalinan), modelSalinanSelected.Replace(" ", ""));

            switch (modelSalinanValue)
            {
                case SettingEnum.ModelSalinan.Model1:

                    _mySelection.Bookmarks.Add("EndDownLine");
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    Model1(
                        batasKiriNamaNotarisSelected,
                        stempelSelected,
                        txtNotaris1,
                        txtNotaris2);
                    break;
                case SettingEnum.ModelSalinan.Model2:
                    _mySelection.Bookmarks.Add("EndDownLine");
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    _mySelection.TypeParagraph();
                    Model2(
                        batasKiriNamaNotarisSelected,
                        stempelSelected,
                        txtNotaris1,
                        txtNotaris2);
                    break;
            }

        }

        public static void Model1(
            string batasKiriNamaNotarisSelected,
            bool stempelSelected,
            string txtNotaris1,
            string txtNotaris2
            )
        {
            _mySelection.Font.Spacing = 0;
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            _mySelection.Font.Bold = 1;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineSingle;
            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.CentimetersToPoints(batasKiriNamaNotarisSelected.ToFloat());
            _mySelection.TypeText(Text: txtNotaris2);
            _mySelection.Font.Bold = 1;
            _mySelection.Font.Underline = WdUnderline.wdUnderlineNone;
            _mySelection.TypeParagraph();
            _mySelection.TypeText(Text: txtNotaris1);
            _mySelection.Font.Spacing = 24;
            _mySelection.TypeParagraph();

            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
            _mySelection.ParagraphFormat.SpaceAfterAuto = 0;

            if (stempelSelected == true)
            {
                Stempel1();
            }
        }

        public static void Model2(
            string batasKiriNamaNotarisSelected,
            bool stempelSelected,
            string txtNotaris1,
            string txtNotaris2)
        {

            _mySelection.ParagraphFormat.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleNone;
            _mySelection.Font.Spacing = 0;

            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.CentimetersToPoints(batasKiriNamaNotarisSelected.ToFloat());
            _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
            _mySelection.ParagraphFormat.SpaceAfterAuto = 0;

            _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            _mySelection.TypeText(Text: txtNotaris2);
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.TypeParagraph();
            _mySelection.Font.Bold = 1;
            _mySelection.TypeText(Text: txtNotaris1);
            _mySelection.Font.Bold = 1;
            if (_mySelection.Font.Underline == WdUnderline.wdUnderlineNone)
            {
                _mySelection.Font.Underline = WdUnderline.wdUnderlineSingle;
            }
            else
            {
                _mySelection.Font.Underline = WdUnderline.wdUnderlineNone;
            }

            _mySelection.TypeParagraph();

            _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify; //wdAlignParagraphJustify
            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.InchesToPoints(0.ToFloat());
            _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
            _mySelection.ParagraphFormat.SpaceAfterAuto = 0;

            if (stempelSelected == true)
            {
                Stempel2();
            }

        }

        public static void getPathStempel(string pathStempelSelected)
        {
            pathStempel = pathStempelSelected;
        }

        public static void getSettingStempel(
            float _naikBaris,
            float _batasMarginAtas,
            float _batasMarginKiri,
            float _panjangStempel,
            float _lebarStempel
            )
        {

            naikBaris = _naikBaris;
            batasMarginAtas = _batasMarginAtas;
            batasMarginKiri = _batasMarginKiri;
            panjangStempel = _panjangStempel;
            lebarStempel = _lebarStempel;

            Console.WriteLine(_myDocument.InlineShapes.Count); //0
            Console.WriteLine(_myDocument.Range(1).InlineShapes.Count);

            foreach (Shape item in _myDocument.Shapes)
            {
                Console.WriteLine(item.Title);
                if (item.Title == "stempel")
                {
                    item.Width = panjangStempel;
                }
                if (item.AlternativeText == "test")
                {
                    item.Width = panjangStempel;
                }
            }


            foreach (Microsoft.Office.Interop.Word.InlineShape iShape in _myDocument.InlineShapes)
            {
                Console.WriteLine(iShape.Title);
                if (iShape != null)
                {
                    if (iShape.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        iShape.Width = panjangStempel;
                    }
                }
                //if (iShape.AlternativeText == "test")
                //{
                //    Console.WriteLine(iShape);
                //};
            }

            //Console.WriteLine(_myDocument.Range(1).InlineShapes.Count);

            //for (int i = 1; i < _myDocument.Shapes.Count; i++) // Loop Total Inline Shape
            //{
            //    if (_myDocument.Shapes[i].AlternativeText == "stempel")
            //    {
            //        _myDocument.Shapes[i].Width = panjangStempel;
            //    }
            //}

            //for (int i = 1; i < _myDocument.InlineShapes.Count; i++) // Loop Total Inline Shape
            //{
            //    if (_myDocument.InlineShapes[i].Title == "stempel")
            //    {
            //        _myDocument.InlineShapes[i].Width = panjangStempel;
            //    }
            //}

        }

        public static void Stempel2()
        {

            // Stempel Macro 2
            _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 5); // COunt : 5
            _mySelection.HomeKey(Unit: WdUnits.wdLine);
            var fbrs = _mySelection.Information[WdInformation.wdVerticalPositionRelativeToPage] + 0; // 0 /10 margin-top stempel
            var fklm = _mySelection.Information[WdInformation.wdHorizontalPositionRelativeToPage] * 0.93; // 0.93 / 0.73 margin-left stempel

            _myDocument.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, fklm, fbrs, 114, 101).Select();

            _mySelection.ShapeRange.TextFrame.TextRange.Select();
            _mySelection.Collapse();
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            _mySelection.ShapeRange.Fill.Solid();

            _mySelection.ShapeRange.Fill.Transparency = 0;
            _mySelection.ShapeRange.Line.Weight = 0.75.ToFloat();
            _mySelection.ShapeRange.Line.DashStyle = Microsoft.Office.Core.MsoLineDashStyle.msoLineSolid;
            _mySelection.ShapeRange.Line.Style = Microsoft.Office.Core.MsoLineStyle.msoLineSingle;
            _mySelection.ShapeRange.Line.Transparency = 0;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.Line.BackColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.TextFrame.MarginLeft = 7.2.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginRight = 7.2.ToFloat(); //7.2.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginTop = 3.6.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginBottom = 3.6.ToFloat();
            _mySelection.ShapeRange.LockAnchor = 0;
            _mySelection.ShapeRange.LayoutInCell = -1;
            _mySelection.ShapeRange.WrapFormat.AllowOverlap = -1;
            _mySelection.ShapeRange.WrapFormat.Side = WdWrapSideType.wdWrapBoth;
            _mySelection.ShapeRange.WrapFormat.DistanceTop = _mySelection.Application.InchesToPoints(0);
            _mySelection.ShapeRange.WrapFormat.DistanceBottom = _mySelection.Application.InchesToPoints(0);
            _mySelection.ShapeRange.WrapFormat.DistanceLeft = _mySelection.Application.InchesToPoints(0.13.ToFloat());
            _mySelection.ShapeRange.WrapFormat.DistanceRight = _mySelection.Application.InchesToPoints(0.13.ToFloat());
            _mySelection.ShapeRange.WrapFormat.Type = WdWrapType.wdWrapNone;
            _mySelection.ShapeRange.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendToBack);
            _mySelection.ShapeRange.TextFrame.AutoSize = 0;
            _mySelection.ShapeRange.TextFrame.WordWrap = 1;
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

            //Browse path Stempel
            if (pathCap == "" || pathCap == null)
            {
                _mySelection.Range.InlineShapes.AddPicture(FileName: @"C:\Program Files\Stempel\Stempel.png", LinkToFile: false, SaveWithDocument: true);
            }
            else
            {
                //var shape = _mySelection.Range.InlineShapes.AddPicture(FileName:pathStempel, LinkToFile: false, SaveWithDocument: true);
                //shape.Select();
                //shape.Width = 80; //
                //shape.Height = 80; //
                //shape.Title = "stempel";
                //shape.AlternativeText = "test";

                var shape = _myDocument.Shapes.AddPicture(FileName:pathStempel, LinkToFile:false, SaveWithDocument: true,Left: 300);

                // var shape = _myDocument.Shapes.AddPicture(pathStempel, false, false, fklm, fbrs, 114, 101);

                shape.Select();
                shape.Width = 80; //
                shape.Height = 80; //
                shape.Title = "stempel";
                shape.AlternativeText = "test";
                shape.Name = "stempel";

            }

            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.RightIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.SpaceBefore = 0;
            //_mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
            _mySelection.ParagraphFormat.SpaceAfter = 0;
            //_mySelection.ParagraphFormat.SpaceAfterAuto = 0;
            _mySelection.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            _mySelection.ParagraphFormat.WidowControl = -1;
            _mySelection.ParagraphFormat.KeepWithNext = 0;
            _mySelection.ParagraphFormat.KeepTogether = 0;
            _mySelection.ParagraphFormat.PageBreakBefore = 0;
            _mySelection.ParagraphFormat.NoLineNumber = 0;
            _mySelection.ParagraphFormat.Hyphenation = -1;
            _mySelection.ParagraphFormat.FirstLineIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.OutlineLevel = WdOutlineLevel.wdOutlineLevelBodyText;
            //_mySelection.ParagraphFormat.CharacterUnitLeftIndent = 0;
            //_mySelection.ParagraphFormat.CharacterUnitRightIndent = 0;
            //_mySelection.ParagraphFormat.CharacterUnitFirstLineIndent = 0;
            //_mySelection.ParagraphFormat.LineUnitBefore = 0;
            //_mySelection.ParagraphFormat.LineUnitAfter = 0;
            //_mySelection.ParagraphFormat.MirrorIndents = 0;
            //_mySelection.ParagraphFormat.TextboxTightWrap = WdTextboxTightWrap.wdTightNone;

        }

        public static void Stempel1()
        {

            // Stempel Macro 1
            _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 4);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);
            var fbrs = _mySelection.Information[WdInformation.wdVerticalPositionRelativeToPage] - 85; //85
            var fklm = _mySelection.Information[WdInformation.wdHorizontalPositionRelativeToPage] * 1.2; //0.75

            _myDocument.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, fklm, fbrs, 114, 101).Select();

            _mySelection.ShapeRange.TextFrame.TextRange.Select();
            _mySelection.Collapse();
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            _mySelection.ShapeRange.Fill.Solid();
            _mySelection.ShapeRange.Fill.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.Fill.Transparency = 0;
            _mySelection.ShapeRange.Line.Weight = 0.75.ToFloat();
            _mySelection.ShapeRange.Line.DashStyle = Microsoft.Office.Core.MsoLineDashStyle.msoLineSolid;
            _mySelection.ShapeRange.Line.Style = Microsoft.Office.Core.MsoLineStyle.msoLineSingle;
            _mySelection.ShapeRange.Line.Transparency = 0;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.Line.BackColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.TextFrame.MarginLeft = 7.2.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginRight = 7.2.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginTop = 3.6.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginBottom = 3.6.ToFloat();
            _mySelection.ShapeRange.LockAnchor = 0;
            _mySelection.ShapeRange.LayoutInCell = -1;
            _mySelection.ShapeRange.WrapFormat.AllowOverlap = -1;
            _mySelection.ShapeRange.WrapFormat.Side = WdWrapSideType.wdWrapBoth;
            _mySelection.ShapeRange.WrapFormat.DistanceTop = _mySelection.Application.InchesToPoints(0);
            _mySelection.ShapeRange.WrapFormat.DistanceBottom = _mySelection.Application.InchesToPoints(0);
            _mySelection.ShapeRange.WrapFormat.DistanceLeft = _mySelection.Application.InchesToPoints(0.13.ToFloat());
            _mySelection.ShapeRange.WrapFormat.DistanceRight = _mySelection.Application.InchesToPoints(0.13.ToFloat());
            _mySelection.ShapeRange.WrapFormat.Type = WdWrapType.wdWrapNone;
            _mySelection.ShapeRange.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendToBack);
            _mySelection.ShapeRange.TextFrame.AutoSize = 0;
            _mySelection.ShapeRange.TextFrame.WordWrap = -1;
            _mySelection.ShapeRange.TextFrame.VerticalAnchor = Microsoft.Office.Core.MsoVerticalAnchor.msoAnchorTop;
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

            //Ubah Ukuran Gambar
            _mySelection.ShapeRange.ScaleWidth(
                  0.75.ToFloat(),
                  Microsoft.Office.Core.MsoTriState.msoFalse,
                  Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft
            );

            //Browse path Stempel
            if (pathCap == "" || pathCap == null)
            {
                _mySelection.Range.InlineShapes.AddPicture(FileName: @"C:\Program Files\Stempel\Stempel.png", LinkToFile: false, SaveWithDocument: true);
            }
            else
            {
                _mySelection.Range.InlineShapes.AddPicture(FileName: pathStempel, LinkToFile: false, SaveWithDocument: true);
            }

            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.RightIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.SpaceBefore = 0;
            _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
            _mySelection.ParagraphFormat.SpaceAfter = 0;
            _mySelection.ParagraphFormat.SpaceAfterAuto = 0;
            _mySelection.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            _mySelection.ParagraphFormat.WidowControl = -1;
            _mySelection.ParagraphFormat.KeepWithNext = 0;
            _mySelection.ParagraphFormat.KeepTogether = 0;
            _mySelection.ParagraphFormat.PageBreakBefore = 0;
            _mySelection.ParagraphFormat.NoLineNumber = 0;
            _mySelection.ParagraphFormat.Hyphenation = -1;
            _mySelection.ParagraphFormat.FirstLineIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.OutlineLevel = WdOutlineLevel.wdOutlineLevelBodyText;
            _mySelection.ParagraphFormat.CharacterUnitLeftIndent = 0;
            _mySelection.ParagraphFormat.CharacterUnitRightIndent = 0;
            _mySelection.ParagraphFormat.CharacterUnitFirstLineIndent = 0;
            _mySelection.ParagraphFormat.LineUnitBefore = 0;
            _mySelection.ParagraphFormat.LineUnitAfter = 0;
            _mySelection.ParagraphFormat.MirrorIndents = 0;
            _mySelection.ParagraphFormat.TextboxTightWrap = WdTextboxTightWrap.wdTightNone;

        }

        public static void PageNumbering(
            string prosesAktaSelected,
            bool capSelected,
            string posisiNomorHalaman,
            string rataPosisiHalaman,
            string jumlahHalaman,
            string barisJudul,
            string posisiCap)
        {
            // PageNumbering Macro
            double x = 0;
            double y = 0;

            int pg = _mySelection.Range.Information[WdInformation.wdActiveEndAdjustedPageNumber];
            var FSize = fontSize;
            var FName = fontName;
            var pg_end = jumlahHalaman.ToInteger();
            var endpage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //totalPage

            SettingEnum.PosisiVertikalNomorHalaman posisiNomorHalamanValue = (SettingEnum.PosisiVertikalNomorHalaman)Enum.Parse(typeof(SettingEnum.PosisiVertikalNomorHalaman), posisiNomorHalaman.Replace(" ", ""));
            if (posisiNomorHalamanValue == SettingEnum.PosisiVertikalNomorHalaman.TanpaNomer)
                return;

            SettingEnum.PosisiHorisontalNomorHalaman rataPosisiHalamanValue = (SettingEnum.PosisiHorisontalNomorHalaman)Enum.Parse(typeof(SettingEnum.PosisiHorisontalNomorHalaman), rataPosisiHalaman.Replace(" ", ""));
            var zlbr = 75;

            if (posisiNomorHalamanValue == SettingEnum.PosisiVertikalNomorHalaman.Bawah)
            {

                if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataTengah)
                {
                    x = (_myDocument.PageSetup.PageWidth / (double)2) + zlbr;// 50
                }
                if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataKanan)
                {
                    x = (_myDocument.PageSetup.PageWidth / (double)4) * 3 + zlbr;// 50
                }
                y = _myDocument.PageSetup.PageHeight - 50; // 75

            }

            else if (pg == 1)
            {

                if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataTengah)
                {
                    x = (_myDocument.PageSetup.PageWidth / (double)2) + zlbr;// 50
                }
                if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataKanan)
                {
                    x = (_myDocument.PageSetup.PageWidth / (double)4) * 3 + zlbr;// 50
                }
                y = _myDocument.PageSetup.PageHeight - 50; // 75

            }

            else
            {

                if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataTengah)
                {
                    x = (_myDocument.PageSetup.PageWidth / (double)2) + zlbr;
                }
                if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataKanan)
                {
                    x = (_myDocument.PageSetup.PageWidth / (double)4) * 3 + zlbr;// 50
                }
                y = 25;

            }

            _myDocument.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, x.ToFloat(), y.ToFloat(), 54, 27).Select();
            _mySelection.ShapeRange.TextFrame.TextRange.Select();
            _mySelection.Collapse();

            if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataTengah)
            {
                _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            if (rataPosisiHalamanValue == SettingEnum.PosisiHorisontalNomorHalaman.RataKanan)
            {
                _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            }

            _mySelection.Font.Name = FName;
            _mySelection.Font.Bold = 0;
            _mySelection.Font.Underline = 0;
            _mySelection.TypeText(Text: pg.ToString());
            _mySelection.ShapeRange.Select();
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.Fill.Solid();
            _mySelection.ShapeRange.Fill.Transparency = 0;
            _mySelection.ShapeRange.Fill.BackColor.RGB = ColorTranslator.ToWin32(Color.White);
            _mySelection.ShapeRange.Fill.ForeColor.RGB = ColorTranslator.ToWin32(Color.White);
            _mySelection.ShapeRange.Line.Weight = 0.75.ToFloat();
            _mySelection.ShapeRange.Line.DashStyle = Microsoft.Office.Core.MsoLineDashStyle.msoLineSolid;
            _mySelection.ShapeRange.Line.Style = Microsoft.Office.Core.MsoLineStyle.msoLineSingle;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.Collapse();

        }

        public static void CapTengahPage(int jumlahPage)
        {
            var pageCenter = jumlahPage / 2;
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToFirst, Count: pageCenter, Name: "");
            Cap();

        }

        public static void CapAllPage()
        {
            Cap();
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Count: 1, Name: "");
        }

        public static void getPathCap(string pathCapSelected)
        {
            pathCap = pathCapSelected;
        }

        public static void Cap()
        {
            // Cap Macro
            _myDocument.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 25, 24, 140, 46).Select();
            _mySelection.ShapeRange.TextFrame.TextRange.Select();
            _mySelection.Collapse();
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            _mySelection.ShapeRange.Fill.Solid();
            _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.Fill.Transparency = 0;
            _mySelection.ShapeRange.Line.Weight = 0.75.ToFloat();
            _mySelection.ShapeRange.Line.DashStyle = Microsoft.Office.Core.MsoLineDashStyle.msoLineSolid;
            _mySelection.ShapeRange.Line.Style = Microsoft.Office.Core.MsoLineStyle.msoLineSingle;
            _mySelection.ShapeRange.Line.Transparency = 0;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            _mySelection.ShapeRange.Line.ForeColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.Line.BackColor.RGB = ColorTranslator.ToWin32(Color.Black);
            _mySelection.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.TextFrame.MarginLeft = 7.2.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginRight = 7.2.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginTop = 3.6.ToFloat();
            _mySelection.ShapeRange.TextFrame.MarginBottom = 3.6.ToFloat();
            _mySelection.ShapeRange.LockAnchor = 0;
            _mySelection.ShapeRange.LayoutInCell = -1;
            _mySelection.ShapeRange.WrapFormat.AllowOverlap = -1;
            _mySelection.ShapeRange.WrapFormat.Side = WdWrapSideType.wdWrapBoth;
            _mySelection.ShapeRange.WrapFormat.DistanceTop = _mySelection.Application.InchesToPoints(0);
            _mySelection.ShapeRange.WrapFormat.DistanceBottom = _mySelection.Application.InchesToPoints(0);
            _mySelection.ShapeRange.WrapFormat.DistanceLeft = _mySelection.Application.InchesToPoints(0.13.ToFloat());
            _mySelection.ShapeRange.WrapFormat.DistanceRight = _mySelection.Application.InchesToPoints(0.13.ToFloat());
            _mySelection.ShapeRange.WrapFormat.Type = WdWrapType.wdWrapNone;
            _mySelection.ShapeRange.ZOrder(Microsoft.Office.Core.MsoZOrderCmd.msoSendToBack);
            _mySelection.ShapeRange.TextFrame.AutoSize = 0;
            _mySelection.ShapeRange.TextFrame.WordWrap = -1;
            _mySelection.ShapeRange.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            _mySelection.ShapeRange.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

            if (pathCap == "" || pathCap == null)
            {
                _mySelection.Range.InlineShapes.AddPicture(FileName: @"C:\Program Files\Stempel\Cap.png", LinkToFile: false, SaveWithDocument: true);
            }
            else
            {
                _mySelection.Range.InlineShapes.AddPicture(FileName: pathCap, LinkToFile: false, SaveWithDocument: true);
            }

            _mySelection.ParagraphFormat.LeftIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.RightIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.SpaceBefore = 0;
            _mySelection.ParagraphFormat.SpaceBeforeAuto = 0;
            _mySelection.ParagraphFormat.SpaceAfter = 0;
            _mySelection.ParagraphFormat.SpaceAfterAuto = 0;
            _mySelection.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
            _mySelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            _mySelection.ParagraphFormat.WidowControl = -1;
            _mySelection.ParagraphFormat.KeepWithNext = 0;
            _mySelection.ParagraphFormat.KeepTogether = 0;
            _mySelection.ParagraphFormat.PageBreakBefore = 0;
            _mySelection.ParagraphFormat.NoLineNumber = 0;
            _mySelection.ParagraphFormat.Hyphenation = -1;
            _mySelection.ParagraphFormat.FirstLineIndent = _mySelection.Application.InchesToPoints(0);
            _mySelection.ParagraphFormat.OutlineLevel = WdOutlineLevel.wdOutlineLevelBodyText;
            _mySelection.ParagraphFormat.CharacterUnitLeftIndent = 0;
            _mySelection.ParagraphFormat.CharacterUnitRightIndent = 0;
            _mySelection.ParagraphFormat.CharacterUnitFirstLineIndent = 0;
            _mySelection.ParagraphFormat.LineUnitBefore = 0;
            _mySelection.ParagraphFormat.LineUnitAfter = 0;
            _mySelection.ParagraphFormat.MirrorIndents = 0;
            _mySelection.ParagraphFormat.TextboxTightWrap = WdTextboxTightWrap.wdTightNone;
        }

        public static void Garis(
            string chkWarnaGarisTepi,
            string panjangGarisAtasSelected,
            string sudutGarisAtasSelected,
            string posisiGarisAtasSelected,
            string panjangGarisBawahSelected,
            string sudutGarisBawahSelected,
            string posisiGarisBawahSelected
            )
        {

            Upline(
                chkWarnaGarisTepi,
                panjangGarisAtasSelected.ToFloat(),
                sudutGarisAtasSelected.ToFloat(),
                posisiGarisAtasSelected.ToFloat()
                );
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Count: 1, Name: ""); // lakukan per page 
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(Unit: WdUnits.wdLine);
            _mySelection.MoveUp(Unit: WdUnits.wdLine, Count: 1);
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

            Downline(
                chkWarnaGarisTepi,
                panjangGarisBawahSelected.ToFloat(),
                sudutGarisBawahSelected.ToFloat(),
                posisiGarisBawahSelected.ToFloat()
                );
            _mySelection.GoTo(What: WdGoToItem.wdGoToPage, Which: WdGoToDirection.wdGoToNext, Count: 1, Name: "");
            _mySelection.Find.ClearFormatting();
            _mySelection.HomeKey(Unit: WdUnits.wdLine);

        }

        public static void GetTextSesuaiSelect()
        {
            txtSelect = string.Empty;
            if (_mySelection != null && _mySelection.Range != null)
            {
                txtSelect = _mySelection.Text;
            }

        }

        public static void AddTextAwalCursor()
        {
            var cursor = Cursor.Position;
            Console.WriteLine(cursor);

            //dapatkan posisi cursor
            var y = _mySelection.Range;

            if (txtSelect != null)
            {
                y.Text = txtSelect;
            }
            y.Text = txtSelect;
        }

        public static void GarisDatarTegakBawah()
        {

            //_mySelection.StartOf(WdUnits.wdParagraph, WdMovementType.wdMove); // Pindah Ke Posisi Awal Paragraph
            _mySelection.HomeKey(WdUnits.wdStory, WdMovementType.wdMove); // Pindah ke Awal Document (Awal kata paling awal)
            _mySelection.Bookmarks.Add("Awal"); //Set Bookmark awal cursor       

            int totalPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument]; //Hitung Jumlah Page
            int activePage = _mySelection.Information[WdInformation.wdActiveEndPageNumber]; //Mengetahui Kursor Aktif di Page Berapa
            int pointerLineAwal = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber]; //Mengetahui Line number yang aktif di kursor

            _mySelection.EndKey(WdUnits.wdStory, WdMovementType.wdMove);
            _mySelection.Bookmarks.Add("Akhir");
            int pointerLineAkhir = _mySelection.Information[WdInformation.wdFirstCharacterLineNumber];

            //Looping Setiap Page mulai dari bookmark awal
            _mySelection.GoTo(What: WdGoToItem.wdGoToBookmark, Name: "Awal");

            var jumlahPage = _mySelection.Information[WdInformation.wdNumberOfPagesInDocument];

            GarisVertikal(warnaGarisTepi);

            var counter = 0;
            while (counter < jumlahPage)
            {
                //Garis(warnaGarisTepi);
                //counter = counter + 1;
            }

            _mySelection.GoTo(What: WdGoToItem.wdGoToBookmark, Name: "Akhir");

            //Delete Bookmark yang baru di buat.
            if (_mySelection.Bookmarks.Exists("Awal"))
                _mySelection.Bookmarks["Awal"].Delete();

            if (_mySelection.Bookmarks.Exists("Akhir"))
                _mySelection.Bookmarks["Akhir"].Delete();

        }

        public static void PrintDocTest()
        {

            PrintDialog pDialog = new PrintDialog();//Print Dialog

            pDialog.AllowSomePages = true; // Atur Range Halaman True
            pDialog.AllowCurrentPage = true;
            pDialog.ShowHelp = true;//Tampilkan Tombol Bantuan
            pDialog.AllowSelection = true;


            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.ThisAddIn.Application.ActivePrinter = pDialog.PrinterSettings.PrinterName;
                _myDocument.PrintOut(); //Print Document
            }

        }

        public static void PrintDocDialogs()
        {

            var x = _Dialogs[WdWordDialog.wdDialogFilePrintSetup];
            _Dialogs[WdWordDialog.wdDialogFilePrint].Show();

        }

    }
}
