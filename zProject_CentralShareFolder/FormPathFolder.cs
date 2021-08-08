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

namespace HumanResource.zProject_CentralShareFolder
{
    public partial class FormPathFolder : DevExpress.XtraEditors.XtraForm
    {
        // รับค่า path จาก FormAccessFolder
        private string pathFolder;

        private string departmentName;

        public FormPathFolder(string path, string departmentName)
        {
            InitializeComponent();
            this.pathFolder = path;
            this.departmentName = departmentName;
        }

        private void FormPathFolder_Load(object sender, EventArgs e)
        {
            this.Text = departmentName;
            webBrowser.Url = new Uri(@"\\192.168.0.15\" + pathFolder);
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoBack)
            {
                webBrowser.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward)
            {
                webBrowser.GoForward();
            }
        }
    }
}