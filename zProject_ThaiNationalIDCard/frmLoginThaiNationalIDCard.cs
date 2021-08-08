using BackOfficeApplication.DataCenter;
using DevExpress.XtraEditors;
using HumanResource.DataCenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard.Example;

namespace HumanResource.zProject_ThaiNationalIDCard
{
    public partial class frmLoginThaiNationalIDCard : DevExpress.XtraEditors.XtraForm
    {
        public frmLoginThaiNationalIDCard()
        {
            InitializeComponent();
        }

        public bool Login(string table)
        {
            Authentication authentication = new Authentication();

            string strpass = txtPassword.Text.Trim();
            string strUser = txtUser.Text.Trim();
            string himpass = "";
            string usrpass = "";
            System.Data.DataSet dshim;
            System.Data.DataSet dsusr;
            Int32 intpass = 0;
            try
            {
                dshim = authentication.BdsHimproServer("select *, cast(netpass as char) netpass from hosdata.user where userlogin='" + strUser + "' ", "himusr", table);
                if (dshim.Tables["himusr"].Rows.Count > 0)
                {
                    himpass = dshim.Tables["himusr"].Rows[0]["netpass"].ToString();
                }

                foreach (char c in strpass)
                {
                    intpass = intpass + (int)c;
                }

                dsusr = authentication.BdsHimproServer("select cast(md5('" + intpass.ToString() + "') as char) netpass ", "usrpass", table);
                if (dsusr.Tables["usrpass"].Rows.Count > 0)
                {
                    usrpass = dsusr.Tables["usrpass"].Rows[0]["netpass"].ToString();
                }
                else
                {
                    usrpass = "xx";
                }

                if (usrpass != himpass)
                {
                    MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("@พบปัญหาในการ Login โปรดติดต่อผู้ดูแลระบบ\n" + ex + "", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private int count = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // if wrong login for 3 times
                // Application will close immediately
                if (count == 3)
                {
                    XtraMessageBox.Show("เข้าสู่ระบบไม่สำเร็จครบ 3 ครั้ง ระบบจะปิดตัวอัตโนมัติ" + Environment.NewLine + "กรุณาติดต่อทีมผู้ดูแลระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }

                // check login
                if (Login("hosdata") == true)
                {
                    if (txtUser.Text.Trim() == "TIKK" || txtUser.Text == "YUY" || txtUser.Text == "613051027")
                    {
                        this.Close();

                        // ส่งค่าไปด้วย เพื่อเก็บในฐานข้อมูล
                        string sqlSelect = string.Format(@"SELECT username FROM hosdata.user WHERE hosdata.user.userlogin = '{0}'", txtUser.Text.Trim());
                        DataTable dt = new DataTable();
                        dt = DataAccess.RetriveData(sqlSelect);

                        // เรียก thread ใหม่ให้มาทำงาน
                        Thread t = new Thread((ThreadStart)(() =>
                        {
                            // ส่งชื่อเจ้าหน้าที่ เพื่อไปบันทึก , string officerUsername at frmThaiCardMain
                            frmThaiCardMain f = new frmThaiCardMain(dt.Rows[0][0].ToString());
                            f.BringToFront();
                            f.ShowDialog();
                        }));
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                    }
                    else
                    {
                        XtraMessageBox.Show("คุณไม่มีสิทธิ์เข้าสู่ระบบนี้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
                else
                {
                    count++;
                    XtraMessageBox.Show("เข้าสู่ระบบไม่สำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtUser_EditValueChanged(object sender, EventArgs e)
        {
            txtUser.Text = txtUser.Text.ToUpper();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            txtUser.Text = txtUser.Text.ToUpper();
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            txtUser.Text = txtUser.Text.ToUpper();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUser.Text = txtUser.Text.ToUpper();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}