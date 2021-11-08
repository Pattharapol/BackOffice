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
    public partial class FormOffDutyType : DevExpress.XtraEditors.XtraForm
    {
        public FormOffDutyType()
        {
            InitializeComponent();
        }

        private FormOffDuty FormOffDuty;

        public FormOffDutyType(FormOffDuty formOff)
        {
            InitializeComponent();
            this.FormOffDuty = formOff;
            LoadOffDutyType("");
        }

        private void FormOffDutyType_Load(object sender, EventArgs e)
        {
        }

        private void LoadOffDutyType(string searchValue)
        {
            dgvOffDutyType.DataSource = null;
            DataTable dt = new DataTable();

            string sql = "";
            if (searchValue == "")
            {
                sql = "select id, type_name from human_resource.off_duty_type";
            }
            else
            {
                sql = string.Format(@"select id, type_name from human_resource.off_duty_type where type_name like '%{0}%'", searchValue);
            }
            dt = DataAccess.RetriveData(sql);
            dgvOffDutyType.DataSource = dt;
            dgvOffDutyType.Columns[0].Visible = false;
            dgvOffDutyType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOffdutyType.Text == "")
            {
                XtraMessageBox.Show("กรุณาใส่ประเภทวันลาก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOffdutyType.Focus();
                return;
            }

            // check if its exist
            DataTable dtCheck = new DataTable();
            dtCheck = DataAccess.RetriveData(string.Format(@"select * from human_resource.off_duty_type where type_name = '{0}'", txtOffdutyType.Text.Trim()));
            if (dtCheck.Rows.Count > 0)
            {
                XtraMessageBox.Show("มีประเภทของวันลานี้แล้วในระบบ...", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOffdutyType.Focus();
                return;
            }

            // if no, save it
            DataAccess.ExecuteSQL(string.Format(@"insert into human_resource.off_duty_type (type_name) values ('{0}')", txtOffdutyType.Text.Trim()));
            XtraMessageBox.Show("บันทึกสำเร็จแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtOffdutyType.Text = "";
            txtOffdutyType.Focus();
            LoadOffDutyType("");
            FormOffDuty.FillComboboxTypeOf_OffDuty();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOffDutyType(txtSearch.Text.Trim());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOffDutyType.Rows.Count > 0)
            {
                if (dgvOffDutyType.SelectedRows.Count == 1)
                {
                    dgvOffDutyType.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                    txtOffdutyType.Text = dgvOffDutyType.CurrentRow.Cells[1].Value.ToString();
                    txtOffdutyType.Focus();
                    txtOffdutyType.SelectAll();
                }
                else
                {
                    XtraMessageBox.Show("กรุณาเลือกเพียง 1 รายการครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("ไม่มีข้อมูลในตาราง กรุณาทำรายการก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // check empty
            if (txtOffdutyType.Text == "")
            {
                XtraMessageBox.Show("กรุณาใส่ประเภทวันลาก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOffdutyType.Focus();
                return;
            }

            // check if its exist
            DataTable dtCheck = new DataTable();
            dtCheck = DataAccess.RetriveData(string.Format(@"select * from human_resource.off_duty_type where type_name = '{0}'", txtOffdutyType.Text.Trim()));
            if (dtCheck.Rows.Count > 0)
            {
                XtraMessageBox.Show("มีประเภทของวันลานี้แล้วในระบบ...", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOffdutyType.Focus();
                txtOffdutyType.SelectAll();
                return;
            }
            else
            {
                string sql = string.Format("UPDATE human_resource.off_duty_type SET type_name = '{0}' WHERE id = '{1}'", txtOffdutyType.Text.Trim(), dgvOffDutyType.CurrentRow.Cells[0].Value.ToString());
                DataAccess.ExecuteSQL(sql);
                XtraMessageBox.Show("บันทึกแก้ไขสำเร็จแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvOffDutyType.Enabled = true;
                btnUpdate.Enabled = false;
                btnSave.Enabled = true;
                txtOffdutyType.Text = "";
                txtOffdutyType.Focus();
                LoadOffDutyType("");
                FormOffDuty.FillComboboxTypeOf_OffDuty();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOffDutyType != null)
            {
                if (dgvOffDutyType.SelectedRows.Count == 1)
                {
                    if (XtraMessageBox.Show("คุณต้องการลบรายการนี้ใช่หรือไม่", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sql = string.Format(string.Format(@"DELETE FROM human_resource.off_duty_type WHERE id = '{0}'", dgvOffDutyType.CurrentRow.Cells[0].Value.ToString()));
                        DataAccess.ExecuteSQL(sql);

                        LoadOffDutyType("");
                        FormOffDuty.FillComboboxTypeOf_OffDuty();
                    }
                }
                else
                {
                    XtraMessageBox.Show("กรุณาเลือก 1 รายการ เพื่อทำรายการ...", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("ไม่มีรายการในฐานข้อมูล กรุณาทำรายการก่อนครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtOffdutyType.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
    }
}