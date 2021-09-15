namespace HumanResource.UI
{
    partial class FormServiceWorkerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiceWorkerReport));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgvServiceWorkerCheckIn = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnProcess = new DevExpress.XtraEditors.SimpleButton();
            this.btnEXCEL = new DevExpress.XtraEditors.SimpleButton();
            this.btnPDF = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceWorkerCheckIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.dgvServiceWorkerCheckIn);
            this.groupControl1.Controls.Add(this.btnProcess);
            this.groupControl1.Controls.Add(this.btnEXCEL);
            this.groupControl1.Controls.Add(this.btnPDF);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dtpEndDate);
            this.groupControl1.Controls.Add(this.dtpStartDate);
            this.groupControl1.Location = new System.Drawing.Point(307, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(765, 714);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "รายงานการมาทำงานสายของเจ้าหน้าที่สายบริการ";
            // 
            // dgvServiceWorkerCheckIn
            // 
            this.dgvServiceWorkerCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvServiceWorkerCheckIn.Location = new System.Drawing.Point(5, 96);
            this.dgvServiceWorkerCheckIn.MainView = this.gridView1;
            this.dgvServiceWorkerCheckIn.Name = "dgvServiceWorkerCheckIn";
            this.dgvServiceWorkerCheckIn.Size = new System.Drawing.Size(755, 555);
            this.dgvServiceWorkerCheckIn.TabIndex = 35;
            this.dgvServiceWorkerCheckIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgvServiceWorkerCheckIn;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Appearance.Options.UseFont = true;
            this.btnProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.ImageOptions.Image")));
            this.btnProcess.Location = new System.Drawing.Point(318, 32);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(135, 41);
            this.btnProcess.TabIndex = 34;
            this.btnProcess.Text = "ประมวลผล";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnEXCEL
            // 
            this.btnEXCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEXCEL.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEXCEL.Appearance.Options.UseFont = true;
            this.btnEXCEL.Enabled = false;
            this.btnEXCEL.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEXCEL.ImageOptions.Image")));
            this.btnEXCEL.Location = new System.Drawing.Point(263, 660);
            this.btnEXCEL.Name = "btnEXCEL";
            this.btnEXCEL.Size = new System.Drawing.Size(145, 41);
            this.btnEXCEL.TabIndex = 33;
            this.btnEXCEL.Text = "ส่งออก EXCEL";
            this.btnEXCEL.Click += new System.EventHandler(this.btnEXCEL_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPDF.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Appearance.Options.UseFont = true;
            this.btnPDF.Enabled = false;
            this.btnPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.ImageOptions.Image")));
            this.btnPDF.Location = new System.Drawing.Point(414, 660);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(145, 41);
            this.btnPDF.TabIndex = 32;
            this.btnPDF.Text = "ส่งออก PDF";
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(35, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "ถึงวันที่";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(26, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "จากวันที่";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd MMMM yyyy";
            this.dtpEndDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(97, 65);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 27);
            this.dtpEndDate.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd MMMM yyyy";
            this.dtpStartDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(97, 32);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 27);
            this.dtpStartDate.TabIndex = 0;
            // 
            // FormServiceWorkerReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1492, 738);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FormServiceWorkerReport.IconOptions.Icon")));
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FormServiceWorkerReport.IconOptions.SvgImage")));
            this.Name = "FormServiceWorkerReport";
            this.Text = "รายงานการมาทำงานสายของเจ้าหน้าที่สายบริการ";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceWorkerCheckIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgvServiceWorkerCheckIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnProcess;
        private DevExpress.XtraEditors.SimpleButton btnEXCEL;
        private DevExpress.XtraEditors.SimpleButton btnPDF;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}