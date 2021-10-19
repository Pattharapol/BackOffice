﻿
namespace HumanResource.zProject_ThaiNationalIDCard.UI
{
    partial class frmVaccineTransferData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVaccineTransferData));
            this.dgvNewPT = new System.Windows.Forms.DataGridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDoWork = new DevExpress.XtraEditors.SimpleButton();
            this.lblOPD_OPD = new System.Windows.Forms.Label();
            this.lblNewPT = new System.Windows.Forms.Label();
            this.pbOPD_OPD = new System.Windows.Forms.ProgressBar();
            this.dgvOPD_OPD = new System.Windows.Forms.DataGridView();
            this.pbNewPT = new System.Windows.Forms.ProgressBar();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpVaccineDate = new System.Windows.Forms.DateTimePicker();
            this.bgwNewPT = new System.ComponentModel.BackgroundWorker();
            this.bgwOPD = new System.ComponentModel.BackgroundWorker();
            this.btnTestMovePictures = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPD_OPD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNewPT
            // 
            this.dgvNewPT.AllowUserToAddRows = false;
            this.dgvNewPT.AllowUserToDeleteRows = false;
            this.dgvNewPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewPT.Location = new System.Drawing.Point(24, 88);
            this.dgvNewPT.Name = "dgvNewPT";
            this.dgvNewPT.ReadOnly = true;
            this.dgvNewPT.Size = new System.Drawing.Size(257, 455);
            this.dgvNewPT.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "วันที่ฉีด";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnTestMovePictures);
            this.groupControl1.Controls.Add(this.btnDoWork);
            this.groupControl1.Controls.Add(this.lblOPD_OPD);
            this.groupControl1.Controls.Add(this.lblNewPT);
            this.groupControl1.Controls.Add(this.pbOPD_OPD);
            this.groupControl1.Controls.Add(this.dgvOPD_OPD);
            this.groupControl1.Controls.Add(this.dgvNewPT);
            this.groupControl1.Controls.Add(this.pbNewPT);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.dtpVaccineDate);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(14, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(971, 613);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "โอนถ่ายข้อมูลการฉีดวัคซีนนอกสถานที่";
            // 
            // btnDoWork
            // 
            this.btnDoWork.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDoWork.ImageOptions.SvgImage")));
            this.btnDoWork.Location = new System.Drawing.Point(838, 33);
            this.btnDoWork.Name = "btnDoWork";
            this.btnDoWork.Size = new System.Drawing.Size(128, 39);
            this.btnDoWork.TabIndex = 12;
            this.btnDoWork.Text = "ถ่ายข้อมูล";
            this.btnDoWork.Click += new System.EventHandler(this.btnDoWork_Click);
            // 
            // lblOPD_OPD
            // 
            this.lblOPD_OPD.AutoSize = true;
            this.lblOPD_OPD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOPD_OPD.Location = new System.Drawing.Point(615, 553);
            this.lblOPD_OPD.Name = "lblOPD_OPD";
            this.lblOPD_OPD.Size = new System.Drawing.Size(38, 15);
            this.lblOPD_OPD.TabIndex = 8;
            this.lblOPD_OPD.Text = "label2";
            // 
            // lblNewPT
            // 
            this.lblNewPT.AutoSize = true;
            this.lblNewPT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPT.Location = new System.Drawing.Point(135, 553);
            this.lblNewPT.Name = "lblNewPT";
            this.lblNewPT.Size = new System.Drawing.Size(38, 15);
            this.lblNewPT.TabIndex = 7;
            this.lblNewPT.Text = "label1";
            // 
            // pbOPD_OPD
            // 
            this.pbOPD_OPD.Location = new System.Drawing.Point(287, 549);
            this.pbOPD_OPD.Name = "pbOPD_OPD";
            this.pbOPD_OPD.Size = new System.Drawing.Size(679, 23);
            this.pbOPD_OPD.TabIndex = 6;
            // 
            // dgvOPD_OPD
            // 
            this.dgvOPD_OPD.AllowUserToAddRows = false;
            this.dgvOPD_OPD.AllowUserToDeleteRows = false;
            this.dgvOPD_OPD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOPD_OPD.Location = new System.Drawing.Point(287, 88);
            this.dgvOPD_OPD.Name = "dgvOPD_OPD";
            this.dgvOPD_OPD.ReadOnly = true;
            this.dgvOPD_OPD.Size = new System.Drawing.Size(679, 455);
            this.dgvOPD_OPD.TabIndex = 5;
            // 
            // pbNewPT
            // 
            this.pbNewPT.Location = new System.Drawing.Point(24, 549);
            this.pbNewPT.Name = "pbNewPT";
            this.pbNewPT.Size = new System.Drawing.Size(257, 23);
            this.pbNewPT.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.Location = new System.Drawing.Point(287, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpVaccineDate
            // 
            this.dtpVaccineDate.CustomFormat = "dd MMMM yyyy";
            this.dtpVaccineDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVaccineDate.Location = new System.Drawing.Point(77, 40);
            this.dtpVaccineDate.Name = "dtpVaccineDate";
            this.dtpVaccineDate.Size = new System.Drawing.Size(204, 29);
            this.dtpVaccineDate.TabIndex = 1;
            // 
            // bgwNewPT
            // 
            this.bgwNewPT.WorkerReportsProgress = true;
            this.bgwNewPT.WorkerSupportsCancellation = true;
            this.bgwNewPT.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwNewPT_DoWork);
            this.bgwNewPT.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwNewPT_ProgressChanged);
            this.bgwNewPT.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwNewPT_RunWorkerCompleted);
            // 
            // bgwOPD
            // 
            this.bgwOPD.WorkerReportsProgress = true;
            this.bgwOPD.WorkerSupportsCancellation = true;
            this.bgwOPD.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwOPD_DoWork);
            this.bgwOPD.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwOPD_ProgressChanged);
            this.bgwOPD.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwOPD_RunWorkerCompleted);
            // 
            // btnTestMovePictures
            // 
            this.btnTestMovePictures.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnTestMovePictures.Location = new System.Drawing.Point(704, 33);
            this.btnTestMovePictures.Name = "btnTestMovePictures";
            this.btnTestMovePictures.Size = new System.Drawing.Size(128, 39);
            this.btnTestMovePictures.TabIndex = 13;
            this.btnTestMovePictures.Text = "ทดสอบย้ายรูป";
            this.btnTestMovePictures.Click += new System.EventHandler(this.btnTestMovePictures_Click);
            // 
            // frmVaccineTransferData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 648);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmVaccineTransferData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "โอนถ่ายข้อมูล";
            this.Load += new System.EventHandler(this.frmVaccineTransferData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewPT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPD_OPD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNewPT;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDoWork;
        private System.Windows.Forms.Label lblOPD_OPD;
        private System.Windows.Forms.Label lblNewPT;
        private System.Windows.Forms.ProgressBar pbOPD_OPD;
        private System.Windows.Forms.DataGridView dgvOPD_OPD;
        private System.Windows.Forms.ProgressBar pbNewPT;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DateTimePicker dtpVaccineDate;
        private System.ComponentModel.BackgroundWorker bgwNewPT;
        private System.ComponentModel.BackgroundWorker bgwOPD;
        private DevExpress.XtraEditors.SimpleButton btnTestMovePictures;
    }
}