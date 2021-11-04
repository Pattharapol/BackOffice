﻿
namespace BackOfficeApplication.Project_SmartCard.UI
{
    partial class FormSmartCard
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
            this.components = new System.ComponentModel.Container();
            this.label23 = new System.Windows.Forms.Label();
            this.btnTransferData = new DevExpress.XtraEditors.SimpleButton();
            this.label20 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnUpdateHN = new DevExpress.XtraEditors.SimpleButton();
            this.txtCID2 = new System.Windows.Forms.TextBox();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.btnPrintMoreSticker = new System.Windows.Forms.Button();
            this.btnFindByCID_HN = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.btnTestPrint = new System.Windows.Forms.Button();
            this.txtPrintNumber = new System.Windows.Forms.ComboBox();
            this.lblOfficerUsername = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pbPictureFromDatabase = new System.Windows.Forms.PictureBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbLibVersion = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_issue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRefreshReaderList = new System.Windows.Forms.Button();
            this.chkBoxMonitor = new System.Windows.Forms.CheckBox();
            this.cbxReaderList = new System.Windows.Forms.ComboBox();
            this.btnReadWithPhoto = new System.Windows.Forms.Button();
            this.PhotoProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.pbPictureFromIDCard = new System.Windows.Forms.PictureBox();
            this.lbl_expire = new System.Windows.Forms.Label();
            this.lbl_sex = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_birthday = new System.Windows.Forms.Label();
            this.lbl_en_lastname = new System.Windows.Forms.Label();
            this.lbl_en_firstname = new System.Windows.Forms.Label();
            this.lbl_en_prefix = new System.Windows.Forms.Label();
            this.lbl_th_lastname = new System.Windows.Forms.Label();
            this.lbl_th_firstname = new System.Windows.Forms.Label();
            this.lbl_th_prefix = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureFromDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureFromIDCard)).BeginInit();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(20, 445);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(163, 13);
            this.label23.TabIndex = 203;
            this.label23.Text = "**ใช้ในกรณีขึ้นบัตรใหม่แล้ว Error";
            // 
            // btnTransferData
            // 
            this.btnTransferData.Location = new System.Drawing.Point(23, 316);
            this.btnTransferData.Name = "btnTransferData";
            this.btnTransferData.Size = new System.Drawing.Size(158, 49);
            this.btnTransferData.TabIndex = 201;
            this.btnTransferData.Text = "โอนข้อมูลฉีดวัคซีน";
            this.btnTransferData.Click += new System.EventHandler(this.btnTransferData_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(17, 369);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 13);
            this.label20.TabIndex = 200;
            this.label20.Text = "**ใช้ในกรณีไปฉีดวัคซีนนอกสถานที่";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnUpdateHN
            // 
            this.btnUpdateHN.Location = new System.Drawing.Point(23, 389);
            this.btnUpdateHN.Name = "btnUpdateHN";
            this.btnUpdateHN.Size = new System.Drawing.Size(158, 49);
            this.btnUpdateHN.TabIndex = 202;
            this.btnUpdateHN.Text = "อัปเดท HN";
            // 
            // txtCID2
            // 
            this.txtCID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtCID2.Location = new System.Drawing.Point(800, 77);
            this.txtCID2.Name = "txtCID2";
            this.txtCID2.Size = new System.Drawing.Size(169, 29);
            this.txtCID2.TabIndex = 199;
            this.txtCID2.Visible = false;
            this.txtCID2.WordWrap = false;
            // 
            // txtCID
            // 
            this.txtCID.Enabled = false;
            this.txtCID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCID.Location = new System.Drawing.Point(77, 469);
            this.txtCID.Name = "txtCID";
            this.txtCID.Size = new System.Drawing.Size(169, 29);
            this.txtCID.TabIndex = 198;
            this.txtCID.Visible = false;
            this.txtCID.WordWrap = false;
            // 
            // btnPrintMoreSticker
            // 
            this.btnPrintMoreSticker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrintMoreSticker.Location = new System.Drawing.Point(625, 122);
            this.btnPrintMoreSticker.Name = "btnPrintMoreSticker";
            this.btnPrintMoreSticker.Size = new System.Drawing.Size(169, 40);
            this.btnPrintMoreSticker.TabIndex = 197;
            this.btnPrintMoreSticker.Text = "พิมพ์สติกเกอร์เพิ่ม";
            this.btnPrintMoreSticker.UseVisualStyleBackColor = true;
            // 
            // btnFindByCID_HN
            // 
            this.btnFindByCID_HN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnFindByCID_HN.Location = new System.Drawing.Point(625, 74);
            this.btnFindByCID_HN.Name = "btnFindByCID_HN";
            this.btnFindByCID_HN.Size = new System.Drawing.Size(169, 40);
            this.btnFindByCID_HN.TabIndex = 196;
            this.btnFindByCID_HN.Text = "ลงทะเบียนจากบัตรประชาชน";
            this.btnFindByCID_HN.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.Location = new System.Drawing.Point(17, 213);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(211, 20);
            this.label19.TabIndex = 195;
            this.label19.Text = "6. เลือกจำนวนแผ่นที่ต้องการพิมพ์";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.Location = new System.Drawing.Point(17, 150);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(185, 20);
            this.label22.TabIndex = 194;
            this.label22.Text = "5. เลือกเครื่องปริ๊นท์สติกเกอร์";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.Location = new System.Drawing.Point(16, 123);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(198, 20);
            this.label21.TabIndex = 193;
            this.label21.Text = "4. ติ๊กถูกที่ Auto/Monitor >>>";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.Location = new System.Drawing.Point(16, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(230, 20);
            this.label18.TabIndex = 192;
            this.label18.Text = "3. เลือกเครื่องอ่าน SmartCard >>>";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label17.Location = new System.Drawing.Point(16, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(217, 20);
            this.label17.TabIndex = 191;
            this.label17.Text = "2. กดปุ่ม Refresh reader    >>>";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.Location = new System.Drawing.Point(16, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(203, 20);
            this.label16.TabIndex = 190;
            this.label16.Text = "1. เสียบเครื่องอ่าน Smart Card";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(14, 473);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 20);
            this.label15.TabIndex = 189;
            this.label15.Text = "13 หลัก";
            this.label15.Visible = false;
            // 
            // cboPrinter
            // 
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(16, 173);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(203, 24);
            this.cboPrinter.TabIndex = 188;
            // 
            // btnTestPrint
            // 
            this.btnTestPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnTestPrint.Location = new System.Drawing.Point(1059, 10);
            this.btnTestPrint.Name = "btnTestPrint";
            this.btnTestPrint.Size = new System.Drawing.Size(169, 50);
            this.btnTestPrint.TabIndex = 187;
            this.btnTestPrint.Text = "Test Print";
            this.btnTestPrint.UseVisualStyleBackColor = true;
            // 
            // txtPrintNumber
            // 
            this.txtPrintNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtPrintNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPrintNumber.FormattingEnabled = true;
            this.txtPrintNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.txtPrintNumber.Location = new System.Drawing.Point(88, 239);
            this.txtPrintNumber.Name = "txtPrintNumber";
            this.txtPrintNumber.Size = new System.Drawing.Size(55, 28);
            this.txtPrintNumber.TabIndex = 186;
            // 
            // lblOfficerUsername
            // 
            this.lblOfficerUsername.AutoSize = true;
            this.lblOfficerUsername.Location = new System.Drawing.Point(654, 663);
            this.lblOfficerUsername.Name = "lblOfficerUsername";
            this.lblOfficerUsername.Size = new System.Drawing.Size(145, 21);
            this.lblOfficerUsername.TabIndex = 185;
            this.lblOfficerUsername.Text = "lblOfficerUsername";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(944, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 184;
            this.label14.Text = "รูปจากฐานข้อมูล";
            // 
            // pbPictureFromDatabase
            // 
            this.pbPictureFromDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPictureFromDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPictureFromDatabase.Location = new System.Drawing.Point(816, 215);
            this.pbPictureFromDatabase.Name = "pbPictureFromDatabase";
            this.pbPictureFromDatabase.Size = new System.Drawing.Size(412, 431);
            this.pbPictureFromDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPictureFromDatabase.TabIndex = 183;
            this.pbPictureFromDatabase.TabStop = false;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnTest.Location = new System.Drawing.Point(884, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(169, 50);
            this.btnTest.TabIndex = 182;
            this.btnTest.Text = "Test New Case";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnBarcode.Location = new System.Drawing.Point(625, 418);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(169, 40);
            this.btnBarcode.TabIndex = 181;
            this.btnBarcode.Text = "Print Barcode";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(587, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 20);
            this.label12.TabIndex = 180;
            this.label12.Text = "HN";
            // 
            // txtHN
            // 
            this.txtHN.Enabled = false;
            this.txtHN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHN.Location = new System.Drawing.Point(625, 168);
            this.txtHN.Name = "txtHN";
            this.txtHN.Size = new System.Drawing.Size(169, 29);
            this.txtHN.TabIndex = 147;
            this.txtHN.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 663);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(490, 21);
            this.label10.TabIndex = 179;
            this.label10.Text = "Special thanks to : https://github.com/chakphanu/ThaiNationalIDCard";
            // 
            // lbLibVersion
            // 
            this.lbLibVersion.AutoSize = true;
            this.lbLibVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLibVersion.Location = new System.Drawing.Point(260, 10);
            this.lbLibVersion.Name = "lbLibVersion";
            this.lbLibVersion.Size = new System.Drawing.Size(61, 21);
            this.lbLibVersion.TabIndex = 178;
            this.lbLibVersion.Text = "label10";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(359, 433);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 20);
            this.label13.TabIndex = 176;
            this.label13.Text = "วันหมดอายุ";
            // 
            // lbl_issue
            // 
            this.lbl_issue.AutoSize = true;
            this.lbl_issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_issue.Location = new System.Drawing.Point(441, 411);
            this.lbl_issue.Name = "lbl_issue";
            this.lbl_issue.Size = new System.Drawing.Size(70, 20);
            this.lbl_issue.TabIndex = 175;
            this.lbl_issue.Text = "lbl_issue";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(360, 411);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 174;
            this.label11.Text = "วันออกบัตร";
            // 
            // btnRefreshReaderList
            // 
            this.btnRefreshReaderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnRefreshReaderList.Location = new System.Drawing.Point(264, 59);
            this.btnRefreshReaderList.Name = "btnRefreshReaderList";
            this.btnRefreshReaderList.Size = new System.Drawing.Size(124, 30);
            this.btnRefreshReaderList.TabIndex = 173;
            this.btnRefreshReaderList.Text = "Refresh reader list";
            this.btnRefreshReaderList.UseVisualStyleBackColor = true;
            this.btnRefreshReaderList.Click += new System.EventHandler(this.btnRefreshReaderList_Click);
            // 
            // chkBoxMonitor
            // 
            this.chkBoxMonitor.AutoSize = true;
            this.chkBoxMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkBoxMonitor.Location = new System.Drawing.Point(264, 124);
            this.chkBoxMonitor.Name = "chkBoxMonitor";
            this.chkBoxMonitor.Size = new System.Drawing.Size(102, 20);
            this.chkBoxMonitor.TabIndex = 172;
            this.chkBoxMonitor.Text = "Auto/Monitor";
            this.chkBoxMonitor.UseVisualStyleBackColor = true;
            this.chkBoxMonitor.CheckedChanged += new System.EventHandler(this.chkBoxMonitor_CheckedChanged);
            // 
            // cbxReaderList
            // 
            this.cbxReaderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReaderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbxReaderList.FormattingEnabled = true;
            this.cbxReaderList.Location = new System.Drawing.Point(264, 94);
            this.cbxReaderList.Name = "cbxReaderList";
            this.cbxReaderList.Size = new System.Drawing.Size(297, 24);
            this.cbxReaderList.TabIndex = 171;
            // 
            // btnReadWithPhoto
            // 
            this.btnReadWithPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnReadWithPhoto.Location = new System.Drawing.Point(382, 147);
            this.btnReadWithPhoto.Name = "btnReadWithPhoto";
            this.btnReadWithPhoto.Size = new System.Drawing.Size(179, 40);
            this.btnReadWithPhoto.TabIndex = 170;
            this.btnReadWithPhoto.Text = "&Read With PHOTO";
            this.btnReadWithPhoto.UseVisualStyleBackColor = true;
            this.btnReadWithPhoto.Visible = false;
            this.btnReadWithPhoto.Click += new System.EventHandler(this.btnReadWithPhoto_Click);
            // 
            // PhotoProgressBar1
            // 
            this.PhotoProgressBar1.Location = new System.Drawing.Point(447, 469);
            this.PhotoProgressBar1.MarqueeAnimationSpeed = 0;
            this.PhotoProgressBar1.Name = "PhotoProgressBar1";
            this.PhotoProgressBar1.Size = new System.Drawing.Size(347, 23);
            this.PhotoProgressBar1.TabIndex = 169;
            // 
            // pbPictureFromIDCard
            // 
            this.pbPictureFromIDCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPictureFromIDCard.Location = new System.Drawing.Point(625, 207);
            this.pbPictureFromIDCard.Name = "pbPictureFromIDCard";
            this.pbPictureFromIDCard.Size = new System.Drawing.Size(169, 196);
            this.pbPictureFromIDCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPictureFromIDCard.TabIndex = 168;
            this.pbPictureFromIDCard.TabStop = false;
            // 
            // lbl_expire
            // 
            this.lbl_expire.AutoSize = true;
            this.lbl_expire.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_expire.Location = new System.Drawing.Point(441, 433);
            this.lbl_expire.Name = "lbl_expire";
            this.lbl_expire.Size = new System.Drawing.Size(75, 20);
            this.lbl_expire.TabIndex = 177;
            this.lbl_expire.Text = "lbl_expire";
            // 
            // lbl_sex
            // 
            this.lbl_sex.AutoSize = true;
            this.lbl_sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_sex.Location = new System.Drawing.Point(441, 389);
            this.lbl_sex.Name = "lbl_sex";
            this.lbl_sex.Size = new System.Drawing.Size(57, 20);
            this.lbl_sex.TabIndex = 167;
            this.lbl_sex.Text = "lbl_sex";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(401, 389);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 20);
            this.label9.TabIndex = 166;
            this.label9.Text = "เพศ";
            // 
            // lbl_birthday
            // 
            this.lbl_birthday.AutoSize = true;
            this.lbl_birthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_birthday.Location = new System.Drawing.Point(441, 367);
            this.lbl_birthday.Name = "lbl_birthday";
            this.lbl_birthday.Size = new System.Drawing.Size(89, 20);
            this.lbl_birthday.TabIndex = 165;
            this.lbl_birthday.Text = "lbl_birthday";
            // 
            // lbl_en_lastname
            // 
            this.lbl_en_lastname.AutoSize = true;
            this.lbl_en_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_en_lastname.Location = new System.Drawing.Point(441, 345);
            this.lbl_en_lastname.Name = "lbl_en_lastname";
            this.lbl_en_lastname.Size = new System.Drawing.Size(125, 20);
            this.lbl_en_lastname.TabIndex = 164;
            this.lbl_en_lastname.Text = "lbl_en_lastname";
            // 
            // lbl_en_firstname
            // 
            this.lbl_en_firstname.AutoSize = true;
            this.lbl_en_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_en_firstname.Location = new System.Drawing.Point(441, 323);
            this.lbl_en_firstname.Name = "lbl_en_firstname";
            this.lbl_en_firstname.Size = new System.Drawing.Size(126, 20);
            this.lbl_en_firstname.TabIndex = 163;
            this.lbl_en_firstname.Text = "lbl_en_firstname";
            // 
            // lbl_en_prefix
            // 
            this.lbl_en_prefix.AutoSize = true;
            this.lbl_en_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_en_prefix.Location = new System.Drawing.Point(441, 301);
            this.lbl_en_prefix.Name = "lbl_en_prefix";
            this.lbl_en_prefix.Size = new System.Drawing.Size(98, 20);
            this.lbl_en_prefix.TabIndex = 162;
            this.lbl_en_prefix.Text = "lbl_en_prefix";
            // 
            // lbl_th_lastname
            // 
            this.lbl_th_lastname.AutoSize = true;
            this.lbl_th_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_th_lastname.Location = new System.Drawing.Point(441, 279);
            this.lbl_th_lastname.Name = "lbl_th_lastname";
            this.lbl_th_lastname.Size = new System.Drawing.Size(121, 20);
            this.lbl_th_lastname.TabIndex = 161;
            this.lbl_th_lastname.Text = "lbl_th_lastname";
            // 
            // lbl_th_firstname
            // 
            this.lbl_th_firstname.AutoSize = true;
            this.lbl_th_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_th_firstname.Location = new System.Drawing.Point(441, 257);
            this.lbl_th_firstname.Name = "lbl_th_firstname";
            this.lbl_th_firstname.Size = new System.Drawing.Size(122, 20);
            this.lbl_th_firstname.TabIndex = 160;
            this.lbl_th_firstname.Text = "lbl_th_firstname";
            // 
            // lbl_th_prefix
            // 
            this.lbl_th_prefix.AutoSize = true;
            this.lbl_th_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_th_prefix.Location = new System.Drawing.Point(441, 235);
            this.lbl_th_prefix.Name = "lbl_th_prefix";
            this.lbl_th_prefix.Size = new System.Drawing.Size(94, 20);
            this.lbl_th_prefix.TabIndex = 159;
            this.lbl_th_prefix.Text = "lbl_th_prefix";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(386, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 158;
            this.label8.Text = "วันเกิด";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(361, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 157;
            this.label7.Text = "lastname";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(360, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 156;
            this.label6.Text = "firstname";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(388, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 155;
            this.label5.Text = "prefix";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(401, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 154;
            this.label4.Text = "สกุล";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(409, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 20);
            this.label3.TabIndex = 153;
            this.label3.Text = "ชื่อ";
            // 
            // txtBoxLog
            // 
            this.txtBoxLog.Location = new System.Drawing.Point(264, 498);
            this.txtBoxLog.Multiline = true;
            this.txtBoxLog.Name = "txtBoxLog";
            this.txtBoxLog.ReadOnly = true;
            this.txtBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxLog.Size = new System.Drawing.Size(530, 148);
            this.txtBoxLog.TabIndex = 149;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(394, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 152;
            this.label2.Text = "คำนำ";
            // 
            // lbl_cid
            // 
            this.lbl_cid.AutoSize = true;
            this.lbl_cid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_cid.Location = new System.Drawing.Point(441, 213);
            this.lbl_cid.Name = "lbl_cid";
            this.lbl_cid.Size = new System.Drawing.Size(53, 20);
            this.lbl_cid.TabIndex = 151;
            this.lbl_cid.Text = "lbl_cid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(291, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 150;
            this.label1.Text = "รหัสประจำตัวประชาชน";
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnRead.Location = new System.Drawing.Point(264, 147);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(98, 40);
            this.btnRead.TabIndex = 148;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Visible = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // FormSmartCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 695);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnTransferData);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnUpdateHN);
            this.Controls.Add(this.txtCID2);
            this.Controls.Add(this.txtCID);
            this.Controls.Add(this.btnPrintMoreSticker);
            this.Controls.Add(this.btnFindByCID_HN);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboPrinter);
            this.Controls.Add(this.btnTestPrint);
            this.Controls.Add(this.txtPrintNumber);
            this.Controls.Add(this.lblOfficerUsername);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pbPictureFromDatabase);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtHN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbLibVersion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbl_issue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnRefreshReaderList);
            this.Controls.Add(this.chkBoxMonitor);
            this.Controls.Add(this.cbxReaderList);
            this.Controls.Add(this.btnReadWithPhoto);
            this.Controls.Add(this.PhotoProgressBar1);
            this.Controls.Add(this.pbPictureFromIDCard);
            this.Controls.Add(this.lbl_expire);
            this.Controls.Add(this.lbl_sex);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_birthday);
            this.Controls.Add(this.lbl_en_lastname);
            this.Controls.Add(this.lbl_en_firstname);
            this.Controls.Add(this.lbl_en_prefix);
            this.Controls.Add(this.lbl_th_lastname);
            this.Controls.Add(this.lbl_th_firstname);
            this.Controls.Add(this.lbl_th_prefix);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_cid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRead);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = global::BackOfficeApplication.Properties.Resources.psswlogo_XbZ_icon;
            this.MaximizeBox = false;
            this.Name = "FormSmartCard";
            this.Text = "Smart Card Reader cOde : by Pattharapol";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSmartCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureFromDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPictureFromIDCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private DevExpress.XtraEditors.SimpleButton btnTransferData;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton btnUpdateHN;
        private System.Windows.Forms.TextBox txtCID2;
        private System.Windows.Forms.TextBox txtCID;
        private System.Windows.Forms.Button btnPrintMoreSticker;
        private System.Windows.Forms.Button btnFindByCID_HN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Button btnTestPrint;
        private System.Windows.Forms.ComboBox txtPrintNumber;
        private System.Windows.Forms.Label lblOfficerUsername;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pbPictureFromDatabase;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbLibVersion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_issue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRefreshReaderList;
        private System.Windows.Forms.CheckBox chkBoxMonitor;
        private System.Windows.Forms.ComboBox cbxReaderList;
        private System.Windows.Forms.Button btnReadWithPhoto;
        private System.Windows.Forms.ProgressBar PhotoProgressBar1;
        private System.Windows.Forms.PictureBox pbPictureFromIDCard;
        private System.Windows.Forms.Label lbl_expire;
        private System.Windows.Forms.Label lbl_sex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_birthday;
        private System.Windows.Forms.Label lbl_en_lastname;
        private System.Windows.Forms.Label lbl_en_firstname;
        private System.Windows.Forms.Label lbl_en_prefix;
        private System.Windows.Forms.Label lbl_th_lastname;
        private System.Windows.Forms.Label lbl_th_firstname;
        private System.Windows.Forms.Label lbl_th_prefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRead;
    }
}