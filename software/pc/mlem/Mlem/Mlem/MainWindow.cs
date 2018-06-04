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
        private Link link;

        public MainWindow()
        {
            InitializeComponent();

            LampPickerInit(GetUiLampsNum());
            CalendarInit(GetUiLampsNum() + 1, GetUiMaxLampsNum() + 1);
            InitHeaterRow("Kabel", eCalendarColor.Steel);
            LampManager.OnLampNamesValidationStatusChanged += LampManager_OnLampNamesValidationStatusChanged;
            link = new Link("127.0.0.1", 50007);
        }

        void LampManager_OnLampNamesValidationStatusChanged(ValidationEventArgs args)
        {
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

            if (link.Connect())
            {
                SendJsonData();
                link.Close();
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

        private string GetHeaterName()
        {
            return calendarView1.DisplayedOwners[0];
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

                string output = JsonCreator.GetJson(
                    heater,
                    lamps,
                    LampManager.GetLampsConfig(),
                    minTempLimit,
                    maxTempLimit,
                    views.ConvertAll(view => view.Model));

                link.Send(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (link.Connect())
            {
                Console.WriteLine("Read config");
                link.Send("read command");
                link.Receive();
                link.Close();
            }
        }

        private List<LimitTempView> views = null;
        private int minTempLimit = 0;
        private int maxTempLimit = 0;

        private void btnLimits_Click(object sender, EventArgs e)
        {
            List<string> names = LampManager.GetNames();
            names.Insert(0, GetHeaterName());

            List<LimitTempModel> models = (views == null) ?
                LimitTempModel.Create(names) :
                 LimitTempModel.Create(names, views.ConvertAll(view => view.Model));

            views = LimitTempView.Create(models);

            LimitWindow window = new LimitWindow(views, minTempLimit, maxTempLimit);
            window.FormClosing += window_FormClosing;
            window.ShowDialog();
        }

        void window_FormClosing(object sender, FormClosingEventArgs e)
        {
            LimitWindow window = (LimitWindow)sender;

            if (window.IsValid)
            {
                btnSend.Enabled = true;
                minTempLimit = window.GetTemp(LimitWindow.TempType.MIN);
                maxTempLimit = window.GetTemp(LimitWindow.TempType.MAX);
            }
        }
    }
}
