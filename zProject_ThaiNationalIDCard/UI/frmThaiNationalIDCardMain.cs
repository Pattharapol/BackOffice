using BackOfficeApplication.DataCenter;
using BackOfficeApplication.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HumanResource.zProject_ThaiNationalIDCard.Report;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard;
using DataSet = HumanResource.zProject_ThaiNationalIDCard.Report.DataSet;

namespace HumanResource.zProject_ThaiNationalIDCard.UI
{
    public partial class frmThaiNationalIDCardMain : DevExpress.XtraEditors.XtraForm
    {
        private ThaiIDCard idcard;
        private DataTable dt;
        private DataSet ds;
        private static MySqlConnection con;
        private MySqlDataAdapter da;
        private MySqlCommand cmd;
        private Personal personal;

        private ConnectionStringModel model = new ConnectionStringModel();

        private string officerUsername { get; }

        public frmThaiNationalIDCardMain()
        {
            InitializeComponent();
            //GetConnectionString()
            DataAccess.GetConnectionString();
        }

        public frmThaiNationalIDCardMain(string officerName)
        {
            InitializeComponent();
            //GetConnectionString()
            DataAccess.GetConnectionString();
            officerUsername = officerName;
        }

        private void frmThaiNationalIDCardMain_Load(object sender, EventArgs e)
        {
            GetPrinter();
            idcard = new ThaiIDCard();
            lbLibVersion.Text = "LibThaiIDCard version: " + idcard.Version();
            //chkBoxMonitor.Checked = true;
            lblOfficerUsername.Text = $"ผู้ใช้งาน : {officerUsername}";
            txtPrintNumber.SelectedIndex = 0;
            DataAccess.GetConnectionString();
            GetConnection();
            DataAccess.UpdateHN_Hosdata_Docno();
        }

        private void Log(string text = "")
        {
            if (txtBoxLog.InvokeRequired)
            {
                txtBoxLog.BeginInvoke(new MethodInvoker(delegate { txtBoxLog.AppendText(text); }));
            }
            else
            {
                txtBoxLog.AppendText(text);
            }
        }

        private void LogLine(string text = "")
        {
            if (txtBoxLog.InvokeRequired)
            {
                txtBoxLog.BeginInvoke(new MethodInvoker(delegate { txtBoxLog.AppendText(text + Environment.NewLine); }));
            }
            else
            {
                txtBoxLog.AppendText(text + Environment.NewLine);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_cid.Text = "Reading...";
                Refresh();
                Personal personal = idcard.readAll();
                if (personal != null)
                {
                    lbl_cid.Text = personal.Citizenid;
                    lbl_birthday.Text = personal.Birthday.ToString("dd/MM/yyyy");
                    lbl_sex.Text = personal.Sex;
                    lbl_th_prefix.Text = personal.Th_Prefix;
                    lbl_th_firstname.Text = personal.Th_Firstname;
                    lbl_th_lastname.Text = personal.Th_Lastname;
                    lbl_en_prefix.Text = personal.En_Prefix;
                    lbl_en_firstname.Text = personal.En_Firstname;
                    lbl_en_lastname.Text = personal.En_Lastname;
                    lbl_issue.Text = personal.Issue.ToString("dd/MM/yyyy");
                    lbl_expire.Text = personal.Expire.ToString("dd/MM/yyyy");

                    LogLine(personal.Address);
                    LogLine(personal.addrHouseNo); // บ้านเลขที่
                    LogLine(personal.addrVillageNo); // หมู่ที่
                    LogLine(personal.addrLane); // ซอย
                    LogLine(personal.addrRoad); // ถนน
                    LogLine(personal.addrTambol);
                    LogLine(personal.addrAmphur);
                    LogLine(personal.addrProvince);
                    LogLine(personal.Issuer);
                }
                else if (idcard.ErrorCode() > 0)
                {
                    MessageBox.Show(idcard.Error());
                }
                else
                {
                    MessageBox.Show("Catch all");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void photoProgress(int value, int maximum)
        {
            try
            {
                if (txtBoxLog.InvokeRequired)
                {
                    if (PhotoProgressBar1.Maximum != maximum)
                        PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Maximum = maximum; }));

                    // fix progress bar sync.
                    if (PhotoProgressBar1.Maximum > value)
                        PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Value = value + 1; }));

