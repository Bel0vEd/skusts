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
         

        public HisrotyUserControl()
        {
            InitializeComponent();
            itemComboBox = adapterDataBase.GetItemsComboBox();
            foreach (var item in itemComboBox)
            {
                comboBoxChartSelection.Items.Add(item);
            }
        }
        
        private void ComboBoxChartSelection_SelectedIndexChanged(object sender, EventArgs e)
        {

            //TODO Пофиксить ввод пользователельских данных в поле combobox
            DataTable DataInDB = adapterDataBase.GetGraphPoints(comboBoxChartSelection.Text[0].ToString());

   
            List<double> PointGraph = new List<double>();
            List<DateTime> DateGraph = new List<DateTime>();

            
                for (int i = 0; i < DataInDB.Columns[0].Table.Rows.Count; i++)
                {
                    PointGraph.Add(Convert.ToDouble(DataInDB.Columns[0].Table.Rows[i].ItemArray[0])); //point in the graph
                    DateGraph.Add(Convert.ToDateTime(DataInDB.Columns[0].Table.Rows[i].ItemArray[1]));
                }   
            
            bufferDataGraph.DateFirstGraph1 = DateGraph;
            bufferDataGraph.DateTwoGraph1 = DateGraph;

            bufferDataGraph.PointFirstGraph1 = PointGraph;
            bufferDataGraph.PointTwoGraph1 = PointGraph;
            ManagerGraph managerGraph = new ManagerGraph(bufferDataGraph);
          
            plotViewHistory.Model = managerGraph.DrawOxyPlotGraph();
        }
    } 
}
