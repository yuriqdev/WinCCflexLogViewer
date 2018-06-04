using System;
using System.Windows.Forms;

namespace WinCCFlexLogViewer
{
    public partial class YScaleSettings : Form
	{
		public YScaleSettings(double min, double max, string c_name)
		{
            InitializeComponent();
            channel_name_label.Text = c_name;
            channel_Y_min_input.Text = string.Concat(min);
            channel_Y_max_input.Text = string.Concat(max);
		}

		private void btnSet_Click(object sender, EventArgs e)
		{
            min = channel_Y_min_input.DoubleVal;
            max = channel_Y_max_input.DoubleVal;
            if (channel_Y_min_input.NumOK == true & channel_Y_max_input.NumOK == true)
            {
                set = true;
                Close();
            }
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
            set = false;
            Close();
		}
		//
		public double min;
		//
		public double max;
		//
		public bool set;
    }
}
