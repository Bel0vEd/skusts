using System;
using System.ComponentModel;
using System.Management.Instrumentation;
using System.Windows.Forms;

namespace SkyStsWinForm
{

    public partial class Viewer : Form
    {
        public static Viewer Instance { get; private set; }
        private ConnectUserControl connectUserControl = new ConnectUserControl();
        private UserControls.MonitoringUserControl monitoringControl = new UserControls.MonitoringUserControl();
        private HisrotyUserControl hisrotyUserControl = new HisrotyUserControl();

        public void setScaleUserControl()
        {
            ReplacementOrCreateUserControl("MonitoringScaleUserControl");
        }

        private Control saveConnectUserControl;
        private Control saveMonitoringUserControl;
        private Control saveHisrotyUserControl;
        public static void setMaxCountLogsFromDevice(int NumberLogs)
        {
            Action action = () =>  Instance.progressBarLogLoad.Maximum = NumberLogs; //Viewer.setMaxPrigressBar(NumberLogs);
            Instance.progressBarLogLoad.Invoke(action);
        }

        private Timer FormTimer = new Timer
        {
            Interval = 60000
        };
        private readonly ContextMenu m_menu = new ContextMenu();
        
        
        public Viewer()
        {
            InitializeComponent();
            Instance = this;


            DateTime ThToday = DateTime.Now;
            connectUserControl.Width = panelUserControl.Width;
            connectUserControl.Height = panelUserControl.Height;
            m_menu.MenuItems.Add(0, new MenuItem("Развернуть приложение", new System.EventHandler(DeployApplication)));
            m_menu.MenuItems.Add(1, new MenuItem("Выход", new System.EventHandler(CloseWinForm_onClick)));
            notifyIconTray.ContextMenu = m_menu;
            connectUserControl.Parent = panelUserControl;
            notifyIconTray.Visible = false;
        }

        private void ButtonMenuConnectDevice_Click(object sender, EventArgs e)
        {

            SidePanel.Height = BussonMenuConnectDevice.Height;
            SidePanel.Top = BussonMenuConnectDevice.Top;
            ReplacementOrCreateUserControl("ConnectUserControl");
        }

        private void SaveControlStatus()
        {
            switch (panelUserControl.Controls[0].Name)
            {
                case "ConnectUserControl":
                    saveConnectUserControl = panelUserControl.Controls[0];
                    break;

                case "MonitoringUserControl":
                    saveMonitoringUserControl = panelUserControl.Controls[0];
                    break;
                case "HistoryUserControl":
                    saveHisrotyUserControl = panelUserControl.Controls[0];
                    break;
                
            }
        }

        private void ReplacementOrCreateUserControl(string CreateUserControl)
        {
            switch (CreateUserControl)
            {
                case "ConnectUserControl":
                    if (panelUserControl.Controls.Count == 0)
                    {
                        connectUserControl.Parent = panelUserControl;
                    }
                    else
                    {
                        SaveControlStatus();
                        panelUserControl.Controls.Clear();
                        if (saveConnectUserControl == null)
                        {
                            connectUserControl.Parent = panelUserControl;
                            connectUserControl.Dock = DockStyle.Fill;
                        }
                        else
                        {
                            panelUserControl.Controls.Add(saveConnectUserControl);
                        }
                    }
                    break;
                    
                case "MonitoringUserControl":
                    
                    if (panelUserControl.Controls.Count == 0)
                    {
                        monitoringControl.Parent = panelUserControl;
                    }
                    else
                    {
                        SaveControlStatus();
                        panelUserControl.Controls.Clear();
                        if (saveMonitoringUserControl == null)
                        {
                            monitoringControl.Parent = panelUserControl;
                            monitoringControl.Dock = DockStyle.Fill;
                        }
                        else
                        {
                            panelUserControl.Controls.Add(saveMonitoringUserControl);
                        }
                    }
                    break;
                 case "HistoryUserControl":
                    if (panelUserControl.Controls.Count == 0)
                    {
                        hisrotyUserControl.Parent = panelUserControl;
                    }
                    else
                    {
                        SaveControlStatus();
                        panelUserControl.Controls.Clear();
                        if (saveHisrotyUserControl == null)
                        {
                            hisrotyUserControl.Parent = panelUserControl;
                            hisrotyUserControl.Dock = DockStyle.Fill;
                        }
                        else
                        {
                            panelUserControl.Controls.Add(saveHisrotyUserControl);
                        }
                    }
                    break;
               
            }
        }
        
