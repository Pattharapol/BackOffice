
namespace BackOfficeApplication.Project_HR.UI
{
    partial class FormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabServiceWorker = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelServiceWorker = new DevExpress.XtraEditors.PanelControl();
            this.dgvServiceWorkerCheckIn = new System.Windows.Forms.DataGridView();
            this.btnPrintServiceWorker = new DevExpress.XtraEditors.SimpleButton();
            this.btnPDF_ServiceWorker = new DevExpress.XtraEditors.SimpleButton();
            this.btnProcessServiceWorker = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelBackOffice = new DevExpress.XtraEditors.PanelControl();
            this.dgvBackOfficeReport = new System.Windows.Forms.DataGridView();
            this.btnBackOfficePrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackOffice_PDF = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackOfficeProcess = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpBackOffice_END = new System.Windows.Forms.DateTimePicker();
            this.dtpBackOffice_Start = new System.Windows.Forms.DateTimePicker();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.panelSupervisor = new DevExpress.XtraEditors.PanelControl();
            this.dgvSupervisorReport = new System.Windows.Forms.DataGridView();
            this.btnSupervisorPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnSupervisorPDF = new DevExpress.XtraEditors.SimpleButton();
            this.btnSupervisorProcess = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtpSupervisorEND = new System.Windows.Forms.DateTimePicker();
            this.dtpSupervisorStart = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabServiceWorker)).BeginInit();
            this.xtraTabServiceWorker.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelServiceWorker)).BeginInit();
            this.panelServiceWorker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceWorkerCheckIn)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBackOffice)).BeginInit();
            this.panelBackOffice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackOfficeReport)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSupervisor)).BeginInit();
            this.panelSupervisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisorReport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.groupControl1.Controls.Add(this.xtraTabServiceWorker);
            this.groupControl1.Location = new System.Drawing.Point(43, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(886, 618);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "รายงานการเข้า / ออกงาน";
            // 
            // xtraTabServiceWorker
            // 
            this.xtraTabServiceWorker.Location = new System.Drawing.Point(24, 40);
            this.xtraTabServiceWorker.Name = "xtraTabServiceWorker";
            this.xtraTabServiceWorker.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabServiceWorker.Size = new System.Drawing.Size(839, 552);
            this.xtraTabServiceWorker.TabIndex = 1;
            this.xtraTabServiceWorker.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(837, 521);
            this.xtraTabPage1.Text = "สายบริการ";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelServiceWorker);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(837, 521);
            this.panelControl1.TabIndex = 0;
            // 
            // panelServiceWorker
            // 
            this.panelServiceWorker.Controls.Add(this.dgvServiceWorkerCheckIn);
            this.panelServiceWorker.Controls.Add(this.btnPrintServiceWorker);
            this.panelServiceWorker.Controls.Add(this.btnPDF_ServiceWorker);
            this.panelServiceWorker.Controls.Add(this.btnProcessServiceWorker);
            this.panelServiceWorker.Controls.Add(this.labelControl2);
            this.panelServiceWorker.Controls.Add(this.labelControl1);
            this.panelServiceWorker.Controls.Add(this.dtpEndDate);
            this.panelServiceWorker.Controls.Add(this.dtpStartDate);
            this.panelServiceWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServiceWorker.Location = new System.Drawing.Point(2, 2);
            this.panelServiceWorker.Name = "panelServiceWorker";
            this.panelServiceWorker.Size = new System.Drawing.Size(833, 517);
            this.panelServiceWorker.TabIndex = 0;
            // 
            // dgvServiceWorkerCheckIn
            // 
            this.dgvServiceWorkerCheckIn.AllowUserToAddRows = false;
            this.dgvServiceWorkerCheckIn.AllowUserToDeleteRows = false;
            this.dgvServiceWorkerCheckIn.AllowUserToResizeColumns = false;
            this.dgvServiceWorkerCheckIn.AllowUserToResizeRows = false;
            this.dgvServiceWorkerCheckIn.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiceWorkerCheckIn.ColumnHeadersHeight = 35;
            this.dgvServiceWorkerCheckIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvServiceWorkerCheckIn.Location = new System.Drawing.Point(28, 66);
            this.dgvServiceWorkerCheckIn.MultiSelect = false;
            this.dgvServiceWorkerCheckIn.Name = "dgvServiceWorkerCheckIn";
            this.dgvServiceWorkerCheckIn.ReadOnly = true;
            this.dgvServiceWorkerCheckIn.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvServiceWorkerCheckIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceWorkerCheckIn.Size = new System.Drawing.Size(780, 399);
            this.dgvServiceWorkerCheckIn.TabIndex = 42;
            // 
            // btnPrintServiceWorker
            // 
            this.btnPrintServiceWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintServiceWorker.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintServiceWorker.Appearance.Options.UseFont = true;
            this.btnPrintServiceWorker.Enabled = false;
            this.btnPrintServiceWorker.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintServiceWorker.ImageOptions.SvgImage")));
            this.btnPrintServiceWorker.Location = new System.Drawing.Point(297, 471);
            this.btnPrintServiceWorker.Name = "btnPrintServiceWorker";
            this.btnPrintServiceWorker.Size = new System.Drawing.Size(110, 41);
            this.btnPrintServiceWorker.TabIndex = 41;
            this.btnPrintServiceWorker.Text = "&Print";
            this.btnPrintServiceWorker.Click += new System.EventHandler(this.btnPrintServiceWorker_Click);
            // 
            // btnPDF_ServiceWorker
            // 
            this.btnPDF_ServiceWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPDF_ServiceWorker.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF_ServiceWorker.Appearance.Options.UseFont = true;
            this.btnPDF_ServiceWorker.Enabled = false;
            this.btnPDF_ServiceWorker.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF_ServiceWorker.ImageOptions.Image")));
            this.btnPDF_ServiceWorker.Location = new System.Drawing.Point(413, 471);
            this.btnPDF_ServiceWorker.Name = "btnPDF_ServiceWorker";
            this.btnPDF_ServiceWorker.Size = new System.Drawing.Size(145, 41);
            this.btnPDF_ServiceWorker.TabIndex = 40;
            this.btnPDF_ServiceWorker.Text = "ส่งออก PDF";
            this.btnPDF_ServiceWorker.Click += new System.EventHandler(this.btnPDF_ServiceWorker_Click);
            // 
            // btnProcessServiceWorker
            // 
            this.btnProcessServiceWorker.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessServiceWorker.Appearance.Options.UseFont = true;
            this.btnProcessServiceWorker.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessServiceWorker.ImageOptions.Image")));
            this.btnProcessServiceWorker.Location = new System.Drawing.Point(636, 16);
            this.btnProcessServiceWorker.Name = "btnProcessServiceWorker";
            this.btnProcessServiceWorker.Size = new System.Drawing.Size(135, 41);
            this.btnProcessServiceWorker.TabIndex = 39;
            this.btnProcessServiceWorker.Text = "ประมวลผล";
            this.btnProcessServiceWorker.Click += new System.EventHandler(this.btnProcessServiceWorker_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(351, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 19);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "ถึงวันที่";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(69, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 19);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "จากวันที่";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd MMMM yyyy";
            this.dtpEndDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(413, 21);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 29);
            this.dtpEndDate.TabIndex = 36;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd MMMM yyyy";
            this.dtpStartDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(140, 21);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 29);
            this.dtpStartDate.TabIndex = 35;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panelBackOffice);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(837, 521);
            this.xtraTabPage2.Text = "สายสนับสนุน";
            // 
            // panelBackOffice
            // 
            this.panelBackOffice.Controls.Add(this.dgvBackOfficeReport);
            this.panelBackOffice.Controls.Add(this.btnBackOfficePrint);
            this.panelBackOffice.Controls.Add(this.btnBackOffice_PDF);
            this.panelBackOffice.Controls.Add(this.btnBackOfficeProcess);
            this.panelBackOffice.Controls.Add(this.labelControl3);
            this.panelBackOffice.Controls.Add(this.labelControl4);
            this.panelBackOffice.Controls.Add(this.dtpBackOffice_END);
            this.panelBackOffice.Controls.Add(this.dtpBackOffice_Start);
            this.panelBackOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackOffice.Location = new System.Drawing.Point(0, 0);
            this.panelBackOffice.Name = "panelBackOffice";
            this.panelBackOffice.Size = new System.Drawing.Size(837, 521);
            this.panelBackOffice.TabIndex = 1;
            // 
            // dgvBackOfficeReport
            // 
            this.dgvBackOfficeReport.AllowUserToAddRows = false;
            this.dgvBackOfficeReport.AllowUserToDeleteRows = false;
            this.dgvBackOfficeReport.AllowUserToResizeColumns = false;
            this.dgvBackOfficeReport.AllowUserToResizeRows = false;
            this.dgvBackOfficeReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackOfficeReport.ColumnHeadersHeight = 35;
            this.dgvBackOfficeReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBackOfficeReport.Location = new System.Drawing.Point(28, 62);
            this.dgvBackOfficeReport.MultiSelect = false;
            this.dgvBackOfficeReport.Name = "dgvBackOfficeReport";
            this.dgvBackOfficeReport.ReadOnly = true;
            this.dgvBackOfficeReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBackOfficeReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackOfficeReport.Size = new System.Drawing.Size(780, 399);
            this.dgvBackOfficeReport.TabIndex = 50;
            // 
            // btnBackOfficePrint
            // 
            this.btnBackOfficePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackOfficePrint.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackOfficePrint.Appearance.Options.UseFont = true;
            this.btnBackOfficePrint.Enabled = false;
            this.btnBackOfficePrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBackOfficePrint.ImageOptions.SvgImage")));
            this.btnBackOfficePrint.Location = new System.Drawing.Point(297, 467);
            this.btnBackOfficePrint.Name = "btnBackOfficePrint";
            this.btnBackOfficePrint.Size = new System.Drawing.Size(110, 41);
            this.btnBackOfficePrint.TabIndex = 49;
            this.btnBackOfficePrint.Text = "&Print";
            this.btnBackOfficePrint.Click += new System.EventHandler(this.btnBackOfficePrint_Click);
            // 
            // btnBackOffice_PDF
            // 
            this.btnBackOffice_PDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackOffice_PDF.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackOffice_PDF.Appearance.Options.UseFont = true;
            this.btnBackOffice_PDF.Enabled = false;
            this.btnBackOffice_PDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackOffice_PDF.ImageOptions.Image")));
            this.btnBackOffice_PDF.Location = new System.Drawing.Point(413, 467);
            this.btnBackOffice_PDF.Name = "btnBackOffice_PDF";
            this.btnBackOffice_PDF.Size = new System.Drawing.Size(145, 41);
            this.btnBackOffice_PDF.TabIndex = 48;
            this.btnBackOffice_PDF.Text = "ส่งออก PDF";
            this.btnBackOffice_PDF.Click += new System.EventHandler(this.btnBackOffice_PDF_Click);
            // 
            // btnBackOfficeProcess
            // 
            this.btnBackOfficeProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackOfficeProcess.Appearance.Options.UseFont = true;
            this.btnBackOfficeProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackOfficeProcess.ImageOptions.Image")));
            this.btnBackOfficeProcess.Location = new System.Drawing.Point(636, 12);
            this.btnBackOfficeProcess.Name = "btnBackOfficeProcess";
            this.btnBackOfficeProcess.Size = new System.Drawing.Size(135, 41);
            this.btnBackOfficeProcess.TabIndex = 47;
            this.btnBackOfficeProcess.Text = "ประมวลผล";
            this.btnBackOfficeProcess.Click += new System.EventHandler(this.btnBackOfficeProcess_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(351, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 19);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "ถึงวันที่";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(69, 23);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 19);
            this.labelControl4.TabIndex = 46;
            this.labelControl4.Text = "จากวันที่";
            // 
            // dtpBackOffice_END
            // 
            this.dtpBackOffice_END.CustomFormat = "dd MMMM yyyy";
            this.dtpBackOffice_END.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpBackOffice_END.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBackOffice_END.Location = new System.Drawing.Point(413, 17);
            this.dtpBackOffice_END.Name = "dtpBackOffice_END";
            this.dtpBackOffice_END.Size = new System.Drawing.Size(200, 29);
            this.dtpBackOffice_END.TabIndex = 44;
            // 
            // dtpBackOffice_Start
            // 
            this.dtpBackOffice_Start.CustomFormat = "dd MMMM yyyy";
            this.dtpBackOffice_Start.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpBackOffice_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBackOffice_Start.Location = new System.Drawing.Point(140, 17);
            this.dtpBackOffice_Start.Name = "dtpBackOffice_Start";
            this.dtpBackOffice_Start.Size = new System.Drawing.Size(200, 29);
            this.dtpBackOffice_Start.TabIndex = 43;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.panelSupervisor);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(837, 521);
            this.xtraTabPage3.Text = "หัวหน้างาน";
            // 
            // panelSupervisor
            // 
            this.panelSupervisor.Controls.Add(this.dgvSupervisorReport);
            this.panelSupervisor.Controls.Add(this.btnSupervisorPrint);
            this.panelSupervisor.Controls.Add(this.btnSupervisorPDF);
            this.panelSupervisor.Controls.Add(this.btnSupervisorProcess);
            this.panelSupervisor.Controls.Add(this.labelControl5);
            this.panelSupervisor.Controls.Add(this.labelControl6);
            this.panelSupervisor.Controls.Add(this.dtpSupervisorEND);
            this.panelSupervisor.Controls.Add(this.dtpSupervisorStart);
            this.panelSupervisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSupervisor.Location = new System.Drawing.Point(0, 0);
            this.panelSupervisor.Name = "panelSupervisor";
            this.panelSupervisor.Size = new System.Drawing.Size(837, 521);
            this.panelSupervisor.TabIndex = 1;
            // 
            // dgvSupervisorReport
            // 
            this.dgvSupervisorReport.AllowUserToAddRows = false;
            this.dgvSupervisorReport.AllowUserToDeleteRows = false;
            this.dgvSupervisorReport.AllowUserToResizeColumns = false;
            this.dgvSupervisorReport.AllowUserToResizeRows = false;
            this.dgvSupervisorReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvSupervisorReport.ColumnHeadersHeight = 35;
            this.dgvSupervisorReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSupervisorReport.Location = new System.Drawing.Point(28, 62);
            this.dgvSupervisorReport.MultiSelect = false;
            this.dgvSupervisorReport.Name = "dgvSupervisorReport";
            this.dgvSupervisorReport.ReadOnly = true;
            this.dgvSupervisorReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSupervisorReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupervisorReport.Size = new System.Drawing.Size(780, 399);
            this.dgvSupervisorReport.TabIndex = 58;
            // 
            // btnSupervisorPrint
            // 
            this.btnSupervisorPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupervisorPrint.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupervisorPrint.Appearance.Options.UseFont = true;
            this.btnSupervisorPrint.Enabled = false;
            this.btnSupervisorPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnSupervisorPrint.Location = new System.Drawing.Point(297, 467);
            this.btnSupervisorPrint.Name = "btnSupervisorPrint";
            this.btnSupervisorPrint.Size = new System.Drawing.Size(110, 41);
            this.btnSupervisorPrint.TabIndex = 57;
            this.btnSupervisorPrint.Text = "&Print";
            this.btnSupervisorPrint.Click += new System.EventHandler(this.btnSupervisorPrint_Click);
            // 
            // btnSupervisorPDF
            // 
            this.btnSupervisorPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupervisorPDF.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupervisorPDF.Appearance.Options.UseFont = true;
            this.btnSupervisorPDF.Enabled = false;
            this.btnSupervisorPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnSupervisorPDF.Location = new System.Drawing.Point(413, 467);
            this.btnSupervisorPDF.Name = "btnSupervisorPDF";
            this.btnSupervisorPDF.Size = new System.Drawing.Size(145, 41);
            this.btnSupervisorPDF.TabIndex = 56;
            this.btnSupervisorPDF.Text = "ส่งออก PDF";
            this.btnSupervisorPDF.Click += new System.EventHandler(this.btnSupervisorPDF_Click);
            // 
            // btnSupervisorProcess
            // 
            this.btnSupervisorProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupervisorProcess.Appearance.Options.UseFont = true;
            this.btnSupervisorProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.btnSupervisorProcess.Location = new System.Drawing.Point(636, 12);
            this.btnSupervisorProcess.Name = "btnSupervisorProcess";
            this.btnSupervisorProcess.Size = new System.Drawing.Size(135, 41);
            this.btnSupervisorProcess.TabIndex = 55;
            this.btnSupervisorProcess.Text = "ประมวลผล";
            this.btnSupervisorProcess.Click += new System.EventHandler(this.btnSupervisorProcess_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(351, 23);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 19);
            this.labelControl5.TabIndex = 53;
            this.labelControl5.Text = "ถึงวันที่";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(69, 23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 19);
            this.labelControl6.TabIndex = 54;
            this.labelControl6.Text = "จากวันที่";
            // 
            // dtpSupervisorEND
            // 
            this.dtpSupervisorEND.CustomFormat = "dd MMMM yyyy";
            this.dtpSupervisorEND.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpSupervisorEND.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSupervisorEND.Location = new System.Drawing.Point(413, 17);
            this.dtpSupervisorEND.Name = "dtpSupervisorEND";
            this.dtpSupervisorEND.Size = new System.Drawing.Size(200, 29);
            this.dtpSupervisorEND.TabIndex = 52;
            // 
            // dtpSupervisorStart
            // 
            this.dtpSupervisorStart.CustomFormat = "dd MMMM yyyy";
            this.dtpSupervisorStart.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpSupervisorStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSupervisorStart.Location = new System.Drawing.Point(140, 17);
            this.dtpSupervisorStart.Name = "dtpSupervisorStart";
            this.dtpSupervisorStart.Size = new System.Drawing.Size(200, 29);
            this.dtpSupervisorStart.TabIndex = 51;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 642);
            this.Controls.Add(this.groupControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::BackOfficeApplication.Properties.Resources.psswlogo_XbZ_icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายงานการเข้า/ออกงาน";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabServiceWorker)).EndInit();
            this.xtraTabServiceWorker.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelServiceWorker)).EndInit();
            this.panelServiceWorker.ResumeLayout(false);
            this.panelServiceWorker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceWorkerCheckIn)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBackOffice)).EndInit();
            this.panelBackOffice.ResumeLayout(false);
            this.panelBackOffice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackOfficeReport)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSupervisor)).EndInit();
            this.panelSupervisor.ResumeLayout(false);
            this.panelSupervisor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisorReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabServiceWorker;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelServiceWorker;
        private DevExpress.XtraEditors.PanelControl panelBackOffice;
        private DevExpress.XtraEditors.PanelControl panelSupervisor;
        private DevExpress.XtraEditors.SimpleButton btnProcessServiceWorker;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private DevExpress.XtraEditors.SimpleButton btnPrintServiceWorker;
        private DevExpress.XtraEditors.SimpleButton btnPDF_ServiceWorker;
        private System.Windows.Forms.DataGridView dgvServiceWorkerCheckIn;
        private System.Windows.Forms.DataGridView dgvBackOfficeReport;
        private DevExpress.XtraEditors.SimpleButton btnBackOfficePrint;
        private DevExpress.XtraEditors.SimpleButton btnBackOffice_PDF;
        private DevExpress.XtraEditors.SimpleButton btnBackOfficeProcess;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DateTimePicker dtpBackOffice_END;
        private System.Windows.Forms.DateTimePicker dtpBackOffice_Start;
        private System.Windows.Forms.DataGridView dgvSupervisorReport;
        private DevExpress.XtraEditors.SimpleButton btnSupervisorPrint;
        private DevExpress.XtraEditors.SimpleButton btnSupervisorPDF;
        private DevExpress.XtraEditors.SimpleButton btnSupervisorProcess;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.DateTimePicker dtpSupervisorEND;
        private System.Windows.Forms.DateTimePicker dtpSupervisorStart;
    }
}