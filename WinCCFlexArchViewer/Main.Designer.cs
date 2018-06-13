namespace WinCCFlexLogViewer
{
	public partial class Main : System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		//
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.togleTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideshowcurveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockunlockvzoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ControlsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCSVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.button_loclunlockvzoom = new System.Windows.Forms.Button();
            this.button_panright = new System.Windows.Forms.Button();
            this.button_zoomin = new System.Windows.Forms.Button();
            this.button_panbottom = new System.Windows.Forms.Button();
            this.button_resetzoompan = new System.Windows.Forms.Button();
            this.button_pantop = new System.Windows.Forms.Button();
            this.button_zoomout = new System.Windows.Forms.Button();
            this.button_panleft = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingpanel = new System.Windows.Forms.Panel();
            this.progress_counter_textlabel = new System.Windows.Forms.Label();
            this.loadingpictureBox = new System.Windows.Forms.PictureBox();
            this.DTrend = new ZedGraph.ZedGraphControl();
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.progress_timer = new System.Windows.Forms.Timer(this.components);
            this.printDlg = new System.Windows.Forms.PrintDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.loadingpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.togleTableToolStripMenuItem,
            this.hideshowcurveMenuItem,
            this.printMenuItem,
            this.lockunlockvzoomMenuItem,
            this.ExitStripMenuItem,
            this.aboutMenuItem,
            this.ControlsStripMenuItem,
            this.fullscreenToolStripMenuItem,
            this.SaveCSVMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 2, 2);
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_142_database_plus;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.ToolTipText = "Import data log file";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // togleTableToolStripMenuItem
            // 
            this.togleTableToolStripMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_120_table;
            this.togleTableToolStripMenuItem.Name = "togleTableToolStripMenuItem";
            this.togleTableToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.togleTableToolStripMenuItem.Text = "Table";
            this.togleTableToolStripMenuItem.ToolTipText = "Toggle  table view";
            this.togleTableToolStripMenuItem.Click += new System.EventHandler(this.togleTableToolStripMenuItem_Click);
            // 
            // hideshowcurveMenuItem
            // 
            this.hideshowcurveMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_115_list;
            this.hideshowcurveMenuItem.Name = "hideshowcurveMenuItem";
            this.hideshowcurveMenuItem.Size = new System.Drawing.Size(71, 20);
            this.hideshowcurveMenuItem.Text = "Curves";
            // 
            // printMenuItem
            // 
            this.printMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_16_print;
            this.printMenuItem.Name = "printMenuItem";
            this.printMenuItem.Size = new System.Drawing.Size(60, 20);
            this.printMenuItem.Text = "Print";
            this.printMenuItem.ToolTipText = "Print Graph";
            this.printMenuItem.Click += new System.EventHandler(this.printMenuItem_Click);
            // 
            // lockunlockvzoomMenuItem
            // 
            this.lockunlockvzoomMenuItem.CheckOnClick = true;
            this.lockunlockvzoomMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_242_flash;
            this.lockunlockvzoomMenuItem.Name = "lockunlockvzoomMenuItem";
            this.lockunlockvzoomMenuItem.Size = new System.Drawing.Size(134, 20);
            this.lockunlockvzoomMenuItem.Text = "Lock vertical zoom";
            this.lockunlockvzoomMenuItem.ToolTipText = "Toggle Y-axis zoom lock";
            this.lockunlockvzoomMenuItem.Click += new System.EventHandler(this.lockunlockvzoomMenuItem_Click);
            // 
            // ExitStripMenuItem
            // 
            this.ExitStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExitStripMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_389_exit;
            this.ExitStripMenuItem.Name = "ExitStripMenuItem";
            this.ExitStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.ExitStripMenuItem.Text = "exit";
            this.ExitStripMenuItem.Click += new System.EventHandler(this.ExitStripMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_196_circle_info;
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(38, 20);
            this.aboutMenuItem.Text = " ";
            this.aboutMenuItem.ToolTipText = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // ControlsStripMenuItem
            // 
            this.ControlsStripMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_589_remote_control_tv;
            this.ControlsStripMenuItem.Name = "ControlsStripMenuItem";
            this.ControlsStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.ControlsStripMenuItem.Text = "Controls";
            this.ControlsStripMenuItem.ToolTipText = "Toggle Control pad";
            this.ControlsStripMenuItem.Click += new System.EventHandler(this.ControlsStripMenuItem_Click);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.fullscreen2;
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.fullscreenToolStripMenuItem.Text = "Fullscreen";
            this.fullscreenToolStripMenuItem.ToolTipText = "Toggle fullscreen mode";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // SaveCSVMenuItem
            // 
            this.SaveCSVMenuItem.Image = global::WinCCFlexLogViewer.Properties.Resources.save_64;
            this.SaveCSVMenuItem.Name = "SaveCSVMenuItem";
            this.SaveCSVMenuItem.Size = new System.Drawing.Size(79, 20);
            this.SaveCSVMenuItem.Text = "Save csv";
            this.SaveCSVMenuItem.ToolTipText = "Save Table data to CSV file";
            this.SaveCSVMenuItem.Click += new System.EventHandler(this.SaveCSVMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Log Files(*.csv;*.txt;*rdb)|*.csv;*.txt;*rdb|csv file|*.csv|rdb file|*.rdb|An" +
    "y file|*.*";
            this.openFileDialog1.Title = "Open WinCC flexible or TIA Portal Log file";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.controlPanel);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.DTrend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_data);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(846, 454);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 1;
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.button_loclunlockvzoom);
            this.controlPanel.Controls.Add(this.button_panright);
            this.controlPanel.Controls.Add(this.button_zoomin);
            this.controlPanel.Controls.Add(this.button_panbottom);
            this.controlPanel.Controls.Add(this.button_resetzoompan);
            this.controlPanel.Controls.Add(this.button_pantop);
            this.controlPanel.Controls.Add(this.button_zoomout);
            this.controlPanel.Controls.Add(this.button_panleft);
            this.controlPanel.Controls.Add(this.button_print);
            this.controlPanel.Location = new System.Drawing.Point(718, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(122, 116);
            this.controlPanel.TabIndex = 1;
            this.controlPanel.Visible = false;
            // 
            // button_loclunlockvzoom
            // 
            this.button_loclunlockvzoom.FlatAppearance.BorderSize = 0;
            this.button_loclunlockvzoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loclunlockvzoom.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_242_flash;
            this.button_loclunlockvzoom.Location = new System.Drawing.Point(85, 79);
            this.button_loclunlockvzoom.Name = "button_loclunlockvzoom";
            this.button_loclunlockvzoom.Size = new System.Drawing.Size(37, 34);
            this.button_loclunlockvzoom.TabIndex = 8;
            this.button_loclunlockvzoom.UseVisualStyleBackColor = true;
            this.button_loclunlockvzoom.Click += new System.EventHandler(this.button_loclunlockvzoom_Click);
            // 
            // button_panright
            // 
            this.button_panright.FlatAppearance.BorderSize = 0;
            this.button_panright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_panright.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_218_circle_arrow_right;
            this.button_panright.Location = new System.Drawing.Point(85, 39);
            this.button_panright.Name = "button_panright";
            this.button_panright.Size = new System.Drawing.Size(37, 34);
            this.button_panright.TabIndex = 7;
            this.button_panright.UseVisualStyleBackColor = true;
            this.button_panright.Click += new System.EventHandler(this.button_panright_Click);
            // 
            // button_zoomin
            // 
            this.button_zoomin.FlatAppearance.BorderSize = 0;
            this.button_zoomin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_zoomin.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_237_zoom_in;
            this.button_zoomin.Location = new System.Drawing.Point(85, -1);
            this.button_zoomin.Name = "button_zoomin";
            this.button_zoomin.Size = new System.Drawing.Size(37, 34);
            this.button_zoomin.TabIndex = 6;
            this.button_zoomin.UseVisualStyleBackColor = true;
            this.button_zoomin.Click += new System.EventHandler(this.button_zoomin_Click);
            // 
            // button_panbottom
            // 
            this.button_panbottom.FlatAppearance.BorderSize = 0;
            this.button_panbottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_panbottom.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_220_circle_arrow_down;
            this.button_panbottom.Location = new System.Drawing.Point(42, 79);
            this.button_panbottom.Name = "button_panbottom";
            this.button_panbottom.Size = new System.Drawing.Size(37, 34);
            this.button_panbottom.TabIndex = 5;
            this.button_panbottom.UseVisualStyleBackColor = true;
            this.button_panbottom.Click += new System.EventHandler(this.button_panbottom_Click);
            // 
            // button_resetzoompan
            // 
            this.button_resetzoompan.FlatAppearance.BorderSize = 0;
            this.button_resetzoompan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_resetzoompan.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_215_resize_small;
            this.button_resetzoompan.Location = new System.Drawing.Point(42, 39);
            this.button_resetzoompan.Name = "button_resetzoompan";
            this.button_resetzoompan.Size = new System.Drawing.Size(37, 34);
            this.button_resetzoompan.TabIndex = 4;
            this.button_resetzoompan.UseVisualStyleBackColor = true;
            this.button_resetzoompan.Click += new System.EventHandler(this.button_resetzoompan_Click);
            // 
            // button_pantop
            // 
            this.button_pantop.FlatAppearance.BorderSize = 0;
            this.button_pantop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_pantop.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_219_circle_arrow_top;
            this.button_pantop.Location = new System.Drawing.Point(42, -1);
            this.button_pantop.Name = "button_pantop";
            this.button_pantop.Size = new System.Drawing.Size(37, 34);
            this.button_pantop.TabIndex = 3;
            this.button_pantop.UseVisualStyleBackColor = true;
            this.button_pantop.Click += new System.EventHandler(this.button_pantop_Click);
            // 
            // button_zoomout
            // 
            this.button_zoomout.FlatAppearance.BorderSize = 0;
            this.button_zoomout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_zoomout.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_238_zoom_out;
            this.button_zoomout.Location = new System.Drawing.Point(-1, 79);
            this.button_zoomout.Name = "button_zoomout";
            this.button_zoomout.Size = new System.Drawing.Size(37, 34);
            this.button_zoomout.TabIndex = 2;
            this.button_zoomout.UseVisualStyleBackColor = true;
            this.button_zoomout.Click += new System.EventHandler(this.button_zoomout_Click);
            // 
            // button_panleft
            // 
            this.button_panleft.FlatAppearance.BorderSize = 0;
            this.button_panleft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_panleft.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_217_circle_arrow_left;
            this.button_panleft.Location = new System.Drawing.Point(-1, 39);
            this.button_panleft.Name = "button_panleft";
            this.button_panleft.Size = new System.Drawing.Size(37, 34);
            this.button_panleft.TabIndex = 1;
            this.button_panleft.UseVisualStyleBackColor = true;
            this.button_panleft.Click += new System.EventHandler(this.button_panleft_Click);
            // 
            // button_print
            // 
            this.button_print.FlatAppearance.BorderSize = 0;
            this.button_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_print.Image = global::WinCCFlexLogViewer.Properties.Resources.glyphicons_16_print;
            this.button_print.Location = new System.Drawing.Point(-1, -1);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(37, 34);
            this.button_print.TabIndex = 0;
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loadingpanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 454);
            this.panel1.TabIndex = 1;
            // 
            // loadingpanel
            // 
            this.loadingpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loadingpanel.Controls.Add(this.progress_counter_textlabel);
            this.loadingpanel.Controls.Add(this.loadingpictureBox);
            this.loadingpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingpanel.Location = new System.Drawing.Point(0, 0);
            this.loadingpanel.Name = "loadingpanel";
            this.loadingpanel.Size = new System.Drawing.Size(846, 454);
            this.loadingpanel.TabIndex = 1;
            this.loadingpanel.Visible = false;
            // 
            // progress_counter_textlabel
            // 
            this.progress_counter_textlabel.AutoSize = true;
            this.progress_counter_textlabel.Location = new System.Drawing.Point(387, 261);
            this.progress_counter_textlabel.Name = "progress_counter_textlabel";
            this.progress_counter_textlabel.Size = new System.Drawing.Size(0, 13);
            this.progress_counter_textlabel.TabIndex = 1;
            this.progress_counter_textlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingpictureBox
            // 
            this.loadingpictureBox.Image = global::WinCCFlexLogViewer.Properties.Resources.loading;
            this.loadingpictureBox.Location = new System.Drawing.Point(371, 192);
            this.loadingpictureBox.Name = "loadingpictureBox";
            this.loadingpictureBox.Size = new System.Drawing.Size(63, 66);
            this.loadingpictureBox.TabIndex = 0;
            this.loadingpictureBox.TabStop = false;
            // 
            // DTrend
            // 
            this.DTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DTrend.IsEnableSelection = true;
            this.DTrend.Location = new System.Drawing.Point(0, 0);
            this.DTrend.Margin = new System.Windows.Forms.Padding(0);
            this.DTrend.Name = "DTrend";
            this.DTrend.ScrollGrace = 0D;
            this.DTrend.ScrollMaxX = 0D;
            this.DTrend.ScrollMaxY = 0D;
            this.DTrend.ScrollMaxY2 = 0D;
            this.DTrend.ScrollMinX = 0D;
            this.DTrend.ScrollMinY = 0D;
            this.DTrend.ScrollMinY2 = 0D;
            this.DTrend.Size = new System.Drawing.Size(846, 454);
            this.DTrend.TabIndex = 0;
            this.DTrend.UseExtendedPrintDialog = true;
            this.DTrend.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.DTrend_ZoomEvent);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.AllowUserToOrderColumns = true;
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_data.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_data.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.ReadOnly = true;
            this.dataGridView_data.Size = new System.Drawing.Size(150, 46);
            this.dataGridView_data.TabIndex = 0;
            // 
            // progress_timer
            // 
            this.progress_timer.Interval = 50;
            this.progress_timer.Tick += new System.EventHandler(this.progress_timer_Tick);
            // 
            // printDlg
            // 
            this.printDlg.UseEXDialog = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "table.csv";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 478);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.loadingpanel.ResumeLayout(false);
            this.loadingpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		//
		private System.ComponentModel.IContainer components;
		//
		private System.Windows.Forms.MenuStrip menuStrip1;
		//
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		//
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		//
		private System.Windows.Forms.SplitContainer splitContainer1;
		//  ZedGraph Instance
		private ZedGraph.ZedGraphControl DTrend;
		//
		private System.Windows.Forms.DataGridView dataGridView_data;
		//
		private System.Windows.Forms.ToolStripMenuItem togleTableToolStripMenuItem;
		//
		private System.Windows.Forms.ToolStripMenuItem hideshowcurveMenuItem;
		//
		private System.Windows.Forms.ToolStripMenuItem printMenuItem;
		//
		private System.Windows.Forms.ToolStripMenuItem lockunlockvzoomMenuItem;
		// 
		private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
		//
		private System.Windows.Forms.Panel panel1;
		//
		private System.Windows.Forms.ToolStripMenuItem ControlsStripMenuItem;
		//
		private System.Windows.Forms.ToolStripMenuItem ExitStripMenuItem;
		//
		private System.Windows.Forms.Panel controlPanel;
		//
		private System.Windows.Forms.Button button_loclunlockvzoom;
		//
		private System.Windows.Forms.Button button_panright;
		//
		private System.Windows.Forms.Button button_zoomin;
		//
		private System.Windows.Forms.Button button_panbottom;
		//
		private System.Windows.Forms.Button button_resetzoompan;
		//
		private System.Windows.Forms.Button button_pantop;
		//
		private System.Windows.Forms.Button button_zoomout;
		//
		private System.Windows.Forms.Button button_panleft;
		//
		private System.Windows.Forms.Button button_print;
		//
		private System.Windows.Forms.Panel loadingpanel;
		//
		private System.Windows.Forms.PictureBox loadingpictureBox;
		//
		private System.Windows.Forms.Label progress_counter_textlabel;
		//
		private System.Windows.Forms.Timer progress_timer;
        //
        private System.Windows.Forms.PrintDialog printDlg;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveCSVMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}
