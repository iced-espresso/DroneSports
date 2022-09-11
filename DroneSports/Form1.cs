using System.Diagnostics;
using System.Media;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;
using WMPLib;

namespace DroneSports
{

    public partial class Form1 : Form
    {
        

        class AttackTeam
        {
            public Color currAttackTeam = Color.Blue;
            public Color defaultAttackTeam = Color.Blue;
            public Label label;
            public TextBox textBox;

            public AttackTeam(Label label, TextBox textBox)
            {
                this.defaultAttackTeam = Color.Blue;
                this.currAttackTeam = this.defaultAttackTeam;
                this.label = label;
                this.textBox = textBox;
                label.ForeColor = Color.Blue;
            }

            public void setRed()
            {
                this.currAttackTeam = Color.Red;
                label.ForeColor = Color.Red;
                textBox.ForeColor = Color.Red;
            }

            public void setBlue()
            {
                this.currAttackTeam = Color.Blue;
                label.ForeColor = Color.Blue;
                textBox.ForeColor = Color.Blue;
            }

            public void Reset()
            {
                if (currAttackTeam == Color.Blue)
                {
                    setBlue();
                }
                else if(currAttackTeam == Color.Red)
                {
                    setRed();
                }
                label.Text = CONFIG_ATTACK_TIME.ToString("00");
            }

            public void ChangeTeam()
            {
                if (this.currAttackTeam == Color.Blue)
                {
                    setRed();
                }
                else if (this.currAttackTeam == Color.Red)
                {
                    setBlue();
                }
            }

            public void hardReset()
            {
                if (this.defaultAttackTeam == Color.Blue)
                {
                    this.defaultAttackTeam = Color.Red;
                }
                else if(this.defaultAttackTeam == Color.Red)
                {
                    this.defaultAttackTeam = Color.Blue;
                }

                this.currAttackTeam = this.defaultAttackTeam;
                Reset();
            }
        }

        enum GameModeEnum
        {
            INGAME,
            PAUSE,
            IDLE,
            REST
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

            public void Ready()
            {
                mode = GameModeEnum.IDLE;
                label.Text = "경기 전";
            }

            public void End()
            {
                mode = GameModeEnum.IDLE;
                label.Text = "경기 종료";
            }

            public void Start()
            {
                mode = GameModeEnum.INGAME;
                label.Text = "경기 중";
            }

            public void Pause()
            {
                mode = GameModeEnum.PAUSE;
                label.Text = "경기 중지";
            }

            public void Rest()
            {
                mode = GameModeEnum.REST;
                label.Text = "휴식 시간";
            }
        }


        /// <summary>
        /// config
        /// </summary>
        public static int CONFIG_ATTACK_TIME = 18;
        public int CONFIG_gameTotalMin = 3;
        public int CONFIG_gameTotalSec = 0;

        public int CONFIG_SCORE3_THRESHOLD_TIME = 12;
        public int CONFIG_SCORE2_THRESHOLD_TIME = 6;
        private SoundPlayer startGameCountDownSound = new SoundPlayer();
        private SoundPlayer startGameSound = new SoundPlayer();
        private SoundPlayer goalSound = new SoundPlayer();
        private SoundPlayer gameEnd10sSound = new SoundPlayer();
        private SoundPlayer attackEnd5sSound = new SoundPlayer();
        private SoundPlayer restEnd10sSound = new SoundPlayer();
        private WMPLib.WindowsMediaPlayer windowMediaPlayer = new WMPLib.WindowsMediaPlayer();
        private string getGameTime()
        {
            return CONFIG_gameTotalMin.ToString("00") + ":" + CONFIG_gameTotalSec.ToString("00");
        }

        Stopwatch stopwatch = new Stopwatch();

        long prevTime;
        long attackPrevTime;

        public Form1()
        {
            InitializeComponent();
            attackTeam = new AttackTeam(attackTeamTimeLabel, attackTeamTimeLabelText);
            currentGameMode = new GameMode(GameModeEnum.IDLE, gameModeLabel);

        }

        AttackTeam attackTeam;
        GameMode currentGameMode;


