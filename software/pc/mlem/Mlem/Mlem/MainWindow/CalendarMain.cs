using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.Schedule;
using DevComponents.DotNetBar;
using DevComponents.Schedule.Model;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using Mlem.Device;

namespace Mlem
{
    public partial class MainWindow
    {
        private enum TimelineFill { WHITE, COLOR };
        private const int TIMELINE_ROW_HEIGHT = 55; // px
        private int MAX_ROWS;

        private void CalendarInit(int maxRows)
        {
            CalendarModel model = NewCalendarModelInit(TimelineFill.COLOR);
            calendarView1.CalendarModel = model;

            MAX_ROWS = maxRows;

            calendarView1.TimeLineShowIntervalHeader = true;
            calendarView1.TimeLineShowPeriodHeader = false;
            calendarView1.IsTimeRulerVisible = true;
            // bottom scroll
            calendarView1.TimeLineShowPageNavigation = false;
            // scroll for every timeline
            calendarView1.TimeLineCondensedViewVisibility = eCondensedViewVisibility.Hidden;

            // Don't show more than 24h
            calendarView1.TimeLineCanExtendRange = false;
            calendarView1.TimeLineViewEndDate = calendarView1.TimeLineViewStartDate.AddDays(1);

            // Stretch appointment across timeline
            calendarView1.TimeLineStretchRowHeight = true;
            // Remove horizontal appointment padding
            calendarView1.TimeLineHorizontalPadding = 0;
            // Period column width
            calendarView1.TimeLineColumnWidth = 30;
            // Timeline row height
            calendarView1.TimeLineHeight = TIMELINE_ROW_HEIGHT;
            // Disable current time indicator
            calendarView1.TimeIndicator.Visibility = eTimeIndicatorVisibility.Hidden;

            // Event handling
            calendarView1.AppointmentViewChanged += calendarView1_AppointmentViewChanged;
            calendarView1.CalendarModel.AppointmentAdded += CalendarModel_AppointmentAdded;
            calendarView1.AppointmentViewChanging += calendarView1_AppointmentViewChanging;
            calendarView1.DisplayedOwnersChanged += calendarView1_DisplayedOwnersChanged;
        }

        private void RemoveLastRow()
        {
            int lastIndex = calendarView1.DisplayedOwners.Count - 1;
            if (lastIndex >= 0)
            {
                calendarView1.DisplayedOwners.RemoveAt(lastIndex);

                if (calendarView1.DisplayedOwners.Count >= 4)
                {
                    calendarView1.Height -= TIMELINE_ROW_HEIGHT;
                    this.Height -= TIMELINE_ROW_HEIGHT;
                }
            }
        }

        private void TimelineAddNewRow(string name, eCalendarColor color)
        {
            if (calendarView1.DisplayedOwners.Count == MAX_ROWS)
                return;

            if (calendarView1.DisplayedOwners.Count >= 4)
            {
                calendarView1.Height += TIMELINE_ROW_HEIGHT;
                this.Height += TIMELINE_ROW_HEIGHT;
            }

            // default empty name and color
            calendarView1.DisplayedOwners.Add(name);
            int cnt = calendarView1.DisplayedOwners.Count;
            calendarView1.MultiCalendarTimeLineViews[cnt - 1].CalendarColor = color;
        }

        void TimelineClear()
        {
            int n = calendarView1.DisplayedOwners.Count;
            for (int i = 0; i < n; i ++)
            {
                RemoveLastRow();
            }
            calendarView1.CalendarModel.Appointments.Clear();
        }

        void calendarView1_AppointmentViewChanging(object sender, AppointmentViewChangingEventArgs e)
        {
            // check whether this appointment exceeds timeline end date
            if (IsDateValid(e.EndTime) == false)
            {
                e.Cancel = true;
            }
        }

        void CalendarModel_AppointmentAdded(object sender, AppointmentEventArgs e)
        {
            Appointment current = e.Appointment;

            // Remove appointment if it exceeds timeline range
            if (IsDateValid(current.EndTime) == false)
            {
                calendarView1.CalendarModel.Appointments.Remove(current);
                return;
            }

            // Remove appointment if it was created on existing one
            foreach (var app in calendarView1.CalendarModel.Appointments)
            {
                if (app.OwnerKey == current.OwnerKey &&
                    app != current &&
                    arePeriodsOverlapping(app.StartTime, app.EndTime, current.StartTime, current.EndTime))
                {
                    calendarView1.CalendarModel.Appointments.Remove(current);
                    return;
                }
            }
        }

