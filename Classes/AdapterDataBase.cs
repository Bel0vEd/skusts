using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SkyStsWinForm.Classes
{
    class AdapterDataBase
    {
        private SqlDataAdapter sqlDataAdapter;
        private DataTable dataTable;
        private readonly string ConnectionString = Properties.Settings.Default.DatabaseConnectionString;
        private DataTable DataInDB;

        private DataTable GetDtTable(string nameTable, string command)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                sqlDataAdapter = new SqlDataAdapter(command, ConnectionString);

                dataTable = new DataTable(nameTable);
                connection.Open();
                var commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                try
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (SqlException)
                {

                }
                connection.Close();
            }
            return dataTable;
        }

        public DataTable GetJobNumberAndFirstDateTime()
        {
            dataTable = GetDtTable("\"История работ\"", "SELECT DISTINCT \"Номер работы\", " +
                                                       "min(\"Дата и время\") " +
                                           "FROM \"История работ\"" +
                                           "GROUP BY \"Номер работы\""
                                  );

            return dataTable;

        }

        public DataTable GetGraphPoints(string JobNumber)
        {
            dataTable = GetDtTable("\"История работ\"", "SELECT \"Точка на графике\", \"Дата и время\" " +
                                           "FROM \"История работ\"" +
                                           "WHERE \"Номер работы\" = " + JobNumber
                                  );
            return dataTable;
        }

        public List<string> GetItemsComboBox()
        {
            List<string> itemComboBox = new List<string>();
            DataInDB = GetJobNumberAndFirstDateTime();

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
                itemComboBox.Add(bufcomboBoxChartSelectionString);
                bufcomboBoxChartSelectionString = "";
            }
            return itemComboBox;
        }
    }
}
