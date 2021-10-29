using System;
using HumanResource.UI;
using HumanResource.zProject_CentralShareFolder;
using HumanResource.zProject_Covid19Vaccine;
using HumanResource.zProject_DrugManagement.ui;
using HumanResource.zProject_ThaiNationalIDCard.UI;

//using ThaiNationalIDCard.Example;

namespace HumanResource
{
    public partial class FormMainMenu : DevExpress.XtraEditors.XtraForm
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {
            FormLoginSetting f = new FormLoginSetting();
            f.ShowDialog();
        }

        private void btnHumanResource_Click(object sender, EventArgs e)
        {
            FormLoginHumanResource f = new FormLoginHumanResource();
            f.ShowDialog();
        }

        private void btnCentralFolder_Click(object sender, EventArgs e)
        {
            FormLoginCentralFolder f = new FormLoginCentralFolder();
            f.ShowDialog();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            //FormLoginSetting f = new FormLoginSetting();
            //f.ShowDialog();
        }

        private void btnSmartCardReader_Click(object sender, EventArgs e)
        {
            frmLoginThaiNationalIDCard f = new frmLoginThaiNationalIDCard();
            f.ShowDialog();
        }

        private void btnCovid19Vaccine_Click(object sender, EventArgs e)
        {
            FormLoginCovid19Vaccine f = new FormLoginCovid19Vaccine();
            f.ShowDialog();
        }

        private void btnDrugManagement_Click(object sender, EventArgs e)
        {
            FormDrugLogin formDrugLogin = new FormDrugLogin();
            formDrugLogin.ShowDialog();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(@"http://192.168.0.3/himpro");
            //webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}