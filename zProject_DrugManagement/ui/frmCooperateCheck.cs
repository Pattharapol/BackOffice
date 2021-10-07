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
    public partial class frmCooperateCheck : DevExpress.XtraEditors.XtraForm
    {
        private string user_id = "";

        public frmCooperateCheck(string user_id)
        {
            InitializeComponent();
        }

        private void frmCooperateCheck_Load(object sender, EventArgs e)
        {
            //FillUncheckData(txtInvoiceNo.Text.Trim());
        }

        // Fill Data into dgvUncheck by DataTable
        private void FillUncheckData(string searchValue)
        {
            dgvUncheck.Rows.Clear();
            string sql = "";
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(searchValue))
            {
                sql = string.Format(@"SELECT dummy.dummy_id, dummy.receiveNo, vd.vendorName, dummy.receiveDate, dummy.totalPrice, bg.budgetType FROM drugmanagement.receivedata_dummy AS dummy LEFT JOIN drugmanagement.vendor AS vd ON dummy.vendor_id = vd.vendor_id LEFT JOIN drugmanagement.budget as bg ON dummy.budget_id = bg.budget_id WHERE (dummy.CoSSK = 0 AND dummy.CoSubSSK = 0) ");
            }
            else
            {
                sql = string.Format(@"SELECT dummy.dummy_id, dummy.receiveNo, vd.vendorName, dummy.receiveDate, dummy.totalPrice, bg.budgetType FROM drugmanagement.receivedata_dummy AS dummy LEFT JOIN drugmanagement.vendor AS vd ON dummy.vendor_id = vd.vendor_id LEFT JOIN drugmanagement.budget as bg ON dummy.budget_id = bg.budget_id WHERE dummy.receiveNo = '{0}' AND (dummy.CoSSK = 0 AND dummy.CoSubSSK = 0) ", searchValue);
            }
            dt = DataAccess.RetriveData(sql);

            // create 8 DGV columns in dgvUncheck before do this coz we have to add 2 buttons to DGV for choose either ซื้อร่วมจังหวัด or ซื้อร่วมเขต
            foreach (DataRow data in dt.Rows)
            {
                dgvUncheck.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), Convert.ToDateTime(data[3].ToString()).ToString("yyyy-MM-dd"), data[4].ToString(), data[5].ToString(), "ซื้อร่วมจังหวัด", "ซื้อร่วมเขต", "ไม่ซื้อร่วม");
            }
        }

        // Fill Data into dgvChecked by DataTable
        private void FillCheckedData()
        {
            // always clear before fill something into
            dgvChecked.Rows.Clear();
            //DatabaseLayer.DataCenter dc = new DatabaseLayer.DataCenter();
            // user async coz we dont need to being block by program when working
            DataTable dt = DataAccess.RetriveData(string.Format(@"SELECT * FROM  drugmanagement.receivedata_dummy WHERE CoSSK = 1 OR CoSubSSK = 1 "));
            if (dt != null)
            {
                // first create columns in dgvChecked
                // fill all of them into dgvChecked but hide what we dont want to show by do it at edit in dgvChecked
                foreach (DataRow row in dt.Rows)
                {
                    dgvChecked.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(), row[15].ToString(), row[16].ToString(), row[17].ToString(), row[18].ToString(), row[19].ToString(), row[20].ToString(), row[21].ToString());
                }

                // calculate totalPrice for list of bills in dgvChecked then pass it into lblCount , lblTotal
                decimal total = 0;
                foreach (DataGridViewRow row in dgvChecked.Rows)
                {
                    total += Convert.ToDecimal(row.Cells[11].Value);
                }
                lblCount.Text = Convert.ToString(dgvChecked.Rows.Count);
                lblTotal.Text = total.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // check digits before search receiveNo must be 8 digits
            if (txtInvoiceNo.Text.Trim().Length < 8)
            {
                ep.SetError(txtInvoiceNo, "เลขรับไม่ถูกต้อง กรุณาตรวจสอบด้วยครับ");
                txtInvoiceNo.SelectAll();
                txtInvoiceNo.Focus();
                return;
            }

            // Fill them into dgvUncheck and lock txtSearch and btnSearch, u can release it by press btnNewReceiveNo_Click
            FillUncheckData(txtInvoiceNo.Text.Trim());
            txtInvoiceNo.Enabled = false;
        }

        private void dgvUncheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // รับค่าจาก Column ที่จะเลือก โดยต้องไปตั้งชื่อ Column ก่อน ถ้าเลือกแล้วชื่อ Column ตรงกัน ก็อัพเดทได้เลย
            string colName = dgvUncheck.Columns[e.ColumnIndex].Name;

            if (colName == "colCO_SSK")
            {
                string sql = string.Format(@"UPDATE drugmanagement.receivedata_dummy SET CoSSK = 1 WHERE dummy_id = '{0}' AND receiveNo = '{1}' AND totalPrice = '{2}'", dgvUncheck.CurrentRow.Cells[0].Value.ToString(), dgvUncheck.CurrentRow.Cells[1].Value.ToString(), dgvUncheck.CurrentRow.Cells[4].Value.ToString());
                DataAccess.ExecuteSQL(sql);
                FillCheckedData();
                FillUncheckData(txtInvoiceNo.Text.Trim());
            }

            if (colName == "colCO_SubSSK")
            {
                string sql = string.Format(@"UPDATE drugmanagement.receivedata_dummy SET CoSubSSK = 1 WHERE dummy_id = '{0}' AND receiveNo = '{1}' AND totalPrice = '{2}'", dgvUncheck.CurrentRow.Cells[0].Value.ToString(), dgvUncheck.CurrentRow.Cells[1].Value.ToString(), dgvUncheck.CurrentRow.Cells[4].Value.ToString());
                FillCheckedData();
                FillUncheckData(txtInvoiceNo.Text.Trim());
            }
        }

        private void btnNewReceiveNo_Click(object sender, EventArgs e)
        {
            // release btn and txt
            btnSearch.Enabled = true;
            txtInvoiceNo.Enabled = true;
            txtInvoiceNo.Text = "";
            txtInvoiceNo.Focus();
            dgvUncheck.Rows.Clear();
        }
    }
}