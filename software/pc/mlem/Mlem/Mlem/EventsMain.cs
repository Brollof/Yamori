﻿using System;
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
                // Accept only date from range 00:00 - 00:00 (next day)
                if (app.OwnerKey == ioName && IsDateValid(app.EndTime))
                {
                    Event startEvent = new Event(true, app.StartTime);
                    Event endEvent = new Event(false, app.EndTime);

                    events.Add(startEvent);
                    events.Add(endEvent);
                }
            }

            SortEventsByTime(ref events);
            return ConcatEvents(events);
        }

        private void SortEventsByTime(ref List<Event> events)
        {
            events.Sort((a, b) => a.Time.CompareTo(b.Time));
        }

        private bool IsDateValid(DateTime time)
        {
            return (time <= calendarView1.TimeLineViewStartDate.AddDays(1));
        }

        private List<Event> ConcatEvents(List<Event> events)
        {
            int n = events.Count;

            if (n > 3) // at least two time periods must be in list
            {
                List<Event> concat = new List<Event>();
                concat.Add(events[0]);
                concat.Add(events[1]);

                for (int i = 2; i < n; i++) // ommit first period
                {
                    var last = concat.Last();
                    if (last.Time == events[i].Time)
                    {
                        concat.Remove(last);
                    }
                    else
                    {
                        concat.Add(events[i]);
                    }
                }
                return concat;
            }
            return events;
        }
    }
}
