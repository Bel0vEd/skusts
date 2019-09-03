using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SkyStsWinForm.Classes;
using OxyPlot;
using System.Resources;

namespace SkyStsWinForm
{
    public partial class MonitoringUserControl : UserControl
    {

        private BufferDataGraph bufferDataGraph  = new BufferDataGraph();
        private ManagerGraph management = new ManagerGraph();

        private bool SubscribeToTimerEvent = false;
        private bool DisableFollowGraph = false;

        private Timer FormTimer = new Timer
        {
            Interval = 1000
        };

        public MonitoringUserControl()
        { 
            InitializeComponent();

            management = new ManagerGraph(bufferDataGraph, OxyPlotGraphView.Model);
            management.DrawOxyPlotGraph();

            comboBoxViewPoints.SelectedIndex = 0;
            MonitoringOfIndicators();
        }
        
        #region Вызов методов получения данных и рисование графика
        private void DrawOxyPlotGraph(object sender, EventArgs e)
        {
            if (DisableFollowGraph == false)
            {
                bufferDataGraph.GetDataFromDevice();
                bufferDataGraph.Parent = OxyPlotGraphView.Model.Axes[0].Parent;

                OxyPlotGraphView.Model = management.DrawOxyPlotGraph();

                
            }
            else
            {
                bufferDataGraph.Parent = OxyPlotGraphView.Model.Axes[0].Parent;

                bufferDataGraph.GetDataFromDevice();
                OxyPlotGraphView.Model = management.DrawOxyPlotGraph();
            }

        }
        #endregion

        #region Подписка таймера на получение данных и рисование графика каждые 1000ms
        private void MonitoringOfIndicators()
        {
            if (SubscribeToTimerEvent == false)
            {
                SubscribeToTimerEvent = true;
                
                FormTimer.Start();
                FormTimer.Tick += new EventHandler(DrawOxyPlotGraph);
            }
        }
        #endregion

        #region Обработчик кнопки вкл/откл слежения за графиком
        private void ButtonStopDrawGraph_Click(object sender, EventArgs e)
        {
            if (DisableFollowGraph == false)
            {
                DisableFollowGraph = true;
                management.Set_RangeOfrawingSecond(-2);
                buttonChangeDisplayModeGraph.Text = "Включить следование за графиком";

            }
            else
            {
                DisableFollowGraph = false;
                management.Set_RangeOfrawingSecond(-1);
                buttonChangeDisplayModeGraph.Text = "Отключить следование за графиком";
            }
            OxyPlotGraphView.Model = management.DrawOxyPlotGraph();
        }
        #endregion

        #region Обработчик ограничения слежения за графиком в секундах
        private void ButtonSetDiapasonTestimony_Click(object sender, EventArgs e)
        {
            DisableFollowGraph = true;
            buttonChangeDisplayModeGraph.Text = "Включить следование за графиком";
            if (Convert.ToInt32(textBoxCountDiapasonTestimony.Text) > 0 && 
                Convert.ToInt32(textBoxCountDiapasonTestimony.Text) < 10000)
            {
                management.Set_RangeOfrawingSecond(Convert.ToInt32(textBoxCountDiapasonTestimony.Text));

            }
            else
            {
                MessageBox.Show("Количество секунд не может быть отрицательным и быть больше 9999");
            }
            OxyPlotGraphView.Model = management.DrawOxyPlotGraph();
        }
        #endregion

        #region Обработчик установки точек на графике
        private void ComboBoxViewPoints_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxViewPoints.SelectedIndex)
            {
                case 0:
                    bufferDataGraph.MarkerType = MarkerType.None;
                    break;
                case 1:
                    bufferDataGraph.MarkerType = MarkerType.Cross;
                    break;
                case 2:
                    bufferDataGraph.MarkerType = MarkerType.Diamond;
                    break;
                case 3:
                    bufferDataGraph.MarkerType = MarkerType.Circle;
                    break;
                case 4:
                    bufferDataGraph.MarkerType = MarkerType.Plus;
                    break;
                case 5:
                    bufferDataGraph.MarkerType = MarkerType.Square;
                    break;
            }
            OxyPlotGraphView.Model = management.DrawOxyPlotGraph();
        }
        #endregion

        #region Обработчик остановки подписки на получение данных и рисование данных
        private void Button1_Click(object sender, EventArgs e)
        {
            FormTimer.Tick -= DrawOxyPlotGraph;
        }
        #endregion
    }
}
