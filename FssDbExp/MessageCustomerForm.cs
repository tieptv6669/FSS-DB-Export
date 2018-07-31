using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FssDbExp
{
    public partial class MessageCustomerForm : Form
    {
        public MessageCustomerForm(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
