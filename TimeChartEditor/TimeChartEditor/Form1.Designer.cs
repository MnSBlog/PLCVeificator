namespace TimeChartEditor
{
    partial class TimeChartMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCorp = new System.Windows.Forms.Label();
            this.btnLoadTimeChart = new System.Windows.Forms.Button();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.btnMapping = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.lblSubTnow = new System.Windows.Forms.Label();
            this.lblTnow = new System.Windows.Forms.Label();
            this.lblSubSteps = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblLog = new System.Windows.Forms.Label();
            this.lblTimeChart = new System.Windows.Forms.Label();
            this.lblLadder = new System.Windows.Forms.Label();
            this.pbTimeChart = new System.Windows.Forms.PictureBox();
            this.pbLadderChart = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimeChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLadderChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSubSteps);
            this.panel1.Controls.Add(this.lblTnow);
            this.panel1.Controls.Add(this.lblSubTnow);
            this.panel1.Controls.Add(this.btnAnalysis);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnMapping);
            this.panel1.Controls.Add(this.btnLoadCSV);
            this.panel1.Controls.Add(this.btnLoadTimeChart);
            this.panel1.Controls.Add(this.lblCorp);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1880, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("210 옴니굴림 040", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(26, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Time Char Editor (Prototype)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCorp
            // 
            this.lblCorp.AutoSize = true;
            this.lblCorp.Font = new System.Drawing.Font("210 옴니굴림 040", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCorp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCorp.Location = new System.Drawing.Point(84, 54);
            this.lblCorp.Name = "lblCorp";
            this.lblCorp.Size = new System.Drawing.Size(412, 33);
            this.lblCorp.TabIndex = 1;
            this.lblCorp.Text = "MnS Lab of Ajou University";
            this.lblCorp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadTimeChart
            // 
            this.btnLoadTimeChart.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoadTimeChart.Location = new System.Drawing.Point(540, 10);
            this.btnLoadTimeChart.Name = "btnLoadTimeChart";
            this.btnLoadTimeChart.Size = new System.Drawing.Size(159, 77);
            this.btnLoadTimeChart.TabIndex = 2;
            this.btnLoadTimeChart.Text = "Load Time Chart";
            this.btnLoadTimeChart.UseVisualStyleBackColor = true;
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoadCSV.Location = new System.Drawing.Point(705, 10);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(159, 77);
            this.btnLoadCSV.TabIndex = 3;
            this.btnLoadCSV.Text = "Load Ladder\r\n(Only CSV)";
            this.btnLoadCSV.UseVisualStyleBackColor = true;
            this.btnLoadCSV.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMapping
            // 
            this.btnMapping.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMapping.Location = new System.Drawing.Point(870, 10);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(159, 77);
            this.btnMapping.TabIndex = 4;
            this.btnMapping.Text = "Mapping";
            this.btnMapping.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRun.Location = new System.Drawing.Point(1035, 10);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(159, 77);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnalysis.Location = new System.Drawing.Point(1200, 10);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(159, 77);
            this.btnAnalysis.TabIndex = 6;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            // 
            // lblSubTnow
            // 
            this.lblSubTnow.AutoSize = true;
            this.lblSubTnow.Font = new System.Drawing.Font("210 옴니굴림 040", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubTnow.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSubTnow.Location = new System.Drawing.Point(1365, 14);
            this.lblSubTnow.Name = "lblSubTnow";
            this.lblSubTnow.Size = new System.Drawing.Size(73, 24);
            this.lblSubTnow.TabIndex = 7;
            this.lblSubTnow.Text = "Tnow:";
            // 
            // lblTnow
            // 
            this.lblTnow.AutoSize = true;
            this.lblTnow.Font = new System.Drawing.Font("210 옴니굴림 040", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTnow.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTnow.Location = new System.Drawing.Point(1444, 14);
            this.lblTnow.Name = "lblTnow";
            this.lblTnow.Size = new System.Drawing.Size(87, 24);
            this.lblTnow.TabIndex = 8;
            this.lblTnow.Text = "00.000";
            this.lblTnow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubSteps
            // 
            this.lblSubSteps.AutoSize = true;
            this.lblSubSteps.Font = new System.Drawing.Font("210 옴니굴림 040", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubSteps.ForeColor = System.Drawing.SystemColors.Window;
            this.lblSubSteps.Location = new System.Drawing.Point(1365, 58);
            this.lblSubSteps.Name = "lblSubSteps";
            this.lblSubSteps.Size = new System.Drawing.Size(76, 24);
            this.lblSubSteps.TabIndex = 9;
            this.lblSubSteps.Text = "Steps:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("210 옴니굴림 040", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(1451, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "00000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReset.Location = new System.Drawing.Point(1553, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(159, 77);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQuit.Location = new System.Drawing.Point(1718, 10);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(159, 77);
            this.btnQuit.TabIndex = 12;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.pbTimeChart);
            this.panel2.Controls.Add(this.lblTimeChart);
            this.panel2.Location = new System.Drawing.Point(12, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 872);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Controls.Add(this.pbLadderChart);
            this.panel3.Controls.Add(this.lblLadder);
            this.panel3.Location = new System.Drawing.Point(964, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(925, 872);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel4.Controls.Add(this.lblLog);
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Location = new System.Drawing.Point(12, 994);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1880, 43);
            this.panel4.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 11);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Enabled = false;
            this.lblLog.Font = new System.Drawing.Font("210 옴니굴림 040", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLog.ForeColor = System.Drawing.SystemColors.Window;
            this.lblLog.Location = new System.Drawing.Point(278, 12);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(534, 22);
            this.lblLog.TabIndex = 1;
            this.lblLog.Text = "[YY:MM:DD-24:00:00][Log Level][Position][Contents]";
            this.lblLog.Click += new System.EventHandler(this.lblLog_Click);
            // 
            // lblTimeChart
            // 
            this.lblTimeChart.AutoSize = true;
            this.lblTimeChart.Font = new System.Drawing.Font("210 옴니굴림 040", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimeChart.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblTimeChart.Location = new System.Drawing.Point(14, 15);
            this.lblTimeChart.Name = "lblTimeChart";
            this.lblTimeChart.Size = new System.Drawing.Size(146, 27);
            this.lblTimeChart.TabIndex = 10;
            this.lblTimeChart.Text = "Time Chart";
            // 
            // lblLadder
            // 
            this.lblLadder.AutoSize = true;
            this.lblLadder.Font = new System.Drawing.Font("210 옴니굴림 040", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLadder.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblLadder.Location = new System.Drawing.Point(13, 15);
            this.lblLadder.Name = "lblLadder";
            this.lblLadder.Size = new System.Drawing.Size(174, 27);
            this.lblLadder.TabIndex = 11;
            this.lblLadder.Text = "Ladder Chart";
            // 
            // pbTimeChart
            // 
            this.pbTimeChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbTimeChart.Image = global::TimeChartEditor.Properties.Resources.timechart;
            this.pbTimeChart.Location = new System.Drawing.Point(14, 45);
            this.pbTimeChart.Name = "pbTimeChart";
            this.pbTimeChart.Size = new System.Drawing.Size(896, 789);
            this.pbTimeChart.TabIndex = 11;
            this.pbTimeChart.TabStop = false;
            // 
            // pbLadderChart
            // 
            this.pbLadderChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLadderChart.Image = global::TimeChartEditor.Properties.Resources.ladderchart;
            this.pbLadderChart.Location = new System.Drawing.Point(13, 45);
            this.pbLadderChart.Name = "pbLadderChart";
            this.pbLadderChart.Size = new System.Drawing.Size(863, 789);
            this.pbLadderChart.TabIndex = 12;
            this.pbLadderChart.TabStop = false;
            // 
            // TimeChartMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("210 옴니굴림 040", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "TimeChartMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeChartEditor";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTimeChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLadderChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnLoadCSV;
        private Button btnLoadTimeChart;
        private Label lblCorp;
        private Label lblTitle;
        private Button btnQuit;
        private Button btnReset;
        private Label label1;
        private Label lblSubSteps;
        private Label lblTnow;
        private Label lblSubTnow;
        private Button btnAnalysis;
        private Button btnRun;
        private Button btnMapping;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label lblLog;
        private ProgressBar progressBar1;
        private PictureBox pbTimeChart;
        private Label lblTimeChart;
        private PictureBox pbLadderChart;
        private Label lblLadder;
    }
}