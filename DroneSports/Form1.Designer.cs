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
            this.leftTeamName = new System.Windows.Forms.TextBox();
            this.rightTeamName = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.코트체인지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.경기중지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.경기리셋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이미지삽입ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameModeLabel = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.leftTeamMember = new System.Windows.Forms.TextBox();
            this.rightTeamMember = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.startGameButton = new System.Windows.Forms.Button();
            this.leftTeamScore = new System.Windows.Forms.Label();
            this.rightTeamScore = new System.Windows.Forms.Label();
            this.leftTeamSetScore = new System.Windows.Forms.Label();
            this.rightTeamSetScore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.restStartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("맑은 고딕", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(774, 148);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(357, 159);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "03:00";
            // 
            // leftTeamName
            // 
            this.leftTeamName.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leftTeamName.ForeColor = System.Drawing.Color.Blue;
            this.leftTeamName.Location = new System.Drawing.Point(3, 129);
            this.leftTeamName.Name = "leftTeamName";
            this.leftTeamName.Size = new System.Drawing.Size(698, 114);
            this.leftTeamName.TabIndex = 2;
            this.leftTeamName.TabStop = false;
            this.leftTeamName.Text = "블루팀";
            this.leftTeamName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightTeamName
            // 
            this.rightTeamName.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rightTeamName.ForeColor = System.Drawing.Color.Red;
            this.rightTeamName.Location = new System.Drawing.Point(1192, 129);
            this.rightTeamName.Name = "rightTeamName";
            this.rightTeamName.Size = new System.Drawing.Size(698, 114);
            this.rightTeamName.TabIndex = 3;
            this.rightTeamName.TabStop = false;
            this.rightTeamName.Text = "레드팀";
            this.rightTeamName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.코트체인지ToolStripMenuItem,
            this.경기중지ToolStripMenuItem,
            this.경기리셋ToolStripMenuItem,
            this.이미지삽입ToolStripMenuItem,
            this.설정ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 124);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 코트체인지ToolStripMenuItem
            // 
            this.코트체인지ToolStripMenuItem.Name = "코트체인지ToolStripMenuItem";
            this.코트체인지ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.코트체인지ToolStripMenuItem.Text = "코트 체인지";
            this.코트체인지ToolStripMenuItem.Click += new System.EventHandler(this.코트체인지ToolStripMenuItem_Click);
            // 
            // 경기중지ToolStripMenuItem
            // 
            this.경기중지ToolStripMenuItem.Name = "경기중지ToolStripMenuItem";
            this.경기중지ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.경기중지ToolStripMenuItem.Text = "경기 중지";
            this.경기중지ToolStripMenuItem.Click += new System.EventHandler(this.경기중지ToolStripMenuItem_Click);
            // 
            // 경기리셋ToolStripMenuItem
            // 
            this.경기리셋ToolStripMenuItem.Name = "경기리셋ToolStripMenuItem";
            this.경기리셋ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.경기리셋ToolStripMenuItem.Text = "스코어 리셋";
            this.경기리셋ToolStripMenuItem.Click += new System.EventHandler(this.경기리셋ToolStripMenuItem_Click);
            // 
            // 이미지삽입ToolStripMenuItem
            // 
            this.이미지삽입ToolStripMenuItem.Name = "이미지삽입ToolStripMenuItem";
            this.이미지삽입ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.이미지삽입ToolStripMenuItem.Text = "이미지 삽입";
            this.이미지삽입ToolStripMenuItem.Click += new System.EventHandler(this.이미지삽입ToolStripMenuItem_Click);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.설정ToolStripMenuItem.Text = "설정";
            this.설정ToolStripMenuItem.Click += new System.EventHandler(this.설정ToolStripMenuItem_Click);
            // 
            // gameModeLabel
            // 
            this.gameModeLabel.AutoSize = true;
            this.gameModeLabel.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameModeLabel.ForeColor = System.Drawing.Color.White;
            this.gameModeLabel.Location = new System.Drawing.Point(881, 129);
            this.gameModeLabel.Name = "gameModeLabel";
            this.gameModeLabel.Size = new System.Drawing.Size(119, 41);
            this.gameModeLabel.TabIndex = 5;
            this.gameModeLabel.Text = "경기 전";
            this.gameModeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.textBox3.TabStop = false;
            this.textBox3.Text = "제 1회 드론 농구대회";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leftTeamMember
            // 
            this.leftTeamMember.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftTeamMember.Location = new System.Drawing.Point(3, 803);
            this.leftTeamMember.Multiline = true;
            this.leftTeamMember.Name = "leftTeamMember";
            this.leftTeamMember.Size = new System.Drawing.Size(698, 231);
            this.leftTeamMember.TabIndex = 10;
            this.leftTeamMember.TabStop = false;
            this.leftTeamMember.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.leftTeamMember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.leftTeamMember_KeyDown);
            // 
            // rightTeamMember
            // 
            this.rightTeamMember.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rightTeamMember.Location = new System.Drawing.Point(1192, 803);
            this.rightTeamMember.Multiline = true;
            this.rightTeamMember.Name = "rightTeamMember";
            this.rightTeamMember.Size = new System.Drawing.Size(698, 231);
            this.rightTeamMember.TabIndex = 10;
            this.rightTeamMember.TabStop = false;
            this.rightTeamMember.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(707, 803);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(878, 201);
            this.startGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(135, 33);
            this.startGameButton.TabIndex = 16;
            this.startGameButton.Text = "경기시작";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // leftTeamScore
            // 
            this.leftTeamScore.BackColor = System.Drawing.Color.White;
            this.leftTeamScore.Font = new System.Drawing.Font("맑은 고딕", 230.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leftTeamScore.ForeColor = System.Drawing.Color.Blue;
            this.leftTeamScore.Location = new System.Drawing.Point(3, 256);
            this.leftTeamScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leftTeamScore.Name = "leftTeamScore";
            this.leftTeamScore.Size = new System.Drawing.Size(699, 544);
            this.leftTeamScore.TabIndex = 17;
            this.leftTeamScore.Text = "0";
            this.leftTeamScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.leftTeamScore.Click += new System.EventHandler(this.leftTeamScore_Click);
            this.leftTeamScore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftTeamScore_MouseDown);
            // 
            // rightTeamScore
            // 
            this.rightTeamScore.BackColor = System.Drawing.Color.White;
            this.rightTeamScore.Font = new System.Drawing.Font("맑은 고딕", 230.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rightTeamScore.ForeColor = System.Drawing.Color.Red;
            this.rightTeamScore.Location = new System.Drawing.Point(1192, 256);
            this.rightTeamScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightTeamScore.Name = "rightTeamScore";
            this.rightTeamScore.Size = new System.Drawing.Size(699, 544);
            this.rightTeamScore.TabIndex = 18;
            this.rightTeamScore.Text = "0";
            this.rightTeamScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rightTeamScore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightTeamScore_MouseDown);
            // 
            // leftTeamSetScore
            // 
            this.leftTeamSetScore.BackColor = System.Drawing.Color.White;
            this.leftTeamSetScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftTeamSetScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftTeamSetScore.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftTeamSetScore.ForeColor = System.Drawing.Color.Blue;
            this.leftTeamSetScore.Location = new System.Drawing.Point(609, 132);
            this.leftTeamSetScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leftTeamSetScore.Name = "leftTeamSetScore";
            this.leftTeamSetScore.Size = new System.Drawing.Size(92, 111);
            this.leftTeamSetScore.TabIndex = 19;
            this.leftTeamSetScore.Text = "0";
            this.leftTeamSetScore.Click += new System.EventHandler(this.label1_Click);
            this.leftTeamSetScore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // rightTeamSetScore
            // 
            this.rightTeamSetScore.BackColor = System.Drawing.Color.White;
            this.rightTeamSetScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightTeamSetScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightTeamSetScore.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rightTeamSetScore.ForeColor = System.Drawing.Color.Red;
            this.rightTeamSetScore.Location = new System.Drawing.Point(1192, 132);
            this.rightTeamSetScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightTeamSetScore.Name = "rightTeamSetScore";
            this.rightTeamSetScore.Size = new System.Drawing.Size(92, 111);
            this.rightTeamSetScore.TabIndex = 20;
            this.rightTeamSetScore.Text = "0";
            this.rightTeamSetScore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Controls.Add(this.restStartButton);
            this.panel1.Controls.Add(this.startGameButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 121);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1980, 999);
            this.panel1.TabIndex = 21;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.panel1_PreviewKeyDown);
            // 
            // restStartButton
            // 
            this.restStartButton.Location = new System.Drawing.Point(878, 243);
            this.restStartButton.Margin = new System.Windows.Forms.Padding(4);
            this.restStartButton.Name = "restStartButton";
            this.restStartButton.Size = new System.Drawing.Size(135, 33);
            this.restStartButton.TabIndex = 16;
            this.restStartButton.Text = "휴식시작";
            this.restStartButton.UseVisualStyleBackColor = true;
            this.restStartButton.Click += new System.EventHandler(this.restStartButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 180F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(749, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 353);
            this.label1.TabIndex = 17;
            this.label1.Text = "vs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.leftTeamSetScore);
            this.Controls.Add(this.rightTeamSetScore);
            this.Controls.Add(this.rightTeamScore);
            this.Controls.Add(this.leftTeamScore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rightTeamMember);
            this.Controls.Add(this.leftTeamMember);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.gameModeLabel);
            this.Controls.Add(this.rightTeamName);
            this.Controls.Add(this.leftTeamName);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Drone Sports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label timeLabel;
        private TextBox leftTeamName;
        private TextBox rightTeamName;
        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 코트체인지ToolStripMenuItem;
        private ToolStripMenuItem 경기중지ToolStripMenuItem;
        private ToolStripMenuItem 경기리셋ToolStripMenuItem;
        private Label gameModeLabel;
        private TextBox textBox3;
        private TextBox leftTeamMember;
        private TextBox rightTeamMember;
        private PictureBox pictureBox1;
        private ToolStripMenuItem 이미지삽입ToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private Button startGameButton;
        private Label leftTeamScore;
        private Label rightTeamScore;
        private Label leftTeamSetScore;
        private Label rightTeamSetScore;
        private Panel panel1;
        private Button restStartButton;
        private ToolStripMenuItem 설정ToolStripMenuItem;
        private Label label1;
    }
}