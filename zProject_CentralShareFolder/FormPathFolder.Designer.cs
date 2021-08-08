namespace HumanResource.zProject_CentralShareFolder
{
    partial class FormPathFolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPathFolder));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnForward = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackward = new DevExpress.XtraEditors.SimpleButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnForward);
            this.panelControl1.Controls.Add(this.btnBackward);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1482, 82);
            this.panelControl1.TabIndex = 3;
            // 
            // btnForward
            // 
            this.btnForward.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.ImageOptions.Image")));
            this.btnForward.Location = new System.Drawing.Point(74, 19);
            this.btnForward.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(57, 55);
            this.btnForward.TabIndex = 1;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBackward.ImageOptions.Image")));
            this.btnBackward.Location = new System.Drawing.Point(8, 19);
            this.btnBackward.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(57, 55);
            this.btnBackward.TabIndex = 0;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 82);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webBrowser.MinimumSize = new System.Drawing.Size(30, 32);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1482, 799);
            this.webBrowser.TabIndex = 4;
            // 
            // FormPathFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 881);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormPathFolder";
            this.Text = "FormPathFolder";
            this.Load += new System.EventHandler(this.FormPathFolder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnForward;
        private DevExpress.XtraEditors.SimpleButton btnBackward;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}