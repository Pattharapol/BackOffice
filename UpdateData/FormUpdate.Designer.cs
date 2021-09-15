namespace UpdateData
{
    partial class FormUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.cboTypeOfImportData = new System.Windows.Forms.ComboBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblCHECKIN = new System.Windows.Forms.Label();
            this.lblDEPT = new System.Windows.Forms.Label();
            this.lblUSERINFO = new System.Windows.Forms.Label();
            this.dgvCHECKIN = new System.Windows.Forms.DataGridView();
            this.dgvDEPT = new System.Windows.Forms.DataGridView();
            this.dgvUSERINFO = new System.Windows.Forms.DataGridView();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCHECKIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDEPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSERINFO)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.cboTypeOfImportData);
            this.groupBox1.Controls.Add(this.ProgressBar);
            this.groupBox1.Controls.Add(this.lblCHECKIN);
            this.groupBox1.Controls.Add(this.lblDEPT);
            this.groupBox1.Controls.Add(this.lblUSERINFO);
            this.groupBox1.Controls.Add(this.dgvCHECKIN);
            this.groupBox1.Controls.Add(this.dgvDEPT);
            this.groupBox1.Controls.Add(this.dgvUSERINFO);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 587);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(801, 46);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 48);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "อัปเดทข้อมูล";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(17, 46);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(141, 48);
            this.btnUpload.TabIndex = 21;
            this.btnUpload.Text = "เลือกไฟล์";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cboTypeOfImportData
            // 
            this.cboTypeOfImportData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeOfImportData.FormattingEnabled = true;
            this.cboTypeOfImportData.Items.AddRange(new object[] {
            "--เลือกประเภทการนำเข้าข้อมูล --",
            "ทั้งปีงบประมาณ",
            "เดือนปัจจุบัน"});
            this.cboTypeOfImportData.Location = new System.Drawing.Point(17, 19);
            this.cboTypeOfImportData.Name = "cboTypeOfImportData";
            this.cboTypeOfImportData.Size = new System.Drawing.Size(258, 21);
            this.cboTypeOfImportData.TabIndex = 20;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ProgressBar.Location = new System.Drawing.Point(17, 553);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(872, 23);
            this.ProgressBar.TabIndex = 19;
            // 
            // lblCHECKIN
            // 
            this.lblCHECKIN.AutoSize = true;
            this.lblCHECKIN.Location = new System.Drawing.Point(529, 97);
            this.lblCHECKIN.Name = "lblCHECKIN";
            this.lblCHECKIN.Size = new System.Drawing.Size(75, 13);
            this.lblCHECKIN.TabIndex = 18;
            this.lblCHECKIN.Text = "ข้อมูลเจ้าหน้าที่";
            // 
            // lblDEPT
            // 
            this.lblDEPT.AutoSize = true;
            this.lblDEPT.Location = new System.Drawing.Point(278, 97);
            this.lblDEPT.Name = "lblDEPT";
            this.lblDEPT.Size = new System.Drawing.Size(75, 13);
            this.lblDEPT.TabIndex = 17;
            this.lblDEPT.Text = "ข้อมูลเจ้าหน้าที่";
            // 
            // lblUSERINFO
            // 
            this.lblUSERINFO.AutoSize = true;
            this.lblUSERINFO.Location = new System.Drawing.Point(14, 97);
            this.lblUSERINFO.Name = "lblUSERINFO";
            this.lblUSERINFO.Size = new System.Drawing.Size(75, 13);
            this.lblUSERINFO.TabIndex = 16;
            this.lblUSERINFO.Text = "ข้อมูลเจ้าหน้าที่";
            // 
            // dgvCHECKIN
            // 
            this.dgvCHECKIN.AllowUserToAddRows = false;
            this.dgvCHECKIN.AllowUserToDeleteRows = false;
            this.dgvCHECKIN.AllowUserToResizeColumns = false;
            this.dgvCHECKIN.AllowUserToResizeRows = false;
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvCHECKIN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
            this.dgvCHECKIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvCHECKIN.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCHECKIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCHECKIN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCHECKIN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvCHECKIN.ColumnHeadersHeight = 30;
            this.dgvCHECKIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCHECKIN.DefaultCellStyle = dataGridViewCellStyle48;
            this.dgvCHECKIN.EnableHeadersVisualStyles = false;
            this.dgvCHECKIN.Location = new System.Drawing.Point(494, 116);
            this.dgvCHECKIN.MultiSelect = false;
            this.dgvCHECKIN.Name = "dgvCHECKIN";
            this.dgvCHECKIN.ReadOnly = true;
            this.dgvCHECKIN.RowHeadersVisible = false;
            this.dgvCHECKIN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCHECKIN.Size = new System.Drawing.Size(448, 421);
            this.dgvCHECKIN.TabIndex = 15;
            // 
            // dgvDEPT
            // 
            this.dgvDEPT.AllowUserToAddRows = false;
            this.dgvDEPT.AllowUserToDeleteRows = false;
            this.dgvDEPT.AllowUserToResizeColumns = false;
            this.dgvDEPT.AllowUserToResizeRows = false;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvDEPT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle49;
            this.dgvDEPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvDEPT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDEPT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDEPT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDEPT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle50;
            this.dgvDEPT.ColumnHeadersHeight = 30;
            this.dgvDEPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDEPT.DefaultCellStyle = dataGridViewCellStyle51;
            this.dgvDEPT.EnableHeadersVisualStyles = false;
            this.dgvDEPT.Location = new System.Drawing.Point(281, 116);
            this.dgvDEPT.MultiSelect = false;
            this.dgvDEPT.Name = "dgvDEPT";
            this.dgvDEPT.ReadOnly = true;
            this.dgvDEPT.RowHeadersVisible = false;
            this.dgvDEPT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDEPT.Size = new System.Drawing.Size(207, 421);
            this.dgvDEPT.TabIndex = 14;
            // 
            // dgvUSERINFO
            // 
            this.dgvUSERINFO.AllowUserToAddRows = false;
            this.dgvUSERINFO.AllowUserToDeleteRows = false;
            this.dgvUSERINFO.AllowUserToResizeColumns = false;
            this.dgvUSERINFO.AllowUserToResizeRows = false;
            dataGridViewCellStyle52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvUSERINFO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle52;
            this.dgvUSERINFO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvUSERINFO.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvUSERINFO.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUSERINFO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUSERINFO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle53;
            this.dgvUSERINFO.ColumnHeadersHeight = 30;
            this.dgvUSERINFO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUSERINFO.DefaultCellStyle = dataGridViewCellStyle54;
            this.dgvUSERINFO.EnableHeadersVisualStyles = false;
            this.dgvUSERINFO.Location = new System.Drawing.Point(17, 116);
            this.dgvUSERINFO.MultiSelect = false;
            this.dgvUSERINFO.Name = "dgvUSERINFO";
            this.dgvUSERINFO.ReadOnly = true;
            this.dgvUSERINFO.RowHeadersVisible = false;
            this.dgvUSERINFO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUSERINFO.Size = new System.Drawing.Size(258, 421);
            this.dgvUSERINFO.TabIndex = 13;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 611);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCHECKIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDEPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSERINFO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTypeOfImportData;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label lblCHECKIN;
        private System.Windows.Forms.Label lblDEPT;
        private System.Windows.Forms.Label lblUSERINFO;
        private System.Windows.Forms.DataGridView dgvCHECKIN;
        private System.Windows.Forms.DataGridView dgvDEPT;
        private System.Windows.Forms.DataGridView dgvUSERINFO;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

