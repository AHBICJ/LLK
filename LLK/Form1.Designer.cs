namespace LLK
{
    partial class Main
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
            this.GameBox = new System.Windows.Forms.PictureBox();
            this.Tip = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.TimeBar = new System.Windows.Forms.ProgressBar();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.TimeLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameBox
            // 
            this.GameBox.Location = new System.Drawing.Point(30, 30);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(434, 476);
            this.GameBox.TabIndex = 0;
            this.GameBox.TabStop = false;
            this.GameBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GameBox_Paint);
            this.GameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameBox_MouseClick);
            // 
            // Tip
            // 
            this.Tip.Location = new System.Drawing.Point(515, 56);
            this.Tip.Name = "Tip";
            this.Tip.Size = new System.Drawing.Size(75, 23);
            this.Tip.TabIndex = 1;
            this.Tip.Text = "提示";
            this.Tip.UseVisualStyleBackColor = true;
            this.Tip.Click += new System.EventHandler(this.Tip_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(515, 140);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(515, 223);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 23);
            this.Pause.TabIndex = 3;
            this.Pause.Text = "暂停";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // TimeBar
            // 
            this.TimeBar.Location = new System.Drawing.Point(60, 512);
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(530, 23);
            this.TimeBar.TabIndex = 4;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(509, 367);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(43, 13);
            this.ScoreLabel.TabIndex = 5;
            this.ScoreLabel.Text = "得分：";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(577, 367);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(13, 13);
            this.Score.TabIndex = 6;
            this.Score.Text = "0";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(577, 417);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(13, 13);
            this.Time.TabIndex = 8;
            this.Time.Text = "0";
            // 
            // TimeLeft
            // 
            this.TimeLeft.AutoSize = true;
            this.TimeLeft.Location = new System.Drawing.Point(485, 417);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Size = new System.Drawing.Size(67, 13);
            this.TimeLeft.TabIndex = 7;
            this.TimeLeft.Text = "剩余时间：";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 573);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.TimeLeft);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.TimeBar);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Tip);
            this.Controls.Add(this.GameBox);
            this.Name = "Main";
            this.Text = "连连看";
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.Button Tip;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.ProgressBar TimeBar;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label TimeLeft;
    }
}

