namespace DroneSports
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timeLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.attackTeamTimeLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.경기시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.경기중지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.경기리셋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.attackTeamTimeLabelText = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("맑은 고딕", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.Location = new System.Drawing.Point(774, 145);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(357, 159);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "03:00";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(3, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(698, 114);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "블루팀";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(1192, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(698, 114);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "레드팀";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // attackTeamTimeLabel
            // 
            this.attackTeamTimeLabel.AutoSize = true;
            this.attackTeamTimeLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.attackTeamTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attackTeamTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.attackTeamTimeLabel.Font = new System.Drawing.Font("맑은 고딕", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attackTeamTimeLabel.Location = new System.Drawing.Point(848, 534);
            this.attackTeamTimeLabel.Name = "attackTeamTimeLabel";
            this.attackTeamTimeLabel.Size = new System.Drawing.Size(201, 161);
            this.attackTeamTimeLabel.TabIndex = 0;
            this.attackTeamTimeLabel.Text = "18";
            this.attackTeamTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.attackTeamTimeLabel.Click += new System.EventHandler(this.attackTeamTimeLabel_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.경기시작ToolStripMenuItem,
            this.경기중지ToolStripMenuItem,
            this.경기리셋ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 경기시작ToolStripMenuItem
            // 
            this.경기시작ToolStripMenuItem.Name = "경기시작ToolStripMenuItem";
            this.경기시작ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.경기시작ToolStripMenuItem.Text = "경기 시작";
            this.경기시작ToolStripMenuItem.Click += new System.EventHandler(this.경기시작ToolStripMenuItem_Click);
            // 
            // 경기중지ToolStripMenuItem
            // 
            this.경기중지ToolStripMenuItem.Name = "경기중지ToolStripMenuItem";
            this.경기중지ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.경기중지ToolStripMenuItem.Text = "경기 중지";
            this.경기중지ToolStripMenuItem.Click += new System.EventHandler(this.경기중지ToolStripMenuItem_Click);
            // 
            // 경기리셋ToolStripMenuItem
            // 
            this.경기리셋ToolStripMenuItem.Name = "경기리셋ToolStripMenuItem";
            this.경기리셋ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.경기리셋ToolStripMenuItem.Text = "경기 리셋";
            this.경기리셋ToolStripMenuItem.Click += new System.EventHandler(this.경기리셋ToolStripMenuItem_Click);
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameModeLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.gameModeLabel.Location = new System.Drawing.Point(881, 129);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(149, 41);
            this.gameModeLabel.TabIndex = 5;
            this.gameModeLabel.Text = "경기 종료";
            this.gameModeLabel.Click += new System.EventHandler(this.gameModeLabel_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.MistyRose;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox3.Location = new System.Drawing.Point(-28, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(1952, 107);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "제 1회 드론 농구대회";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 199.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(171, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 442);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("맑은 고딕", 199.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.ForeColor = System.Drawing.Color.Blue;
            this.textBox4.Location = new System.Drawing.Point(3, 263);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(698, 462);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("맑은 고딕", 199.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox5.ForeColor = System.Drawing.Color.Red;
            this.textBox5.Location = new System.Drawing.Point(1192, 260);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(698, 462);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // attackTeamTimeLabelText
            // 
            this.attackTeamTimeLabelText.CausesValidation = false;
            this.attackTeamTimeLabelText.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.attackTeamTimeLabelText.ForeColor = System.Drawing.Color.LimeGreen;
            this.attackTeamTimeLabelText.Location = new System.Drawing.Point(848, 484);
            this.attackTeamTimeLabelText.Name = "attackTeamTimeLabelText";
            this.attackTeamTimeLabelText.Size = new System.Drawing.Size(201, 47);
            this.attackTeamTimeLabelText.TabIndex = 9;
            this.attackTeamTimeLabelText.Text = "공격 시간";
            this.attackTeamTimeLabelText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(3, 803);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(1887, 218);
            this.textBox7.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(848, 698);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "1점슛";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(1055, 651);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 44);
            this.button2.TabIndex = 12;
            this.button2.Text = "1";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(1055, 601);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 44);
            this.button3.TabIndex = 13;
            this.button3.Text = "2";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Lime;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(1055, 551);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 44);
            this.button4.TabIndex = 14;
            this.button4.Text = "3";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.attackTeamTimeLabelText);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.gameModeLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.attackTeamTimeLabel);
            this.Controls.Add(this.timeLabel);
            this.Name = "Form1";
            this.Text = "Drone Sports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label timeLabel;
        private TextBox textBox1;
        private TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
        private Label attackTeamTimeLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 경기시작ToolStripMenuItem;
        private ToolStripMenuItem 경기중지ToolStripMenuItem;
        private ToolStripMenuItem 경기리셋ToolStripMenuItem;
        private Label gameModeLabel;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox attackTeamTimeLabelText;
        private TextBox textBox7;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}