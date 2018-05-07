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
using Newtonsoft.Json.Linq;

namespace Mlem
{
    public partial class MainWindow : Office2007Form
    {
        Mlem mlem;
        private string[] LampsStr = new string[] { "Podłoga", "Czerwona", "Biala", "Niebieska" };
        private List<Event> heaterList;
        private List<Event> redLampList;
        private List<Event> blueLampList;


        public MainWindow()
        {
            InitializeComponent();

            CalendarInit();

            btnSend.Enabled = false;
            mlem = new Mlem("127.0.0.1", 50007);

            heaterList = new List<Event>()
            {
                new Event()
                {
                State = true,
                Time = new DateTime(2016, 3, 18, 16, 55, 20, DateTimeKind.Utc),
                },
                new Event()
                {
                State = false,
                Time = new DateTime(2016, 3, 18, 17, 0, 0, DateTimeKind.Utc),
                },
            };

            redLampList = new List<Event>()
            {
                new Event()
                {
                State = true,
                Time = new DateTime(2016, 3, 18, 1, 55, 20, DateTimeKind.Utc),
                },
                new Event()
                {
                State = false,
                Time = new DateTime(2016, 3, 18, 2, 0, 0, DateTimeKind.Utc),
                },
            };

            blueLampList = new List<Event>()
            {
                new Event()
                {
                State = true,
                Time = new DateTime(2016, 3, 18, 5, 55, 20, DateTimeKind.Utc),
                },
                new Event()
                {
                State = false,
                Time = new DateTime(2016, 3, 18, 8, 0, 0, DateTimeKind.Utc),
                },
            };
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
            try
            {
                ConcatAppointments();
                List<Event> heater = GetEventsFromTimeline(0);
                List<Lamp> lamps = new List<Lamp>();

                for (int i = 1; i < calendarView1.DisplayedOwners.Count; i++)
                {
                    string lampName = calendarView1.DisplayedOwners[i];
                    List<Event> events = GetEventsFromTimeline(i);
                    lamps.Add(new Lamp(lampName, events));
                }

                string output = JsonCreator.GetJson(heater, lamps);
                Console.WriteLine(output);
                //mlem.Send(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void cbShowPeriod_CheckedChanged(object sender, EventArgs e)
        {
            string template = "";
            if (((CheckBox)sender).Checked)
                template = "[StartTime] - [EndTime]";

            foreach(var app in calendarView1.CalendarModel.Appointments)
            {
                app.DisplayTemplate = template;
            }
        }

        private void calendarView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && calendarView1.SelectedAppointments.Count > 0)
            {
                AppointmentView view = calendarView1.SelectedAppointments[0];
                calendarView1.CalendarModel.Appointments.Remove(view.Appointment);
            }
        }
    }
}
