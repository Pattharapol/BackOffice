using BackOfficeApplication.DataCenter;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public frmVaccineTransferData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// select data from localhost
        /// </summary>
        private void newPT_FromLocalhost()
        {
            string date1 = dtpVaccineDate.Value.ToString("yyyy-MM-dd");
            string date = (Convert.ToInt32(date1.Substring(0, 4)) - 543) + date1.Substring(4);
            string sqlNewPT = string.Format(@"SELECT regdate, hn, cardid, pttitle, ptfname, ptlname, ptsex, ptdob, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, updatedate, date_update, lastvisitdate, carduser, user_update, typeHn, pcucode, sendscrroom FROM pt.pt WHERE pt.pt.regdate = '{0}'", date);
            da = new MySqlDataAdapter(sqlNewPT, localConn);
            da.Fill(dtNewPT);
            dgvNewPT.DataSource = dtNewPT;
            // yes there are new PT
            // then check if exist in center database
            if (dtNewPT != null && dtNewPT.Rows.Count > 0)
            {
                
                for (int i = 0; i < dgvNewPT.Rows.Count-1; i++)
                {
                    int percent = (i * 100) / dgvNewPT.Rows.Count;
                    bgwNewPT.ReportProgress(percent);

                    // check from center database if PT exist
                    string sqlCheck_PT = string.Format(@"SELECT hn, cardid FROM pt.pt WHERE cardid = '{0}' ", dgvNewPT.Rows[i].Cells[2].Value.ToString());
                    DataTable dtCheckPT = new DataTable();
                    dtCheckPT = DataAccess.RetriveData(sqlCheck_PT);
                    // if exist
                    if (dtCheckPT.Rows.Count > 0)
                    {
                        // dummy
                        string update_Local_OPD_OPD_dummy = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", "009555"+i, dtCheckPT.Rows[0][1].ToString(), date);
                        cmd = new MySqlCommand(update_Local_OPD_OPD_dummy, localConn);
                        localConn.Open();
                        cmd.ExecuteNonQuery();
                        localConn.Close();

                        string update_Local_OPD_OPD = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", dtCheckPT.Rows[0][0].ToString(), dtCheckPT.Rows[0][1].ToString(), date);
                        cmd = new MySqlCommand(update_Local_OPD_OPD, localConn);
                        localConn.Open();
                        cmd.ExecuteNonQuery();
                        localConn.Close();
                    }
                    // insert into pt.pt for new PT
                    else
                    {
                        string hn = "";
                        DataTable dtMAX_HN = new DataTable();
                        string sqlMAX_HN = "SELECT MAX(CAST(pt.pt.hn AS UNSIGNED INTEGER)) FROM pt.pt";
                        dtMAX_HN = DataAccess.RetriveData(sqlMAX_HN);
                        if (dtMAX_HN.Rows[0][0].ToString().Length == 5)
                        {
                            hn = "00" + (Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                        }
                        if (dtMAX_HN.Rows[0][0].ToString().Length == 6)
                        {
                            hn = "0" + (Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                        }
                        if (dtMAX_HN.Rows[0][0].ToString().Length == 7)
                        {
                            hn = Convert.ToString(Convert.ToInt32(dtMAX_HN.Rows[0][0].ToString()) + 1);
                        }

                        

                        string sqlInsertToPT_PT = string.Format(@"INSERT INTO pt.pt (regdate, hn, cardid, pttitle, ptfname, ptlname, ptsex, ptdob, ptdobtrust, married, ptnation, ptrace, religion, ptaddress, cardroom, timereg, updatedate, date_update, lastvisitdate, carduser, user_update, typeHn, pcucode, sendscrroom) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}', '{19}', '{20}', '{21}', '{22}', '{23}')", Convert.ToDateTime(dgvNewPT.Rows[i].Cells[0].Value.ToString()).ToString("yyyy-MM-dd"),
                            hn, dgvNewPT.Rows[i].Cells[2].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[3].Value.ToString(), dgvNewPT.Rows[i].Cells[4].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[5].Value.ToString(), dgvNewPT.Rows[i].Cells[6].Value.ToString(),
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[7].Value.ToString()).ToString("yyyy-MM-dd"), dgvNewPT.Rows[i].Cells[8].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[9].Value.ToString(), dgvNewPT.Rows[i].Cells[10].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[11].Value.ToString(), dgvNewPT.Rows[i].Cells[12].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[13].Value.ToString(), dgvNewPT.Rows[i].Cells[14].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[15].Value.ToString(), Convert.ToDateTime(dgvNewPT.Rows[i].Cells[16].Value.ToString()).ToString("yyyy-MM-dd"),
                            Convert.ToDateTime(dgvNewPT.Rows[i].Cells[17].Value.ToString()).ToString("yyyy-MM-dd"), Convert.ToDateTime(dgvNewPT.Rows[i].Cells[17].Value.ToString()).ToString("yyyy-MM-dd"),
                            dgvNewPT.Rows[i].Cells[19].Value.ToString(), dgvNewPT.Rows[i].Cells[20].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[21].Value.ToString(), dgvNewPT.Rows[i].Cells[22].Value.ToString(),
                            dgvNewPT.Rows[i].Cells[23].Value.ToString()
                            );

                        DataAccess.ExecuteSQL(sqlInsertToPT_PT);

                        try
                        {
                            // update new HN at opd.opd at localhost
                            string sql_Update_New_HN_dummy = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", "009000" + (i+1), dgvNewPT.Rows[i].Cells[2].Value.ToString(), date);
                            cmd = new MySqlCommand(sql_Update_New_HN_dummy, localConn);
                            localConn.Open();
                            cmd.ExecuteNonQuery();
                            localConn.Close();

                            string sql_Update_New_HN = string.Format(@"UPDATE opd.opd SET opd.opd.hn = '{0}' WHERE opd.opd.cardid = '{1}' AND opd.opd.regdate = '{2}'", hn, dgvNewPT.Rows[i].Cells[2].Value.ToString(), date);
                            cmd = new MySqlCommand(sql_Update_New_HN, localConn);
                            localConn.Open();
                            cmd.ExecuteNonQuery();
                            localConn.Close();

                            // update hosdata.docno for keep last HN updating for original HIMPRO function
                            string docNo_Year = Convert.ToString(Convert.ToInt32(DateTime.Now.ToString("yyyy")) - 543);
                            string sql_Update_HOsdata_Docno_MaxHN = string.Format(@"UPDATE hosdata.docno SET hosdata.docno.no = hosdata.docno.no + 1 WHERE hosdata.docno.code = 'HN' AND hosdata.docno.year = '{0}'", docNo_Year);
                            DataAccess.ExecuteSQL(sql_Update_HOsdata_Docno_MaxHN);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                       
                    }
                }

                // then select from localhost opd.opd
                //  string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid
                DataTable dtOPD_LOCAL = new DataTable();
                string sql_SELECT_FROM_OPD_LOCAL = string.Format(@"SELECT pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid FROM opd.opd WHERE opd.opd.regdate = '{0}'", date);
                da = new MySqlDataAdapter(sql_SELECT_FROM_OPD_LOCAL, localConn);
                da.Fill(dtOPD_LOCAL);
                if (dtOPD_LOCAL.Rows.Count > 0)
                {
                    dgvOPD_OPD.DataSource = dtOPD_LOCAL;
                }
                else
                {
                }
            }
            else
            {
                // If there is no new PT then go to TransferData Function
            }
        }

        private void DoWork_OPD_OPD()
        {
            string date1 = dtpVaccineDate.Value.ToString("yyyy-MM-dd");
            string date = (Convert.ToInt32(date1.Substring(0, 4)) - 543) + date1.Substring(4);

            for (int i = 0; i < dgvOPD_OPD.Rows.Count-1; i++)
            {
                bgwOPD.ReportProgress((i * 100) / dgvOPD_OPD.Rows.Count);

                // check if people came in that day
                DataTable dtCheck_OPD_OPD = new DataTable();
                string sql = string.Format(@"SELECT opd.opd.hn, opd.opd.frequency FROM opd.opd WHERE opd.opd.regdate = '{0}' AND opd.opd.hn = '{1}'", date, dgvOPD_OPD.Rows[i].Cells[2].Value.ToString());
                dtCheck_OPD_OPD = DataAccess.RetriveData(sql);
                if (dtCheck_OPD_OPD.Rows.Count > 0)
                {
                    // people have come in that day
                    // insert to opd.opd
                    //string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", "28015", date, dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(dtCheck_OPD_OPD.Rows[0][1].ToString()) + 1,
                    //    dgvOPD_OPD.Rows[i].Cells[4].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[5].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[6].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[7].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[8].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[9].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[10].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[11].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[12].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[13].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[14].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[15].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[16].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[17].Value.ToString(), date,
                    //    dgvOPD_OPD.Rows[i].Cells[19].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[20].Value.ToString(),
                    //    dgvOPD_OPD.Rows[i].Cells[21].Value.ToString(), dgvOPD_OPD.Rows[i].Cells[22].Value.ToString());
                    //DataAccess.ExecuteSQL(sqlInsertTo_OPD_OPD);

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
                    catch
                    {

                    }
                }
                else
                {
                    //SELECT pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid

                    try
                    {
                        string sqlInsertTo_OPD_OPD = string.Format(@"INSERT INTO opd.opd (pcucode, regdate, hn, frequency, timestart, timereg, regperiod, regroom, fullname, ptclass, sign, scrroom, reguser, oldnew, comein, typevisit, sendScrRoom, clinic, date_update, yage, mage, dage, cardid) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", "28015", date, dgvOPD_OPD.Rows[i].Cells[2].Value.ToString(), 1, dgvOPD_OPD.Rows[i].Cells[4].Value.ToString(),
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
                    catch 
                    {

                    }

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
                    catch
                    {

                    }
                }
            }
        }

        private void btnDoWork_Click(object sender, EventArgs e)
        {
            bgwOPD.RunWorkerAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            newPT_FromLocalhost();
            //bgwNewPT.RunWorkerAsync();
        }

        private void bgwNewPT_DoWork(object sender, DoWorkEventArgs e)
        {
            //newPT_FromLocalhost();
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
        }

        private void frmVaccineTransferData_Load(object sender, EventArgs e)
        {

        }
    }
}