using BackOfficeApplication.DataCenter;
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

namespace BackOfficeApplication.Project_HR.UI
{
    public partial class FormOffDuty : DevExpress.XtraEditors.XtraForm
    {
        public FormOffDuty()
        {
            InitializeComponent();
        }

        private void FormOffDuty_Load(object sender, EventArgs e)
        {
            DataAccess.GetConnectionString();
            LoadOffDutyWorker();
            FillComboboxTypeOf_OffDuty();
            this.cboType.SelectedIndex = 0;
            this.btnCancel.Visible = true;
        }

        public void FillComboboxTypeOf_OffDuty()
        {
            DataTable dt = new DataTable();
            dt = DataAccess.RetriveData("SELECT type_name FROM human_resource.off_duty_type");

            cboType.Items.Add("-----เลือกรายการลา-----");
            foreach (DataRow data in dt.Rows)
            {
                cboType.Items.Add(data["type_name"].ToString());
            }
        }

        private void LoadOffDutyWorker()
        {
            dgvOffDuty.Rows.Clear();
            DataTable dt = new DataTable();

            string month = DateTime.Now.ToString("yyyy-MM");
            string dateStart = month + "-" + "01";
            string dateEnd = month + "-" + "31";

            //string sql = string.Format(@"select off.id, off.user, dept.dept_name, off.startDate, off.endDate, off.amount from human_resource.userinfo as userinfo INNER JOIN human_resource.departments as dept on userinfo.DEPTID = dept.dept_id inner join off_duty as off on userinfo.NAME = off.`user` where human_resource.off.startDate between '{0}' and '{1}'", dateStart, dateEnd);

            string sql = string.Format(@"select off.id, off.user, dept.dept_id, dept.dept_name, off.type, date_format(off.startDate, '%Y-%m-%d') as startDate, date_format(off.endDate, '%Y-%m-%d') as endDate, off.amount from human_resource.userinfo as userinfo INNER JOIN human_resource.departments as dept on userinfo.DEPTID = dept.dept_id inner join human_resource.off_duty as off on userinfo.NAME = off.`user` where human_resource.off.startDate between '{0}' and '{1}'", dateStart, dateEnd);

            dt = DataAccess.RetriveData(sql);
            foreach (DataRow data in dt.Rows)
            {
                // convert to พ.ศ.
                string startDate = Convert.ToDateTime(data["startDate"].ToString()).ToString("yyyy-MM-dd");
                //string date1 = (Convert.ToInt32(startDate.Substring(0, 4))) + startDate.Substring(4);

                string endDate = Convert.ToDateTime(data["endDate"].ToString()).ToString("yyyy-MM-dd");
                //string date2 = (Convert.ToInt32(endDate.Substring(0, 4))) + endDate.Substring(4);

                dgvOffDuty.Rows.Add(data["id"].ToString(), data["user"].ToString(), data["dept_id"].ToString(), data["dept_name"].ToString(), data["type"].ToString(), startDate, endDate, data["amount"].ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOffDuty.SelectedRows.Count == 1)
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                dgvOffDuty.Enabled = false;
                txtSearchOfficer.Text = dgvOffDuty.CurrentRow.Cells[1].Value.ToString();
                lblDeptID.Text = dgvOffDuty.CurrentRow.Cells[2].Value.ToString();
                txtDept.Text = dgvOffDuty.CurrentRow.Cells[3].Value.ToString();
                cboType.Text = dgvOffDuty.CurrentRow.Cells[4].Value.ToString();
                dtpStartDate.Value = Convert.ToDateTime(dgvOffDuty.CurrentRow.Cells[5].Value.ToString());
                dtpEndDate.Value = Convert.ToDateTime(dgvOffDuty.CurrentRow.Cells[6].Value.ToString());
                txtAmount.Text = dgvOffDuty.CurrentRow.Cells[7].Value.ToString();
            }
            else
            {
                XtraMessageBox.Show("กรุณาเลือกรายการที่ต้องการ เพียง 1 รายการครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            dgvOffDuty.Enabled = true;
            txtSearchOfficer.Text = "";
            lblDeptID.Text = "";
            txtDept.Text = "";
            cboType.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtAmount.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOffDuty.SelectedRows.Count == 1)
            {
                if (XtraMessageBox.Show("คุณต้องการลบรายการที่เลือก ใช่หรือไม่", "แจ้งทราบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = dgvOffDuty.CurrentRow.Cells[0].Value.ToString();
                    string sql = string.Format(@"delete from human_resource.off_duty where id = '{0}'", id);
                    DataAccess.ExecuteSQL(sql);
                    XtraMessageBox.Show("ลบรายการที่เลือกเรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOffDutyWorker();
                    return;
                }
                else
                {
                }
            }
            else
            {
            }

            btnCancel_Click(sender, e);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSearchOfficer.Text == "")
            {
                XtraMessageBox.Show("กรุณาใส่ชื่อเจ้าหน้าที่ด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchOfficer.Focus();
                return;
            }

            if (cboType.SelectedIndex == 0)
            {
                XtraMessageBox.Show("กรุณาเลือกประเภทของการลาด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboType.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                XtraMessageBox.Show("กรุณาระบุจำนวนวันลาด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            string id = dgvOffDuty.CurrentRow.Cells[0].Value.ToString();
            string dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string sql = string.Format(@"update human_resource.off_duty set user = '{0}', dept_id = '{1}', type = '{2}', startDate = '{3}', endDate = '{4}', amount = '{5}' where id = '{6}' ", txtSearchOfficer.Text.Trim(), lblDeptID.Text, cboType.Text.Trim(), dateStart, dateEnd, txtAmount.Text.Trim(), id);

            txtAmount.Clear();
            txtSearchOfficer.ReadOnly = false;
            txtSearchOfficer.Enabled = true;
            txtSearchOfficer.Clear();
            txtSearchOfficer.Focus();
            cboType.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtDept.Clear();
            lblDeptID.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSearchOfficer.Text == "")
            {
                XtraMessageBox.Show("กรุณาใส่ชื่อเจ้าหน้าที่ด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchOfficer.Focus();
                return;
            }

            if (cboType.SelectedIndex == 0)
            {
                XtraMessageBox.Show("กรุณาเลือกประเภทของการลาด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboType.Focus();
                return;
            }

            if (txtAmount.Text == "")
            {
                XtraMessageBox.Show("กรุณาระบุจำนวนวันลาด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            if (Convert.ToInt32(txtAmount.Text) < 1)
            {
                XtraMessageBox.Show("จำนวนวันลาเป็น 0 หรือ ติดลบ กรุณาตรวจสอบอีกครั้งครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            string dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string sql = string.Format(@"insert into human_resource.off_duty (user, dept_id, type, startDate, endDate, amount) values ('{0}','{1}','{2}','{3}','{4}','{5}')", txtSearchOfficer.Text.Trim(), lblDeptID.Text, cboType.Text.Trim(), dateStart, dateEnd, txtAmount.Text.Trim());
            DataAccess.ExecuteSQL(sql);
            XtraMessageBox.Show("บันทึกวันลาของเจ้าหน้าที่ เรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOffDutyWorker();
            txtAmount.Clear();
            txtSearchOfficer.ReadOnly = false;
            txtSearchOfficer.Enabled = true;
            txtSearchOfficer.Clear();
            txtSearchOfficer.Focus();
            cboType.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtDept.Clear();
            lblDeptID.Text = "";
            txtAmount.Text = "";
        }

        private void txtSearchOfficer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormSearchOfficer f = new FormSearchOfficer(this, txtSearchOfficer.Text);
                f.ShowDialog();
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            // นับวันลาอัตโนมัติ

            string dateStart = dtpStartDate.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtpEndDate.Value.ToString("yyyy-MM-dd");

            string monthStart = dateStart.Substring(5, 2);
            string monthEnd = dateEnd.Substring(5, 2);

            string dayStart = dateStart.Substring(8);
            string dayEnd = dateEnd.Substring(8);

            // ถ้าเดือนเดียวกัน
            if (monthStart == monthEnd)
            {
                // ถ้าวันที่เริ่มน้อยกว่า วันที่สิ้นสุด
                if (Convert.ToInt32(dayEnd) < Convert.ToInt32(dayStart))
                {
                    XtraMessageBox.Show("วันที่สิ้นสุดการลา น้อยกว่าวันที่เริ่มการลา กรุณาตรวจสอบใหม่อีกครั้งครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = false;
                    return;
                }
                // ปกติ
                else
                {
                    txtAmount.Text = Convert.ToString(Convert.ToInt32(dayEnd) - Convert.ToInt32(dayStart) + 1);
                    btnSave.Enabled = true;
                }
            }
            // คนละเดือน
            else
            {
                // ลงท้ายด้วย ..คม
                if (monthStart == "01" || monthStart == "03" || monthStart == "05" || monthStart == "07" || monthStart == "08" || monthStart == "10" || monthStart == "12")
                {
                    int dayTotal = (31 - Convert.ToInt32(dayStart) + 1) + Convert.ToInt32(dayEnd);
                    txtAmount.Text = Convert.ToString(dayTotal);
                    return;
                }
                // ลงท้ายด้วย ..ยน
                else if (monthStart == "04" || monthStart == "06" || monthStart == "09" || monthStart == "11")
                {
                    int dayTotal = (30 - Convert.ToInt32(dayStart) + 1) + Convert.ToInt32(dayEnd);
                    txtAmount.Text = Convert.ToString(dayTotal);
                    return;
                }
                // กุมภาพันธ์
                else
                {
                    // แปลงเป็น คศ
                    int leapYear = Convert.ToInt32(dateStart.Substring(0, 4)) - 543;

                    // is leapYear
                    // ปีอธิกสุรทินคือปีที่ -->
                    // เงื่อนไขที่ 1. หารด้วย 4 ลงตัว, หารด้วย 100 ไม่ลงตัว
                    // เงื่อนไขที่ 2. แต่หารด้วย 400 ลงตัว
                    if ((leapYear % 4 == 0 && leapYear % 100 != 0) || leapYear % 400 == 0)
                    {
                        int dayTotal = (29 - Convert.ToInt32(dayStart) + 1) + Convert.ToInt32(dayEnd);
                        txtAmount.Text = Convert.ToString(dayTotal);
                        return;
                    }
                    // is not leapYear
                    else
                    {
                        int dayTotal = (28 - Convert.ToInt32(dayStart) + 1) + Convert.ToInt32(dayEnd);
                        txtAmount.Text = Convert.ToString(dayTotal);
                        return;
                    }
                }
            }
        }

        private void txtSearchOfficer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDept.Text = CommonCOde.getDepartmentByUserName(txtSearchOfficer.Text.Trim());
            }
            catch
            {
            }
        }

        private void btnOffDutyType_Click(object sender, EventArgs e)
        {
            FormOffDutyType f = new FormOffDutyType(this);
            f.ShowDialog();
        }
    }
}