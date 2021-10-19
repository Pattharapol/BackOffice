namespace HumanResource
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
            this.btnCentralFolder = new DevExpress.XtraEditors.SimpleButton();
            this.btnHumanResource = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnSmartCardReader = new DevExpress.XtraEditors.SimpleButton();
            this.btnCovid19Vaccine = new DevExpress.XtraEditors.SimpleButton();
            this.btnDrugManagement = new DevExpress.XtraEditors.SimpleButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnCentralFolder
            // 
            this.btnCentralFolder.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentralFolder.Appearance.Options.UseFont = true;
            this.btnCentralFolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCentralFolder.ImageOptions.Image")));
            this.btnCentralFolder.Location = new System.Drawing.Point(10, 122);
            this.btnCentralFolder.Name = "btnCentralFolder";
            this.btnCentralFolder.Size = new System.Drawing.Size(168, 55);
            this.btnCentralFolder.TabIndex = 0;
            this.btnCentralFolder.Text = "โฟลเดอร์ส่วนกลาง";
            this.btnCentralFolder.Click += new System.EventHandler(this.btnCentralFolder_Click);
            // 
            // btnHumanResource
            // 
            this.btnHumanResource.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHumanResource.Appearance.Options.UseFont = true;
            this.btnHumanResource.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHumanResource.ImageOptions.Image")));
            this.btnHumanResource.Location = new System.Drawing.Point(10, 183);
            this.btnHumanResource.Name = "btnHumanResource";
            this.btnHumanResource.Size = new System.Drawing.Size(168, 55);
            this.btnHumanResource.TabIndex = 0;
            this.btnHumanResource.Text = "ฝ่ายบุคคล";
            this.btnHumanResource.Click += new System.EventHandler(this.btnHumanResource_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Location = new System.Drawing.Point(594, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(299, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "โรงพยาบาลโพธิ์ศรีสุวรรณ";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            this.lblTitle.DoubleClick += new System.EventHandler(this.labelControl1_DoubleClick);
            // 
            // btnSmartCardReader
            // 
            this.btnSmartCardReader.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSmartCardReader.Appearance.Options.UseFont = true;
            this.btnSmartCardReader.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSmartCardReader.ImageOptions.SvgImage")));
            this.btnSmartCardReader.Location = new System.Drawing.Point(10, 61);
            this.btnSmartCardReader.Name = "btnSmartCardReader";
            this.btnSmartCardReader.Size = new System.Drawing.Size(168, 55);
            this.btnSmartCardReader.TabIndex = 3;
            this.btnSmartCardReader.Text = "Smart Card";
            this.btnSmartCardReader.Click += new System.EventHandler(this.btnSmartCardReader_Click);
            // 
            // btnCovid19Vaccine
            // 
            this.btnCovid19Vaccine.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCovid19Vaccine.Appearance.Options.UseFont = true;
            this.btnCovid19Vaccine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCovid19Vaccine.ImageOptions.Image")));
            this.btnCovid19Vaccine.Location = new System.Drawing.Point(10, 244);
            this.btnCovid19Vaccine.Name = "btnCovid19Vaccine";
            this.btnCovid19Vaccine.Size = new System.Drawing.Size(168, 55);
            this.btnCovid19Vaccine.TabIndex = 4;
            this.btnCovid19Vaccine.Text = "Covid-19 Vaccine";
            this.btnCovid19Vaccine.Click += new System.EventHandler(this.btnCovid19Vaccine_Click);
            // 
            // btnDrugManagement
            // 
            this.btnDrugManagement.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrugManagement.Appearance.Options.UseFont = true;
            this.btnDrugManagement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDrugManagement.ImageOptions.Image")));
            this.btnDrugManagement.Location = new System.Drawing.Point(10, 305);
            this.btnDrugManagement.Name = "btnDrugManagement";
            this.btnDrugManagement.Size = new System.Drawing.Size(168, 55);
            this.btnDrugManagement.TabIndex = 5;
            this.btnDrugManagement.Text = "คลังเวชภัณฑ์";
            this.btnDrugManagement.Click += new System.EventHandler(this.btnDrugManagement_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(197, 61);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1281, 741);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.Url = new System.Uri("http://203.157.197.90/webpage", System.UriKind.Absolute);
            // 
            // FormMainMenu
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1490, 814);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.btnDrugManagement);
            this.Controls.Add(this.btnCovid19Vaccine);
            this.Controls.Add(this.btnSmartCardReader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnHumanResource);
            this.Controls.Add(this.btnCentralFolder);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FormMainMenu.IconOptions.Icon")));
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormMainMenu.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1900, 1000);
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back Office Application";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCentralFolder;
        private DevExpress.XtraEditors.SimpleButton btnHumanResource;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnSmartCardReader;
        private DevExpress.XtraEditors.SimpleButton btnCovid19Vaccine;
        private DevExpress.XtraEditors.SimpleButton btnDrugManagement;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}