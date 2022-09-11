using System.Diagnostics;
using System.Media;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using static System.Formats.Asn1.AsnWriter;
using WMPLib;

namespace DroneSports
{


    public partial class Form1 : Form
    {
        [DllImport("user32.dll")] private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")] private static extern int UnregisterHotKey(int hwnd, int id);

        protected override void WndProc(ref Message m) 
        {
            base.WndProc(ref m);
            if (m.Msg == (int)0x312)
            { 
                if (m.WParam == (IntPtr)0x0)
                {
                    leftTeamScore.Text = (Convert.ToInt32(leftTeamScore.Text) + 1).ToString();
                }
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
        private SoundPlayer startGameSound = new SoundPlayer();
        private SoundPlayer goalSound = new SoundPlayer();
        private SoundPlayer gameEnd10sSound = new SoundPlayer();
        private SoundPlayer attackEnd5sSound = new SoundPlayer();
        private SoundPlayer restEnd10sSound = new SoundPlayer();
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
            currentGameMode = new GameMode(GameModeEnum.IDLE, gameModeLabel);

        }

        GameMode currentGameMode;


        private void Form1_Load(object sender, EventArgs e)
        {
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
                        soundPlayer = gameEnd10sSound;
                    else if (currentGameMode.mode == GameModeEnum.REST)
                        soundPlayer = restEnd10sSound;
                    soundPlayer.Play();
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

            UnregisterHotKey((int)this.Handle, 0);

        }

        public void refreshControls()
        {
            timeLabel.Text = getGameTime();

        }
        private void startGame()
        {
            timeLabel.Text = getGameTime();
            SetVisibleDevButtons(false);

            timer1.Enabled = true;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            prevTime = stopwatch.ElapsedMilliseconds;
            attackPrevTime = stopwatch.ElapsedMilliseconds;
            currentGameMode.Start();

            RegisterHotKey((int)this.Handle, 0, 0x0, (int)Keys.Z);
        }

        private void pauseGame()
        {
            SetVisibleDevButtons(true);
            timer1.Enabled = false;
            currentGameMode.Pause();
            UnregisterHotKey((int)this.Handle, 0);
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

            RegisterHotKey((int)this.Handle, 0, 0x0, (int)Keys.Z);
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

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentGameMode.mode != GameModeEnum.INGAME)
                return;



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

            //if (this.startGameSound.IsLoadCompleted)
            //{
            //    this.startGameSound.PlaySync();
            //}
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


        private void addScoreToLabel(Label label, int score)
        {
            label.Text = (Convert.ToInt32(label.Text) + score).ToString();

            if (score > 0)
            {
                WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
                player.URL = @"골.wav";
                player.controls.play();

                goalSound.Play();
                attackPrevTime = stopwatch.ElapsedMilliseconds;
 
            }
        }

        private void goalByTime()
        {
            if (currentGameMode.mode != GameModeEnum.INGAME)
                return;
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

        private void scoreTimeThreshold1_Click(object sender, EventArgs e)
        {
            if (currentGameMode.mode != GameModeEnum.INGAME)
                return;

        }

        private void scoreTimeThreshold3_Click(object sender, EventArgs e)
        {
            if (currentGameMode.mode != GameModeEnum.INGAME)
                return;

        }

        private void leftTeamMember_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}