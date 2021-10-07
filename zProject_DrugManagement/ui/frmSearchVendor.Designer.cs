
namespace HumanResource.zProject_DrugManagement.ui
{
    partial class frmSearchVendor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchVendor));
            this.txtSearchVendor = new DevExpress.XtraEditors.TextEdit();
            this.dgvSearchVendor = new System.Windows.Forms.DataGridView();
            this.btnChooseVendor = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchVendor
            // 
            this.txtSearchVendor.Location = new System.Drawing.Point(11, 11);
            this.txtSearchVendor.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchVendor.Name = "txtSearchVendor";
            this.txtSearchVendor.Size = new System.Drawing.Size(277, 28);
            this.txtSearchVendor.TabIndex = 1;
            this.txtSearchVendor.EditValueChanged += new System.EventHandler(this.txtSearchVendor_EditValueChanged);
            // 
            // dgvSearchVendor
            // 
            this.dgvSearchVendor.AllowUserToAddRows = false;
            this.dgvSearchVendor.AllowUserToDeleteRows = false;
            this.dgvSearchVendor.AllowUserToResizeColumns = false;
            this.dgvSearchVendor.AllowUserToResizeRows = false;
            this.dgvSearchVendor.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearchVendor.ColumnHeadersHeight = 30;
            this.dgvSearchVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSearchVendor.Location = new System.Drawing.Point(11, 44);
            this.dgvSearchVendor.MultiSelect = false;
            this.dgvSearchVendor.Name = "dgvSearchVendor";
            this.dgvSearchVendor.ReadOnly = true;
            this.dgvSearchVendor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchVendor.Size = new System.Drawing.Size(407, 206);
            this.dgvSearchVendor.TabIndex = 2;
            // 
            // btnChooseVendor
            // 
            this.btnChooseVendor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseVendor.ImageOptions.Image")));
            this.btnChooseVendor.Location = new System.Drawing.Point(296, 254);
            this.btnChooseVendor.Name = "btnChooseVendor";
            this.btnChooseVendor.Size = new System.Drawing.Size(122, 48);
            this.btnChooseVendor.TabIndex = 3;
            this.btnChooseVendor.Text = "เลือก";
            this.btnChooseVendor.Click += new System.EventHandler(this.btnChooseVendor_Click);
            // 
            // frmSearchVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 306);
            this.Controls.Add(this.btnChooseVendor);
            this.Controls.Add(this.dgvSearchVendor);
            this.Controls.Add(this.txtSearchVendor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchVendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ค้นหาบริษัท";
            this.Load += new System.EventHandler(this.frmSearchVendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchVendor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSearchVendor;
        private System.Windows.Forms.DataGridView dgvSearchVendor;
        private DevExpress.XtraEditors.SimpleButton btnChooseVendor;
    }
}