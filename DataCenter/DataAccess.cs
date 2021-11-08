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
using System.Windows.Forms;

namespace BackOfficeApplication.DataCenter
{
    public static class DataAccess
    {
        //public static ConnectionStringModel model = new ConnectionStringModel();
        public static MySqlConnection con;

        public static void GetConnectionString()
        {
            try
            {
                string file = @"C:\Temp\config.txt";
                string[] strCon = File.ReadAllLines(file);
                ConnectionString.Server = strCon[0];
                ConnectionString.Userid = strCon[1];
                ConnectionString.Password = strCon[2];
                // con = new MySqlConnection($"Persist Security Info=False;server={ConnectionString.Server};userid={ConnectionString.Userid};password={ConnectionString.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            }
            catch
            {
            }
        }

        public static bool CheckConnection()
        {
            bool result = false;
            con = new MySqlConnection($"Persist Security Info=False;server={ConnectionString.Server};userid={ConnectionString.Userid};password={ConnectionString.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
            catch
            {
                result = false;
                return result;
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
                    con = new MySqlConnection($"Persist Security Info=False;server={ConnectionString.Server};userid={ConnectionString.Userid};password={ConnectionString.Password};pooling=false; charset=tis620;Allow User Variables=true;default command timeout=820;Max Pool Size=200;Allow User Variables=true;Allow Zero Datetime=true;");
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
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return con;
            }
            catch
            {
                con.Close();
                return con;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Execute Function
        /// </summary>
        /// <param name="sql"></param>
        public static void ExecuteSQL(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, ConnOpen());
                cmd.ExecuteNonQuery();
                ConnClose();
            }
            catch
            {
                ConnClose();
            }
            finally
            {
                ConnClose();
            }
        }

        /// <summary>
        /// Retrive All type of Data as DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable RetriveData(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, ConnOpen());
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
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

        public static DataTable ComboboxHelper(ComboBox cmb, string myColumn, string myChoice, string sql)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(myColumn);
            dt.Rows.Add(myChoice);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, ConnOpen());
            adapter.Fill(dt);
            return dt;
        }

        public static void UpdateHN_Hosdata_Docno()
        {
            DataTable dt = new DataTable();
            dt = DataAccess.RetriveData(@"SELECT MAX(CAST(pt.pt.hn AS UNSIGNED integer)) FROM pt.pt");
            string docNo_Year = DataAccess.RetriveData("SELECT SUBSTRING(NOW(),1,4) as year").Rows[0][0].ToString();
            string sql_Update_HOsdata_Docno_MaxHN = string.Format(@"UPDATE hosdata.docno SET hosdata.docno.no ='{0}' WHERE hosdata.docno.code = 'HN' AND hosdata.docno.year = '{1}'", Convert.ToInt32(dt.Rows[0][0].ToString()), docNo_Year);
            DataAccess.ExecuteSQL(sql_Update_HOsdata_Docno_MaxHN);
        }
    }
}