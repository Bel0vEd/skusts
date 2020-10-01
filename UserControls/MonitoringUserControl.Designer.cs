namespace SkyStsWinForm.UserControls
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxViewPoints = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCountDiapasonTestimony = new System.Windows.Forms.TextBox();
            this.buttonSetDiapasonTestimony = new System.Windows.Forms.Button();
            this.buttonChangeDisplayModeGraph = new System.Windows.Forms.Button();
            this.OxyPlotGraphView = new OxyPlot.WindowsForms.PlotView();
            this.toolTipTurnoverEncoder = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new WpfControlLibrary1.UserControl1();
            this.button1 = new System.Windows.Forms.Button();
            this.MomentText = new System.Windows.Forms.Label();
            this.RevolutionText = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 399);
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
            "Ромб",
            "Круг",
            "Квадрат"});
            this.comboBoxViewPoints.Location = new System.Drawing.Point(130, 396);
            this.comboBoxViewPoints.Name = "comboBoxViewPoints";
            this.comboBoxViewPoints.Size = new System.Drawing.Size(121, 21);
            this.comboBoxViewPoints.TabIndex = 6;
            this.comboBoxViewPoints.SelectedIndexChanged += new System.EventHandler(this.ComboBoxViewPoints_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(721, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "секунд";
            // 
            // textBoxCountDiapasonTestimony
            // 
            this.textBoxCountDiapasonTestimony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCountDiapasonTestimony.Location = new System.Drawing.Point(683, 7);
            this.textBoxCountDiapasonTestimony.Name = "textBoxCountDiapasonTestimony";
            this.textBoxCountDiapasonTestimony.Size = new System.Drawing.Size(32, 20);
            this.textBoxCountDiapasonTestimony.TabIndex = 4;
            this.textBoxCountDiapasonTestimony.Text = "50";
            this.textBoxCountDiapasonTestimony.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonSetDiapasonTestimony
            // 
            this.buttonSetDiapasonTestimony.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetDiapasonTestimony.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(8)))), ((int)(((byte)(115)))));
            this.buttonSetDiapasonTestimony.Location = new System.Drawing.Point(551, 5);
            this.buttonSetDiapasonTestimony.Name = "buttonSetDiapasonTestimony";
            this.buttonSetDiapasonTestimony.Size = new System.Drawing.Size(126, 23);
            this.buttonSetDiapasonTestimony.TabIndex = 3;
            this.buttonSetDiapasonTestimony.Text = "Показать последние ";
            this.buttonSetDiapasonTestimony.UseVisualStyleBackColor = true;
            this.buttonSetDiapasonTestimony.Click += new System.EventHandler(this.ButtonSetDiapasonTestimony_Click);
            // 
            // buttonChangeDisplayModeGraph
            // 
            this.buttonChangeDisplayModeGraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(8)))), ((int)(((byte)(115)))));
            this.buttonChangeDisplayModeGraph.Location = new System.Drawing.Point(6, 6);
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
            this.OxyPlotGraphView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.OxyPlotGraphView.Location = new System.Drawing.Point(6, 35);
            this.OxyPlotGraphView.Name = "OxyPlotGraphView";
            this.OxyPlotGraphView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.OxyPlotGraphView.Size = new System.Drawing.Size(757, 355);
            this.OxyPlotGraphView.TabIndex = 0;
            this.OxyPlotGraphView.Text = "plotView1";
            this.OxyPlotGraphView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.OxyPlotGraphView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.OxyPlotGraphView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 449);
            this.tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.tabPage1.Controls.Add(this.buttonChangeDisplayModeGraph);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBoxViewPoints);
            this.tabPage1.Controls.Add(this.OxyPlotGraphView);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonSetDiapasonTestimony);
            this.tabPage1.Controls.Add(this.textBoxCountDiapasonTestimony);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(154)))), ((int)(((byte)(211)))));
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.RevolutionText);
            this.tabPage2.Controls.Add(this.MomentText);
            this.tabPage2.Controls.Add(this.elementHost1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(769, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(23, 87);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(693, 343);
            this.elementHost1.TabIndex = 60;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(696, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 70);
            this.button1.TabIndex = 59;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MomentText
            // 
            this.MomentText.AutoSize = true;
            this.MomentText.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MomentText.Location = new System.Drawing.Point(82, 46);
            this.MomentText.Name = "MomentText";
            this.MomentText.Size = new System.Drawing.Size(44, 28);
            this.MomentText.TabIndex = 61;
            this.MomentText.Text = "Mp";
            this.MomentText.Visible = false;
            // 
            // RevolutionText
            // 
            this.RevolutionText.AutoSize = true;
            this.RevolutionText.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RevolutionText.Location = new System.Drawing.Point(415, 46);
            this.RevolutionText.Name = "RevolutionText";
            this.RevolutionText.Size = new System.Drawing.Size(63, 28);
            this.RevolutionText.TabIndex = 62;
            this.RevolutionText.Text = "Поз.";
            this.RevolutionText.Visible = false;
            // 
            // MonitoringUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Name = "MonitoringUserControl";
            this.Size = new System.Drawing.Size(784, 456);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OxyPlot.WindowsForms.PlotView OxyPlotGraphView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCountDiapasonTestimony;
        private System.Windows.Forms.Button buttonSetDiapasonTestimony;
        private System.Windows.Forms.Button buttonChangeDisplayModeGraph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxViewPoints;
        private System.Windows.Forms.ToolTip toolTipTurnoverEncoder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfControlLibrary1.UserControl1 userControl11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label RevolutionText;
        private System.Windows.Forms.Label MomentText;
    }
}
