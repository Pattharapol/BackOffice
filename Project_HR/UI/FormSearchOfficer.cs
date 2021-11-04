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
    public partial class FormSearchOfficer : DevExpress.XtraEditors.XtraForm
    {
        private FormOffDuty FormOffDuty;
        private FormRandomCheckOfficer FormRandomCheckOfficer;

        public FormSearchOfficer(FormOffDuty frm, string searchValue)
        {
            InitializeComponent();
            //GetConnectionString()
            DataAccess.GetConnectionString();

            this.FormOffDuty = frm;
            this.txtSearch.Text = searchValue;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
            //dgvSearch.Focus();
            //dgvSearch.CurrentRow.Selected = true;
        }

        public FormSearchOfficer(FormRandomCheckOfficer frmRandomCheckOfficer, string searchValue)
        {
            InitializeComponent();
            //GetConnectionString()
            DataAccess.GetConnectionString();

            this.FormRandomCheckOfficer = frmRandomCheckOfficer;
            this.txtSearch.Text = searchValue;
            this.txtSearch.Focus();
            this.txtSearch.SelectAll();
            //dgvSearch.Focus();
            //dgvSearch.CurrentRow.Selected = true;
        }

        private void FormSearchOfficer_Load(object sender, EventArgs e)
        {
        }

        private void SearchOfficer(string searchValue)
        {
            string sql = "";

            if (searchValue == "")
            {
                sql = string.Format(@"select human_resource.userinfo.NAME, human_resource.departments.dept_id, human_resource.departments.dept_name  from human_resource.userinfo INNER JOIN human_resource.departments on human_resource.userinfo.DEPTID = human_resource.departments.dept_id");
            }
            else
            {
                sql = string.Format(@"select human_resource.userinfo.NAME, human_resource.departments.dept_id, human_resource.departments.dept_name  from human_resource.userinfo INNER JOIN human_resource.departments on human_resource.userinfo.DEPTID = human_resource.departments.dept_id where userinfo.NAME like '%{0}%'", searchValue);
            }

            DataTable dt = new DataTable();
            dt = DataAccess.RetriveData(sql);
            if (dt.Rows.Count > 0)
            {
                dgvSearch.DataSource = dt;
                dgvSearch.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSearch.Columns[1].Visible = false;
                dgvSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvSearch.Focus();
                dgvSearch.CurrentRow.Selected = true;
            }
            else
            {
                dgvSearch.DataSource = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            SearchOfficer(txtSearch.Text.Trim());
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (FormOffDuty != null)
            {
                if (dgvSearch.SelectedRows.Count == 1)
                {
                    FormOffDuty.txtSearchOfficer.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
                    FormOffDuty.txtSearchOfficer.ReadOnly = true;
                    this.Close();
                }
            }
            if (FormRandomCheckOfficer != null)
            {
                if (dgvSearch.SelectedRows.Count == 1)
                {
                    FormRandomCheckOfficer.txtSearchOfficer.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
                    FormRandomCheckOfficer.txtSearchOfficer.ReadOnly = true; 
                    this.Close();
                }
            }
        }

        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (FormOffDuty != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvSearch.SelectedRows.Count == 1)
                    {
                        FormOffDuty.txtSearchOfficer.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
                        FormOffDuty.txtSearchOfficer.ReadOnly = true;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("กรุณาเลือกรายการที่ต้องการเพียง 1 รายการครับ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (true)
            {
            }
        }
    }
}