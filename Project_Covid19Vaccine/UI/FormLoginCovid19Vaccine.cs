using BackOfficeApplication.DataCenter;
using BackOfficeApplication.Project_MainMenu;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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

namespace BackOfficeApplication.Project_Covid19Vaccine.UI
{
    public partial class FormLoginCovid19Vaccine : DevExpress.XtraEditors.XtraForm
    {
        public FormLoginCovid19Vaccine()
        {
            InitializeComponent();
        }

        private void FormLoginCovid19Vaccine_KeyDown(object sender, KeyEventArgs e)
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
                    //MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    this.Close();

                    DataTable dt = new DataTable();
                    dt = DataAccess.RetriveData(string.Format(@"SELECT * FROM hosdata.user WHERE hosdata.user.userlogin = '{0}'", txtUser.Text.Trim()));
                    if (Convert.ToInt32(dt.Rows[0]["drug"].ToString()) == 1)
                    {
                        Thread t = new Thread((ThreadStart)(() =>
                        {
                            //actually FormCovid19VaccineMain
                            // idk where it from

                            FormCovid19VaccineMain f = new FormCovid19VaccineMain();
                            f.ShowDialog();
                        }));
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                    }
                    else
                    {
                        this.Close();
                        Thread.Sleep(10);
                        SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), false, false, false);
                        for (int i = 3; i > 0; i--)
                        {
                            SplashScreenManager.Default.SetWaitFormCaption("แจ้งเตือน");
                            SplashScreenManager.Default.SetWaitFormDescription($"ท่านไม่มีสิทธิ์เข้าใช้งาน ระบบจะปิดตัวใน...{i}");
                            Thread.Sleep(2000);
                        }
                        Application.Exit();
                    }
                }
                else
                {
                    count++;
                    MessageBox.Show("รหัสผ่าน หรือ ชื่อผู้ใช้งาน ไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}