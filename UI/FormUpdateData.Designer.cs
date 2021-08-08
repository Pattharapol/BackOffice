namespace HumanResource.UI
{
    partial class FormUpdateData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdateData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboTypeOfImportData = new System.Windows.Forms.ComboBox();
            this.lblProgressbar = new DevExpress.XtraEditors.LabelControl();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnUpdateData = new DevExpress.XtraEditors.SimpleButton();
            this.lblCHECKIN = new System.Windows.Forms.Label();
            this.lblDEPT = new System.Windows.Forms.Label();
            this.lblUSERINFO = new System.Windows.Forms.Label();
            this.dgvCHECKIN = new System.Windows.Forms.DataGridView();
            this.dgvDEPT = new System.Windows.Forms.DataGridView();
            this.dgvUSERINFO = new System.Windows.Forms.DataGridView();
            this.btnUploadData = new DevExpress.XtraEditors.SimpleButton();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCHECKIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDEPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSERINFO)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboTypeOfImportData);
            this.groupControl1.Controls.Add(this.lblProgressbar);
            this.groupControl1.Controls.Add(this.ProgressBar);
            this.groupControl1.Controls.Add(this.btnUpdateData);
            this.groupControl1.Controls.Add(this.lblCHECKIN);
            this.groupControl1.Controls.Add(this.lblDEPT);
            this.groupControl1.Controls.Add(this.lblUSERINFO);
            this.groupControl1.Controls.Add(this.dgvCHECKIN);
            this.groupControl1.Controls.Add(this.dgvDEPT);
            this.groupControl1.Controls.Add(this.dgvUSERINFO);
            this.groupControl1.Controls.Add(this.btnUploadData);
            this.groupControl1.Location = new System.Drawing.Point(309, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(935, 703);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "อัปเดทข้อมูล";
            // 
            // cboTypeOfImportData
            // 
            this.cboTypeOfImportData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeOfImportData.FormattingEnabled = true;
            this.cboTypeOfImportData.Items.AddRange(new object[] {
            "--เลือกประเภทการนำเข้าข้อมูล --",
            "ทั้งปีงบประมาณ",
            "เดือนปัจจุบัน"});
            this.cboTypeOfImportData.Location = new System.Drawing.Point(5, 39);
            this.cboTypeOfImportData.Name = "cboTypeOfImportData";
            this.cboTypeOfImportData.Size = new System.Drawing.Size(258, 24);
            this.cboTypeOfImportData.TabIndex = 12;
            // 
            // lblProgressbar
            // 
            this.lblProgressbar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblProgressbar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressbar.Appearance.Options.UseFont = true;
            this.lblProgressbar.Location = new System.Drawing.Point(899, 670);
            this.lblProgressbar.Name = "lblProgressbar";
            this.lblProgressbar.Size = new System.Drawing.Size(25, 19);
            this.lblProgressbar.TabIndex = 11;
            this.lblProgressbar.Text = "0%";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBar.Location = new System.Drawing.Point(5, 668);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(872, 23);
            this.ProgressBar.TabIndex = 10;
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateData.Appearance.Options.UseFont = true;
            this.btnUpdateData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateData.ImageOptions.Image")));
            this.btnUpdateData.Location = new System.Drawing.Point(789, 79);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(141, 47);
            this.btnUpdateData.TabIndex = 9;
            this.btnUpdateData.Text = "อัปเดทข้อมูล";
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // lblCHECKIN
            // 
            this.lblCHECKIN.AutoSize = true;
            this.lblCHECKIN.Location = new System.Drawing.Point(517, 139);
            this.lblCHECKIN.Name = "lblCHECKIN";
            this.lblCHECKIN.Size = new System.Drawing.Size(88, 16);
            this.lblCHECKIN.TabIndex = 8;
            this.lblCHECKIN.Text = "ข้อมูลเจ้าหน้าที่";
            // 
            // lblDEPT
            // 
            this.lblDEPT.AutoSize = true;
            this.lblDEPT.Location = new System.Drawing.Point(266, 139);
            this.lblDEPT.Name = "lblDEPT";
            this.lblDEPT.Size = new System.Drawing.Size(88, 16);
            this.lblDEPT.TabIndex = 7;
            this.lblDEPT.Text = "ข้อมูลเจ้าหน้าที่";
            // 
            // lblUSERINFO
            // 
            this.lblUSERINFO.AutoSize = true;
            this.lblUSERINFO.Location = new System.Drawing.Point(2, 139);
            this.lblUSERINFO.Name = "lblUSERINFO";
            this.lblUSERINFO.Size = new System.Drawing.Size(88, 16);
            this.lblUSERINFO.TabIndex = 6;
            this.lblUSERINFO.Text = "ข้อมูลเจ้าหน้าที่";
            // 
            // dgvCHECKIN
            // 
            this.dgvCHECKIN.AllowUserToAddRows = false;
            this.dgvCHECKIN.AllowUserToDeleteRows = false;
            this.dgvCHECKIN.AllowUserToResizeColumns = false;
            this.dgvCHECKIN.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvCHECKIN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCHECKIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvCHECKIN.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCHECKIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCHECKIN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCHECKIN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCHECKIN.ColumnHeadersHeight = 30;
            this.dgvCHECKIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCHECKIN.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCHECKIN.EnableHeadersVisualStyles = false;
            this.dgvCHECKIN.Location = new System.Drawing.Point(482, 158);
            this.dgvCHECKIN.MultiSelect = false;
            this.dgvCHECKIN.Name = "dgvCHECKIN";
            this.dgvCHECKIN.ReadOnly = true;
            this.dgvCHECKIN.RowHeadersVisible = false;
            this.dgvCHECKIN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCHECKIN.Size = new System.Drawing.Size(448, 494);
            this.dgvCHECKIN.TabIndex = 5;
            // 
            // dgvDEPT
            // 
            this.dgvDEPT.AllowUserToAddRows = false;
            this.dgvDEPT.AllowUserToDeleteRows = false;
            this.dgvDEPT.AllowUserToResizeColumns = false;
            this.dgvDEPT.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvDEPT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDEPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvDEPT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDEPT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDEPT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDEPT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDEPT.ColumnHeadersHeight = 30;
            this.dgvDEPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDEPT.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDEPT.EnableHeadersVisualStyles = false;
            this.dgvDEPT.Location = new System.Drawing.Point(269, 158);
            this.dgvDEPT.MultiSelect = false;
            this.dgvDEPT.Name = "dgvDEPT";
            this.dgvDEPT.ReadOnly = true;
            this.dgvDEPT.RowHeadersVisible = false;
            this.dgvDEPT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDEPT.Size = new System.Drawing.Size(207, 494);
            this.dgvDEPT.TabIndex = 4;
            // 
            // dgvUSERINFO
            // 
            this.dgvUSERINFO.AllowUserToAddRows = false;
            this.dgvUSERINFO.AllowUserToDeleteRows = false;
            this.dgvUSERINFO.AllowUserToResizeColumns = false;
            this.dgvUSERINFO.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvUSERINFO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUSERINFO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvUSERINFO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUSERINFO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUSERINFO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUSERINFO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUSERINFO.ColumnHeadersHeight = 30;
            this.dgvUSERINFO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUSERINFO.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUSERINFO.EnableHeadersVisualStyles = false;
            this.dgvUSERINFO.Location = new System.Drawing.Point(5, 158);
            this.dgvUSERINFO.MultiSelect = false;
            this.dgvUSERINFO.Name = "dgvUSERINFO";
            this.dgvUSERINFO.ReadOnly = true;
            this.dgvUSERINFO.RowHeadersVisible = false;
            this.dgvUSERINFO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUSERINFO.Size = new System.Drawing.Size(258, 494);
            this.dgvUSERINFO.TabIndex = 3;
            // 
            // btnUploadData
            // 
            this.btnUploadData.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadData.Appearance.Options.UseFont = true;
            this.btnUploadData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadData.ImageOptions.Image")));
            this.btnUploadData.Location = new System.Drawing.Point(5, 79);
            this.btnUploadData.Name = "btnUploadData";
            this.btnUploadData.Size = new System.Drawing.Size(157, 47);
            this.btnUploadData.TabIndex = 0;
            this.btnUploadData.Text = "นำเข้าฐานข้อมูล";
            this.btnUploadData.Click += new System.EventHandler(this.btnUploadData_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FormUpdateData
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1492, 738);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormUpdateData";
            this.Text = "อัปเดทข้อมูล";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCHECKIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDEPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSERINFO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnUploadData;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.DataGridView dgvUSERINFO;
        private System.Windows.Forms.DataGridView dgvDEPT;
        private System.Windows.Forms.DataGridView dgvCHECKIN;
        private System.Windows.Forms.Label lblCHECKIN;
        private System.Windows.Forms.Label lblDEPT;
        private System.Windows.Forms.Label lblUSERINFO;
        private DevExpress.XtraEditors.SimpleButton btnUpdateData;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private DevExpress.XtraEditors.LabelControl lblProgressbar;
        private System.Windows.Forms.ComboBox cboTypeOfImportData;
    }
}