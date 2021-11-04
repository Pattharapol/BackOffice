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

namespace BackOfficeApplication.Project_DrugInventoryManagement.UI
{
    public partial class FormDrugMain : DevExpress.XtraEditors.XtraForm
    {
        private string userid;

        public FormDrugMain()
        {
            InitializeComponent();
        }

        public FormDrugMain(string userid)
        {
            InitializeComponent();
            this.userid = userid;
        }

        private void tsmnReceiveProducts_Click(object sender, EventArgs e)
        {
            FormReceiveProducts f = new FormReceiveProducts(userid);
            f.ShowDialog();
        }
    }
}