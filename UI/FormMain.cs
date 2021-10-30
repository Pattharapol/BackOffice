using BackOfficeApplication.DataCenter;
using HumanResource.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HumanResource
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            //GetConnectionString()
            DataAccess.GetConnectionString();
        }

        private void btnOffDutyMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormOffDuty frm = Application.OpenForms["FormOffDuty"] as FormOffDuty;
            if (frm != null)
                frm.Focus();
            else
            {
                frm = new FormOffDuty();
                frm.Name = "FormOffDuty";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnUpdateData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormUpdateData frm = Application.OpenForms["FormUpdateData"] as FormUpdateData;
            if (frm != null)
                frm.Focus();
            else
            {
                frm = new FormUpdateData();
                frm.Name = "FormUpdateData";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnOffDutyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormOffDutyReport frm = Application.OpenForms["FormOffDutyReport"] as FormOffDutyReport;
            if (frm != null)
                frm.Focus();
            else
            {
                frm = new FormOffDutyReport();
                frm.Name = "FormOffDutyReport";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnEditOffDuty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormTypeOfOffDuty frm = new FormTypeOfOffDuty();
            frm.ShowDialog();
        }

        private void btnServiceWorkerCheckIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormServiceWorkerReport frm = Application.OpenForms["FormServiceWorkerReport"] as FormServiceWorkerReport;
            if (frm != null)
                frm.Focus();
            else
            {
                frm = new FormServiceWorkerReport();
                frm.Name = "FormServiceWorkerReport";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormBackOfficeWorkerReport frm = Application.OpenForms["FormBackOfficeWorkerReport"] as FormBackOfficeWorkerReport;
            if (frm != null)
                frm.Focus();
            else
            {
                frm = new FormBackOfficeWorkerReport();
                frm.Name = "FormBackOfficeWorkerReport";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
            FormSupervisorReport frm = Application.OpenForms["FormSupervisorReport"] as FormSupervisorReport;
            if (frm != null)
                frm.Focus();
            else
            {
                frm = new FormSupervisorReport();
                frm.Name = "FormSupervisorReport";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void btnRandomCheckOfficer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRandomCheckOfficer f = new frmRandomCheckOfficer();
            f.ShowDialog();
        }
    }
}