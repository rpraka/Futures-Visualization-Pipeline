# Futures-Visualization-Pipeline
A comprehensive set of techniques and tools to collect, process and visualize financial Futures data from scratch.

The pipeline includes a special section on wrangling non-time-indexed data (**tick/range/volume charts**). Such data is especially important since time-based charts exhibit undesirable statistical properties and over-sample low activity periods while under-sampling high activity periods (see Easley, Lopez de Prado, and O’Hara [2012](https://www.stern.nyu.edu/sites/default/files/assets/documents/con_035928.pdf)).


## Table of Contents
  * [Data Collection](#data-collection)
    + [DataSaver](#datasaver)
  * [Data Processing](#data-processing)
  * [Visualization](#visualization)
    + [Time-Indexed Charting Summary](#time-indexed-charting-summary)
    + [1 Minute Charts Aggregated by Day, Filtered by Cash Session](#1-minute-charts-aggregated-by-day--filtered-by-cash-session)
    + [Multi-Panel Indicator and Overlay Plotting](#multi-panel-indicator-and-overlay-plotting)
    + [Dual Intrument Plotting](#dual-intrument-plotting)
  * [Non-Time-Indexed Charting Summary](#non-time-indexed-charting-summary)
    + [10 Range Charts Chunked by Number of Bars and Time Re-indexed](#10-range-charts-chunked-by-number-of-bars-and-time-re-indexed)
    + [Non-Time-Indexed Indicators Superimposed and Time Re-indexed](#non-time-indexed-indicators-superimposed-and-time-re-indexed)

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

## Data Processing
DataSaver ports the data from NT 8 very cleanly, consistently generating an accurate copy of the data with 0 missing values. This greatly simplifies data processing.

**Section 1** of _Futures_Visualization_Pipeline.ipynb_ demonstrates a multi-instrument processing pipeline, where time-indexed data from the highly correlated Nasdaq (NQ) and S&P 500 (ES) Futures is merged together. The indicator series are aligned with their corresponding candlesticks, allowing for superimposed visualization.

**Section 2** demonstrates processing techniques with non-time-indexed data, using chunking techniques and time-reindexing since the data sampling frequency is quite high. It also reveals techniques for interpretable visualizations with multiple superimposed indicator series.

## Visualization
Below is a representative summary of the type of visualizations one can create after following this pipeline. See Sections 1 and 2 of _Futures_Visualization_Pipeline.ipynb_ for details behind each visualization technique.

### Time-Indexed Charting Summary
### 1 Minute Charts Aggregated by Day, Filtered by Cash Session
![minute_charts](https://user-images.githubusercontent.com/67923084/147705283-bed1e70d-fffa-4807-b2cf-fffe2712684b.png)

### Multi-Panel Indicator and Overlay Plotting
![1m_indicator_plotting](https://user-images.githubusercontent.com/67923084/147705355-4124b88d-e887-493f-a392-57467940cd4f.png)

### Dual Intrument Plotting
![dual_instrument_plotting](https://user-images.githubusercontent.com/67923084/147705654-522b8ea5-deb9-4c11-855b-b99b2dc58256.png)

## Non-Time-Indexed Charting Summary
### 10 Range Charts Chunked by Number of Bars and Time Re-indexed
![range_200bars](https://user-images.githubusercontent.com/67923084/147706233-f1cbc7ae-03e4-442c-8d6f-6a625905f26e.png)

### Non-Time-Indexed Indicators Superimposed and Time Re-indexed
![range_indi](https://user-images.githubusercontent.com/67923084/147706586-e73669ce-460b-46d6-a88b-309ce426add8.png)

