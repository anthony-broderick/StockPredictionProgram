using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPredictionProgram
{
    public class Candlestick
    {
        public string Date { get; set; }    // get and set the date of the candlestick data point as a string
        public int Index { get; set; }      // get and set the index of the candlestick
        public decimal Open { get; set; }   // get and set the opening price of the stock as a decimal (for money)
        public decimal High { get; set; }   // get and set the highest price of the stock as a decimal (for money)
        public decimal Low { get; set; }    // get and set the lowest price of the stock as a decimal (for money)
        public decimal Close { get; set; }  // get and set the closing price of the stock as a decimal (for money)
        public long Volume { get; set; }    // get and set the volume of shares traded as a long int
        public double GraphVolume { get; set; }    // get and set the volume of shares traded as a long int
    }
}
