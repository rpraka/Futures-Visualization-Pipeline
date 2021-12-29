#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
using System.IO;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators
{
    public class DataSaver : Indicator
    {
        int ran = 0;
        private StreamWriter sw1;
        private StreamWriter sw2;
        private string path1;
        private string path2;

        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Description = @"save historical data of price and indicator values";
                Name = "DataSaver";
                Calculate = Calculate.OnEachTick;
                IsOverlay = false;
                DisplayInDataBox = true;
                DrawOnPricePanel = true;
                DrawHorizontalGridLines = true;
                DrawVerticalGridLines = true;
                PaintPriceMarkers = true;
                ScaleJustification = NinjaTrader.Gui.Chart.ScaleJustification.Right;
                IsSuspendedWhileInactive = true;
                path1 = @"\\vmware-host\Shared Folders\nt_data\ohlcv.txt"; //set candlestick data path here
                path2 = @"\\vmware-host\Shared Folders\nt_data\indicators.txt"; //set indicator data path here


            }
            else if (State == State.Configure)
            {
            }
            else if (State == State.Terminated)
            {
                if (sw1 != null)
                {
                    sw1.Close();
                    sw1.Dispose();
                    sw1 = null;
                }
                if (sw2 != null)
                {
                    sw2.Close();
                    sw2.Dispose();
                    sw2 = null;
                }

            }
        }

        protected override void OnBarUpdate()
        {

        }
        protected override void OnRender(ChartControl chartControl, ChartScale chartScale)
        {
            if (ran == 20)
            {
                ClearOutputWindow();
                sw1 = File.CreateText(path1);
                sw2 = File.CreateText(path2);
                base.OnRender(chartControl, chartScale);

                NinjaTrader.Code.Output.Process("name,index,time,open,high,low,close,volume", PrintTo.OutputTab2);
                sw1.WriteLine("name,index,time,open,high,low,close,volume");

                // loop through only the rendered bars on the chart
                for (int barIndex = 0; barIndex <= ChartBars.ToIndex; barIndex++)
                {
                    // get the close price at the selected bar index value
                    double open = Bars.GetOpen(barIndex);
                    double close = Bars.GetClose(barIndex);
                    double high = Bars.GetHigh(barIndex);
                    double low = Bars.GetLow(barIndex);
                    double volume = Bars.GetVolume(barIndex);
                    // get the timestamp at the selected bar index value
                    DateTime time = Bars.GetTime(barIndex);

                    NinjaTrader.Code.Output.Process(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", "ohlcv", barIndex, time, open, high, low, close, volume), PrintTo.OutputTab2);
                    sw1.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", "ohlcv", barIndex, time, open, high, low, close, volume));
                }
                sw1.Close();

                lock (ChartControl.Indicators)
                {
                    Print("name,index,value,plot_name");
                    sw2.WriteLine("name,index,value,plot_name");
                    foreach (IndicatorBase indi in ChartControl.Indicators)
                    {
                        for (int i = 0; i < indi.Plots.Count(); i++)
                        {
                            if (indi.Plots[i] != null)
                            {
                                for (int j = 0; j < indi.Values[i].Count; j++)
                                {
                                    Print(String.Format("{0},{1},{2},{3}", indi.Name, j, indi.Values[i].GetValueAt(j), indi.Plots[i].Name));
                                    sw2.WriteLine(String.Format("{0},{1},{2},{3}", indi.Name, j, indi.Values[i].GetValueAt(j), indi.Plots[i].Name));
                                }
                            }
                        }
                    }

                }
                sw2.Close();


            }
            ran += 1;
        }
    }
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
    public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
    {
        private DataSaver[] cacheDataSaver;
        public DataSaver DataSaver()
        {
            return DataSaver(Input);
        }

        public DataSaver DataSaver(ISeries<double> input)
        {
            if (cacheDataSaver != null)
                for (int idx = 0; idx < cacheDataSaver.Length; idx++)
                    if (cacheDataSaver[idx] != null && cacheDataSaver[idx].EqualsInput(input))
                        return cacheDataSaver[idx];
            return CacheIndicator<DataSaver>(new DataSaver(), input, ref cacheDataSaver);
        }
    }
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
    public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
    {
        public Indicators.DataSaver DataSaver()
        {
            return indicator.DataSaver(Input);
        }

        public Indicators.DataSaver DataSaver(ISeries<double> input)
        {
            return indicator.DataSaver(input);
        }
    }
}

namespace NinjaTrader.NinjaScript.Strategies
{
    public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
    {
        public Indicators.DataSaver DataSaver()
        {
            return indicator.DataSaver(Input);
        }

        public Indicators.DataSaver DataSaver(ISeries<double> input)
        {
            return indicator.DataSaver(input);
        }
    }
}

#endregion
