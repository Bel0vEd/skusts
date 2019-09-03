using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using EasyModbus.Exceptions;

namespace SkyStsWinForm
{
    public partial class ConnectUserControl : UserControl
    {
        public ConnectUserControl()
        {
            InitializeComponent();
            IpAdress.Text = "127.0.0.1";
            Port.Text = "502";
        }

        private void ButtonConnectDevice_Click(object sender, EventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient(IpAdress.Text, Convert.ToInt32(Port.Text));
            try
            {
                modbusClient.Connect();

                int[] HoldingRegisters = modbusClient.ReadHoldingRegisters(0, 3);
                foreach (var item in HoldingRegisters)
                {
                    MessageBox.Show(item.ToString());
                }
            }
            catch (ConnectionException ex)
            {
                if (ex.Message == "connection timed out")
                {
                    MessageBox.Show("Подключение не установленно. Время ожидания подключения истекло");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
