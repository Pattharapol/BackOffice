
namespace HumanResource.zProject_DrugManagement.ui
{
    partial class frmSearchDrug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchDrug));
            this.txtSearchDrug = new DevExpress.XtraEditors.TextEdit();
            this.dgvSearchDrug = new System.Windows.Forms.DataGridView();
            this.btnChooseDrug = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchDrug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchDrug)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchDrug
            // 
            this.txtSearchDrug.Location = new System.Drawing.Point(11, 11);
            this.txtSearchDrug.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchDrug.Name = "txtSearchDrug";
            this.txtSearchDrug.Size = new System.Drawing.Size(277, 28);
            this.txtSearchDrug.TabIndex = 5;
            this.txtSearchDrug.EditValueChanged += new System.EventHandler(this.txtSearchDrug_EditValueChanged);
            // 
            // dgvSearchDrug
            // 
            this.dgvSearchDrug.AllowUserToAddRows = false;
            this.dgvSearchDrug.AllowUserToDeleteRows = false;
            this.dgvSearchDrug.AllowUserToResizeColumns = false;
            this.dgvSearchDrug.AllowUserToResizeRows = false;
            this.dgvSearchDrug.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearchDrug.ColumnHeadersHeight = 30;
            this.dgvSearchDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSearchDrug.Location = new System.Drawing.Point(11, 44);
            this.dgvSearchDrug.MultiSelect = false;
            this.dgvSearchDrug.Name = "dgvSearchDrug";
            this.dgvSearchDrug.ReadOnly = true;
            this.dgvSearchDrug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchDrug.Size = new System.Drawing.Size(407, 184);
            this.dgvSearchDrug.TabIndex = 6;
            // 
            // btnChooseDrug
            // 
            this.btnChooseDrug.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseDrug.ImageOptions.Image")));
            this.btnChooseDrug.Location = new System.Drawing.Point(319, 234);
            this.btnChooseDrug.Name = "btnChooseDrug";
            this.btnChooseDrug.Size = new System.Drawing.Size(99, 36);
            this.btnChooseDrug.TabIndex = 7;
            this.btnChooseDrug.Text = "เลือก";
            this.btnChooseDrug.Click += new System.EventHandler(this.btnChooseDrug_Click);
            // 
            // frmSearchDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 276);
            this.Controls.Add(this.btnChooseDrug);
            this.Controls.Add(this.dgvSearchDrug);
            this.Controls.Add(this.txtSearchDrug);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchDrug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ค้นหาเวชภัณฑ์";
            this.Load += new System.EventHandler(this.frmSearchDrug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchDrug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchDrug)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSearchDrug;
        private System.Windows.Forms.DataGridView dgvSearchDrug;
        private DevExpress.XtraEditors.SimpleButton btnChooseDrug;
    }
}