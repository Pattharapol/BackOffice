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
using HumanResource.DataCenter;
using System.Threading;

namespace HumanResource
{
    public partial class FormLoginSetting : DevExpress.XtraEditors.XtraForm
    {
        public FormLoginSetting()
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
            DataSet dshim;
            DataSet dsusr;
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
                    if (txtUser.Text.ToLower() == "tikk")
                    {
                        this.Close();

                        // เรียก thread ใหม่ให้มาทำงาน
                        Thread t = new Thread((ThreadStart)(() =>
                        {
                            FormSetting f = new FormSetting();
                            f.ShowDialog();
                        }));
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                    }
                    else
                    {
                        XtraMessageBox.Show("ท่านไม่มีสิทธิ์เข้าสู่ระบบนี้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtUser_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
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