using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using SkyStsWinForm.Classes;
using System;

namespace SkyStsWinForm
{
    class ManagementGraph
    {
        private PlotModel Model;
        private readonly BufferDataGraph BufferDataGraph;
        private int RangeOfDrawingSecond = -1;

        public ManagementGraph(BufferDataGraph bufferDataGraph = null, PlotModel Model = null)
        {
            this.Model = Model;
            BufferDataGraph = bufferDataGraph;
        }

        public void Set_RangeOfrawingSecond(int rangeOfrawingSecond)
        {
            this.RangeOfDrawingSecond = rangeOfrawingSecond;
        }



        public PlotModel DrawOxyPlotGraph()
        {
            Model = new PlotModel {
                LegendTitle = "DateTimeAxis",
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.TopRight
            };

            

            if (Model.Axes.Count > 0)
            {
                Model.Axes.Clear();
            }

            if (RangeOfDrawingSecond == -1)
            {
                Model = SettingDrawDefaultPosition(Model);
            }

            else if(RangeOfDrawingSecond == -2)
            {
                try
                {
                    Model = SettingDrawSavePosition(Model);
                }
                catch (NullReferenceException)
                {
                    Model = SettingDrawDefaultPosition(Model);
                }
            }
            else
            {
                Model = SettingDrawLastSeconds(Model);
            }

            Model.Series.Clear();
            for (int i = 0; i < 2; i++)
            {
               var lineSerie = new LineSeries()
                {
                    StrokeThickness = 2,
                    MarkerSize = 3,
                    MarkerStroke = OxyColors.AliceBlue,
                    MarkerType = BufferDataGraph.MarkerType,
                    CanTrackerInterpolatePoints = false,
                    Title = string.Format("Detector {0}", i),
                    Smooth = false,
                };
                if (i == 0)
                {
                    int j = 0;
                    foreach (var item in BufferDataGraph.PointFirstGraph1)
                    {
                        
                        lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(BufferDataGraph.DateFirstGraph1[j]), item));
                        j++;
                    }
                }

                if (i == 1)
                {
                    int j = 0;
                    foreach (var item in BufferDataGraph.PointTwoGraph1)
                    {
                        lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(BufferDataGraph.DateTwoGraph1[j]), item));
                        j++;
                    }
                }
                Model.Series.Add(lineSerie);
            }
            return Model;
        }

        private PlotModel SettingDrawLastSeconds(PlotModel plotModel)
        {
            var minValue = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(-RangeOfDrawingSecond));
            var maxValue = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(0));
            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = minValue,
                Maximum = maxValue,
                StringFormat = "HH:mm:ss",
                IntervalLength = 50,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Data"
            });

            plotModel.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Value"
            });
            return plotModel;
        }

        private PlotModel SettingDrawSavePosition(PlotModel plotModel)
        {
            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = ((PlotModel)BufferDataGraph.Parent).DefaultXAxis.ActualMinimum,
                Maximum = ((PlotModel)BufferDataGraph.Parent).DefaultXAxis.ActualMaximum,
                StringFormat = "HH:mm:ss",
                IntervalLength = 50,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Data"
            });

            plotModel.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Minimum = ((PlotModel)BufferDataGraph.Parent).DefaultYAxis.ActualMinimum,
                Maximum = ((PlotModel)BufferDataGraph.Parent).DefaultYAxis.ActualMaximum,
                Title = "Value"
            });
            return plotModel;
        }

        private PlotModel SettingDrawDefaultPosition(PlotModel plotModel)
        {
            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,

                StringFormat = "HH:mm:ss",
                IntervalLength = 50,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Data"
            });

            plotModel.Axes.Add(new LinearAxis()
            {
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Value"
            });
            return plotModel;
        }
    }
}
