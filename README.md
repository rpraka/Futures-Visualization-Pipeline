# Futures-Visualization-Pipeline
A comprehensive set of techniques and tools to collect, process and visualize financial Futures data from scratch.

The pipeline includes a special section on wrangling non-time indexed data (**tick/range/volume charts**). Such data is especially important since time-based charts exhibit undesirable statistical properties and over-sample low activity periods while under-sampling high activity periods (see Easley, Lopez de Prado, and O’Hara [2012](https://www.stern.nyu.edu/sites/default/files/assets/documents/con_035928.pdf)).

## Data Collection
When it comes to strategy development, collecting large amounts of reliable data is of utmost importance. Several resources exist to collect intra-day historical data for equity markets at almost no cost (yfinance, alpaca, polygon.io, etc.). However, APIs for intra-day Futures data are quite expensive, especially for beginners interested in getting their feet wet.

Here, I present a completely free option to extract high frequency data using the NinjaTrader 8 platform. This approach works in both the free evaluation software as well as the paid version.

### Datasaver

