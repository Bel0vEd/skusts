using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SkyStsWinForm
{

    public partial class Viewer : Form
    {


        private ConnectUserControl connectUserControl = new ConnectUserControl();
        private MonitoringUserControl monitoringControl = new MonitoringUserControl();
        private HisrotyUserControl hisrotyUserControl = new HisrotyUserControl();

        private Control saveConnectUserControl;
        private Control saveMonitoringUserControl;
        private Control saveHisrotyUserControl;

        private readonly ContextMenu m_menu = new ContextMenu();

        public Viewer()
        {
            InitializeComponent();


            m_menu.MenuItems.Add(0, new MenuItem("Развернуть приложение", new System.EventHandler(DeployApplication)));
            m_menu.MenuItems.Add(1, new MenuItem("Выход", new System.EventHandler(CloseWinForm_onClick)));
            notifyIconTray.ContextMenu = m_menu;

            connectUserControl.Parent = panelUserControl;
            notifyIconTray.Visible = false;
        }

        private void ButtonMenuConnectDevice_Click(object sender, EventArgs e)
        {
            ReplacementAndCreateUserControl("ConnectUserControl");
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

        private void ReplacementAndCreateUserControl(string CreateUserControl)
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

        private void ButtonMenuMonitoringOfIndicators_Click(object sender, EventArgs e)
        {
            ReplacementAndCreateUserControl("MonitoringUserControl");
        }

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
        }
        #endregion

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
            notifyIconTray.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region Создание окна истории
        private void ButtonMenuHistory_Click(object sender, EventArgs e)
        {
            ReplacementAndCreateUserControl("HistoryUserControl");
            
        }
        #endregion
    }
}
