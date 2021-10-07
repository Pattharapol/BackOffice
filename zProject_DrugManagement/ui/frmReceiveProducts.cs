using BackOfficeApplication.DataCenter;
using DevExpress.XtraEditors;
using HumanResource.DataCenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResource.zProject_DrugManagement.ui
{
    public partial class frmReceiveProducts : DevExpress.XtraEditors.XtraForm
    {
        private string user_id = "";

        public frmReceiveProducts(string user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            //MessageBox.Show(user_id);
        }

        private void frmReceiveProducts_Load(object sender, EventArgs e)
        {
            this.Invoke(new ThreadStart(delegate { FillCombobox(); }));
            this.Invoke(new ThreadStart(delegate { FillDataToDGV(); }));
            this.Invoke(new ThreadStart(delegate { dtReceive.EditValue = DateTime.Now.ToString("dd/MM/yyyy"); }));
        }

        //Cancel
        private void Cancel()
        {
            //dtExpDate.EditValue = DateTime.Now;
            dgvAddproducts.Enabled = true;
            dtReceive.Enabled = true;
            dtApproveDate.Enabled = true;
            dtOrderDate.Enabled = true;
            txtBarcode.Text = "";
            txtDrugs.Text = "";
            txtInvoiceNo.Text = "";
            txtLotno.Text = "";
            txtOrderNo.Text = "";
            txtPack.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtReceiveNo.Enabled = true;
            txtTotalPrice.Text = "";
            txtVendor.Text = "";
            cmbBudgetType.SelectedIndex = 0;
            cmbHowtobuy.SelectedIndex = 0;
            txtReceiveNo.Focus();
            btnNewBill.Visible = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void ClearFormUpdate()
        {
            dtExpDate.EditValue = DateTime.Now;
            dtReceive.Enabled = false;
            dtApproveDate.Enabled = false;
            dtOrderDate.Enabled = false;
            //txtBarcode.Text = "";
            txtDrugs.Text = "";
            //txtInvoiceNo.Text = "";
            txtLotno.Text = "";
            //txtOrderNo.Text = "";
            txtPack.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtReceiveNo.Enabled = false;
            txtTotalPrice.Text = "";
            //txtVendor.Text = "";
            //cmbBudgetType.SelectedIndex = 0;
            //cmbHowtobuy.SelectedIndex = 0;
            txtInvoiceNo.Focus();
            btnNewBill.Visible = true;
            btnUpdate.Enabled = false;
        }

        //ClearForm
        public void ClearForm()
        {
            dtExpDate.EditValue = DateTime.Now;
            dtReceive.Enabled = false;
            dtApproveDate.Enabled = false;
            dtOrderDate.Enabled = false;
            //txtBarcode.Text = "";
            txtDrugs.Text = "";
            //txtInvoiceNo.Text = "";
            txtLotno.Text = "";
            //txtOrderNo.Text = "";
            txtPack.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtReceiveNo.Enabled = false;
            txtTotalPrice.Text = "";
            //txtVendor.Text = "";
            //cmbBudgetType.SelectedIndex = 0;
            //cmbHowtobuy.SelectedIndex = 0;
            txtInvoiceNo.Focus();
            btnNewBill.Visible = true;
            btnUpdate.Enabled = false;
        }

        // Fill data into DGV by DataTable
        public void FillDataToDGV()
        {
            dgvAddproducts.DataSource = null;

            DataTable dt = DataAccess.RetriveData(string.Format(@"SELECT dummy.dummy_id, dummy.user_id, dummy.receiveNo, dummy.invoiceNo, dummy.orderNo, dummy.drug_id, drg.drugName, dummy.vendor_id, dummy.lastStock, dummy.qty, dummy.pack, dummy.price, dummy.totalPrice, dummy.totalStock, dummy.lotNo, dummy.htb_id, dummy.budget_id, dummy.receiveDate, dummy.expDate, dummy.orderDate, dummy.approveDate , vd.vendorName FROM drugmanagement.receivedata_dummy AS dummy LEFT JOIN drugmanagement.drug AS drg ON dummy.drug_id = drg.drug_id LEFT JOIN drugmanagement.vendor AS vd ON dummy.vendor_id = vd.vendor_id WHERE (CoSSK = '0' AND CoSubSSK = '0') ORDER BY dummy.receiveNo ASC"));
            dgvAddproducts.DataSource = dt;
            dgvAddproducts.Columns[0].Visible = false;
            dgvAddproducts.Columns[1].Visible = false;
            dgvAddproducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // reveiveNo
            dgvAddproducts.Columns[3].Visible = false;
            dgvAddproducts.Columns[4].Visible = false;
            dgvAddproducts.Columns[5].Visible = false;
            dgvAddproducts.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // drugName
            dgvAddproducts.Columns[7].Visible = false;
            dgvAddproducts.Columns[8].Visible = false;
            dgvAddproducts.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // qty
            dgvAddproducts.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // pack
            dgvAddproducts.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // price
            dgvAddproducts.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // totalPrice
            dgvAddproducts.Columns[13].Visible = false;
            dgvAddproducts.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // lotNo
            dgvAddproducts.Columns[15].Visible = false;
            dgvAddproducts.Columns[16].Visible = false;
            dgvAddproducts.Columns[17].Visible = false;
            dgvAddproducts.Columns[18].Visible = false;
            dgvAddproducts.Columns[19].Visible = false;
            dgvAddproducts.Columns[20].Visible = false;
            dgvAddproducts.Columns[21].Visible = false;
        }

        private void FillCombobox()
        {
            //// เติมข้อมูลใส่ combobox budgettype บันทึกโดยใช้ combobox.SelectedValue
            DataTable dtBudget = DataAccess.ComboboxHelper(cmbBudgetType, "budgetType", "---เลือกรายการ---", "select budget_id, budgetType from drugmanagement.budget");
            cmbBudgetType.DataSource = dtBudget;
            cmbBudgetType.DisplayMember = "budgetType";
            cmbBudgetType.ValueMember = "budget_id";

            //// เติมข้อมูลใส่ combobox howtobuy บันทึกโดยใช้ combobox.SelectedValue
            DataTable dtHTB = DataAccess.ComboboxHelper(cmbHowtobuy, "htbName", "---เลือกรายการ---", "select htb_id, htbName from drugmanagement.howtobuy");
            cmbHowtobuy.DataSource = dtHTB;
            cmbHowtobuy.DisplayMember = "htbName";
            cmbHowtobuy.ValueMember = "htb_id";
        }

        private void txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            // press enter and show search result in another form
            if (e.KeyCode == Keys.Enter)
            {
                // pass 2 arguement to frmSearchVendor
                frmSearchVendor frm = new frmSearchVendor(txtVendor.Text.Trim(), this);
                frm.ShowDialog();
            }
        }

        private void txtDrugs_KeyDown(object sender, KeyEventArgs e)
        {
            // press enter and show search result in another form
            if (e.KeyCode == Keys.Enter)
            {
                // pass 2 arguement to frmSearchDrug
                frmSearchDrug frm = new frmSearchDrug(txtDrugs.Text.Trim(), this);
                frm.ShowDialog();
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float qty = 0;
                float.TryParse(txtQty.Text.Trim(), out qty);

                float price = 0;
                float.TryParse(txtPrice.Text.Trim(), out price);

                txtTotalPrice.Text = Convert.ToString(qty * price);
            }
            catch
            {
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float qty = 0;
                float.TryParse(txtQty.Text.Trim(), out qty);

                float price = 0;
                float.TryParse(txtPrice.Text.Trim(), out price);

                txtTotalPrice.Text = Convert.ToString(qty * price);
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate data
            ep.Clear();
            if (txtReceiveNo.Text.Trim().Length != 8)
            {
                ep.SetError(txtReceiveNo, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtReceiveNo.SelectAll();
                txtReceiveNo.Focus();
                return;
            }
            if (txtInvoiceNo.Text.Trim().Length == 0)
            {
                ep.SetError(txtInvoiceNo, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtInvoiceNo.SelectAll();
                txtInvoiceNo.Focus();
                return;
            }
            if (cmbBudgetType.Text.Trim().Length == 0)
            {
                ep.SetError(cmbBudgetType, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                cmbBudgetType.SelectAll();
                cmbBudgetType.Focus();
                return;
            }
            if (cmbHowtobuy.Text.Trim().Length == 0)
            {
                ep.SetError(cmbBudgetType, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                cmbBudgetType.SelectAll();
                cmbBudgetType.Focus();
                return;
            }
            if (txtVendor.Text.Trim().Length == 0)
            {
                ep.SetError(txtVendor, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtVendor.SelectAll();
                txtVendor.Focus();
                return;
            }
            if (txtDrugs.Text.Trim().Length == 0)
            {
                ep.SetError(txtDrugs, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtDrugs.SelectAll();
                txtDrugs.Focus();
                return;
            }
            if (txtQty.Text.Trim().Length == 0)
            {
                ep.SetError(txtQty, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtQty.SelectAll();
                txtQty.Focus();
                return;
            }
            if (txtPack.Text.Trim().Length == 0)
            {
                ep.SetError(txtPack, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtPack.SelectAll();
                txtPack.Focus();
                return;
            }
            if (txtPrice.Text.Trim().Length == 0)
            {
                ep.SetError(txtPrice, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtPrice.SelectAll();
                txtPrice.Focus();
                return;
            }

            // find stock remaining
            DataTable dtStock = DataAccess.RetriveData(string.Format(@"select totalRemain from drugmanagement.stockcard where drug_id = '{0}' order by transactionDate desc limit 1", lblDrug_id.Text.Trim()));

            // ถ้าไม่มีข้อมูล แสดงว่า ยังไม่เคยมียาตัวนี้
            string lastStock = "";
            if (dtStock.Rows.Count > 0)
            {
                try { lastStock = dtStock.Rows[0][0].ToString(); } catch { }
            }
            else
            {
                lastStock = "0";
            }

            // เตรียมข้อมูลก่อน insert
            int totalQty = Convert.ToInt32(txtQty.Text.Trim()) * Convert.ToInt32(txtPack.Text.Trim());
            int totalStock = totalQty + Convert.ToInt32(lastStock);

            // รูปแบบ วันเดือนปี ใช้แบบนี้ทั้งหมดนะจ๊ะ
            string recDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");
            string expDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");
            string orderDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");
            string approveDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");

            // insert into receivedata_dummy
            try
            {
                string sql = string.Format(@"insert into drugmanagement.receivedata_dummy (user_id, receiveNo, invoiceNo, orderNo, drug_id, vendor_id, lastStock, qty, pack, price, totalPrice, totalStock, lotNo, htb_id, budget_id, receiveDate, expDate, orderDate, approveDate) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')", user_id, txtReceiveNo.Text.Trim(), txtInvoiceNo.Text.Trim(), txtOrderNo.Text.Trim(), lblDrug_id.Text, lblVendor_ID.Text, lastStock, txtQty.Text.Trim(), txtPack.Text.Trim(), txtPrice.Text.Trim(), txtTotalPrice.Text.Trim(), totalStock, txtLotno.Text.Trim(), cmbHowtobuy.SelectedValue, cmbBudgetType.SelectedValue, recDate, expDate, orderDate, approveDate);

                XtraMessageBox.Show("บันทึกข้อมูลสำเร็จ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // once its success insert clear DGV and fill again and then clear form
                FillDataToDGV();
                ClearForm();
            }
            catch (Exception ex)
            {
                CommonCode.CreateExceptionTextFile(ex.Message, "ReceiveProducts");
            }
        }

        private void dtReceive_TextChanged(object sender, EventArgs e)
        {
            // orderDate and approveDate must less than receiveDate make it automatic
            DateTime date = Convert.ToDateTime(dtReceive.EditValue);
            dtOrderDate.EditValue = date.AddDays(-7);
            dtApproveDate.EditValue = date.AddDays(-8);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            dgvAddproducts.Enabled = true;
            dtReceive.Enabled = true;
            dtApproveDate.Enabled = true;
            dtOrderDate.Enabled = true;
            dtApproveDate.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
            dtExpDate.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
            dtOrderDate.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
            dtReceive.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
            txtReceiveNo.Text = "";
            txtBarcode.Text = "";
            txtDrugs.Text = "";
            txtInvoiceNo.Text = "";
            txtLotno.Text = "";
            txtOrderNo.Text = "";
            txtPack.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtReceiveNo.Enabled = true;
            txtTotalPrice.Text = "";
            txtVendor.Text = "";
            cmbBudgetType.SelectedIndex = 0;
            cmbHowtobuy.SelectedIndex = 0;
            txtReceiveNo.Focus();
            btnNewBill.Visible = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            lblBudgetType.Text = "";
            lblDrug_id.Text = "";
            lblLastStock.Text = "";
        }

        private void mnsEdit_Click(object sender, EventArgs e)
        {
            if (dgvAddproducts != null)
            {
                if (dgvAddproducts.Rows.Count > 0)
                {
                    if (dgvAddproducts.SelectedRows.Count == 1)
                    {
                        // pass value to textbox, label and combobox for update
                        txtReceiveNo.Enabled = false;
                        txtReceiveNo.Text = dgvAddproducts.CurrentRow.Cells[2].Value.ToString();
                        txtInvoiceNo.Text = dgvAddproducts.CurrentRow.Cells[3].Value.ToString();
                        txtOrderNo.Text = dgvAddproducts.CurrentRow.Cells[4].Value.ToString();
                        lblDrug_id.Text = dgvAddproducts.CurrentRow.Cells[5].Value.ToString();
                        txtDrugs.Text = dgvAddproducts.CurrentRow.Cells[6].Value.ToString();
                        lblVendor_ID.Text = dgvAddproducts.CurrentRow.Cells[7].Value.ToString();
                        txtVendor.Text = dgvAddproducts.CurrentRow.Cells[21].Value.ToString();
                        txtQty.Text = dgvAddproducts.CurrentRow.Cells[9].Value.ToString();
                        txtPack.Text = dgvAddproducts.CurrentRow.Cells[10].Value.ToString();
                        txtPrice.Text = dgvAddproducts.CurrentRow.Cells[11].Value.ToString();
                        txtTotalPrice.Text = dgvAddproducts.CurrentRow.Cells[12].Value.ToString();
                        lblLastStock.Text = dgvAddproducts.CurrentRow.Cells[8].Value.ToString();
                        //dtApproveDate.EditValue = Convert.ToDateTime(dgvAddproducts.CurrentRow.Cells[20].Value.ToString()).ToString("dd/MM/yyyy");
                        //dtOrderDate.EditValue = Convert.ToDateTime(dgvAddproducts.CurrentRow.Cells[19].Value.ToString()).ToString("dd/MM/yyyy");
                        dtExpDate.EditValue = Convert.ToDateTime(dgvAddproducts.CurrentRow.Cells[18].Value.ToString()).ToString("dd/MM/yyyy");
                        dtReceive.EditValue = Convert.ToDateTime(dgvAddproducts.CurrentRow.Cells[17].Value.ToString()).ToString("dd/MM/yyyy");
                        cmbBudgetType.SelectedIndex = Convert.ToInt32(dgvAddproducts.CurrentRow.Cells[16].Value.ToString());
                        cmbHowtobuy.SelectedIndex = Convert.ToInt32(dgvAddproducts.CurrentRow.Cells[15].Value.ToString());

                        dgvAddproducts.Enabled = false;

                        btnNewBill.Enabled = false;
                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                    }
                }
            }
        }

        private void mnsDelete_Click(object sender, EventArgs e)
        {
            if (dgvAddproducts != null)
            {
                if (dgvAddproducts.Rows.Count > 0)
                {
                    if (dgvAddproducts.SelectedRows.Count == 1)
                    {
                        if (XtraMessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่", "แจ้งทราบ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            DataAccess.ExecuteSQL(string.Format(@"DELETE FROM drugmanagement.receivedata_dummy WHERE dummy_id = '{0}'", dgvAddproducts.CurrentRow.Cells[0].Value.ToString()));

                            XtraMessageBox.Show("ลบข้อมูลสำเร็จแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDataToDGV();
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // validate data
            ep.Clear();
            if (txtReceiveNo.Text.Trim().Length != 8)
            {
                ep.SetError(txtReceiveNo, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtReceiveNo.SelectAll();
                txtReceiveNo.Focus();
                return;
            }
            if (txtInvoiceNo.Text.Trim().Length == 0)
            {
                ep.SetError(txtInvoiceNo, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtInvoiceNo.SelectAll();
                txtInvoiceNo.Focus();
                return;
            }
            if (cmbBudgetType.Text.Trim().Length == 0)
            {
                ep.SetError(cmbBudgetType, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                cmbBudgetType.SelectAll();
                cmbBudgetType.Focus();
                return;
            }
            if (cmbHowtobuy.Text.Trim().Length == 0)
            {
                ep.SetError(cmbBudgetType, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                cmbBudgetType.SelectAll();
                cmbBudgetType.Focus();
                return;
            }
            if (txtVendor.Text.Trim().Length == 0)
            {
                ep.SetError(txtVendor, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtVendor.SelectAll();
                txtVendor.Focus();
                return;
            }
            if (txtDrugs.Text.Trim().Length == 0)
            {
                ep.SetError(txtDrugs, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtDrugs.SelectAll();
                txtDrugs.Focus();
                return;
            }
            if (txtQty.Text.Trim().Length == 0)
            {
                ep.SetError(txtQty, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtQty.SelectAll();
                txtQty.Focus();
                return;
            }
            if (txtPack.Text.Trim().Length == 0)
            {
                ep.SetError(txtPack, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtPack.SelectAll();
                txtPack.Focus();
                return;
            }
            if (txtPrice.Text.Trim().Length == 0)
            {
                ep.SetError(txtPrice, "กรุณากรอกข้อมูลให้ครบถ้วนด้วยครับ");
                txtPrice.SelectAll();
                txtPrice.Focus();
                return;
            }

            // calculate totalStock
            int totalQty = Convert.ToInt32(txtQty.Text.Trim()) * Convert.ToInt32(txtPack.Text.Trim());
            int totalStock = totalQty + Convert.ToInt32(lblLastStock.Text);

            // รูปแบบ วันเดือนปี ใช้แบบนี้ทั้งหมดนะจ๊ะ
            string recDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");
            string expDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");
            string orderDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");
            string approveDate = (Convert.ToDateTime(dtReceive.EditValue)).ToString("yyyy-MM-dd");

            // update

            string sql = string.Format(@"UPDATE drugmanagement.receivedata_dummy SET receiveNo='{0}', invoiceNo='{1}', orderNo='{2}', drug_id='{3}', vendor_id='{4}', qty='{5}', pack='{6}', price='{7}', totalPrice='{8}', totalStock='{9}', lotNo='{10}', htb_id='{11}', budget_id='{12}', receiveDate='{13}', expDate='{14}', orderDate='{15}', approveDate='{16}' WHERE dummy_id = '{17}' ", txtReceiveNo.Text.Trim(), txtInvoiceNo.Text.Trim(), txtOrderNo.Text.Trim(), lblDrug_id.Text.Trim(), lblVendor_ID.Text.Trim(), txtQty.Text.Trim(), txtPack.Text.Trim(), txtPrice.Text.Trim(), txtTotalPrice.Text.Trim(), totalStock, txtLotno.Text.Trim(), cmbHowtobuy.SelectedValue, cmbBudgetType.SelectedValue, recDate, expDate, orderDate, approveDate, dgvAddproducts.CurrentRow.Cells[0].Value.ToString());
            DataAccess.ExecuteSQL(sql);
            XtraMessageBox.Show("บันทึกการแก้ไขข้อมูลสำเร็จแล้วครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cancel();
            FillDataToDGV();
        }
    }
}