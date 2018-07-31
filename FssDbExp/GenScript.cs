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
            try
            {
                List<string> listObjKeyName = getListObjKeyName(tableName, keyColumn, oracleConnection);
                foreach (string str in listObjKeyName)
                {
                    string result = "DELETE FROM tblName WHERE kCol = 'okName'; \n";
                    result = result.Replace("tblName", tableName).Replace("kCol", keyColumn).Replace("okName", str);
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
                    result += "COMMIT;\n";

                    string path = getPath(listPath, tableName, str);
                    File.WriteAllText(path, result, Encoding.UTF8);
                    progressBar.PerformStep();
                }
            }
            catch(Exception e)
            {
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
            }
        }

        public static List<string> getListObjKeyName(string tableName, string keyColumn, OracleConnection oracleConnection)
        {
            List<string> result = new List<string>();
            try
            {
                string sqlCommand = "select distinct keyCol from tblName";
                sqlCommand = sqlCommand.Replace("keyCol", keyColumn).Replace("tblName", tableName);
                OracleCommand oracleCommand = new OracleCommand(sqlCommand);
                OracleDataReader oracleDataReader = OracleProvider.GetOracleDataReader(oracleCommand, oracleConnection);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        result.Add(oracleDataReader.GetOracleValue(0).ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Logger.ShowMsg(e.Message);
                string msg_log = e.Message;
                if(e.Message == "ORA-00942: table or view does not exist")
                {
                    msg_log += " " + tableName;
                }
                Logger.Logging(msg_log, DateTime.Now.ToString());
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

        public static void GenInsertCommandForTransTable(OracleConnection oracleConnection, List<string> listPath, ProgressBar progressBar)
        {
            string path = "";
            foreach(string str in listPath)
            {
                if (str.Contains("TRANS"))
                {
                    path = str;
                    break;
                }
            }

            try
            {
                List<string> listTblTran = new List<string>();
                listTblTran.Add("tltx".ToLower());
                listTblTran.Add("fldmaster".ToLower());
                listTblTran.Add("fldval".ToLower());
                listTblTran.Add("appchk".ToLower());
                listTblTran.Add("appmap".ToLower());

                List<string> listObjKeyName = getListObjKeyName("tltx", "tltxcd", oracleConnection);

                foreach(string str in listObjKeyName)
                {
                    string result = "";
                    foreach(string tblName in listTblTran)
                    {
                        result += "DELETE FROM tblName WHERE kCol = 'okName'; \n";
                        result = result.Replace("tblName", tblName).Replace("okName", str);
                        if (tblName == "tltx" || tblName == "appchk" || tblName == "appmap")
                        {
                            result = result.Replace("kCol", "tltxcd");
                        }
                        else
                        {
                            result = result.Replace("kCol", "objname");
                        }

                        string sqlCommand = "select * from tblName where keyCol = 'objKeyName'";
                        if (tblName == "tltx" || tblName == "appchk" || tblName == "appmap")
                        {
                            sqlCommand = sqlCommand.Replace("keyCol", "tltxcd");
                        }
                        else
                        {
                            sqlCommand = sqlCommand.Replace("keyCol", "objname");
                        }
                        sqlCommand = sqlCommand.Replace("tblName", tblName).Replace("objKeyName", str);
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
                                result += OracleProvider.GenScriptInsert(tblName, headerName, values);
                            }
                        }
                        result += "COMMIT;\n";
                    }

                    string pathTemp = path + "\\TRANS_" + str + ".sql";
                    File.WriteAllText(pathTemp, result, Encoding.UTF8);
                    progressBar.PerformStep();
                }
            }catch(Exception e)
            {
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
            }
        }

        public static string StringStandardMaster(string strTemp)
        {
            string str = strTemp;
            int index;
            while(str[0] == '\n')
            {
                    str = str.Remove(0, 1);
            }
            str = str.Trim();
            index = str.IndexOf("\n");
            str = str.Insert(index + 1, "\n");
            if(str[str.Length - 1] != ';')
            {
                str += ';';
            }
            str += '\n';
            str += '/';

            return str;
        }
    }
}
