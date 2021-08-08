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
using BackOfficeApplication.Model;
using BackOfficeApplication.DataCenter;
using MySql.Data.MySqlClient;
using HumanResource.zProject_CentralShareFolder;
using System.Threading;

namespace HumanResource
{
    public partial class FormSetting : DevExpress.XtraEditors.XtraForm
    {
        private ConnectionStringModel model = new ConnectionStringModel();

        public FormSetting()
        {
            InitializeComponent();
        }

        private void GetConnection()
        {
            try
            {
                string path = "C:\\Temp\\config.txt";
                string[] lines = File.ReadAllLines(path);
                model.server = lines[0];
                model.userid = lines[1];
                model.password = lines[2];

                txtServer.Text = lines[0];
                txtUserID.Text = lines[1];
                txtPassword.Text = lines[2];
            }
            catch
            {
            }
        }

        private void GetDepartment()
        {
            dgvFolderAccess.Rows.Clear();
            try
            {
                string sql = "SELECT id, department, path FROM human_resource.folder_access WHERE department != 'Central'";
                DataTable dt = new DataTable();
                dt = DataAccess.RetriveData(sql);

                foreach (DataRow row in dt.Rows)
                {
                    dgvFolderAccess.Rows.Add(row["id"].ToString(), row["department"].ToString(), row["path"].ToString(), "เปลี่ยนรหัส");
                }
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "C:\\Temp\\config.txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(txtServer.Text.Trim());
                sw.WriteLine(txtUserID.Text.Trim());
                sw.WriteLine(txtPassword.Text.Trim());
                sw.Close();

                model.server = txtServer.Text;
                model.userid = txtUserID.Text;
                model.password = txtPassword.Text;
                GetDepartment();
                XtraMessageBox.Show("บันทึกเรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            GetConnection();
            GetDepartment();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string path = "C:\\Temp\\config.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(txtServer.Text.Trim());
            sw.WriteLine(txtUserID.Text.Trim());
            sw.WriteLine(txtPassword.Text.Trim());
            sw.Close();

            model.server = txtServer.Text;
            model.userid = txtUserID.Text;
            model.password = txtPassword.Text;
            GetDepartment();

            if (txtServer.Text == "")
            {
                XtraMessageBox.Show("ใส่ที่อยู่เซิฟเวอร์ด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServer.Focus();
                return;
            }
            if (txtUserID.Text == "")
            {
                XtraMessageBox.Show("ใส่ user เข้าใช้งาน server ด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Focus();
                return;
            }
            //if (txtPassword.Text == "")
            //{
            //    XtraMessageBox.Show("ใส่ password เข้าใช้งาน server ด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtPassword.Focus();
            //    return;
            //}

            MySqlConnection con = new MySqlConnection(
                        "Persist Security Info=False; " +
                        "server='" + model.server + "';" +
                        " userid='" + model.userid + "'; " +
                        "password='" + model.password + "';" +
                        "pooling=false; charset=tis620;" +
                        "Allow User Variables=true;" +
                        "default command timeout=820;" +
                        "Max Pool Size=200;" +
                        "Allow User Variables=true;" +
                        "Allow Zero Datetime=true;");

            con.Open();
            if (con.State == ConnectionState.Open)
            {
                XtraMessageBox.Show("การเชื่อมต่อเซิฟเวอร์เสร็จสมบูรณ์ครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                XtraMessageBox.Show("เชื่อมต่อไม่สำเร็จ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
        }

        private void dgvFolderAccess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvFolderAccess.Columns[e.ColumnIndex].Name;
            if (colName == "edit")
            {
                FormChangeFolderPassword f = new FormChangeFolderPassword();
                f.txtDepartment.Text = this.dgvFolderAccess.CurrentRow.Cells[1].Value.ToString();
                f.txtPassword.Focus();
                f.ShowDialog();
            }
        }
    }
}