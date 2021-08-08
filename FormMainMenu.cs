using System;
using HumanResource.UI;
using HumanResource.zProject_CentralShareFolder;
using HumanResource.zProject_ThaiNationalIDCard;
using ThaiNationalIDCard.Example;

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
            //FormSetting f = new FormSetting();
            //f.ShowDialog();
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
            FormLoginSetting f = new FormLoginSetting();
            f.ShowDialog();
        }

        private void btnSmartCardReader_Click(object sender, EventArgs e)
        {
            frmLoginThaiNationalIDCard f = new frmLoginThaiNationalIDCard();
            f.ShowDialog();
        }
    }
}