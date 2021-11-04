using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOfficeApplication.DataCenter;
using BackOfficeApplication.Project_HR.Report;
using System.IO;
using System.Diagnostics;

namespace BackOfficeApplication.Project_HR.UI
{
    public partial class FormOffDutyReport : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtReport = new DataTable();
        private dsOffDuty ds = new dsOffDuty();

        public FormOffDutyReport()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string sqlOffDuty = string.Format(@"SELECT huser.`NAME`, dept.dept_name,off_duty.type,CONCAT(DAY(human_resource.off_duty.startDate),' ', case when(MONTH(human_resource.off_duty.startDate))='10' then 'ต.ค.' when(MONTH(human_resource.off_duty.startDate))='11' then 'พ.ย.' when(MONTH(human_resource.off_duty.startDate))='12' then 'ธ.ค.' when(MONTH(human_resource.off_duty.startDate))='1' then 'ม.ค.' when(MONTH(human_resource.off_duty.startDate))='2' then 'ก.พ.' when(MONTH(human_resource.off_duty.startDate))='3' then 'มี.ค.' when(MONTH(human_resource.off_duty.startDate))='4' then 'เม.ย.' when(MONTH(human_resource.off_duty.startDate))='5' then 'พ.ค.' when(MONTH(human_resource.off_duty.startDate))='6' then 'มิ.ย.' when(MONTH(human_resource.off_duty.startDate))='7' then 'ก.ค.' when(MONTH(human_resource.off_duty.startDate))='8' then 'ส.ค.' when(MONTH(human_resource.off_duty.startDate))='9' then 'ก.ย.' ELSE CAST(human_resource.off_duty.startDate AS DATE) END, ' ',YEAR(human_resource.off_duty.startDate)) AS startDate, CONCAT(DAY(human_resource.off_duty.endDate),' ', case when(MONTH(human_resource.off_duty.endDate))='10' then 'ต.ค.' when(MONTH(human_resource.off_duty.endDate))='11' then 'พ.ย.' when(MONTH(human_resource.off_duty.endDate))='12' then 'ธ.ค.' when(MONTH(human_resource.off_duty.endDate))='1' then 'ม.ค.' when(MONTH(human_resource.off_duty.endDate))='2' then 'ก.พ.' when(MONTH(human_resource.off_duty.endDate))='3' then 'มี.ค.' when(MONTH(human_resource.off_duty.endDate))='4' then 'เม.ย.' when(MONTH(human_resource.off_duty.endDate))='5' then 'พ.ค.' when(MONTH(human_resource.off_duty.endDate))='6' then 'มิ.ย.' when(MONTH(human_resource.off_duty.endDate))='7' then 'ก.ค.' when(MONTH(human_resource.off_duty.endDate))='8' then 'ส.ค.' when(MONTH(human_resource.off_duty.endDate))='9' then 'ก.ย.' ELSE CAST(human_resource.off_duty.endDate AS DATE) END, ' ',YEAR(human_resource.off_duty.endDate)) AS endDate, amount FROM human_resource.userinfo as huser inner join human_resource.off_duty as off_duty on huser.NAME = off_duty.user INNER JOIN human_resource.departments as dept on huser.DEPTID = dept.dept_id WHERE startDate BETWEEN '{0}' AND '{1}' ", dateStart, dateEnd);
            dtReport = DataAccess.RetriveData(sqlOffDuty);

            if (dtReport.Rows.Count == 0 || dtReport.Rows.Count < 1)
            {
                XtraMessageBox.Show("ไม่พบข้อมูลในช่วงเวลาที่ท่านค้นหา", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtReport.Dispose();
                dtReport = null;
                return;
            }
            else
            {
                dgvOffDuty.DataSource = dtReport;

                foreach (DataRow row in dtReport.Rows)
                {
                    ds.Tables[0].Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            LoadData();
            btnEXCEL.Enabled = true;
            btnPDF.Enabled = true;
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            //dsOffDuty ds = new dsOffDuty();
            //foreach (DataRow row in dtReport.Rows)
            //{
            //    ds.Tables[0].Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
            //}

            rptOffDuty rpt = new rptOffDuty();
            rpt.DataSource = ds;

            Directory.CreateDirectory(@"C:\Temp\EXPORT");
            string path = $"C:\\Temp\\EXPORT\\รายงานการลา_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx";

            rpt.ExportToXlsx(path);
            Process.Start(@"C:\Temp\EXPORT");
        }
    }
}