namespace WinCCFlexLogViewer
{
	public partial class YScaleSettings : System.Windows.Forms.Form
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
            this.channel_name_label = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.channel_Y_min_label = new System.Windows.Forms.Label();
            this.channel_Y_max_label = new System.Windows.Forms.Label();
            this.channel_Y_max_input = new WinCCFlexLogViewer.NumTextBox();
            this.channel_Y_min_input = new WinCCFlexLogViewer.NumTextBox();
            this.SuspendLayout();
            // 
            // channel_name_label
            // 
            this.channel_name_label.AutoSize = true;
            this.channel_name_label.Location = new System.Drawing.Point(5, 9);
            this.channel_name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.channel_name_label.Name = "channel_name_label";
            this.channel_name_label.Size = new System.Drawing.Size(75, 13);
            this.channel_name_label.TabIndex = 0;
            this.channel_name_label.Text = "Channel name";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(12, 79);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // channel_Y_min_label
            // 
            this.channel_Y_min_label.AutoSize = true;
            this.channel_Y_min_label.Location = new System.Drawing.Point(12, 34);
            this.channel_Y_min_label.Name = "channel_Y_min_label";
            this.channel_Y_min_label.Size = new System.Drawing.Size(37, 13);
            this.channel_Y_min_label.TabIndex = 5;
            this.channel_Y_min_label.Text = "Y Min:";
            // 
            // channel_Y_max_label
            // 
            this.channel_Y_max_label.AutoSize = true;
            this.channel_Y_max_label.Location = new System.Drawing.Point(12, 56);
            this.channel_Y_max_label.Name = "channel_Y_max_label";
            this.channel_Y_max_label.Size = new System.Drawing.Size(40, 13);
            this.channel_Y_max_label.TabIndex = 6;
            this.channel_Y_max_label.Text = "Y Max:";
            // 
            // channel_Y_max_input
            // 
            this.channel_Y_max_input.Location = new System.Drawing.Point(55, 53);
            this.channel_Y_max_input.Name = "channel_Y_max_input";
            this.channel_Y_max_input.Size = new System.Drawing.Size(100, 20);
            this.channel_Y_max_input.TabIndex = 4;
            this.channel_Y_max_input.Text = "0";
            this.channel_Y_max_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.channel_Y_max_input.WordWrap = false;
            // 
            // channel_Y_min_input
            // 
            this.channel_Y_min_input.Location = new System.Drawing.Point(55, 31);
            this.channel_Y_min_input.Name = "channel_Y_min_input";
            this.channel_Y_min_input.Size = new System.Drawing.Size(100, 20);
            this.channel_Y_min_input.TabIndex = 3;
            this.channel_Y_min_input.Text = "0";
            this.channel_Y_min_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.channel_Y_min_input.WordWrap = false;
            // 
            // YScaleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 112);
            this.Controls.Add(this.channel_Y_max_label);
            this.Controls.Add(this.channel_Y_min_label);
            this.Controls.Add(this.channel_Y_max_input);
            this.Controls.Add(this.channel_Y_min_input);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.channel_name_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YScaleSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Y scale settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		//
		private System.ComponentModel.IContainer components;
		//
		private System.Windows.Forms.Label channel_name_label;
		//
		private System.Windows.Forms.Button btnSet;
		// 
		private System.Windows.Forms.Button btnCancel;
		// 
		private NumTextBox channel_Y_min_input;
		// 
		private NumTextBox channel_Y_max_input;
		// 
		private System.Windows.Forms.Label channel_Y_min_label;
		// 
		private System.Windows.Forms.Label channel_Y_max_label;
	}
}
