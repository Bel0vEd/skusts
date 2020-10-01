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
using SkyStsWinForm.Classes;
using System.Net.Sockets;

namespace SkyStsWinForm
{
    public partial class ConnectUserControl : UserControl
    {
        public static ConnectUserControl Instance { get; private set; }
        private static ModbusClient modbusClient;
        private static DateTime dtDateTime;
        public void disconnectSKU()
        {
            if (modbusClient != null)
            {
                modbusClient.Disconnect();
            }
        }


        public static ModbusClient getModbusClient()
        {
            return modbusClient;
        }
        private Timer FormTimer = new Timer
        {
            Interval = 1000
        };
        private bool SubscribeToTimerEvent = false;
        private void TimeSubscribe()
        {
            if (SubscribeToTimerEvent == false)
            {
                SubscribeToTimerEvent = true;

                FormTimer.Start();
                FormTimer.Tick += new EventHandler(AddOneSecondTime);
            }
        }

        private static string timeNow;

        public static float[] getMomentAndDate()
        {
            float[] data = new float[2];
            try
            {
                int[] a = modbusClient.ReadHoldingRegisters(1034, 2);
                data[0] = ModbusClient.ConvertRegistersToFloat(a);

                int[] b = modbusClient.ReadHoldingRegisters(1040, 2);
                data[1] = ModbusClient.ConvertRegistersToFloat(b);
            }
            catch (Exception ex)
            {
                return null;
                //TODO  
            }
            
            return data;
        }

        public void AddOneSecondTime(object sender, EventArgs e)
        {
            try
            {
                dtDateTime = dtDateTime.AddSeconds(1);
                LabelTimeNow.Text = Convert.ToString(dtDateTime);
                timeNow = LabelTimeNow.Text;
                int[] a = modbusClient.ReadHoldingRegisters(1034, 2);
            }//TODO дописать exeption
            catch (Exception)
            {

            }
            
        }

