
namespace BackOfficeApplication.Project_DrugInventoryManagement.UI
{
    partial class FormDrugMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.จดการเวชภณฑToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ตงคาToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.รายงานToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnReceiveProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnSellProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.จดการเวชภณฑToolStripMenuItem,
            this.รายงานToolStripMenuItem,
            this.ตงคาToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(966, 29);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // จดการเวชภณฑToolStripMenuItem
            // 
            this.จดการเวชภณฑToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnReceiveProducts,
            this.tsmnSellProducts});
            this.จดการเวชภณฑToolStripMenuItem.Name = "จดการเวชภณฑToolStripMenuItem";
            this.จดการเวชภณฑToolStripMenuItem.Size = new System.Drawing.Size(118, 25);
            this.จดการเวชภณฑToolStripMenuItem.Text = "จัดการเวชภัณฑ์";
            // 
            // ตงคาToolStripMenuItem
            // 
            this.ตงคาToolStripMenuItem.Name = "ตงคาToolStripMenuItem";
            this.ตงคาToolStripMenuItem.Size = new System.Drawing.Size(53, 25);
            this.ตงคาToolStripMenuItem.Text = "ตั้งค่า";
            // 
            // รายงานToolStripMenuItem
            // 
            this.รายงานToolStripMenuItem.Name = "รายงานToolStripMenuItem";
            this.รายงานToolStripMenuItem.Size = new System.Drawing.Size(67, 25);
            this.รายงานToolStripMenuItem.Text = "รายงาน";
            // 
            // tsmnReceiveProducts
            // 
            this.tsmnReceiveProducts.Name = "tsmnReceiveProducts";
            this.tsmnReceiveProducts.Size = new System.Drawing.Size(184, 26);
            this.tsmnReceiveProducts.Text = "รับเข้าเวชภัณฑ์";
            this.tsmnReceiveProducts.Click += new System.EventHandler(this.tsmnReceiveProducts_Click);
            // 
            // tsmnSellProducts
            // 
            this.tsmnSellProducts.Name = "tsmnSellProducts";
            this.tsmnSellProducts.Size = new System.Drawing.Size(184, 26);
            this.tsmnSellProducts.Text = "จ่ายออกเวชภัณฑ์";
            // 
            // FormDrugMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 590);
            this.Controls.Add(this.menuStrip);
            this.IconOptions.Image = global::BackOfficeApplication.Properties.Resources.psswlogo_XbZ_icon;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormDrugMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ระบบบริหารคลังเวชภัณฑ์";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem จดการเวชภณฑToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ตงคาToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem รายงานToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmnReceiveProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmnSellProducts;
    }
}