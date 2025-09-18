# StockPredictionProgram

The StockPredictionProgram is a C# .NET framework designed to let the user find 'Beauty' scores in candlestick charts.
It offers guidance into when to buy or sell given CSV stock data.

Language: C#
Platform: Visual Studio

## User Instructions

Begin by running the program. Then select the 'Load Candlestick Data' button. You can then select any CSV that contains
stock data (Date,Close/Last,Volume,Open,High,Low). A candlestick chart will be generated for the time range that you select.
You can then click on two points on the chart and it will get you the 'Beauty' score of the range between your two points.

## Beauty Score

The beauty score utilizes the fibonnaci sequence or golden ratio to determine if the range of candlesticks is beautiful.
The more points of the candlestick that fall into the fibonnaci percentage levels in that range, the higher the beauty score.
The beauty range is from 0-4, 4 being the 'most beautiful' with 0 being the 'least beautiful'. A higher beauty score indicates
that the candlesticks are following a strong trend. Seeing the candlesticks break below or above that selected range is a potential
indicator that the stock price will keep rising or falling.

## Installation

### Clone the repository:
git clone https://github.com/anthony-broderick/StockPredictionProgram.git
