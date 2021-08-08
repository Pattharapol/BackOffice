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

namespace HumanResource.UI
{
    public partial class FormSearchOfficer : DevExpress.XtraEditors.XtraForm
    {
        private FormOffDuty FormOffDuty;

        public FormSearchOfficer(FormOffDuty frm, string searchValue)
        {
            InitializeComponent();
            this.FormOffDuty = frm;
            this.txtSearch.Text = searchValue;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
        }

        private void SearchOfficer(string searchValue)
        {
            string sql = "";

            if (searchValue == "")
            {
                sql = string.Format(@"select user.NAME, dept.dept_id, dept.dept_name  from human_resource.userinfo as user INNER JOIN human_resource.departments as dept on user.DEPTID = dept.dept_id");
            }
            else
            {
                sql = string.Format(@"select user.NAME, dept.dept_id, dept.dept_name  from human_resource.userinfo as user INNER JOIN human_resource.departments as dept on user.DEPTID = dept.dept_id where user.NAME like '%{0}%'", searchValue);
            }

            DataTable dt = new DataTable();
            dt = DataAccess.RetriveData(sql);
            dgvSearch.DataSource = dt;
            dgvSearch.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSearch.Columns[1].Visible = false;
            dgvSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchOfficer(txtSearch.Text.Trim());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (dgvSearch.SelectedRows.Count == 1)
            {
                FormOffDuty.txtSearchOfficer.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
                FormOffDuty.lblDeptID.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString();
                FormOffDuty.txtDept.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("กรุณาเลือกรายการที่ต้องการเพียง 1 รายการครับ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}