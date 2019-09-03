using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkyStsWinForm.Classes;

namespace SkyStsWinForm
{
    public partial class HisrotyUserControl : UserControl
    {
        private readonly AdapterDataBase adapterDataBase = new AdapterDataBase();
        private DataTable DataInDB;
        public HisrotyUserControl()
        {
            InitializeComponent();
            DataInDB = adapterDataBase.getJobNumberAndDateTime();

            string bufcomboBoxChartSelectionString = "";
            int i = 0;

            foreach (DataRow item in DataInDB.Rows)
            {
                
                foreach (DataColumn item2 in DataInDB.Columns)
                {
                    i++;
                    if (i == 2)
                    {
                        bufcomboBoxChartSelectionString += " - " + item[item2].ToString();
                    }
                    else
                    {
                        bufcomboBoxChartSelectionString += item[item2].ToString();
                    }
                }
                i = 0;
                comboBoxChartSelection.Items.Add(bufcomboBoxChartSelectionString);
                bufcomboBoxChartSelectionString = "";
            }
            
        }
        
        private void ComboBoxChartSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    } 
}
