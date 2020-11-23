namespace transtrusttool.Utils
{
    partial class ConfigurationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._tbDelay2Mess1Acc = new System.Windows.Forms.NumericUpDown();
            this._lDelay2Mess1Acc = new System.Windows.Forms.Label();
            this._tbDelay2Mess2Acc = new System.Windows.Forms.NumericUpDown();
            this._lDelay2Mess2Acc = new System.Windows.Forms.Label();
            this._tbPauseAt = new System.Windows.Forms.NumericUpDown();
            this._lPauseAt = new System.Windows.Forms.Label();
            this._tbPauseTime = new System.Windows.Forms.NumericUpDown();
            this._lPauseTime = new System.Windows.Forms.Label();

            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._tbMakeFriendWithStrangers = new System.Windows.Forms.CheckBox();
            this._lMakeFriendWithStrangers = new System.Windows.Forms.Label();
            this._tbLogWhenSuccessful = new System.Windows.Forms.CheckBox();
            this._lLogWhenSuccessful = new System.Windows.Forms.Label();

            this._bCancel = new System.Windows.Forms.Button();
            this._bSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this._tbDelay2Mess1Acc);
            this.groupBox1.Controls.Add(this._lDelay2Mess1Acc);
            this.groupBox1.Controls.Add(this._tbDelay2Mess2Acc);
            this.groupBox1.Controls.Add(this._lDelay2Mess2Acc);
            this.groupBox1.Controls.Add(this._tbPauseAt);
            this.groupBox1.Controls.Add(this._lPauseAt);
            this.groupBox1.Controls.Add(this._tbPauseTime);
            this.groupBox1.Controls.Add(this._lPauseTime);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình giãn cách khi gửi tin";

            // 
            // _lDelay2Mess1Acc
            // 
            this._lDelay2Mess1Acc.Location = new System.Drawing.Point(9, 25);
            this._lDelay2Mess1Acc.Name = "_lDelay2Mess1Acc";
            this._lDelay2Mess1Acc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._lDelay2Mess1Acc.Size = new System.Drawing.Size(226, 20);
            this._lDelay2Mess1Acc.TabIndex = 0;
            this._lDelay2Mess1Acc.Text = "Hai tin nhắn cách nhau bn giây";
            this._lDelay2Mess1Acc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // _tbDelay2Mess1Acc
            // 
            this._tbDelay2Mess1Acc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbDelay2Mess1Acc.Location = new System.Drawing.Point(242, 25);
            this._tbDelay2Mess1Acc.Name = "_tbDelay2Mess1Acc";
            this._tbDelay2Mess1Acc.Size = new System.Drawing.Size(97, 20);
            this._tbDelay2Mess1Acc.TabIndex = 1;

            // 
            // _lDelay2Mess2Acc
            // 
            this._lDelay2Mess2Acc.Location = new System.Drawing.Point(9, 55);
            this._lDelay2Mess2Acc.Name = "_lDelay2Mess2Acc";
            this._lDelay2Mess2Acc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._lDelay2Mess2Acc.Size = new System.Drawing.Size(226, 20);
            this._lDelay2Mess2Acc.TabIndex = 2;
            this._lDelay2Mess2Acc.Text = "Chuyển số kế tiếp thì ngưng bn giây";
            this._lDelay2Mess2Acc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // _tbDelay2Mess2Acc
            // 
            this._tbDelay2Mess2Acc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbDelay2Mess2Acc.Location = new System.Drawing.Point(242, 55);
            this._tbDelay2Mess2Acc.Name = "_tbDelay2Mess2Acc";
            this._tbDelay2Mess2Acc.Size = new System.Drawing.Size(97, 20);
            this._tbDelay2Mess2Acc.TabIndex = 3;

            // 
            // _lPauseAt
            // 
            this._lPauseAt.Location = new System.Drawing.Point(9, 85);
            this._lPauseAt.Name = "_lPauseAt";
            this._lPauseAt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._lPauseAt.Size = new System.Drawing.Size(226, 19);
            this._lPauseAt.TabIndex = 4;
            this._lPauseAt.Text = "Gửi cho bao nhiêu số thì ngắt quãng";
            this._lPauseAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // _tbPauseAt
            // 
            this._tbPauseAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbPauseAt.Location = new System.Drawing.Point(242, 85);
            this._tbPauseAt.Name = "_tbPauseAt";
            this._tbPauseAt.Size = new System.Drawing.Size(97, 20);
            this._tbPauseAt.TabIndex = 5;

            // 
            // _lPauseTime
            // 
            this._lPauseTime.Location = new System.Drawing.Point(9, 115);
            this._lPauseTime.Name = "_lPauseTime";
            this._lPauseTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._lPauseTime.Size = new System.Drawing.Size(226, 19);
            this._lPauseTime.TabIndex = 6;
            this._lPauseTime.Text = "Ngắt quãng bn giây";
            this._lPauseTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // _tbPauseTime
            // 
            this._tbPauseTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbPauseTime.Location = new System.Drawing.Point(242, 115);
            this._tbPauseTime.Name = "_tbPauseTime";
            this._tbPauseTime.Size = new System.Drawing.Size(97, 20);
            this._tbPauseTime.TabIndex = 7;

            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._lMakeFriendWithStrangers);
            this.groupBox2.Controls.Add(this._tbMakeFriendWithStrangers);
            this.groupBox2.Controls.Add(this._lLogWhenSuccessful);
            this.groupBox2.Controls.Add(this._tbLogWhenSuccessful);
            this.groupBox2.Location = new System.Drawing.Point(6, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tùy chọn khác";

            // 
            // _lMakeFriendWithStrangers
            // 
            this._lMakeFriendWithStrangers.Location = new System.Drawing.Point(9, 25);
            this._lMakeFriendWithStrangers.Name = "_lMakeFriendWithStrangers";
            this._lMakeFriendWithStrangers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._lMakeFriendWithStrangers.Size = new System.Drawing.Size(226, 19);
            this._lMakeFriendWithStrangers.TabIndex = 8;
            this._lMakeFriendWithStrangers.Text = "Gửi kết bạn số lạ";
            this._lMakeFriendWithStrangers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // _tbMakeFriendWithStrangers
            // 
            this._tbMakeFriendWithStrangers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbMakeFriendWithStrangers.Location = new System.Drawing.Point(242, 25);
            this._tbMakeFriendWithStrangers.Name = "_tbMakeFriendWithStrangers";
            this._tbMakeFriendWithStrangers.Size = new System.Drawing.Size(97, 20);
            this._tbMakeFriendWithStrangers.TabIndex = 9;

            // 
            // _lLogWhenSuccessful
            // 
            this._lLogWhenSuccessful.Location = new System.Drawing.Point(9, 55);
            this._lLogWhenSuccessful.Name = "_lLogWhenSuccessful";
            this._lLogWhenSuccessful.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._lLogWhenSuccessful.Size = new System.Drawing.Size(226, 19);
            this._lLogWhenSuccessful.TabIndex = 10;
            this._lLogWhenSuccessful.Text = "Ghi log cả trường hợp thành công";
            this._lLogWhenSuccessful.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // _tbLogWhenSuccessful
            // 
            this._tbLogWhenSuccessful.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._tbLogWhenSuccessful.Location = new System.Drawing.Point(242, 55);
            this._tbLogWhenSuccessful.Name = "_tbLogWhenSuccessful";
            this._tbLogWhenSuccessful.Size = new System.Drawing.Size(97, 20);
            this._tbLogWhenSuccessful.TabIndex = 11;

            // 
            // _bCancel
            // 
            this._bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._bCancel.Location = new System.Drawing.Point(285, 290);
            this._bCancel.Name = "_bCancel";
            this._bCancel.Size = new System.Drawing.Size(75, 23);
            this._bCancel.TabIndex = 23;
            this._bCancel.Text = "Bỏ qua";
            this._bCancel.UseVisualStyleBackColor = true;
            this._bCancel.Click += new System.EventHandler(this._bCancel_Click);
            // 
            // _bSave
            // 
            this._bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._bSave.Location = new System.Drawing.Point(205, 290);
            this._bSave.Name = "_bSave";
            this._bSave.Size = new System.Drawing.Size(75, 23);
            this._bSave.TabIndex = 24;
            this._bSave.Text = "Lưu";
            this._bSave.UseVisualStyleBackColor = true;
            this._bSave.Click += new System.EventHandler(this._bSave_Click);

            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this._bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._bCancel;
            this.ClientSize = new System.Drawing.Size(370, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._bSave);
            this.Controls.Add(this._bCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình hệ thống";
            
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();

            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown _tbDelay2Mess1Acc;
        private System.Windows.Forms.Label _lDelay2Mess1Acc;
        private System.Windows.Forms.NumericUpDown _tbDelay2Mess2Acc;
        private System.Windows.Forms.Label _lDelay2Mess2Acc;
        private System.Windows.Forms.NumericUpDown _tbPauseAt;
        private System.Windows.Forms.Label _lPauseAt;
        private System.Windows.Forms.NumericUpDown _tbPauseTime;
        private System.Windows.Forms.Label _lPauseTime;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox _tbMakeFriendWithStrangers;
        private System.Windows.Forms.Label _lMakeFriendWithStrangers;
        private System.Windows.Forms.CheckBox _tbLogWhenSuccessful;
        private System.Windows.Forms.Label _lLogWhenSuccessful;

        private System.Windows.Forms.Button _bCancel;
        private System.Windows.Forms.Button _bSave;
    }
}