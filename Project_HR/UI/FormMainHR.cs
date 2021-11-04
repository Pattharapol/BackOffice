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

namespace BackOfficeApplication.Project_HR.UI
{
    public partial class FormMainHR : DevExpress.XtraEditors.XtraForm
    {
        public FormMainHR()
        {
            InitializeComponent();
        }

        private void tsUpdateData_Click(object sender, EventArgs e)
        {
            FormUpdateData f = new FormUpdateData();
            f.ShowDialog();
        }

        private void tsOffDuty_Click(object sender, EventArgs e)
        {
            FormOffDuty f = new FormOffDuty();
            f.ShowDialog();
        }

        private void tsRandomCheck_Click(object sender, EventArgs e)
        {
            FormRandomCheckOfficer f = new FormRandomCheckOfficer();
            f.ShowDialog();
        }

        private void tsReport_Click(object sender, EventArgs e)
        {
            FormReport f = new FormReport();
            f.ShowDialog();
        }
    }
}