        #region Создание окна мониторинга
        private void ButtonMenuMonitoringOfIndicators_Click(object sender, EventArgs e)
        {
            SidePanel.Height = ButtonMenuMonitoringOfIndicators.Height;
            SidePanel.Top = ButtonMenuMonitoringOfIndicators.Top;
            ReplacementOrCreateUserControl("MonitoringUserControl");

            //пока что запустим индикаторы
            //ReplacementOrCreateUserControl("MonitoringScaleUserControl");

        }
        #endregion

        #region Обработчик сворачивания окна       
        private void WindowForm_Minimized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = true;
                // делаем нашу иконку в трее активной
                notifyIconTray.Visible = false;
            }
            if (WindowState == FormWindowState.Maximized)
            {
                connectUserControl.Width = panelUserControl.Width;
                connectUserControl.Height = panelUserControl.Height;
            }
            if(WindowState == FormWindowState.Normal)
            {
                connectUserControl.Width = panelUserControl.Width;
                connectUserControl.Height = panelUserControl.Height;
            }
        }
        #endregion
        private void Viewer_Resize(object sender, EventArgs e)
        {
            connectUserControl.Width = panelUserControl.Width;
            connectUserControl.Height = panelUserControl.Height;
        }
        #region Обработка нажатий для iconTray 
        private void NotifyIconTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DeployApplication(sender, e);
        }

        private void DeployApplication(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // делаем нашу иконку скрытой
                notifyIconTray.Visible = false;
                // возвращаем отображение окна в панели
                this.ShowInTaskbar = true;
                //разворачиваем окно
                WindowState = FormWindowState.Normal;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            notifyIconTray.Visible = true;
            this.ShowInTaskbar = false;
            notifyIconTray.ShowBalloonTip(100, "Сообщение", "Приложение свенулось в трей", ToolTipIcon.Info);

        }

        private void CloseWinForm_onClick(object sender, EventArgs e)
        {
            connectUserControl.disconnectSKU();
            notifyIconTray.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region Создание окна истории
        private void ButtonMenuHistory_Click(object sender, EventArgs e)
        {
            hisrotyUserControl.getItemsCB();
            SidePanel.Height = ButtonMenuHistory.Height;
            SidePanel.Top = ButtonMenuHistory.Top;
            ReplacementOrCreateUserControl("HistoryUserControl");
            

        }
        #endregion
        public static void setProgressBar(int CurrentRedRecordLog)
        {
            try
            {
                Action action = () => Instance.progressBarLogLoad.Value = CurrentRedRecordLog;
                Instance.progressBarLogLoad.Invoke(action);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Как-то так получилось, что " + (Instance.progressBarLogLoad.Maximum + CurrentRedRecordLog) + " превысило " + Instance.progressBarLogLoad.Maximum);
            }
        }

        public static void showProgressBarUpdateLogs()
        {
            Action action = () => Instance.progressBarLogLoad.Visible = true;
            Instance.progressBarLogLoad.Invoke(action);
            action = () => Instance.labelUpdateData.Visible = true;
            Instance.progressBarLogLoad.Invoke(action);
          
        }
        public static void hideProgressBarUpdateLogs()
        {
            Action action = () => Instance.progressBarLogLoad.Visible = false;
            Instance.progressBarLogLoad.Invoke(action);
            action = () => Instance.labelUpdateData.Visible = false;
            Instance.progressBarLogLoad.Invoke(action);
        }
    }
}
