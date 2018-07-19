using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace FssDbExp
{
    public class GenScript
    {
        public static void GenInsertCommand(string tableName, string keyColumn, OracleConnection oracleConnection, List<string> listPath, ProgressBar progressBar)
        {
            List<string> listObjKeyName = getListObjKeyName(tableName, keyColumn, oracleConnection);
            foreach (string str in listObjKeyName)
            {
                string result = "";
                string sqlCommand = "select * from tblName where keyCol = 'objKeyName'";
                sqlCommand = sqlCommand.Replace("keyCol", keyColumn).Replace("tblName", tableName).Replace("objKeyName", str);
                OracleCommand oracleCommand = new OracleCommand(sqlCommand);
                OracleDataReader oracleDataReader = OracleProvider.GetOracleDataReader(oracleCommand, oracleConnection);

                List<string> headerName = new List<string>();
                for (int index = 0; index < oracleDataReader.FieldCount; index++)
                {
                    headerName.Add(oracleDataReader.GetName(index));
                }

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        List<string> values = new List<string>();
                        for (int index = 0; index < oracleDataReader.FieldCount; index++)
                        {
                            values.Add(oracleDataReader.GetOracleValue(index).ToString());
                        }
                        result += OracleProvider.GenScriptInsert(tableName, headerName, values);
                    }
                }

                string path = getPath(listPath, tableName, str);
                File.WriteAllText(path, result, Encoding.UTF8);
                progressBar.PerformStep();
            }
        }

        public static List<string> getListObjKeyName(string tableName, string keyColumn, OracleConnection oracleConnection)
        {
            List<string> result = new List<string>();
            string sqlCommand = "select distinct keyCol from tblName";
            sqlCommand = sqlCommand.Replace("keyCol", keyColumn).Replace("tblName", tableName);
            OracleCommand oracleCommand = new OracleCommand(sqlCommand);
            OracleDataReader oracleDataReader = OracleProvider.GetOracleDataReader(oracleCommand, oracleConnection);

            if(oracleDataReader != null && oracleDataReader.HasRows)
            {
                while (oracleDataReader.Read())
                {
                    result.Add(oracleDataReader.GetOracleValue(0).ToString());
                }
            }

            return result;
        }

        public static string getPath(List<string> listPath, string tableName, string keyObjName)
        {
            string path = "";
            foreach(string str in listPath)
            {
                if (str.Contains(tableName))
                {
                    path = str + "\\" + tableName + "_" + keyObjName + ".sql";
                    return path;
                }
            }

            return path;
        }
    }
}
