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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxViewPoints1 = new System.Windows.Forms.ComboBox();
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
            this.groupBoxHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.groupBoxHistory.Controls.Add(this.label2);
            this.groupBoxHistory.Controls.Add(this.comboBoxViewPoints1);
            this.groupBoxHistory.Controls.Add(this.plotViewHistory);
            this.groupBoxHistory.Controls.Add(this.label1);
            this.groupBoxHistory.Controls.Add(this.comboBoxChartSelection);
            this.groupBoxHistory.ForeColor = System.Drawing.Color.White;
            this.groupBoxHistory.Location = new System.Drawing.Point(3, 3);
            this.groupBoxHistory.Name = "groupBoxHistory";
            this.groupBoxHistory.Size = new System.Drawing.Size(638, 418);
            this.groupBoxHistory.TabIndex = 1;
            this.groupBoxHistory.TabStop = false;
            this.groupBoxHistory.Text = "История";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вид точек на графике";
            // 
            // comboBoxViewPoints1
            // 
            this.comboBoxViewPoints1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxViewPoints1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxViewPoints1.FormattingEnabled = true;
            this.comboBoxViewPoints1.Items.AddRange(new object[] {
            "Без точек",
            "Ромб",
            "Круг",
            "Квадрат"});
            this.comboBoxViewPoints1.Location = new System.Drawing.Point(131, 391);
            this.comboBoxViewPoints1.Name = "comboBoxViewPoints1";
            this.comboBoxViewPoints1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxViewPoints1.TabIndex = 3;
            this.comboBoxViewPoints1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxViewPoints1_SelectedIndexChanged);
            // 
            // plotViewHistory
            // 
            this.plotViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotViewHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.plotViewHistory.ForeColor = System.Drawing.Color.White;
            this.plotViewHistory.Location = new System.Drawing.Point(8, 50);
            this.plotViewHistory.Name = "plotViewHistory";
            this.plotViewHistory.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotViewHistory.Size = new System.Drawing.Size(626, 341);
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
            this.comboBoxChartSelection.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.Controls.Add(this.groupBoxHistory);
            this.Name = "HisrotyUserControl";
            this.Size = new System.Drawing.Size(644, 421);
            this.groupBoxHistory.ResumeLayout(false);
            this.groupBoxHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxHistory;
        private OxyPlot.WindowsForms.PlotView plotViewHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChartSelection;
        private System.Windows.Forms.ComboBox comboBoxViewPoints1;
        private System.Windows.Forms.Label label2;
    }
}
