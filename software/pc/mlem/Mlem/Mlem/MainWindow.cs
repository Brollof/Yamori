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
using Mlem.Device;
using Mlem.Device.DeviceViewModel;

namespace Mlem
{
    public partial class MainWindow : Office2007Form
    {
        private Link link;
        private Version v = new Version(1, 0);
        int[] SLOTS = { 1, 2, 3, 4, 5, 6, 7, 8 };
        bool OFFLINE = true;

        public MainWindow()
        {
            InitializeComponent();
            this.Text = "Mlem " + v.ToString();

            InitDeviceTypePicker();
            InitDeviceColorPicker();
            InitDeviceSlotPicker();
            CalendarInit(SLOTS.Length);
            link = new Link("127.0.0.1", 50007);
        }

        private void InitDeviceTypePicker()
        {
            foreach (DeviceType val in typeof(DeviceType).GetEnumValues())
            {
                string desc = DeviceManager.GetDescription(val);
                ddDeviceType.Items.Add(desc);
            }
            ddDeviceType.SelectedIndex = 0;
        }

        private void InitDeviceColorPicker()
        {
            cddDeviceColor.FillWithColors(CalendarUtils.Colors);
        }

        private void InitDeviceSlotPicker()
        {
            foreach (var slot in SLOTS)
                ddDeviceSlot.Items.Add(slot.ToString());
            ddDeviceSlot.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //mlem.Send("Hello :)");
            //mlem.Receive();
            if (OFFLINE)
                SendJsonData();
            else
            {
                if (link.Connect())
                {
                    SendJsonData();
                    link.Close();
                }
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

        private string sentData = null;

        private void SendJsonData()
        {
            try
            {
                ConcatAppointments();
                List<DeviceConfig> devConfs = new List<DeviceConfig>();
                List<DeviceModel> devices = DeviceManager.Devices;

                for (int i = 0; i < devices.Count; i++)
                {
                    DeviceConfig config = new DeviceConfig(devices[i].Name);
                    Color color = CalendarUtils.ConvertColor(devices[i].Color);
                    config.Color = new RGB(color.R, color.G, color.B);
                    config.Events = GetEventsFromTimeline(i);
                    config.Slot = devices[i].Slot;
                    config.Type = devices[i].Type.ToString();
                    devConfs.Add(config);
                }

                string output = JsonCreator.GetJson(
                    devConfs,
                    minTempLimit,
                    maxTempLimit,
                    views.ConvertAll(view => view.Model));
                if (OFFLINE)
                    sentData = output;
                else
                    link.Send(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private string json = @"{ 'Devices': { 'Niebieska': { 'Events': [ { 'State': true, 'Time': '2018-06-20T01:00:00' }, { 'State': false, 'Time': '2018-06-20T03:00:00' } ], 'Slot': 1, 'Color': { 'R': 93, 'G': 140, 'B': 201 }, 'Type': 'LAMP' }, 'Czerwona': { 'Events': [ { 'State': true, 'Time': '2018-06-20T00:00:00' } ], 'Slot': 2, 'Color': { 'R': 193, 'G': 105, 'B': 105 }, 'Type': 'LAMP' }, 'Zielona': { 'Events': [ { 'State': true, 'Time': '2018-06-20T00:30:00' }, { 'State': false, 'Time': '2018-06-20T02:30:00' }, { 'State': true, 'Time': '2018-06-20T05:00:00' }, { 'State': false, 'Time': '2018-06-20T07:00:00' }, { 'State': true, 'Time': '2018-06-20T10:00:00' }, { 'State': false, 'Time': '2018-06-20T10:30:00' } ], 'Slot': 3, 'Color': { 'R': 114, 'G': 164, 'B': 90 }, 'Type': 'LAMP' }, 'Zolta': { 'Events': [ { 'State': false, 'Time': '2018-06-20T00:30:00' }, { 'State': true, 'Time': '2018-06-20T21:00:00' }, { 'State': false, 'Time': '2018-06-20T21:01:00' }, { 'State': true, 'Time': '2018-06-20T23:00:00' } ], 'Slot': 4, 'Color': { 'R': 255, 'G': 209, 'B': 81 }, 'Type': 'LAMP' }, 'kabel': { 'Events': [], 'Slot': 5, 'Color': { 'R': 97, 'G': 106, 'B': 118 }, 'Type': 'CABLE' } }, 'Config': { 'Limits': { 'Events': [ { 'Selected': true, 'Time': 20, 'Name': 'Niebieska' } ], 'Min': 30, 'Max': 40 } }, 'Initialized': true}";
        private void btnRead_Click(object sender, EventArgs e)
        {
            if (OFFLINE)
            {
                Console.WriteLine("offline read");
                try
                {
                    var data = JObject.Parse(json);
                    var devices = data["Devices"].ToObject<Dictionary<string, JObject>>();
                    var config = data["Config"];

                    foreach (var entry in devices)
                    {
                        string devName = entry.Key;
                        DeviceType devType = (DeviceType)Enum.Parse(typeof(DeviceType), (string)entry.Value["Type"]);
                        RGB rgb = entry.Value["Color"].ToObject<RGB>();
                        eCalendarColor color = CalendarUtils.ConvertColor(rgb);
                        int slot = (int)entry.Value["Slot"];
                        List<Event> events = new List<Event>();
                        foreach (var evData in entry.Value["Events"])
                        {
                            Event ev = evData.ToObject<Event>();
                            events.Add(ev);
                        }

                        DeviceManager.AddDevice(devName, devType, slot, color);
                        devName += getSlotFormat(slot);
                        TimelineAddNewRow(devName, color);
                    }

                    ///////////////////////////////////////////////////////
                    minTempLimit = (int)config["Limits"]["Min"];
                    maxTempLimit = (int)config["Limits"]["Max"];

                    List<LimitTempView> _views = new List<LimitTempView>();
                    foreach (var limit in config["Limits"]["Events"])
                    {
                        LimitTempModel model = limit.ToObject<LimitTempModel>();
                        _views.Add(new LimitTempView(model));
                    }

                    views = _views;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                if (link.Connect())
                {
                    Console.WriteLine("Read config");
                    link.Send("read command");
                    link.Receive();
                    link.Close();
                }
            }
        }

        private List<LimitTempView> views = null;
        private int minTempLimit = 0;
        private int maxTempLimit = 0;

        private void btnLimits_Click(object sender, EventArgs e)
        {
            List<string> names = DeviceManager.GetNames();

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

        private string getSlotFormat(int slot)
        {
            return "[" + slot.ToString() + "]";
        }

        private string removeSlotFormat(string s)
        {
            return s.Remove(s.Length - 3, 3);
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeviceManager.Devices.Count >= 8)
                    return;

                string devName = txtDeviceName.Text;
                if (string.IsNullOrEmpty(devName))
                    return;

                if (!DeviceManager.CanAdd(devName))
                {
                    MessageBox.Show("Urządzenie o podanej nazwie już istnieje",
                        "Niepoprawna nazwa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                DeviceType type = (DeviceType)ddDeviceType.SelectedIndex;
                eCalendarColor color;
                int slot = Convert.ToInt32(ddDeviceSlot.Text);

                if (DeviceManager.HasColor(type))
                    color = CalendarUtils.CalendarColorFromString(cddDeviceColor.SelectedItem.ToString());
                else
                    color = DeviceManager.GetDefaultColor(type);

                DeviceManager.AddDevice(devName, type, slot, color);
                devName += getSlotFormat(slot);
                TimelineAddNewRow(devName, color);
                txtDeviceName.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ddDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox dd = (ComboBox)sender;
            DeviceType type = (DeviceType)dd.SelectedIndex;
            bool show = DeviceManager.HasColor(type);
            cddDeviceColor.Visible = show;
            labDeviceColor.Visible = show;
        }

        void calendarView1_DisplayedOwnersChanged(object sender, EventArgs e)
        {
            if (calendarView1.DisplayedOwners.Count > 0)
            {
                calendarView1.Visible = true;
                btnLimits.Enabled = true;
            }
            else
            {
                calendarView1.Visible = false;
                btnLimits.Enabled = false;
                btnSend.Enabled = false;
            }

            // remove all
            foreach (var slot in SLOTS)
                ddDeviceSlot.Items.Remove(slot.ToString());

            // add all
            foreach (var slot in SLOTS)
                ddDeviceSlot.Items.Add(slot.ToString());

            // remove used
            foreach (var dev in DeviceManager.Devices)
                ddDeviceSlot.Items.Remove(dev.Slot.ToString());

            if (ddDeviceSlot.Items.Count > 0)
                ddDeviceSlot.SelectedIndex = 0;
        }
    }
}
