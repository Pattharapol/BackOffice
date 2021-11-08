using BackOfficeApplication.DataCenter;
using BackOfficeApplication.Project_HR.Report;
using BackOfficeApplication.Project_MainMenu;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOfficeApplication.Project_HR.UI
{
    public partial class FormRandomCheckOfficer : DevExpress.XtraEditors.XtraForm
    {
        // เอาไว้ทำรายงานด้วย
        private DataTable dtResult = new DataTable();

        public FormRandomCheckOfficer()
        {
            InitializeComponent();

            // add column to DGV
            dtResult.Columns.Add("FULLNAME");
            dtResult.Columns.Add("CHECK_DATE");
            dtResult.Columns.Add("CHECK_IN");
            dtResult.Columns.Add("CHECK_OUT");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            dtResult.Clear();
            dtResult.Dispose();

            try
            {
                dgvSearchResult.Rows.Clear();
            }
            catch
            {
            }

            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("กรุณารอสักครู่...");

            foreach (DataGridViewRow row in dgvOfficerSearchList.Rows)
            {
                SplashScreenManager.Default.SetWaitFormDescription($"กำลังค้นหาข้อมูล => {row.Cells[0].Value.ToString()}");
                Thread.Sleep(10);

                //MessageBox.Show(row.Cells[0].Value.ToString() + "   " + row.Cells[1].Value.ToString());
                DataTable dt = new DataTable();
                string sql = string.Format(@"SELECT human_resource.userinfo.NAME AS FULLNAME, date_format(human_resource.check_in.check_date, '%Y-%m-%d') AS CHECK_DATE, human_resource.check_in.check_time AS CHECK_IN, human_resource.check_out.check_time AS CHECK_OUT FROM human_resource.check_in left join human_resource.check_out ON human_resource.check_in.userid = human_resource.check_out.userid LEFT JOIN human_resource.userinfo ON human_resource.check_in.userid = human_resource.userinfo.id
                     WHERE human_resource.check_in.userid = '{0}' AND human_resource.check_in.check_date = '{1}' AND     human_resource.check_out.userid = '{2}' AND human_resource.check_out.check_date = '{3}'", CommonCOde.getUSERID_fromUSERNAME(row.Cells[0].Value.ToString()),
                    row.Cells[1].Value.ToString(),
                    CommonCOde.getUSERID_fromUSERNAME(row.Cells[0].Value.ToString()),
                    row.Cells[1].Value.ToString());
                dt = DataAccess.RetriveData(sql);

                if (dt.Rows.Count > 0)
                {
                    dtResult.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                }
                else
                {
                    dtResult.Rows.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), "ไม่พบข้อมูล", "ไม่พบข้อมูล");
                }
            }

            this.BeginInvoke(new ThreadStart(delegate
            {
                foreach (DataRow row in dtResult.Rows)
                {
                    dgvSearchResult.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
            }));
            SplashScreenManager.CloseForm();
            Thread.Sleep(10);
        }

        private void FormRandomCheckOfficer_Load(object sender, EventArgs e)
        {
        }

        private void txtSearchOfficer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormSearchOfficer f = new FormSearchOfficer(this, txtSearchOfficer.Text.Trim());
                f.ShowDialog();
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchOfficer.Text.Trim()))
            {
                XtraMessageBox.Show("กรุณาใส่ชื่อเจ้าหน้าที่ด้วยครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string date = dtpSearchOfficer.Value.ToString("yyyy-MM-dd");
                DataGridViewRow createROw = new DataGridViewRow();
                createROw.CreateCells(dgvOfficerSearchList);
                createROw.Cells[0].Value = txtSearchOfficer.Text.Trim();
                createROw.Cells[1].Value = date;
                createROw.Cells[2].Value = "ลบ";

                dgvOfficerSearchList.Rows.Add(createROw);

                dtpSearchOfficer.Value = DateTime.Now;
                txtSearchOfficer.Text = "";
                txtSearchOfficer.ReadOnly = false;
                txtSearchOfficer.Enabled = true;
                txtSearchOfficer.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearchOfficer.ReadOnly = false;
            txtSearchOfficer.Enabled = true;
            txtSearchOfficer.Focus();
        }

        private void dgvOfficerSearchList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOfficerSearchList.Columns[e.ColumnIndex].Name.ToLower();
            if (colName == "delete")
            {
                foreach (DataGridViewRow row in dgvOfficerSearchList.SelectedRows)
                {
                    dgvOfficerSearchList.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dsRandomCheckOfficer ds = new dsRandomCheckOfficer();
            foreach (DataRow row in dtResult.Rows)
            {
                ds.Tables[0].Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }

            rptRandomCheckOfficer rpt = new rptRandomCheckOfficer();
            rpt.DataSource = ds;
            rpt.ShowPreview();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            dsRandomCheckOfficer ds = new dsRandomCheckOfficer();
            foreach (DataRow row in dtResult.Rows)
            {
                ds.Tables[0].Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }

            rptRandomCheckOfficer rpt = new rptRandomCheckOfficer();
            rpt.DataSource = ds;

            // create directory
            Directory.CreateDirectory(@"C:\Temp\EXPORT");

            string path = $"C:\\Temp\\EXPORT\\รายงานสุ่มตรวจ_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            rpt.ExportToPdf(path);

            // เปิดโฟลเดอร์
            Process.Start(@"C:\Temp\EXPORT");
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            dsRandomCheckOfficer ds = new dsRandomCheckOfficer();
            foreach (DataRow row in dtResult.Rows)
            {
                ds.Tables[0].Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }

            rptRandomCheckOfficer rpt = new rptRandomCheckOfficer();
            rpt.DataSource = ds;

            // create directory
            Directory.CreateDirectory(@"C:\Temp\EXPORT");

            string path = $"C:\\Temp\\EXPORT\\รายงานสุ่มตรวจ_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx";

            rpt.ExportToXlsx(path);
            // เปิดโฟลเดอร์
            Process.Start(@"C:\Temp\EXPORT");
        }
    }
}