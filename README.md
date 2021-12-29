# Futures-Visualization-Pipeline
A comprehensive set of techniques and tools to collect, process and visualize financial Futures data from scratch.

The pipeline includes a special section on wrangling non-time-indexed data (**tick/range/volume charts**). Such data is especially important since time-based charts exhibit undesirable statistical properties and over-sample low activity periods while under-sampling high activity periods (see Easley, Lopez de Prado, and O’Hara [2012](https://www.stern.nyu.edu/sites/default/files/assets/documents/con_035928.pdf)).

## Data Collection
When it comes to strategy development, collecting large amounts of reliable data is of utmost importance. Several resources exist to collect intra-day historical data for equity markets at almost no cost (yfinance, alpaca, polygon.io, etc.). However, APIs for intra-day Futures data are quite expensive, especially for beginners interested in getting their feet wet.

Here, I present a completely free option to extract high frequency data using the NinjaTrader 8 platform. This approach works in both the free evaluation software as well as the paid version.

### DataSaver
Due to the lack of free options for scraping NT 8 data into an easily digestible format, I am releasing my own called **DataSaver**. It allows for **free** exportation of all chart data, including indicators - which eliminates computational discrepancies from occuring between your backtesting and live trading environments.

Simply import the zipped _datasaver.cs_ file to begin.
![image](https://user-images.githubusercontent.com/67923084/147692626-2a0a7e04-f2ea-45d8-b726-343d72b1f70f.png)

Open a standard time-based or non-time-based chart and add any desired indicators and metrics. Using a playback connection on historical market data is my preferred method of data collection. The charts support up to a single second of temporal resolution, and can retrieve up to 90 days of order flow data. Then, add the DataSaver indicator to the target chart and drag your mouse across the chart to start data collection.

Candlestick data will be stored as comma-separated values under ohlcv.txt and all indicators will be in indicators.txt.

![image](https://user-images.githubusercontent.com/67923084/147692550-b63da1ff-b710-402b-8597-5c6e9217468d.png)

## Data Processing and Visualization
DataSaver ports the data from NT 8 very cleanly, consistently generating an accurate copy of the data with 0 missing values. This makes data processing quite simple.

**Section 1** of _Futures_Visualization_Pipeline.ipynb_ demonstrates a multi-instrument processing pipeline, where time-indexed data from the highly correlated Nasdaq (NQ) and S&P 500 (ES) Futures is merged together. **Section 2** demonstrates processing techniques with non-time-indexed data, with chunking techniques and time-reindexing. 

