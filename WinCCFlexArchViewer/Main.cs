using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinCCFlexLogViewer.Properties;
using ZedGraph;

namespace WinCCFlexLogViewer
{
	public partial class Main : Form
	{
		public Main()
		{
            InitializeComponent();
            Icon = Resources.logo1;
            Text = Application.ProductName + " v" + Application.ProductVersion;
            DTrend.GraphPane.Title.IsVisible = false;
            DTrend.MasterPane[0].IsFontsScaled = false;
            DTrend.GraphPane.Legend.IsVisible = false;
            DTrend.GraphPane.Border.IsVisible = false;
            DTrend.GraphPane.Chart.Border.IsVisible = false;
            DTrend.MasterPane.Margin.Left = 0f;
            DTrend.MasterPane.Margin.Right = 0f;
            DTrend.MasterPane.Margin.Top = 0f;
            DTrend.MasterPane.Margin.Bottom = 0f;
            DTrend.MasterPane.InnerPaneGap = 0f;
            DTrend.GraphPane.Margin.Left = 0f;
            DTrend.GraphPane.Margin.Right = 2f;
            DTrend.GraphPane.Margin.Top = 5f;
            DTrend.GraphPane.Margin.Bottom = 0f;
            DTrend.GraphPane.XAxis.Type = AxisType.Text;
            DTrend.GraphPane.XAxis.IsVisible = true;
            DTrend.GraphPane.XAxis.Title.IsVisible = false;
            DTrend.GraphPane.XAxis.IsAxisSegmentVisible = false;
            DTrend.GraphPane.XAxis.Scale.FontSpec.Size = 10f;
            DTrend.GraphPane.XAxis.Scale.Min = 0.0;
            DTrend.GraphPane.XAxis.MajorGrid.PenWidth = 0.5f;
            DTrend.GraphPane.XAxis.MajorGrid.IsVisible = true;
            DTrend.GraphPane.XAxis.MinorTic.IsOpposite = false;
            DTrend.GraphPane.XAxis.MajorTic.IsOpposite = false;
            DTrend.GraphPane.YAxis.IsVisible = false;
            DTrend.GraphPane.YAxis.Scale.MinAuto = false;
            DTrend.GraphPane.YAxis.Scale.MaxAuto = false;
            DTrend.GraphPane.YAxis.Scale.Min = -100.0;
            DTrend.GraphPane.YAxis.Scale.Max = 5000.0;
            DTrend.GraphPane.Y2Axis.MajorTic.IsOpposite = false;
            DTrend.GraphPane.Y2Axis.MinorTic.IsOpposite = false;
            DTrend.GraphPane.Y2Axis.IsVisible = false;
            DTrend.GraphPane.X2Axis.IsVisible = false;
            DTrend.GraphPane.AxisChange();
            DTrend.Refresh();
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			
            //  Парсинг аргументов командной строки
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
                string path = "";
                string a = commandLineArgs[i];
				if (a == "-f")
				{
					if (i < commandLineArgs.Length - 1)
					{
						path = commandLineArgs[i + 1];
						if (File.Exists(path))
						{
                            loadingpanel.Visible = true;
                            csv_file = path;
                            startparsing();
                        }
					}
				}
				else if (a == "-fullscreen")
				{
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
				}
				else if (a == "-hidefilebutton")
				{
                    fileToolStripMenuItem.Visible = false;
				}
				else if (a == "-hideprintbutton")
				{
                    printMenuItem.Visible = false;
                    button_print.Visible = false;
                }
			}
		}

