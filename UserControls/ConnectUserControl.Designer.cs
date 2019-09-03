namespace SkyStsWinForm
{
    partial class ConnectUserControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.ButtonConnectDevice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IpAdress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Порт";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(153, 40);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(40, 20);
            this.Port.TabIndex = 8;
            // 
            // ButtonConnectDevice
            // 
            this.ButtonConnectDevice.Location = new System.Drawing.Point(24, 66);
            this.ButtonConnectDevice.Name = "ButtonConnectDevice";
            this.ButtonConnectDevice.Size = new System.Drawing.Size(169, 37);
            this.ButtonConnectDevice.TabIndex = 6;
            this.ButtonConnectDevice.Text = "Добавить устройство";
            this.ButtonConnectDevice.UseVisualStyleBackColor = true;
            this.ButtonConnectDevice.Click += new System.EventHandler(this.ButtonConnectDevice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP адрес устройства";
            // 
            // IpAdress
            // 
            this.IpAdress.Location = new System.Drawing.Point(24, 40);
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.Size = new System.Drawing.Size(107, 20);
            this.IpAdress.TabIndex = 5;
            // 
            // ConnectUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ButtonConnectDevice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IpAdress);
            this.Name = "ConnectUserControl";
            this.Size = new System.Drawing.Size(670, 473);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Button ButtonConnectDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IpAdress;
    }
}
