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
            this.Tip.Location = new System.Drawing.Point(537, 56);
            this.Tip.Name = "Tip";
            this.Tip.Size = new System.Drawing.Size(75, 23);
            this.Tip.TabIndex = 1;
            this.Tip.Text = "提示";
            this.Tip.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(537, 133);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 2;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(537, 223);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(75, 23);
            this.Pause.TabIndex = 3;
            this.Pause.Text = "暂停";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Tip);
            this.Controls.Add(this.GameBox);
            this.Name = "Main";
            this.Text = "连连看";
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.Button Tip;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Pause;
    }
}

