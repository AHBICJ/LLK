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
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Combo = new System.Windows.Forms.Label();
            this.ComboLabel = new System.Windows.Forms.Label();
            this.CountDown = new System.Windows.Forms.Label();
            this.MessUp = new System.Windows.Forms.Button();
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
            this.Tip.Location = new System.Drawing.Point(520, 198);
            this.Tip.Name = "Tip";
            this.Tip.Size = new System.Drawing.Size(75, 23);
            this.Tip.TabIndex = 1;
            this.Tip.Text = "提示";
            this.Tip.UseVisualStyleBackColor = true;
            this.Tip.Click += new System.EventHandler(this.Tip_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(520, 30);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(520, 114);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 23);
            this.Pause.TabIndex = 3;
            this.Pause.Text = "暂停";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(509, 442);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(43, 13);
            this.ScoreLabel.TabIndex = 5;
            this.ScoreLabel.Text = "得分：";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Location = new System.Drawing.Point(568, 442);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(13, 13);
            this.Score.TabIndex = 6;
            this.Score.Text = "0";
            this.Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Combo
            // 
            this.Combo.AutoSize = true;
            this.Combo.Location = new System.Drawing.Point(568, 467);
            this.Combo.Name = "Combo";
            this.Combo.Size = new System.Drawing.Size(13, 13);
            this.Combo.TabIndex = 10;
            this.Combo.Text = "0";
            this.Combo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboLabel
            // 
            this.ComboLabel.AutoSize = true;
            this.ComboLabel.Location = new System.Drawing.Point(509, 467);
            this.ComboLabel.Name = "ComboLabel";
            this.ComboLabel.Size = new System.Drawing.Size(43, 13);
            this.ComboLabel.TabIndex = 9;
            this.ComboLabel.Text = "连击：";
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountDown.ForeColor = System.Drawing.Color.Red;
            this.CountDown.Location = new System.Drawing.Point(515, 352);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(80, 55);
            this.CountDown.TabIndex = 11;
            this.CountDown.Text = "60";
            this.CountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessUp
            // 
            this.MessUp.Location = new System.Drawing.Point(520, 282);
            this.MessUp.Name = "MessUp";
            this.MessUp.Size = new System.Drawing.Size(75, 23);
            this.MessUp.TabIndex = 12;
            this.MessUp.Text = "打乱";
            this.MessUp.UseVisualStyleBackColor = true;
            this.MessUp.Click += new System.EventHandler(this.MessUp_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LLK.Images.Loading;
            this.ClientSize = new System.Drawing.Size(643, 529);
            this.Controls.Add(this.MessUp);
            this.Controls.Add(this.CountDown);
            this.Controls.Add(this.Combo);
            this.Controls.Add(this.ComboLabel);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.ScoreLabel);
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
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Combo;
        private System.Windows.Forms.Label ComboLabel;
        private System.Windows.Forms.Label CountDown;
        private System.Windows.Forms.Button MessUp;
    }
}

