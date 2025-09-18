namespace StockPredictionProgram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_candlesticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_loadCandlesticks = new System.Windows.Forms.Button();
            this.radioButton_1M = new System.Windows.Forms.RadioButton();
            this.groupBox_timeFrame = new System.Windows.Forms.GroupBox();
            this.radioButtonALL = new System.Windows.Forms.RadioButton();
            this.radioButton_5Y = new System.Windows.Forms.RadioButton();
            this.radioButton_1Y = new System.Windows.Forms.RadioButton();
            this.radioButton_YTD = new System.Windows.Forms.RadioButton();
            this.radioButton_6M = new System.Windows.Forms.RadioButton();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox_candlestickData = new System.Windows.Forms.GroupBox();
            this.label_date = new System.Windows.Forms.Label();
            this.label_high = new System.Windows.Forms.Label();
            this.label_low = new System.Windows.Forms.Label();
            this.label_open = new System.Windows.Forms.Label();
            this.label_close = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlesticks)).BeginInit();
            this.groupBox_timeFrame.SuspendLayout();
            this.groupBox_candlestickData.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart_candlesticks
            // 
            this.chart_candlesticks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_candlesticks.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Empty;
            chartArea3.Name = "ChartArea_candlesticks";
            this.chart_candlesticks.ChartAreas.Add(chartArea3);
            this.chart_candlesticks.Cursor = System.Windows.Forms.Cursors.Cross;
            legend3.Name = "Legend1";
            this.chart_candlesticks.Legends.Add(legend3);
            this.chart_candlesticks.Location = new System.Drawing.Point(0, 70);
            this.chart_candlesticks.Name = "chart_candlesticks";
            this.chart_candlesticks.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart_candlesticks.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))),
        System.Drawing.Color.SteelBlue};
            series5.ChartArea = "ChartArea_candlesticks";
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Series_volume";
            series5.XValueMember = "Date";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YValueMembers = "GraphVolume";
            series6.ChartArea = "ChartArea_candlesticks";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series6.CustomProperties = "PriceDownColor=Firebrick, PriceUpColor=Green";
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series6.IsVisibleInLegend = false;
            series6.LabelForeColor = System.Drawing.Color.Empty;
            series6.Legend = "Legend1";
            series6.Name = "Series_candlesticks";
            series6.XValueMember = "Date";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.YValueMembers = "High, Low, Open, Close, Index";
            series6.YValuesPerPoint = 5;
            this.chart_candlesticks.Series.Add(series5);
            this.chart_candlesticks.Series.Add(series6);
            this.chart_candlesticks.Size = new System.Drawing.Size(1409, 621);
            this.chart_candlesticks.TabIndex = 0;
            this.chart_candlesticks.Text = "chart_candlesticks";
            this.chart_candlesticks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_candlesticks_MouseDown);
            this.chart_candlesticks.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_candlesticks_MouseMove);
            this.chart_candlesticks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_candlesticks_MouseUp);
            // 
            // button_loadCandlesticks
            // 
            this.button_loadCandlesticks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_loadCandlesticks.Location = new System.Drawing.Point(18, 5);
            this.button_loadCandlesticks.Name = "button_loadCandlesticks";
            this.button_loadCandlesticks.Size = new System.Drawing.Size(180, 23);
            this.button_loadCandlesticks.TabIndex = 1;
            this.button_loadCandlesticks.Text = "Load Candlestick Data";
            this.button_loadCandlesticks.UseVisualStyleBackColor = true;
            this.button_loadCandlesticks.Click += new System.EventHandler(this.button_loadCandlesticks_Click);
            // 
            // radioButton_1M
            // 
            this.radioButton_1M.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_1M.AutoSize = true;
            this.radioButton_1M.Location = new System.Drawing.Point(6, 14);
            this.radioButton_1M.Name = "radioButton_1M";
            this.radioButton_1M.Size = new System.Drawing.Size(32, 23);
            this.radioButton_1M.TabIndex = 8;
            this.radioButton_1M.Text = "1M";
            this.radioButton_1M.UseVisualStyleBackColor = true;
            this.radioButton_1M.CheckedChanged += new System.EventHandler(this.radioButton_1M_CheckedChanged);
            // 
            // groupBox_timeFrame
            // 
            this.groupBox_timeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_timeFrame.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_timeFrame.Controls.Add(this.radioButtonALL);
            this.groupBox_timeFrame.Controls.Add(this.radioButton_5Y);
            this.groupBox_timeFrame.Controls.Add(this.radioButton_1Y);
            this.groupBox_timeFrame.Controls.Add(this.radioButton_YTD);
            this.groupBox_timeFrame.Controls.Add(this.radioButton_6M);
            this.groupBox_timeFrame.Controls.Add(this.radioButton_1M);
            this.groupBox_timeFrame.Location = new System.Drawing.Point(12, 25);
            this.groupBox_timeFrame.Name = "groupBox_timeFrame";
            this.groupBox_timeFrame.Size = new System.Drawing.Size(259, 39);
            this.groupBox_timeFrame.TabIndex = 9;
            this.groupBox_timeFrame.TabStop = false;
            // 
            // radioButtonALL
            // 
            this.radioButtonALL.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonALL.AutoSize = true;
            this.radioButtonALL.Checked = true;
            this.radioButtonALL.Location = new System.Drawing.Point(199, 14);
            this.radioButtonALL.Name = "radioButtonALL";
            this.radioButtonALL.Size = new System.Drawing.Size(36, 23);
            this.radioButtonALL.TabIndex = 13;
            this.radioButtonALL.TabStop = true;
            this.radioButtonALL.Text = "ALL";
            this.radioButtonALL.UseVisualStyleBackColor = true;
            this.radioButtonALL.CheckedChanged += new System.EventHandler(this.radioButtonALL_CheckedChanged);
            // 
            // radioButton_5Y
            // 
            this.radioButton_5Y.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_5Y.AutoSize = true;
            this.radioButton_5Y.Location = new System.Drawing.Point(163, 14);
            this.radioButton_5Y.Name = "radioButton_5Y";
            this.radioButton_5Y.Size = new System.Drawing.Size(30, 23);
            this.radioButton_5Y.TabIndex = 12;
            this.radioButton_5Y.Text = "5Y";
            this.radioButton_5Y.UseVisualStyleBackColor = true;
            this.radioButton_5Y.CheckedChanged += new System.EventHandler(this.radioButton_5Y_CheckedChanged);
            // 
            // radioButton_1Y
            // 
            this.radioButton_1Y.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_1Y.AutoSize = true;
            this.radioButton_1Y.Location = new System.Drawing.Point(127, 14);
            this.radioButton_1Y.Name = "radioButton_1Y";
            this.radioButton_1Y.Size = new System.Drawing.Size(30, 23);
            this.radioButton_1Y.TabIndex = 11;
            this.radioButton_1Y.Text = "1Y";
            this.radioButton_1Y.UseVisualStyleBackColor = true;
            this.radioButton_1Y.CheckedChanged += new System.EventHandler(this.radioButton_1Y_CheckedChanged);
            // 
            // radioButton_YTD
            // 
            this.radioButton_YTD.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_YTD.AutoSize = true;
            this.radioButton_YTD.Location = new System.Drawing.Point(82, 14);
            this.radioButton_YTD.Name = "radioButton_YTD";
            this.radioButton_YTD.Size = new System.Drawing.Size(39, 23);
            this.radioButton_YTD.TabIndex = 10;
            this.radioButton_YTD.Text = "YTD";
            this.radioButton_YTD.UseVisualStyleBackColor = true;
            this.radioButton_YTD.CheckedChanged += new System.EventHandler(this.radioButton_YTD_CheckedChanged);
            // 
            // radioButton_6M
            // 
            this.radioButton_6M.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_6M.AutoSize = true;
            this.radioButton_6M.Location = new System.Drawing.Point(44, 14);
            this.radioButton_6M.Name = "radioButton_6M";
            this.radioButton_6M.Size = new System.Drawing.Size(32, 23);
            this.radioButton_6M.TabIndex = 9;
            this.radioButton_6M.Text = "6M";
            this.radioButton_6M.UseVisualStyleBackColor = true;
            this.radioButton_6M.CheckedChanged += new System.EventHandler(this.radioButton_6M_CheckedChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(1412, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 691);
            this.vScrollBar1.TabIndex = 10;
            // 
            // groupBox_candlestickData
            // 
            this.groupBox_candlestickData.Controls.Add(this.label_close);
            this.groupBox_candlestickData.Controls.Add(this.label_open);
            this.groupBox_candlestickData.Controls.Add(this.label_low);
            this.groupBox_candlestickData.Controls.Add(this.label_high);
            this.groupBox_candlestickData.Controls.Add(this.label_date);
            this.groupBox_candlestickData.Location = new System.Drawing.Point(295, 10);
            this.groupBox_candlestickData.Name = "groupBox_candlestickData";
            this.groupBox_candlestickData.Size = new System.Drawing.Size(1098, 54);
            this.groupBox_candlestickData.TabIndex = 11;
            this.groupBox_candlestickData.TabStop = false;
            this.groupBox_candlestickData.Text = "Candlestick Data";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(7, 29);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(36, 13);
            this.label_date.TabIndex = 0;
            this.label_date.Text = "Date: ";
            // 
            // label_high
            // 
            this.label_high.AutoSize = true;
            this.label_high.Location = new System.Drawing.Point(176, 29);
            this.label_high.Name = "label_high";
            this.label_high.Size = new System.Drawing.Size(35, 13);
            this.label_high.TabIndex = 1;
            this.label_high.Text = "High: ";
            // 
            // label_low
            // 
            this.label_low.AutoSize = true;
            this.label_low.Location = new System.Drawing.Point(348, 29);
            this.label_low.Name = "label_low";
            this.label_low.Size = new System.Drawing.Size(33, 13);
            this.label_low.TabIndex = 2;
            this.label_low.Text = "Low: ";
            // 
            // label_open
            // 
            this.label_open.AutoSize = true;
            this.label_open.Location = new System.Drawing.Point(537, 29);
            this.label_open.Name = "label_open";
            this.label_open.Size = new System.Drawing.Size(39, 13);
            this.label_open.TabIndex = 3;
            this.label_open.Text = "Open: ";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Location = new System.Drawing.Point(742, 29);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(39, 13);
            this.label_close.TabIndex = 4;
            this.label_close.Text = "Close: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 691);
            this.Controls.Add(this.groupBox_candlestickData);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.button_loadCandlesticks);
            this.Controls.Add(this.chart_candlesticks);
            this.Controls.Add(this.groupBox_timeFrame);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlesticks)).EndInit();
            this.groupBox_timeFrame.ResumeLayout(false);
            this.groupBox_timeFrame.PerformLayout();
            this.groupBox_candlestickData.ResumeLayout(false);
            this.groupBox_candlestickData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_candlesticks;
        private System.Windows.Forms.Button button_loadCandlesticks;
        private System.Windows.Forms.RadioButton radioButton_1M;
        private System.Windows.Forms.GroupBox groupBox_timeFrame;
        private System.Windows.Forms.RadioButton radioButtonALL;
        private System.Windows.Forms.RadioButton radioButton_5Y;
        private System.Windows.Forms.RadioButton radioButton_1Y;
        private System.Windows.Forms.RadioButton radioButton_YTD;
        private System.Windows.Forms.RadioButton radioButton_6M;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox groupBox_candlestickData;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.Label label_open;
        private System.Windows.Forms.Label label_low;
        private System.Windows.Forms.Label label_high;
        private System.Windows.Forms.Label label_date;
    }
}

