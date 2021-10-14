﻿using BackOfficeApplication.DataCenter;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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

namespace HumanResource.zProject_DrugManagement.ui
{
    public partial class FormDrugLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormDrugLogin()
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
                    MessageBox.Show("เข้าสู่ระบบไม่สำเร็จครบ 3 ครั้ง ระบบจะปิดตัวอัตโนมัติ" + Environment.NewLine + "กรุณาติดต่อทีมผู้ดูแลระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }

                // check login
                if (Login("hosdata") == true)
                {
                    DataTable dt = new DataTable();
                    dt = DataAccess.RetriveData(string.Format(@"SELECT drug, userid FROM hosdata.user WHERE hosdata.user.userlogin = '{0}'", txtUser.Text.Trim()));

                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        //Open Wait Form
                        SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
                        SplashScreenManager.Default.SetWaitFormCaption("คุณไม่มีสิทธิ์เข้าสู่ระบบ");

                        for (int i = 3; i > 0; i--)
                        {
                            //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.

                            SplashScreenManager.Default.SetWaitFormDescription($"ระบบจะปิดตัวใน...{i.ToString()}");
                            Thread.Sleep(2000);
                        }
                        //Close Wait Form
                        SplashScreenManager.CloseForm(false);
                        Application.Exit();
                    }
                    else
                    {
                        this.Close();
                        Thread t = new Thread((ThreadStart)(() =>
                        {
                            FormDrugMain f = new FormDrugMain(dt.Rows[0]["userid"].ToString());
                            f.ShowDialog();
                        }));
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                    }
                }
                else
                {
                    count++;
                    MessageBox.Show("เข้าสู่ระบบไม่สำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}