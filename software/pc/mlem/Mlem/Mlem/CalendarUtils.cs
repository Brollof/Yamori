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
    struct ColorMap
    {
        public eCalendarColor CalendarColor;
        public Color RealColor;

        public ColorMap(eCalendarColor calColor, Color realColor)
        {
            CalendarColor = calColor;
            RealColor = realColor;
        }
    }

    public static class CalendarUtils
    {
        private const int CALENDAR_PART = 0;
        private static List<ColorMap> colorMapper = new List<ColorMap>();
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
                    Color realColor = c.GetColor(CALENDAR_PART);
                    colors.Add(realColor);
                    ColorMap cm = new ColorMap((eCalendarColor)color, realColor);
                    colorMapper.Add(cm);
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

        public static Color ConvertColor(eCalendarColor color)
        {
            foreach(var map in colorMapper)
            {
                if (map.CalendarColor == color)
                {
                    return map.RealColor;
                }
            }
            return Color.White;
        }

        public static eCalendarColor ConvertColor(Color color)
        {
            foreach (var map in colorMapper)
            {
                if (map.RealColor == color)
                {
                    return map.CalendarColor;
                }
            }
            return eCalendarColor.Automatic;
        }

        public static eCalendarColor ConvertColor(RGB rgb)
        {
            Color color = Color.FromArgb(rgb.R, rgb.G, rgb.B);
            return ConvertColor(color);
        }
    }
}
