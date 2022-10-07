using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyHelper
{
    public class MyForm
    {
        

        private DevExpress.XtraEditors.XtraForm _frmAktif;

        public MyForm(DevExpress.XtraEditors.XtraForm frmAktif)
        {
            _frmAktif = frmAktif;
        }

        public static void CloseAllFrm(Form mdiparent)
        {
            foreach (var frm in mdiparent.MdiChildren)
            {
                frm.Close();
            }
        }

        public static void ShowForm(Type tipe, object mdiparent)
        {
            var mdiparentcast = (DevExpress.XtraEditors.XtraForm)mdiparent;
            DevExpress.XtraEditors.XtraForm form = default(DevExpress.XtraEditors.XtraForm);

            if (mdiparentcast.MdiChildren.Any(x => x.GetType() == tipe))
            {
                form = (DevExpress.XtraEditors.XtraForm)Convert.ChangeType(mdiparentcast.MdiChildren.First(x => x.GetType() == tipe), tipe);
            }
            else
            {
                form = (DevExpress.XtraEditors.XtraForm)Convert.ChangeType(Activator.CreateInstance(tipe), tipe);
            }

            form.MdiParent = (DevExpress.XtraEditors.XtraForm)mdiparent;
            form.Show();
            form.BringToFront();

        }

        public static void ShowDialogForm(Type tipe)
        {
            DevExpress.XtraEditors.XtraForm form;
            form = (DevExpress.XtraEditors.XtraForm)Convert.ChangeType(Activator.CreateInstance(tipe), tipe);
            form.ShowDialog();
        }

        public bool CekEmptyContorl()
        {
            var controls = GetAllControls(_frmAktif);
            foreach (Control item in controls.OrderBy(x => x.TabIndex))
            {
                if (item is ComboBoxEdit)
                {
                    var ctr = (item as ComboBoxEdit);
                    if (ctr.Text == string.Empty)
                    {
                        ctr.Focus();
                        Dx.InfoWarningDx(ctr.Tag.ToString() + " Harus di Isi");
                        return true;
                    }
                }
                else if (item is SearchLookUpEdit)
                {
                    var ctr = (item as DevExpress.XtraEditors.SearchLookUpEdit);
                    if (!ctr.EditValue.IsNotEmpty())
                    {
                        ctr.Focus();
                        Dx.InfoWarningDx(ctr.Tag.ToString() + " Harus di Isi");
                        return true;
                    }
                }
                else if (item is TextEdit)
                {
                    var ctr = (item as DevExpress.XtraEditors.TextEdit);
                    if (ctr.Text == string.Empty)
                    {
                        ctr.Focus();
                        Dx.InfoWarningDx(ctr.Tag.Safe().ToString() + " Harus di Isi");
                        return true;
                    }
                }
                else if (item is DateEdit)
                {
                    var ctr = (item as DevExpress.XtraEditors.DateEdit);
                    if (ctr.EditValue == null)
                    {
                        ctr.Focus();
                        Dx.InfoWarningDx(ctr.Tag.Safe().ToString() + " Harus di Isi");
                        return true;
                    }
                }

            }
            return false;
        }


        public List<Control> GetAllControls()
        {
            GetAllControls(_frmAktif);
            return controls;
        }

        private List<Control> controls = new List<Control>();

        private List<Control> GetAllControls(Control parent)
        {

            foreach (Control control in parent.Controls)
            {


                if (control.HasChildren)
                {
                    controls.Add(control);
                    GetAllControls(control);
                }
                else
                    controls.Add(control);
            }
            return controls;
        }
    }
}
