using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using SkyStsWinForm.Classes;
using System;

namespace SkyStsWinForm
{
    class ManagerGraph
    {
        private PlotModel Model;
        private readonly BufferDataGraph BufferDataGraph;
        private int RangeOfDrawingSecond = -1;

        public ManagerGraph(BufferDataGraph bufferDataGraph, PlotModel Model = null)
        {
            this.Model = Model;
            BufferDataGraph = bufferDataGraph;
        }

        public void Set_RangeOfrawingSecond(int rangeOfrawingSecond)
        {
            this.RangeOfDrawingSecond = rangeOfrawingSecond;
        }

        int flag;

        public PlotModel DrawOxyPlotGraph(int a)
        {
            flag = a;
            Model = new PlotModel
            {
                LegendTitle = "Графики",
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.TopRight,
                LegendTextColor = OxyColors.White,
                LegendTitleColor = OxyColors.White,
                PlotAreaBorderColor = OxyColors.White,
                SubtitleColor = OxyColors.White,
                SelectionColor = OxyColors.White,
                TextColor = OxyColors.White,
                TitleColor = OxyColors.White
            };

            

            if (Model.Axes.Count > 0)
            {
                Model.Axes.Clear();
            }
            Model.GetDefaultColor();
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
                    StrokeThickness = 3,
                    MarkerSize = 3,
                    MarkerStrokeThickness = 1,
                    MarkerStroke = OxyColors.White,
                    MarkerFill = OxyColors.White,
                    MarkerType = BufferDataGraph.MarkerType,
                    CanTrackerInterpolatePoints = false,
                    Title = string.Format("Detector {0}", i),
                    Smooth = false,
                };
                if (flag == 1)
                {
                    if (i == 0)
                    {
                        lineSerie.Color = OxyColors.Yellow;
                        lineSerie.Title = "Момент (кН*м)";
                        int j = 0;
                        foreach (var item in BufferDataGraph.PointFirstGraph1)
                        {

                            lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(BufferDataGraph.DateFirstGraph1[j]), item));
                            j++;
                        }
                    }
                    if (i == 1)
                    {
                        lineSerie.Color = OxyColors.Green;
                        lineSerie.Title = "Позиция (обор.)";
                        int j = 0;
                        foreach (var item in BufferDataGraph.PointTwoGraph1)
                        {
                            lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(BufferDataGraph.DateTwoGraph1[j]), item));
                            j++;
                        }
                    }
                }
                if (flag == 2)
                {
                    if (i == 0)
                    {
                        lineSerie.Color = OxyColors.Yellow;
                        lineSerie.Title = "Момент (кН*м)";
                        int j = 0;
                        foreach (var item in BufferDataGraph.PointFirstGraph1)
                        {

                            lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(BufferDataGraph.TimeFirstGraph[j]), item));
                            j++;
                        }
                    }
                    if (i == 1)
                    {
                        lineSerie.Color = OxyColors.Green;
                        lineSerie.Title = "Позиция (обор.)";
                        int j = 0;
                        foreach (var item in BufferDataGraph.PointTwoGraph1)
                        {
                            lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(BufferDataGraph.TimeSecondGraph[j]), item));
                            j++;
                        }
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
                ExtraGridlineColor = OxyColors.White,
                MajorGridlineColor = OxyColors.White,
                MinorGridlineColor = OxyColors.White,
                MinorTicklineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
                Position = AxisPosition.Bottom,
                Minimum = minValue,
                Maximum = maxValue,
                StringFormat = "HH:mm:ss",
                IntervalLength = 50,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Data"
                
            });;

            plotModel.Axes.Add(new LinearAxis()
            {
                ExtraGridlineColor = OxyColors.White,
                MajorGridlineColor = OxyColors.White,
                MinorGridlineColor = OxyColors.White,
                MinorTicklineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
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
                ExtraGridlineColor = OxyColors.White,
                MajorGridlineColor = OxyColors.White,
                MinorGridlineColor = OxyColors.White,
                MinorTicklineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
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
                ExtraGridlineColor = OxyColors.White,
                MajorGridlineColor = OxyColors.White,
                MinorGridlineColor = OxyColors.White,
                MinorTicklineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
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
            if (flag == 1)
            {
                plotModel.Axes.Add(new DateTimeAxis
                {
                    ExtraGridlineColor = OxyColors.White,
                    MajorGridlineColor = OxyColors.White,
                    MinorGridlineColor = OxyColors.White,
                    MinorTicklineColor = OxyColors.White,
                    Position = AxisPosition.Bottom,
                    TicklineColor = OxyColors.White,
                    StringFormat = "HH:mm:ss",
                    IntervalLength = 50,
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "Data"
                });
            }
            if (flag == 2)
            {
                plotModel.Axes.Add(new LinearAxis()
                {
                    ExtraGridlineColor = OxyColors.White,
                    MajorGridlineColor = OxyColors.White,
                    MinorGridlineColor = OxyColors.White,
                    MinorTicklineColor = OxyColors.White,
                    Position = AxisPosition.Bottom,
                    TicklineColor = OxyColors.White,
                    IntervalLength = 50,
                    MajorGridlineStyle = LineStyle.Solid,
                    MinorGridlineStyle = LineStyle.Dot,
                    Title = "Data"
                });
            }
            plotModel.Axes.Add(new LinearAxis()
            {
                ExtraGridlineColor = OxyColors.White,
                MajorGridlineColor = OxyColors.White,
                MinorGridlineColor = OxyColors.White,
                MinorTicklineColor = OxyColors.White,
                TicklineColor = OxyColors.White,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Title = "Value"
            });
            return plotModel;
        }
    }
}
