using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using DevComponents.DotNetBar.Schedule;
using DevComponents.DotNetBar;
using DevComponents.Schedule.Model;

namespace Mlem
{
    public partial class MainWindow : Office2007Form
    {
        Mlem mlem;
        private string[] LampsStr = new string[] { "Niebieska-L", "Czerwona", "Biala", "Niebieska-P" };

        public MainWindow()
        {
            InitializeComponent();

            CalendarInit();
  
            

            
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

        private void btnJson_Click(object sender, EventArgs e)
        {
            var data = new RootJson()
            {
                //Lamp = new IO()
                //{
                //    State = true,
                //    Time = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                //},
                Heater = new IO()
                {
                    State = false,
                    Time = new DateTime(2016, 3, 18, 16, 55, 20, DateTimeKind.Utc),
                }
            };
            var output = JsonConvert.SerializeObject(data);
            // mlem.Send(output);
        }
    }
}
