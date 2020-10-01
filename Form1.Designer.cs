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
            this.ButtonMenuMonitoringOfIndicators = new System.Windows.Forms.Button();
            this.ButtonMenuHistory = new System.Windows.Forms.Button();
            this.panelUserControl = new System.Windows.Forms.Panel();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUpdateData = new System.Windows.Forms.Label();
            this.progressBarLogLoad = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.BussonMenuConnectDevice = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonMenuMonitoringOfIndicators
            // 
            this.ButtonMenuMonitoringOfIndicators.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonMenuMonitoringOfIndicators.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonMenuMonitoringOfIndicators.FlatAppearance.BorderSize = 0;
            this.ButtonMenuMonitoringOfIndicators.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ButtonMenuMonitoringOfIndicators.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ButtonMenuMonitoringOfIndicators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMenuMonitoringOfIndicators.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonMenuMonitoringOfIndicators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ButtonMenuMonitoringOfIndicators.Image = ((System.Drawing.Image)(resources.GetObject("ButtonMenuMonitoringOfIndicators.Image")));
            this.ButtonMenuMonitoringOfIndicators.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMenuMonitoringOfIndicators.Location = new System.Drawing.Point(15, 296);
            this.ButtonMenuMonitoringOfIndicators.Name = "ButtonMenuMonitoringOfIndicators";
            this.ButtonMenuMonitoringOfIndicators.Size = new System.Drawing.Size(172, 42);
            this.ButtonMenuMonitoringOfIndicators.TabIndex = 2;
            this.ButtonMenuMonitoringOfIndicators.Text = "Мониторинг";
            this.ButtonMenuMonitoringOfIndicators.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ButtonMenuMonitoringOfIndicators.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonMenuMonitoringOfIndicators.UseVisualStyleBackColor = false;
            this.ButtonMenuMonitoringOfIndicators.Click += new System.EventHandler(this.ButtonMenuMonitoringOfIndicators_Click);
            // 
            // ButtonMenuHistory
            // 
            this.ButtonMenuHistory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonMenuHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonMenuHistory.FlatAppearance.BorderSize = 0;
            this.ButtonMenuHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ButtonMenuHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ButtonMenuHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMenuHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonMenuHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ButtonMenuHistory.Image = ((System.Drawing.Image)(resources.GetObject("ButtonMenuHistory.Image")));
            this.ButtonMenuHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMenuHistory.Location = new System.Drawing.Point(15, 344);
            this.ButtonMenuHistory.Name = "ButtonMenuHistory";
            this.ButtonMenuHistory.Size = new System.Drawing.Size(155, 42);
            this.ButtonMenuHistory.TabIndex = 6;
            this.ButtonMenuHistory.Text = "История";
            this.ButtonMenuHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMenuHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonMenuHistory.UseVisualStyleBackColor = false;
            this.ButtonMenuHistory.Click += new System.EventHandler(this.ButtonMenuHistory_Click);
            // 
            // panelUserControl
            // 
            this.panelUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.panelUserControl.Location = new System.Drawing.Point(205, 0);
            this.panelUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.panelUserControl.Name = "panelUserControl";
            this.panelUserControl.Size = new System.Drawing.Size(1067, 665);
            this.panelUserControl.TabIndex = 7;
            // 
            // notifyIconTray
            // 
            this.notifyIconTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTray.Icon")));
            this.notifyIconTray.Text = "Мониторинг свинчивания";
            this.notifyIconTray.Visible = true;
            this.notifyIconTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconTray_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.labelUpdateData);
            this.panel1.Controls.Add(this.progressBarLogLoad);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.SidePanel);
            this.panel1.Controls.Add(this.ButtonMenuHistory);
            this.panel1.Controls.Add(this.ButtonMenuMonitoringOfIndicators);
            this.panel1.Controls.Add(this.BussonMenuConnectDevice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 665);
            this.panel1.TabIndex = 8;
            // 
            // labelUpdateData
            // 
            this.labelUpdateData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelUpdateData.AutoSize = true;
            this.labelUpdateData.Location = new System.Drawing.Point(14, 609);
            this.labelUpdateData.Name = "labelUpdateData";
            this.labelUpdateData.Size = new System.Drawing.Size(162, 26);
            this.labelUpdateData.TabIndex = 10;
            this.labelUpdateData.Text = "Синхронизация с устройством\r\nПожалуйста подождите...";
            this.labelUpdateData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUpdateData.Visible = false;
            // 
            // progressBarLogLoad
            // 
            this.progressBarLogLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBarLogLoad.Location = new System.Drawing.Point(14, 642);
            this.progressBarLogLoad.Name = "progressBarLogLoad";
            this.progressBarLogLoad.Size = new System.Drawing.Size(175, 11);
            this.progressBarLogLoad.TabIndex = 9;
            this.progressBarLogLoad.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // SidePanel
            // 
            this.SidePanel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.SidePanel.Location = new System.Drawing.Point(3, 262);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 34);
            this.SidePanel.TabIndex = 7;
            // 
            // BussonMenuConnectDevice
            // 
            this.BussonMenuConnectDevice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BussonMenuConnectDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BussonMenuConnectDevice.FlatAppearance.BorderSize = 0;
            this.BussonMenuConnectDevice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BussonMenuConnectDevice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BussonMenuConnectDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BussonMenuConnectDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BussonMenuConnectDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BussonMenuConnectDevice.Image = ((System.Drawing.Image)(resources.GetObject("BussonMenuConnectDevice.Image")));
            this.BussonMenuConnectDevice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BussonMenuConnectDevice.Location = new System.Drawing.Point(12, 257);
            this.BussonMenuConnectDevice.Name = "BussonMenuConnectDevice";
            this.BussonMenuConnectDevice.Size = new System.Drawing.Size(174, 44);
            this.BussonMenuConnectDevice.TabIndex = 0;
            this.BussonMenuConnectDevice.Text = "Подключение";
            this.BussonMenuConnectDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BussonMenuConnectDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BussonMenuConnectDevice.UseVisualStyleBackColor = false;
            this.BussonMenuConnectDevice.Click += new System.EventHandler(this.ButtonMenuConnectDevice_Click);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.ClientSize = new System.Drawing.Size(1272, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUserControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(710, 39);
            this.Name = "Viewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "СКУ-СТС";
            this.ResizeEnd += new System.EventHandler(this.Viewer_Resize);
            this.Resize += new System.EventHandler(this.WindowForm_Minimized);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion
        private System.Windows.Forms.Button ButtonMenuMonitoringOfIndicators;
        private System.Windows.Forms.Button ButtonMenuHistory;
        private System.Windows.Forms.Panel panelUserControl;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BussonMenuConnectDevice;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.PictureBox pictureBox1;

        public static void setMaxPrigressBar(int numb)
        {

        }

        private System.Windows.Forms.Label labelUpdateData;
        private System.Windows.Forms.ProgressBar progressBarLogLoad;
    }
}

