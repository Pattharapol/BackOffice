using BackOfficeApplication.DataCenter;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using HumanResource.DataCenter;
using HumanResource.UI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResource.zProject_ThaiNationalIDCard.UI
{
    public partial class frmVaccineTransferData : DevExpress.XtraEditors.XtraForm
    {
        private MySqlConnection localConn = new MySqlConnection("server=localhost;userid=root;password=;");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;

        private DataTable dtNewPT = new DataTable();

        private string date1 = "";
        private string date = "";

        private LocalDataAccess localDataAccess = new LocalDataAccess();
        private DataAccess dataAccess = new DataAccess();

        public frmVaccineTransferData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// select data from localhost
        /// </summary>
        private void newPT_FromLocalhost()
        {
            this.Invoke(new ThreadStart(delegate
            {
                date1 = dtpVaccineDate.Value.ToString("yyyy-MM-dd");
                date = (Convert.ToInt32(date1.Substring(0, 4)) - 543) + date1.Substring(4);
            }));
            Thread.Sleep(10);

            string sqlNewPT = string.Format(@"SELECT regdate, hn, cardid, pttitle, ptfname, ptlname, ptsex, ptdob, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, updatedate, date_update, lastvisitdate, carduser, user_update, typeHn, pcucode, sendscrroom FROM pt.pt WHERE pt.pt.regdate = '{0}'", date);
            dtNewPT = localDataAccess.RetrieveData(sqlNewPT);
            this.Invoke(new ThreadStart(delegate { dgvNewPT.DataSource = dtNewPT; })); Thread.Sleep(10);

            // yes there are new PT
            // then check if exist in center database
            if (dtNewPT != null && dtNewPT.Rows.Count > 0)
            {
                for (int i = 0; i < dgvNewPT.Rows.Count; i++)
                {
                    // report progress
                    bgwNewPT.ReportProgress(((i + 1) * 100) / dgvNewPT.Rows.Count);

                    // check from center database if PT exist
                    string sqlCheck_PT = string.Format(@"SELECT hn, cardid FROM pt.pt WHERE cardid = '{0}' ", dgvNewPT.Rows[i].Cells[2].Value.ToString());
                    DataTable dtCheckPT = new DataTable();
                    dtCheckPT = DataAccess.RetriveData(sqlCheck_PT);
                    // if exist
                    if (dtCheckPT.Rows.Count > 0)
                    {
                        // dummy
                        string update_Local_OPD_OPD_dummy = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", "09555" + i, dtCheckPT.Rows[0][1].ToString(), date);
                        localDataAccess.ExecuteSQL(update_Local_OPD_OPD_dummy);

                        // update local HN by select HN from 192.168.0.2 then update whole table in that day
                        string update_Local_OPD_OPD = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", dtCheckPT.Rows[0][0].ToString(), dtCheckPT.Rows[0][1].ToString(), date);
                        localDataAccess.ExecuteSQL(update_Local_OPD_OPD);
                    }
                    // insert into pt.pt for new PT
                    else
                    {
                        string hn = localDataAccess.MaxHN();

                        string sqlInsertToPT_PT = string.Format(@"INSERT INTO pt.pt (regdate, hn, cardid, pttitle, ptfname, ptlname, ptsex, ptdob, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, updatedate, date_update, lastvisitdate, carduser, user_update, typeHn, pcucode, sendscrroom) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}', '{19}', '{20}', '{21}', '{22}', '{23}')",
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[0].Value.ToString()).ToString("yyyy-MM-dd"),
                            hn, dgvNewPT.Rows[i].Cells[2].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[3].Value.ToString(), dgvNewPT.Rows[i].Cells[4].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[5].Value.ToString(), dgvNewPT.Rows[i].Cells[6].Value.ToString(),
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[7].Value.ToString()).ToString("yyyy-MM-dd"),
                            dgvNewPT.Rows[i].Cells[8].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[9].Value.ToString(), dgvNewPT.Rows[i].Cells[10].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[11].Value.ToString(), dgvNewPT.Rows[i].Cells[12].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[13].Value.ToString(), dgvNewPT.Rows[i].Cells[14].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[15].Value.ToString(),
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[16].Value.ToString()).ToString("yyyy-MM-dd"),
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[17].Value.ToString()).ToString("yyyy-MM-dd"),
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[17].Value.ToString()).ToString("yyyy-MM-dd"),
                            dgvNewPT.Rows[i].Cells[19].Value.ToString(), dgvNewPT.Rows[i].Cells[20].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[21].Value.ToString(), dgvNewPT.Rows[i].Cells[22].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[23].Value.ToString()
                            );

                        DataAccess.ExecuteSQL(sqlInsertToPT_PT);

                        try
                        {
                            // update new HN_dummy at opd.opd at localhost
                            // in case they will be that HN in system, catch will be appear in this method
                            // so i decided to update to dummy_HN, that is || "009000" + (i + 1) ||
                            string sql_Update_New_HN_dummy = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", "09000" + (i + 1), dgvNewPT.Rows[i].Cells[2].Value.ToString(), date);
                            localDataAccess.ExecuteSQL(sql_Update_New_HN_dummy);

                            // update new HN at opd.opd at localhost
                            string sql_Update_New_HN = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", hn, dgvNewPT.Rows[i].Cells[2].Value.ToString(), date);
                            localDataAccess.ExecuteSQL(sql_Update_New_HN);

                            DataAccess.UpdateHN_Hosdata_Docno();

                            // update hosdata.docno for keep last HN updating for original HIMPRO function for localhost
                            string docNo_Year1 = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy")) - 543);
                            string sql_Update_HOsdata_Docno_MaxHN1 = string.Format(@"UPDATE hosdata.docno SET hosdata.docno.no = hosdata.docno.no + 1 WHERE hosdata.docno.code = 'HN' AND hosdata.docno.year = '{0}'", docNo_Year1);
                            localDataAccess.ExecuteSQL(sql_Update_HOsdata_Docno_MaxHN1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            // If there is no new PT then go to TransferData Function

            // then select from localhost opd.opd
            //  string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid
            DataTable dtOPD_LOCAL = new DataTable();
            string sql_SELECT_FROM_OPD_LOCAL = string.Format(@"SELECT pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid FROM opd.opd WHERE opd.opd.regdate = '{0}'", date);
            dtOPD_LOCAL = localDataAccess.RetrieveData(sql_SELECT_FROM_OPD_LOCAL);

            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), true, true, false);

            this.Invoke(new ThreadStart(delegate
            {
                foreach (DataRow row in dtOPD_LOCAL.Rows)
                {
                    DataTable dtHN = new DataTable();
                    // select HN from 192.168.0.2 to update HN at localhost
                    string sql_SELECT_HN_FROM_HOST02 = string.Format(@"SELECT pt.pt.hn FROM pt.pt WHERE pt.pt.cardid = '{0}'", row["cardid"].ToString());
                    dtHN = DataAccess.RetriveData(sql_SELECT_HN_FROM_HOST02);

                    if (dtHN.Rows.Count > 0)
                    {
                        string sql_UPDATE_HN = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", dtHN.Rows[0][0].ToString(), row["cardid"].ToString(), date);
                        localDataAccess.ExecuteSQL(sql_UPDATE_HN);
                    }

                    //The Wait Form is opened in a separate thread.
                    //To change its Description, use the SetWaitFormDescription method.
                    SplashScreenManager.Default.SetWaitFormCaption("อัปเดท HN...");
                    SplashScreenManager.Default.SetWaitFormDescription("กำลังอัปเดท HN => " + dtHN.Rows[0][0].ToString());
                    Thread.Sleep(10);
                }
            }));

            // close wait form
            SplashScreenManager.CloseForm(false);

            // select from OPD localhost after UPDATE HN
            string sql_OPD_AFTER_UPDATE_HN = string.Format(@"SELECT pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid FROM opd.opd WHERE opd.opd.regdate = '{0}'", date);
            this.Invoke(new ThreadStart(delegate { dgvOPD_OPD.DataSource = null; }));
            this.Invoke(new ThreadStart(delegate { dgvOPD_OPD.DataSource = localDataAccess.RetrieveData(sql_OPD_AFTER_UPDATE_HN); }));
            this.Invoke(new ThreadStart(delegate { bgwOPD.RunWorkerAsync(); }));
        }

        private void DoWork_OPD_OPD()
        {
            for (int i = 0; i < dgvOPD_OPD.Rows.Count; i++)
            {
                bgwOPD.ReportProgress((i * 100) / dgvOPD_OPD.Rows.Count);

                // check if people came in that day
                DataTable dtCheck_OPD_OPD = new DataTable();
                string sql = string.Format(@"SELECT opd.opd.hn, opd.opd.frequency FROM opd.opd WHERE opd.opd.regdate = '{0}' AND opd.opd.hn = '{1}' AND opd.opd.cardid = '{2}'", date, dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[22].Value.ToString());
                dtCheck_OPD_OPD = DataAccess.RetriveData(sql);
                if (dtCheck_OPD_OPD.Rows.Count > 0)
                {
                    // people have come in that day
                    // insert to opd.opd at main server
                    // pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid
                    string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')",
                        "28015",
                        date,
                        dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(),
                        Convert.ToInt32(dgvOPD_OPD.Rows[i].Cells[3].Value.ToString()) + 1,
                        dgvOPD_OPD.Rows[i].Cells[4].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[5].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[6].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[7].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[8].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[9].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[10].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[11].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[12].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[13].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[14].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[15].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[16].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[17].Value.ToString(), date,
                        dgvOPD_OPD.Rows[i].Cells[19].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[20].Value.ToString(),
                        dgvOPD_OPD.Rows[i].Cells[21].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[22].Value.ToString());
                    DataAccess.ExecuteSQL(sqlInsertTo_OPD_OPD);

                    // select from opd.oqueue , coz we want frequency that people came
                    DataTable dtFrequency = new DataTable();
                    string sqlFrequency = string.Format(@"SELECT opd.oqueue.frequency FROM opd.oqueue WHERE opd.oqueue.hn = '{0}' AND opd.oqueue.regdate = '{1}'", dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(), date);
                    dtFrequency = DataAccess.RetriveData(sqlFrequency);
                    //int frequency = 1 + Convert.ToInt32(dtFrequency.Rows[0][0].ToString());
                    int frequency = 1;
                    try { frequency = 1 + Convert.ToInt32(dtFrequency.Rows[0][0].ToString()); } catch { frequency = 1; }

                    // select queue
                    DataTable dtQUEUE = new DataTable();
                    string sqlQUEUE = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", date);
                    dtQUEUE = DataAccess.RetriveData(sqlQUEUE);

                    try
                    {
                        // now we need necessary data for insert into opd.oqueue
                        string sqlInsertTo_OPD_OQUEUE_NEWCOMING = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", "28015", date, dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(), frequency, Convert.ToInt32(dtQUEUE.Rows[0][0].ToString()) + 1, "CARD1", "001", "SCR8", Convert.ToInt32(dtQUEUE.Rows[0][0].ToString()) + 1, date);
                        DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE_NEWCOMING);
                    }
                    catch { }
                }
                else
                {
                    //SELECT pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid

                    try
                    {
                        string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')",
                            "28015",
                            date,
                            dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(),
                            1,
                            dgvOPD_OPD.Rows[i].Cells[4].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[5].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[6].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[7].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[8].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[9].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[10].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[11].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[12].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[13].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[14].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[15].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[16].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[17].Value.ToString(), date,
                            dgvOPD_OPD.Rows[i].Cells[19].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[20].Value.ToString(),
                            dgvOPD_OPD.Rows[i].Cells[21].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[22].Value.ToString());
                        DataAccess.ExecuteSQL(sqlInsertTo_OPD_OPD);
                    }
                    catch { }

                    // select last queue
                    DataTable dtCheckQueue = new DataTable();
                    string sqlCheckQueue = string.Format(@"SELECT MAX(cast(opd.oqueue.queue AS UNSIGNED INTEGER)) AS queue FROM opd.oqueue WHERE opd.oqueue.regdate = '{0}'", date);
                    dtCheckQueue = DataAccess.RetriveData(sqlCheckQueue);
                    int queue = 1 + Convert.ToInt32(dtCheckQueue.Rows[0][0].ToString());
                    int frequency = 1;
                    try
                    {
                        string sqlInsertTo_OPD_OQUEUE_NEWCOMING = string.Format(@"INSERT INTO opd.oqueue (pcucode, regdate, hn, frequency, queue, regroom, status, sendscrroom, scrqueue, date_update) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", "28015", date, dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(), frequency, queue, "CARD1", "001", "SCR8", queue, date);
                        DataAccess.ExecuteSQL(sqlInsertTo_OPD_OQUEUE_NEWCOMING);
                    }
                    catch { }
                }
            }
        }

        private void btnDoWork_Click(object sender, EventArgs e)
        {
            bgwOPD.RunWorkerAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //newPT_FromLocalhost();
            bgwNewPT.RunWorkerAsync();
        }

        private void bgwNewPT_DoWork(object sender, DoWorkEventArgs e)
        {
            newPT_FromLocalhost();
        }

        private void bgwNewPT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbNewPT.Value = e.ProgressPercentage;
            lblNewPT.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bgwNewPT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbNewPT.Value = 0;
            lblNewPT.Text = "100%";
        }

        private void bgwOPD_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWork_OPD_OPD();
        }

        private void bgwOPD_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbOPD_OPD.Value = e.ProgressPercentage;
            lblOPD_OPD.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bgwOPD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbOPD_OPD.Value = 0;
            lblOPD_OPD.Text = "100%";
            this.BeginInvoke(new ThreadStart(delegate { DataAccess.UpdateHN_Hosdata_Docno(); }));
            this.BeginInvoke(new ThreadStart(delegate { localDataAccess.UpdateHN_Hosdata_Docno_Local(); }));
            this.BeginInvoke(new ThreadStart(delegate { MovePictures(); }));
        }

        private void frmVaccineTransferData_Load(object sender, EventArgs e)
        {
        }

        private void MovePictures()
        {
            string sourceFolder = @"C:\Temp\Pictures";
            string destinationFolder = @"\\192.168.0.15\ubuntu@15\#3 Pictures\PeopleImage";
            //string destinationFolder = @"C:\Temp\Pictures2";

            if (Directory.Exists(sourceFolder) && Directory.Exists(destinationFolder))
            {
                SplashScreenManager.ShowForm(this, typeof(FormProgressIndicator), true, true, false);
                foreach (var pic in new DirectoryInfo(sourceFolder).GetFiles())
                {
                    string picName = $@"{destinationFolder}\{pic.Name}";
                    if (File.Exists(picName))
                    {
                        File.Delete(picName);
                        pic.MoveTo($@"{destinationFolder}\{pic.Name}");
                    }
                    else
                    {
                        pic.MoveTo($@"{destinationFolder}\{pic.Name}");
                    }
                    //pic.MoveTo($@"{destinationFolder}\{pic.Name}");
                    //The Wait Form is opened in a separate thread.
                    //To change its Description, use the SetWaitFormDescription method.
                    SplashScreenManager.Default.SetWaitFormCaption("กรุณารอสักครู่...");
                    SplashScreenManager.Default.SetWaitFormDescription($"กำลังย้ายรูป => {pic.Name}");
                    Thread.Sleep(10);
                }
                SplashScreenManager.CloseForm();
                Thread.Sleep(10);
            }
            else
            {
                XtraMessageBox.Show($"ไม่พบ {sourceFolder} หรือ {destinationFolder} กรุณาติดต่อผู้ดูแลระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnTestMovePictures_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new ThreadStart(delegate { MovePictures(); }));
            this.BeginInvoke(new ThreadStart(delegate { DataAccess.UpdateHN_Hosdata_Docno(); }));
        }
    }
}