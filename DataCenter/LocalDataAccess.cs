using BackOfficeApplication.DataCenter;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.DataCenter
{
    public class LocalDataAccess
    {
        private MySqlConnection localConn = new MySqlConnection("server=localhost;userid=root;password=;");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;

        public DataTable RetrieveData(string sql)
        {
            DataTable dt = new DataTable();
            da = new MySqlDataAdapter(sql, localConn);
            da.Fill(dt);
            return dt;
        }

        public void ExecuteSQL(string sql)
        {
            localConn.Open();
            cmd = new MySqlCommand(sql, localConn);
            cmd.ExecuteNonQuery();
            localConn.Close();
        }

        public string MaxHN()
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

            return hn;
        }

        public void UpdateHN_Hosdata_Docno_Local()
        {
            LocalDataAccess localDataAccess = new LocalDataAccess();
            DataTable dt = new DataTable();
            dt = localDataAccess.RetrieveData(@"SELECT MAX(CAST(pt.pt.hn AS UNSIGNED integer)) FROM pt.pt");
            string docNo_Year = DataAccess.RetriveData("SELECT SUBSTRING(NOW(),1,4) as year").Rows[0][0].ToString();
            string sql_Update_HOsdata_Docno_MaxHN = string.Format(@"UPDATE hosdata.docno SET hosdata.docno.no ='{0}' WHERE hosdata.docno.code = 'HN' AND hosdata.docno.year = '{1}'", Convert.ToInt32(dt.Rows[0][0].ToString()), docNo_Year);
            localDataAccess.ExecuteSQL(sql_Update_HOsdata_Docno_MaxHN);
        }
    }
}