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
using System.Diagnostics;

namespace HumanResource.zProject_CentralShareFolder
{
    public partial class FormCentralFolder : DevExpress.XtraEditors.XtraForm
    {
        public FormCentralFolder()
        {
            InitializeComponent();
        }

        private void btnITDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("IT", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnCentralFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // CentralFOlder ไม่ต้องมีพาสเวิร์ด

            string pathFolder = @"\\192.168.0.15\ShareFolder";

            Process.Start(@pathFolder);

            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            //FormPathFolder frm = Application.OpenForms["FormPathFolder"] as FormPathFolder;

            //frm = new FormPathFolder("Central@ubuntu", "โฟลเดอร์ส่วนกลาง");
            //frm.Name = "FormPathFolder";
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void btnManageDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Manage", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnTraditionalDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Traditional", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnDentalDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Dental", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnMedicineDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Medicine", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnLaboratoryDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Lab", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnPharmacyDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Pharma", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnPhysicalDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Physical", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnPCCDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("PCC", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnERDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("ER", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnIPDDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("IPD", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnOPDDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("OPD", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnNursingDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Nursing", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void btnPsychiatryDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("Psychiatry", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAccessFolder f = new FormAccessFolder("test", this);
            f.txtPassword.Focus();
            f.ShowDialog();
        }
    }
}