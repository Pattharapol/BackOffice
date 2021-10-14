using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApplication.DataCenter
{
    public static class MSAccessDataAccess
    {
        // Read data from MS Access
        //private static string connectionStringMSAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Temp\att2000.mdb";
        private static string connectionStringMSAccess = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Temp\att2000.mdb";

        public static DataTable RetrieveCheckIN_FromMSAccess(string type)
        {
            // เลือกเอาเฉพาะปีนั้นๆ แต่เลือกเดือนไม่ได้ ไม่รู้ทำไม
            string presentYear = DateTime.Now.ToString("yyyy");
            string presentMonth = DateTime.Now.ToString("MM");
            string lastMonth = Convert.ToString(Convert.ToInt32(presentMonth) - 1);
            if (lastMonth.Length == 1)
            {
                lastMonth = "0" + lastMonth;
            }

            string lastYear = Convert.ToString(Convert.ToInt32(presentYear) - 1);

            DataTable dt = new DataTable();
            string sql = "";

            using (OleDbConnection connection = new OleDbConnection(connectionStringMSAccess))
            {
                if (type == "ทั้งปีงบประมาณ")
                {
                    // เอาไว้ประมวลผลรายปี
                    sql = ("SELECT USERID, CHECKTIME, CHECKTYPE FROM CHECKINOUT " +
                        "WHERE (CHECKTIME LIKE '%" + presentYear + "%' " +
                        "OR CHECKTIME LIKE '%" + "10/" + lastYear + "%' " +
                        "OR CHECKTIME LIKE '%" + "11/" + lastYear + "%' " +
                        "OR CHECKTIME LIKE '%" + "12/" + lastYear + "%') AND CHECKTYPE = 'I' ");
                }
                else
                {
                    // เอาไว้ประมวลผลรายเดือน
                    if (presentMonth == "01")
                    {
                        sql = ("SELECT USERID, CHECKTIME, CHECKTYPE FROM CHECKINOUT WHERE CHECKTIME LIKE '%" + "12/" + lastYear + "%' AND CHECKTYPE = 'I' ");
                    }
                    else
                    {
                        sql = ("SELECT USERID, CHECKTIME, CHECKTYPE FROM CHECKINOUT WHERE CHECKTIME LIKE '%" + lastMonth + "/" + presentYear + "%' AND CHECKTYPE = 'I' ");
                    }
                }

                try
                {
                    OleDbDataAdapter oda = new OleDbDataAdapter(sql, connection);
                    connection.Open();
                    oda.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return dt;
                // The connection is automatically closed because of using block.
            }
        }

        public static DataTable RetrieveDataFromMSAccess(string sql)
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(connectionStringMSAccess))
            {
                OleDbDataAdapter oda = new OleDbDataAdapter(sql, connection);
                try
                {
                    connection.Open();
                    oda.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return dt;
                // The connection is automatically closed because of using block.
            }
        }
    }
}