using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mlem
{
    public class NumericTextBox : System.Windows.Forms.TextBox
    {
        public NumericTextBox()
        {
            this.Text = "0";
            this.ShortcutsEnabled = false;
            this.MaxLength = 2;
            this.KeyPress += NumericTextBox_KeyPress;
        }

        private void NumericTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
