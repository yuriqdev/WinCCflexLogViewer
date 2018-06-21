using System;
using System.Diagnostics;
using System.Windows.Forms;
//using WinCCFlexLogViewer.Properties;

namespace WinCCFlexLogViewer
{
    public partial class About : Form
	{
		public About()
		{
            InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
            lblBuild.Text = buildDate.ToString();
        }

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            linkLabel1.LinkVisited = true;
			Process.Start("http://plc2k.com");
		}

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://github.com/yuriqdev/WinCCflexLogViewer");
        }
    }
}
