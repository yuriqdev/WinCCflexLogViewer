using System;
using System.Globalization;
using System.Windows.Forms;

namespace WinCCFlexLogViewer
{
    public partial class NumTextBox : TextBox
    {
        private const int WM_PASTE = 0x0302;
        private bool ok = false;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }

            if (e.KeyChar != 22)
                e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != ',' || (Text.Contains(",") && !SelectedText.Contains(","))) && e.KeyChar != (char)Keys.Back && (e.KeyChar != '-' || SelectionStart != 0 || (Text.Contains("-") && !SelectedText.Contains("-")));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE)
            {
                base.WndProc(ref m);   // Handle all other messages normally
            }
            else
            {
                double value;
                if (double.TryParse(Clipboard.GetText(), out value))
                {
                    Text = value.ToString();
                }
                else MessageBox.Show("Only Number Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private double DblParse()
        {
            double d = 0.0;
            if (Text == String.Empty)
            {
                MessageBox.Show("Empty Value Not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            else
            {
                ok = double.TryParse(this.Text, out d);
                if (ok == false) MessageBox.Show("Only Number Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return d;
        }

        public double DoubleVal
        {
            get
            {
                return DblParse();
            }
        }

        public bool NumOK
        {
            get
            {
                return ok;
            }
        }
    }
}
