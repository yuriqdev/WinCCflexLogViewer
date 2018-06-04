using System;
using System.Diagnostics;
using System.Windows.Forms;
using WinCCFlexLogViewer.Properties;

namespace WinCCFlexLogViewer
{
    public partial class About : Form
	{
		public About()
		{
            InitializeComponent();
		}

		//
	/*	private void About_Load(object sender, EventArgs e)
		{
	//		base.Icon = Resources.logo1;
		}   */

		//
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            linkLabel1.LinkVisited = true;
			Process.Start("http://plc2k.com");
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
