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
    public partial class frmSearchDrug : DevExpress.XtraEditors.XtraForm
    {
        private frmReceiveProducts frmReceiveProducts;
        private string searchValue = "";

        public frmSearchDrug(string searchValue, frmReceiveProducts frmReceiveProducts)
        {
            InitializeComponent();
            this.frmReceiveProducts = frmReceiveProducts;
            this.searchValue = searchValue;
        }

        private void frmSearchDrug_Load(object sender, EventArgs e)
        {
            txtSearchDrug.Text = searchValue;
            SearchDrugs(txtSearchDrug.Text.Trim());
        }

        private void SearchDrugs(string searchValue)
        {
            dgvSearchDrug.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchValue))
            {
                query = string.Format(@"select * from drugmanagement.drug");
            }
            else
            {
                query = string.Format(@"select * from drugmanagement.drug where drugName like '%{0}%' ", searchValue.Trim());
            }

            DataTable dt = DataAccess.RetriveData(query);
            dgvSearchDrug.DataSource = dt;
            dgvSearchDrug.Columns[0].Visible = false;
            dgvSearchDrug.Columns[1].Visible = false;
            dgvSearchDrug.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSearchDrug.Columns[3].Visible = false;
            dgvSearchDrug.Columns[4].Visible = false;
            dgvSearchDrug.Columns[5].Visible = false;
            dgvSearchDrug.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSearchDrug.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSearchDrug.Columns[8].Visible = false;
            dgvSearchDrug.Columns[9].Visible = false;
        }

        private void txtSearchDrug_EditValueChanged(object sender, EventArgs e)
        {
            SearchDrugs(txtSearchDrug.Text.Trim());
        }

        private void btnChooseDrug_Click(object sender, EventArgs e)
        {
            if (dgvSearchDrug.Rows.Count > 0)
            {
                if (dgvSearchDrug.SelectedRows.Count == 1)
                {
                    if (this.frmReceiveProducts != null)
                    {
                        this.frmReceiveProducts.lblDrug_id.Text = dgvSearchDrug.CurrentRow.Cells[0].Value.ToString(); // drug_id
                        this.frmReceiveProducts.txtDrugs.Text = dgvSearchDrug.CurrentRow.Cells[2].Value.ToString(); // drugName
                        this.frmReceiveProducts.txtPack.Text = dgvSearchDrug.CurrentRow.Cells[6].Value.ToString(); // pack
                        this.frmReceiveProducts.txtPrice.Text = dgvSearchDrug.CurrentRow.Cells[7].Value.ToString(); // price
                        // last stock
                        if (string.IsNullOrEmpty(dgvSearchDrug.CurrentRow.Cells[8].Value.ToString()))
                        {
                            this.frmReceiveProducts.lblLastStock.Text = "0"; // last stock
                        }
                        else
                        {
                            this.frmReceiveProducts.lblLastStock.Text = dgvSearchDrug.CurrentRow.Cells[8].Value.ToString(); // last stock
                        }

                        this.frmReceiveProducts.txtQty.Focus();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("เลือกรายการเวชภัณฑ์ก่อนครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("เลือกรายการเวชภัณฑ์ก่อนครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}