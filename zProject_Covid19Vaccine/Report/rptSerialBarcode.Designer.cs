
namespace HumanResource.zProject_Covid19Vaccine.Report
{
    partial class rptSerialBarcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.CodabarGenerator codabarGenerator1 = new DevExpress.XtraPrinting.BarCode.CodabarGenerator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSerial = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.dsSerialBarcode1 = new HumanResource.zProject_Covid19Vaccine.Report.dsSerialBarcode();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dsSerialBarcode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 7F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 7F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel2,
            this.xrSerial,
            this.xrBarCode1});
            this.Detail.HeightF = 193.75F;
            this.Detail.Name = "Detail";
            // 
            // xrSerial
            // 
            this.xrSerial.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[vaccineName]")});
            this.xrSerial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrSerial.LocationFloat = new DevExpress.Utils.PointFloat(122.9167F, 107.5833F);
            this.xrSerial.Multiline = true;
            this.xrSerial.Name = "xrSerial";
            this.xrSerial.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrSerial.SizeF = new System.Drawing.SizeF(180.2083F, 22.99999F);
            this.xrSerial.StylePriority.UseFont = false;
            this.xrSerial.StylePriority.UseTextAlignment = false;
            this.xrSerial.Text = "xrSerial";
            this.xrSerial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[serial]")});
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(77.08334F, 21.125F);
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(200F, 75F);
            codabarGenerator1.WideNarrowRatio = 2F;
            this.xrBarCode1.Symbology = codabarGenerator1;
            // 
            // dsSerialBarcode1
            // 
            this.dsSerialBarcode1.DataSetName = "dsSerialBarcode";
            this.dsSerialBarcode1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(35.41667F, 107.5834F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(87.5F, 22.99999F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Name : ";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[lot]")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(122.9167F, 130.5833F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(180.2083F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrSerial";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(35.41667F, 130.5833F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(87.5F, 23F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Lot no : ";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[expire]")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(122.9167F, 153.5833F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(180.2083F, 22.99998F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrSerial";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel4.TextFormatString = "{0:d MMM yyyy}";
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(35.41667F, 153.5833F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(87.5F, 22.99998F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Expire Date : ";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // rptSerialBarcode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsSerialBarcode1});
            this.DataMember = "DataTable";
            this.DataSource = this.dsSerialBarcode1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 4, 7, 7);
            this.PageWidth = 355;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.RollPaper = true;
            this.ShowPreviewMarginLines = false;
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.Version = "21.1";
            ((System.ComponentModel.ISupportInitialize)(this.dsSerialBarcode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrSerial;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private dsSerialBarcode dsSerialBarcode1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
    }
}
