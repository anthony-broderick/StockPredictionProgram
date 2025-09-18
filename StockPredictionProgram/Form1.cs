using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace StockPredictionProgram
{
    public partial class Form1 : Form
    {
        private List<Candlestick> candlestickData; // Class-level field
        private List<SmartCandlestick> smartCandlestickData;
        private List<UsableCandlestick> usableCandlestickData;
        private BindingSource bindingSource; // Class-level field
        public static string timeFrame = "ALL";
        public static bool loadedCandlesticks = false;
        public Form1(string filePath = null)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(filePath))
            {
                LoadCandlestickData(filePath);
            }
        }

        private void button_loadCandlesticks_Click(object sender, EventArgs e)
        {
            OpenAndLoadCandlesticks();
            loadedCandlesticks = true;
        }

        private void OpenAndLoadCandlesticks()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int iteration = 0;
                    foreach (string filePath in openFileDialog.FileNames)
                    {

                        if (iteration == 0)
                        {
                            this.Text = filePath;               // name the form after the file
                            LoadCandlestickData(filePath);      // load candlesticks to file
                            iteration++;
                            continue;
                        }


                        // create a new instance of Form1 for each file
                        Form1 form1 = new Form1(filePath);      // pass the file path to Form1
                        form1.LoadCandlestickData(filePath);    // load candlesticks to file
                        form1.Text = filePath;                  // name the form after the file

                        // Show Form1 as a new form
                        form1.Show();
                    }
                }
            }
        }

        // iterate through the data, adding candlesticks with the members listed in our candlestick class
        private List<Candlestick> LoadCandlestickData(string filePath)
        {
            candlestickData = new List<Candlestick>();  // create new list of candlesticks to store in candlestickData
            try
            {
                using (var reader = new StreamReader(filePath)) // read through file
                {
                    char[] delimiters = { '\\', ',', '"', '$' };     // filter out junk from date
                    string line = reader.ReadLine(); // Skip the header line
                    var index = 0;
                    while ((line = reader.ReadLine()) != null)  // step through each line
                    {
                        var values = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // remove unneeded entries
                        try
                        {
                            DateTime parsedDate;
                            string[] dateFormats = { "yyyy-MM-dd", "M/d/yyyy", "MM/dd/yyyy" };  // Add both formats to try parsing

                            // Attempt to parse date using multiple formats
                            bool isDateParsed = DateTime.TryParseExact(values[0], dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

                            if (!isDateParsed)
                            {
                                Console.WriteLine($"Invalid date format: {values[0]}");
                                continue;  // Skip to the next line if date is invalid
                            }
                            var open = Math.Round(100 * decimal.Parse(values[3], CultureInfo.InvariantCulture)) / 100;      // parse through the open values, multiplying and dividing them by 100 to ensure proper rounding
                            var high = Math.Round(100 * decimal.Parse(values[4], CultureInfo.InvariantCulture)) / 100;      // parse through the high values, multiplying and dividing them by 100 to ensure proper rounding
                            var low = Math.Round(100 * decimal.Parse(values[5], CultureInfo.InvariantCulture)) / 100;       // parse through the low values, multiplying and dividing them by 100 to ensure proper rounding
                            var close = Math.Round(100 * decimal.Parse(values[1], CultureInfo.InvariantCulture)) / 100;     // parse through the close values, multiplying and dividing them by 100 to ensure proper rounding
                            var volume = long.Parse(values[2]);                                                             // parse through the volume values, storing them in volume

                            var candlestick = new Candlestick   // create a new candlestick from Candlestick.cs
                            {
                                Date = parsedDate.ToString("yyyy-MM-dd"),   // set candlestick's date
                                Index = index,
                                Open = open,                                // set candlestick's open
                                High = high,                                // set candlestick's high
                                Low = low,                                  // set candlestick's low
                                Close = close,                              // set candlestick's close
                                Volume = volume,                            // set candlestick's volume
                            };
                            index++;
                            candlestickData.Add(candlestick);               // add the candlestick we created to the list of candlesticks
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Invalid format: {string.Join(", ", values)}");      // error catch
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);      // error catch
            }

            // Check if the data is reversed
            if (DateTime.Parse(candlestickData.First().Date) > DateTime.Parse(candlestickData.Last().Date))
            {
                // Reverse the list to maintain proper order
                candlestickData.Reverse();
            }


            BindCandlesticks();

            return candlestickData;
        }

        private void BindCandlesticks()
        {
            bindingSource = new BindingSource();            // create a new instance of bindingSource
            var latestDate = DateTime.Now;
            var startDate = candlestickData.Min(c => DateTime.Parse(c.Date));
            var filteredData = candlestickData;
            int maxHigh;
            int minLow;
            long maxVolume;
            switch (timeFrame)
            {
                case "1M":
                    chart_candlesticks.Series["Series_candlesticks"].XValueMember = "Date";
                    chart_candlesticks.Series["Series_volume"].XValueMember = "Date";
                    startDate = latestDate.AddMonths(-1);
                    filteredData = candlestickData.Where(c => DateTime.Parse(c.Date) >= startDate && DateTime.Parse(c.Date) <= latestDate).ToList();
                    maxHigh = (int)Math.Ceiling(1.05 * (int)filteredData.Max(c => c.High));
                    minLow = (int)Math.Floor(0.95 * (int)filteredData.Min(c => c.Low));
                    maxVolume = filteredData.Max(c => c.Volume);
                    foreach (var candlestick in filteredData)
                    {
                        candlestick.GraphVolume = ((double)candlestick.Volume / (double)maxVolume) * (1.05 * ((double)maxHigh - (double)minLow) * 0.25) + minLow;
                    }
                    break;
                case "6M":
                    chart_candlesticks.Series["Series_candlesticks"].XValueMember = "Date";
                    chart_candlesticks.Series["Series_volume"].XValueMember = "Date";
                    startDate = latestDate.AddMonths(-6);
                    filteredData = candlestickData.Where(c => DateTime.Parse(c.Date) >= startDate && DateTime.Parse(c.Date) <= latestDate).ToList();
                    maxHigh = (int)Math.Ceiling(1.05 * (int)filteredData.Max(c => c.High));
                    minLow = (int)Math.Floor(0.95 * (int)filteredData.Min(c => c.Low));
                    maxVolume = filteredData.Max(c => c.Volume);
                    foreach (var candlestick in filteredData)
                    {
                        candlestick.GraphVolume = ((double)candlestick.Volume / (double)maxVolume) * (1.05 * ((double)maxHigh - (double)minLow) * 0.25) + minLow;
                    }
                    break;
                case "YTD":
                    chart_candlesticks.Series["Series_candlesticks"].XValueMember = "Date";
                    chart_candlesticks.Series["Series_volume"].XValueMember = "Date";
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    filteredData = candlestickData.Where(c => DateTime.Parse(c.Date) >= startDate && DateTime.Parse(c.Date) <= latestDate).ToList();
                    maxHigh = (int)Math.Ceiling(1.05 * (int)filteredData.Max(c => c.High));
                    minLow = (int)Math.Floor(0.95 * (int)filteredData.Min(c => c.Low));
                    maxVolume = filteredData.Max(c => c.Volume);
                    foreach (var candlestick in filteredData)
                    {
                        candlestick.GraphVolume = ((double)candlestick.Volume / (double)maxVolume) * (1.05 * ((double)maxHigh - (double)minLow) * 0.25) + minLow;
                    }
                    break;
                case "1Y":
                    chart_candlesticks.Series["Series_candlesticks"].XValueMember = "Date";
                    chart_candlesticks.Series["Series_volume"].XValueMember = "Date";
                    startDate = latestDate.AddYears(-1);
                    filteredData = candlestickData.Where(c => DateTime.Parse(c.Date) >= startDate && DateTime.Parse(c.Date) <= latestDate).ToList();
                    maxHigh = (int)Math.Ceiling(1.05 * (int)filteredData.Max(c => c.High));
                    minLow = (int)Math.Floor(0.95 * (int)filteredData.Min(c => c.Low));
                    maxVolume = filteredData.Max(c => c.Volume);
                    foreach (var candlestick in filteredData)
                    {
                        candlestick.GraphVolume = ((double)candlestick.Volume / (double)maxVolume) * (1.05 * ((double)maxHigh - (double)minLow) * 0.25) + minLow;
                    }
                    break;
                case "5Y":
                    chart_candlesticks.Series["Series_candlesticks"].XValueMember = "Date";
                    chart_candlesticks.Series["Series_volume"].XValueMember = "Date";
                    startDate = latestDate.AddYears(-5);
                    filteredData = candlestickData.Where(c => DateTime.Parse(c.Date) >= startDate && DateTime.Parse(c.Date) <= latestDate).ToList();
                    maxHigh = (int)Math.Ceiling(1.05 * (int)filteredData.Max(c => c.High));
                    minLow = (int)Math.Floor(0.95 * (int)filteredData.Min(c => c.Low));
                    maxVolume = filteredData.Max(c => c.Volume);
                    foreach (var candlestick in filteredData)
                    {
                        candlestick.GraphVolume = ((double)candlestick.Volume / (double)maxVolume) * (1.05 * ((double)maxHigh - (double)minLow) * 0.25) + minLow;
                    }
                    break;
                default:
                    chart_candlesticks.Series["Series_candlesticks"].XValueMember = "Date";
                    chart_candlesticks.Series["Series_volume"].XValueMember = "Date";
                    maxHigh = (int)Math.Ceiling(1.05 * (int)filteredData.Max(c => c.High));
                    minLow = (int)Math.Floor(0.95 * (int)filteredData.Min(c => c.Low));
                    maxVolume = filteredData.Max(c => c.Volume);
                    foreach (var candlestick in filteredData)
                    {
                        candlestick.GraphVolume = ((double)candlestick.Volume / (double)maxVolume) * (1.05 * ((double)maxHigh - (double)minLow) * 0.25) + minLow;
                    }
                    break;
            }
            bindingSource.DataSource = filteredData;     // bind our candlestick list to our data source
            chart_candlesticks.DataSource = bindingSource;
            chart_candlesticks.DataBind();
            NormalizeChart(filteredData, chart_candlesticks);
            GetDataPoints();
        }

        private void NormalizeChart(List<Candlestick> data, Chart chart)
        {
            // Calculate the min and max values of OHLC
            double min = data.Min(c => Math.Min(Math.Min((double)c.Open, (double)c.High), Math.Min((double)c.Low, (double)c.Close)));
            double max = data.Max(c => Math.Max(Math.Max((double)c.Open, (double)c.High), Math.Max((double)c.Low, (double)c.Close)));

            int rangeMin = (int)Math.Floor(0.95 * min);             // round the min to an integer from double and set the min to be slightly lower
            int rangeMax = (int)Math.Ceiling(1.05 * max);           // round the max to an integer from double and set the max to be slightly higher
            int rangeInterval = (int)Math.Ceiling((max - min) / 6); // round the range from max to min and divide into clear intervals to step through on the y axis

            // Set y-axis range
            chart.ChartAreas["ChartArea_candlesticks"].AxisY.Minimum = rangeMin;
            chart.ChartAreas["ChartArea_candlesticks"].AxisY.Maximum = rangeMax;

            // Ensure y-axis labels are in whole numbers
            chart.ChartAreas["ChartArea_candlesticks"].AxisY.Interval = rangeInterval;

        }

        private void ClearChart()
        {
            chart_candlesticks.Annotations.Clear();
        }

        private void radioButton_1M_CheckedChanged(object sender, EventArgs e)
        {
            timeFrame = "1M";
            if (loadedCandlesticks) { BindCandlesticks(); }
            ClearChart();
        }

        private void radioButton_6M_CheckedChanged(object sender, EventArgs e)
        {
            timeFrame = "6M";
            if (loadedCandlesticks) { BindCandlesticks(); }
            ClearChart();
        }

        private void radioButton_YTD_CheckedChanged(object sender, EventArgs e)
        {
            timeFrame = "YTD";
            if (loadedCandlesticks) { BindCandlesticks(); }
            ClearChart();
        }

        private void radioButton_1Y_CheckedChanged(object sender, EventArgs e)
        {
            timeFrame = "1Y";
            if (loadedCandlesticks) { BindCandlesticks(); }
            ClearChart();
        }

        private void radioButton_5Y_CheckedChanged(object sender, EventArgs e)
        {
            timeFrame = "5Y";
            if (loadedCandlesticks) { BindCandlesticks(); }
            ClearChart();
        }

        private void radioButtonALL_CheckedChanged(object sender, EventArgs e)
        {
            timeFrame = "ALL";
            if (loadedCandlesticks) { BindCandlesticks(); }
            ClearChart();
        }

        private Point startPoint;  // Starting point of the rectangle
        private List<LineAnnotation> fibLevels = new List<LineAnnotation>(); // Store the fibonacci levels
        private void chart_candlesticks_MouseMove(object sender, MouseEventArgs e)
        {

            if (loadedCandlesticks)
            {
                chart_candlesticks.ChartAreas[0].CursorX.SetCursorPixelPosition(e.Location, true);
                chart_candlesticks.ChartAreas[0].CursorY.SetCursorPixelPosition(e.Location, true);
                chart_candlesticks.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dash;
                chart_candlesticks.ChartAreas[0].CursorY.LineDashStyle = ChartDashStyle.Dash;
            }


        }

        private void GetDataPoints()
        {
            var series = chart_candlesticks.Series["Series_candlesticks"];

            usableCandlestickData = new List<UsableCandlestick>();  // create new list of candlesticks to store in candlestickData

            // Loop through the data points of this specific series
            for (int i = 0; i < series.Points.Count; i++)
            {
                var point = series.Points[i];

                var open = point.YValues[0];    // Assuming that Open is stored in the first Y value
                var high = point.YValues[1];    // Assuming that High is stored in the second Y value
                var low = point.YValues[2];     // Assuming that Low is stored in the third Y value
                var close = point.YValues[3];   // Assuming that Close is stored in the fourth Y value
                var candlestickDate = point.AxisLabel;

                var usableCandlestick = new UsableCandlestick   // create a new candlestick from UsableCandlestick.cs
                {
                    Date = candlestickDate,   // set candlestick's date
                    Open = open,                                // set candlestick's open
                    High = high,                                // set candlestick's high
                    Low = low,                                  // set candlestick's low
                    Close = close,                              // set candlestick's close
                    DataPointCount = i
                };
                usableCandlestickData.Add(usableCandlestick);

            }
        }
        private void GetCandlestickByXPosition(int roundedClickPosition)
        {

            var candlestick = usableCandlestickData[roundedClickPosition];

            label_date.Text = "Date: " + candlestick.Date;
            label_high.Text = "High: " + candlestick.High.ToString();
            label_low.Text = "Low: " + candlestick.Low.ToString();
            label_open.Text = "Open: " + candlestick.Open.ToString();
            label_close.Text = "Close: " + candlestick.Close.ToString();
            // label_volume.Text = "Volume: " + candlestick.Volume.ToString();


        }

        private void chart_candlesticks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // Only start drawing on left-click
            {
                // Record the starting point of the rectangle (where the mouse is clicked)
                startPoint = e.Location;
            }
        }

        private List<int> roundedClickPositions = new List<int>();

        private void chart_candlesticks_MouseUp(object sender, MouseEventArgs e)
        {

            double clickPosition = chart_candlesticks.ChartAreas[0].AxisX.PixelPositionToValue(e.X); // Assuming the X position of the mouse click represents the X axis in the chart
            int roundedClickPosition = (int)Math.Round(clickPosition);

            // Find the UsableCandlestick whose XPosition is closest to the clickPosition
            GetCandlestickByXPosition(roundedClickPosition);

            // Add the rounded click position to the list
            roundedClickPositions.Add(roundedClickPosition);

            // If we have two rounded click positions, call the desired function and clear the list
            if (roundedClickPositions.Count == 2)
            {
                // Call the function with the two positions (you can adjust this as needed)
                HandleTwoClickPositions(roundedClickPositions[0], roundedClickPositions[1]);

                // Clear the list of click positions
                roundedClickPositions.Clear();
            }

        }

        private void HandleTwoClickPositions(int clickPosition1, int clickPosition2)
        {
            int startPosition = Math.Min(clickPosition1, clickPosition2);
            int endPosition = Math.Max(clickPosition1, clickPosition2);
            var filteredData = usableCandlestickData.Where(data => data.DataPointCount >= startPosition && data.DataPointCount <= endPosition).ToList();
            FibonacciLevels(filteredData);
        }

        private void FibonacciLevels(List<UsableCandlestick> filteredData)
        {
            int waveStartIndex = filteredData.Min(data => data.DataPointCount);
            int waveEndIndex = filteredData.Max(data => data.DataPointCount);
            var startCandlestick = filteredData.FirstOrDefault(data => data.DataPointCount == waveStartIndex);
            var endCandlestick = filteredData.FirstOrDefault(data => data.DataPointCount == waveEndIndex);
            decimal waveStartPrice;
            decimal waveEndPrice;
            bool trendUp = true;

            if (startCandlestick.High < endCandlestick.High)
            {
                waveStartPrice = (decimal)startCandlestick.Low;
                waveEndPrice = (decimal)endCandlestick.High;
            }
            else
            {
                waveStartPrice = (decimal)startCandlestick.High;
                waveEndPrice = (decimal)endCandlestick.Low;
                trendUp = false;
            }

            decimal waveDifference = waveEndPrice - waveStartPrice;
            decimal[] fibonacciLevels = new decimal[] { 100, 76.4m, 61.8m, 50m, 31.2m, 23.6m, 0m };

            List<decimal> computedLevels = new List<decimal>();

            foreach (decimal level in fibonacciLevels)
            {
                // Calculate the price at the Fibonacci level based on the percentage
                decimal fibLevelPrice = waveEndPrice - (waveDifference * (level / 100));

                // Add the calculated Fibonacci price to the computedLevels list
                computedLevels.Add(fibLevelPrice);
            }

            ComputeCandlestickBeauty(filteredData, waveStartIndex, waveEndIndex, computedLevels, waveEndPrice);

        }

        private void ComputeCandlestickBeauty(List<UsableCandlestick> filteredData, int waveStartIndex, int waveEndIndex, List<decimal> computedLevels, decimal waveEndprice)
        {
            // Initialize variables for total beauty score and count of candlesticks
            int totalBeautyScore = 0;
            int candlestickCount = 0;
            decimal beautyTolerance = 0.015m;
            List<int> beautyScores = new List<int>();

            // Loop through each candlestick in the range
            for (int i = waveStartIndex + 1; i < waveEndIndex; i++)
            {
                // Get the current candlestick
                UsableCandlestick currentCandlestick = filteredData.FirstOrDefault(c => c.DataPointCount == i);

                if (currentCandlestick != null)
                {
                    // Initialize the beauty count for this candlestick
                    int beautyCount = 0;

                    // Check if any part of the candlestick (Open, High, Low, Close) falls within 1.5% of any Fibonacci level
                    decimal[] parts = { (decimal)currentCandlestick.Open, (decimal)currentCandlestick.High, (decimal)currentCandlestick.Low, (decimal)currentCandlestick.Close };

                    foreach (var part in parts)
                    {
                        foreach (var fibLevelPrice in computedLevels)
                        {
                            // Calculate the 1.5% tolerance range for this Fibonacci price level
                            decimal lowerBound = fibLevelPrice - (fibLevelPrice * (beautyTolerance)); // 1.5% below the Fibonacci level
                            decimal upperBound = fibLevelPrice + (fibLevelPrice * (beautyTolerance)); // 1.5% above the Fibonacci level

                            // Check if the part is within the tolerance range
                            if (part >= lowerBound && part <= upperBound)
                            {
                                beautyCount++; // Increment beauty count if the part falls within the 1.5% range
                                break; // No need to check other Fibonacci levels for this part
                            }
                        }
                    }

                    // Store the beauty score for this candlestick in the list
                    beautyScores.Add(beautyCount);
                }
            }

            // Calculate the average beauty score
            decimal averageBeautyScore = (decimal)beautyScores.DefaultIfEmpty(0).Average();
            MessageBox.Show("Average Beauty Score: " + averageBeautyScore.ToString("F2"));
        }
    }
}
