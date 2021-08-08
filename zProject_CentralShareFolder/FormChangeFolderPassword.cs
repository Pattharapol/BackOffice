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
using System.Security.Cryptography;
using BackOfficeApplication.DataCenter;

namespace HumanResource.zProject_CentralShareFolder
{
    public partial class FormChangeFolderPassword : DevExpress.XtraEditors.XtraForm
    {
        public FormChangeFolderPassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                XtraMessageBox.Show("กรุณากรอกรหัสผ่านด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Length < 6)
            {
                XtraMessageBox.Show("รหัสผ่านไม่ปลอดภัย กรุณากรอกรหัสผ่านมากกว่า 5 ตัวด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            string sql = string.Format(@"UPDATE human_resource.folder_access SET password = '" + (DataAccess._EncryptPassword(txtPassword.Text.Trim()) + "' WHERE department = '" + txtDepartment.Text + "' "));
            DataAccess.ExecuteSQL(sql);
            XtraMessageBox.Show("เปลี่ยนรหัสผ่านเรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}