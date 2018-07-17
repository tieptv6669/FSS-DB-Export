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

namespace FssDbExp
{
    public partial class MainGui : Form
    {
        public MainGui()
        {
            InitializeComponent();
        }


        private void buttonTestConnect_Click(object sender, EventArgs e)
        {
            OracleProvider oracleProvider = new OracleProvider();
            oracleProvider.Host = textBoxHost.Text;
            oracleProvider.Port = textBoxPort.Text;
            oracleProvider.Service_name = textBoxSerName.Text;
            oracleProvider.User = textBoxUser.Text;
            oracleProvider.Pass = textBoxPass.Text;

            textBoxResultTestConnect.ForeColor = Color.White;

            string conString = oracleProvider.BuildConnectionString(oracleProvider);
            OracleConnection oracleConnection = oracleProvider.GetConnection(conString);

            if (oracleConnection != null)
            {
                textBoxResultTestConnect.BackColor = Color.LightGreen;
                textBoxResultTestConnect.Text = "SUCCESS";
            }
            else
            {
                textBoxResultTestConnect.BackColor = Color.Red;
                textBoxResultTestConnect.Text = "FAIL";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {

                path = file.FileName;
                textBoxRootDir.ForeColor = Color.Red;
                textBoxRootDir.Text = path;
            }
        }

        private void MainGui_Load(object sender, EventArgs e)
        {
            comboBoxDirType.SelectedIndex = 0;
        }
    }
}
