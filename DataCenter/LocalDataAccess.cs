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
    }
}