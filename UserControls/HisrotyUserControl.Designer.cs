namespace SkyStsWinForm
{
    partial class HisrotyUserControl
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
            this.groupBoxHistory = new System.Windows.Forms.GroupBox();
            this.plotViewHistory = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxChartSelection = new System.Windows.Forms.ComboBox();
            this.groupBoxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxHistory
            // 
            this.groupBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHistory.Controls.Add(this.plotViewHistory);
            this.groupBoxHistory.Controls.Add(this.label1);
            this.groupBoxHistory.Controls.Add(this.comboBoxChartSelection);
            this.groupBoxHistory.Location = new System.Drawing.Point(3, 3);
            this.groupBoxHistory.Name = "groupBoxHistory";
            this.groupBoxHistory.Size = new System.Drawing.Size(638, 386);
            this.groupBoxHistory.TabIndex = 1;
            this.groupBoxHistory.TabStop = false;
            this.groupBoxHistory.Text = "История";
            // 
            // plotViewHistory
            // 
            this.plotViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotViewHistory.BackColor = System.Drawing.SystemColors.ControlDark;
            this.plotViewHistory.Location = new System.Drawing.Point(6, 44);
            this.plotViewHistory.Name = "plotViewHistory";
            this.plotViewHistory.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewHistory.Size = new System.Drawing.Size(626, 336);
            this.plotViewHistory.TabIndex = 2;
            this.plotViewHistory.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotViewHistory.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotViewHistory.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбор графика из истории";
            // 
            // comboBoxChartSelection
            // 
            this.comboBoxChartSelection.FormattingEnabled = true;
            this.comboBoxChartSelection.Location = new System.Drawing.Point(158, 17);
            this.comboBoxChartSelection.Name = "comboBoxChartSelection";
            this.comboBoxChartSelection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChartSelection.TabIndex = 0;
            this.comboBoxChartSelection.SelectedIndexChanged += new System.EventHandler(this.ComboBoxChartSelection_SelectedIndexChanged);
            // 
            // HisrotyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxHistory);
            this.Name = "HisrotyUserControl";
            this.Size = new System.Drawing.Size(644, 392);
            this.groupBoxHistory.ResumeLayout(false);
            this.groupBoxHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHistory;
        private OxyPlot.WindowsForms.PlotView plotViewHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChartSelection;
    }
}
