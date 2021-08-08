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
    public partial class FormTypeOfOffDuty : DevExpress.XtraEditors.XtraForm
    {
        public FormTypeOfOffDuty()
        {
            InitializeComponent();
            LoadOffDutyType("");
            txtOffduty.Focus();
        }

        private void LoadOffDutyType(string searchValue)
        {
            dgvOffDuty.DataSource = null;
            DataTable dt = new DataTable();

            string sql = "";
            if (searchValue == "")
            {
                sql = "select type_name from human_resource.off_duty_type";
            }
            else
            {
                sql = string.Format(@"select type_name from human_resource.off_duty_type where type_name like '%{0}%'", searchValue);
            }
            dt = DataAccess.RetriveData(sql);
            dgvOffDuty.DataSource = dt;
            dgvOffDuty.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOffduty.Text == "")
            {
                XtraMessageBox.Show("กรุณาใส่ประเภทวันลาก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOffduty.Focus();
                return;
            }

            // check if its exist
            DataTable dtCheck = new DataTable();
            dtCheck = DataAccess.RetriveData(string.Format(@"select * from human_resource.off_duty_type where type_name = '{0}'", txtOffduty.Text.Trim()));
            if (dtCheck.Rows.Count > 0)
            {
                XtraMessageBox.Show("มีประเภทของวันลานี้แล้วในระบบ...", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOffduty.Focus();
                return;
            }

            // if no, save it
            DataAccess.ExecuteSQL(string.Format(@"insert into human_resource.off_duty_type (type_name) values ('{0}')", txtOffduty.Text.Trim()));
            XtraMessageBox.Show("บันทึกสำเร็จแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtOffduty.Text = "";
            txtOffduty.Focus();
            LoadOffDutyType("");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOffDutyType(txtSearch.Text.Trim());
        }
    }
}