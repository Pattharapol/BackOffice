using BackOfficeApplication.HumanResource.Report;
using BackOfficeApplication.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApplication.DataCenter
{
    public class DataAccess
    {
        public static MySqlConnection con;
        public static ConnectionStringModel conString = new ConnectionStringModel();

        private static void GetConnectionString()
        {
            try
            {
                string file = @"C:\Temp\config.txt";
                string[] strCon = File.ReadAllLines(file);
                conString.server = strCon[0];
                conString.userid = strCon[1];
                conString.password = strCon[2];
            }
            catch
            {
            }
        }

        public static void CreateConnection()
        {
            try
            {
                string path = "C:\\Temp\\config.txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("192.168.0.2");
                sw.WriteLine("root");
                sw.WriteLine("boom123");
                sw.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Open the Connection
        /// </summary>
        /// <returns></returns>
        private static MySqlConnection ConnOpen()
        {
            try
            {
                GetConnectionString();
                if (con == null)
                {
                    con = new MySqlConnection(
                        "Persist Security Info=False; " +
                        "server='" + conString.server + "';" +
                        " userid='" + conString.userid + "'; " +
                        "password='" + conString.password + "';" +
                        "pooling=false; charset=tis620;" +
                        "Allow User Variables=true;" +
                        "default command timeout=820;" +
                        "Max Pool Size=200;" +
                        "Allow User Variables=true;" +
                        "Allow Zero Datetime=true;");
                }

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch
            {
                return con;
            }
        }

        /// <summary>
        /// Close the Connection
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection ConnClose()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }

        /// <summary>
        /// Execute Function
        /// </summary>
        /// <param name="sql"></param>
        public static void ExecuteSQL(string sql)
        {
            GetConnectionString();
            con = new MySqlConnection(
                        "Persist Security Info=False; " +
                        "server='" + conString.server + "';" +
                        "userid='" + conString.userid + "';" +
                        "password='" + conString.password + "';" +
                        "pooling=false; charset=tis620;" +
                        "Allow User Variables=true;" +
                        "default command timeout=820;" +
                        "Max Pool Size=200;" +
                        "Allow User Variables=true;" +
                        "Allow Zero Datetime=true;");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ConnClose();
        }

        /// <summary>
        /// Retrive All type of Data as DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable RetriveData(string sql)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, ConnOpen());
            da.Fill(dt);
            ConnClose();
            return dt;
        }

        /// <summary>
        /// Retrive DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet FillDataSetForReport(DataSet ds, string dsTable, string sql)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sql, ConnOpen());

            da.Fill(ds, ds.Tables[0].TableName);
            ConnClose();

            return ds;
        }

        public static string EncyptPassword(string password, SymmetricAlgorithm key)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, key.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(password);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            return (Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
        }

        /// <summary>
        /// Sucerity key
        /// </summary>
        private const string SecurityKey = "ronaldoR9";

        public static string _EncryptPassword(string pass)
        {
            // Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(pass);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));

            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}