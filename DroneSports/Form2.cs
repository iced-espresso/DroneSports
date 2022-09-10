using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneSports
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            this.Owner = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = form1.CONFIG_gameTotalMin.ToString();
            textBox6.Text = form1.CONFIG_gameTotalSec.ToString();

            textBox2.Text = Form1.CONFIG_ATTACK_TIME.ToString();
            textBox3.Text = form1.CONFIG_SCORE3_THRESHOLD_TIME.ToString();
            textBox4.Text = form1.CONFIG_SCORE2_THRESHOLD_TIME.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.CONFIG_gameTotalMin = Convert.ToInt32(textBox1.Text);
            form1.CONFIG_gameTotalSec = Convert.ToInt32(textBox6.Text);
            Form1.CONFIG_ATTACK_TIME = Convert.ToInt32(textBox2.Text);
            form1.CONFIG_SCORE3_THRESHOLD_TIME = Convert.ToInt32(textBox3.Text);
            form1.CONFIG_SCORE2_THRESHOLD_TIME = Convert.ToInt32(textBox4.Text);
            form1.refreshControls();
            MessageBox.Show("설정 완료");
        }
    }
}
