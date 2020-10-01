using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using SkyStsWinForm.Classes;

namespace SkyStsWinForm
{
    public partial class HisrotyUserControl : UserControl
    {
        private readonly AdapterDataBase adapterDataBase = new AdapterDataBase();
        private readonly BufferDataGraph bufferDataGraph = new BufferDataGraph();
        
        private List<string> itemComboBox = new List<string>();
         
        public void getItemsCB()
        {
            comboBoxChartSelection.Items.Clear();
            itemComboBox = adapterDataBase.GetItemsComboBox();
            foreach (var item in itemComboBox)
            {
                comboBoxChartSelection.Items.Add(item);
            }
        }

        public HisrotyUserControl()
        {
            InitializeComponent();
            itemComboBox = adapterDataBase.GetItemsComboBox();
            getItemsCB();
        }
        ManagerGraph managerGraph;
        private void ComboBoxChartSelection_SelectedIndexChanged(object sender, EventArgs e)
        {

            //TODO Пофиксить ввод пользователельских данных в поле combobox
            DataTable DataInDB = adapterDataBase.GetGraphPoints(comboBoxChartSelection.Text.ToString());
            List<double> PointGraph = new List<double>();
            List<double> DateGraph = new List<double>();
            for (int i = 0; i < DataInDB.Columns[0].Table.Rows.Count; i++)
            {
                PointGraph.Add(Convert.ToDouble(DataInDB.Columns[0].Table.Rows[i].ItemArray[0])); //point in the graph
                DateGraph.Add(Convert.ToDouble(DataInDB.Columns[0].Table.Rows[i].ItemArray[1]));
            }
            DataTable DataInDB1 = adapterDataBase.GetGraphPoints1(comboBoxChartSelection.Text.ToString());
            List<double> PointGraph1 = new List<double>();
            List<double> DateGraph1 = new List<double>();
            for (int i = 0; i < DataInDB1.Columns[0].Table.Rows.Count; i++)
            {
                PointGraph1.Add(Convert.ToDouble(DataInDB1.Columns[0].Table.Rows[i].ItemArray[0])); //point in the graph
                DateGraph1.Add(Convert.ToDouble(DataInDB1.Columns[0].Table.Rows[i].ItemArray[1]));
            }
            bufferDataGraph.TimeFirstGraph = DateGraph;
            bufferDataGraph.TimeSecondGraph = DateGraph1;
            bufferDataGraph.PointFirstGraph1 = PointGraph;
            bufferDataGraph.PointTwoGraph1 = PointGraph1;
            managerGraph = new ManagerGraph(bufferDataGraph);
            plotViewHistory.Model = managerGraph.DrawOxyPlotGraph(2);
        }

        private void ComboBoxViewPoints1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxViewPoints1.SelectedIndex)
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
            if (managerGraph != null)
                plotViewHistory.Model = managerGraph.DrawOxyPlotGraph(2);
            else
                MessageBox.Show("Выберите график из истории" , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    } 
}
