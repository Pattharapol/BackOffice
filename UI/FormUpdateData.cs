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
            //GetConnectionString()
            DataAccess.GetConnectionString();
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

            //DataAccess.ExecuteSQL("DELETE FROM human_resource.userinfo WHERE userinfo.NAME = '1112'");
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
        }

        #endregion Select Department

        #region updateCheckIN

        private int iCHeckIn;
        private string yearAndMonth = "";

        private void updateCheckIN()
        {
            try
            {
                string year = DateTime.Now.ToString("yyyy");
                string presentMonth = DateTime.Now.ToString("MM");
                string lastMonth = Convert.ToString(Convert.ToInt32(presentMonth) - 1);
                if (lastMonth.Length == 1)
                {
                    lastMonth = "0" + lastMonth;
                    yearAndMonth = year + "-" + lastMonth;
                }

                for (iCHeckIn = 1; iCHeckIn < dgvCHECKIN.Rows.Count - 1; iCHeckIn++)
                {
                    // for report Progress
                    int percentage = (iCHeckIn + 1) * 100 / dgvCHECKIN.Rows.Count;
                    backgroundWorker.ReportProgress(percentage);

                    string date = dgvCHECKIN.Rows[iCHeckIn].Cells[1].Value.ToString().Substring(0, 10).Replace("/", "-");
                    string realDate = Convert.ToDateTime(date).ToString("yyyy-MM-dd");

                    string time = dgvCHECKIN.Rows[iCHeckIn].Cells[1].Value.ToString().Substring(11);
                    //string realTime = Convert.ToDateTime(time).ToString("hh:mm");

                    // check for check_in or check_out
                    if (dgvCHECKIN.Rows[iCHeckIn].Cells[2].Value.ToString() == "I")
                    {
                        string sqlINSERT = string.Format(@"INSERT INTO human_resource.check_in (userid, check_date, check_time, check_type) VALUES ('{0}', '{1}', '{2}', '{3}')", dgvCHECKIN.Rows[iCHeckIn].Cells[0].Value.ToString(), realDate, time, dgvCHECKIN.Rows[iCHeckIn].Cells[2].Value.ToString());

                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            lblCheckInCount.Text = iCHeckIn.ToString() + "/" + dgvCHECKIN.Rows.Count.ToString();
                            lblCheckInCount.Update();
                        }));

                        DataAccess.ExecuteSQL(sqlINSERT);
                    }
                    else
                    {
                        string sqlINSERT = string.Format(@"INSERT INTO human_resource.check_out (userid, check_date, check_time, check_type) VALUES ('{0}', '{1}', '{2}', '{3}')", dgvCHECKIN.Rows[iCHeckIn].Cells[0].Value.ToString(), realDate, time, dgvCHECKIN.Rows[iCHeckIn].Cells[2].Value.ToString());

                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            lblCheckInCount.Text = iCHeckIn.ToString() + "/" + dgvCHECKIN.Rows.Count.ToString();
                            lblCheckInCount.Update();
                        }));

                        DataAccess.ExecuteSQL(sqlINSERT);
                    }
                }
            }
            catch
            {
            }
        }

        #endregion updateCheckIN

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
                if (XtraMessageBox.Show("การนำเข้าข้อมูลอาจใช้เวลานาน ท่านต้องการทำต่อ ใช่หรือไม่", "แจ้งทราบ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    fsOut.Close();
                    fsIn.Close();

                    SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
                    SplashScreenManager.Default.SetWaitFormCaption("กำลังนำเข้าข้อมูล...");
                    SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");

                    cboTypeOfImportData.Enabled = false;
                    // เฉพาะเดือนล่าสุด ลบแค่เดือนนั้นๆ
                    if (cboTypeOfImportData.SelectedIndex == 2)
                    {
                        string year = DateTime.Now.ToString("yyyy");
                        string presentMonth = DateTime.Now.ToString("MM");
                        string lastMonth = Convert.ToString(Convert.ToInt32(presentMonth) - 1);
                        if (lastMonth.Length == 1)
                        {
                            lastMonth = "0" + lastMonth;
                            yearAndMonth = year + lastMonth;
                        }
                        string sqlDeleteCurrentMonthFromCheckIn = string.Format(@"DELETE FROM human_resource.check_in WHERE replace(human_resource.check_in.check_date, '-','') LIKE '%{0}%'", yearAndMonth);
                        DataAccess.ExecuteSQL(sqlDeleteCurrentMonthFromCheckIn);
                        string sqlDeleteCurrentMonthFromCheckOUT = string.Format(@"DELETE FROM human_resource.check_out WHERE replace(human_resource.check_out.check_date, '-','') LIKE '%{0}%'", yearAndMonth);
                        DataAccess.ExecuteSQL(sqlDeleteCurrentMonthFromCheckOUT);
                    }
                    // ทั้งปีงบประมาณ ลบทั้งหมด
                    if (cboTypeOfImportData.SelectedIndex == 1)
                    {
                        DataAccess.ExecuteSQL("DELETE FROM human_resource.check_in");
                        DataAccess.ExecuteSQL("DELETE FROM human_resource.check_out");
                    }

                    // disable button
                    btnUpdateData.Enabled = false;

                    // Fill DGV
                    DoWorkDelegate dowork = new DoWorkDelegate(FillUser);
                    dowork += new DoWorkDelegate(FillDepartment);
                    dowork += new DoWorkDelegate(FillCheckInAndCHeckOut);
                    dowork();

                    lblCheckInCount.Text = "0/" + dgvCHECKIN.Rows.Count;
                    lblDeptCount.Text = "0/" + dgvDEPT.Rows.Count;
                    lblUserCount.Text = "0/" + dgvUSERINFO.Rows.Count;

                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    fsOut.Close();
                    fsIn.Close();
                }

                //lblDEPT.Text = "ข้อมูลที่จะนำเข้า มีทั้งหมด " + dgvDEPT.Rows.Count + " รายการ";
                //lblUSERINFO.Text = "ข้อมูลที่จะนำเข้า มีทั้งหมด " + dgvUSERINFO.Rows.Count + " รายการ";
            }
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            //if (dgvCHECKIN.Rows.Count < 0 || dgvCHECKIN.DataSource == null)
            //{
            //    XtraMessageBox.Show("กรุณานำเข้าหรืออัพเดทข้อมูลให้เป็นปัจจุบันก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    if (XtraMessageBox.Show("การอัพเดทข้อมูลอาจใช้เวลานาน คุณต้องการอัพเดทข้อมูลใช่หรือไม่", "แจ้งทราบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        btnUpdateData.Enabled = false;
            //        btnUploadData.Enabled = false;
            //        if (cboTypeOfImportData.SelectedIndex == 1)
            //        {
            //            DataAccess.ExecuteSQL("delete from human_resource.check_in");
            //        }
            //    }
            //}
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            updateCheckIN();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarCHECKIN.Visible = true;
            ProgressBarCHECKIN.Value = e.ProgressPercentage;
            lblProgressbarCheckIN.Visible = true;
            lblProgressbarCheckIN.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblCheckInCount.Visible = false;
            cboTypeOfImportData.Enabled = true;
            btnUpdateData.Enabled = true;
            btnUploadData.Enabled = true;
            lblProgressbarCheckIN.Text = "100%";
            ProgressBarCHECKIN.Value = 100;
            SplashScreenManager.CloseForm();
            //backgroundWorker1.RunWorkerAsync();
            //XtraMessageBox.Show("อัปเดทข้อมูลเรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            updateUSER();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarUSER.Value = e.ProgressPercentage;
            lblProgressbarUSER.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblUserCount.Visible = false;
            ProgressBarUSER.Value = 100;
            lblProgressbarUSER.Text = "100%";
            backgroundWorker2.RunWorkerAsync();

            //backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            updateDepartment();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarDepartment.Value = e.ProgressPercentage;
            lblProgressbarDepartment.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblDeptCount.Visible = false;
            ProgressBarDepartment.Value = 100;
            lblProgressbarDepartment.Text = "100%";
            backgroundWorker.RunWorkerAsync();
            //SplashScreenManager.CloseForm();
        }

        private int iDepartment;

        private void updateDepartment()
        {
            try
            {
                for (iDepartment = 0; iDepartment < dgvDEPT.Rows.Count - 1; iDepartment++)
                {
                    int percent = (iDepartment + 1) * 100 / dgvDEPT.Rows.Count;
                    backgroundWorker2.ReportProgress(percent);

                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        lblDeptCount.Text = iDepartment.ToString() + "/" + dgvDEPT.Rows.Count.ToString();
                        lblDeptCount.Update();
                    }));

                    DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.departments (dept_id, dept_name) VALUES ('{0}','{1}')", dgvDEPT.Rows[iDepartment].Cells["DEPTID"].Value.ToString(), dgvDEPT.Rows[iDepartment].Cells["DEPTNAME"].Value.ToString()));
                }
            }
            catch
            {
            }
        }

        private int iUser;

        private void updateUSER()
        {
            try
            {
                for (iUser = 0; iUser < dgvUSERINFO.Rows.Count - 1; iUser++)
                {
                    int percent = (iUser + 1) * 100 / dgvUSERINFO.Rows.Count;
                    backgroundWorker1.ReportProgress(percent);

                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        lblUserCount.Text = iUser.ToString() + "/" + (dgvUSERINFO.Rows.Count).ToString();
                        lblUserCount.Update();
                    }));

                    DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.userinfo (id, NAME, TITLE, DEPTID) VALUES ('{0}', '{1}', '{2}', '{3}')", dgvUSERINFO.Rows[iUser].Cells[0].Value.ToString(), dgvUSERINFO.Rows[iUser].Cells[1].Value.ToString(), dgvUSERINFO.Rows[iUser].Cells[2].Value.ToString(), dgvUSERINFO.Rows[iUser].Cells[3].Value.ToString()));
                }

                Thread.Sleep(10);
                string sqlUpdate1112 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'อรรถวุฒิ ธรรมชาติ', TITLE = 'นาย', DEPTID = '5' WHERE id = '134'");
                DataAccess.ExecuteSQL(sqlUpdate1112);
                Thread.Sleep(10);

                string sqlUpdate1113 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'จุฑามาศ บุญคำ', TITLE = 'นางสาว', DEPTID = '9' WHERE id = '136'");
                DataAccess.ExecuteSQL(sqlUpdate1113);
                Thread.Sleep(10);

                string sqlUpdate1114 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'พิมพ์ประพัทร์ อุดมทนัชโชติ', TITLE = 'นางสาว', DEPTID = '9' WHERE id = '135'");
                DataAccess.ExecuteSQL(sqlUpdate1114);
                Thread.Sleep(10);

                string sqlUpdate1115 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'สุมิตา ดวงมาลา', TITLE = 'นางสาว', DEPTID = '9' WHERE id = '137'");
                DataAccess.ExecuteSQL(sqlUpdate1115);
                Thread.Sleep(10);

                //string sqlUpdate16 = string.Format(@"");
                string sqlUpdate1117 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'สมยศ ศรีมูล', TITLE = 'นาย', DEPTID = '14' WHERE id = '140'");
                DataAccess.ExecuteSQL(sqlUpdate1117);
                Thread.Sleep(10);

                string sqlUpdate1118 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'ณัฐนันท์ พิมพ์วัน', TITLE = 'นางสาว', DEPTID = '9' WHERE id = '139'");
                DataAccess.ExecuteSQL(sqlUpdate1118);
                Thread.Sleep(10);

                string sqlUpdate1119 = string.Format(@"UPDATE human_resource.userinfo SET NAME = 'เมธี แสนการุณ', TITLE = 'นาย', DEPTID = '8' WHERE id = '138'");
                DataAccess.ExecuteSQL(sqlUpdate1119);
                Thread.Sleep(10);
            }
            catch
            {
            }
        }

        private void FormUpdateData_Load(object sender, EventArgs e)
        {
            DataAccess.GetConnectionString();
        }
    }
}