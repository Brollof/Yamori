using DevComponents.DotNetBar;
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
    public partial class MainWindow
    {
        private const int COL_WIDTH = 90; // px

        private void AddNewColumn()
        {
            int col = lampPicker.ColumnCount;
            lampPicker.ColumnCount++;

            lampPicker.Width += COL_WIDTH;
            ColumnStyle style = new ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F);
            lampPicker.ColumnStyles.Add(style);
            TextBox txtLamp = new TextBox();
            txtLamp.Anchor = AnchorStyles.None;
            txtLamp.Name = "txtLamp" + col.ToString();
            txtLamp.Size = new Size(84, 20);
            txtLamp.TabIndex = 2;
            txtLamp.TextChanged += txtLamp_TextChanged;
            lampPicker.Controls.Add(txtLamp, col, 0);

            ColorDropDown cdd = new ColorDropDown(0, 0, CalendarUtils.Colors);
            cdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cdd.SelectedIndexChanged +=cdd_SelectedIndexChanged;
            lampPicker.Controls.Add(cdd, col, 1);
            
            List<Control> controls = new List<Control>{txtLamp, cdd};
            LampManager.AddColumn(style, controls, lampPicker.ColumnCount - 1);
        }

        private void cdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorDropDown cdd = (ColorDropDown)sender;
            int col = LampManager.GetColumnNumber(cdd);
            string colorName = cdd.SelectedItem.ToString();
            calendarView1.MultiCalendarTimeLineViews[col].CalendarColor =
                CalendarUtils.CalendarColorFromString(colorName);
        }

        private void txtLamp_TextChanged(object sender, EventArgs e)
        {
            UpdateTimeline();
            LampManager.ValidateNames();
        }
        
        private void UpdateColumnStyles()
        {
            float percent = 100f / (lampPicker.ColumnCount - 1);
            for (int i = 1; i < lampPicker.ColumnCount; i++)
            {
                lampPicker.ColumnStyles[i].SizeType = SizeType.Percent;
                lampPicker.ColumnStyles[i].Width = percent;
            }
        }

        private void LampPickerInit(int numberOfCols)
        {
            ShowLampPicker(numberOfCols);

            // Debug printing
            var cols = lampPicker.ColumnStyles;
            foreach (ColumnStyle col in cols)
            {
                Console.WriteLine("size type: {0}, width: {1}", col.SizeType, col.Width);
            }

            Console.WriteLine("Total tab width: {0} ({1} + {2}*{3})",
                lampPicker.Width,
                (int)cols[0].Width,
                lampPicker.ColumnCount - 1,
                (lampPicker.Width - (int)cols[0].Width)/(lampPicker.ColumnCount - 1));

        }

        private void RemoveLastColumn()
        {
            if (lampPicker.ColumnCount > 1)
            {

                lampPicker.Width -= COL_WIDTH;
                PickerColumn pc = LampManager.RemovePickerColumn(lampPicker.ColumnCount - 1);
                foreach(Control control in pc.Controls)
                {
                    lampPicker.Controls.Remove(control);
                }
                lampPicker.ColumnStyles.Remove(pc.Style);
                lampPicker.ColumnCount -= 1;
            }
            else
            {
                Debug.Assert(false, "No columns to remove!");
            }
        }

        private void ShowLampPicker(int columns)
        {
            int currentColsNum = lampPicker.ColumnCount - 1;

            if (columns == currentColsNum)
                return;

            lampPicker.SuspendLayout();

            if (columns > currentColsNum)
            {
                for (int i = 0; i < columns - currentColsNum; i++)
                    AddNewColumn();
            }
            else
            {
                for (int i = 0; i < currentColsNum - columns; i++)
                    RemoveLastColumn();
            }

            UpdateColumnStyles();

            lampPicker.ResumeLayout(false);
            lampPicker.PerformLayout();
        }
    }
}
