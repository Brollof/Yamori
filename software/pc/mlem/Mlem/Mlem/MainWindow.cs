﻿using System;
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

            // Set our Calendar Model
            CalendarModel model = new CalendarModel();

            // Assign model to the CalendarView so view has data to display
            calendarView1.CalendarModel = model;

            // And add our base set of users
            calendarView1.DisplayedOwners.AddRange(LampsStr);

            // Add some sample appointments
            // deleted! AddSampleAppointments();

            calendarView1.TimeLineShowIntervalHeader = true; // musi byc...
            calendarView1.TimeLineShowPeriodHeader = false; // calkiem u gory gowno
            calendarView1.IsTimeRulerVisible = true; // podzialka
            calendarView1.TimeLineShowPageNavigation = false; // to gowno na dole
            calendarView1.TimeLineCondensedViewVisibility = eCondensedViewVisibility.Hidden; // scroll dla kazdego timelineu
       

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

        // UNUSED
        #region AddAppointment

        private Appointment AddAppointment(string s,
            DateTime startTime, DateTime endTime, string ownerKey, string color, string marker)
        {

            Appointment appointment = new Appointment();

            appointment.StartTime = startTime;
            appointment.EndTime = endTime;
            appointment.OwnerKey = ownerKey;

            appointment.Subject = s;
            appointment.Description = "Custom description for this appointment";
            appointment.CategoryColor = color;
            appointment.TimeMarkedAs = marker;

            appointment.Tooltip = "This is a Custom tooltip for this appointment";

            calendarView1.CalendarModel.Appointments.Add(appointment);

            return (appointment);
        }

        #endregion

        #region calendarView1_MouseUp

        private void calendarView1_MouseUp(object sender, MouseEventArgs e)
        {
            // Process Right MouseUp event in order to
            // present view specific ContextMenu

            if (e.Button == MouseButtons.Right)
            {
                // Main Calendar View hit
                if (sender is BaseView)
                    BaseViewMouseUp(sender, e);

                // AppointmentView hit
                else if (sender is AppointmentView)
                    AppointmentViewMouseUp(sender);

                // TimeLineHeaderPanel
                else if (sender is TimeLineHeaderPanel)
                    TimeLineHeaderPanelMouseUp(sender, e);
            }
        }

        #endregion

        #region BaseViewMouseUp

        private void BaseViewMouseUp(object sender, MouseEventArgs e)
        {
            BaseView view = sender as BaseView;
            eViewArea area = view.GetViewAreaFromPoint(e.Location);

            if (area == eViewArea.InContent)
                InContentMouseUp(view, e);
        }

        #endregion

        #region InContentMouseUp
        private void InContentMouseUp(BaseView view, MouseEventArgs e)
        {
            // Get the DateSelection start and end
            // from the current mouse location
            DateTime startDate, endDate;

            if (calendarView1.GetDateSelectionFromPoint(e.Location, out startDate, out endDate) == true)
            {
                // If this date falls outside the currently
                // selected range (DateSelectionStart and DateSelectionEnd)
                // then select the new range

                if (IsDateSelected(startDate, endDate) == false)
                {
                    calendarView1.DateSelectionStart = startDate;
                    calendarView1.DateSelectionEnd = endDate;
                }
            }
            ShowContextMenu(InContentContextMenu);
        }

        #endregion

        #region IsDateSelected
        private bool IsDateSelected(DateTime startDate, DateTime endDate)
        {
            if (calendarView1.DateSelectionStart.HasValue && calendarView1.DateSelectionEnd.HasValue)
            {
                if (calendarView1.DateSelectionStart.Value <= startDate &&
                    calendarView1.DateSelectionEnd.Value >= endDate)
                    return (true);
            }

            return (false);
        }
        #endregion

        #region AddNewAppointment
        void miAdd_Click(object sender, EventArgs e)
        {
            DateTime startDate = calendarView1.DateSelectionStart.GetValueOrDefault();
            DateTime endDate = calendarView1.DateSelectionEnd.GetValueOrDefault();

            AddNewAppointment(startDate, endDate);
        }

        private Appointment AddNewAppointment(DateTime startDate, DateTime endDate)
        {
            // Create new appointment and add it to the model
            // Appointment will show up in the view automatically

            Appointment appointment = new Appointment();

            appointment.StartTime = startDate;
            appointment.EndTime = endDate;
            appointment.OwnerKey = calendarView1.SelectedOwner;

            appointment.Subject = "New " +
                appointment.CategoryColor + " appointment!";

            appointment.Description = "This is a new appointment";
            appointment.Tooltip = "This is a Custom tooltip for this new appointment";

            // Add appointment to the model

            calendarView1.CalendarModel.Appointments.Add(appointment);

            return (appointment);
        }

        #endregion

        #region AppointmentViewMouseUp
        private void AppointmentViewMouseUp(object sender)
        {
            AppointmentView view = sender as AppointmentView;

            // Select the appointment
            view.IsSelected = true;

            // Let the user delete the appointment
            AppDeleteContextItem.Enabled = (view.Appointment.IsRecurringInstance == false);
            AppointmentContextMenu.Tag = view;

            ShowContextMenu(AppointmentContextMenu);
        }
        #endregion

        #region Delete Appointment
        void miDelete_Click(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;
            AppointmentView view = bi.Parent.Tag as AppointmentView;

            if (view != null)
                calendarView1.CalendarModel.Appointments.Remove(view.Appointment);
        }
        #endregion

        #region TimeLineHeaderPanelMouseUp
        private void TimeLineHeaderPanelMouseUp(object sender, MouseEventArgs e)
        {
            TimeLineHeaderPanel tp = sender as TimeLineHeaderPanel;

            if (tp != null)
            {
                eViewArea area = tp.GetViewAreaFromPoint(e.Location);

                if (area == eViewArea.InIntervalHeader)
                    InIntervalHeaderMouseUp();
            }
        }
        #endregion

        #region InIntervalHeaderMouseUp
        private void InIntervalHeaderMouseUp()
        {
            for (int i = IntervalHeaderContextMenu.SubItems.Count - 1; i > 0; i--)
                IntervalHeaderContextMenu.SubItems.RemoveAt(i);

            AddIntervalMinutes();
            ShowContextMenu(IntervalHeaderContextMenu);
        }
        #endregion

        #region Interval time support

        #region AddIntervalMinutes
        private void AddIntervalMinutes()
        {
            for (int i = 1; i <= 60; i++)
            {
                if (60 % i == 0)
                    AddIntervalItem(i);
            }
        }
        #endregion

        #region AddIntervalItem
        private void AddIntervalItem(int i)
        {
            ButtonItem bi = new ButtonItem("", i.ToString());

            bi.Click += BiIntervalClick;

            if (calendarView1.TimeLineInterval == i)
                bi.Checked = true;

            IntervalHeaderContextMenu.SubItems.Add(bi);
        }
        #endregion

        #region BiIntervalClick
        private void BiIntervalClick(object sender, EventArgs e)
        {
            ButtonItem bi = sender as ButtonItem;

            int n;

            if (int.TryParse(bi.Text, out n) == true)
                calendarView1.TimeLineInterval = n;
        }
        #endregion

        #endregion

        #region ShowContextMenu
        private void ShowContextMenu(ButtonItem cm)
        {
            cm.Popup(MousePosition);
        }
        #endregion
    }
}
