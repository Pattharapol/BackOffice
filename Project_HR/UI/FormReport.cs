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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOfficeApplication.Project_HR.UI
{
    public partial class FormReport : DevExpress.XtraEditors.XtraForm
    {
        // for select data from database
        private DataTable dtServiceWorker = new DataTable();

        private DataTable dtBackOffice = new DataTable();
        private DataTable dtSupervisor = new DataTable();

        // for store data, use with report
        private DataTable dtSourceServiceWorker = new DataTable();

        private DataTable dtSourceBackOffice = new DataTable();
        private DataTable dtSourceSupervisor = new DataTable();

        // for report only
        private dsCheckIN_OUT dsCheckIN_OUT = new dsCheckIN_OUT();

        public FormReport()
        {
            InitializeComponent();

            dtSourceServiceWorker.Columns.Add("NAME");
            dtSourceServiceWorker.Columns.Add("dept_name");
            dtSourceServiceWorker.Columns.Add("check_date");
            dtSourceServiceWorker.Columns.Add("check_time");

            dtSourceBackOffice.Columns.Add("NAME");
            dtSourceBackOffice.Columns.Add("dept_name");
            dtSourceBackOffice.Columns.Add("check_date");
            dtSourceBackOffice.Columns.Add("check_time");

            dtSourceSupervisor.Columns.Add("NAME");
            dtSourceSupervisor.Columns.Add("dept_name");
            dtSourceSupervisor.Columns.Add("check_date");
            dtSourceSupervisor.Columns.Add("check_time");
        }

        private void btnProcessServiceWorker_Click(object sender, EventArgs e)
        {
            // spin splash screen
            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
            SplashScreenManager.Default.SetWaitFormCaption("กำลังประมวลผล...");
            SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");

            // clear data from dummy table
            DataAccess.ExecuteSQL("DELETE FROM human_resource.dummy_late_data");

            string dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEndDate.Value.ToString("yyyy-MM-dd");

            // ประมวลผลเจ้าหน้าที่ทั่วไป มาทำงาน 08.00 สายได้ 15 นาที

            string sql = string.Format(@"SELECT userinfo.NAME, departments.dept_name, date_format(check_in.check_date, '%Y-%m-%d') as check_date, check_in.check_time FROM human_resource.userinfo INNER JOIN human_resource.departments ON userinfo.DEPTID = departments.dept_id left JOIN human_resource.check_in ON userinfo.id = check_in.userid AND userinfo.DEPTID != '14' AND userinfo.id NOT IN ('5','7', '8', '9', '10', '11', '14', '17', '35', '37', '38', '88', '121', '130') WHERE (check_in.check_date BETWEEN '{0}' AND '{1}') ORDER BY userinfo.NAME ASC", dateStart, dateEnd);

            dtServiceWorker = DataAccess.RetriveData(sql);

            // เตรียม datatable มารับข้อมูลที่กรองแล้ว พร้อมกับ add column เข้าไป
            // ประกาศข้างนอก เพราะต้องเอาไป loop ดึงข้อมูลจาก dummy

            foreach (DataRow data in dtServiceWorker.Rows)
            {
                int checkIn = Convert.ToInt32(data["check_time"].ToString().Substring(0, 5).Replace(":", ""));

                // 08.15 ถึง 10.00 || 16.15 ถึง 18.00  || 00.15 ถึง 01.30
                if (checkIn > 815 && checkIn < 1000 || checkIn > 1615 && checkIn < 1800 || checkIn > 15 && checkIn < 130)
                {
                    // convert to yyyy-MM-dd such as 2564-10-10
                    string date = "";
                    int year = 0;
                    string date1 = "";
                    if (string.IsNullOrEmpty(data[2].ToString()))
                    {
                    }
                    else
                    {
                        date = Convert.ToDateTime(data[2].ToString()).ToString("yyyy-MM-dd");
                        year = Convert.ToInt32(date.Substring(0, 4)) - 543;
                        date1 = year + date.Substring(4);
                        dtSourceServiceWorker.Rows.Add(data[0].ToString(), data[1].ToString(), date1, data[3].ToString());
                    }

                    //DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.dummy_late_data (name, department, date, time) VALUES ('{0}', '{1}', '{2}', '{3}')", data[0].ToString(), data[1].ToString(), date1, data[3].ToString()));
                }
            }

            dgvServiceWorkerCheckIn.DataSource = dtSourceServiceWorker;
            dgvServiceWorkerCheckIn.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvServiceWorkerCheckIn.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvServiceWorkerCheckIn.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvServiceWorkerCheckIn.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            SplashScreenManager.CloseForm();
            btnPrintServiceWorker.Enabled = true;
            btnPDF_ServiceWorker.Enabled = true;
        }

        private void btnPDF_ServiceWorker_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"C:\Temp\EXPORT");
            dsCheckIN_OUT.Clear();
            dsCheckIN_OUT.Dispose();
            foreach (DataRow data in dtSourceServiceWorker.Rows)
            {
                dsCheckIN_OUT.Tables[0].Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }

            string path = $"C:\\Temp\\EXPORT\\รายงานการมาสายเจ้าหน้าที่สายบริการ_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            rptCheckIN_OUT rpt = new rptCheckIN_OUT();
            rpt.DataSource = dsCheckIN_OUT;
            rpt.ExportToPdf(path);

            // เปิดโฟลเดอร์
            Process.Start(@"C:\Temp\EXPORT");
        }

        private void btnPrintServiceWorker_Click(object sender, EventArgs e)
        {
            dsCheckIN_OUT.Clear();
            dsCheckIN_OUT.Dispose();
            foreach (DataRow data in dtSourceServiceWorker.Rows)
            {
                dsCheckIN_OUT.Tables[0].Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }
            rptCheckIN_OUT rpt = new rptCheckIN_OUT();

            rpt.DataSource = dsCheckIN_OUT;
            rpt.ShowPreview();
        }

        private void btnBackOfficeProcess_Click(object sender, EventArgs e)
        {
            // spin splash screen
            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
            SplashScreenManager.Default.SetWaitFormCaption("กำลังประมวลผล...");
            SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");

            // clear data from dummy table
            //DataAccess.ExecuteSQL("DELETE FROM human_resource.dummy_late_data");

            string dateStart = dtpBackOffice_Start.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpBackOffice_END.Value.ToString("yyyy-MM-dd");

            // ประมวลผลเจ้าหน้าที่ทั่วไป มาทำงาน 08.00 สายได้ 15 นาที

            DataTable dt = new DataTable();

            string sql = string.Format(@"SELECT userinfo.NAME, departments.dept_name, date_format(check_in.check_date, '%Y-%m-%d') as check_date, check_in.check_time FROM human_resource.userinfo INNER JOIN human_resource.departments ON userinfo.DEPTID = departments.dept_id left JOIN human_resource.check_in ON userinfo.id = check_in.userid AND userinfo.DEPTID = '14' AND userinfo.id NOT IN ('5','7', '8', '9', '10', '11', '14', '17', '35', '37', '38', '88', '121', '130') WHERE (check_in.check_date BETWEEN '{0}' AND '{1}') ORDER BY userinfo.NAME ASC", dateStart, dateEnd);

            dt = DataAccess.RetriveData(sql);

            // เตรียม datatable มารับข้อมูลที่กรองแล้ว พร้อมกับ add column เข้าไป
            // ประกาศข้างนอก เพราะต้องเอาไป loop ดึงข้อมูลจาก dummy

            

            foreach (DataRow data in dt.Rows)
            {
                int checkIn = Convert.ToInt32(data["check_time"].ToString().Substring(0, 5).Replace(":", ""));

                // 08.45 ถึง 10.00 || 16.15 ถึง 18.00  || 00.15 ถึง 01.30
                if (checkIn > 845 && checkIn < 1000 || checkIn > 1645 && checkIn < 1800 || checkIn > 45 && checkIn < 130)
                {
                    // convert to yyyy-MM-dd such as 2564-10-10
                    string date = Convert.ToDateTime(data[2].ToString()).ToString("yyyy-MM-dd");
                    int year = Convert.ToInt32(date.Substring(0, 4)) - 543;
                    string date1 = year + date.Substring(4);
                    dtSourceBackOffice.Rows.Add(data[0].ToString(), data[1].ToString(), date1, data[3].ToString());

                    //DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.dummy_late_data (name, department, date, time) VALUES ('{0}', '{1}', '{2}', '{3}')", data[0].ToString(), data[1].ToString(), date1, data[3].ToString()));
                }
            }

            dgvBackOfficeReport.DataSource = dtSourceBackOffice;
            dgvBackOfficeReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBackOfficeReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBackOfficeReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBackOfficeReport.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            SplashScreenManager.CloseForm();
            btnBackOfficePrint.Enabled = true;
            btnBackOffice_PDF.Enabled = true;
        }

        private void btnBackOffice_PDF_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"C:\Temp\EXPORT");
            dsCheckIN_OUT.Clear();
            dsCheckIN_OUT.Dispose();
            foreach (DataRow data in dtSourceBackOffice.Rows)
            {
                dsCheckIN_OUT.Tables[0].Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }

            string path = $"C:\\Temp\\EXPORT\\รายงานการมาสายเจ้าหน้าที่สายสนับสนุน_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            rptCheckIN_OUT rpt = new rptCheckIN_OUT();
            rpt.DataSource = dsCheckIN_OUT;
            rpt.ExportToPdf(path);

            // เปิดโฟลเดอร์
            Process.Start(@"C:\Temp\EXPORT");
        }

        private void btnBackOfficePrint_Click(object sender, EventArgs e)
        {
            dsCheckIN_OUT.Clear();
            dsCheckIN_OUT.Dispose();
            foreach (DataRow data in dtSourceBackOffice.Rows)
            {
                dsCheckIN_OUT.Tables[0].Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }

            rptCheckIN_OUT rpt = new rptCheckIN_OUT();
            rpt.DataSource = dsCheckIN_OUT;
            rpt.ShowPreview();
        }

        private void btnSupervisorProcess_Click(object sender, EventArgs e)
        {
            // spin splash screen
            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
            SplashScreenManager.Default.SetWaitFormCaption("กำลังประมวลผล...");
            SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");

            // clear data from dummy table
            //DataAccess.ExecuteSQL("DELETE FROM human_resource.dummy_late_data");

            string dateStart = dtpSupervisorStart.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpSupervisorEND.Value.ToString("yyyy-MM-dd");

            // ประมวลผลเจ้าหน้าที่ทั่วไป มาทำงาน 08.00 สายได้ 15 นาที

            string sql = string.Format(@"SELECT userinfo.NAME, departments.dept_name, date_format(check_in.check_date, '%Y-%m-%d') as check_date , check_in.check_time FROM human_resource.userinfo INNER JOIN human_resource.departments ON userinfo.DEPTID = departments.dept_id left JOIN human_resource.check_in ON userinfo.id = check_in.userid AND userinfo.id IN ('5','7', '8', '9', '10', '11', '14', '17', '35', '37', '38', '88', '121', '130') WHERE (check_in.check_date BETWEEN '{0}' AND '{1}') ORDER BY userinfo.NAME ASC", dateStart, dateEnd);

            dtSupervisor = DataAccess.RetriveData(sql);

            // เตรียม datatable มารับข้อมูลที่กรองแล้ว พร้อมกับ add column เข้าไป
            // ประกาศข้างนอก เพราะต้องเอาไป loop ดึงข้อมูลจาก dummy

           

            foreach (DataRow data in dtSupervisor.Rows)
            {
                int checkIn = Convert.ToInt32(data[3].ToString().Substring(0, 5).Replace(":", ""));

                // 08.30 ถึง 10.00 || 16.30 ถึง 18.00  || 00.30 ถึง 01.30
                if (checkIn > 830 && checkIn < 1000 || checkIn > 1630 && checkIn < 1800 || checkIn > 30 && checkIn < 130)
                {
                    // convert to yyyy-MM-dd such as 2564-10-10
                    string date = Convert.ToDateTime(data[2].ToString()).ToString("yyyy-MM-dd");
                    int year = Convert.ToInt32(date.Substring(0, 4)) - 543;
                    string date1 = year + date.Substring(4);
                    dtSourceSupervisor.Rows.Add(data[0].ToString(), data[1].ToString(), date1, data[3].ToString());

                    //DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.dummy_late_data (name, department, date, time) VALUES ('{0}', '{1}', '{2}', '{3}')", data[0].ToString(), data[1].ToString(), date1, data[3].ToString()));
                }
            }

            dgvSupervisorReport.DataSource = dtSourceSupervisor;
            dgvSupervisorReport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupervisorReport.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupervisorReport.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSupervisorReport.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            SplashScreenManager.CloseForm();
            btnSupervisorPDF.Enabled = true;
            btnSupervisorPrint.Enabled = true;
        }

        private void btnSupervisorPrint_Click(object sender, EventArgs e)
        {
            dsCheckIN_OUT.Clear();
            dsCheckIN_OUT.Dispose();
            foreach (DataRow data in dtSourceSupervisor.Rows)
            {
                dsCheckIN_OUT.Tables[0].Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }

            rptCheckIN_OUT rpt = new rptCheckIN_OUT();
            rpt.DataSource = dsCheckIN_OUT;
            rpt.ShowPreview();
        }

        private void btnSupervisorPDF_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"C:\Temp\EXPORT");
            dsCheckIN_OUT.Clear();
            dsCheckIN_OUT.Dispose();
            foreach (DataRow data in dtSourceSupervisor.Rows)
            {
                dsCheckIN_OUT.Tables[0].Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }

            string path = $"C:\\Temp\\EXPORT\\รายงานการมาสายหัวหน้างาน_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            rptCheckIN_OUT rpt = new rptCheckIN_OUT();
            rpt.DataSource = dsCheckIN_OUT;
            rpt.ExportToPdf(path);

            // เปิดโฟลเดอร์
            Process.Start(@"C:\Temp\EXPORT");
        }
    }
}