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
using System.Security.Cryptography;

namespace HumanResource.zProject_CentralShareFolder
{
    public partial class FormAccessFolder : DevExpress.XtraEditors.XtraForm
    {
        // รับค่าจาก FormCentralFolder
        private string department;

        private FormCentralFolder formCentralFolder;

        public FormAccessFolder(string dept, FormCentralFolder formCentralFolder)
        {
            InitializeComponent();
            this.department = dept;
            this.formCentralFolder = formCentralFolder;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                string sql = string.Format(@"SELECT password, path, departmentName FROM human_resource.folder_access WHERE department = '{0}'", department);
                dt = DataAccess.RetriveData(sql);
                string encrypt = DataAccess._EncryptPassword(txtPassword.Text.Trim());
                if (encrypt == dt.Rows[0][0].ToString())
                {
                    this.Hide();

                    // เช็คว่า เปิดแล้วหรือยัง ถ้าเปิด ก็ให้ focus ไปเลย
                    FormPathFolder frm = Application.OpenForms["FormPathFolder"] as FormPathFolder;
                    if (frm != null)
                        frm.Focus();
                    else
                    {
                        frm = new FormPathFolder(dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                        frm.Name = "FormPathFolder";
                        frm.MdiParent = formCentralFolder;
                        frm.Show();
                    }
                }
                else
                {
                    XtraMessageBox.Show("รหัสผ่านไม่ถูกต้อง", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtPassword.Focus();
                    return;
                }
            }
        }
    }
}