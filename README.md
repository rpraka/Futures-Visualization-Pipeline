# Futures-Visualization-Pipeline
A comprehensive set of techniques and tools to collect, process and visualize financial Futures data from scratch.

The pipeline includes a special section on wrangling non-time indexed data (**tick/range/volume charts**). Such data is especially important since time-based charts exhibit undesirable statistical properties and over-sample low activity periods while under-sampling high activity periods (see Easley, Lopez de Prado, and O’Hara [2012](https://www.stern.nyu.edu/sites/default/files/assets/documents/con_035928.pdf)).

## Data Collection
When it comes to strategy development, collecting large amounts of reliable data is of utmost importance. Several resources exist to collect intra-day historical data for equity markets at almost no cost (yfinance, alpaca, polygon.io, etc.). However, APIs for intra-day Futures data are quite expensive, especially for beginners interested in getting their feet wet.

Here, I present a completely free option to extract high frequency data using the NinjaTrader 8 platform. This approach works in both the free evaluation software as well as the paid version.

### DataSaver
Due to the lack of free options for scraping NT 8 data into an easily digestible format, I am releasing my own called DataSaver. It allows the exportation of all chart data, including indicators - which prevents computational discrepancies from occuring between your backtesting and live trading environments.

Simply import the zipped datasaver.cs file to begin.

Open a standard time-based or non-time based chart and add any desired indicators and metrics. Using a playback connection on historical market data is my preferred method of data collection. The charts support up to a single second of temporal resolution, and can retrieve up to 90 days of order flow data. Then, add the DataSaver indicator to the target chart and drag your mouse across the chart to start data collection.

Candlestick data will be stored as comma-separated values under ohlcv.txt and all indicators will be in indicators.txt.
