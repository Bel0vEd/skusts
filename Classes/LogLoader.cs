using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyStsWinForm.Classes
{
    class LogLoader
    {
        private ModbusClient modbusClient;
        public long getOldbestRecordNumber()
        {
            if (modbusClient != null && modbusClient.Connected == true)
            {
                try
                {
                    modbusClient = ConnectUserControl.getModbusClient();

                    int[] bufOldbestRecordNumber = new int[4];
                    bufOldbestRecordNumber = modbusClient.ReadHoldingRegisters(1062, 4);
                    bufOldbestRecordNumber[2] = 0;
                    bufOldbestRecordNumber[3] = 0;
                    long OldbestRecordNumber = Convert.ToInt64(ModbusClient.ConvertRegistersToLong(bufOldbestRecordNumber));

                    return OldbestRecordNumber;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Неожиданный обрыв подключения");
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        public long getNewbestRecordNumber()
        {
            modbusClient = ConnectUserControl.getModbusClient();
            if (modbusClient != null && modbusClient.Connected == true)
            {
                try
                {
                    

                    int[] bufNewbestRecordNumber = new int[4];
                    bufNewbestRecordNumber = modbusClient.ReadHoldingRegisters(1064, 4);
                    bufNewbestRecordNumber[2] = 0;
                    bufNewbestRecordNumber[3] = 0;
                    long NewbestRecordNumber = Convert.ToInt64(ModbusClient.ConvertRegistersToLong(bufNewbestRecordNumber));

                    return NewbestRecordNumber;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Неожиданный обрыв подключения");
                    return -1;//
                }
            }
            else
            {
                return -1;
            }
        }

        public static List<float[,]> getDataGrafiksOfDevice(int[] sizelog, ModbusClient modbusClient, int startIndex)
        {
            List<float[,]> ListAllGraphics = new List<float[,]>();
            for (int i = 0; i < sizelog.Length; i++)//AllLog
            {
                float[,] WorksAndPointsForGraphs = new float[3, sizelog[i]];
                    int NumbersRead = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sizelog[i]) / 32));
                    int CurrentCountRead = 0;
                    for (int j = 0; j < NumbersRead; j++)//dataMomentForLog
                    {
                        modbusClient.WriteMultipleRegisters(1059, ModbusClient.ConvertIntToRegisters(j));
                        modbusClient.WriteMultipleRegisters(1060, ModbusClient.ConvertIntToRegisters(i + startIndex));
                        int[] readRegisters = modbusClient.ReadHoldingRegisters(17344, 64);
                        for (int z = 0; z < readRegisters.Length; z = z + 2)
                        {
                            WorksAndPointsForGraphs[0, CurrentCountRead] = ModbusClient.ConvertRegistersToFloat(new int[2] { readRegisters[z], readRegisters[z + 1] });
                            CurrentCountRead++;
                            if (CurrentCountRead >= sizelog[i])
                            { break; }
                        }
                    }
                    CurrentCountRead = 0;
                    for (int j = 42; j < 42 + NumbersRead; j++)//dataRevolutionsForLog
                    {
                        modbusClient.WriteMultipleRegisters(1059, ModbusClient.ConvertIntToRegisters(j));
                        modbusClient.WriteMultipleRegisters(1060, ModbusClient.ConvertIntToRegisters(i + startIndex));
                        int[] readRegisters = modbusClient.ReadHoldingRegisters(17344, 64);
                        for (int z = 0; z < readRegisters.Length; z = z + 2)
                        {
                            WorksAndPointsForGraphs[1, CurrentCountRead] = ModbusClient.ConvertRegistersToFloat(new int[2] { readRegisters[z], readRegisters[z + 1] });
                            CurrentCountRead++;
                            if (CurrentCountRead == sizelog[i])
                            { break; }
                        }
                    }
                    CurrentCountRead = 0;
                for (int j = 84; j < 84 + NumbersRead; j++)//dataTimeForLog
                {
                    modbusClient.WriteMultipleRegisters(1059, ModbusClient.ConvertIntToRegisters(j));
                    modbusClient.WriteMultipleRegisters(1060, ModbusClient.ConvertIntToRegisters(i + startIndex));
                    int[] readRegisters = modbusClient.ReadHoldingRegisters(17344, 64);
                    for (int z = 0; z < readRegisters.Length; z = z + 2)
                    {
                        WorksAndPointsForGraphs[2, CurrentCountRead] = ModbusClient.ConvertRegistersToFloat(new int[2] { readRegisters[z], readRegisters[z + 1] });
                        CurrentCountRead++;
                        if (CurrentCountRead == sizelog[i])
                        { break; }
                    }
                }
                AdapterDataBase.writeDataLogDB(WorksAndPointsForGraphs, i + startIndex);
                ListAllGraphics.Add(WorksAndPointsForGraphs);
                Viewer.setProgressBar(i);
            }
            return ListAllGraphics;
        }

        public async void getDataGrafiksOfDeviceAsync(int[] sizelog, int indexMaxNumberDB)
        {
            Viewer.showProgressBarUpdateLogs();
            Viewer.setMaxCountLogsFromDevice(sizelog.Length + 1);
            List<float[,]> ListAllGraphics = new List<float[,]>();
            ListAllGraphics = await Task.Run(() => getDataGrafiksOfDevice(sizelog, modbusClient, indexMaxNumberDB));
            Viewer.hideProgressBarUpdateLogs();
            
        }

        public List<int[]> getLogs(int startIndexRead)
        {
            modbusClient = ConnectUserControl.getModbusClient();
            List<int[]> RecordNumbers = new List<int[]>();

            if (modbusClient != null && modbusClient.Connected == true)
            {
                try
                {
                    //long OldbestRecordNumber = getOldbestRecordNumber();
                    long NewbestRecordNumber = getNewbestRecordNumber();
                    if (startIndexRead != -1 && NewbestRecordNumber != -1)
                    {
                        
                        modbusClient.WriteMultipleRegisters(1059, ModbusClient.ConvertIntToRegisters(768));
                        for (long i = startIndexRead; i <= NewbestRecordNumber; i++)
                        {
                            int[] numberCurrentWrite = new int[4];
                            numberCurrentWrite = ModbusClient.ConvertLongToRegisters(i);
                            modbusClient.WriteMultipleRegisters(1060, numberCurrentWrite);
                            int[] ArrayLogs = new int[64];
                            ArrayLogs = modbusClient.ReadHoldingRegisters(17344, 64);
                            RecordNumbers.Add(ArrayLogs);
                        }
                    }
                    return RecordNumbers;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Неожиданный обрыв подключения");
                    return RecordNumbers;//
                }
            }
            else
            {
                return RecordNumbers;
            }
        }
    }
}