                    PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Value = value; }));
                }
                else
                {
                    if (PhotoProgressBar1.Maximum != maximum)
                        PhotoProgressBar1.Maximum = maximum;

                    // fix progress bar sync.
                    if (PhotoProgressBar1.Maximum > value)
                        PhotoProgressBar1.Value = value + 1;

                    PhotoProgressBar1.Value = value;
                }
            }
            catch
            {
            }
        }

        private void GetConnection()
        {
            try
            {
                string path = "C:\\Temp\\config.txt";
                string[] lines = File.ReadAllLines(path);
                model.Server = lines[0];
                model.Userid = lines[1];
                model.Password = lines[2];
                model.PicurePath = lines[3];
                //if (File.Exists($"{model.PicurePath}person.jpg"))
                //{
                //    MessageBox.Show($"{model.PicurePath}person.jpg");
                //}
                //else
                //{
                //    MessageBox.Show($"NO");
                //}

                //txtServer.Text = lines[0];
                //txtUserID.Text = lines[1];
                //txtPassword.Text = lines[2];
                //cbxPicPath.Text = lines[3];
            }
            catch
            {
            }
        }

        // get value from CardInserted Method...
        private string ptAddress = "";

        public void CardInserted(Personal personal)
        {
            try
            {
                if (personal == null)
                {
                    if (idcard.ErrorCode() > 0)
                    {
                        MessageBox.Show(idcard.Error());
                    }
                    return;
                }

                lbl_cid.BeginInvoke(new MethodInvoker(delegate { lbl_cid.Text = personal.Citizenid; }));
                lbl_birthday.BeginInvoke(new MethodInvoker(delegate { lbl_birthday.Text = personal.Birthday.ToString("yyyy-MM-dd"); }));
                lbl_sex.BeginInvoke(new MethodInvoker(delegate { lbl_sex.Text = personal.Sex; }));
                lbl_th_prefix.BeginInvoke(new MethodInvoker(delegate { lbl_th_prefix.Text = personal.Th_Prefix; }));
                lbl_th_firstname.BeginInvoke(new MethodInvoker(delegate { lbl_th_firstname.Text = personal.Th_Firstname; }));
                lbl_th_lastname.BeginInvoke(new MethodInvoker(delegate { lbl_th_lastname.Text = personal.Th_Lastname; }));
                lbl_en_prefix.BeginInvoke(new MethodInvoker(delegate { lbl_en_prefix.Text = personal.En_Prefix; }));
                lbl_en_firstname.BeginInvoke(new MethodInvoker(delegate { lbl_en_firstname.Text = personal.En_Firstname; }));
                lbl_en_lastname.BeginInvoke(new MethodInvoker(delegate { lbl_en_lastname.Text = personal.En_Lastname; }));
                lbl_issue.BeginInvoke(new MethodInvoker(delegate { lbl_issue.Text = personal.Issue.ToString("dd/MM/yyyy"); }));
                lbl_expire.BeginInvoke(new MethodInvoker(delegate { lbl_expire.Text = personal.Expire.ToString("dd/MM/yyyy"); }));
                pbPictureFromIDCard.BeginInvoke(new MethodInvoker(delegate { pbPictureFromIDCard.Image = personal.PhotoBitmap; }));

                ///////////////////////////////////
                LogLine(personal.Address);
                ptAddress = personal.Address;
                this.BeginInvoke(new MethodInvoker(delegate { CheckIfExist(); }));
            }
            catch
            {
            }
        }

        private void btnReadWithPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_cid.Text = "Reading...";
                Refresh();
                idcard.eventPhotoProgress += new handlePhotoProgress(photoProgress);
                personal = idcard.readAllPhoto();
                if (personal != null)
                {
                    lbl_cid.Text = personal.Citizenid;
                    lbl_birthday.Text = personal.Birthday.ToString("yyyy-MM-dd");
                    lbl_sex.Text = personal.Sex;
                    lbl_th_prefix.Text = personal.Th_Prefix;
                    lbl_th_firstname.Text = personal.Th_Firstname;
                    lbl_th_lastname.Text = personal.Th_Lastname;
                    lbl_en_prefix.Text = personal.En_Prefix;
                    lbl_en_firstname.Text = personal.En_Firstname;
                    lbl_en_lastname.Text = personal.En_Lastname;
                    lbl_issue.Text = personal.Issue.ToString("dd/MM/yyyy");
                    lbl_expire.Text = personal.Expire.ToString("dd/MM/yyyy");
                    pbPictureFromIDCard.Image = personal.PhotoBitmap;

                    //////////////
                    CheckIfExist();
                }
                else if (idcard.ErrorCode() > 0)
                {
                    MessageBox.Show(idcard.Error());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshReaderList_Click(object sender, EventArgs e)
        {
            cbxReaderList.Items.Clear();
            cbxReaderList.SelectedIndex = -1;
            cbxReaderList.SelectedText = String.Empty;
            cbxReaderList.Text = string.Empty;
            cbxReaderList.Refresh();

            try
            {
                ThaiIDCard idcard = new ThaiIDCard();
                string[] readers = idcard.GetReaders();

                if (readers == null) return;

                foreach (string r in readers)
                {
                    cbxReaderList.Items.Add(r);
                }
                cbxReaderList.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chkBoxMonitor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBoxMonitor.Checked)
                {
                    if (cbxReaderList.SelectedItem == null)
                    {
                        MessageBox.Show("No reader select to monitoring.");
                        chkBoxMonitor.Checked = false;
                        return;
                    }
                    idcard.MonitorStart(cbxReaderList.SelectedItem.ToString());
                    idcard.eventCardInsertedWithPhoto += new handleCardInserted(CardInserted);
                    idcard.eventPhotoProgress += new handlePhotoProgress(photoProgress);
                }
                else
                {
                    if (cbxReaderList.SelectedItem != null)
                        idcard.MonitorStop(cbxReaderList.SelectedItem.ToString());
                }
            }
            catch
            {
            }
        }

        private void CheckIfExist()
        {
            // บางที การ์ดทำงานก็ไม่สมบูรณ์ ดักไว้ก่อน
            if (lbl_cid.Text == "lbl_cid")
            {
                MessageBox.Show("กรุณาลองใหม่อีกครั้งครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                // เช็คว่า เคยลงทะเบียนหรือยัง
                dt = new DataTable();
                ds = new DataSet();
                string sql = string.Format(@"SELECT pt.pt.hn, replace(pt.pt.cardid, '-','') as card, concat(pt.pt.pttitle, pt.pt.ptfname, ' ', pt.pt.ptlname) as name FROM pt.pt WHERE replace(pt.pt.cardid, '-','') = '{0}'", lbl_cid.Text.Trim());

                dt = DataAccess.RetriveData(sql);
                if (dt.Rows.Count > 0)
                {
                    // if people who come is registered, then print...
                    txtHN.Text = dt.Rows[0][0].ToString();
                    txtHN.ReadOnly = true;
                    txtHN.Visible = true;
                    btnBarcode.Visible = true;
                    // เช็คว่ามีรูปมั้ย
                    Directory.CreateDirectory(model.PicurePath); // if exist, this line will be ignore
                    if (File.Exists($"{model.PicurePath}{lbl_cid.Text}.jpg"))
                    {
                        try
                        {
                            pbPictureFromDatabase.Image = Image.FromFile($"{model.PicurePath}{lbl_cid.Text}.jpg");
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            Bitmap bmp = new Bitmap(pbPictureFromIDCard.Image);
                            Image img = bmp;
                            img.Save(lbl_cid.Text + ".jpg", ImageFormat.Jpeg);
                            FileInfo _img = new FileInfo(lbl_cid.Text + ".jpg");
                            if (File.Exists($"{model.PicurePath}{lbl_cid.Text}.jpg"))
                            {
                                try
                                {
                                    File.Delete($"{model.PicurePath}{lbl_cid.Text}.jpg");
                                    _img.MoveTo($"{model.PicurePath}{lbl_cid.Text}.jpg");
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                try
                                {
                                    _img.MoveTo($"{model.PicurePath}{lbl_cid.Text}.jpg");
                                }
                                catch
                                {
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // oldcase
                    oldCase();
                }
                else
                {
                    // if not, go to newCase Method
                    // newCase();

                    XtraMessageBox.Show("ไม่พบคนไข้รายนี้ในระบบ...กรุณาขึ้นบัตรใหม่ที่ HIMPRO ด้วยครับ", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void newCase()
        {
            // age "yyyy-MM-dd"
            int yearAge = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(lbl_birthday.Text.Substring(0, 4));
            int monthAge = 0;
            int monthNow = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("MM")));
            int birthMonth = Convert.ToInt32(lbl_birthday.Text.Substring(5, 2));
            if (birthMonth > monthNow)
            {
                monthAge = -(-birthMonth + monthNow);
            }
            else
            {
                monthAge = monthNow - birthMonth;
            }
            int dayAge = 0;
            int dayNow = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("dd")));
            int birthDay = Convert.ToInt32(lbl_birthday.Text.Substring(8, 2));
            if (birthDay < dayNow)
            {
                dayAge = dayNow - birthDay;
            }
            else
            {
                dayAge = -(birthDay - dayNow);
            }

            // save image
            Bitmap bmp = new Bitmap(pbPictureFromIDCard.Image);
            Image img = bmp;
            img.Save(lbl_cid.Text + ".jpg", ImageFormat.Jpeg);
            FileInfo _img = new FileInfo(lbl_cid.Text + ".jpg");
            if (File.Exists($"{model.PicurePath}{lbl_cid.Text}.jpg"))
            {
                try
                {
                    File.Delete($"{model.PicurePath}{lbl_cid.Text}.jpg");
                    _img.MoveTo($"{model.PicurePath}{lbl_cid.Text}.jpg");
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    _img.MoveTo($"{model.PicurePath}{lbl_cid.Text}.jpg");
                }
                catch
                {
                }
            }

            DataTable dtMAX_HN = new DataTable();
            string sqlMAX_HN = "SELECT MAX(CAST(pt.pt.hn AS UNSIGNED INTEGER)) FROM pt.pt";
            dtMAX_HN = DataAccess.RetriveData(sqlMAX_HN);
            if (dtMAX_HN.Rows[0][0].ToString().Length == 5)
            {
                txtHN.Text = "00" + (Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                txtHN.ReadOnly = false;
            }
            if (dtMAX_HN.Rows[0][0].ToString().Length == 6)
            {
                txtHN.Text = "0" + (Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                txtHN.ReadOnly = false;
            }
            if (dtMAX_HN.Rows[0][0].ToString().Length == 7)
            {
                txtHN.Text = Convert.ToString(Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                txtHN.ReadOnly = false;
            }

            // regdate
            string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            // hn
            //string hn = "x" + txtHN.Text;
            string hn = txtHN.Text;
            // cardid
            string cardid = lbl_cid.Text.Insert(1, "-").Insert(6, "-").Insert(12, "-").Insert(15, "-");
            // pttitle
            string title = lbl_th_prefix.Text;
            // ptfname
            string firstName = lbl_th_firstname.Text;
            // ptlname
            string lastName = lbl_th_lastname.Text;

            // ptsex
            string sex = "";
            if (lbl_th_prefix.Text == "นาง" || lbl_th_prefix.Text == "นางสาว" || lbl_th_prefix.Text == "น.ส." || lbl_th_prefix.Text == "ด.ญ." || lbl_th_prefix.Text == "นางสาว")
            {
                sex = "SX2";
            }
            else if (lbl_th_prefix.Text == "นาย" || lbl_th_prefix.Text == "สามเณร" || lbl_th_prefix.Text == "ด.ช." || lbl_th_prefix.Text == "พระ")
            {
                sex = "SX1";
            }
            else
            {
                sex = "SX1";
            }

            // ptdob
            string dateOfBirth = "";
            if (lbl_birthday.Text.Contains("/"))
            {
                string date = lbl_birthday.Text.Substring(0, 2);
                string month = lbl_birthday.Text.Substring(3, 2);
                int year = Convert.ToInt32(lbl_birthday.Text.Substring(6)) - 543;
                dateOfBirth = year.ToString() + "-" + month + "-" + date;
            }
            else
            {
                int year = Convert.ToInt32(lbl_birthday.Text.Substring(0, 4)) - 543;
                dateOfBirth = year + Convert.ToDateTime(lbl_birthday.Text).ToString("yyyy-MM-dd").Substring(4);
            }

            // ptdobtrust
            string ptdobtrust = "AGETY1";
            // married
            string married = "MA1";
            // ptnation
            string ptnation = "99";
            // ptrace
            string ptrace = "99";
            // religion
            string religion = "RL1";
            //// ptaddress
            string ptaddress = ptAddress.Replace("ตำบล", "").Replace("ที่", "").Replace("อำเภอ", "").Replace("จังหวัด", "");

            // cardroom
            string cardroom = "CARD1";
            // timereg
            string timereg = DateTime.Now.ToString("HH:mm:ss");
            // carduser, receive from who logged in
            string carduser = officerUsername;
            // user_update, receive from who logged in
            string user_update = officerUsername;
            // typeHn
            string typeHn = "HNTY1";
            // pcucode
            string pcucode = "28015";
            // send screen room
            string sendscrroom = "SCR8";

            // update hosdata.docno for keep last HN updating for original HIMPRO function
            string docNo_Year = DateTime.Now.ToString("yyyy");
            string sql_Update_HOsdata_Docno_MaxHN = string.Format(@"UPDATE hosdata.docno SET hosdata.docno.no = hosdata.docno.no + 1 WHERE hosdata.docno.code = 'HN' AND hosdata.docno.year = '{0}'", docNo_Year);
            DataAccess.ExecuteSQL(sql_Update_HOsdata_Docno_MaxHN);

            // insert into pt.pt in new case
            string sqlInsertToPT = string.Format(@"INSERT INTO pt.pt (regdate, hn, cardid, pttitle, ptfname, ptlname, ptsex, ptdob, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, updatedate, date_update, lastvisitdate, carduser, user_update, typeHn, pcucode, sendscrroom) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}', '{19}', '{20}', '{21}', '{22}', '{23}')", regdate, hn, cardid, title, firstName, lastName, sex, dateOfBirth, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, regdate, regdate, regdate, carduser, user_update, typeHn, pcucode, sendscrroom);
            DataAccess.ExecuteSQL(sqlInsertToPT);

            // insert into opd.opd , register on PCU
            // สิทธิ์ส่งเสริม มาเพื่อฉีดวัคซีนป้องกันโควิด
            string ptClass = "07";
            string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", pcucode, regdate, hn, "1", timereg, timereg, "TP1", cardroom, lbl_th_prefix.Text + lbl_th_firstname.Text + " " + lbl_th_lastname.Text, ptClass, "รับวัคซีนโควิด-19", "INV14", officerUsername, "PT2", "IN1", "TV1", sendscrroom, "153", regdate, yearAge, monthAge, dayAge, cardid);
            DataAccess.ExecuteSQL(sqlInsertTo_OPD_OPD);
            txtHN.Text = hn;

            // insert into opd.oqueue
            // select last queue
            DataTable dtCheckQueue = new DataTable();
            string sqlCheckQueue = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", regdate);
            dtCheckQueue = DataAccess.RetriveData(sqlCheckQueue);
            int queue = 1;
            if (dtCheckQueue.Rows.Count > 0)
            {
                try
                {
                    queue = 1 + Convert.ToInt32(dtCheckQueue.Rows[0][0].ToString());
                }
                catch
                {
                    queue = 1;
                }
            }
            else
            {
                queue = 1;
            }

            int frequency = 1;
            string sqlInsertTo_OPD_OQUEUE = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", pcucode, regdate, hn, frequency, queue, cardroom, "001", sendscrroom, queue, regdate);
            DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE);

            PrintNewCase();
        }

        public void oldCase()
        {
            // age "yyyy-MM-dd"
            int yearAge = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(lbl_birthday.Text.Substring(0, 4));
            int monthAge = 0;
            int monthNow = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("MM")));
            int birthMonth = Convert.ToInt32(lbl_birthday.Text.Substring(5, 2));
            if (birthMonth > monthNow)
            {
                monthAge = -(-birthMonth + monthNow);
            }
            else if (birthMonth == monthNow)
            {
                monthAge = 0;
            }
            else
            {
                monthAge = monthNow - birthMonth;
            }
            int dayAge = 0;
            int dayNow = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("dd")));
            int birthDay = Convert.ToInt32(lbl_birthday.Text.Substring(8, 2));
            if (birthDay < dayNow)
            {
                dayAge = dayNow - birthDay;
            }
            else if (dayNow == birthDay)
            {
                dayAge = 0;
            }
            else
            {
                dayAge = birthDay - dayNow;
            }

            // cardroom
            string cardroom = "CARD1";
            // timereg
            string timereg = DateTime.Now.ToString("HH:mm");
            // carduser, receive from who logged in
            string carduser = officerUsername;
            // user_update, receive from who logged in
            string user_update = officerUsername;
            // typeHn
            string typeHn = "HNTY1";
            // pcucode
            string pcucode = "28015";
            // send screen room
            string sendscrroom = "SCR8";
            // regdate
            string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            // hn
            //string hn = "x" + txtHN.Text;
            string hn = txtHN.Text;
            // cardid
            string cardid = "";
            if (lbl_cid.Text == "lbl_cid")
            {
                XtraMessageBox.Show("เกิดการทำงานผิดพลาด กรุณาถอดบัตรแล้วลองอีกครั้งครับ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cardid = lbl_cid.Text.Insert(1, "-").Insert(6, "-").Insert(12, "-").Insert(15, "-");
            }

            // CHeck If people came in that day...
            DataTable dtCheckCamein = new DataTable();
            string sqlCheckCameIn = string.Format(@"SELECT * FROM opd.opd WHERE opd.opd.hn = '{0}' AND opd.opd.regdate = '{1}'", hn, regdate);
            dtCheckCamein = DataAccess.RetriveData(sqlCheckCameIn);
            if (dtCheckCamein.Rows.Count > 0)
            {
                if (pbPictureFromIDCard.Image == null)
                {
                    // stop
                }
                else
                {
                    // check if people registered on vaccine covid-19
                    // sometime some people regis twice coz of user insert card twice on some reason...
                    string sqlCheckIfRegisOnOPD_OPD = string.Format(@"SELECT opd.opd.hn, opd.opd.fullname, opd.opd.reguser, opd.opd.timereg, opd.opd.sign FROM opd.opd WHERE (opd.opd.SIGN LIKE '%โควิด%') AND  (opd.opd.sendScrRoom = 'SCR8') AND (opd.opd.ptclass = '07')  AND (opd.opd.regdate = '{0}') AND (opd.opd.hn = '{1}') ", regdate, hn);
                    DataTable dtCheckIfRegisOnOPD_OPD = new DataTable();
                    dtCheckIfRegisOnOPD_OPD = DataAccess.RetriveData(sqlCheckIfRegisOnOPD_OPD);

                    if (dtCheckIfRegisOnOPD_OPD.Rows.Count > 0)
                    {
                        if (XtraMessageBox.Show($"ผู้ป่วย hn : {dtCheckIfRegisOnOPD_OPD.Rows[0][0].ToString()} {dtCheckIfRegisOnOPD_OPD.Rows[0][1].ToString()} " + Environment.NewLine + $"ได้ลงทะเบียนฉีดวัคซีนแล้ว โดย : {dtCheckIfRegisOnOPD_OPD.Rows[0][2].ToString()} " + Environment.NewLine + $"เวลา : {dtCheckIfRegisOnOPD_OPD.Rows[0][3].ToString()} เหตุผลที่มา : {dtCheckIfRegisOnOPD_OPD.Rows[0][4].ToString()} ต้องการพิมพ์บาร์โค้ด ใช่หรือไม่" + Environment.NewLine + "ผู้ป่วยลงทะเบียนฉีดวัคซีนแล้วครับ",
                            "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                        {
                            txtHN.Text = dtCheckIfRegisOnOPD_OPD.Rows[0][0].ToString();
                            txtHN.ReadOnly = true;
                            btnBarcode.Enabled = true;
                            btnBarcode.Visible = true;
                            PrintOldCase();
                        }
                        return;
                    }
                    else
                    {
                        // insert into opd.opd, plus 1 for opd.opd.frequency
                        string sqlCheckOPD_OPD = string.Format(@"SELECT opd.opd.hn, opd.opd.frequency FROM opd.opd WHERE opd.opd.hn = '{0}' AND opd.opd.regdate = '{1}'", hn, regdate);
                        DataTable dtCHeckOPD_OPD = new DataTable();
                        dtCHeckOPD_OPD = DataAccess.RetriveData(sqlCheckOPD_OPD);
                        if (dtCHeckOPD_OPD.Rows.Count > 0)
                        {
                            int frequency_OPD = 1;
                            try
                            {
                                frequency_OPD = Convert.ToInt32(dtCHeckOPD_OPD.Rows[0][1].ToString()) + 1;
                            }
                            catch
                            {
                                frequency_OPD = 1;
                            }
                            string sqlInsert_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", pcucode, regdate, hn, frequency_OPD, timereg, timereg, "TP1", cardroom, lbl_th_prefix.Text + lbl_th_firstname.Text + " " + lbl_th_lastname.Text, "07", "รับวัคซีนโควิด-19", "INV14", officerUsername, "PT2", "IN1", "TV1", sendscrroom, "153", regdate, yearAge, monthAge, dayAge, cardid);
                            DataAccess.ExecuteSQL(sqlInsert_OPD);

                            // select last queue
                            DataTable dtCheckQueue = new DataTable();
                            string sqlCheckQueue = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", regdate);
                            dtCheckQueue = DataAccess.RetriveData(sqlCheckQueue);
                            int queue = 1;
                            if (dtCheckQueue.Rows.Count > 0)
                            {
                                try
                                {
                                    queue = 1 + Convert.ToInt32(dtCheckQueue.Rows[0][0].ToString());
                                }
                                catch
                                {
                                    queue = 1;
                                }
                            }
                            else
                            {
                                queue = 1;
                            }

                            // insert into opd.oqueue
                            // check frequency at opd.oqueue if the HN exist in that day
                            DataTable dtCheckFrequency = new DataTable();
                            string sqlCheckFrequency = string.Format(@"SELECT opd.oqueue.hn, MAX(opd.oqueue.frequency) FROM opd.oqueue WHERE opd.oqueue.hn = '{0}' AND opd.oqueue.regdate = '{1}' ORDER BY opd.oqueue.regdate DESC LIMIT 1", hn, regdate);
                            dtCheckFrequency = DataAccess.RetriveData(sqlCheckFrequency);
                            if (dtCheckFrequency.Rows.Count > 0)
                            {
                                int frequency = 1;
                                try
                                {
                                    frequency = Convert.ToInt32(dtCHeckOPD_OPD.Rows[0][1].ToString()) + 1;
                                }
                                catch
                                {
                                    frequency = 1;
                                }
                                string sqlInsertTo_OPD_OQUEUE_ADD_QUEUE = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", pcucode, regdate, hn, frequency, queue, cardroom, "001", sendscrroom, queue, regdate);
                                DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE_ADD_QUEUE);
                            }
                        }
                        else
                        {
                            // select last queue
                            DataTable dtCheckQueue = new DataTable();
                            string sqlCheckQueue = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", regdate);
                            dtCheckQueue = DataAccess.RetriveData(sqlCheckQueue);
                            int queue = 1;
                            if (dtCheckQueue.Rows.Count > 0)
                            {
                                try
                                {
                                    queue = 1 + Convert.ToInt32(dtCheckQueue.Rows[0][0].ToString());
                                }
                                catch
                                {
                                    queue = 1;
                                }
                            }
                            else
                            {
                                queue = 1;
                            }

                            // insert into opd.oqueue
                            // check frequency at opd.oqueue if the HN exist in that day
                            DataTable dtCheckFrequency = new DataTable();
                            string sqlCheckFrequency = string.Format(@"SELECT opd.oqueue.hn, MAX(opd.oqueue.frequency) FROM opd.oqueue WHERE opd.oqueue.hn = '{0}' AND opd.oqueue.regdate = '{1}' ORDER BY opd.oqueue.regdate DESC LIMIT 1", hn, regdate);
                            dtCheckFrequency = DataAccess.RetriveData(sqlCheckFrequency);
                            if (dtCheckFrequency.Rows.Count > 0)
                            {
                                int frequency = 1;
                                try
                                {
                                    frequency = 1 + Convert.ToInt32(dtCheckFrequency.Rows[0][1].ToString());
                                }
                                catch
                                {
                                    frequency = 1;
                                }
                                string sqlInsertTo_OPD_OQUEUE_ADD_QUEUE = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", pcucode, regdate, hn, frequency, queue, cardroom, "001", sendscrroom, queue, regdate);
                                DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE_ADD_QUEUE);
                            }
                        }
                    }
                }
            }
            else
            {
                if (pbPictureFromIDCard.Image == null)
                {
                    // stop
                }
                else
                {
                    // insert into opd.opd , register on PCU
                    // สิทธิ์ส่งเสริม มาเพื่อฉีดวัคซีนป้องกันโควิด
                    string ptClass = "07";

                    // ค่าไม่เปลี่ยน แสดงว่ามาจากการกรอกเลข 13 หลัก dt.Rows[0][2].ToString() คือชื่อนามสกุล
                    string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", pcucode, regdate, hn, "1", timereg, timereg, "TP1", cardroom, lbl_th_prefix.Text + lbl_th_firstname.Text + " " + lbl_th_lastname.Text, ptClass, "รับวัคซีนโควิด-19", "INV14", officerUsername, "PT2", "IN1", "TV1", sendscrroom, "153", regdate, yearAge, monthAge, dayAge, cardid);
                    DataAccess.ExecuteSQL(sqlInsertTo_OPD_OPD);

                    // select last queue
                    DataTable dtCheckQueue = new DataTable();
                    string sqlCheckQueue = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", regdate);
                    dtCheckQueue = DataAccess.RetriveData(sqlCheckQueue);
                    int queue = 0;
                    if (dtCheckQueue.Rows.Count > 0)
                    {
                        try
                        {
                            queue = 1 + Convert.ToInt32(dtCheckQueue.Rows[0][0].ToString());
                        }
                        catch
                        {
                            queue = 1;
                        }
                    }
                    else
                    {
                        queue = 1;
                    }

                    int frequency = 1;
                    string sqlInsertTo_OPD_OQUEUE_NEWCOMING = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", pcucode, regdate, hn, frequency, queue, cardroom, "001", sendscrroom, queue, regdate);
                    DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE_NEWCOMING);
                }
            }

            txtHN.Text = hn;
            txtHN.ReadOnly = true;

            PrintOldCase();
        }

        private void PrintOldCase()
        {
            string file = @"C:\Temp\config.txt";
            string[] strCon = File.ReadAllLines(file);
            model.Server = strCon[0];
            model.Userid = strCon[1];
            model.Password = strCon[2];
            con = new MySqlConnection($"Persist Security Info=False;server={model.Server};userid={model.Userid};password={model.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            // regdate
            string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            int printNumber = Convert.ToInt32(txtPrintNumber.Text);
            string sql = string.Format(@"SELECT pt.pt.hn, concat(pt.pt.pttitle, pt.pt.ptfname, ' ', pt.pt.ptlname) as NAME, replace(pt.pt.cardid, '-', '') as cardid, opd.oqueue.queue FROM pt.pt INNER JOIN opd.oqueue ON pt.pt.hn = opd.oqueue.hn WHERE pt.pt.HN = '{0}' AND opd.oqueue.regdate = '{1}' ORDER BY opd.oqueue.queue DESC LIMIT 1", txtHN.Text, regdate);
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, ds.Tables[0].TableName);
            XtraReport2 x = new XtraReport2();
            x.DataSource = ds;
            // ไม่ให้โชว์ คำว่า ( รับใหม่ )
            x.FindControl("xrNewCase", true).ForeColor = Color.White;
            x.PrinterName = cboPrinter.Text;
            for (int i = 1; i <= printNumber; i++)
            {
                x.Print();
            }
            DataAccess.UpdateHN_Hosdata_Docno();
        }

        private void PrintNewCase()
        {
            string file = @"C:\Temp\config.txt";
            string[] strCon = File.ReadAllLines(file);
            model.Server = strCon[0];
            model.Userid = strCon[1];
            model.Password = strCon[2];
            con = new MySqlConnection($"Persist Security Info=False;server={model.Server};userid={model.Userid};password={model.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            // regdate
            string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            int printNumber = Convert.ToInt32(txtPrintNumber.Text);
            string sql = string.Format(@"SELECT pt.pt.hn, concat(pt.pt.pttitle, pt.pt.ptfname, ' ', pt.pt.ptlname) as NAME, replace(pt.pt.cardid, '-', '') as cardid, opd.oqueue.queue FROM pt.pt INNER JOIN opd.oqueue ON pt.pt.hn = opd.oqueue.hn WHERE pt.pt.HN = '{0}' AND opd.oqueue.regdate = '{1}'", txtHN.Text, regdate);
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, ds.Tables[0].TableName);
            XtraReport2 x = new XtraReport2();
            x.DataSource = ds;
            x.PrinterName = cboPrinter.Text;
            for (int i = 1; i <= printNumber; i++)
            {
                x.Print();
            }
            DataAccess.UpdateHN_Hosdata_Docno();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            string file = @"C:\Temp\config.txt";
            string[] strCon = File.ReadAllLines(file);
            model.Server = strCon[0];
            model.Userid = strCon[1];
            model.Password = strCon[2];
            con = new MySqlConnection($"Persist Security Info=False;server={model.Server};userid={model.Userid};password={model.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            if (pbPictureFromDatabase.Image == null && pbPictureFromIDCard.Image == null)
            {
                return;
            }
            if (txtHN.Text == "")
            {
                return;
            }

            // regdate
            string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            int printNumber = Convert.ToInt32(txtPrintNumber.Text);
            string sql = string.Format(@"SELECT pt.pt.hn, concat(pt.pt.pttitle, pt.pt.ptfname, ' ', pt.pt.ptlname) as name, replace(pt.pt.cardid, '-', '') as cardid, opd.oqueue.queue FROM pt.pt INNER JOIN opd.oqueue ON pt.pt.hn = opd.oqueue.hn WHERE pt.pt.hn = '{0}' AND opd.oqueue.regdate = '{1}' ORDER BY opd.oqueue.queue DESC LIMIT 1", txtHN.Text, regdate);
            DataSet ds = new DataSet();
            da = new MySqlDataAdapter(sql, con);
            da.Fill(ds, ds.Tables[0].TableName);
            XtraReport2 x = new XtraReport2();
            x.DataSource = ds;
            // ไม่ให้โชว์ คำว่า ( รับใหม่ )
            x.FindControl("xrNewCase", true).ForeColor = Color.White;
            x.PrinterName = cboPrinter.Text;
            for (int i = 1; i <= printNumber; i++)
            {
                x.Print();
            }
        }

        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            //string sql = null;
            //DataTable dtFindHN = new DataTable();
            //// regdate
            //string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtHN.Text.Trim().Length == 1)
            //    {
            //        txtHN.Text = "000000" + txtHN.Text;
            //    }
            //    if (txtHN.Text.Trim().Length == 2)
            //    {
            //        txtHN.Text = "00000" + txtHN.Text;
            //    }
            //    if (txtHN.Text.Trim().Length == 3)
            //    {
            //        txtHN.Text = "0000" + txtHN.Text;
            //    }
            //    if (txtHN.Text.Trim().Length == 4)
            //    {
            //        txtHN.Text = "000" + txtHN.Text;
            //    }
            //    if (txtHN.Text.Trim().Length == 5)
            //    {
            //        txtHN.Text = "00" + txtHN.Text;
            //    }
            //    if (txtHN.Text.Trim().Length == 6)
            //    {
            //        txtHN.Text = "0" + txtHN.Text;
            //    }

            //    sql = string.Format(@"SELECT REPLACE(pt.pt.cardid, '-','') AS cid FROM pt.pt INNER JOIN opd.oqueue ON pt.pt.hn = opd.oqueue.hn WHERE pt.pt.hn = '{0}' AND opd.oqueue.regdate = '{1}' ORDER BY opd.oqueue.queue DESC LIMIT 1", txtHN.Text, regdate);
            //    dtFindHN = DataAccess.RetriveData(sql);
            //    if (dtFindHN.Rows.Count > 0)
            //    {
            //        if (File.Exists($"\\\\192.168.0.15\\ubuntu@15\\#3 Pictures\\PeopleImage\\{dtFindHN.Rows[0][0].ToString()}.jpg"))
            //        {
            //            pbPictureFromDatabase.Image = Image.FromFile($"\\\\192.168.0.15\\ubuntu@15\\#3 Pictures\\PeopleImage\\{dtFindHN.Rows[0][0].ToString()}.jpg");
            //        }
            //        else
            //        {
            //            pbPictureFromDatabase.Image = Image.FromFile($"\\\\192.168.0.15\\ubuntu@15\\#3 Pictures\\PeopleImage\\person.jpg");
            //        }

            //        btnBarcode.Visible = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show($"ไม่พบผู้ป่วย {txtHN.Text} ลงทะเบียนในวันนี้", "แจ้งทราบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //    btnBarcode.Visible = true;
            //}
        }

        // get printer
        private void GetPrinter()
        {
            cboPrinter.Items.Clear();
            // using System.Management;
            string query = string.Format(@"SELECT * from Win32_Printer");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection collection = searcher.Get();
            try
            {
                foreach (ManagementObject printer in collection)
                {
                    string printerName = printer.ToString().Substring(printer.ToString().LastIndexOf("=")).Replace("=", "").Replace("\"", "");
                    cboPrinter.Items.Add(printerName);
                    //foreach (PropertyData property in printer.Properties)
                    //{
                    //    //MessageBox.Show($"{property.Name}, {property.Value}, {property.Qualifiers}, {property.GetType()}");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cboPrinter.SelectedIndex = 0;
        }

        private void btnPrintMoreSticker_Click(object sender, EventArgs e)
        {
            txtHN.Enabled = true;
            txtHN.ReadOnly = false;
            txtHN.Focus();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // age "yyyy-MM-dd"
            //int yearAge = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(lbl_birthday.Text.Substring(0, 4));
            //int monthAge;
            //int monthNow = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("MM")));
            //int birthMonth = Convert.ToInt32(lbl_birthday.Text.Substring(5, 2));
            //if (birthMonth > monthNow)
            //{
            //    monthAge = -(-birthMonth + monthNow);
            //}
            //else
            //{
            //    monthAge = monthNow - birthMonth;
            //}
            //int dayAge;
            //int dayNow = Convert.ToInt32(Convert.ToInt32(DateTime.Now.ToString("dd")));
            //int birthDay = Convert.ToInt32(lbl_birthday.Text.Substring(8, 2));
            //if (birthDay < dayNow)
            //{
            //    dayAge = dayNow - birthDay;
            //}
            //else
            //{
            //    dayAge = -(birthDay - dayNow);
            //}

            pbPictureFromDatabase.Image = null;
            // save image
            //Bitmap bmp = new Bitmap(pbPictureFromIDCard.Image);
            //Image img = bmp;
            //img.Save(lbl_cid.Text + "jpg", ImageFormat.Jpeg);
            //FileInfo _img = new FileInfo(lbl_cid.Text + "jpg");
            //if (File.Exists(@"\\192.168.0.15\ubuntu@15\#3 Pictures\PeopleImage\" + lbl_cid.Text + ".jpg"))
            //{
            //    try
            //    {
            //        File.Delete(@"\\192.168.0.15\ubuntu@15\#3 Pictures\PeopleImage\" + lbl_cid.Text + ".jpg");
            //        _img.MoveTo(@"\\192.168.0.15\ubuntu@15\#3 Pictures\PeopleImage\" + lbl_cid.Text + ".jpg");
            //    }
            //    catch
            //    {
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        _img.MoveTo(@"\\192.168.0.15\ubuntu@15\#3 Pictures\PeopleImage\" + lbl_cid.Text + ".jpg");
            //    }
            //    catch
            //    {
            //    }
            //}

            DataTable dtMAX_HN = new DataTable();
            string sqlMAX_HN = "SELECT MAX(CAST(pt.pt.hn AS UNSIGNED INTEGER)) FROM pt.pt";
            dtMAX_HN = DataAccess.RetriveData(sqlMAX_HN);
            if (dtMAX_HN.Rows[0][0].ToString().Length == 5)
            {
                txtHN.Text = "00" + (Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                txtHN.ReadOnly = false;
            }
            if (dtMAX_HN.Rows[0][0].ToString().Length == 6)
            {
                txtHN.Text = "0" + (Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                txtHN.ReadOnly = false;
            }
            if (dtMAX_HN.Rows[0][0].ToString().Length == 7)
            {
                txtHN.Text = Convert.ToString(Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                txtHN.ReadOnly = false;
            }

            // regdate
            string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            // hn
            //string hn = "x" + txtHN.Text;
            string hn = txtHN.Text;
            //// cardid
            //string cardid = lbl_cid.Text.Insert(1, "-").Insert(6, "-").Insert(12, "-").Insert(15, "-");
            //// pttitle
            //string title = lbl_th_prefix.Text;
            //// ptfname
            //string firstName = lbl_th_firstname.Text;
            //// ptlname
            //string lastName = lbl_th_lastname.Text;

            // ptsex
            //string sex;
            //if (lbl_th_prefix.Text == "นาง" || lbl_th_prefix.Text == "นางสาว" || lbl_th_prefix.Text == "น.ส." || lbl_th_prefix.Text == "ด.ญ." || lbl_th_prefix.Text == "นางสาว")
            //{
            //    sex = "SX2";
            //}
            //else if (lbl_th_prefix.Text == "นาย" || lbl_th_prefix.Text == "สามเณร" || lbl_th_prefix.Text == "ด.ช." || lbl_th_prefix.Text == "พระ")
            //{
            //    sex = "SX1";
            //}
            //else
            //{
            //    sex = "SX1";
            //}

            // ptdob
            //string dateOfBirth = "";
            //if (lbl_birthday.Text.Contains("/"))
            //{
            //    string date = lbl_birthday.Text.Substring(0, 2);
            //    string month = lbl_birthday.Text.Substring(3, 2);
            //    int year = Convert.ToInt32(lbl_birthday.Text.Substring(6)) - 543;
            //    dateOfBirth = year.ToString() + "-" + month + "-" + date;
            //}
            //else
            //{
            //    int year = Convert.ToInt32(lbl_birthday.Text.Substring(0, 4)) - 543;
            //    dateOfBirth = year + Convert.ToDateTime(lbl_birthday.Text).ToString("yyyy-MM-dd").Substring(4);
            //}

            // ptdobtrust
            string ptdobtrust = "AGETY1";
            // married
            string married = "MA1";
            // ptnation
            string ptnation = "99";
            // ptrace
            string ptrace = "99";
            // religion
            string religion = "RL1";
            // ptaddress
            //string ptaddress = personal.addrHouseNo + " " + personal.addrVillageNo.Replace("ที่", "") + " " + personal.addrTambol.Replace("ตำบล", "") + " " + personal.addrAmphur.Replace("อำเภอ", "") + " " + personal.addrProvince.Replace("จังหวัด", "");
            //if (ptaddress == "")
            //{
            //    ptaddress = "";
            //}

            // cardroom
            string cardroom = "CARD1";
            // timereg
            string timereg = DateTime.Now.ToString("HH:mm:ss");
            // carduser, receive from who logged in
            string carduser = officerUsername;
            // user_update, receive from who logged in
            string user_update = officerUsername;
            // typeHn
            string typeHn = "HNTY1";
            // pcucode
            string pcucode = "28015";
            // send screen room
            string sendscrroom = "SCR8";

            // insert into pt.pt in new case
            string sqlInsertToPT = string.Format(@"INSERT INTO pt.pt (regdate, hn, cardid, pttitle, ptfname, ptlname, ptsex, ptdob, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, updatedate, date_update, lastvisitdate, carduser, user_update, typeHn, pcucode, sendscrroom) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}', '{19}', '{20}', '{21}', '{22}', '{23}')", regdate, hn, "0-0000-00000-00-0", "นาย", "ทดสอบ2", "ทดสอบ2", "SX1", "1986-03-08", ptdobtrust, married, ptnation, ptrace, religion, "176 ม.2 ต.สำโรง", cardroom, timereg, regdate, regdate, regdate, carduser, user_update, typeHn, pcucode, sendscrroom);
            DataAccess.ExecuteSQL(sqlInsertToPT);

            // insert into opd.opd , register on PCU
            // สิทธิ์ส่งเสริม มาเพื่อฉีดวัคซีนป้องกันโควิด
            string ptClass = "07";
            string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", pcucode, regdate, hn, "1", timereg, timereg, "TP1", cardroom, "นาย ทดสอบ2 ทดสอบ2", ptClass, "รับวัคซีนโควิด-19", "INV14", officerUsername, "PT2", "IN1", "TV1", sendscrroom, "153", regdate, 35, 5, 10, "0-0000-00000-00-0");
            DataAccess.ExecuteSQL(sqlInsertTo_OPD_OPD);
            txtHN.Text = hn;
            txtHN.ReadOnly = false;

            // insert into opd.oqueue
            // select last queue
            DataTable dtCheckQueue = new DataTable();
            string sqlCheckQueue = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", regdate);
            dtCheckQueue = DataAccess.RetriveData(sqlCheckQueue);
            int queue = 1 + Convert.ToInt32(dtCheckQueue.Rows[0][0].ToString());
            int frequency = 1;
            string sqlInsertTo_OPD_OQUEUE = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", pcucode, regdate, hn, frequency, queue, cardroom, "001", sendscrroom, queue, regdate);
            DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE);

            PrintNewCase();
        }

        private void btnTransferData_Click(object sender, EventArgs e)
        {
            frmVaccineTransferData f = new frmVaccineTransferData();
            f.ShowDialog();
        }

        private void btnTestPrint_Click(object sender, EventArgs e)
        {
            string file = @"C:\Temp\config.txt";
            string[] strCon = File.ReadAllLines(file);
            model.Server = strCon[0];
            model.Userid = strCon[1];
            model.Password = strCon[2];
            con = new MySqlConnection($"Persist Security Info=False;server={model.Server};userid={model.Userid};password={model.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            //if (pbPictureFromDatabase.Image == null && pbPictureFromIDCard.Image == null)
            //{
            //    return;
            //}
            //if (txtHN.Text == "")
            //{
            //    return;
            //}

            // regdate
            //string regdate = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy-MM-dd").Substring(0, 4)) - 543) + DateTime.Now.ToString("yyyy-MM-dd").Substring(4);
            int printNumber = Convert.ToInt32(txtPrintNumber.Text);
            //string sql = string.Format(@"SELECT pt.pt.hn, concat(pt.pt.pttitle, pt.pt.ptfname, ' ', pt.pt.ptlname) as name, replace(pt.pt.cardid, '-', '') as cardid, opd.oqueue.queue FROM pt.pt INNER JOIN opd.oqueue ON pt.pt.hn = opd.oqueue.hn WHERE pt.pt.hn = '{0}' AND opd.oqueue.regdate = '{1}' ORDER BY opd.oqueue.queue DESC LIMIT 1", txtHN.Text, regdate);
            //DataSet ds = new DataSet();
            //da = new MySqlDataAdapter(sql, con);
            //da.Fill(ds, ds.Tables[0].TableName);
            XtraReport2 x = new XtraReport2();
            //x.DataSource = ds;
            // ไม่ให้โชว์ คำว่า ( รับใหม่ )
            x.FindControl("xrNewCase", true).ForeColor = Color.White;
            x.PrinterName = cboPrinter.Text;
            for (int i = 1; i <= printNumber; i++)
            {
                x.Print();
            }
        }

        private void btnUpdateHN_Click(object sender, EventArgs e)
        {
            DataAccess.UpdateHN_Hosdata_Docno();
        }
    }
}