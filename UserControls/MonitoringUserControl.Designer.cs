namespace SkyStsWinForm
{
    partial class MonitoringUserControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxViewPoints = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCountDiapasonTestimony = new System.Windows.Forms.TextBox();
            this.buttonSetDiapasonTestimony = new System.Windows.Forms.Button();
            this.buttonChangeDisplayModeGraph = new System.Windows.Forms.Button();
            this.OxyPlotGraphView = new OxyPlot.WindowsForms.PlotView();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxViewPoints);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxCountDiapasonTestimony);
            this.groupBox2.Controls.Add(this.buttonSetDiapasonTestimony);
            this.groupBox2.Controls.Add(this.buttonChangeDisplayModeGraph);
            this.groupBox2.Controls.Add(this.OxyPlotGraphView);
            this.groupBox2.Location = new System.Drawing.Point(3, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 517);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Показатели";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(257, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Работа закончилась";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Вид точек на графике";
            // 
            // comboBoxViewPoints
            // 
            this.comboBoxViewPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxViewPoints.FormattingEnabled = true;
            this.comboBoxViewPoints.Items.AddRange(new object[] {
            "Без точек",
            "Крест",
            "Ромб",
            "Круг",
            "Плюс",
            "Квадрат"});
            this.comboBoxViewPoints.Location = new System.Drawing.Point(130, 489);
            this.comboBoxViewPoints.Name = "comboBoxViewPoints";
            this.comboBoxViewPoints.Size = new System.Drawing.Size(121, 21);
            this.comboBoxViewPoints.TabIndex = 6;
            this.comboBoxViewPoints.SelectedIndexChanged += new System.EventHandler(this.ComboBoxViewPoints_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "секунд";
            // 
            // textBoxCountDiapasonTestimony
            // 
            this.textBoxCountDiapasonTestimony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCountDiapasonTestimony.Location = new System.Drawing.Point(595, 22);
            this.textBoxCountDiapasonTestimony.Name = "textBoxCountDiapasonTestimony";
            this.textBoxCountDiapasonTestimony.Size = new System.Drawing.Size(32, 20);
            this.textBoxCountDiapasonTestimony.TabIndex = 4;
            this.textBoxCountDiapasonTestimony.Text = "50";
            this.textBoxCountDiapasonTestimony.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetDiapasonTestimony
            // 
            this.buttonSetDiapasonTestimony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetDiapasonTestimony.Location = new System.Drawing.Point(463, 20);
            this.buttonSetDiapasonTestimony.Name = "buttonSetDiapasonTestimony";
            this.buttonSetDiapasonTestimony.Size = new System.Drawing.Size(126, 23);
            this.buttonSetDiapasonTestimony.TabIndex = 3;
            this.buttonSetDiapasonTestimony.Text = "Показать последние ";
            this.buttonSetDiapasonTestimony.UseVisualStyleBackColor = true;
            this.buttonSetDiapasonTestimony.Click += new System.EventHandler(this.ButtonSetDiapasonTestimony_Click);
            // 
            // buttonChangeDisplayModeGraph
            // 
            this.buttonChangeDisplayModeGraph.Location = new System.Drawing.Point(6, 20);
            this.buttonChangeDisplayModeGraph.Name = "buttonChangeDisplayModeGraph";
            this.buttonChangeDisplayModeGraph.Size = new System.Drawing.Size(202, 23);
            this.buttonChangeDisplayModeGraph.TabIndex = 1;
            this.buttonChangeDisplayModeGraph.Text = "Отключить следование за графиком";
            this.buttonChangeDisplayModeGraph.UseVisualStyleBackColor = true;
            this.buttonChangeDisplayModeGraph.Click += new System.EventHandler(this.ButtonStopDrawGraph_Click);
            // 
            // OxyPlotGraphView
            // 
            this.OxyPlotGraphView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OxyPlotGraphView.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.OxyPlotGraphView.Location = new System.Drawing.Point(6, 48);
            this.OxyPlotGraphView.Name = "OxyPlotGraphView";
            this.OxyPlotGraphView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.OxyPlotGraphView.Size = new System.Drawing.Size(669, 435);
            this.OxyPlotGraphView.TabIndex = 0;
            this.OxyPlotGraphView.Text = "plotView1";
            this.OxyPlotGraphView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.OxyPlotGraphView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.OxyPlotGraphView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MonitoringUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox2);
            this.Name = "MonitoringUserControl";
            this.Size = new System.Drawing.Size(686, 529);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private OxyPlot.WindowsForms.PlotView OxyPlotGraphView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCountDiapasonTestimony;
        private System.Windows.Forms.Button buttonSetDiapasonTestimony;
        private System.Windows.Forms.Button buttonChangeDisplayModeGraph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxViewPoints;
        private System.Windows.Forms.Button button1;
    }
}
