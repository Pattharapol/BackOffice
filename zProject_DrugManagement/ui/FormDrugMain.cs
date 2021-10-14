using BackOfficeApplication.DataCenter;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HumanResource.zProject_DrugManagement.ui
{
    public partial class FormDrugMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private string user_id { get; }

        public FormDrugMain()
        {
            InitializeComponent();
        }

        public FormDrugMain(string userid)
        {
            InitializeComponent();
            this.user_id = userid;

            this.Text = "คลังเวชภัณฑ์โรงพยาบาลโพธิ์ศรีสุวรรณ - " + DataAccess.RetriveData(string.Format(@"SELECT hosdata.user.username FROM hosdata.user WHERE hosdata.user.userid = '{0}'", user_id)).Rows[0][0].ToString();
        }

        private void menuReceiveProducts_Click_1(object sender, EventArgs e)
        {
            // close all open form
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "FormDrugMain" && Application.OpenForms[i].Name != "FormMainMenu")
                    Application.OpenForms[i].Close();
            }

            // each form must be the same size 1328, 818
            frmReceiveProducts f = new frmReceiveProducts(user_id);
            f.TopLevel = false;
            fluentDesignFormContainer1.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }

        private void menuCheckReceiveDrug_Click(object sender, EventArgs e)
        {
            // close all open form
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "FormDrugMain" && Application.OpenForms[i].Name != "FormMainMenu")
                    Application.OpenForms[i].Close();
            }

            // each form must be the same size 1328, 818
            frmCooperateCheck f = new frmCooperateCheck(user_id);
            f.TopLevel = false;
            fluentDesignFormContainer1.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }
    }
}