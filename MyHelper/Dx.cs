using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace MyHelper
{
    public class Dx
    {


        public static System.Windows.Forms.CheckState GetValueCheked(bool value)
        {
            switch (value)
            {
                case true:
                    return CheckState.Checked;
                case false:
                    return CheckState.Unchecked;
                default:
                    return CheckState.Indeterminate;
            }

        }

        // Colom Must HaveValue
        public static bool ValidasiValueGrid(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, params string[] namaField)
        {
            int tempI = 1;

            if (namaGridView.OptionsView.NewItemRowPosition == DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom)
                tempI = 2;

            for (int i = 0; i <= namaGridView.RowCount - tempI; i++)
            {
                foreach (var item in namaField)
                {

                    if ((namaGridView.GetRowCellValue(i, item)).IsNullOrZero())
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(namaGridView.Columns[item].Caption + " TIDAK BOLEH KOSONG", "PERHATIAN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        namaGridView.FocusedRowHandle = i;
                        namaGridView.FocusedColumn = namaGridView.Columns[item];
                        namaGridView.Focus();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ValidasiValueGrid(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView namaGridView, params string[] namaField)
        {
            int tempI = 1;

            if (namaGridView.OptionsView.NewItemRowPosition == DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom)
                tempI = 2;

            for (int i = 0; i <= namaGridView.RowCount - tempI; i++)
            {
                foreach (var item in namaField)
                {

                    if ((namaGridView.GetRowCellValue(i, item)).IsNullOrZero())
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(namaGridView.Columns[item].Caption + " TIDAK BOLEH KOSONG", "PERHATIAN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        namaGridView.FocusedRowHandle = i;
                        namaGridView.FocusedColumn = namaGridView.Columns[item];
                        namaGridView.Focus();
                        return true;
                    }
                }
            }
            return false;
        }

        // Min Record
        public static bool ValidasiGridMinRecord(DevExpress.XtraGrid.Views.Grid.GridView namaGridView)
        {
            if (namaGridView.RowCount == 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("DATA MASIH KOSONG MIN ISI 1 DATA RECORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                namaGridView.Focus();
                return true;
            }
            return false;
        }

        public static bool ValidasiGridMinRecord(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView namaGridView)
        {

            if (namaGridView.OptionsView.NewItemRowPosition != DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None && namaGridView.RowCount == 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("DATA MASIH KOSONG MIN ISI 1 DATA RECORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                namaGridView.Focus();
                return true;
            }
            else if (namaGridView.RowCount == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("DATA MASIH KOSONG MIN ISI 1 DATA RECORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                namaGridView.Focus();
                return true;
            }

            return false;
        }

        // Duplicate Row
        public static void ValidasiDuplicateRow(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string NamaRow)
        {

            string value = Convert.ToString(namaGridView.GetFocusedRowCellValue(NamaRow));

            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (i != namaGridView.FocusedRowHandle && value == Convert.ToString(namaGridView.GetRowCellValue(i, NamaRow)))
                {

                    if (value.IsEmpty())
                        InfoErrorDx("Data Kosong");
                    else
                    {
                        InfoErrorDx("DUPLICATE DATA");
                        namaGridView.DeleteSelectedRows();
                    }
                    namaGridView.FocusedRowHandle = i;
                    break;
                }

            }

        }

        public static bool IsDuplicateRow(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string namaRow)
        {
            string value = Convert.ToString(namaGridView.GetFocusedRowCellValue(namaRow));

            // Jika Kosong Abaikan
            if (string.IsNullOrEmpty(value)) return false;

            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (i != namaGridView.FocusedRowHandle && value == Convert.ToString(namaGridView.GetRowCellValue(i, namaRow)))
                    return true;
            }

            return false;
        }

        public static void ValidasiDuplicateRow(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView namaGridView, string NamaRow, out bool isReCount)
        {
            string Value = Convert.ToString(namaGridView.GetFocusedRowCellValue(NamaRow));
            isReCount = false;
            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (i != namaGridView.FocusedRowHandle & Value == Convert.ToString(namaGridView.GetRowCellValue(i, NamaRow)))
                {
                    InfoErrorDx("DUPLICATE DATA");
                    namaGridView.DeleteSelectedRows();
                    isReCount = true;
                    namaGridView.FocusedRowHandle = i;
                    break;
                }
            }
        }

        public static void ValidasiDuplicateRow(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string NamaRow, out bool isReCount)
        {
            string Value = Convert.ToString(namaGridView.GetFocusedRowCellValue(NamaRow));
            isReCount = false;
            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (i != namaGridView.FocusedRowHandle & Value == Convert.ToString(namaGridView.GetRowCellValue(i, NamaRow)))
                {
                    InfoErrorDx("DUPLICATE DATA");
                    namaGridView.DeleteSelectedRows();
                    isReCount = true;
                    namaGridView.FocusedRowHandle = i;
                    break;
                }
            }
        }

        public static void CekTampilanGudang(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, DevExpress.XtraEditors.CheckEdit chkGudang)
        {
            if (namaGridView.Columns["Gudang"].Visible)
                chkGudang.CheckState = CheckState.Checked;
            else
                chkGudang.CheckState = CheckState.Unchecked;            
        }

        public static bool ValidasiControlDx(object NamaObject, string InfoCaption, bool IsQuestion = false)
        {
            var obj = (DevExpress.XtraEditors.BaseEdit)NamaObject;

            if (obj.EditValue.IsNullOrZero())
            {
                if (IsQuestion)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show(InfoCaption + " MASIH KOSONG, LANJUT SIMPAN ?", "VALIDASI DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        obj.Focus();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(InfoCaption + " HARUS DI ISI", "VALIDASI DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    obj.Focus();
                    return true;
                }
            }
            return false;
        }

        public static bool ValidasiControlDx(object NamaObject)
        {
            var obj = (DevExpress.XtraEditors.BaseEdit)NamaObject;

            if (obj.EditValue.IsNullOrZero())
                return false;
            else
                return true;
        }

        public static void UrutkanNoGrid(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string NamaColNo = "No")
        {
            for (int Index = 0; Index <= namaGridView.RowCount - 1; Index++)
            {
                namaGridView.SetRowCellValue(Index, NamaColNo, Index + 1);
            }
        }

        public static void ValidasiColomSatuan(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, int jmlSatuan)
        {
            if (jmlSatuan <= 1)
            {
                DisableCol(namaGridView, "IdSatuan");
                DisableCol(namaGridView, "Satuan");
            }
            else
            {
                EnableCol(namaGridView, "IdSatuan");
                EnableCol(namaGridView, "Satuan", true);
            }
        }

        public static void FindPanel(DevExpress.XtraGrid.Views.Grid.GridView namaGridView)
        {
            if (namaGridView.IsFindPanelVisible == true)
            {
                namaGridView.HideFindPanel();
            }
            else
            {
                namaGridView.ShowFindPanel();
            }
        }

        public static void FilterPanel(DevExpress.XtraGrid.Views.Grid.GridView namaGridView)
        {
            if (namaGridView.OptionsView.ShowAutoFilterRow == true)
            {
                namaGridView.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                namaGridView.OptionsView.ShowAutoFilterRow = true;
            }
        }

        public static void KolomPanel(DevExpress.XtraGrid.Views.Grid.GridView namaGridView)
        {
            if (namaGridView.CustomizationForm == null)
            {
                namaGridView.ShowCustomization();
            }
            else if (namaGridView.CustomizationForm.Visible == false)
            {
                namaGridView.ShowCustomization();
            }
            else
            {
                namaGridView.HideCustomization();
            }
        }

        public static void SummaryFotter(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, bool IsShow)
        {
            if (IsShow == true)
            {
                namaGridView.OptionsView.ShowFooter = true;
            }
            else
            {
                namaGridView.OptionsView.ShowFooter = false;
            }
        }

        public static void LastClik(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, int KodeIndex)
        {
            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (KodeIndex == Convert.ToInt32(namaGridView.GetRowCellValue(i, "Id")))
                {
                    namaGridView.FocusedRowHandle = i;
                }
            }
        }

        public static void LastRecordUpdate(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, int IdFocus, string NamaCol)
        {
            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (IdFocus == namaGridView.GetRowCellValue(i, NamaCol).ToInteger())
                {
                    namaGridView.FocusedRowHandle = i;
                    break;
                }
            }
        }

        public static void LastRecordUpdate(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string IdFocus, string NamaCol)
        {
            for (int i = 0; i <= namaGridView.RowCount - 1; i++)
            {
                if (IdFocus == (namaGridView.GetRowCellValue(i, NamaCol)).ToString())
                {
                    namaGridView.FocusedRowHandle = i;
                    break;
                }
            }
        }

        public static void IsBandvisible(DevExpress.XtraGrid.Views.BandedGrid.GridBand namaBandGrid, bool isVisible)
        {
            if (isVisible)
                namaBandGrid.Visible = true;
            else
                namaBandGrid.Visible = false;
        }

        public static void IsColomVisible(DevExpress.XtraGrid.Views.Grid.GridView namaGrid, bool isVisible, string namaColum)
        {
            if (!namaColum.IsEmpty())
            {
                if (isVisible)
                    namaGrid.Columns[namaColum].Visible = true;
                else
                    namaGrid.Columns[namaColum].Visible = false;
            }
        }

        public static void EmbededNavigatorOn(DevExpress.XtraGrid.GridControl NamaGridContorl)
        {
            NamaGridContorl.UseEmbeddedNavigator = true;
            NamaGridContorl.EmbeddedNavigator.Buttons.Append.Visible = false;
            NamaGridContorl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            NamaGridContorl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            NamaGridContorl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            NamaGridContorl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;

        }


        //public static void DisableCol(DevExpress.XtraGrid.Views.Grid.GridView NamaGrid, string NamaCol)
        //{
        //    if (!NamaGrid.Columns[NamaCol].IsEmpty())
        //    {
        //        NamaGrid.Columns[NamaCol].OptionsColumn.AllowEdit = false;
        //        NamaGrid.Columns[NamaCol].OptionsColumn.AllowFocus = false;
        //        NamaGrid.Columns[NamaCol].OptionsColumn.ReadOnly = true;
        //    }
        //}

        public static void SetFormatString(DevExpress.XtraGrid.Views.Grid.GridView namaGrid, string formatstr, params string[] namaCol)
        {
            foreach (var item in namaCol)
                namaGrid.Columns[item].DisplayFormat.FormatString = formatstr;
        }


        public static void DisableCol(DevExpress.XtraGrid.Views.Grid.GridView NamaGrid, params string[] NamaCol)
        {
            foreach (var item in NamaCol)
            {
                if (!NamaGrid.Columns[item].IsEmpty())
                {
                    NamaGrid.Columns[item].OptionsColumn.AllowEdit = false;
                    NamaGrid.Columns[item].OptionsColumn.AllowFocus = false;
                    NamaGrid.Columns[item].OptionsColumn.ReadOnly = true;
                }
            }
        }



        public static void DisableCol(DevExpress.XtraGrid.Views.Grid.GridView NamaGrid, int IndexCol)
        {
            if (!NamaGrid.Columns[IndexCol].IsEmpty())
            {
                NamaGrid.Columns[IndexCol].OptionsColumn.AllowEdit = false;
                NamaGrid.Columns[IndexCol].OptionsColumn.AllowFocus = false;
                NamaGrid.Columns[IndexCol].OptionsColumn.ReadOnly = true;
            }
        }

        public static void EnableCol(DevExpress.XtraGrid.Views.Grid.GridView NamaGrid, string NamaCol, bool OnlyFocus = false)
        {

            if (!NamaGrid.Columns[NamaCol].IsEmpty())
            {
                if (!OnlyFocus)
                {
                    NamaGrid.Columns[NamaCol].OptionsColumn.AllowEdit = true;
                    NamaGrid.Columns[NamaCol].OptionsColumn.ReadOnly = false;
                }

                NamaGrid.Columns[NamaCol].OptionsColumn.AllowFocus = true;

            }
        }

        public static void EnableCol(DevExpress.XtraGrid.Views.Grid.GridView NamaGrid, bool OnlyFocus, params string[] NamaCol)
        {

            foreach (var item in NamaCol)
            {
                if (!NamaGrid.Columns[item].IsEmpty())
                {
                    if (!OnlyFocus)
                    {
                        NamaGrid.Columns[item].OptionsColumn.AllowEdit = true;
                        NamaGrid.Columns[item].OptionsColumn.ReadOnly = false;
                    }

                    NamaGrid.Columns[item].OptionsColumn.AllowFocus = true;

                }
            }


        }

        public static void EnableCol(DevExpress.XtraGrid.Views.Grid.GridView NamaGrid, int IndexCol, bool OnlyFocus = false)
        {

            if (!NamaGrid.Columns[IndexCol].IsEmpty())
            {
                if (!OnlyFocus)
                {
                    NamaGrid.Columns[IndexCol].OptionsColumn.AllowEdit = true;
                    NamaGrid.Columns[IndexCol].OptionsColumn.ReadOnly = false;
                }

                NamaGrid.Columns[IndexCol].OptionsColumn.AllowFocus = true;

            }
        }

        public static void LockGrid(DevExpress.XtraGrid.Views.Grid.GridView namaGridView)
        {
            namaGridView.OptionsCustomization.AllowColumnMoving = false;
            namaGridView.OptionsMenu.EnableColumnMenu = false;
            namaGridView.OptionsCustomization.AllowSort = false;
        }

        public static void UnLockGrid(DevExpress.XtraGrid.Views.Grid.GridView namaGridView)
        {
            namaGridView.OptionsCustomization.AllowColumnMoving = true;
            namaGridView.OptionsMenu.EnableColumnMenu = true;
        }




        //public static void InfoError(string Note = "")
        //{
        //    if (string.IsNullOrEmpty(Note))
        //        Note = "ADA ERROR HUB PROGRAMER : 0815-8899-672 (MARTIN)";
        //    MessageBox.Show(Note, "BRASIL SOFTWARE DEVLOPMENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //public static void InfoBerhasil(string Note = "")
        //{
        //    if (string.IsNullOrEmpty(Note))
        //        Note = "SUKSES PROSES DATA";
        //    MessageBox.Show(Note, "BRASIL SOFTWARE DEVLOPMENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        public static void InfoBerhasilDx(string Note = "", string Judul = "")
        {
            if (string.IsNullOrEmpty(Note))
                Note = "SUKSES PROSES DATA";
            if (string.IsNullOrEmpty(Judul))
                Judul = "MARTINO SOFT";
            DevExpress.XtraEditors.XtraMessageBox.Show(Note, Judul, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void InfoErrorDx(string Note = "", string Judul = "")
        {
            if (string.IsNullOrEmpty(Note))
                Note = "ADA ERROR HUB PROGRAMER : 0815-8899-672 (MARTIN)";
            if (string.IsNullOrEmpty(Judul))
                Judul = "MARTINO SOFT";
            DevExpress.XtraEditors.XtraMessageBox.Show(Note, Judul, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void InfoWarningDx(string Note = "", string Judul = "")
        {
            if (string.IsNullOrEmpty(Note))
                Note = "ILLEGAL ACTION";
            if (string.IsNullOrEmpty(Judul))
                Judul = "MARTINO SOFT";
            DevExpress.XtraEditors.XtraMessageBox.Show(Note, Judul, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool InfoQuestionDx(string note, string judul = "")
        {
            if (string.IsNullOrEmpty(judul))
                judul = "Martino Soft";

            if (DevExpress.XtraEditors.XtraMessageBox.Show(note, judul, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return false;
            else
                return true;

        }


        #region "LAYOUT"

        //public static void SaveLayOut(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string Namafrm)
        //{
        //    if (!Directory.Exists("MyLayout"))
        //        Directory.CreateDirectory("MyLayout");
        //    StringBuilder LayoutName = new StringBuilder();
        //    LayoutName = LayoutName.Append("Mylayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
        //    namaGridView.SaveLayoutToXml(LayoutName.ToString());
        //}

        //public static void SaveLayOut(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView namaGridView, string Namafrm)
        //{
        //    if (!Directory.Exists("MyLayout"))
        //        Directory.CreateDirectory("MyLayout");
        //    StringBuilder LayoutName = new StringBuilder();
        //    LayoutName = LayoutName.Append("Mylayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
        //    namaGridView.SaveLayoutToXml(LayoutName.ToString());
        //}

        //public static void DeleteLayOut(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string Namafrm)
        //{
        //    StringBuilder LocFile = new StringBuilder();
        //    LocFile = LocFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
        //    File.Delete(LocFile.ToString());
        //}

        //public static void DeleteLayOut(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView namaGridView, string Namafrm)
        //{
        //    StringBuilder LocFile = new StringBuilder();
        //    LocFile = LocFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
        //    File.Delete(LocFile.ToString());
        //}

        //public static void LoadLayOut(DevExpress.XtraGrid.Views.Grid.GridView namaGridView, string Namafrm)
        //{
        //    StringBuilder NamaFile = new StringBuilder();
        //    NamaFile = NamaFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
        //    if (File.Exists(NamaFile.ToString()))
        //        namaGridView.RestoreLayoutFromXml(NamaFile.ToString());
        //}

        //public static void LoadLayOut(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView namaGridView, string Namafrm)
        //{
        //    StringBuilder NamaFile = new StringBuilder();
        //    NamaFile = NamaFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
        //    if (File.Exists(NamaFile.ToString()))
        //        namaGridView.RestoreLayoutFromXml(NamaFile.ToString());
        //}

        //Send As Object

        public static bool IsLoadLayOut(object GridView, string Namafrm)
        {
            var namaGridView = (DevExpress.XtraGrid.Views.Base.BaseView)GridView;
            StringBuilder NamaFile = new StringBuilder();
            NamaFile = NamaFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
            if (File.Exists(NamaFile.ToString()))
                return true;
            else
                return false;
        }

        public static void LoadLayOut(object GridView, string Namafrm)
        {
            var namaGridView = (DevExpress.XtraGrid.Views.Base.BaseView)GridView;
            StringBuilder NamaFile = new StringBuilder();
            NamaFile = NamaFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
            if (File.Exists(NamaFile.ToString()))
                namaGridView.RestoreLayoutFromXml(NamaFile.ToString());
        }

        public static void SaveLayOut(object GridView, string Namafrm)
        {
            var namaGridView = (DevExpress.XtraGrid.Views.Base.BaseView)GridView;
            if (!Directory.Exists("MyLayout"))
                Directory.CreateDirectory("MyLayout");
            StringBuilder LayoutName = new StringBuilder();
            LayoutName = LayoutName.Append("Mylayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
            namaGridView.SaveLayoutToXml(LayoutName.ToString());
        }

        public static void DeleteLayOut(object GridView, string Namafrm)
        {
            var namaGridView = (DevExpress.XtraGrid.Views.Base.BaseView)GridView;
            StringBuilder LocFile = new StringBuilder();
            LocFile = LocFile.Append("MyLayout\\").Append("Lay").Append(Namafrm).Append(namaGridView.Name).Append(".xml");
            File.Delete(LocFile.ToString());
        }


        public static void SavePivot(DevExpress.XtraPivotGrid.PivotGridControl namaPivot, string namaFrm)
        {
            if (!Directory.Exists("MyLayout"))
                Directory.CreateDirectory("MyLayout");
            StringBuilder info = new StringBuilder();
            info.Append("Mylayout\\").Append("LayPvt").Append(namaFrm).Append(namaPivot).Append(".xml");
            namaPivot.SaveLayoutToXml(info.ToString());
        }

        public static void LoadPivot(DevExpress.XtraPivotGrid.PivotGridControl namaPivot, string namaFrm)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Mylayout\\").Append("LayPvt").Append(namaFrm).Append(namaPivot).Append(".xml");
            if (File.Exists(info.ToString()))
                namaPivot.RestoreLayoutFromXml(info.ToString());

        }

        public static void DeletePivot(DevExpress.XtraPivotGrid.PivotGridControl namaPivot, string namaFrm)
        {
            StringBuilder info = new StringBuilder();
            info.Append("Mylayout\\").Append("LayPvt").Append(namaFrm).Append(namaPivot).Append(".xml");
            File.Delete(info.ToString());
        }


        #endregion

    }
}
