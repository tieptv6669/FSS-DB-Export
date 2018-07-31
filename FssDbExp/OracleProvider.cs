using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace FssDbExp
{
    public class OracleProvider
    {
        // Properties
        public string User { get; set; }
        public string Pass { get; set; }

        public OracleProvider() { }

        /// <summary>
        /// Build connection string
        /// </summary>
        /// <param name="oracleProvider"></param>
        /// <returns></returns>
        public string BuildConnectionString(string dataSource, string user, string pass)
        {
            try
            {
                string conString = "Data Source = " + dataSource;
                OracleConnectionStringBuilder oracleConnectionStringBuilder = new OracleConnectionStringBuilder();
                oracleConnectionStringBuilder.ConnectionString = conString;
                oracleConnectionStringBuilder.UserID = user;
                oracleConnectionStringBuilder.Password = pass;

                return oracleConnectionStringBuilder.ToString();
            }
            catch(Exception e)
            {
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get connection
        /// </summary>
        /// <param name="conStr"></param>
        /// <returns></returns>
        public OracleConnection GetConnection(string conStr)
        {
            OracleConnection oracleConnection = new OracleConnection(conStr);
            if (oracleConnection.State != System.Data.ConnectionState.Open)
            {
                oracleConnection.Open();
            }
            return oracleConnection;
        }

        /// <summary>
        /// Thực thi câu lệnh truy vấn
        /// </summary>
        /// <param name="oracleCmd"></param>
        /// <returns></returns>
        public static OracleDataReader GetOracleDataReader(OracleCommand oracleCmd, OracleConnection oracleConnection)
        {
            OracleDataReader oracleDataReader;
            oracleCmd.Connection = oracleConnection;
            oracleDataReader = oracleCmd.ExecuteReader();

            return oracleDataReader;
        }

        public static string GenScriptInsert(string tableName, List<string> headerName, List<string> values)
        {
            for(int index = 0; index < values.Count; index++)
            {
                if (values[index].Contains("'"))
                {
                    values[index] = values[index].Replace("'", "''");
                }
            }

            string script = "INSERT INTO " + tableName + " (";

            for (int index = 0; index < headerName.Count - 1; index++)
            {
                script += headerName[index];
                script += ",";
            }
            script += headerName[headerName.Count - 1];
            script += ")\n VALUES (";

            for(int index = 0; index < values.Count - 1; index++)
            {
                if(values[index] != "null")
                {
                    script += "'";
                    script += values[index];
                    script += "',";
                }
                else
                {
                    script += values[index];
                    script += ",";
                }
            }
            if (values[values.Count - 1] != "null")
            {
                script += "'";
                script += values[values.Count - 1];
                script += "');\n";
            }
            else
            {
                script += values[values.Count - 1];
                script += ");\n";
            }
            return script;
        }
    }
}
