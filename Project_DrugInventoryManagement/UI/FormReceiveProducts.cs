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
    public partial class FormReceiveProducts : DevExpress.XtraEditors.XtraForm
    {
        private string userid;

        public FormReceiveProducts()
        {
            InitializeComponent();
        }

        public FormReceiveProducts(string userid)
        {
            InitializeComponent();
            this.userid = userid;
        }
    }
}