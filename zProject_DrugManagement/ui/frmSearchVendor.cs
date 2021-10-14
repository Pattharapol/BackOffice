using BackOfficeApplication.DataCenter;
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

namespace HumanResource.zProject_DrugManagement.ui
{
    public partial class frmSearchVendor : DevExpress.XtraEditors.XtraForm
    {
        private frmReceiveProducts FrmReceiveProducts;
        private string searchValue = "";

        public frmSearchVendor(string searchValue, frmReceiveProducts FrmReceiveProducts)
        {
            InitializeComponent();
            this.FrmReceiveProducts = FrmReceiveProducts;
            this.searchValue = searchValue;
        }

        private void frmSearchVendor_Load(object sender, EventArgs e)
        {
            txtSearchVendor.Text = searchValue;
            SearchVendor(searchValue);
        }

        private async void SearchVendor(string searchValue)
        {
            dgvSearchVendor.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchValue))
            {
                query = string.Format(@"select * from drugmanagement.vendor");
            }
            else
            {
                query = string.Format(@"select * from drugmanagement.vendor where vendorName like '%{0}%' or vendorCode like '%{1}%' ", searchValue.Trim(), searchValue.Trim());
            }

            DataTable dt = DataAccess.RetriveData(query);
            dgvSearchVendor.DataSource = dt;
            dgvSearchVendor.Columns[0].Visible = false;
            dgvSearchVendor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSearchVendor.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSearchVendor.Columns[3].Visible = false;
            dgvSearchVendor.Columns[4].Visible = false;
            dgvSearchVendor.Columns[5].Visible = false;
        }

        private void txtSearchVendor_EditValueChanged(object sender, EventArgs e)
        {
            SearchVendor(txtSearchVendor.Text.Trim());
        }

        private void btnChooseVendor_Click(object sender, EventArgs e)
        {
            if (dgvSearchVendor.Rows.Count > 0)
            {
                if (dgvSearchVendor.SelectedRows.Count == 1)
                {
                    if (FrmReceiveProducts != null)
                    {
                        this.FrmReceiveProducts.txtVendor.Text = dgvSearchVendor.CurrentRow.Cells[2].Value.ToString();
                        this.FrmReceiveProducts.lblVendor_ID.Text = dgvSearchVendor.CurrentRow.Cells[0].Value.ToString();
                        this.Close();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("เลือกบริษัทยาก่อนครับ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}