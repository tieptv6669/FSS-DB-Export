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
                int indexHost = conString.IndexOf("HOST = ") + "HOST = ".Length;
                conString = conString.Insert(indexHost, oracleProvider.Host);
                int indexPort = conString.IndexOf("PORT = ") + "PORT = ".Length;
                conString = conString.Insert(indexPort, oracleProvider.Port);
                int indexServiceName = conString.IndexOf("SERVICE_NAME = ") + "SERVICE_NAME = ".Length;
                conString = conString.Insert(indexServiceName, oracleProvider.Service_name);

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
