using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;

namespace FssDbExp
{
    public partial class MainGui : Form
    {
        public static OracleConnection oracleConnection;
        public static string DBName;
        public static PathMaster pathMaster;

        public MainGui()
        {
            InitializeComponent();
        }


        private void buttonTestConnect_Click(object sender, EventArgs e)
        {
            OracleProvider oracleProvider = new OracleProvider();
            string conString = oracleProvider.BuildConnectionString(comboBoxTNSname.SelectedValue.ToString(), textBoxUser.Text, textBoxPass.Text);
            OracleConnection oracConnection = oracleProvider.GetConnection(conString);

            if (oracConnection != null)
            {
                oracleConnection = oracConnection;
                DBName = textBoxUser.Text;
                labelTestConnect.Text = "SUCCESS!";
                labelTestConnect.ForeColor = Color.Green;
            }
            else
            {
                labelTestConnect.Text = "FAIL!";
                labelTestConnect.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                textBoxRootDir.Text = path;
            }
        }

        private void MainGui_Load(object sender, EventArgs e)
        {
            //progressBarExpDt.Increment(10);
            if (comboBoxDirType.SelectedIndex == 1)
            {
                checkBoxBDS.Enabled = false;
                checkBoxHost.Enabled = false;
            }
            comboBoxDirType.SelectedIndex = 0;
            string tnsContent = TNS_Parser.getTnsFileContent("tnsnames.ora");
            List<TNSModel> list = TNS_Parser.listConnectionStr(TNS_Parser.getListTnsName(tnsContent), tnsContent);

            comboBoxTNSname.DataSource = list;
            comboBoxTNSname.DisplayMember = "TnsName";
            comboBoxTNSname.ValueMember = "DataSource";
            textBoxRootDir.Text = Environment.SystemDirectory.ToString();
        }

        private void buttonExpData_Click(object sender, EventArgs e)
        {
            OracleProvider oracleProvider = new OracleProvider();
            string conString = oracleProvider.BuildConnectionString(comboBoxTNSname.SelectedValue.ToString(), textBoxUser.Text, textBoxPass.Text);
            OracleConnection oracConnection = oracleProvider.GetConnection(conString);

            if (oracleConnection != null)
            {
                oracleConnection = oracConnection;
                DBName = textBoxUser.Text;
            }

            if (oracleConnection != null && oracleConnection.State == ConnectionState.Open)
            {
                // get list view
                List<string> listViewName = getListObject("VIEW");
                // get list trigger
                List<string> listTriggerName = getListObject("TRIGGER");
                // get list procedure
                List<string> listProcedureName = getListObject("PROCEDURE");
                // get list function
                List<string> listFunctionName = getListObject("FUNCTION");
                // get list package
                List<string> listPackageName = getListObject("PACKAGE");
                // get list type
                List<string> listType = getListObject("TYPE");

                progressBarExpDt.Maximum = listViewName.Count + listTriggerName.Count +
                                            listProcedureName.Count + listFunctionName.Count + 
                                            + listPackageName.Count + listType.Count;
                progressBarExpDt.Step = 1;

                // gen view
                genObject(listViewName, "VIEW", progressBarExpDt);
                // gen trigger
                genObject(listTriggerName, "TRIGGER", progressBarExpDt);
                // gen procedure
                genObject(listProcedureName, "PROCEDURE", progressBarExpDt);
                // gen function 
                genObject(listFunctionName, "FUNCTION", progressBarExpDt);
                // gen package
                genObject(listPackageName, "PACKAGE", progressBarExpDt);
                // gen type
                genObject(listType, "TYPE", progressBarExpDt);
            }
            oracleConnection.Close();
            oracleConnection.Dispose();

            MessageBox.Show("Export data completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCreateDir_Click(object sender, EventArgs ev)
        {
            try
            {
                if (comboBoxDirType.SelectedItem.ToString() == "FlexDB" && textBoxVersionName.Text.Trim().Length > 0
               && checkBoxBDS.Checked == false && checkBoxHost.Checked == false)
                {
                    MessageBox.Show("Please choose DB type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PathMaster pMaster = new PathMaster(textBoxVersionName.Text, checkBoxBDS.Checked, checkBoxHost.Checked, comboBoxDirType.SelectedItem.ToString(), textBoxRootDir.Text);
                foreach (string temp in pMaster.ListPath)
                {
                    if (!Directory.Exists(temp))
                    {
                        Directory.CreateDirectory(temp);
                    }
                }
                labelMkDir.Text = "Done!";
                pathMaster = pMaster;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxDirType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxDirType.SelectedIndex == 1)
            {
                checkBoxBDS.Enabled = false;
                checkBoxHost.Enabled = false;
            }
            if(comboBoxDirType.SelectedIndex == 0)
            {
                checkBoxBDS.Enabled = true;
                checkBoxHost.Enabled = true;
            }
        }

        private List<string> getListObject(string objName)
        {
            try
            {
                List<string> listObjName = new List<string>();
                string orcCommand = "select OBJECT_NAME from dba_objects where owner = :mOwner and OBJECT_TYPE = '" + objName + "'";
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = orcCommand;
                oracleCommand.Parameters.Add(new OracleParameter("mOwner", DBName));

                OracleDataReader oracleDataReader = OracleProvider.GetOracleDataReader(oracleCommand, oracleConnection);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        listObjName.Add(oracleDataReader.GetString(0));
                    }
                }

                return listObjName;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string getScriptObj(string objName, string objType)
        {
            try
            {
                string script = "";
                string orcCommand = "select dbms_metadata.get_ddl('" + objType + "', '" + objName + "', '" + DBName + "') from dual";
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = orcCommand;
                OracleDataReader oracleDataReader = OracleProvider.GetOracleDataReader(oracleCommand, oracleConnection);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
                    script = oracleDataReader.GetString(0);
                    return script;
                }

                return script;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void genObject(List<string> listObjName, string objType, ProgressBar progressBar)
        {
            try
            {
                // gen object
                foreach (string objName in listObjName)
                {
                    string script = getScriptObj(objName, objType);
                    string path = getPath(objType, objName);
                    File.WriteAllText(path, script, Encoding.UTF8);
                    progressBar.PerformStep();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getPath(string objType, string objName)
        {
            string path = "";

            if(objType == "VIEW")
            {
                path = pathMaster.ListPath[6];
                path += "\\" + objName + ".sql";
            }

            if (objType.Equals("TRIGGER"))
            {
                path = pathMaster.ListPath[11];
                path += "\\" + objName + ".sql";
            }

            if (objType.Equals("PROCEDURE"))
            {
                path = pathMaster.ListPath[8];
                path += "\\" + objName + ".sql";
            }

            if (objType.Equals("FUNCTION"))
            {
                path = pathMaster.ListPath[9];
                path += "\\" + objName + ".sql";
            }

            if (objType.Equals("PACKAGE"))
            {
                path = pathMaster.ListPath[10];
                path += "\\" + objName + ".sql";
            }

            if (objType.Equals("TYPE"))
            {
                path = pathMaster.ListPath[12];
                path += "\\" + objName + ".sql";
            }

            return path;
        }
    }
}
