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
using BackOfficeApplication.DataCenter;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraSplashScreen;
using HumanResource.Report;

namespace HumanResource.UI
{
    public partial class FormServiceWorkerReport : DevExpress.XtraEditors.XtraForm
    {
        public FormServiceWorkerReport()
        {
            InitializeComponent();
            //GetConnectionString()
            DataAccess.GetConnectionString();
        }

        private void btnProcess_Click(object sender, EventArgs e)
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

            DataTable dt = new DataTable();

            string sql = string.Format(@"SELECT userinfo.NAME, departments.dept_name, check_in.check_date, check_in.check_time FROM human_resource.userinfo INNER JOIN human_resource.departments ON userinfo.DEPTID = departments.dept_id left JOIN human_resource.check_in ON userinfo.id = check_in.userid AND userinfo.DEPTID != '14' AND userinfo.id NOT IN ('5','7', '8', '9', '10', '11', '14', '17', '35', '37', '38', '88', '121', '130') WHERE (check_in.check_date BETWEEN '{0}' AND '{1}') ORDER BY userinfo.NAME ASC", dateStart, dateEnd);

            dt = DataAccess.RetriveData(sql);

            // เตรียม datatable มารับข้อมูลที่กรองแล้ว พร้อมกับ add column เข้าไป
            // ประกาศข้างนอก เพราะต้องเอาไป loop ดึงข้อมูลจาก dummy
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("NAME");
            dtSource.Columns.Add("dept_name");
            dtSource.Columns.Add("check_date");
            dtSource.Columns.Add("check_time");

            foreach (DataRow data in dt.Rows)
            {
                int checkIn = Convert.ToInt32(data["check_time"].ToString().Substring(0, 5).Replace(":", ""));

                // 08.15 ถึง 10.00 || 16.15 ถึง 18.00  || 00.15 ถึง 01.30
                if (checkIn > 815 && checkIn < 1000 || checkIn > 1615 && checkIn < 1800 || checkIn > 15 && checkIn < 130)
                {
                    // convert to yyyy-MM-dd such as 2564-10-10
                    string date = Convert.ToDateTime(data[2].ToString()).ToString("yyyy-MM-dd");
                    int year = Convert.ToInt32(date.Substring(0, 4)) - 543;
                    string date1 = year + date.Substring(4);
                    dtSource.Rows.Add(data[0].ToString(), data[1].ToString(), date1, data[3].ToString());

                    DataAccess.ExecuteSQL(string.Format(@"INSERT INTO human_resource.dummy_late_data (name, department, date, time) VALUES ('{0}', '{1}', '{2}', '{3}')", data[0].ToString(), data[1].ToString(), date1, data[3].ToString()));
                }
            }

            dgvServiceWorkerCheckIn.DataSource = dtSource;
            SplashScreenManager.CloseForm();
            btnEXCEL.Enabled = true;
            btnPDF.Enabled = true;
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            // create directory
            Directory.CreateDirectory(@"C:\Temp\EXPORT");

            string path = $"C:\\Temp\\EXPORT\\รายงานการมาสายเจ้าหน้าที่สายบริการ_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx";
            dgvServiceWorkerCheckIn.ExportToXlsx(path);

            // เปิดโฟลเดอร์
            Process.Start(@"C:\Temp\EXPORT");
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string sql = string.Format(@"SELECT name, department, CONCAT(DAY(date),' ', case when(MONTH(date))='10' then 'ต.ค.' when(MONTH(date))='11' then 'พ.ย.' when(MONTH(date))='12' then 'ธ.ค.' when(MONTH(date))='1' then 'ม.ค.' when(MONTH(date))='2' then 'ก.พ.' when(MONTH(date))='3' then 'มี.ค.' when(MONTH(date))='4' then 'เม.ย.' when(MONTH(date))='5' then 'พ.ค.' when(MONTH(date))='6' then 'มิ.ย.' when(MONTH(date))='7' then 'ก.ค.' when(MONTH(date))='8' then 'ส.ค.' when(MONTH(date))='9' then 'ก.ย.' ELSE CAST(date AS date) END, ' ',YEAR(date)) AS date, time FROM human_resource.dummy_late_data WHERE human_resource.dummy_late_data.date BETWEEN '{0}' AND '{1}' ORDER BY human_resource.dummy_late_data.name ", dateStart, dateEnd);

            dsServiceWorker ds = new dsServiceWorker();

            rptServiceWorker rpt = new rptServiceWorker();
            rpt.RequestParameters = false;
            rpt.DataSource = DataAccess.FillDataSetForReport(ds, ds.Tables[0].TableName, sql);

            // spin splash screen
            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
            SplashScreenManager.Default.SetWaitFormCaption("กำลังส่งออก PDF ...");
            SplashScreenManager.Default.SetWaitFormDescription("กรุณารอสักครู่...");

            // create directory
            Directory.CreateDirectory(@"C:\Temp\EXPORT");

            string path = $"C:\\Temp\\EXPORT\\รายงานการมาสายเจ้าหน้าที่สายบริการ_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";
            rpt.ExportToPdf(path);

            // ปิดแล้ว เปิดโฟลเดอร์
            SplashScreenManager.CloseForm();
            Process.Start(@"C:\Temp\EXPORT");
        }
    }
}