using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace BackOfficeApplication.Project_HR.Report
{
    public partial class rptCheckIN_OUT : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCheckIN_OUT()
        {
            InitializeComponent();
        }

        private void xrLabel13_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            e.Cancel = e.PageIndex > 0;
        }
    }
}