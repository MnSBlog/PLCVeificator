namespace Pinokio.MPV
{
    partial class VerifierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.middlePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mesTextBox = new System.Windows.Forms.TextBox();
            this.tcTextBox = new System.Windows.Forms.TextBox();
            this.cimTextBox = new System.Windows.Forms.TextBox();
            this.PLCtextBox = new System.Windows.Forms.TextBox();
            this.middlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // middlePanel
            // 
            this.middlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.middlePanel.Controls.Add(this.groupBox2);
            this.middlePanel.Controls.Add(this.groupBox1);
            this.middlePanel.Location = new System.Drawing.Point(12, 103);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(1576, 774);
            this.middlePanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.panel1.Controls.Add(this.PLCtextBox);
            this.panel1.Controls.Add(this.cimTextBox);
            this.panel1.Controls.Add(this.tcTextBox);
            this.panel1.Controls.Add(this.mesTextBox);
            this.panel1.Location = new System.Drawing.Point(4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1584, 74);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(41, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 700);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(828, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 700);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // mesTextBox
            // 
            this.mesTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.mesTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.mesTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.mesTextBox.Location = new System.Drawing.Point(247, 16);
            this.mesTextBox.Multiline = true;
            this.mesTextBox.Name = "mesTextBox";
            this.mesTextBox.Size = new System.Drawing.Size(180, 40);
            this.mesTextBox.TabIndex = 0;
            this.mesTextBox.Text = "MES";
            this.mesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tcTextBox
            // 
            this.tcTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.tcTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.tcTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.tcTextBox.Location = new System.Drawing.Point(556, 16);
            this.tcTextBox.Multiline = true;
            this.tcTextBox.Name = "tcTextBox";
            this.tcTextBox.Size = new System.Drawing.Size(180, 40);
            this.tcTextBox.TabIndex = 1;
            this.tcTextBox.Text = "TC";
            this.tcTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cimTextBox
            // 
            this.cimTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.cimTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.cimTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.cimTextBox.Location = new System.Drawing.Point(861, 16);
            this.cimTextBox.Multiline = true;
            this.cimTextBox.Name = "cimTextBox";
            this.cimTextBox.Size = new System.Drawing.Size(180, 40);
            this.cimTextBox.TabIndex = 2;
            this.cimTextBox.Text = "CIM";
            this.cimTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cimTextBox.TextChanged += new System.EventHandler(this.cimTextBox_TextChanged);
            // 
            // PLCtextBox
            // 
            this.PLCtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.PLCtextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.PLCtextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.PLCtextBox.Location = new System.Drawing.Point(1162, 16);
            this.PLCtextBox.Multiline = true;
            this.PLCtextBox.Name = "PLCtextBox";
            this.PLCtextBox.Size = new System.Drawing.Size(180, 40);
            this.PLCtextBox.TabIndex = 3;
            this.PLCtextBox.Text = "PLC";
            this.PLCtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VerifierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.middlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerifierForm";
            this.Text = "VerifierForm";
            this.middlePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PLCtextBox;
        private System.Windows.Forms.TextBox cimTextBox;
        private System.Windows.Forms.TextBox tcTextBox;
        private System.Windows.Forms.TextBox mesTextBox;
    }
}