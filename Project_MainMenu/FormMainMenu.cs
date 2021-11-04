using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackOfficeApplication.Project_MainMenu;
using BackOfficeApplication.MainUI;
using BackOfficeApplication.Project_Covid19Vaccine.UI;
using BackOfficeApplication.Project_DrugInventoryManagement.UI;
using BackOfficeApplication.Project_ThaiNationalIDCard_CovidVaccine.UI;
using BackOfficeApplication.Project_HR.UI;
using System.IO;

namespace BackOfficeApplication
{
    public partial class FormMainMenu : DevExpress.XtraEditors.XtraForm
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            FormLoginSetting f = new FormLoginSetting();
            f.ShowDialog();
        }

        private void btnCovid19Vaccine_Click(object sender, EventArgs e)
        {
            FormLoginCovid19Vaccine f = new FormLoginCovid19Vaccine();
            f.ShowDialog();
        }

        private void btnDrugManagement_Click(object sender, EventArgs e)
        {
            FormLoginDrug f = new FormLoginDrug();
            f.ShowDialog();
        }

        private void btnSmartCardReader_Click(object sender, EventArgs e)
        {
            FormLoginSmartCard f = new FormLoginSmartCard();
            f.ShowDialog();
        }

        private void btnHumanResource_Click(object sender, EventArgs e)
        {
            FormLoginHR f = new FormLoginHR();
            f.ShowDialog();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\Temp\\");
            string path = "C:\\Temp\\config.txt";
            try
            {
                if (!File.Exists(path))
                {
                    
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("xxx.xxx.xxx.xxx");
                    sw.WriteLine("xxxx");
                    sw.WriteLine("xxxxxxx");
                    sw.Close();
                }
                else
                {

                }
            }
            catch
            {

            }
            
        }
    }
}