
namespace HumanResource.zProject_Covid19Vaccine
{
    partial class btnConvert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnConvert));
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVaccine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpExpire = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Serial : ";
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(187, 172);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(212, 29);
            this.txtSerial.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(287, 253);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 41);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(187, 137);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(212, 29);
            this.txtLotNo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Lot No : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Vaccine Name : ";
            // 
            // txtVaccine
            // 
            this.txtVaccine.Location = new System.Drawing.Point(187, 103);
            this.txtVaccine.Name = "txtVaccine";
            this.txtVaccine.Size = new System.Drawing.Size(212, 29);
            this.txtVaccine.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Expire Date : ";
            // 
            // dtpExpire
            // 
            this.dtpExpire.Location = new System.Drawing.Point(187, 207);
            this.dtpExpire.Name = "dtpExpire";
            this.dtpExpire.Size = new System.Drawing.Size(212, 29);
            this.dtpExpire.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 580);
            this.Controls.Add(this.dtpExpire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVaccine);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLotNo);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConvert.IconOptions.SvgImage")));
            this.Name = "btnConvert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Covid- 19 Vaccine Information";
            this.Load += new System.EventHandler(this.FormCovid19VaccineMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerial;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVaccine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpExpire;
    }
}