        // Perform actions for both move and resize events
        void calendarView1_AppointmentViewChanged(object sender, AppointmentViewChangedEventArgs e)
        {
            AppointmentView current = e.CalendarItem as AppointmentView;

            // check whether this appointment overlaps another one
            foreach (var app in calendarView1.CalendarModel.Appointments)
            {
                if (!app.IsSelected && app.OwnerKey == current.Appointment.OwnerKey)
                {
                    if (arePeriodsOverlapping(app.StartTime, app.EndTime, current.StartTime, current.EndTime))
                    {
                        current.StartTime = e.OldStartTime;
                        current.EndTime = e.OldEndTime;
                    }
                }
            }

            updateAppointmentTooltip(current.ModelItem as Appointment);
        }

        private bool arePeriodsOverlapping(DateTime s1, DateTime e1, DateTime s2, DateTime e2)
        {
            return !(s1 >= e2 || s2 >= e1);
        }

        private void updateAppointmentTooltip(Appointment app)
        {
            app.Tooltip = app.StartTime.ToShortTimeString() + " - " + app.EndTime.ToShortTimeString();
        }

        private CalendarModel NewCalendarModelInit(TimelineFill fill)
        {
            CalendarModel model = new CalendarModel();

            if (fill == TimelineFill.WHITE)
            {
                WorkTime start = new WorkTime(0, 0);
                WorkTime end = new WorkTime(23, 59);
                foreach (WorkDay day in model.WorkDays)
                {
                    day.WorkStartTime = start;
                    day.WorkEndTime = end;
                }
                model.WorkDays.Add(new WorkDay(DayOfWeek.Saturday, start, end));
                model.WorkDays.Add(new WorkDay(DayOfWeek.Sunday, start, end));
            }
            else if (fill == TimelineFill.COLOR)
            {
                model.WorkDays.Clear();
            }
            else
            {
                Debug.Assert(false, "Only BLUE or WHITE color is allowed!");
            }

            return model;
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
            else if (area == eViewArea.InTab)
                InTabMouseUp();
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

        #region InTabMouseUp
        private void InTabMouseUp()
        {
            InTabRemoveTab.Visible = true;
            InTabRemoveTab.Text = "Usuń \"" + calendarView1.SelectedOwner + "\"";
            ShowContextMenu(InTabContextMenu);
        }
        #endregion

        #region InTabRemoveTab_Click
        private void InTabRemoveTab_Click(object sender, EventArgs e)
        {
            if (calendarView1.SelectedOwnerIndex >= 0)
            {
                string name = calendarView1.DisplayedOwners[calendarView1.SelectedOwnerIndex];
                DeviceManager.RemoveDevice(removeSlotFormat(name));
                calendarView1.DisplayedOwners.RemoveAt(calendarView1.SelectedOwnerIndex);
            }

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
            return AddNewAppointment(startDate, endDate, calendarView1.SelectedOwner);
        }

        private Appointment AddNewAppointment(DateTime startDate, DateTime endDate, string owner)
        {
            Appointment app = new Appointment();
            app.StartTime = startDate;
            app.EndTime = endDate;
            app.OwnerKey = owner;
            if (cbShowPeriod.Checked)
                app.DisplayTemplate = "[StartTime] - [EndTime]";
            else
                app.DisplayTemplate = " ";

            updateAppointmentTooltip(app);

            calendarView1.CalendarModel.Appointments.Add(app);

            return app;
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

        #region Utils
        private List<Appointment> GetAppointmentByOwner(int row)
        {
            List<Appointment> ret = new List<Appointment>();
            string owner = calendarView1.DisplayedOwners[row];

            foreach (var app in calendarView1.CalendarModel.Appointments)
            {
                if (owner == app.OwnerKey)
                {
                    ret.Add(app);
                }
            }
            return ret;
        }

        private void ClearAppointmentsByOwner(int row)
        {
            AppointmentCollection apps = calendarView1.CalendarModel.Appointments;
            string owner = calendarView1.DisplayedOwners[row];

            for (int i = apps.Count - 1; i >= 0; i--)
            {
                if (apps[i].OwnerKey == owner)
                {
                    apps.RemoveAt(i);
                }
            }
        }

        private void ConcatAppointmentsByOwner(int row)
        {
            List<Appointment> apps = GetAppointmentByOwner(row);

            if (apps.Count > 1) // at least two time periods must be visible
            {
                apps.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

                for (int i = apps.Count - 1; i > 0; i--)
                {
                    if (apps[i].StartTime == apps[i - 1].EndTime)
                    {
                        apps[i - 1].EndTime = apps[i].EndTime;
                        apps.RemoveAt(i);
                    }
                }

                ClearAppointmentsByOwner(row);
                foreach (var app in apps)
                {
                    calendarView1.CalendarModel.Appointments.Add(app);
                }
            }
        }

        private void ConcatAppointments()
        {
            for (int i = 0; i < calendarView1.DisplayedOwners.Count; i++)
            {
                ConcatAppointmentsByOwner(i);
            }
        }
        #endregion
    }
}
