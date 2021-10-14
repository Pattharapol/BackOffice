using BackOfficeApplication.DataCenter;
using BarcodeLib;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HumanResource.zProject_Covid19Vaccine.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResource.zProject_Covid19Vaccine
{
    public partial class btnConvert : DevExpress.XtraEditors.XtraForm
    {
        public btnConvert()
        {
            InitializeComponent();
        }

        private void FormCovid19VaccineMain_Load(object sender, EventArgs e)
        {
        }

        private void txtHn_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Barcode barcodeAPI = new Barcode();

            //int width = pbCID.Width;
            //int height = pbCID.Height;
            //Color foreColor = Color.Black;
            //Color backColor = Color.White;

            //this.BeginInvoke(new MethodInvoker(delegate
            //{
            //    //if (txtCID.Text != "")
            //    //{
            //    //    Image barcode = barcodeAPI.Encode(TYPE.EAN13, txtCID.Text, foreColor, backColor, (int)(width * 0.8), (int)(height * 0.8));
            //    //    pbCID.Image = barcode;
            //    //}

            //    if (txtSerial.Text != "")
            //    {
            //        Image barcode = barcodeAPI.Encode(TYPE.CODE11, txtSerial.Text, foreColor, backColor, (int)(width * 0.8), (int)(height * 0.8));
            //        pbSerial.Image = barcode;
            //    }
            //}));

            //if (txtFullName.Text != "")
            //{
            //    Image barcode = barcodeAPI.Encode(TYPE.UPCE, txtFullName.Text, foreColor, backColor, (int)(width * 0.8), (int)(height * 0.8));
            //    pbFullName.Image = barcode;
            //}

            //if (txtLotNo.Text != "")
            //{
            //    Image barcode = barcodeAPI.Encode(TYPE.FIM, txtLotNo.Text, foreColor, backColor, (int)(width * 0.8), (int)(height * 0.8));
            //    pbLotNo.Image = barcode;
            //}
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dsSerialBarcode ds = new dsSerialBarcode();
            ds.Tables[0].Rows.Add(txtSerial.Text.Trim(), txtVaccine.Text.Trim(), txtLotNo.Text.Trim(), dtpExpire.Value.ToString("dd MMMM yyyy"));
            rptSerialBarcode rpt = new rptSerialBarcode();
            rpt.DataSource = ds;
            rpt.ShowPreview();
        }
    }
}