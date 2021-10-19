using BackOfficeApplication.DataCenter;
using BarcodeLib;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HumanResource.zProject_Covid19Vaccine.Report;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResource.zProject_Covid19Vaccine
{
    public partial class FormCovid19VaccineMain : DevExpress.XtraEditors.XtraForm
    {
        private DataAccess DataAccess = new DataAccess();

        public FormCovid19VaccineMain()
        {
            InitializeComponent();
        }

        private void textboxAutoComplete(TextBox txt, string sql)
        {
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            DataTable dt = new DataTable();
            dt = DataAccess.RetriveData(sql);
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                data.Add(row[0].ToString());
            }

            txt.AutoCompleteCustomSource = data;
        }

        private void FormCovid19VaccineMain_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new ThreadStart(delegate { textboxAutoComplete(txtLotNo, string.Format(@"SELECT DISTINCT(phosisuwan.moph_ic_vaccine_inv.LotNumber) FROM phosisuwan.moph_ic_vaccine_inv")); }));
            this.BeginInvoke(new ThreadStart(delegate { textboxAutoComplete(txtVaccine, string.Format(@"SELECT DISTINCT(phosisuwan.moph_ic_vaccine_inv.Company) FROM phosisuwan.moph_ic_vaccine_inv")); }));
            this.BeginInvoke(new ThreadStart(delegate { textboxAutoComplete(txtSerial, string.Format(@"SELECT DISTINCT(phosisuwan.moph_ic_vaccine_serial.SerialNumber) FROM phosisuwan.moph_ic_vaccine_serial")); }));
        }

        private void txtHn_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //dsSerialBarcode ds = new dsSerialBarcode();
            //ds.Tables[0].Rows.Add(txtSerial.Text.Trim(), txtVaccine.Text.Trim(), txtLotNo.Text.Trim(), dtpExpire.Value.ToString("dd MMMM yyyy"));
            //rptSerialBarcode rpt = new rptSerialBarcode();
            //rpt.DataSource = ds;
            //rpt.ShowPreview();
        }

        private void txtVaccine_TextChanged(object sender, EventArgs e)
        {
            //lblVaccineError.Visible = false;
            //// only number letter using Regex
            //if (Regex.IsMatch(txtVaccine.Text, @"^[a-zA-Z0-9]+$"))
            //{
            //}
            //else
            //{
            //    lblVaccineError.Visible = true;
            //}
        }

        private void txtLotNo_TextChanged(object sender, EventArgs e)
        {
            // only number letter
            //txtLotNo.Text = string.Concat(txtLotNo.Text.Where(Char.IsLetter));

            lblLotNoError.Visible = false;
            if (Regex.IsMatch(txtLotNo.Text, @"^[a-zA-Z0-9]+$"))
            {
            }
            else
            {
                lblLotNoError.Visible = true;
            }
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            // only number letter
            //txtSerial.Text = string.Concat(txtSerial.Text.Where(Char.IsLetter));
            lblSerialNoError.Visible = false;
            if (Regex.IsMatch(txtSerial.Text, @"^[a-zA-Z0-9]+$"))
            {
            }
            else
            {
                lblSerialNoError.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            // validation special char
            if (lblLotNoError.Visible == true)
            {
                XtraMessageBox.Show("มีอักขระพิเศษปะปนอยู่ กรุณาพิมพ์ใหม่แล้วตรวจสอบอีกครั้งครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (lblVaccineError.Visible == true)
            //{
            //    XtraMessageBox.Show();
            //    return;
            //}
            if (lblSerialNoError.Visible == true)
            {
                XtraMessageBox.Show("มีอักขระพิเศษปะปนอยู่ กรุณาพิมพ์ใหม่แล้วตรวจสอบอีกครั้งครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validation empty char
            if (string.IsNullOrEmpty(txtVaccine.Text))
            {
                ep.SetError(txtVaccine, "กรุณากรอกชื่อวัคซีนด้วยครับ");
                txtVaccine.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLotNo.Text))
            {
                ep.SetError(txtLotNo, "กรุณากรอก Lot Number ด้วยครับ");
                txtLotNo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSerial.Text))
            {
                ep.SetError(txtSerial, "กรุณากรอก Serial Number ด้วยครับ");
                txtSerial.Focus();
                return;
            }

            string sql = string.Format(@"INSERT INTO phosisuwan.moph_ic_vaccine_serial (LotNumber, SerialNumber, Quantity, ExpiredDate) VALUES ('{0}','{1}','{2}','{3}')", txtLotNo.Text.Trim(), txtSerial.Text.Trim(), txtQty.Text.Trim(), Convert.ToDateTime(dtpExpiredDate.EditValue).ToString("yyyy-MM-dd"));
            DataAccess.ExecuteSQL(sql);
            XtraMessageBox.Show("บันทึกเรียบร้อยแล้วครับ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow only number
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}