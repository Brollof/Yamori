using DevComponents.DotNetBar.Schedule;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mlem
{
    class ColorDropDown : ComboBox
    {
        private List<Color> colors;

        public ColorDropDown()
        {
            this.FormattingEnabled = true;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += this_DrawItem;
        }

        public ColorDropDown(int x, int y, List<Color> colors)
        {
            this.colors = colors;
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormattingEnabled = true;
            this.Location = new System.Drawing.Point(x, y);
            //this.Name = "comboBox1";
            this.Size = new System.Drawing.Size(121, 21);
            this.TabIndex = 11;
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += this_DrawItem;

            string[] names = typeof(eCalendarColor).GetEnumNames();
            foreach (string name in names)
            {
                if (name != "Automatic")
                    this.Items.Add(name);
            }
            this.SelectedIndex = 0;
        }

        public void FillWithColors(List<Color> colors)
        {
            this.colors = colors;
            string[] names = typeof(eCalendarColor).GetEnumNames();
            foreach (string name in names)
            {
                if (name != "Automatic")
                    this.Items.Add(name);
            }
            this.SelectedIndex = 0;
        }

        #region Events
        private void this_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Rectangle rec = e.Bounds;
                string colorName = ((ComboBox)sender).Items[e.Index].ToString();
                //Color color = CalendarUtils.ColorFromCalendarString(colorName);
                Color color = colors[e.Index];
                Brush brush = new SolidBrush(color);
                g.FillRectangle(brush, rec);
            }
        }
        #endregion
    }
}
