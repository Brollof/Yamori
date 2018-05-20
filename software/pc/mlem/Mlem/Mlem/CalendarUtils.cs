using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Schedule;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    public static class CalendarUtils
    {
        private const int CALENDAR_PART = 0;
        private static List<Color> colors = GetCalendarColors();

        public static List<Color> Colors
        {
            get { return colors; }
        }

        private static List<Color> GetCalendarColors()
        {
            CalendarView cal = new CalendarView();
            cal.DisplayedOwners.Add(" ");
            List<Color> colors = new List<Color>();

            var values = Enum.GetValues(typeof(eCalendarColor));
            foreach(var color in values)
            {
                try
                {
                    cal.MultiCalendarTimeLineViews[0].CalendarColor = (eCalendarColor)color;
                    CalendarColor c = cal.MultiCalendarTimeLineViews[0].CalendarColorTable;
                    colors.Add(c.GetColor(CALENDAR_PART));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            cal.Dispose();
            return colors;
        }

        public static eCalendarColor CalendarColorFromString(string colorName)
        {
            eCalendarColor color;
            Enum.TryParse(colorName, out color);
            return color;
        }
    }
}
