using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeApplication.DataCenter
{
    public static class CommonCOde
    {
        public static void CreateExceptionTextFile(string errorMessage, string fromForm)
        {
            string path = @"c:\temp\error.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(errorMessage + " at " + fromForm);
                    sw.Close();
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(errorMessage + " at " + fromForm);
                sw.Close();
            }
        }

        public static string getUSERID_fromUSERNAME(string userName)
        {
            return DataAccess.RetriveData(string.Format(@"SELECT id FROM human_resource.userinfo WHERE NAME = '{0}'", userName)).Rows[0][0].ToString();
        }

        public static string getDepartmentByUserName(string userName)
        {
            return DataAccess.RetriveData(string.Format(@"SELECT dept.dept_name FROM human_resource.departments AS dept INNER JOIN human_resource.userinfo AS usr ON dept.dept_id = usr.DEPTID WHERE usr.NAME = '{0}'", userName)).Rows[0][0].ToString();
        }
    }
}