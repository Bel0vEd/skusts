using System;

namespace SkyStsWinForm
{
    partial class Viewer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.BussonMenuConnectDevice = new System.Windows.Forms.Button();
            this.ButtonMenuMonitoringOfIndicators = new System.Windows.Forms.Button();
            this.ButtonMenuHistory = new System.Windows.Forms.Button();
            this.panelUserControl = new System.Windows.Forms.Panel();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // BussonMenuConnectDevice
            // 
            this.BussonMenuConnectDevice.Location = new System.Drawing.Point(12, 12);
            this.BussonMenuConnectDevice.Name = "BussonMenuConnectDevice";
            this.BussonMenuConnectDevice.Size = new System.Drawing.Size(90, 82);
            this.BussonMenuConnectDevice.TabIndex = 0;
            this.BussonMenuConnectDevice.Text = "Подключение к устройству";
            this.BussonMenuConnectDevice.UseVisualStyleBackColor = true;
            this.BussonMenuConnectDevice.Click += new System.EventHandler(this.ButtonMenuConnectDevice_Click);
            // 
            // ButtonMenuMonitoringOfIndicators
            // 
            this.ButtonMenuMonitoringOfIndicators.Location = new System.Drawing.Point(12, 102);
            this.ButtonMenuMonitoringOfIndicators.Name = "ButtonMenuMonitoringOfIndicators";
            this.ButtonMenuMonitoringOfIndicators.Size = new System.Drawing.Size(90, 82);
            this.ButtonMenuMonitoringOfIndicators.TabIndex = 2;
            this.ButtonMenuMonitoringOfIndicators.Text = "Мониторинг показателей";
            this.ButtonMenuMonitoringOfIndicators.UseVisualStyleBackColor = true;
            this.ButtonMenuMonitoringOfIndicators.Click += new System.EventHandler(this.ButtonMenuMonitoringOfIndicators_Click);
            // 
            // ButtonMenuHistory
            // 
            this.ButtonMenuHistory.Location = new System.Drawing.Point(12, 190);
            this.ButtonMenuHistory.Name = "ButtonMenuHistory";
            this.ButtonMenuHistory.Size = new System.Drawing.Size(90, 82);
            this.ButtonMenuHistory.TabIndex = 6;
            this.ButtonMenuHistory.Text = "История показаний";
            this.ButtonMenuHistory.UseVisualStyleBackColor = true;
            this.ButtonMenuHistory.Click += new System.EventHandler(this.ButtonMenuHistory_Click);
            // 
            // panelUserControl
            // 
            this.panelUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelUserControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelUserControl.Location = new System.Drawing.Point(109, 9);
            this.panelUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.panelUserControl.Name = "panelUserControl";
            this.panelUserControl.Size = new System.Drawing.Size(682, 432);
            this.panelUserControl.TabIndex = 7;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "Мониторинг свинчивания";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconTray_MouseDoubleClick);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelUserControl);
            this.Controls.Add(this.ButtonMenuHistory);
            this.Controls.Add(this.ButtonMenuMonitoringOfIndicators);
            this.Controls.Add(this.BussonMenuConnectDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(710, 0);
            this.Name = "Viewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.WindowForm_Minimized);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button BussonMenuConnectDevice;
        private System.Windows.Forms.Button ButtonMenuMonitoringOfIndicators;
        private System.Windows.Forms.Button ButtonMenuHistory;
        private System.Windows.Forms.Panel panelUserControl;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
    }
}

