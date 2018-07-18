using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Windows.Forms;

namespace FssDbExp
{
    public class OracleProvider
    {
        // Attributes
        private string host;
        private string port;
        private string service_name;
        private string user;
        private string pass;

        // Properties
        public string Host { get; set; }
        public string Port { get; set; }
        public string Service_name { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }

        public OracleProvider() { }

        /// <summary>
        /// Build connection string
        /// </summary>
        /// <param name="oracleProvider"></param>
        /// <returns></returns>
        public string BuildConnectionString(OracleProvider oracleProvider)
        {
            try
            {
                string conString = "";
                conString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;
                conString = conString.Replace("_H_", oracleProvider.Host);
                conString = conString.Replace("_P_", oracleProvider.Port);
                conString = conString.Replace("_SN_", oracleProvider.Service_name);

                OracleConnectionStringBuilder oracleConnectionStringBuilder = new OracleConnectionStringBuilder();
                oracleConnectionStringBuilder.ConnectionString = conString;
                oracleConnectionStringBuilder.UserID = oracleProvider.User;
                oracleConnectionStringBuilder.Password = oracleProvider.Pass;

                return oracleConnectionStringBuilder.ToString();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        /// <summary>
        /// Get connection
        /// </summary>
        /// <param name="conStr"></param>
        /// <returns></returns>
        public OracleConnection GetConnection(string conStr)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(conStr);
                if (oracleConnection.State != System.Data.ConnectionState.Open)
                {
                    oracleConnection.Open();
                }
                return oracleConnection;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
