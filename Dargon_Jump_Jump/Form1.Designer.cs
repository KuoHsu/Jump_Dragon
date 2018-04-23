namespace Dargon_Jump_Jump
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Score_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PauseGame = new System.Windows.Forms.ToolStripMenuItem();
            this.ProceedGame = new System.Windows.Forms.ToolStripMenuItem();
            this.StopGame = new System.Windows.Forms.ToolStripMenuItem();
            this.ScoreText = new System.Windows.Forms.Label();
            this.DiedLabel = new System.Windows.Forms.Label();
            this.Restart = new System.Windows.Forms.Button();
            this.Start_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Score_label
            // 
            this.Score_label.AutoSize = true;
            this.Score_label.BackColor = System.Drawing.Color.Transparent;
            this.Score_label.Font = new System.Drawing.Font("Hack", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_label.ForeColor = System.Drawing.Color.Black;
            this.Score_label.Location = new System.Drawing.Point(251, 32);
            this.Score_label.Name = "Score_label";
            this.Score_label.Size = new System.Drawing.Size(21, 22);
            this.Score_label.TabIndex = 0;
            this.Score_label.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PauseGame,
            this.ProceedGame,
            this.StopGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PauseGame
            // 
            this.PauseGame.Name = "PauseGame";
            this.PauseGame.ShortcutKeyDisplayString = "Ctrl+Q";
            this.PauseGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.PauseGame.Size = new System.Drawing.Size(67, 20);
            this.PauseGame.Text = "暫停遊戲";
            this.PauseGame.Click += new System.EventHandler(this.PauseGame_Click);
            // 
            // ProceedGame
            // 
            this.ProceedGame.Name = "ProceedGame";
            this.ProceedGame.ShortcutKeyDisplayString = "Ctrl+A";
            this.ProceedGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.ProceedGame.Size = new System.Drawing.Size(67, 20);
            this.ProceedGame.Text = "繼續遊戲";
            this.ProceedGame.Click += new System.EventHandler(this.ProceedGame_Click);
            // 
            // StopGame
            // 
            this.StopGame.Name = "StopGame";
            this.StopGame.ShortcutKeyDisplayString = "Ctrl+X";
            this.StopGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.StopGame.Size = new System.Drawing.Size(67, 20);
            this.StopGame.Text = "停止遊戲";
            this.StopGame.Click += new System.EventHandler(this.StopGame_Click);
            // 
            // ScoreText
            // 
            this.ScoreText.AutoSize = true;
            this.ScoreText.BackColor = System.Drawing.Color.Transparent;
            this.ScoreText.Font = new System.Drawing.Font("Hack", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreText.ForeColor = System.Drawing.Color.Black;
            this.ScoreText.Location = new System.Drawing.Point(168, 32);
            this.ScoreText.Name = "ScoreText";
            this.ScoreText.Size = new System.Drawing.Size(88, 22);
            this.ScoreText.TabIndex = 5;
            this.ScoreText.Text = "Score：";
            // 
            // DiedLabel
            // 
            this.DiedLabel.AutoSize = true;
            this.DiedLabel.BackColor = System.Drawing.Color.Transparent;
            this.DiedLabel.Font = new System.Drawing.Font("Hack", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiedLabel.ForeColor = System.Drawing.Color.Red;
            this.DiedLabel.Location = new System.Drawing.Point(159, 62);
            this.DiedLabel.Name = "DiedLabel";
            this.DiedLabel.Size = new System.Drawing.Size(383, 74);
            this.DiedLabel.TabIndex = 6;
            this.DiedLabel.Text = "GMAE OVER";
            this.DiedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DiedLabel.Visible = false;
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.Transparent;
            this.Restart.Font = new System.Drawing.Font("Hack", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Restart.Location = new System.Drawing.Point(290, 139);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(125, 40);
            this.Restart.TabIndex = 7;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Visible = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.Color.Transparent;
            this.Start_button.Font = new System.Drawing.Font("Hack", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_button.Location = new System.Drawing.Point(290, 139);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(125, 40);
            this.Start_button.TabIndex = 8;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = false;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(684, 288);
            this.Controls.Add(this.Start_button);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.DiedLabel);
            this.Controls.Add(this.ScoreText);
            this.Controls.Add(this.Score_label);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "恐龍跳跳";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Score_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label ScoreText;
        private System.Windows.Forms.Label DiedLabel;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.ToolStripMenuItem PauseGame;
        private System.Windows.Forms.ToolStripMenuItem ProceedGame;
        private System.Windows.Forms.ToolStripMenuItem StopGame;
        private System.Windows.Forms.Button Start_button;
    }
}

