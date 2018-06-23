using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DevComponents.Schedule.Model;

namespace Mlem
{
    public class Event
    {
        public bool State { get; set; }
        public String Time { get; set; }
        private DateTime dateTime;

        public Event(bool state, DateTime time)
        {
            State = state;
            Time = time.ToShortTimeString();
            dateTime = time;
        }

        public Event() { }

        public DateTime GetDateTime() { return this.dateTime; }
    }

    public class Lamp
    {
        public List<Event> Events;
        public string Name;

        public Lamp(string name, List<Event> events)
        {
            Name = name;
            Events = events;
        }
    }

    public partial class MainWindow
    {
        /*
         * Gathers all events from given row (timeline) to list and returns it.
         * Returned list is sorted ascending.
         * Midnight periods are combined together.
         */
        private List<Event> GetEventsFromTimeline(int row)
        {
            Debug.Assert(row < calendarView1.DisplayedOwners.Count, "Index error! (" + row + ")");

            List<Event> events = new List<Event>();
            string ioName = calendarView1.DisplayedOwners[row];

            foreach (var app in calendarView1.CalendarModel.Appointments)
            {
                if (app.OwnerKey == ioName)
                {
                    Event startEvent = new Event(true, app.StartTime);
                    Event endEvent = new Event(false, app.EndTime);

                    events.Add(startEvent);
                    events.Add(endEvent);
                }
            }

            events = SortEventsByTime(events);
            return MergeMidnight(events);
        }

        private List<Event> SortEventsByTime(List<Event> events)
        {
            events.Sort((a, b) => a.GetDateTime().CompareTo(b.GetDateTime()));
            return events;
        }

        private bool IsDateValid(DateTime time)
        {
            return (time <= calendarView1.TimeLineViewStartDate.AddDays(1));
        }

        private List<Event> MergeMidnight(List<Event> events)
        {
            if (events.Count == 0)
                return events;

            Event first = events.First();
            Event last = events.Last();

            if (first.GetDateTime().TimeOfDay == last.GetDateTime().TimeOfDay)
            {
                // List length of two means that there is only one period which lasts
                // whole day. In that case remove only last event so the controlled
                // device will be turned on 24/7 which shouldn't happen anyway.
                if (events.Count > 2)
                    events.Remove(first);
                events.Remove(last);
            }

            return events;
        }

        private void FillTimeline(List<Event> events, string name)
        {
            // special case - whole day
            if (events.Count == 1)
            {
                DateTime start = DateTime.Parse("00:00");
                DateTime end = start.AddDays(1);
                AddNewAppointment(start, end, name);
            }
            else if (events.Count > 1)
            {
                Debug.Assert(events.Count % 2 == 0, "JSON DATA CORRUPTED: odd number of events");
                // midnight
                if (events.First().State == false && events.Last().State == true)
                {
                    // unmerge midnight
                    Console.WriteLine("Unmerging midnight for " + name);
                    DateTime start = DateTime.Parse("00:00");
                    DateTime end = DateTime.Parse(events.First().Time);
                    AddNewAppointment(start, end, name);

                    start = DateTime.Parse(events.Last().Time);
                    end = DateTime.Parse("00:00").AddDays(1);
                    AddNewAppointment(start, end, name);

                    events.RemoveAt(0);
                    events.RemoveAt(events.Count - 1);
                }

                // other "regular" events
                for (int i = 0; i < events.Count; i += 2)
                {
                    DateTime start = DateTime.Parse(events[i].Time);
                    DateTime end = DateTime.Parse(events[i + 1].Time);
                    AddNewAppointment(start, end, name);
                }
            }
        }
    }
}
