
namespace BackOfficeApplication.Project_HR.UI
{
    partial class FormMainHR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainHR));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsUpdateData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOffDuty = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsRandomCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsReport = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUpdateData,
            this.toolStripSeparator1,
            this.tsOffDuty,
            this.toolStripSeparator3,
            this.tsRandomCheck,
            this.toolStripSeparator2,
            this.tsReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1392, 60);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsUpdateData
            // 
            this.tsUpdateData.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdateData.Image")));
            this.tsUpdateData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsUpdateData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpdateData.Name = "tsUpdateData";
            this.tsUpdateData.Size = new System.Drawing.Size(91, 57);
            this.tsUpdateData.Text = "อัพเดทข้อมูล";
            this.tsUpdateData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsUpdateData.Click += new System.EventHandler(this.tsUpdateData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 60);
            // 
            // tsOffDuty
            // 
            this.tsOffDuty.Image = ((System.Drawing.Image)(resources.GetObject("tsOffDuty.Image")));
            this.tsOffDuty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOffDuty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOffDuty.Name = "tsOffDuty";
            this.tsOffDuty.Size = new System.Drawing.Size(123, 57);
            this.tsOffDuty.Text = "บันทึก/แก้ไขวันลา";
            this.tsOffDuty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsOffDuty.Click += new System.EventHandler(this.tsOffDuty_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 60);
            // 
            // tsRandomCheck
            // 
            this.tsRandomCheck.Image = ((System.Drawing.Image)(resources.GetObject("tsRandomCheck.Image")));
            this.tsRandomCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsRandomCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRandomCheck.Name = "tsRandomCheck";
            this.tsRandomCheck.Size = new System.Drawing.Size(63, 57);
            this.tsRandomCheck.Text = "สุ่มตรวจ";
            this.tsRandomCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsRandomCheck.Click += new System.EventHandler(this.tsRandomCheck_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 60);
            // 
            // tsReport
            // 
            this.tsReport.Image = ((System.Drawing.Image)(resources.GetObject("tsReport.Image")));
            this.tsReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReport.Name = "tsReport";
            this.tsReport.Size = new System.Drawing.Size(59, 57);
            this.tsReport.Text = "รายงาน";
            this.tsReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsReport.Click += new System.EventHandler(this.tsReport_Click);
            // 
            // FormMainHR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 756);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::BackOfficeApplication.Properties.Resources.psswlogo_XbZ_icon;
            this.MaximizeBox = false;
            this.Name = "FormMainHR";
            this.Text = "ระบบจัดการทรัพยากรบุคคล";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsOffDuty;
        private System.Windows.Forms.ToolStripButton tsUpdateData;
        private System.Windows.Forms.ToolStripButton tsRandomCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsReport;
    }
}