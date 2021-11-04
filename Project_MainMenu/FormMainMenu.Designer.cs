
namespace BackOfficeApplication
{
    partial class FormMainMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.btnSmartCardReader = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnDrugManagement = new DevExpress.XtraEditors.SimpleButton();
            this.btnCovid19Vaccine = new DevExpress.XtraEditors.SimpleButton();
            this.btnHumanResource = new DevExpress.XtraEditors.SimpleButton();
            this.btnCentralFolder = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(210, 68);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(658, 503);
            this.webBrowser.TabIndex = 13;
            this.webBrowser.Url = new System.Uri("http://192.168.0.3/himpro", System.UriKind.Absolute);
            // 
            // btnSmartCardReader
            // 
            this.btnSmartCardReader.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmartCardReader.Appearance.Options.UseFont = true;
            this.btnSmartCardReader.Location = new System.Drawing.Point(23, 68);
            this.btnSmartCardReader.Name = "btnSmartCardReader";
            this.btnSmartCardReader.Size = new System.Drawing.Size(168, 55);
            this.btnSmartCardReader.TabIndex = 10;
            this.btnSmartCardReader.Text = "Smart Card";
            this.btnSmartCardReader.Click += new System.EventHandler(this.btnSmartCardReader_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Location = new System.Drawing.Point(388, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(299, 37);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "โรงพยาบาลโพธิ์ศรีสุวรรณ";
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // btnDrugManagement
            // 
            this.btnDrugManagement.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrugManagement.Appearance.Options.UseFont = true;
            this.btnDrugManagement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDrugManagement.ImageOptions.Image")));
            this.btnDrugManagement.Location = new System.Drawing.Point(906, 129);
            this.btnDrugManagement.Name = "btnDrugManagement";
            this.btnDrugManagement.Size = new System.Drawing.Size(168, 55);
            this.btnDrugManagement.TabIndex = 12;
            this.btnDrugManagement.Text = "คลังเวชภัณฑ์";
            this.btnDrugManagement.Click += new System.EventHandler(this.btnDrugManagement_Click);
            // 
            // btnCovid19Vaccine
            // 
            this.btnCovid19Vaccine.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCovid19Vaccine.Appearance.Options.UseFont = true;
            this.btnCovid19Vaccine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCovid19Vaccine.ImageOptions.Image")));
            this.btnCovid19Vaccine.Location = new System.Drawing.Point(906, 68);
            this.btnCovid19Vaccine.Name = "btnCovid19Vaccine";
            this.btnCovid19Vaccine.Size = new System.Drawing.Size(168, 55);
            this.btnCovid19Vaccine.TabIndex = 11;
            this.btnCovid19Vaccine.Text = "Covid-19 Vaccine";
            this.btnCovid19Vaccine.Click += new System.EventHandler(this.btnCovid19Vaccine_Click);
            // 
            // btnHumanResource
            // 
            this.btnHumanResource.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHumanResource.Appearance.Options.UseFont = true;
            this.btnHumanResource.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHumanResource.ImageOptions.Image")));
            this.btnHumanResource.Location = new System.Drawing.Point(23, 190);
            this.btnHumanResource.Name = "btnHumanResource";
            this.btnHumanResource.Size = new System.Drawing.Size(168, 55);
            this.btnHumanResource.TabIndex = 7;
            this.btnHumanResource.Text = "ฝ่ายบุคคล";
            this.btnHumanResource.Click += new System.EventHandler(this.btnHumanResource_Click);
            // 
            // btnCentralFolder
            // 
            this.btnCentralFolder.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentralFolder.Appearance.Options.UseFont = true;
            this.btnCentralFolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCentralFolder.ImageOptions.Image")));
            this.btnCentralFolder.Location = new System.Drawing.Point(23, 129);
            this.btnCentralFolder.Name = "btnCentralFolder";
            this.btnCentralFolder.Size = new System.Drawing.Size(168, 55);
            this.btnCentralFolder.TabIndex = 8;
            this.btnCentralFolder.Text = "โฟลเดอร์ส่วนกลาง";
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 590);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.btnDrugManagement);
            this.Controls.Add(this.btnCovid19Vaccine);
            this.Controls.Add(this.btnSmartCardReader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnHumanResource);
            this.Controls.Add(this.btnCentralFolder);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::BackOfficeApplication.Properties.Resources.psswlogo_XbZ_icon;
            this.MaximizeBox = false;
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back Office Application";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private DevExpress.XtraEditors.SimpleButton btnDrugManagement;
        private DevExpress.XtraEditors.SimpleButton btnCovid19Vaccine;
        private DevExpress.XtraEditors.SimpleButton btnSmartCardReader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnHumanResource;
        private DevExpress.XtraEditors.SimpleButton btnCentralFolder;
    }
}