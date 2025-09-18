using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPredictionProgram
{
    public class UsableCandlestick
    {
        public string Date { get; set; }    // get and set the date of the candlestick data point as a string
        public double Open { get; set; }   // get and set the opening price of the stock as a decimal (for money)
        public double High { get; set; }   // get and set the highest price of the stock as a decimal (for money)
        public double Low { get; set; }    // get and set the lowest price of the stock as a decimal (for money)
        public double Close { get; set; }  // get and set the closing price of the stock as a decimal (for money)
        public int DataPointCount { get; set; }
    }
}
