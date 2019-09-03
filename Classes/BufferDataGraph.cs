using OxyPlot;
using System;
using System.Collections.Generic;

namespace SkyStsWinForm.Classes
{
    class BufferDataGraph
    {
        private readonly Random rnd = new Random();
        private int DrawNumber2 = 0;

        public List<double> PointFirstGraph1 { get; set; } = new List<double>();
        public List<DateTime> DateFirstGraph1 { get; set; } = new List<DateTime>();
        public List<double> PointTwoGraph1 { get; set; } = new List<double>();
        public List<DateTime> DateTwoGraph1 { get; set; } = new List<DateTime>();
        public MarkerType MarkerType  { get; set; }

        public Model Parent { get; set; }

        public void GetDataFromDevice()
        {
            var startDate = DateTime.Now;
            DrawNumber2 += rnd.Next(0, 5);
            PointFirstGraph1.Add(DrawNumber2);
            DateFirstGraph1.Add(startDate);
            int rand = rnd.Next(5, 10);
            PointTwoGraph1.Add(DrawNumber2 + rand);
            DateTwoGraph1.Add(startDate);
        }

        public void SetDataFromDatabase()
        {

        }
    }
}
