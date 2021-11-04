using BackOfficeApplication.Project_MainMenu;
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

namespace BackOfficeApplication.MainUI
{
    public partial class FormLoginSetting : DevExpress.XtraEditors.XtraForm
    {
        public FormLoginSetting()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FormLoginSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10 && (e.Alt))
            {
                this.Hide();
                FormSetting f = new FormSetting();
                f.ShowDialog();
            }
        }
    }
}