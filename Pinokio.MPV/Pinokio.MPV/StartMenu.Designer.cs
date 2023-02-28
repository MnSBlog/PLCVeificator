
namespace Pinokio.MPV
{
    partial class StartMenu
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.sidePanel = new System.Windows.Forms.Panel();
            this.quitBtn = new System.Windows.Forms.Button();
            this.optionBtn = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.dataLoadBtn = new System.Windows.Forms.Button();
            this.verifierBtn = new System.Windows.Forms.Button();
            this.mainBtn = new System.Windows.Forms.Button();
            this.menuTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.sidePanel.Controls.Add(this.quitBtn);
            this.sidePanel.Controls.Add(this.optionBtn);
            this.sidePanel.Controls.Add(this.reportBtn);
            this.sidePanel.Controls.Add(this.dataLoadBtn);
            this.sidePanel.Controls.Add(this.verifierBtn);
            this.sidePanel.Controls.Add(this.mainBtn);
            this.sidePanel.Location = new System.Drawing.Point(0, 56);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(245, 977);
            this.sidePanel.TabIndex = 0;
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.quitBtn.Font = new System.Drawing.Font("굴림", 18F);
            this.quitBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.quitBtn.Location = new System.Drawing.Point(-3, 917);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(245, 57);
            this.quitBtn.TabIndex = 5;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.optionBtn.Font = new System.Drawing.Font("굴림", 18F);
            this.optionBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.optionBtn.Location = new System.Drawing.Point(0, 277);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(245, 57);
            this.optionBtn.TabIndex = 4;
            this.optionBtn.Text = "Option";
            this.optionBtn.UseVisualStyleBackColor = false;
            // 
            // reportBtn
            // 
            this.reportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.reportBtn.Font = new System.Drawing.Font("굴림", 18F);
            this.reportBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.reportBtn.Location = new System.Drawing.Point(0, 208);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(245, 57);
            this.reportBtn.TabIndex = 3;
            this.reportBtn.Text = "Report";
            this.reportBtn.UseVisualStyleBackColor = false;
            // 
            // dataLoadBtn
            // 
            this.dataLoadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.dataLoadBtn.Font = new System.Drawing.Font("굴림", 18F);
            this.dataLoadBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.dataLoadBtn.Location = new System.Drawing.Point(0, 139);
            this.dataLoadBtn.Name = "dataLoadBtn";
            this.dataLoadBtn.Size = new System.Drawing.Size(245, 57);
            this.dataLoadBtn.TabIndex = 2;
            this.dataLoadBtn.Text = "Data Load";
            this.dataLoadBtn.UseVisualStyleBackColor = false;
            // 
            // verifierBtn
            // 
            this.verifierBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.verifierBtn.Font = new System.Drawing.Font("굴림", 18F);
            this.verifierBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.verifierBtn.Location = new System.Drawing.Point(0, 69);
            this.verifierBtn.Name = "verifierBtn";
            this.verifierBtn.Size = new System.Drawing.Size(245, 57);
            this.verifierBtn.TabIndex = 1;
            this.verifierBtn.Text = "Verifier";
            this.verifierBtn.UseVisualStyleBackColor = false;
            this.verifierBtn.Click += new System.EventHandler(this.verifierBtn_Click);
            // 
            // mainBtn
            // 
            this.mainBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.mainBtn.Font = new System.Drawing.Font("굴림", 18F);
            this.mainBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.mainBtn.Location = new System.Drawing.Point(0, 0);
            this.mainBtn.Name = "mainBtn";
            this.mainBtn.Size = new System.Drawing.Size(245, 57);
            this.mainBtn.TabIndex = 0;
            this.mainBtn.Text = "Main";
            this.mainBtn.UseVisualStyleBackColor = false;
            this.mainBtn.Click += new System.EventHandler(this.mainBtn_Click);
            // 
            // menuTextBox
            // 
            this.menuTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.menuTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.menuTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.menuTextBox.Location = new System.Drawing.Point(-2, 29);
            this.menuTextBox.Multiline = true;
            this.menuTextBox.Name = "menuTextBox";
            this.menuTextBox.Size = new System.Drawing.Size(247, 29);
            this.menuTextBox.TabIndex = 1;
            this.menuTextBox.Text = "Menu";
            // 
            // titleTextBox
            // 
            this.titleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.titleTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.titleTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.titleTextBox.Location = new System.Drawing.Point(-2, 0);
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(1919, 31);
            this.titleTextBox.TabIndex = 2;
            this.titleTextBox.Text = "Pinokio MPV";
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.logTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.logTextBox.Location = new System.Drawing.Point(0, 1039);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(1917, 38);
            this.logTextBox.TabIndex = 3;
            this.logTextBox.Text = "Log";
            // 
            // centerPanel
            // 
            this.centerPanel.Location = new System.Drawing.Point(280, 50);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(1600, 900);
            this.centerPanel.TabIndex = 4;
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.menuTextBox);
            this.Controls.Add(this.sidePanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StartMenu_Load);
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button mainBtn;
        private System.Windows.Forms.TextBox menuTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Button dataLoadBtn;
        private System.Windows.Forms.Button verifierBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Panel centerPanel;
    }
}

