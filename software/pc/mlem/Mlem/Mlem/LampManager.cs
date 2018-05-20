using DevComponents.DotNetBar.Schedule;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mlem
{
    struct LampUI
    {
        public string Name;
        public eCalendarColor Color;

        public LampUI(string name, eCalendarColor color)
        {
            Name = name;
            Color = color;
        }
    }

    struct PickerColumn
    {
        public ColumnStyle Style;
        public List<Control> Controls;
        public int Column;

        public PickerColumn(ColumnStyle style, List<Control> controls, int column)
        {
            Style = style;
            Controls = controls;
            Column = column;
        }
    }

    static class LampManager
    {
        // 1. Link cols with controls
        // 2. Link cols with timeline rows
        private const int OFFSET = 1;
        private static List<PickerColumn> pickerColumns = new List<PickerColumn>();

        public static LampUI GetLamp(int col)
        {
            PickerColumn pc = LampManager.GetLampPickerColumn(col);
            string name = null;
            eCalendarColor color = eCalendarColor.Automatic;

            foreach(Control c in pc.Controls)
            {
               if (c is TextBox)
               {
                   name = c.Text;
                   if (String.IsNullOrEmpty(name))
                       name = " ";
               }
               else if (c is ColorDropDown)
               {
                   string colorName = ((ColorDropDown)c).SelectedItem.ToString();
                   color = CalendarUtils.CalendarColorFromString(colorName);
               }
            }
            return new LampUI(name, color);
        }

        public static void AddColumn(ColumnStyle style, List<Control> controls, int column)
        {
            PickerColumn pc = new PickerColumn(style, controls, column);
            pickerColumns.Add(pc);
            Console.WriteLine("[LM] Added column " + column);
        }

        public static PickerColumn GetLampPickerColumn(int column)
        {
            Debug.Assert(column - OFFSET >= 0, "INVALID INDEX! " + (column - OFFSET));
            return pickerColumns[column - OFFSET];
        }

        public static PickerColumn RemovePickerColumn(int column)
        {
            Debug.Assert(column - OFFSET >= 0, "INVALID INDEX! " + (column - OFFSET));
            PickerColumn pc = pickerColumns[column - OFFSET];
            pickerColumns.Remove(pc);
            Console.WriteLine("[LM] Removed column " + pc.Column);
            return pc;
        }

        public static int GetColumnNumber(Control target)
        {
            foreach(var item in pickerColumns)
            {
                foreach(var control in item.Controls)
                {
                    if (control == target)
                        return item.Column;
                }
            }
            return -1;
        }

        
    }
}
