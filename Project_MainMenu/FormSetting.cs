using BackOfficeApplication.DataCenter;
using BackOfficeApplication.Model;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOfficeApplication.Project_MainMenu
{
    public partial class FormSetting : DevExpress.XtraEditors.XtraForm
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            GetConnection();
            GetDepartment();
            cboTypeOfUse.SelectedIndex = 0;
        }

        private void GetConnection()
        {
            try
            {
                string path = "C:\\Temp\\config.txt";

                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    ConnectionString.Server = lines[0];
                    ConnectionString.Userid = lines[1];
                    ConnectionString.Password = lines[2];
                    ConnectionString.PicurePath = lines[3];

                    txtServer.Text = lines[0];
                    txtUserID.Text = lines[1];
                    txtPassword.Text = lines[2];
                    cbxPicPath.Text = lines[3];
                }
                else
                {
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("192.168.0.2");
                    sw.WriteLine("root");
                    sw.WriteLine("boom123");
                    sw.Close();

                    ConnectionString.Server = "192.168.0.2";
                    ConnectionString.Userid = "root";
                    ConnectionString.Password = "boom123";
                    //ConnectionString.PicurePath = path;
                }
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
                bool result = DataAccess.CheckConnection();
                if (result)
                {
                    string sql = "SELECT id, department, path FROM human_resource.folder_access WHERE department != 'Central'";
                    DataTable dt = new DataTable();
                    dt = DataAccess.RetriveData(sql);
                    if (dt == null)
                    {
                    }
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            dgvFolderAccess.Rows.Add(row["id"].ToString(), row["department"].ToString(), row["path"].ToString(), "เปลี่ยนรหัส");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("ทำการเชื่อมต่อไม่ได้ กรุณาติดต่อทีม Admin", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
            }
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
            sw.WriteLine(cbxPicPath.Text);
            sw.Close();

            ConnectionString.Server = txtServer.Text;
            ConnectionString.Userid = txtUserID.Text;
            ConnectionString.Password = txtPassword.Text;
            ConnectionString.PicurePath = cbxPicPath.Text;
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
                        "server='" + ConnectionString.Server + "';" +
                        " userid='" + ConnectionString.Userid + "'; " +
                        "password='" + ConnectionString.Password + "';" +
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxPicPath.Text == "")
            {
                XtraMessageBox.Show("เลือกที่เก็บรูปภาพก่อนครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string path = "C:\\Temp\\config.txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(txtServer.Text.Trim());
                sw.WriteLine(txtUserID.Text.Trim());
                sw.WriteLine(txtPassword.Text.Trim());
                sw.WriteLine(cbxPicPath.Text.Trim());
                sw.Close();

                ConnectionString.Server = txtServer.Text;
                ConnectionString.Userid = txtUserID.Text;
                ConnectionString.Password = txtPassword.Text;
                ConnectionString.PicurePath = cbxPicPath.Text;
                GetDepartment();
                XtraMessageBox.Show("บันทึกเรียบร้อยแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
            }
        }

        private void cboTypeOfUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cboTypeOfUse index
            // ฉีดวัคซีนในโรงพยาบาล => 1
            //ฉีดวัคซีนนอกพื้นที่ => 2
            //โอนถ่ายข้อมูลการฉีดวัคซีน => 3
            if (cboTypeOfUse.SelectedIndex != 0)
            {
                if (cboTypeOfUse.SelectedIndex == 1 || cboTypeOfUse.SelectedIndex == 3)
                {
                    //โอนถ่ายข้อมูลการฉีดวัคซีน => 3
                    // ฉีดวัคซีนในโรงพยาบาล => 1
                    ConnectionString.Server = "192.168.0.2";
                    ConnectionString.Userid = "root";
                    ConnectionString.Password = "boom123";
                    ConnectionString.PicurePath = @"\\192.168.0.15\ubuntu@15\#3 Pictures\PeopleImage\";

                    string path = "C:\\Temp\\config.txt";
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine(ConnectionString.Server);
                    sw.WriteLine(ConnectionString.Userid);
                    sw.WriteLine(ConnectionString.Password);
                    sw.WriteLine(ConnectionString.PicurePath);
                    sw.Close();

                    txtServer.Text = ConnectionString.Server;
                    txtUserID.Text = ConnectionString.Userid;
                    txtPassword.Text = ConnectionString.Password;
                    cbxPicPath.SelectedIndex = 0;
                }
                if (cboTypeOfUse.SelectedIndex == 2)
                {
                    //ฉีดวัคซีนนอกพื้นที่ => 2
                    ConnectionString.Server = "localhost";
                    ConnectionString.Userid = "root";
                    ConnectionString.Password = "";
                    ConnectionString.PicurePath = @"C:\Temp\Pictures\";

                    string path = "C:\\Temp\\config.txt";
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine(ConnectionString.Server);
                    sw.WriteLine(ConnectionString.Userid);
                    sw.WriteLine(ConnectionString.Password);
                    sw.WriteLine(ConnectionString.PicurePath);
                    sw.Close();

                    txtServer.Text = ConnectionString.Server;
                    txtUserID.Text = ConnectionString.Userid;
                    txtPassword.Text = ConnectionString.Password;
                    cbxPicPath.SelectedIndex = 1;
                }
            }
            else
            {
            }
        }
    }
}