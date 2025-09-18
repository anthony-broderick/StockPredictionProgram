using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPredictionProgram
{
    public class SmartCandlestick : Candlestick
    {
        
        private const decimal HammerThresholdPercentage = 0.30m;
        private const decimal NeutralThresholdPercentage = 0.10m;
        private const decimal DojiThresholdPercentage = 0.01m;
        public decimal TotalRange { get { return High - Low; } }
        public decimal BodyRange { get { return Math.Abs(Open - Close); } }
        public decimal TopPrice { get { return Math.Max(Open, Close); } }
        public decimal BottomPrice { get { return Math.Min(Open, Close); } }
        public decimal UpperTail { get { return High - TopPrice; } }
        public decimal LowerTail { get { return Low - BottomPrice; } }
        public bool IsBullish { get { return Open < Close; } }
        public bool IsBearish { get { return Open > Close; } }
        public bool IsNeutral { get { return BodyRange < (TotalRange * NeutralThresholdPercentage); } }
        public bool IsMarubozu { get { return BodyRange == TotalRange; } }
        public bool IsHammer { get { return UpperTail < (TotalRange * HammerThresholdPercentage) && BodyRange < (LowerTail * HammerThresholdPercentage); } }
        public bool IsDoji { get { return BodyRange < (TotalRange * DojiThresholdPercentage); } }
        public bool IsDragonflyDoji { get { return IsDoji && UpperTail < (TotalRange * DojiThresholdPercentage); } }
        public bool IsGravestoneDoji { get { return IsDoji && LowerTail < (TotalRange * DojiThresholdPercentage); } }
        
    }
}
