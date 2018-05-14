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
            lampPicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TextBox txtLamp = new TextBox();
            txtLamp.Anchor = AnchorStyles.None;
            txtLamp.Name = "txtLamp" + col.ToString();
            txtLamp.Size = new Size(84, 20);
            txtLamp.TabIndex = 2;
            lampPicker.Controls.Add(txtLamp, col, 0);

            ColorPickerButton cpLamp = new ColorPickerButton();
            cpLamp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            cpLamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            cpLamp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            cpLamp.Image = new Bitmap(Properties.Resources.NoColor);
            cpLamp.Location = new System.Drawing.Point(63, 43);
            cpLamp.Name = "cpLamp" + col.ToString();
            cpLamp.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            cpLamp.Size = new System.Drawing.Size(37, 23);
            cpLamp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            cpLamp.TabIndex = 0;
            lampPicker.Controls.Add(cpLamp, col, 1);
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

        private void RemoveLastItem()
        {
            int index = lampPicker.Controls.Count - 1;
            lampPicker.Controls.RemoveAt(index);
        }

        private void RemoveLastColumn()
        {
            if (lampPicker.ColumnCount > 1)
            {
                lampPicker.Width -= COL_WIDTH;
                RemoveLastItem();
                RemoveLastItem();
                lampPicker.ColumnStyles.RemoveAt(lampPicker.ColumnStyles.Count - 1);
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
