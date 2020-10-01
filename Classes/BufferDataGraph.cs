using EasyModbus;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyStsWinForm.Classes
{
    public class BufferDataGraph
    {
        public List<double> PointFirstGraph1 { get; set; } = new List<double>();
        public List<double> TimeFirstGraph { get; set; } = new List<double>();
        public List<double> TimeSecondGraph { get; set; } = new List<double>();
        public List<DateTime> DateFirstGraph1 { get; set; } = new List<DateTime>();
        public List<double> PointTwoGraph1 { get; set; } = new List<double>();
        public List<DateTime> DateTwoGraph1 { get; set; } = new List<DateTime>();
        public MarkerType MarkerType  { get; set; }
        private ModbusClient modbusClient;

        public Model Parent { get; set; }
        public async void GetDataFromDevice()
        {
            modbusClient = ConnectUserControl.getModbusClient();
            if (modbusClient != null && modbusClient.Connected == true)
            {
                //var startDate = Convert.ToDateTime(ConnectUserControl.getDateTimeFromDevice());
                var startDate = await Task.Run(() => Convert.ToDateTime(ConnectUserControl.getDateTimeFromDevice()));
                float[] data = await Task.Run(() => ConnectUserControl.getMomentAndDate()); 

                if (data != null)
                {
                    PointFirstGraph1.Add(data[0]);//момент
                    DateFirstGraph1.Add(startDate);
                    PointTwoGraph1.Add(data[1]);  //date
                    DateTwoGraph1.Add(startDate);
                }
            }
        }
    }
}