        private void Form1_Load(object sender, EventArgs e)
        {
            this.startGameCountDownSound.SoundLocation = @"경기시작카운트다운.wav";
            this.startGameCountDownSound.LoadAsync();

            this.startGameSound.SoundLocation = @"경기시작.wav";
            this.startGameSound.LoadAsync();

            this.goalSound.SoundLocation = @"골.wav";
            this.goalSound.LoadAsync();

            this.attackEnd5sSound.SoundLocation = @"공격종료5초전.wav";
            this.attackEnd5sSound.LoadAsync();

            this.gameEnd10sSound.SoundLocation = @"경기종료10초전.wav";
            this.gameEnd10sSound.LoadAsync();

            this.restEnd10sSound.SoundLocation = @"휴식종료10초전.wav";
            this.restEnd10sSound.LoadAsync();

            this.pictureBox1.Image = new Bitmap(@"logo.png");

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
                Application.DoEvents();
                prevTime = currentTime;

                String[] strs = timeLabel.Text.Split(":");
                int minutate = Convert.ToInt32(strs[0]);
                int second = Convert.ToInt32(strs[1]);
                DateTime dt = new DateTime(1, 1, 1, 1, minutate, second);
                DateTime newDt = dt.AddSeconds(-1);
                DateTime refTime = new DateTime(1, 1, 1, 1, 0, 0);

                timeLabel.Text = newDt.Minute.ToString("00") + ":" + newDt.Second.ToString("00");


                // 10초전 경기종료
                if(newDt.Minute == 0 && newDt.Second == 10)
                {
                   
                    
                    SoundPlayer soundPlayer = gameEnd10sSound;
                    if (currentGameMode.mode == GameModeEnum.INGAME)
                        windowMediaPlayer.URL = @"경기종료10초전.wav";
                    else if (currentGameMode.mode == GameModeEnum.REST)
                        windowMediaPlayer.URL = @"휴식종료10초전.wav";

                    windowMediaPlayer.controls.play();
                }

                if (currentGameMode.mode == GameModeEnum.INGAME)
                {
                    if (newDt <= refTime)
                    {
                        endGame();
                        return;
                    }
                }

                if ( currentGameMode.mode == GameModeEnum.REST)
                {
                    if (newDt <= refTime)
                    {
                        endRest();
                    }
                }
            }

            
            if (currentGameMode.mode == GameModeEnum.INGAME)
            {
                currentTime = stopwatch.ElapsedMilliseconds;
                if (currentTime - attackPrevTime >= 1000)
                {
                    attackPrevTime = currentTime;

                    int roundSecond = Convert.ToInt32(attackTeamTimeLabel.Text);
                    if (roundSecond > 0)
                    {
                        attackTeamTimeLabel.Text = (roundSecond - 1).ToString("00");
                    }
                    else
                    {
                        attackTeam.ChangeTeam();
                        attackPrevTime = currentTime;
                        attackTeamTimeLabel.Text = CONFIG_ATTACK_TIME.ToString("00");
                    }

                    roundSecond = Convert.ToInt32(attackTeamTimeLabel.Text);

                    if(roundSecond == 5)
                    {
                        attackEnd5sSound.Play();
                    }

                    if (roundSecond > CONFIG_SCORE3_THRESHOLD_TIME)
                    {
                        scoreTimeThreshold3.Visible = true;
                        scoreTimeThreshold2.Visible = true;
                        scoreTimeThreshold1.Visible = true;
                    }
                    else if (roundSecond > CONFIG_SCORE2_THRESHOLD_TIME)
                    {
                        scoreTimeThreshold3.Visible = false;
                        scoreTimeThreshold2.Visible = true;
                        scoreTimeThreshold1.Visible = true;
                    }
                    else if (roundSecond > 0)
                    {
                        scoreTimeThreshold3.Visible = false;
                        scoreTimeThreshold2.Visible = false;
                        scoreTimeThreshold1.Visible = true;
                    }
                    else if (roundSecond == 0)
                    {
                        scoreTimeThreshold3.Visible = false;
                        scoreTimeThreshold2.Visible = false;
                        scoreTimeThreshold1.Visible = false;
                    }
                }
            }
        }

