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
using System.Diagnostics;

namespace Mlem
{
    public partial class MainWindow : Office2007Form
    {
        private Mlem mlem;

        public MainWindow()
        {
            InitializeComponent();

            LampPickerInit(GetUiLampsNum());
            CalendarInit(GetUiLampsNum() + 1, GetUiMaxLampsNum() + 1);
            InitHeaterRow("Kabel", eCalendarColor.Steel);
            LampManager.OnLampNamesValidationStatusChanged += LampManager_OnLampNamesValidationStatusChanged;
            mlem = new Mlem("127.0.0.1", 50007);
        }

        void LampManager_OnLampNamesValidationStatusChanged(ValidationEventArgs args)
        {
            btnSend.Enabled = args.IsValid;
            btnLimits.Enabled = args.IsValid;
        }

        private int GetUiLampsNum()
        {
            return Convert.ToInt32(ddLampNum.Text);
        }

        private int GetUiMaxLampsNum()
        {
            return Convert.ToInt32(ddLampNum.Items[ddLampNum.Items.Count - 1]);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //mlem.Send("Hello :)");
            //mlem.Receive();

            if (mlem.Connect())
            {
                SendJsonData();
                mlem.Close();
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

        private void cbLampsNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int lampsNum = GetUiLampsNum();
                ShowLampPicker(lampsNum);
                UpdateTimelineRows(lampsNum + 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void InitHeaterRow(string name, eCalendarColor color)
        {
            calendarView1.DisplayedOwners[0] = name;
            calendarView1.MultiCalendarTimeLineViews[0].CalendarColor = color;
        }

        private void SendJsonData()
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

                string output = JsonCreator.GetJson(heater, lamps, LampManager.GetLampsConfig());
                Console.WriteLine(output);
                mlem.Send(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (mlem.Connect())
            {
                Console.WriteLine("Read config");
                mlem.Send("read command");
                mlem.Receive();
                mlem.Close();
            }
        }

        private List<LimitTempView> views = null;
        private void btnLimits_Click(object sender, EventArgs e)
        {
            List<string> names = LampManager.GetNames();

            List<LimitTempModel> models = LimitTempModel.Create(names);
            views = LimitTempView.Create(models);

            LimitWindow window = new LimitWindow(views);
            window.FormClosing += window_FormClosing;
            window.ShowDialog();
        }

        void window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(views[0].TxtTime.Text);
            int minutes = views[0].Model.Time;
            Console.WriteLine(minutes);
        }
    }
}