        public static void connectSKU(string ip, int port)
        {
            try
            {
                modbusClient = new ModbusClient(ip, port);
                //modbusClient.ConnectionTimeout = 50000;
                modbusClient.Connect();
                int[] zavnomer = new int[4];
                zavnomer = modbusClient.ReadHoldingRegisters(3 - 1, 4);
                zavnomer[2] = 0;
                zavnomer[3] = 0;
                ulong zavnomer1 = Convert.ToUInt64(ModbusClient.ConvertRegistersToLong(zavnomer));
                MessageBox.Show("Подключение установлено. Заводской № " + zavnomer1.ToString());

                Action action = () => Instance.labelConnectStatus.Text = "Подключение установлено";
                Instance.labelConnectStatus.Invoke(action);

                action = () => Instance.ButtonConnectDevice.Enabled = false;
                Instance.ButtonConnectDevice.Invoke(action);
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
            catch (SocketException)
            {
                {
                    MessageBox.Show("Не удалось подключиться к устройству.");
                }
            }
        }
        public string encoder(string a)
        {
            string type = "Тип энкодера: Не определён";
            if (a == "1")
            { type = "Тип энкодера: Cчётчик"; }
            if (a == "0")
            { type = "Тип энкодера: Квадратурный"; }
            return type;
        }
        public ConnectUserControl()
        {
            InitializeComponent();
            Instance = this;
            IpAdress.Text = "127.0.0.1";
            Port.Text = "502";
        }
        public float RegisterValueConvertToFloat(ModbusClient modbusClient, int b)
        {
            try
            {
                int[] a = modbusClient.ReadHoldingRegisters(b - 1, 1);
                int[] fromfloat = new int[2];
                fromfloat[1] = a[0];
                float registr = ModbusClient.ConvertRegistersToFloat(fromfloat);
                return registr;
            }
            catch (StartingAddressInvalidException)
            {
                return 999;
            }
        }
        public int RegisterValueConvertToInt(ModbusClient modbusClient, int b)
        {
            try
            {
                int[] a = modbusClient.ReadHoldingRegisters(b - 1, 1);
                return a[0];
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static bool stateConnection = true; 

        public static string getDateTimeFromDevice()
        {
            try
            {
                int[] time = new int[4];
                time = modbusClient.ReadHoldingRegisters(1057 - 1, 4);
                time[2] = 0;
                time[3] = 0;
                ulong time1 = Convert.ToUInt64(ModbusClient.ConvertRegistersToLong(time));
                return ConvertTime(time1.ToString());
            }
            catch (Exception ex)
            {
                if (stateConnection)
                {
                    if (ex.Message == "connection timed out")
                    {
                        MessageBox.Show("Подключение не установленно. Время ожидания подключения истекло");

                        stateConnection = false;

                        Action action = () => Instance.labelConnectStatus.Text = "Подключение не установлено";
                        Instance.labelConnectStatus.Invoke(action);

                        action = () => Instance.ButtonConnectDevice.Enabled = true;
                        Instance.ButtonConnectDevice.Invoke(action);

                        DialogResult questConnect = MessageBox.Show("Подключение потеряно", "", MessageBoxButtons.RetryCancel);
                        if (questConnect == DialogResult.Cancel)
                        {
                            //Environment.Exit(0);
                        }
                        else if (questConnect == DialogResult.Retry)
                        {
                            stateConnection = true;
                            connectSKU(statIpAdress, Convert.ToInt32(statPort));
                        }
                    }
                    else
                    {
                        //другие исключения
                        
                    }
                }
                return timeNow;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (modbusClient == null || modbusClient.Connected == false)
                {
                    MessageBox.Show("Для начала подключитесь к устройству!");
                }
                else
                {
                    if (comboBox1.SelectedIndex < 1)
                    {
                        comboBox1.SelectedIndex = 0;
                        textBox2mA.Text = RegisterValueConvertToFloat(modbusClient, 62).ToString();
                        textBox3mA.Text = RegisterValueConvertToFloat(modbusClient, 64).ToString();
                        textBox4mA.Text = RegisterValueConvertToFloat(modbusClient, 66).ToString();
                        textBox5mA.Text = RegisterValueConvertToFloat(modbusClient, 68).ToString();
                        textBox6mA.Text = RegisterValueConvertToFloat(modbusClient, 70).ToString();
                        textBox7mA.Text = RegisterValueConvertToFloat(modbusClient, 72).ToString();
                        textBox8mA.Text = RegisterValueConvertToFloat(modbusClient, 74).ToString();
                        textBox9mA.Text = RegisterValueConvertToFloat(modbusClient, 76).ToString();
                        textBox10mA.Text = RegisterValueConvertToFloat(modbusClient, 78).ToString();
                        textBox2kH.Text = RegisterValueConvertToFloat(modbusClient, 80).ToString();
                        textBox3kH.Text = RegisterValueConvertToFloat(modbusClient, 82).ToString();
                        textBox4kH.Text = RegisterValueConvertToFloat(modbusClient, 84).ToString();
                        textBox5kH.Text = RegisterValueConvertToFloat(modbusClient, 86).ToString();
                        textBox6kH.Text = RegisterValueConvertToFloat(modbusClient, 88).ToString();
                        textBox7kH.Text = RegisterValueConvertToFloat(modbusClient, 90).ToString();
                        textBox8kH.Text = RegisterValueConvertToFloat(modbusClient, 92).ToString();
                        textBox9kH.Text = RegisterValueConvertToFloat(modbusClient, 94).ToString();
                        textBox10kH.Text = RegisterValueConvertToFloat(modbusClient, 96).ToString();
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 1;
                        textBox2mA.Text = RegisterValueConvertToFloat(modbusClient, 102).ToString();
                        textBox3mA.Text = RegisterValueConvertToFloat(modbusClient, 104).ToString();
                        textBox4mA.Text = RegisterValueConvertToFloat(modbusClient, 106).ToString();
                        textBox5mA.Text = RegisterValueConvertToFloat(modbusClient, 108).ToString();
                        textBox6mA.Text = RegisterValueConvertToFloat(modbusClient, 110).ToString();
                        textBox7mA.Text = RegisterValueConvertToFloat(modbusClient, 112).ToString();
                        textBox8mA.Text = RegisterValueConvertToFloat(modbusClient, 114).ToString();
                        textBox9mA.Text = RegisterValueConvertToFloat(modbusClient, 116).ToString();
                        textBox10mA.Text = RegisterValueConvertToFloat(modbusClient, 118).ToString();
                        textBox2kH.Text = RegisterValueConvertToFloat(modbusClient, 120).ToString();
                        textBox3kH.Text = RegisterValueConvertToFloat(modbusClient, 122).ToString();
                        textBox4kH.Text = RegisterValueConvertToFloat(modbusClient, 124).ToString();
                        textBox5kH.Text = RegisterValueConvertToFloat(modbusClient, 126).ToString();
                        textBox6kH.Text = RegisterValueConvertToFloat(modbusClient, 128).ToString();
                        textBox7kH.Text = RegisterValueConvertToFloat(modbusClient, 130).ToString();
                        textBox8kH.Text = RegisterValueConvertToFloat(modbusClient, 132).ToString();
                        textBox9kH.Text = RegisterValueConvertToFloat(modbusClient, 134).ToString();
                        textBox10kH.Text = RegisterValueConvertToFloat(modbusClient, 136).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LabelTimeNow.Visible = false;
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
        
        private static string statIpAdress;
        private static string statPort;
        private void ButtonConnectDevice_Click(object sender, EventArgs e)
        {
            try
            { 
                if (modbusClient == null || modbusClient.Connected == false)
                {
                    
                    connectSKU(IpAdress.Text, Convert.ToInt32(Port.Text));
                    
                    statIpAdress = IpAdress.Text;
                    statPort = Port.Text;

                }
                if (modbusClient != null && modbusClient.Connected == true)
                {
                    float[] regf = new float[50];    
                    int[] regi = new int[50];
                    for (int i = 10; i < 60; i++)
                    {
                        regi[i - 10] = RegisterValueConvertToInt(modbusClient, i);
                        regf[i - 10] = RegisterValueConvertToFloat(modbusClient, i);
                    }
                    textBoxNumberBrigada.Text = RegisterValueConvertToInt(modbusClient, 28).ToString();//Id текущей бригады 27 регистр
                    if(RegisterValueConvertToInt(modbusClient, 8) == 1)
                        radioButton2.Checked = true;
                    else if(RegisterValueConvertToInt(modbusClient, 8) == 0)
                        radioButton1.Checked = true;
                    LabelTimeNow.Text = getDateTimeFromDevice();//время и дата(число секунд прошедших с 1.1.2013 0х420,0х421)
                    if (!SubscribeToTimerEvent)
                    {
                        TimeSubscribe();
                    }
                    textBoxPorogLog.Text = RegisterValueConvertToFloat(modbusClient, 58).ToString();//Порог логирования
                    textBoxPorogK2.Text = RegisterValueConvertToFloat(modbusClient, 54).ToString(); //Порог K1 оповщатель
                    textBoxPorogK1.Text = RegisterValueConvertToFloat(modbusClient, 55).ToString(); //Порог K2 отс клапан
                    textBoxImpVP.Text = RegisterValueConvertToInt(modbusClient, 59).ToString();//Импульс на оборот ВП
                    textBoxImpNP.Text = RegisterValueConvertToInt(modbusClient, 99).ToString();//Импульс на оборот НП
                    LabelTimeNow.Visible = true;
                    //точки апроксимации
                    if (comboBox1.SelectedIndex < 1)
                    {
                        comboBox1.SelectedIndex = 0;
                        textBox2mA.Text = RegisterValueConvertToFloat(modbusClient, 62).ToString();
                        textBox3mA.Text = RegisterValueConvertToFloat(modbusClient, 64).ToString();
                        textBox4mA.Text = RegisterValueConvertToFloat(modbusClient, 66).ToString();
                        textBox5mA.Text = RegisterValueConvertToFloat(modbusClient, 68).ToString();
                        textBox6mA.Text = RegisterValueConvertToFloat(modbusClient, 70).ToString();
                        textBox7mA.Text = RegisterValueConvertToFloat(modbusClient, 72).ToString();
                        textBox8mA.Text = RegisterValueConvertToFloat(modbusClient, 74).ToString();
                        textBox9mA.Text = RegisterValueConvertToFloat(modbusClient, 76).ToString();
                        textBox10mA.Text = RegisterValueConvertToFloat(modbusClient, 78).ToString();
                        textBox2kH.Text = RegisterValueConvertToFloat(modbusClient, 80).ToString();
                        textBox3kH.Text = RegisterValueConvertToFloat(modbusClient, 82).ToString();
                        textBox4kH.Text = RegisterValueConvertToFloat(modbusClient, 84).ToString();
                        textBox5kH.Text = RegisterValueConvertToFloat(modbusClient, 86).ToString();
                        textBox6kH.Text = RegisterValueConvertToFloat(modbusClient, 88).ToString();
                        textBox7kH.Text = RegisterValueConvertToFloat(modbusClient, 90).ToString();
                        textBox8kH.Text = RegisterValueConvertToFloat(modbusClient, 92).ToString();
                        textBox9kH.Text = RegisterValueConvertToFloat(modbusClient, 94).ToString();
                        textBox10kH.Text = RegisterValueConvertToFloat(modbusClient, 96).ToString();
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 1;
                        textBox2mA.Text = RegisterValueConvertToFloat(modbusClient, 102).ToString();
                        textBox3mA.Text = RegisterValueConvertToFloat(modbusClient, 104).ToString();
                        textBox4mA.Text = RegisterValueConvertToFloat(modbusClient, 106).ToString();
                        textBox5mA.Text = RegisterValueConvertToFloat(modbusClient, 108).ToString();
                        textBox6mA.Text = RegisterValueConvertToFloat(modbusClient, 110).ToString();
                        textBox7mA.Text = RegisterValueConvertToFloat(modbusClient, 112).ToString();
                        textBox8mA.Text = RegisterValueConvertToFloat(modbusClient, 114).ToString();
                        textBox9mA.Text = RegisterValueConvertToFloat(modbusClient, 116).ToString();
                        textBox10mA.Text = RegisterValueConvertToFloat(modbusClient, 118).ToString();
                        textBox2kH.Text = RegisterValueConvertToFloat(modbusClient, 120).ToString();
                        textBox3kH.Text = RegisterValueConvertToFloat(modbusClient, 122).ToString();
                        textBox4kH.Text = RegisterValueConvertToFloat(modbusClient, 124).ToString();
                        textBox5kH.Text = RegisterValueConvertToFloat(modbusClient, 126).ToString();
                        textBox6kH.Text = RegisterValueConvertToFloat(modbusClient, 128).ToString();
                        textBox7kH.Text = RegisterValueConvertToFloat(modbusClient, 130).ToString();
                        textBox8kH.Text = RegisterValueConvertToFloat(modbusClient, 132).ToString();
                        textBox9kH.Text = RegisterValueConvertToFloat(modbusClient, 134).ToString();
                        textBox10kH.Text = RegisterValueConvertToFloat(modbusClient, 136).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LabelTimeNow.Visible = false;
                if (ex.Message == "connection timed out")
                {
                    MessageBox.Show("Подключение не установленно. Время ожидания подключения истекло");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            AdapterDataBase.RecordDBDataLogsAsync();
        }
        public static string ConvertTime(string time)
        {
            var DoubleTime = Convert.ToDouble(time);
            dtDateTime = new DateTime(2013, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(DoubleTime);
            var b = Convert.ToString(dtDateTime);
            return b;
        }

        private void buttonParametr_Click(object sender, EventArgs e)
        {
            try
            {
                if (modbusClient == null || modbusClient.Connected == false)
                {
                    connectSKU(IpAdress.Text, Convert.ToInt32(Port.Text));
                    textBoxNumberBrigada.Text = RegisterValueConvertToInt(modbusClient, 28).ToString();//Id текущей бригады 27 регистр
                    if (RegisterValueConvertToInt(modbusClient, 8) == 1)
                        radioButton2.Checked = true;
                    else if (RegisterValueConvertToInt(modbusClient, 8) == 0)
                        radioButton1.Checked = true;
                    LabelTimeNow.Text = getDateTimeFromDevice();//время и дата(число секунд прошедших с 1.1.2013 0х420,0х421)
                    if (!SubscribeToTimerEvent)
                    {
                        TimeSubscribe();
                    }
                    textBoxPorogLog.Text = RegisterValueConvertToFloat(modbusClient, 58).ToString();//Порог логирования
                    textBoxPorogK2.Text = RegisterValueConvertToFloat(modbusClient, 54).ToString(); //Порог K1 оповщатель
                    textBoxPorogK1.Text = RegisterValueConvertToFloat(modbusClient, 56).ToString(); //Порог K2 отс клапан
                    textBoxImpVP.Text = RegisterValueConvertToInt(modbusClient, 59).ToString();//Импульс на оборот ВП
                    textBoxImpNP.Text = RegisterValueConvertToInt(modbusClient, 99).ToString();//Импульс на оборот НП
                    LabelTimeNow.Visible = true;
                }
                modbusClient.WriteSingleRegister(55, ModbusClient.ConvertFloatToRegisters(Convert.ToSingle(textBoxPorogK1.Text))[1]);
                modbusClient.WriteSingleRegister(53, ModbusClient.ConvertFloatToRegisters(Convert.ToSingle(textBoxPorogK2.Text))[1]);
                modbusClient.WriteSingleRegister(57, ModbusClient.ConvertFloatToRegisters(Convert.ToSingle(textBoxPorogLog.Text))[1]);
                modbusClient.WriteSingleRegister(27, Convert.ToInt32(textBoxNumberBrigada.Text));
                modbusClient.WriteSingleRegister(58, Convert.ToInt32(textBoxImpVP.Text));
                modbusClient.WriteSingleRegister(98, Convert.ToInt32(textBoxImpNP.Text));
                if (radioButton2.Checked == true)
                    modbusClient.WriteSingleRegister(7, Convert.ToInt32("1"));
                else if (radioButton1.Checked == true)
                    modbusClient.WriteSingleRegister(7, Convert.ToInt32("0"));
                modbusClient.ConnectionTimeout = 1;
            }
            catch (Exception ex)
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
