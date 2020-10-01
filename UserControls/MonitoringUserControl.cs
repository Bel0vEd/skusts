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
using wpf = WpfControlLibrary1;

namespace SkyStsWinForm.UserControls
{
    public partial class MonitoringUserControl : UserControl
    {

        private BufferDataGraph bufferDataGraph = new BufferDataGraph();
        private ManagerGraph management = new ManagerGraph(null);

        private bool SubscribeToTimerEvent = false;
        private bool DisableFollowGraph = false;

        private Timer FormTimer = new Timer
        {
            Interval = 1000
        };
        private wpf.UserControl1 uc;
        public MonitoringUserControl()
        {
            InitializeComponent();
            tabControl1.TabPages[0].Text = "График";
            tabControl1.TabPages[1].Text = "Индикаторы";
            uc = wpf.UserControl1.Instance;
            management = new ManagerGraph(bufferDataGraph, OxyPlotGraphView.Model);
            management.DrawOxyPlotGraph(1);
            
            comboBoxViewPoints.SelectedIndex = 0;
            MonitoringOfIndicators();
      
        }

        #region Вызов методов получения данных и рисование графика
        private void DrawOxyPlotGraph(object sender, EventArgs e)
        {
            if (DisableFollowGraph == false)
            {
                bufferDataGraph.GetDataFromDevice();
                if (bufferDataGraph.PointFirstGraph1.Count != 0)
                {
                    uc.setValueMoment(bufferDataGraph.PointFirstGraph1[bufferDataGraph.PointFirstGraph1.Count - 1]);

                }
                bufferDataGraph.Parent = OxyPlotGraphView.Model.Axes[0].Parent;
                OxyPlotGraphView.Model = management.DrawOxyPlotGraph(1);
            }
            else
            {
                bufferDataGraph.Parent = OxyPlotGraphView.Model.Axes[0].Parent;
                bufferDataGraph.GetDataFromDevice();
                if (bufferDataGraph.PointFirstGraph1.Count != 0)
                {
                    uc.setValueMoment(bufferDataGraph.PointFirstGraph1[bufferDataGraph.PointFirstGraph1.Count - 1]);

                }
                OxyPlotGraphView.Model = management.DrawOxyPlotGraph(1);
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
            OxyPlotGraphView.Model = management.DrawOxyPlotGraph(1);
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
            OxyPlotGraphView.Model = management.DrawOxyPlotGraph(1);
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
                    bufferDataGraph.MarkerType = MarkerType.Diamond;
                    break;
                case 2:
                    bufferDataGraph.MarkerType = MarkerType.Circle;
                    break;
                case 3:
                    bufferDataGraph.MarkerType = MarkerType.Square;
                    break;
            }
            OxyPlotGraphView.Model = management.DrawOxyPlotGraph(1);
        }
        #endregion

        #region Обработчик остановки подписки на получение данных и рисование данных
        private void Button1_Click(object sender, EventArgs e)
        {
            FormTimer.Tick -= DrawOxyPlotGraph;
        }
        #endregion

        int valueGauge = 10;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MomentText.Visible == false)
            {
                MomentText.Visible = true;
                RevolutionText.Visible = true;
            }
            valueGauge += 10;
            uc.setValueMoment(valueGauge);
            uc.setValueRevolution(valueGauge / 2);
            MomentText.Text = valueGauge.ToString() + " Mp, кН*м";
            RevolutionText.Text = (valueGauge/2).ToString() + " оборотов";
        }
    }
}
