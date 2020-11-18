namespace transtrusttool
{
    partial class main
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
            this.account1_start_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_stop1 = new System.Windows.Forms.Button();
            this.account1TptRun = new System.Windows.Forms.Button();
            this.btnAuto1 = new System.Windows.Forms.Button();
            this.account2_start_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.account2TptRun = new System.Windows.Forms.Button();
            this.btn_stop2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAuto2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // account1_start_btn
            // 
            this.account1_start_btn.Location = new System.Drawing.Point(373, 24);
            this.account1_start_btn.Name = "account1_start_btn";
            this.account1_start_btn.Size = new System.Drawing.Size(76, 26);
            this.account1_start_btn.TabIndex = 1;
            this.account1_start_btn.Text = "TDC - Run";
            this.account1_start_btn.UseVisualStyleBackColor = true;
            this.account1_start_btn.Visible = false;
            this.account1_start_btn.Click += new System.EventHandler(this.Account1_start_btn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.Config_btn_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_stop1);
            this.groupBox1.Controls.Add(this.account1TptRun);
            this.groupBox1.Controls.Add(this.btnAuto1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.account1_start_btn);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account 1";
            // 
            // btn_stop1
            // 
            this.btn_stop1.Location = new System.Drawing.Point(279, 24);
            this.btn_stop1.Name = "btn_stop1";
            this.btn_stop1.Size = new System.Drawing.Size(65, 26);
            this.btn_stop1.TabIndex = 6;
            this.btn_stop1.Text = "Stop";
            this.btn_stop1.UseVisualStyleBackColor = true;
            this.btn_stop1.Visible = false;
            this.btn_stop1.Click += new System.EventHandler(this.Btn_stop1_Click);
            // 
            // account1TptRun
            // 
            this.account1TptRun.Location = new System.Drawing.Point(455, 24);
            this.account1TptRun.Name = "account1TptRun";
            this.account1TptRun.Size = new System.Drawing.Size(76, 26);
            this.account1TptRun.TabIndex = 5;
            this.account1TptRun.Text = "TPT - Run";
            this.account1TptRun.UseVisualStyleBackColor = true;
            this.account1TptRun.Visible = false;
            this.account1TptRun.Click += new System.EventHandler(this.Account1TptRun_Click);
            // 
            // btnAuto1
            // 
            this.btnAuto1.Location = new System.Drawing.Point(191, 24);
            this.btnAuto1.Name = "btnAuto1";
            this.btnAuto1.Size = new System.Drawing.Size(65, 26);
            this.btnAuto1.TabIndex = 4;
            this.btnAuto1.Text = "Auto";
            this.btnAuto1.UseVisualStyleBackColor = true;
            this.btnAuto1.Click += new System.EventHandler(this.BtnAuto1_Click);
            // 
            // account2_start_btn
            // 
            this.account2_start_btn.Location = new System.Drawing.Point(373, 24);
            this.account2_start_btn.Name = "account2_start_btn";
            this.account2_start_btn.Size = new System.Drawing.Size(76, 26);
            this.account2_start_btn.TabIndex = 1;
            this.account2_start_btn.Text = "TDC - Run";
            this.account2_start_btn.UseVisualStyleBackColor = true;
            this.account2_start_btn.Visible = false;
            this.account2_start_btn.Click += new System.EventHandler(this.Account2_start_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account2";
            // 
            // account2TptRun
            // 
            this.account2TptRun.Location = new System.Drawing.Point(455, 24);
            this.account2TptRun.Name = "account2TptRun";
            this.account2TptRun.Size = new System.Drawing.Size(76, 26);
            this.account2TptRun.TabIndex = 6;
            this.account2TptRun.Text = "TPT - Run";
            this.account2TptRun.UseVisualStyleBackColor = true;
            this.account2TptRun.Visible = false;
            this.account2TptRun.Click += new System.EventHandler(this.Account2TptRun_Click);
            // 
            // btn_stop2
            // 
            this.btn_stop2.Location = new System.Drawing.Point(279, 25);
            this.btn_stop2.Name = "btn_stop2";
            this.btn_stop2.Size = new System.Drawing.Size(65, 26);
            this.btn_stop2.TabIndex = 7;
            this.btn_stop2.Text = "Stop";
            this.btn_stop2.UseVisualStyleBackColor = true;
            this.btn_stop2.Visible = false;
            this.btn_stop2.Click += new System.EventHandler(this.Btn_stop2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_stop2);
            this.groupBox2.Controls.Add(this.account2TptRun);
            this.groupBox2.Controls.Add(this.btnAuto2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.account2_start_btn);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(549, 67);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account 2";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnAuto2
            // 
            this.btnAuto2.Location = new System.Drawing.Point(191, 24);
            this.btnAuto2.Name = "btnAuto2";
            this.btnAuto2.Size = new System.Drawing.Size(65, 26);
            this.btnAuto2.TabIndex = 5;
            this.btnAuto2.Text = "Auto";
            this.btnAuto2.UseVisualStyleBackColor = true;
            this.btnAuto2.Click += new System.EventHandler(this.BtnAuto2_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 193);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "TranstrustTool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button account1_start_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button account1TptRun;
        private System.Windows.Forms.Button btn_stop1;
        private System.Windows.Forms.Button btnAuto1;
        private System.Windows.Forms.Button account2_start_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button account2TptRun;
        private System.Windows.Forms.Button btn_stop2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAuto2;
    }
}

