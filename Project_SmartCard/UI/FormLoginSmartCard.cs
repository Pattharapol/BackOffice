﻿using BackOfficeApplication.DataCenter;
using BackOfficeApplication.Project_SmartCard.UI;
using DevExpress.XtraEditors;
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

namespace BackOfficeApplication.Project_ThaiNationalIDCard_CovidVaccine.UI
{
    public partial class FormLoginSmartCard : DevExpress.XtraEditors.XtraForm
    {
        public FormLoginSmartCard()
        {
            InitializeComponent();
        }

        private void FormLoginSmartCard_Load(object sender, EventArgs e)
        {
        }

        private void FormLoginSmartCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        public bool Login(string table)
        {
            //Authentication authentication = new Authentication();

            string strpass = txtPassword.Text.Trim();
            string strUser = txtUser.Text.Trim();
            string himpass = "";
            string usrpass = "";
            DataSet dshim;
            DataSet dsusr;
            Int32 intpass = 0;
            try
            {
                dshim = Authentication.BdsHimproServer("select *, cast(netpass as char) netpass from hosdata.user where userlogin='" + strUser + "' ", "himusr", table);
                if (dshim.Tables["himusr"].Rows.Count > 0)
                {
                    himpass = dshim.Tables["himusr"].Rows[0]["netpass"].ToString();
                }

                foreach (char c in strpass)
                {
                    intpass = intpass + (int)c;
                }

                dsusr = Authentication.BdsHimproServer("select cast(md5('" + intpass.ToString() + "') as char) netpass ", "usrpass", table);
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
                    // XtraMessageBox.Show("รหัสผ่านไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("@พบปัญหาในการ Login โปรดติดต่อผู้ดูแลระบบ\n" + ex + "", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private int count = 0;
        private DataTable dt = new DataTable();

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
                    if (txtUser.Text == "TIKK" || txtUser.Text == "CHANACHAI" || txtUser.Text == "YUY" || txtUser.Text == "CHETSADA" || txtUser.Text == "613051027")
                    {
                        // ส่งค่าไปด้วย ชื่อเจ้าหน้าที่เพื่อไปบันทึก

                        string sql = string.Format(@"SELECT hosdata.user.username FROM hosdata.user WHERE hosdata.user.userlogin = '{0}'", txtUser.Text.Trim());
                        dt = DataAccess.RetriveData(sql);
                        if (dt.Rows.Count > 0)
                        {
                            this.Close();
                            string officerName = dt.Rows[0][0].ToString();

                            Thread t = new Thread((ThreadStart)(() =>
                            {
                                FormSmartCard f = new FormSmartCard(officerName);
                                f.ShowDialog();
                            }));
                            t.SetApartmentState(ApartmentState.STA);
                            t.Start();
                        }
                    }
                }
                else
                {
                    count++;
                    //MessageBox.Show("เข้าสู่ระบบไม่สำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}