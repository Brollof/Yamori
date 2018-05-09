using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mlem
{
    public partial class MainWindow
    {
        private void LampPickerInit()
        {
            var cols = lampPicker.ColumnStyles;
            int colWidth = lampPicker.Width - (int)cols[0].Width;

            // This will be determined by UI
            lampPicker.ColumnCount = 3;

            // Add columns in loop with child controls
            lampPicker.Width += colWidth;
            lampPicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            System.Windows.Forms.TextBox txtLamp2 = new System.Windows.Forms.TextBox();
            txtLamp2.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtLamp2.Name = "txtLamp2";
            txtLamp2.Size = new System.Drawing.Size(84, 20);
            txtLamp2.TabIndex = 2;
            lampPicker.Controls.Add(txtLamp2, 2, 0);

            //lampPicker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            //System.Windows.Forms.TextBox txtLamp3 = new System.Windows.Forms.TextBox();
            //txtLamp3.Anchor = System.Windows.Forms.AnchorStyles.None;
            //txtLamp3.Name = "txtLamp3";
            //txtLamp3.Size = new System.Drawing.Size(84, 20);
            //txtLamp3.TabIndex = 2;
            //lampPicker.Controls.Add(txtLamp3, 2, 0);


            // Set column styles
            float percent = 100f / (lampPicker.ColumnCount - 1);
            Console.WriteLine("Percent col size: " + percent);
            for (int i = 1; i < lampPicker.ColumnCount; i++)
            {
                lampPicker.ColumnStyles[i].SizeType = SizeType.Percent;
                lampPicker.ColumnStyles[i].Width = percent;
            }

            // Debug printing
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
    }
}