        private void SetVisibleDevButtons(bool visible)
        {
            restStartButton.Visible = visible;
            startGameButton.Visible = visible;
        }
        private void endGame()
        {
            SetVisibleDevButtons(true);

            timer1.Enabled = false;
            stopwatch.Stop();
            currentGameMode.End();
            attackTeam.hardReset();

            scoreTimeThreshold3.Visible = true;
            scoreTimeThreshold2.Visible = true;
            scoreTimeThreshold1.Visible = true;

            attackEnd5sSound.Stop();
        }

        public void refreshControls()
        {
            timeLabel.Text = getGameTime();
            attackTeamTimeLabel.Text = CONFIG_ATTACK_TIME.ToString("00");

        }
        private void startGame()
        {
            timeLabel.Text = getGameTime();
            SetVisibleDevButtons(false);

            Application.DoEvents();
            if (this.startGameSound.IsLoadCompleted)
                startGameCountDownSound.PlaySync();


            attackTeam.Reset();

            timer1.Enabled = true;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            prevTime = stopwatch.ElapsedMilliseconds;
            attackPrevTime = stopwatch.ElapsedMilliseconds;
            currentGameMode.Start();

            this.startGameSound.Play();
        }

        private void pauseGame()
        {
            SetVisibleDevButtons(true);
            timer1.Enabled = false;
            currentGameMode.Pause();
        }

        private void resumeGame()
        {
            SetVisibleDevButtons(true);

            timer1.Enabled = true;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            prevTime = stopwatch.ElapsedMilliseconds;
            attackPrevTime = stopwatch.ElapsedMilliseconds;
            currentGameMode.Start();
        }

        private void resetGame()
        {
            SetVisibleDevButtons(true);
            timer1.Enabled = false;
            stopwatch.Stop();
            leftTeamScore.Text = "0";
            rightTeamScore.Text = "0";
            leftTeamSetScore.Text = "0";
            rightTeamSetScore.Text = "0";


            timeLabel.Text = getGameTime();
            attackTeam.Reset();

            currentGameMode.Ready();

        }

        private void startRest(int restMinutate)
        {
            timeLabel.Text = restMinutate.ToString("00") + ":" + "00";


            SetVisibleDevButtons(false);
            currentGameMode.Rest();

            stopwatch = new Stopwatch();
            stopwatch.Start();
            prevTime = stopwatch.ElapsedMilliseconds;


            timer1.Enabled = true;

            if (restMinutate <= 0)
                endRest();
        }

