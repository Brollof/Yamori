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
        public DateTime Time { get; set; }

        public Event(bool state, DateTime time)
        {
            State = state;
            Time = time;
        }

        public Event() { }
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
        /// <summary>
        /// Gathers all events from given row (timeline) to list and returns it.
        /// Returned list is sorted ascending.
        /// Midnight periods are combined together.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
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
            events.Sort((a, b) => a.Time.CompareTo(b.Time));
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

            if (first.Time.TimeOfDay == last.Time.TimeOfDay)
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
    }
}
