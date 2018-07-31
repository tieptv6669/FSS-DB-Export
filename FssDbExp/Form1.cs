using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Threading;

namespace FssDbExp
{
    public partial class MainGui : Form
    {
        public static OracleConnection oracleConnection;
        public static string DBName;
        public static PathMaster pathMaster;
        public static string schemaName;

        public MainGui()
        {
            InitializeComponent();
        }

        private void buttonTestConnect_Click(object sender, EventArgs ev)
        {
            try
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
                    char x = '"';
                    schemaName = x + textBoxUser.Text + x + ".";
                }
                else
                {
                    labelTestConnect.Text = "FAIL!";
                    labelTestConnect.ForeColor = Color.Red;
                }
            }
            catch(Exception e)
            {
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
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

        private void buttonExpData_Click(object sender, EventArgs ev)
        {
            if(MessageBox.Show("The process take many times, Are you sure you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                    try
                    {
                    OracleProvider oracleProvider = new OracleProvider();
                    string conString = oracleProvider.BuildConnectionString(comboBoxTNSname.SelectedValue.ToString(), textBoxUser.Text, textBoxPass.Text);
                    OracleConnection oracConnection = oracleProvider.GetConnection(conString);

                    if (oracleConnection != null)
                    {
                        oracleConnection = oracConnection;
                        DBName = textBoxUser.Text;
                    }

                    progressBarExpDt.Maximum = 0;

                    if (checkBoxExpObj.Checked)
                    {
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

                            progressBarExpDt.Maximum += listViewName.Count + listTriggerName.Count +
                                                        listProcedureName.Count + listFunctionName.Count +
                                                        +listPackageName.Count + listType.Count;
                            progressBarExpDt.Step = 1;
                            // gen view
                            genObject(listViewName, "VIEW", progressBarExpDt);
                            //gen trigger
                            genObject(listTriggerName, "TRIGGER", progressBarExpDt);
                            // gen procedure
                            genObject(listProcedureName, "PROCEDURE", progressBarExpDt);
                            // gen function 
                            genObject(listFunctionName, "FUNCTION", progressBarExpDt);
                            // gen package
                            genObject(listPackageName, "PACKAGE", progressBarExpDt);
                            // gen type
                            genObject(listType, "TYPE", progressBarExpDt);

                            progressBarExpDt.Value = 0;
                        }
                    }

                    if (checkBoxExpTbl.Checked)
                    {
                        string[] lsTable = getListTableNameFromFile();
                        int progressSize = 0;
                        for (int index = 0; index < lsTable.Length; index++)
                        {
                            string[] tbl = lsTable[index].Split('_');
                            List<string> listObjKeyName = GenScript.getListObjKeyName(tbl[0], tbl[1], oracleConnection);
                            progressSize += listObjKeyName.Count;
                        }
                        progressSize += GenScript.getListObjKeyName("tltx", "tltxcd", oracleConnection).Count;
                        progressBarExpDt.Maximum = progressSize;
                   
                        for (int index = 0; index < lsTable.Length; index++)
                        {
                            string[] tbl = lsTable[index].Split('_');
                            string tblName = tbl[0].ToLower();

                            if (tblName != "tltx" && tblName != "fldmaster" && tblName != "fldval"
                                && tblName != "appchk" && tblName != "appmap")
                            {
                                GenScript.GenInsertCommand(tbl[0], tbl[1], oracConnection, pathMaster.ListPath, progressBarExpDt);
                            }
                        }
                        GenScript.GenInsertCommandForTransTable(oracConnection, pathMaster.ListPath, progressBarExpDt);
                    }
                    MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    Logger.ShowMsg(e.Message);
                    Logger.Logging(e.Message, DateTime.Now.ToString());
                }

                progressBarExpDt.Value = 0;
                oracleConnection.Close();
                oracleConnection.Dispose();
            }
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
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
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

                //int x = oracleDataReader.FieldCount;
                //string y = oracleDataReader.GetName(0);
                //string z =  oracleDataReader.GetDataTypeName(0);

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
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
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
                    if (objType == "TRIGGER")
                    {
                        int index = script.IndexOf("ALTER TRIGGER");
                        script = script.Substring(0, index);
                    }
                    return script;
                }
                
                return script;
            }
            catch(Exception e)
            {
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
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
                    script = script.Replace(schemaName, "");
                    script = GenScript.StringStandardMaster(script);
                    string path = getPath(objType, objName);
                    File.WriteAllText(path, script, Encoding.UTF8);
                    progressBar.PerformStep();
                }
            }
            catch(Exception e)
            {
                Logger.ShowMsg(e.Message);
                Logger.Logging(e.Message, DateTime.Now.ToString());
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
                path = pathMaster.ListPath[7];
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
                path = pathMaster.ListPath[11];
                path += "\\" + objName + ".sql";
            }

            return path;
        }

        private string[] getListTableNameFromFile()
        {
            string[] lines = { };
            if(comboBoxDirType.SelectedItem.ToString() == "FlexDB")
            {
                lines = File.ReadAllLines("lsTable.txt");
            }
            if(comboBoxDirType.SelectedItem.ToString() == "FDSFlexDB")
            {
                lines = File.ReadAllLines("lsTableFDS.txt");
            }
            for (int index = 0; index < lines.Length; index++)
            {
                lines[index] = lines[index].ToUpper();
            }
            return lines;
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            labelTestConnect.Text = "";
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            labelTestConnect.Text = "";
        }
   }
}
