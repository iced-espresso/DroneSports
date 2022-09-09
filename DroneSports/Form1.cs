using System.Diagnostics;
using System.Net.Http.Headers;

namespace DroneSports
{

    public partial class Form1 : Form
    {
        private static int secondLabelResetValue = 6;

        enum TeamColor
        {
            Red,
            Blue
        }

        class Team
        {
            public TeamColor color = TeamColor.Blue;
            public Label label;
            public TextBox textBox;

            public Team(Label label, TextBox textBox)
            {
                this.color = TeamColor.Blue;
                this.label = label;
                this.textBox = textBox;
                label.ForeColor = Color.Blue;
            }

            public void Reset()
            {
                color = TeamColor.Blue;
                label.ForeColor = Color.Blue;
                label.Text = secondLabelResetValue.ToString("00");

                textBox.ForeColor = Color.Blue; 
            }

            public void ChangeTeam()
            {
                if (this.color == TeamColor.Blue)
                {
                    this.color = TeamColor.Red;
                    label.ForeColor = Color.Red;
                    textBox.ForeColor = Color.Red;
                }
                else if (this.color == TeamColor.Red)
                {
                    this.color = TeamColor.Blue;
                    label.ForeColor = Color.Blue;
                    textBox.ForeColor = Color.Blue;
                }
            }
        }

        enum GameModeEnum
        {
            INGAME,
            PAUSE,
            IDLE
        }

        class GameMode
        {
            public GameModeEnum mode = GameModeEnum.IDLE;
            private Label label;
            public GameMode(GameModeEnum mode, Label label)
            {
                this.mode = mode;
                this.label = label;
            }

            public void End()
            {
                mode = GameModeEnum.IDLE;
                label.Text = "경기 종료";
            }

            public void Start()
            {
                if (mode == GameModeEnum.INGAME)
                {
                    throw new ArgumentException("이미 게임 중입니다.");
                }
                mode = GameModeEnum.INGAME;
                label.Text = "경기 중";
            }

            public void Pause()
            {
                if (mode != GameModeEnum.INGAME)
                {
                    throw new ArgumentException("경기 중이 아닙니다.");
                }
                mode = GameModeEnum.PAUSE;
                label.Text = "경기 중지";
            }
        }

        Stopwatch stopwatch = new Stopwatch();
        long prevTime;


        public Form1()
        {
            InitializeComponent();
            attackTeam = new Team(attackTeamTimeLabel, attackTeamTimeLabelText);
            currentGameMode = new GameMode(GameModeEnum.IDLE, gameModeLabel);

        }

        Team attackTeam;
        GameMode currentGameMode;


        private void Form1_Load(object sender, EventArgs e)
        {
            resetGame();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long currentTime = stopwatch.ElapsedMilliseconds;
            if (currentTime - prevTime >= 1000)
            {
                prevTime = currentTime;

                String[] strs = timeLabel.Text.Split(":");
                int minutate = Convert.ToInt32(strs[0]);
                int second = Convert.ToInt32(strs[1]);
                DateTime dt = new DateTime(1, 1, 1, 1, minutate, second);
                DateTime newDt = dt.AddSeconds(-1);
                DateTime refTime = new DateTime(1, 1, 1, 1, 0, 0);

                timeLabel.Text = newDt.Minute.ToString("00") + ":" + newDt.Second.ToString("00");

                int roundSecond = Convert.ToInt32(attackTeamTimeLabel.Text);
                if (roundSecond > 0)
                {   
                    attackTeamTimeLabel.Text = (roundSecond - 1).ToString("00");
                }
                else
                {
                    attackTeam.ChangeTeam();
                    attackTeamTimeLabel.Text = secondLabelResetValue.ToString("00");
                }

                roundSecond = Convert.ToInt32(attackTeamTimeLabel.Text);
                if (roundSecond > 4)
                {
                    button4.Visible = true;
                    button3.Visible = true;
                    button2.Visible = true;
                }
                else if(roundSecond > 2)
                {
                    button4.Visible = false;
                    button3.Visible = true;
                    button2.Visible = true;
                }
                else if (roundSecond >= 0)
                {
                    button4.Visible = false;
                    button3.Visible = false;
                    button2.Visible = true;
                }


                    if (newDt <= refTime)
                {
                    endGame();
                    return;
                }
            }
        }
        private void endGame()
        {
            timer1.Enabled = false;
            stopwatch.Stop();
            currentGameMode.End();
        }

        private void startGame()
        {
            if(timeLabel.Text == "00:00")
            {
                resetGame();
            }
            timer1.Enabled = true;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            prevTime = stopwatch.ElapsedMilliseconds;
            currentGameMode.Start();

        }

        private void pauseGame()
        {
            timer1.Enabled = false;
            currentGameMode.Pause();
        }

        private void resetGame()
        {
            timer1.Enabled = false;
            stopwatch.Stop();
            textBox4.Text = "0";
            textBox5.Text = "0";
            timeLabel.Text = getGameTime();
            attackTeam.Reset();

            currentGameMode.End();
        }

        private string getGameTime()
        {
            return "01:00";
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void 경기리셋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void 경기시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void 경기중지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pauseGame();
        }

        private void gameModeLabel_Click(object sender, EventArgs e)
        {

        }

        private void attackTeamTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}