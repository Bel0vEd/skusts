using EasyModbus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyStsWinForm.Classes
{
    public class AdapterDataBase
    {
        private static DataTable dataTable;
        private string ConnectionString = Properties.Settings.Default.DatabaseConnectionString;
        private static DataTable DataInDB;

        private static DataTable GetDtTable(string nameTable, string command)
        {
            //ConnectionString = "Server=(LocalDb)\\v11.0;Integrated Security=true;AttachDbFileName=|DataDirectory|\\DatabaseOfTheDevice.mdf;";
            dataTable = new DataTable();
            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=DatabaseOfTheDevice.db;Version=3;");
            try
            {
                m_dbConn.Open();
                SQLiteCommand m_sqlCmd = new SQLiteCommand();
                m_sqlCmd.Connection = m_dbConn;
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command, m_dbConn);
                adapter.Fill(dataTable);
                m_dbConn.Close();
            }
            catch (Exception ex)
            {
              
                MessageBox.Show("Error: " + ex.Message);
            }
            return dataTable;
        }

        private static int getNetAndOldNumberWorks()
        {
            int numWorks = 0;
            dataTable = GetDtTable("\"Story\"", "SELECT MAX(\"NumberWorks\") AS max_NumberWorks " +
                                           "FROM \"Story\""
                      );
            
            foreach (DataRow item in dataTable.Rows)
            {
                try
                {
                    numWorks = Convert.ToInt32(item.ItemArray[0]);
                }
                catch (InvalidCastException)
                {}
                
            }
            
            return numWorks;
        }
        public static async void RecordDBDataLogsAsync()
        {
            await Task.Run(() => RecordDBDataLogs());

        }

        public static void RecordDBDataLogs()
        {
            List<int[]> logs = new List<int[]>();
            LogLoader logLoad = new LogLoader();
            //logs = logLoad.getLogs();
            int NumberWorks;
            int NumberBrigada;
            float MaxMoment;
            float MovingInResolitions;
            float MaxSpeed;
            float ShutoffValve;
            float DurationEvents;
            int indexMaxNumberWorksDB = getNetAndOldNumberWorks();
            long indexNumberWorksDevice = logLoad.getNewbestRecordNumber();
            if (indexNumberWorksDevice > indexMaxNumberWorksDB)
            {
                if (indexMaxNumberWorksDB == 0)
                {
                    logs = logLoad.getLogs(indexMaxNumberWorksDB);
                }
                else
                {
                    logs = logLoad.getLogs(indexMaxNumberWorksDB + 1);
                    indexMaxNumberWorksDB++;
                }
                int[] sizelog = new int[logs.Count];
                for (int i = 0; i < logs.Count; i++)
                {
                    sizelog[i] = logs[i][15];
                    DateTime dateTime = new DateTime(1997, 1, 1);
                    int[] time1 = new int[4];
                    time1[0] = logs[i][2];
                    time1[1] = logs[i][3];
                    NumberWorks = i + indexMaxNumberWorksDB;
                    dateTime = dateTime.AddDays(logs[i][0]).AddMilliseconds(ModbusClient.ConvertRegistersToLong(time1) * 10);
                    NumberBrigada = logs[i][4];
                    MaxMoment = ModbusClient.ConvertRegistersToFloat(ConvertToArray(logs[i][5], logs[i][6]));
                    MovingInResolitions = ModbusClient.ConvertRegistersToFloat(ConvertToArray(logs[i][7], logs[i][8]));
                    MaxSpeed = ModbusClient.ConvertRegistersToFloat(ConvertToArray(logs[i][9], logs[i][10]));
                    ShutoffValve = ModbusClient.ConvertRegistersToFloat(ConvertToArray(logs[i][11], logs[i][12]));
                    DurationEvents = ModbusClient.ConvertRegistersToFloat(ConvertToArray(logs[i][13], logs[i][14]));
                    RecordInDbData("INSERT INTO Story (NumberWorks, DataTime, NumberBrigada, MaxMoment, MovingInResolitions, MaxSpeed, ShutoffValve, DurationEvents ) " +
                                            "VALUES ('" + NumberWorks + "','" + dateTime.ToString() + "','" + NumberBrigada + "','" + MaxMoment + "','" + MovingInResolitions + "','" + MaxSpeed + "','" + ShutoffValve + "','" + DurationEvents + "')");
                }
                logLoad.getDataGrafiksOfDeviceAsync(sizelog, indexMaxNumberWorksDB);
            }
        }

        public static int[] ConvertToArray(int a,int b)
        {
            int[] ar = new int[2];
            ar[0] = a;
            ar[1] = b;
            return ar;
        }
        private static void RecordInDbData(string command) 
        {
            try
            {
                SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=DatabaseOfTheDevice.db;Version=3;");
                m_dbConn.Open();
                SQLiteCommand m_sqlCmd = new SQLiteCommand();
                m_sqlCmd = m_dbConn.CreateCommand();
                m_sqlCmd.CommandText = command;
                m_sqlCmd.ExecuteNonQuery();
                m_dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }          
        }

        public static DataTable GetJobNumberAndFirstDateTime()
        {
            dataTable = GetDtTable("\"Story\"", "SELECT DISTINCT \"NumberWorks\", " +
                                                       "min(\"DataTime\") " +
                                           "FROM \"Story\"" +
                                           "GROUP BY \"NumberWorks\""
                                  );
            return dataTable;

        }

        public DataTable GetGraphPoints(string JobNumber)
        {
            dataTable = GetDtTable("\"DataLogs\"", "SELECT \"Moment\", \"Time\" " +
                                           "FROM \"DataLogs\"" +
                                           "WHERE \"NumberWorks\" = " + JobNumber
                                  );
            return dataTable;
        }
        public DataTable GetGraphPoints1(string JobNumber)
        {
            dataTable = GetDtTable("\"DataLogs\"", "SELECT \"Encoder\", \"Time\" " +
                                           "FROM \"DataLogs\"" +
                                           "WHERE \"NumberWorks\" = " + JobNumber
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
                        //bufcomboBoxChartSelectionString += " - " + ConnectUserControl.ConvertTime(item[item2].ToString());
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

        public static void writeDataLogDB(float[,] dataLog, int NumberLog)
        {
            string SqlRequest = "INSERT INTO DataLogs(Moment, Encoder, Time, NumberWorks) VALUES ";
            for (int i = 0; i < (dataLog.Length) / 3; i++)
            {
                SqlRequest += "('" + dataLog[0, i] + "', '" + dataLog[1, i] + "', '" + dataLog[2, i] + "', '" + NumberLog + "'), ";
            }
            SqlRequest = SqlRequest.Substring(0, SqlRequest.Length - 2);

            RecordInDbData(SqlRequest);
        }
    }
}