        private void endRest()
        {
            SetVisibleDevButtons(true);
            timer1.Enabled = false;
            stopwatch.Stop();
            currentGameMode.Ready();
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

        private void 코트체인지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeCoat();
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
            if(currentGameMode.mode != GameModeEnum.INGAME)
            {
                attackTeam.hardReset();
                scoreTimeThreshold3.Visible = true;
                scoreTimeThreshold2.Visible = true;
                scoreTimeThreshold1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            goalByTime();
        }

        private void 이미지삽입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "모든 파일(*.*)|*.*";
            openFileDialog1.Title = "이미지 열기";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                //pictureBox1.Image = Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }

        private void changeCoat()
        {
            if (currentGameMode.mode == GameModeEnum.INGAME)
                return;
            String tempTeamName = leftTeamName.Text;
            String tempTeamMember = leftTeamMember.Text;
            String tempScore = leftTeamScore.Text;
            String tempSetScore = leftTeamSetScore.Text;
            Color tempColor = leftTeamName.ForeColor;

            leftTeamName.Text = rightTeamName.Text;
            leftTeamMember.Text = rightTeamMember.Text;
            leftTeamScore.Text = rightTeamScore.Text;
            leftTeamSetScore.Text = rightTeamSetScore.Text;

            rightTeamName.Text = tempTeamName;
            rightTeamMember.Text = tempTeamMember;
            rightTeamScore.Text = tempScore;
            rightTeamSetScore.Text = tempSetScore;

            leftTeamName.ForeColor = rightTeamName.ForeColor;
            leftTeamScore.ForeColor = rightTeamScore.ForeColor;
            leftTeamSetScore.ForeColor = rightTeamSetScore.ForeColor;

            rightTeamName.ForeColor = tempColor;
            rightTeamScore.ForeColor = tempColor;
            rightTeamSetScore.ForeColor = tempColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {
 
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                leftTeamSetScore.Text = (Convert.ToInt32(leftTeamSetScore.Text) + 1).ToString();
            else if (e.Button == MouseButtons.Right)
            {
                if (Convert.ToInt32(leftTeamSetScore.Text) > 0)
                {
                    leftTeamSetScore.Text = (Convert.ToInt32(leftTeamSetScore.Text) - 1).ToString();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                leftTeamSetScore.Text = "0";
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            Label mylabel = rightTeamSetScore;
            if (e.Button == MouseButtons.Left)
                mylabel.Text = (Convert.ToInt32(mylabel.Text) + 1).ToString();
            else if (e.Button == MouseButtons.Right)
            {
                if (Convert.ToInt32(mylabel.Text) > 0)
                {
                    mylabel.Text = (Convert.ToInt32(mylabel.Text) - 1).ToString();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                mylabel.Text = "0";
            }
        }

        private void leftTeamScore_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentGameMode.mode == GameModeEnum.INGAME)
                return;
            Label mylabel = leftTeamScore;
            if (e.Button == MouseButtons.Left)
                mylabel.Text = (Convert.ToInt32(mylabel.Text) + 1).ToString();
            else if (e.Button == MouseButtons.Right)
            {
                if (Convert.ToInt32(mylabel.Text) > 0)
                {
                    mylabel.Text = (Convert.ToInt32(mylabel.Text) - 1).ToString();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                mylabel.Text = "0";
            }
        }

        private void rightTeamScore_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentGameMode.mode == GameModeEnum.INGAME)
                return;
            Label mylabel = rightTeamScore;
            if (e.Button == MouseButtons.Left)
                mylabel.Text = (Convert.ToInt32(mylabel.Text) + 1).ToString();
            else if (e.Button == MouseButtons.Right)
            {
                if (Convert.ToInt32(mylabel.Text) > 0)
                {
                    mylabel.Text = (Convert.ToInt32(mylabel.Text) - 1).ToString();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                mylabel.Text = "0";
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void restStartButton_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("휴식 시간을 입력하시오(분 단위)", "휴식시간", "5", 10, 10);
            int inputInt;
            if (int.TryParse(input, out inputInt))
            {
                startRest(inputInt);
            }
            else
            {
                MessageBox.Show("올바른 숫자를 입력하세요");
            }

        }

        private int scoreByTime()
        {
            int score = 0;
            if(scoreTimeThreshold3.Visible)
            {
                score += 3;
            }
            else if(scoreTimeThreshold2.Visible)
            {
                score += 2;
            }
            else if(scoreTimeThreshold1.Visible)
            {
                score += 1;
            }

            return score;
        }

        private void addScoreToLabel(Label label, int score)
        {
            label.Text = (Convert.ToInt32(label.Text) + score).ToString();
        }

        private void goalByTime()
        {
            if (currentGameMode.mode != GameModeEnum.INGAME)
                return;
            int score = scoreByTime();
            if (leftTeamScore.ForeColor == attackTeam.currAttackTeam)
            {
                addScoreToLabel(leftTeamScore, score);
            }
            else if (rightTeamScore.ForeColor == attackTeam.currAttackTeam)
            {
                addScoreToLabel(rightTeamScore, score);
            }

            if (score > 0)
            {
                attackEnd5sSound.Stop();
                goalSound.Play();
                attackPrevTime = stopwatch.ElapsedMilliseconds;
                attackTeam.ChangeTeam();
                attackTeam.Reset();

                scoreTimeThreshold3.Visible = true;
                scoreTimeThreshold2.Visible = true;
                scoreTimeThreshold1.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            goalByTime();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            goalByTime();
        }

        private void leftTeamScore_Click(object sender, EventArgs e)
        {

        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
    }
}