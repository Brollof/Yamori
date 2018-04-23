using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mlem;

namespace Mlem
{
    public partial class MainWindow : Form
    {
        Mlem mlem;

        public MainWindow()
        {
            InitializeComponent();
            btnSend.Enabled = false;
            mlem = new Mlem("127.0.0.1", 50007);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mlem.IsConnected)
            {
                butConn.Text = "Connect";
                mlem.Close();
                btnSend.Enabled = false;
            }
            else
            {
                if (mlem.Connect())
                {
                    butConn.Text = "Disconnect";
                    btnSend.Enabled = true;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            mlem.Send("Hello :)");
            mlem.Receive();
        }
    }
}