		// FileOpen Button Click
		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
                loadingpanel.Visible = true;
                csv_file = openFileDialog1.FileName;
                startparsing();
			}
		}

		// Запуск парсинга файла в фоновом режиме
		private void startparsing()
		{
            hideshowcurveMenuItem.DropDownItems.Clear();
            DTrend.GraphPane.YAxisList.Clear();
            DTrend.GraphPane.CurveList.Clear();
            panel1.Show();
            centerLoadingAnnimation();
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerSupportsCancellation = true;
            if (Path.GetExtension(csv_file) != ".rdb")
                backgroundWorker.DoWork += parse_data;
            else
                backgroundWorker.DoWork += startparsingSQL;
            backgroundWorker.RunWorkerAsync();
            backgroundWorker.RunWorkerCompleted += dataparsing_complete;
            progress_timer.Enabled = true;
        }

        //    Парсинг SQLite файла лога
        private void startparsingSQL(object sender, DoWorkEventArgs e)
        {
            table = new DataTable();
            DataColumn dataColumn = new DataColumn();
            dataColumn.DataType = Type.GetType("System.String");
            dataColumn.ColumnName = "Date Time";
            table.Columns.Add(dataColumn);  //добавляем столбец Дата-Время

            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + csv_file + ";Version=3;");
            try
            {
                m_dbConn.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("NotOpen " + ex.ToString());
            }

            SQLiteCommand m_sqlCmd = new SQLiteCommand("SELECT DISTINCT  VarName from logdata where (VarName != '$RT_OFF$')", m_dbConn);
            SQLiteDataReader reader = m_sqlCmd.ExecuteReader();

            channel_names = new List<string>();  // Список имен тегов
            timeList = new List<DateTime>();
            while (reader.Read())    // Добавляем столбцы с тегами
            {
                dataColumn = new DataColumn();
                dataColumn.DataType = Type.GetType("System.Double");
                dataColumn.ColumnName = reader.GetString(0);
                table.Columns.Add(dataColumn);

                channel_names.Add(dataColumn.ColumnName);
            }
            reader.Close();
            m_sqlCmd.CommandText = "SELECT VarName, VarValue, Time_ms FROM logdata WHERE (VarName != '$RT_OFF$')";
            reader = m_sqlCmd.ExecuteReader();
            double tmpNum;
            DateTime d;
            int i = -1;
            while (reader.Read())
            {
                tmpNum = reader.GetDouble(2) / 1000000.0;
                d = DateTime.FromOADate(tmpNum); //форматируем в дату-время
                DataRow dataRow = table.NewRow();
                dataRow["Date Time"] = d.ToString() + "." + d.ToString("fff");

                if (i == -1) { table.Rows.Add(dataRow); i++; table.Rows[i][reader.GetString(0)] = reader.GetDouble(1); timeList.Add(d); continue; }

                if (table.Rows[i]["Date Time"].ToString() != dataRow["Date Time"].ToString())
                {
                    table.Rows.Add(dataRow);
                    timeList.Add(d);
                    i++;
                }
                table.Rows[i][reader.GetString(0)] = reader.GetDouble(1);
            }
            reader.Close();
            m_dbConn.Dispose();
            goodRecCounter = table.Rows.Count;
        }
        //  Парсинг CSV файла лога
        private void parse_data(object sender, DoWorkEventArgs e)
		{
			List<string> list = new List<string>();
			try
			{    // Чтение файла построчно в список
				StreamReader streamReader = new StreamReader(new FileStream(csv_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.Default);
				string item;
				while ( (item = streamReader.ReadLine()) != null )
				{
               //     totRecCounter++;   // Общий счетчик строк для отображения на индикаторе прогресса
					list.Add(item); 
                }
                totRecCounter = list.Count;  //немного оптимизации, получим число записей сразу, без цикла
            }
			catch (Exception value)
			{
				MessageBox.Show("Cannot access the file. " + value.ToString());
				return;
			}
            
            char c = ';';   // Скорее всего эта инициализация не нужна
			string text = list[0];
            c = text.Split( new char[]{'"'} )[2][0];  // Получаем символ-разделитель элементов строки

            channel_names = new List<string>();  // Список имен тегов
            timeList = new List<DateTime>();     //
			byte flag = 0;
			foreach (string text2 in list)  // Цикл разбора списка на списки Имен тегов и Дата-Время
			{
				if (flag == 0) flag++;   // сделано для пропуска первой строки в списке - Заголовок лога
				else
				{
					string[] array = text2.Split( new char[]{c} );   // Получаем массив элементов из строки списка лога
					if (array.Length == 5 && array[0].IndexOf("\"\"") == -1)  // В строке должно быть 5 элементов и 
					{
						string txtTagName = array[0].Replace("\"", "");   //Получаем имя тега без слэшей
						string txtTimems = array[4];                     //Получаем значение время в мсек
						if (!channel_names.Contains(txtTagName) && !txtTagName.Equals("$RT_DIS$") && !txtTagName.Equals("$RT_COUNT$") && !txtTagName.Equals("$RT_OFF$"))
						{
                            channel_names.Add(txtTagName);  //Заносим в список имен если имя не служебный тег скады
						}
						if (!txtTagName.Equals("$RT_DIS$") && !txtTagName.Equals("$RT_COUNT$") && !txtTagName.Equals("$RT_OFF$"))
						{
                            txtTimems = Regex.Replace(txtTimems, "[^\\d]", "");//Очищаем от НЕ цифр
                            if (txtTimems.Length < 15)
							{
								int num2 = 15 - txtTimems.Length;
								for (int i = 0; i < num2; i++)
								{
									txtTimems += "0";
								}
							}
							try
							{
								double num3 = double.Parse(txtTimems);  // Конвертируем строку в число
								num3 /= 10000.0;
								num3 /= 1000000.0;
                                DateTime item2 = DateTime.FromOADate(num3);  //форматируем в дату-время
                                if (!timeList.Contains(item2))
								{
                               //     datapointCounter++;
                                    timeList.Add(item2);
								}
							}
							catch (Exception ex)
							{
                                MessageBox.Show("Error 1." + ex.ToString());
                            }
						}
					}
				}
			}   //EndOfForeach

            datapointCounter = timeList.Count;  //  получим число записей сразу, без цикла
            table = new DataTable();
			DataColumn dataColumn = new DataColumn();
			dataColumn.DataType = Type.GetType("System.String");
			dataColumn.ColumnName = "Date Time";
            table.Columns.Add(dataColumn);  //добавляем столбец Дата-Время
			foreach (string columnName in channel_names)  // Добавляем столбцы с тегами
			{
				dataColumn = new DataColumn();
				dataColumn.DataType = Type.GetType("System.Double");
				dataColumn.ColumnName = columnName;
                table.Columns.Add(dataColumn);
			}
			foreach (DateTime dateTime in timeList)  // Добавляем в таблицу строки из списка Даты-Времени
			{
				DataRow dataRow = table.NewRow();
				dataRow["Date Time"] = dateTime.ToString() + "." + dateTime.ToString("fff");
                table.Rows.Add(dataRow);
			}
			flag = 0;
			foreach (string text5 in list)   //
			{
				if (flag == 0) flag++;  // сделано для пропуска первой строки в списке - Заголовок лога
				else
				{
				//	flag++;   //Скорее всего это не нужно
					string[] array2 = text5.Split( new char[]{c} );  // Получаем массив элементов из строки списка лога
                    if (array2.Length == 5 && array2[0].IndexOf("\"\"") == -1)
					{
						string text6 = array2[0].Replace("\"", "");  //Получаем имя тега без слэшей
                        string text7 = array2[4];  //Получаем значение время в мсек
                        string text8 = array2[2];  //Получаем значение Тега
                        if (!text6.Equals("$RT_DIS$") && !text6.Equals("$RT_COUNT$") && !text6.Equals("$RT_OFF$"))
						{
							text7 = Regex.Replace(text7, "[^\\d]", "");
							if (text7.Length < 15)
							{
								int num2 = 15 - text7.Length;
								for (int i = 0; i < num2; i++)
								{
									text7 += "0";
								}
							}
							try
							{
								double num4 = double.Parse(text7);
								num4 /= 10000.0;
								num4 /= 1000000.0;
								DateTime item3 = DateTime.FromOADate(num4);
								double num5 = double.Parse(text8.Replace(string.Concat(Main.GetDecimalSep(text8)), CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator ?? ""));
								int index = timeList.IndexOf(item3);
                                table.Rows[index][text6] = num5;
                           //     goodRecCounter++;
							}
							catch (Exception ex)
							{
                                MessageBox.Show("Error 2. " + ex.ToString());
                            }
						}
					}
				}
            } //EndOfForeach
            goodRecCounter = table.Rows.Count;  //  получим число записей сразу, без цикла
        }

		// 
		private void dataparsing_complete(object sender, RunWorkerCompletedEventArgs e)
		{   if(goodRecCounter==0) { MessageBox.Show("File contains no data"); panel1.Hide(); progress_timer.Enabled = false; return; }
            dataGridView_data.DataSource = table;
            dataGridView_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			int numColor = 0;
			foreach (string text in channel_names)
			{
				PointPairList pointPairList = new PointPairList();
				int num2 = 0;
				foreach (object obj in table.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					if (dataRow[text].ToString() != "")
					{
						pointPairList.Add((double)num2, double.Parse(string.Concat(dataRow[text])));
					}
					else if (num2 > 0)
					{
						pointPairList.Add((double)num2, pointPairList[num2 - 1].Y);
					}
					else
					{
						pointPairList.Add((double)num2, double.NaN);
					}
					num2++;
				}
				YAxis yaxis = new YAxis(text);
                DTrend.GraphPane.YAxisList.Add(yaxis);
				yaxis.Title.IsVisible = true;
				yaxis.Type = AxisType.Linear;
				yaxis.Color = ColorTranslator.FromHtml(colors[numColor]);
				yaxis.Scale.FontSpec.Size = 10f;
				yaxis.Scale.FontSpec.FontColor = ColorTranslator.FromHtml(colors[numColor]);
				yaxis.IsVisible = true;
				yaxis.Scale.MaxAuto = true;
				yaxis.Scale.MinAuto = true;
				yaxis.MajorGrid.IsZeroLine = false;
				yaxis.MajorGrid.IsVisible = true;
				yaxis.MajorTic.IsInside = false;
				yaxis.MinorTic.IsInside = false;
				yaxis.MajorTic.IsOpposite = false;
				yaxis.MinorTic.IsOpposite = false;
				yaxis.Scale.Align = AlignP.Inside;
				yaxis.Title.FontSpec.Size = 10f;
				yaxis.Title.FontSpec.FontColor = ColorTranslator.FromHtml(colors[numColor]);  
				Color color = ColorTranslator.FromHtml(colors[numColor]);
				LineItem lineItem = DTrend.GraphPane.AddCurve(text, pointPairList, color, SymbolType.None);
				lineItem.Line.IsOptimizedDraw = true;
				lineItem.Line.Width = 2f;
				lineItem.YAxisIndex = DTrend.GraphPane.YAxisList.IndexOf(text);   
                dataGridView_data.Columns[text].DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(colors[numColor]);
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(text);
				toolStripMenuItem.ForeColor = ColorTranslator.FromHtml(colors[numColor]);
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("hide/show");
				toolStripMenuItem2.Checked = true;
				toolStripMenuItem2.ForeColor = ColorTranslator.FromHtml(colors[numColor]);
				toolStripMenuItem2.Click += toggleViewCurve;
                toolStripMenuItem2.Paint += toolMnuItemChSta;
                ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("change Y scale min/max");
				toolStripMenuItem3.Click += setYminMax;
				toolStripMenuItem.DropDownItems.Add(toolStripMenuItem2);
				toolStripMenuItem.DropDownItems.Add(toolStripMenuItem3);
                hideshowcurveMenuItem.DropDownItems.Add(toolStripMenuItem);
				numColor++;
            }  //EndOfForeach
            ToolStripMenuItem toolStripMnuItem = new ToolStripMenuItem("Show All/Hide All");
            toolStripMnuItem.Checked = true;
            hideshowcurveMenuItem.DropDownItems.Add(toolStripMnuItem);
            toolStripMnuItem.Click += toggleAllCurves;
            string[] array = new string[timeList.Count];

			int num3 = 0;
			foreach (DateTime dateTime in timeList)
			{
				array[num3] = dateTime.ToString();
				num3++;
			}
            DTrend.GraphPane.XAxis.Scale.Max = (double)num3;
            DTrend.GraphPane.XAxis.Scale.TextLabels = array;
            DTrend.GraphPane.XAxis.Type = AxisType.Text;
            DTrend.GraphPane.Title.IsVisible = false;
            DTrend.GraphPane.Legend.IsVisible = false;
            DTrend.GraphPane.AxisChange();
            DTrend.Refresh();
            panel1.Hide();
            loadingpanel.Visible = false;
            progress_timer.Enabled = false;
            Text = Application.ProductName + " v" + Application.ProductVersion + "   rec. " + goodRecCounter.ToString();
        }

		// 
		private void setYminMax(object sender, EventArgs e)
		{
			foreach (YAxis yaxis in DTrend.GraphPane.YAxisList)
			{
				if (yaxis.Title.Text.IndexOf(((ToolStripMenuItem)sender).OwnerItem.Text) != -1)
				{
					YScaleSettings yscaleSettings = new YScaleSettings(yaxis.Scale.Min, yaxis.Scale.Max, ((ToolStripMenuItem)sender).OwnerItem.Text);
					yscaleSettings.ShowDialog();
					if (yscaleSettings.set)
					{
						yaxis.Scale.MaxAuto = false;
						yaxis.Scale.MinAuto = false;
						yaxis.Scale.Max = yscaleSettings.max;
						yaxis.Scale.Min = yscaleSettings.min;
					}
				}
			}
            DTrend.AxisChange();
            DTrend.Refresh();
		}

        //
        private void toolMnuItemChSta(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = DTrend.GraphPane.CurveList[((ToolStripMenuItem)sender).OwnerItem.Text].IsVisible;
        }

        // Event handler for Dropdown MenuItem "show/hide ALL Curves"
        private void toggleAllCurves(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            foreach (YAxis yaxis in DTrend.GraphPane.YAxisList)
            {
                yaxis.IsVisible = ((ToolStripMenuItem)sender).Checked;
                DTrend.GraphPane.CurveList[yaxis.Title.Text].IsVisible = ((ToolStripMenuItem)sender).Checked;
            }
            DTrend.AxisChange();
            DTrend.Refresh();
        }
        // 
        private void toggleViewCurve(object sender, EventArgs e)
		{
			((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
            DTrend.GraphPane.CurveList[((ToolStripMenuItem)sender).OwnerItem.Text].IsVisible = ((ToolStripMenuItem)sender).Checked;
			foreach (YAxis yaxis in DTrend.GraphPane.YAxisList)
			{
				if (yaxis.Title.Text.IndexOf(((ToolStripMenuItem)sender).OwnerItem.Text) != -1)
				{
					yaxis.IsVisible = ((ToolStripMenuItem)sender).Checked;
				}
			}
            DTrend.AxisChange();
            DTrend.Refresh();
		}

		// 
		private static char GetDecimalSep(string input)
		{
			char[] array = input.ToCharArray();
			foreach (char c in array)
			{
				if (!char.IsNumber(c) && c != '-')
				{
					return c;
				}
			}
			return '.';
		}

		// 
		private void togleTableToolStripMenuItem_Click(object sender, EventArgs e)
		{
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            griddatascroll();

            if (!splitContainer1.Panel2Collapsed)
                togleTableToolStripMenuItem.BackColor = SystemColors.ControlDark;
            else
                togleTableToolStripMenuItem.BackColor = SystemColors.Control;
        }

		// 
		private void lockunlockvzoomMenuItem_Click(object sender, EventArgs e)
		{
            DTrend.IsEnableVZoom = !DTrend.IsEnableVZoom;

            if (!DTrend.IsEnableVZoom)
                lockunlockvzoomMenuItem.BackColor = SystemColors.ControlDark;
            else
                lockunlockvzoomMenuItem.BackColor = SystemColors.Control;
        }

		// Print proc
		private void printMenuItem_Click(object sender, EventArgs e)
		{
			using (PrintDocument printDocument = new PrintDocument())
			{
                printDlg.Document = printDocument; //yur
                printDlg.AllowSelection = true;  //yur
                printDlg.AllowSomePages = true;  //yur
                //
                printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
				printDocument.OriginAtMargins = false;
				printDocument.DefaultPageSettings.Landscape = true;
				printDocument.PrintPage += delegate(object _, PrintPageEventArgs o)
				{
					double num = 39.370078740157481;
					Image image = DTrend.MasterPane.GetImage();
					o.Graphics.DrawImage(image, (float)(1.0 * num), (float)(1.0 * num), (float)(27.0 * num), (float)(18.0 * num));
					o.HasMorePages = false;
				};
                if (printDlg.ShowDialog() == DialogResult.OK)  //yur
                    printDocument.Print();
			}
		}

		//
		private void aboutMenuItem_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.ShowDialog();
		}

		//
		private void ExitStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        // ToggleFullScreenButton Click
        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
            
        }

        // 
        private void ControlsStripMenuItem_Click(object sender, EventArgs e)
		{
            controlPanel.Visible = !controlPanel.Visible;
		}

		// 
		private void button_loclunlockvzoom_Click(object sender, EventArgs e)
		{
            DTrend.IsEnableVZoom = !DTrend.IsEnableVZoom;
		}

		// 
		private void button_resetzoompan_Click(object sender, EventArgs e)
		{
            DTrend.RestoreScale(DTrend.GraphPane);
		}

		// 
		private void button_zoomin_Click(object sender, EventArgs e)
		{
            DTrend.ZoomPane(DTrend.GraphPane, 0.9, default(PointF), false);
		}

		// 
		private void button_zoomout_Click(object sender, EventArgs e)
		{
            DTrend.ZoomPane(DTrend.GraphPane, 1.1, default(PointF), false);
		}

		// 
		private void button_panleft_Click(object sender, EventArgs e)
		{
			double num = (DTrend.GraphPane.XAxis.Scale.Max - DTrend.GraphPane.XAxis.Scale.Min) / 3.0;
            DTrend.GraphPane.XAxis.Scale.Min = DTrend.GraphPane.XAxis.Scale.Min - num;
            DTrend.GraphPane.XAxis.Scale.Max = DTrend.GraphPane.XAxis.Scale.Max - num;
            DTrend.AxisChange();
            DTrend.Refresh();
		}

		//
		private void button_panright_Click(object sender, EventArgs e)
		{
			double num = (DTrend.GraphPane.XAxis.Scale.Max - DTrend.GraphPane.XAxis.Scale.Min) / 3.0;
            DTrend.GraphPane.XAxis.Scale.Min = DTrend.GraphPane.XAxis.Scale.Min + num;
            DTrend.GraphPane.XAxis.Scale.Max = DTrend.GraphPane.XAxis.Scale.Max + num;
            DTrend.AxisChange();
            DTrend.Refresh();
		}

		//
		private void button_pantop_Click(object sender, EventArgs e)
		{
			double num = (DTrend.GraphPane.YAxis.Scale.Max - DTrend.GraphPane.YAxis.Scale.Min) / 3.0;
			foreach (YAxis yaxis in DTrend.GraphPane.YAxisList)
			{
				yaxis.Scale.Min = yaxis.Scale.Min + num;
				yaxis.Scale.Max = yaxis.Scale.Max + num;
			}
            DTrend.AxisChange();
            DTrend.Refresh();
		}

		//
		private void button_panbottom_Click(object sender, EventArgs e)
		{
			double num = (DTrend.GraphPane.YAxis.Scale.Max - DTrend.GraphPane.YAxis.Scale.Min) / 3.0;
			foreach (YAxis yaxis in DTrend.GraphPane.YAxisList)
			{
				yaxis.Scale.Min = yaxis.Scale.Min - num;
				yaxis.Scale.Max = yaxis.Scale.Max - num;
			}
            DTrend.AxisChange();
            DTrend.Refresh();
		}

		//
		private void button_print_Click(object sender, EventArgs e)
		{
			using (PrintDocument printDocument = new PrintDocument())
			{
				printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
				printDocument.OriginAtMargins = false;
				printDocument.DefaultPageSettings.Landscape = true;
				printDocument.PrintPage += delegate(object _, PrintPageEventArgs o)
				{
					double num = 39.370078740157481;
					Image image = DTrend.MasterPane.GetImage();
					o.Graphics.DrawImage(image, (float)(1.0 * num), (float)(1.0 * num), (float)(27.0 * num), (float)(18.0 * num));
					o.HasMorePages = false;
				};
				printDocument.Print();
			}
		}

		//
		private void DTrend_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
		{
            griddatascroll();
		}

		//
		private void griddatascroll()
		{
			if (!splitContainer1.Panel2Collapsed && dataGridView_data.Rows.Count > 0)
			{
				int num = (int)DTrend.GraphPane.XAxis.Scale.Min;
				if (num >= 0 && num <= dataGridView_data.Rows.Count)
				{
                    dataGridView_data.FirstDisplayedScrollingRowIndex = num;
					return;
				}
				if (num >= dataGridView_data.Rows.Count - 1)
				{
                    dataGridView_data.FirstDisplayedScrollingRowIndex = dataGridView_data.Rows.Count - 1;
				}
			}
		}

		//
		private void centerLoadingAnnimation()
		{
			if (loadingpanel.Visible)
			{
                loadingpictureBox.Location = new Point(loadingpanel.Width / 2 - loadingpictureBox.Width / 2, loadingpanel.Height / 2 - loadingpictureBox.Height / 2);
                progress_counter_textlabel.Location = new Point(loadingpanel.Width / 2 - progress_counter_textlabel.Width / 2, loadingpanel.Height / 2 - loadingpictureBox.Height / 2 + 66);
			}
		}

		//
		private void Main_Resize(object sender, EventArgs e)
		{
            centerLoadingAnnimation();
		}

		//
		private void progress_timer_Tick(object sender, EventArgs e)
		{
            progress_counter_textlabel.Text = string.Concat(new object[]
			{
                totRecCounter, " | ", //Общее количество записей в файле	
                datapointCounter, " | ", //
                goodRecCounter  //
            });
            centerLoadingAnnimation();
		}

		//
		private void loadingpanel_Paint(object sender, PaintEventArgs e)
		{
		}

		// Массив цветов для графиков
		public string[] colors = new string[]
		{
			"#00FF00",  // Lime ярко желто-зеленый
			"#0000FF",  // Blue ярко синий
			"#000000",  // Black
			"#FF0000",  // Red  
			"#85A900",  //
			"#006400",  // DarkGreen
			"#010067",  // DarkBlue #00008B
			"#95003A",  // светло-фиолетовый
			"#007DB5",  // светло-голубой
			"#FF00F6",  //
			"#FF937E",  //
			"#6A826C",  //
			"#FF029D",  //
			"#FE8900",  //
			"#7A4782",
			"#7E2DD2",			
            "#01FFFE",  // Cyan #00FFFF
			"#FF0056",
			"#A42400",
			"#00AE7E",
			"#683D3B",
			"#BDC6FF",
			"#263400",
			"#BDD393",
			"#00B917",
			"#9E008E",
			"#001544",
			"#C28C9F",
			"#FF74A3",
			"#01D0FF",
			"#004754",
			"#E56FFE",
			"#788231",
			"#0E4CA1",
			"#91D0CB",
			"#BE9970",
			"#968AE8",
			"#BB8800",
			"#43002C",
			"#DEFF74",
			"#00FFC6",
			"#FFE502",
			"#620E00",
			"#008F9C",
			"#98FF52",
			"#7544B1",
			"#B500FF",
			"#00FF78",
			"#FF6E41",
			"#005F39",
			"#6B6882",
			"#5FAD4E",
			"#A75740",
			"#A5FFD2",
			"#FFB167",
			"#009BFF",
			"#E85EBE"
		};

		// Имя открытого файла лога
		private string csv_file = "";
		//
		private SortedList<string, PointPairList> data_graph = new SortedList<string, PointPairList>();
		//
		private DataTable table;
		//
		private List<string> channel_names;
		//
		private List<DateTime> timeList;
		// Количество строк в файле лога
		private int totRecCounter;
		// Количество точек для графика
		private int datapointCounter;
		// Количество "полезных" записей  (равно общее кол-во строк минус заголовок минус записи служебных тегов Скады)
		private int goodRecCounter;

        private void SaveCSVMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_data.RowCount <= 0)    //test to see if the DataGridView has any rows
            {
                MessageBox.Show("DataGrid contains no data\nNothing to save :)");
                return;
            }
            var sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = "table.csv";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            string value = String.Empty;
            StreamWriter swOut = new StreamWriter(sfd.FileName, false);

            foreach (DataGridViewColumn dc in dataGridView_data.Columns)
            {
                value += dc.Name + ";";
            }
            value = value.Substring(0, value.Length - 1) + Environment.NewLine;
            swOut.Write(value);
            value = String.Empty;

            foreach (DataGridViewRow ddr in dataGridView_data.Rows)
            {
                if (ddr.IsNewRow)
                    continue;
                foreach (DataGridViewCell dc in ddr.Cells)
                {
                    if (dc.Value != null)
                    {
                        value += dc.Value.ToString() + ";";
                    }
                }
                value = value.Substring(0, value.Length - 1) + Environment.NewLine;
                swOut.Write(value);
                value = "";
            }
            swOut.Close();
        }
    }
}
