using BackOfficeApplication.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApplication.DataCenter
{
    public static class Authentication
    {
        // Model/ConnectionStringModel
        //private ConnectionStringModel model = new ConnectionStringModel();

        public static void CreateConnection()
        {
            try
            {
                if (File.Exists("C:\\Temp\\config.txt"))
                {
                }
                else
                {
                    string path = "C:\\Temp\\config.txt";
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("192.168.0.2");
                    sw.WriteLine("root");
                    sw.WriteLine("boom123");
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        private static void GetConnection()
        {
            string filename = "C:\\Temp\\config.txt";
            string[] lines = File.ReadAllLines(filename);
            ConnectionString.Server = lines[0];
            ConnectionString.Userid = lines[1];
            ConnectionString.Password = lines[2];
        }

        public static DataSet BdsHimproServer(string iSQL, string iRsName, string table/*, string srv, string user, string pass, string port*/)  // ทำให้เกิดที่ละตาราง
        {
            // get connection string from txt file
            GetConnection();

            MySqlConnection myConnection = new MySqlConnection($"Persist Security Info=False;server={ConnectionString.Server};userid={ConnectionString.Userid};password={ConnectionString.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            // MySqlConnection myConnection = new MySqlConnection("Persist Security Info=False;Database=hos;Data Source=127.0.0.1;User Id=nk;Password=nik1722;use procedure bodies=false; pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");

            myConnection.Open();   // เปิดใช้ Connecttion

            MySqlCommand mycom = new MySqlCommand();
            mycom.CommandType = CommandType.Text;
            mycom.CommandText = iSQL;
            mycom.Connection = myConnection;

            //        mycom.EndExecuteReader();

            MySqlDataAdapter adapter = new MySqlDataAdapter(mycom);

            DataSet ds = new DataSet();
            adapter.Fill(ds, iRsName);

            myConnection.Close();    // ปิด Connection
            myConnection.Dispose(); mycom.Dispose();
            myConnection = null; mycom = null;
            adapter.Dispose(); adapter = null;
            return ds;
        }
    }
}