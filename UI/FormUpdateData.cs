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
using System.IO;
using BackOfficeApplication.DataCenter;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace HumanResource.UI
{
    public partial class FormUpdateData : DevExpress.XtraEditors.XtraForm
    {
        private delegate void DoWorkDelegate();

        private delegate void UpdateDataDelegate();

        public FormUpdateData()
        {
            InitializeComponent();

            cboTypeOfImportData.SelectedIndex = 0;
        }

        #region Select CheckIN and CheckOUT

        private void FillCheckInAndCHeckOut()
        {
            dgvCHECKIN.DataSource = null;
            try
            {
                if (cboTypeOfImportData.SelectedIndex == 1)
                {
                    dgvCHECKIN.DataSource = MSAccessDataAccess.RetrieveCheckIN_FromMSAccess("ทั้งปีงบประมาณ");
                    dgvCHECKIN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvCHECKIN.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCHECKIN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (cboTypeOfImportData.SelectedIndex == 2)
                {
                    dgvCHECKIN.DataSource = MSAccessDataAccess.RetrieveCheckIN_FromMSAccess("เดือนปัจจุบัน");
                    dgvCHECKIN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvCHECKIN.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvCHECKIN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch
            {
            }
            lblCHECKIN.Text = "ข้อมูลที่จะนำเข้า มีทั้งหมด " + dgvCHECKIN.Rows.Count + " รายการ";
        }

        #endregion Select CheckIN and CheckOUT

        #region Select UserInfo

        private void FillUser()
        {
            DataAccess.ExecuteSQL("DELETE FROM human_resource.userinfo");

            //ms access
            string sql = "SELECT USERID, Name, TITLE, DEFAULTDEPTID FROM userinfo";
            DataTable dt = new DataTable();
            dt = MSAccessDataAccess.RetrieveDataFromMSAccess(sql);
            dgvUSERINFO.DataSource = dt;
            dgvUSERINFO.Columns[0].Visible = false;
            dgvUSERINFO.Columns[2].Visible = false;
            dgvUSERINFO.Columns[3].Visible = false;
            dgvUSERINFO.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataRow data in dt.Rows)
            {
                DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.userinfo (id, NAME, TITLE, DEPTID) VALUES ('{0}', '{1}', '{2}', '{3}')", data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString()));
            }
            //DataAccess.ExecuteSQL("DELETE FROM human_resource.userinfo WHERE userinfo.NAME = '1112'");

            lblUSERINFO.Text = "ข้อมูลที่จะนำเข้า มีทั้งหมด " + dgvUSERINFO.Rows.Count + " รายการ";
        }

        #endregion Select UserInfo

        #region Select Department

        private void FillDepartment()
        {
            DataAccess.ExecuteSQL("DELETE FROM human_resource.departments");

            //ms access
            string sql = "SELECT DEPTID, DEPTNAME FROM departments";
            DataTable dt = new DataTable();
            dt = MSAccessDataAccess.RetrieveDataFromMSAccess(sql);
            dgvDEPT.DataSource = dt;
            dgvDEPT.Columns[0].Visible = false;
            dgvDEPT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataRow data in dt.Rows)
            {
                DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.departments(dept_id, dept_name) VALUES ('{0}','{1}')", data["DEPTID"].ToString(), data["DEPTNAME"].ToString()));
            }

            lblDEPT.Text = "ข้อมูลที่จะนำเข้า มีทั้งหมด " + dgvDEPT.Rows.Count + " รายการ";
        }

        #endregion Select Department

        #region DoProcess Update Data

        private void DoProcess()
        {
            for (int i = 1; i < dgvCHECKIN.Rows.Count - 1; i++)
            {
                // for report Progress
                int percentage = (i + 1) * 100 / dgvCHECKIN.Rows.Count;
                backgroundWorker.ReportProgress(percentage);

                string date = dgvCHECKIN.Rows[i].Cells[1].Value.ToString().Substring(0, 10).Replace("/", "-");
                string realDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");

                string time = dgvCHECKIN.Rows[i].Cells[1].Value.ToString().Substring(11);
                //string realTime = Convert.ToDateTime(time).ToString("hh:mm");

                string sqlINSERT = string.Format(@"INSERT INTO human_resource.check_in (userid, check_date, check_time, check_type) VALUES ('{0}', '{1}', '{2}', '{3}')", dgvCHECKIN.Rows[i].Cells[0].Value.ToString(), realDate, time, dgvCHECKIN.Rows[i].Cells[2].Value.ToString());
                DataAccess.ExecuteSQL(sqlINSERT);
            }
        }

        #endregion DoProcess Update Data

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            if (cboTypeOfImportData.SelectedIndex == 0)
            {
                XtraMessageBox.Show("กรุณาเลือกประเภทที่ต้องการนำเข้าข้อมูล", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Database Files (*.mdb)|*.mdb";
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = o.FileName;
                // เอาไปเก็ยไว้ที่ Path
                FileStream fsOut = new FileStream(@"C:\Temp\att2000.mdb", FileMode.Create);
                FileStream fsIn = new FileStream(fileName, FileMode.Open);
                byte[] bt = new byte[1048756];
                int readByte;
                while ((readByte = fsIn.Read(bt, 0, bt.Length)) > 0)
                {
                    // begin write
                    fsOut.Write(bt, 0, readByte);

                    // เอา position ของ fsIn ไปคูณ 100 แล้วหาร จำนวนทั้งหมดของ fsIn ออกมาเป็น %
                    // worker.ReportProgress((int)(fsIn.Position * 100 / fsIn.Length));
                }
                XtraMessageBox.Show("นำเข้าข้อมูลเรียบร้อยแล้วครับ กำลังประมวลผล กรุณารอสักครู่...", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fsOut.Close();
                fsIn.Close();

                cboTypeOfImportData.Enabled = false;

                SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
                SplashScreenManager.Default.SetWaitFormCaption("กำลังนำเข้าข้อมูล...");
                SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");

                // Fill DGV
                DoWorkDelegate dowork = new DoWorkDelegate(FillUser);
                dowork += new DoWorkDelegate(FillDepartment);
                dowork += new DoWorkDelegate(FillCheckInAndCHeckOut);
                dowork();

                //FillUser();
                //FillDepartment();
                //FillCheckInAndCHeckOut();

                SplashScreenManager.CloseForm();
            }
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            if (dgvCHECKIN.Rows.Count < 0 || dgvCHECKIN.DataSource == null)
            {
                MessageBox.Show("กรุณานำเข้าหรืออัพเดทข้อมูลให้เป็นปัจจุบันก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (MessageBox.Show("การอัพเดทข้อมูลอาจใช้เวลานาน คุณต้องการอัพเดทข้อมูลใช่หรือไม่", "แจ้งทราบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cboTypeOfImportData.SelectedIndex == 1)
                    {
                        DataAccess.ExecuteSQL("delete from human_resource.check_in");
                    }
                    btnUpdateData.Enabled = false;
                    btnUploadData.Enabled = false;

                    backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
            SplashScreenManager.Default.SetWaitFormCaption("กำลังอัปเดทข้อมูล...");
            SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");
            DoProcess();
            SplashScreenManager.CloseForm();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Visible = true;
            ProgressBar.Value = e.ProgressPercentage;
            lblProgressbar.Visible = true;
            lblProgressbar.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cboTypeOfImportData.Enabled = true;
            ProgressBar.Visible = false;
            btnUpdateData.Enabled = true;
            btnUploadData.Enabled = true;
            lblProgressbar.Visible = false;
            XtraMessageBox.Show("อัปเดทข้อมูลเรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}