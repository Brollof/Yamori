using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
                    Event startEvent = new Event(true,  app.StartTime);
                    Event endEvent = new Event(false, app.EndTime);

                    events.Add(startEvent);
                    events.Add(endEvent);
                }
            }

            return events;
        }
    }
}
