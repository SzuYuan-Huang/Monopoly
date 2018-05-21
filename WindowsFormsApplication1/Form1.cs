using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    enum State
    {
        NonUse = 0,
        Rotating = 1,
        Slowing = 2,
        Stop = 3
    }

    
    public partial class Form1 : Form
    {

        const int FPS = 50;

        const int DiceNum = 6;
        const double DiceSpeed = 30;
        const double DiceChange = 50;

        const int SlotNum = 10;
        const double SlotSpeed = 30;
        const double SlotChange = 100;

        const int RotaryNum = 1;
        const double RotarySpeed = 30;
        const double RotaryChange = 100;


        double d_speed;

        double d_count;

        int d_place_1,d_place_2;

        State d_status;

        Bitmap[] d;

        Random rand;


        private int step;
        private int now_player;
        private Player[] players;
        private Block[] map;
        Bitmap MAP;

        private bool attack500;
        private bool attack1000;
        private bool realAttack;
        private bool getBlood;
        private bool attack20;
        private bool stop;
        private bool attackCritical;
        private bool oneShot;

        private int storyCount = 0;



        public Form1()
        {
            InitializeComponent();
            panel2.Hide();
            panel3.Hide();
        }

        int playerCount = 1;
        private bool s = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            if (playerCount <= 4)
            {
                playerChoose.Text = "第" + playerCount.ToString() + "位玩家選擇角色";
            }
            else
            {
                playerChoose.Text = "4位玩家已選完角色，請點選開始遊戲。";
            }
            if (playerCount > 4)
            {
                image1.Enabled = false;
                image2.Enabled = false;
                image3.Enabled = false;
                image4.Enabled = false;
                image5.Enabled = false;
                image6.Enabled = false;
                image7.Enabled = false;
                image8.Enabled = false;
                image9.Enabled = false;
                startButton.Enabled = true;
                SetUI(TurnPhase.Initial);
                timer1.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            AllGroupBox.Visible = true;
            AttackGroupBox.Visible = true;
            player1_ByAttacked.BackgroundImage = players[0].ImageRecord;
            player2_ByAttacked.BackgroundImage = players[1].ImageRecord;
            player3_ByAttacked.BackgroundImage = players[2].ImageRecord;
            player4_ByAttacked.BackgroundImage = players[3].ImageRecord;
            panel1.Hide();
        }

        private void image1_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("1.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("1.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("1.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("1.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image1.Enabled = false;
        }

        private void image2_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("2.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("2.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("2.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("2.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image2.Enabled = false;
        }

        private void image3_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("3.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("3.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("3.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("3.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image3.Enabled = false;
        }

        private void image4_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("4.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("4.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("4.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("4.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image4.Enabled = false;
        }

        private void image5_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("5.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("5.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("5.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("5.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image5.Enabled = false;
        }

        private void image6_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("6.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("6.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("6.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("6.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image6.Enabled = false;
        }

        private void image7_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("7.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("7.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("7.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("7.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image7.Enabled = false;
        }

        private void image8_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("8.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("8.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("8.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("8.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image8.Enabled = false;
        }

        private void image9_Click(object sender, EventArgs e)
        {
            if (playerCount == 1)
            {
                players[0] = new Player("9.png");
                players[0].Location = new Point(0, 0);
                Controls.Add(players[0].Image);
                players[0].Image.Parent = pictureBox1;
                players[0].Image.BringToFront();
            }
            if (playerCount == 2)
            {
                players[1] = new Player("9.png");
                players[1].Location = new Point(0, 0);
                Controls.Add(players[1].Image);
                players[1].Image.Parent = pictureBox1;
                players[1].Image.BringToFront();
            }
            if (playerCount == 3)
            {
                players[2] = new Player("9.png");
                players[2].Location = new Point(0, 0);
                Controls.Add(players[2].Image);
                players[2].Image.Parent = pictureBox1;
                players[2].Image.BringToFront();
            }
            if (playerCount == 4)
            {
                players[3] = new Player("9.png");
                players[3].Location = new Point(0, 0);
                Controls.Add(players[3].Image);
                players[3].Image.Parent = pictureBox1;
                players[3].Image.BringToFront();
            }

            playerCount++;
            image9.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            AllGroupBox.Visible = false;
            AttackGroupBox.Visible = false;

            MAP = new Bitmap("map.png");

            d_status = State.NonUse;

            d = new Bitmap[DiceNum];
            for (int i = 0; i < DiceNum; ++i)
                d[i] = new Bitmap("d" + (i + 1).ToString() + ".bmp");

            rand = new Random();

            timer1.Interval = 1000 / FPS;
            timer1.Start();


            now_player = 0;
            pictureBox1.Load("map.png");
         
            map = new Block[55];

            map[0] = new StartBlock();
            map[0].Location = new Point(578 , 44);

            map[1] = new Block();
            map[1].Location = new Point(650 , 44);

            map[2] = new WhiteBlock();
            map[2].Location = new Point(722, 44);

            map[3] = new BrownBlock();
            map[3].Location = new Point(792, 44);

            map[4] = new WhiteBlock();
            map[4].Location = new Point(863, 44);

            map[5] = new Block(); 
            map[5].Location = new Point(863, 112);

            map[6] = new GreenBlock();
            map[6].Location = new Point(934, 112);

            map[7] = new Block();
            map[7].Location = new Point(934, 182);

            map[8] = new WhiteBlock();
            map[8].Location = new Point(1006, 182);

            map[9] = new PurpleBlock();
            map[9].Location = new Point(1006, 252);

            map[10] = new ArmorBlock();
            map[10].Location = new Point(1006, 320);

            map[11] = new Block();
            map[11].Location = new Point(1006, 390);

            map[12] = new RedBlock();
            map[12].Location = new Point(1006, 460);

            map[13] = new WhiteBlock(); 
            map[13].Location = new Point(1006, 530);

            map[14] = new DoubleStepsBlock(); 
            map[14].Location = new Point(1006, 598);

            map[15] = new WhiteBlock();
            map[15].Location = new Point(1006, 668);

            map[16] = new ArmorBlock();
            map[16].Location = new Point(936, 668);

            map[17] = new BlueBlock(); 
            map[17].Location = new Point(936, 736);

            map[18] = new Block();
            map[18].Location = new Point(864, 736);

            map[19] = new WhiteBlock();
            map[19].Location = new Point(864, 805);

            map[20] = new WhiteBlock();
            map[20].Location = new Point(793, 805);

            map[21] = new ShortCutBlock();
            map[21].Location = new Point(722, 805);

            map[22] = new Block();
            map[22].Location = new Point(650, 805);

            map[23] = new WhiteBlock();
            map[23].Location = new Point(578, 805);

            map[24] = new Block();
            map[24].Location = new Point(508, 805);

            map[25] = new BrownBlock();
            map[25].Location = new Point(437, 805);

            map[26] = new WhiteBlock();
            map[26].Location = new Point(366, 805);

            map[27] = new Block();
            map[27].Location = new Point(366, 736);

            map[28] = new GreenBlock();
            map[28].Location = new Point(295, 736);

            map[29] = new Block();
            map[29].Location = new Point(295, 666);

            map[30] = new WhiteBlock();
            map[30].Location = new Point(224, 666);

            map[31] = new PurpleBlock();
            map[31].Location = new Point(224, 597);

            map[32] = new BloodBlock();
            map[32].Location = new Point(224, 528);

            map[33] = new WhiteBlock();
            map[33].Location = new Point(224, 459);

            map[34] = new RedBlock();
            map[34].Location = new Point(224, 390);

            map[35] = new Block();
            map[35].Location = new Point(224, 320);

            map[36] = new WhiteBlock();
            map[36].Location = new Point(224, 250);

            map[37] = new Block();
            map[37].Location = new Point(224, 180);

            map[38] = new Block();
            map[38].Location = new Point(294, 180);

            map[39] = new BlueBlock();
            map[39].Location = new Point(294, 110);

            map[40] = new Block();
            map[40].Location = new Point(365, 110);

            map[41] = new WhiteBlock();
            map[41].Location = new Point(365, 44);

            map[42] = new Block();
            map[42].Location = new Point(436, 44);

            map[43] = new WhiteBlock();
            map[43].Location = new Point(506, 44);

            map[44] = new Block();
            map[44].Location = new Point(722, 736);

            map[45] = new WhiteBlock();
            map[45].Location = new Point(722, 666);

            map[46] = new YellowBlock();
            map[46].Location = new Point(722, 597);

            map[47] = new Block();
            map[47].Location = new Point(722, 527);

            map[48] = new Block();
            map[48].Location = new Point(722, 457);

            map[49] = new ShopBlock();
            map[49].Location = new Point(614, 422);

            map[50] = new RedBlock();
            map[50].Location = new Point(506, 388);

            map[51] = new WhiteBlock();
            map[51].Location = new Point(506, 320);

            map[52] = new PinkBlock();
            map[52].Location = new Point(506, 250);

            map[53] = new Block();
            map[53].Location = new Point(506, 182);

            map[54] = new WhiteBlock();
            map[54].Location = new Point(506, 112);


            players = new Player[4];

            timer1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            players[now_player].Attack = 500;

            if (button1.Text == "Start")
            {
                d_speed = DiceSpeed;
                d_count = 0;
                d_place_1 = 0;
                d_place_2 = 0;
                d_status = State.Rotating;

                button1.Text = "Stop";
            }
            else
            {
                d_status = State.Slowing;

                button1.Text = "Start";
                button1.Enabled = false;
            }

            SetUI(TurnPhase.Walk);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(100) + 1;

            if(number <= 20)
            {
                storyCount++;

                if (storyCount == 1)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0001.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 2)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0002.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 3)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0003.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 4)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0004.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 5)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0005.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 6)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0006.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 7)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0007.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 8)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0008.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 9)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0009.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 10)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0010.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 11)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0011.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 12)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0012.jpg");
                    AllGroupBox.Enabled = false;
                }
                if (storyCount == 13)
                {
                    panel3.Show();
                    panel3.BackgroundImage = Image.FromFile("0013.jpg");
                    AllGroupBox.Enabled = false;
                }

            }


            players[now_player].Attack = 500;
            player1_ByAttacked.Enabled = true;
            player2_ByAttacked.Enabled = true;
            player3_ByAttacked.Enabled = true;
            player4_ByAttacked.Enabled = true;


            attack500 = false;
            attack1000 = false;
            realAttack = false;
            getBlood = false;
            attack20 = false;
            stop = false;
            attackCritical = false;
            oneShot = false;

            now_player = (now_player + 1) % 4;
            while (players[now_player].State == PlayerState.Dead)
                now_player = (now_player + 1) % 4;

            SetUI(TurnPhase.Initial);
            pictureBox4.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / FPS;
            if (d_status == State.Rotating || d_status == State.Slowing)
            {
                d_count += d_speed;

                if (d_count >= DiceChange)
                {
                    d_count -= DiceChange;
                    int temp1 = rand.Next(6);
                    int temp2 = rand.Next(6);
                    while (d_place_1 == temp1)
                        temp1 = rand.Next(6);
                    d_place_1 = temp1;

                    while (d_place_2 == temp2)
                        temp2 = rand.Next(6);
                    d_place_2 = temp2;
                }
                if (d_status == State.Slowing)
                    d_speed -= rand.NextDouble() * 0.9;
                if (d_speed <= 0)
                    d_status = State.Stop;

                pictureBox2.Image = d[d_place_1];
                pictureBox2.Refresh();

                pictureBox3.Image = d[d_place_2];
                pictureBox3.Refresh();
            }
            else if (d_status == State.Stop)
            {
                d_status = State.NonUse;
                step = d_place_1 + 1 + d_place_2 + 1;
                if(players[now_player].State==PlayerState.SpeedUp)
                {
                    step = step * 2;
                }
                button1.Enabled = true;
                players[now_player].State = PlayerState.Normal;
            }


            if (step != 0)
            {
                timer1.Interval = 250;
                PlayerMove(players[now_player]);
                pictureBox4.Refresh();
            }
            else
            {

                if (players[now_player].BlockIndex == 3 || players[now_player].BlockIndex == 25)
                {
                    label12.Text = "禁止使用法寶攻擊";
                    AttackGroupBox.Enabled = false;
                }
                else if (players[now_player].BlockIndex == 6 || players[now_player].BlockIndex == 28)
                {
                    label12.Text = "隨機的一個事件發生(血量的增減)";
                    AttackGroupBox.Enabled = false;
                }
                else if (players[now_player].BlockIndex == 9 || players[now_player].BlockIndex == 31)
                {
                    label12.Text = "原地暫停一回合";
                    AttackGroupBox.Enabled = false;
                }
                else if (players[now_player].BlockIndex == 12 || players[now_player].BlockIndex == 34 || players[now_player].BlockIndex == 50)
                {
                    label12.Text = "加血100";
                    AttackGroupBox.Enabled = false;
                }
                else if (players[now_player].BlockIndex == 17 || players[now_player].BlockIndex == 39)
                {
                    label12.Text = "隨機的攻擊加成";
                }
                else if (players[now_player].BlockIndex == 46)
                {
                    label12.Text = "誰都無法對此格上停留玩家造成傷害";
                    AttackGroupBox.Enabled = false;
                }
                else if (players[now_player].BlockIndex == 52)
                {
                    label12.Text = "大回血，2000的血量增加";
                    AttackGroupBox.Enabled = false;
                }
                else if (players[now_player].BlockIndex == 49)
                {
                    label12.Text = "法寶商店";
                }

                else if (players[now_player].BlockIndex == 1)
                {
                    label12.Text = "暫停對手一回合";
                }

                else if (players[now_player].BlockIndex == 5)
                {
                    label12.Text = "攻+500";
                }

                else if (players[now_player].BlockIndex == 7)
                {
                    label12.Text = "攻+1000";
                }

                else if (players[now_player].BlockIndex == 10)
                {
                    label12.Text = "盾+2000  (對%傷 真傷無效) ";
                    AttackGroupBox.Enabled = false;
                }

                else if (players[now_player].BlockIndex == 11)
                {
                    label12.Text = "攻+500";
                }

                else if (players[now_player].BlockIndex == 14)
                {
                    label12.Text = "步數*2";
                    AttackGroupBox.Enabled = false;
                }

                else if (players[now_player].BlockIndex == 16)
                {
                    label12.Text = "盾+2000  (對%傷 真傷無效) ";
                    AttackGroupBox.Enabled = false;
                }

                else if (players[now_player].BlockIndex == 18)
                {
                    label12.Text = "攻+1000";
                }

                else if (players[now_player].BlockIndex == 22)
                {
                    label12.Text = "扣敵人20%血";
                }

                else if (players[now_player].BlockIndex == 24)
                {
                    label12.Text = "真傷500";
                }

                else if (players[now_player].BlockIndex == 27)
                {
                    label12.Text = "攻+1000";
                }

                else if (players[now_player].BlockIndex == 29)
                {
                    label12.Text = "扣敵人20%血";
                }

                else if (players[now_player].BlockIndex == 32)
                {
                    label12.Text = "回2000血";
                    AttackGroupBox.Enabled = false;
                }

                else if (players[now_player].BlockIndex == 35)
                {
                    label12.Text = "吸血20%";
                }

                else if (players[now_player].BlockIndex == 37)
                {
                    label12.Text = "暫停對手一回合";
                }

                else if (players[now_player].BlockIndex == 38)
                {
                    label12.Text = "攻+1000";
                }

                else if (players[now_player].BlockIndex == 40)
                {
                    label12.Text = "真傷500";
                }

                else if (players[now_player].BlockIndex == 42)
                {
                    label12.Text = "暴擊率50%";
                }

                else if (players[now_player].BlockIndex == 44)
                {
                    label12.Text = "攻+500";
                }

                else if (players[now_player].BlockIndex == 47)
                {
                    label12.Text = "扣敵人20%血";
                }

                else if (players[now_player].BlockIndex == 48)
                {
                    label12.Text = "暴擊率50%";
                }

                else if (players[now_player].BlockIndex == 53)
                {
                    label12.Text = "暫停對手一回合";
                }

                else
                {
                    AttackGroupBox.Enabled = false;
                }

                

            }
        }

        private void PlayerMove(Player player)
        {
            int now_index = player.BlockIndex;
            int next_index;

           if (player.BlockIndex >= 44)
           {
                next_index = (player.BlockIndex + 1) % 55;
           }
           else
           {
                next_index = (player.BlockIndex + 1) % 44;
           }
            
            
            Point dis = new Point((map[next_index].Location.X - map[now_index].Location.X) , (map[next_index].Location.Y - map[now_index].Location.Y) );
            player.Location = new Point(player.Location.X + dis.X, player.Location.Y + dis.Y);

          //  label9.Text = map[next_index].Location.X.ToString();
          //  label10.Text = map[next_index].Location.Y.ToString();
            

            if(player.Location.X+578 == map[next_index].Location.X && player.Location.Y +44 == map[next_index].Location.Y)
            {
                --step;
                label8.Text = step.ToString();
                player.BlockIndex = next_index;

                if(step==0)
                {
                    map[player.BlockIndex].StopAction(ref player);
                    label4.Text = player.Blood.ToString();
                    label14.Text = player.Attack.ToString();
                    label16.Text = player.Armor.ToString();
                    SetUI(TurnPhase.End);
                }
                else
                {
                    map[player.BlockIndex].PassAction(ref player);
                    label4.Text = player.Blood.ToString();
                    label14.Text = player.Attack.ToString();
                    label16.Text = player.Armor.ToString();
                }
            }
            //label9.Text = players[now_player].Location.X.ToString();
            //label10.Text = players[now_player].Location.Y.ToString();
            button1.Enabled = false;
        }

        private void SetUI(TurnPhase phase)
        {
            switch(phase)
            {
                case TurnPhase.Initial:
                    label12.Text = "";
                    pictureBox5.Load(players[now_player].ImageString);
                    pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                    label2.Text = (now_player + 1).ToString();
                    label4.Text = players[now_player].Blood.ToString();
                    label6.Text = players[now_player].State.ToString();
                    label14.Text = players[now_player].Attack.ToString();

                    player1_Blood.Text = "血量：" + players[0].Blood.ToString();
                    player2_Blood.Text = "血量：" + players[1].Blood.ToString();
                    player3_Blood.Text = "血量：" + players[2].Blood.ToString();
                    player4_Blood.Text = "血量：" + players[3].Blood.ToString();

                    player1_Armor.Text = "護甲：" + players[0].Armor.ToString();
                    player2_Armor.Text = "護甲：" + players[1].Armor.ToString();
                    player3_Armor.Text = "護甲：" + players[2].Armor.ToString();
                    player4_Armor.Text = "護甲：" + players[3].Armor.ToString();

                    if (now_player == 0 || players[0].State == PlayerState.Invisible)
                    {
                        player1_ByAttacked.Enabled = false;
                    }
                    if (now_player == 1 || players[1].State == PlayerState.Invisible)
                    {
                        player2_ByAttacked.Enabled = false;
                    }
                    if (now_player == 2 || players[2].State == PlayerState.Invisible)
                    {
                        player3_ByAttacked.Enabled = false;
                    }
                    if (now_player == 3 || players[3].State == PlayerState.Invisible)
                    {
                        player4_ByAttacked.Enabled = false;
                    }




                    if (players[now_player].State == PlayerState.Stop)
                    {
                        button1.Enabled = false;
                        AttackGroupBox.Enabled = false;
                        button8.Enabled = true;
                        players[now_player].State = PlayerState.Normal;
                        players[now_player].Image.BringToFront();
                    }
                    else if (players[now_player].State == PlayerState.StopAttack)
                    {
                        button1.Enabled = true;
                        AttackGroupBox.Enabled = false;
                        button8.Enabled = false;
                        players[now_player].State = PlayerState.Normal;
                        players[now_player].Image.BringToFront();
                    }
                    else if(players[now_player].State == PlayerState.Teleport)
                    {
                        button1.Enabled = true;
                        AttackGroupBox.Enabled = true;
                        button8.Enabled = false;
                        players[now_player].State = PlayerState.Normal;
                        players[now_player].Image.BringToFront();
                    }
                    else if (players[now_player].State == PlayerState.Invisible)
                    {
                        button1.Enabled = true;
                        AttackGroupBox.Enabled = true;
                        button8.Enabled = false;
                        players[now_player].State = PlayerState.Normal;
                        players[now_player].Image.BringToFront();
                    }
                    else if(players[now_player].State == PlayerState.Shopping)
                    {
                        panel2.Show();
                        button1.Enabled = true;
                        AttackGroupBox.Enabled = true;
                        button8.Enabled = false;
                        AllGroupBox.Enabled = false;
                        players[now_player].State = PlayerState.Normal;
                        players[now_player].Image.BringToFront();
                    }
                    else
                    {
                        players[now_player].Image.BringToFront();
                        button1.Enabled = true;
                        AttackGroupBox.Enabled = true;
                        button8.Enabled = false;
                    }
                    break;

                case TurnPhase.Walk:
                        label8.Text = step.ToString();
                        button1.Enabled = false;
                        if (button1.Text == "Stop")
                        {
                            button1.Enabled = true;
                        }
                        AttackGroupBox.Enabled = false;
                        button8.Enabled = false;
                    break;

                case TurnPhase.Dice:
                    button1.Enabled = true;
                    AttackGroupBox.Enabled = false;
                    button8.Enabled = false;
                    break;

                case TurnPhase.End:
                    label12.Text = "";
                    button1.Enabled = false;
                    AttackGroupBox.Enabled = true;
                    button8.Enabled = true;
                    break;
                    
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            Point now_loc = players[now_player].Location;
            int left = Math.Max(0, Math.Min(1280,now_loc.X + 538 ));
            int top = Math.Max(0, Math.Min(900, now_loc.Y + 0 ));
            int humanleft = now_loc.X;
            int humantop = now_loc.Y;

            /*if (left + 300 > 1280)
                left = 980;
            if (top + 300 > 900)
                top = 600;*/
            Rectangle map_region = new Rectangle(left, top, 125 ,125);

            Graphics g = e.Graphics;

            // Draw background map
            g.DrawImage(MAP, new Rectangle(0, 0, pictureBox4.Width, pictureBox4.Height), map_region, GraphicsUnit.Pixel);

            // Draw player
            Rectangle player_region;
            for (int i = 0; i < 4; ++i)
            {
                player_region = new Rectangle(players[i].Location.X + 80 , players[i].Location.Y + 88 , 100, 100);
                if (i != now_player && map_region.IntersectsWith(player_region))
                    g.DrawImage(players[i].ImageRecord, new Rectangle((players[i].Location.X + 80 - humanleft), (players[i].Location.Y + 88 - humantop), 100, 100), new Rectangle(0 , 0 , players[i].ImageRecord.Width, players[i].ImageRecord.Height), GraphicsUnit.Pixel);
            }

            player_region = new Rectangle(players[now_player].Location.X  + 80 , players[now_player].Location.Y + 88, 100, 100);
            g.DrawImage(players[now_player].ImageRecord, new Rectangle((players[now_player].Location.X + 80 - humanleft), (players[now_player].Location.Y + 88 - humantop), 100, 100), new Rectangle(0, 0, players[now_player].ImageRecord.Width, players[now_player].ImageRecord.Height), GraphicsUnit.Pixel);
             
        }

        private void player1_ByAttacked_Click(object sender, EventArgs e)
        {
            Random number = new Random();

            int overkill = 0;

            if (players[now_player].BlockIndex == 1)
            {
                players[0].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 5)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if(players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 7)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 11)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 18)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 22)
            {
                players[0].Blood = players[0].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 24)
            {
                players[0].Blood = players[0].Blood - 500;
            }

            if (players[now_player].BlockIndex == 27)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 29)
            {
                players[now_player].Blood = players[now_player].Blood + players[0].Blood / 5;
                players[0].Blood = players[0].Blood / 5 * 4; 
            }

            if (players[now_player].BlockIndex == 35)
            {
                players[now_player].Blood = players[now_player].Blood + players[0].Blood / 5;
                players[0].Blood = players[0].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 37)
            {
                players[0].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 38)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 40)
            {
                players[0].Blood = players[0].Blood - 500;
            }

            if(players[now_player].BlockIndex == 42)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[0].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[0].Armor - players[now_player].Attack;
                        players[0].Blood = players[0].Blood + overkill;
                        players[0].Armor = 0;
                    }
                    else
                    {
                        players[0].Armor = players[0].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[0].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[0].Armor - players[now_player].Attack;
                        players[0].Blood = players[0].Blood + overkill;
                        players[0].Armor = 0;
                    }
                    else
                    {
                        players[0].Armor = players[0].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 44)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 47)
            {
                players[0].Blood = players[0].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 48)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[0].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[0].Armor - players[now_player].Attack;
                        players[0].Blood = players[0].Blood + overkill;
                        players[0].Armor = 0;
                    }
                    else
                    {
                        players[0].Armor = players[0].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[0].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[0].Armor - players[now_player].Attack;
                        players[0].Blood = players[0].Blood + overkill;
                        players[0].Armor = 0;
                    }
                    else
                    {
                        players[0].Armor = players[0].Armor - players[now_player].Attack;
                    }
                }
            }

            if(players[now_player].BlockIndex == 53)
            {
                players[0].State = PlayerState.Stop;
            }

            if(players[now_player].BlockIndex == 49)
            {
                if(attack500 == true)
                {
                    players[now_player].Attack += 500;

                    if (players[0].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[0].Armor - players[now_player].Attack;
                        players[0].Blood = players[0].Blood + overkill;
                        players[0].Armor = 0;
                    }
                    else
                    {
                        players[0].Armor = players[0].Armor - players[now_player].Attack;
                    }
                }

                if(attack1000 == true)
                {
                    players[now_player].Attack += 1000;

                    if (players[0].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[0].Armor - players[now_player].Attack;
                        players[0].Blood = players[0].Blood + overkill;
                        players[0].Armor = 0;
                    }
                    else
                    {
                        players[0].Armor = players[0].Armor - players[now_player].Attack;
                    }
                }

                if(attack20 == true)
                {
                    players[0].Blood = players[0].Blood / 5 * 4;
                }

                if(getBlood == true)
                {
                    players[now_player].Blood = players[now_player].Blood + players[0].Blood / 5;
                    players[0].Blood = players[0].Blood / 5 * 4;
                }

                if(realAttack == true)
                {
                    players[0].Blood -= 500;
                }

                if (attackCritical == true)
                {
                    int critical = number.Next(100) + 1;

                    if (critical <= 50)
                    {
                        players[now_player].Attack = players[now_player].Attack * 2;

                        if (players[0].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[0].Armor - players[now_player].Attack;
                            players[0].Blood = players[0].Blood + overkill;
                            players[0].Armor = 0;
                        }
                        else
                        {
                            players[0].Armor = players[0].Armor - players[now_player].Attack;
                        }
                    }
                    else
                    {
                        if (players[0].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[0].Armor - players[now_player].Attack;
                            players[0].Blood = players[0].Blood + overkill;
                            players[0].Armor = 0;
                        }
                        else
                        {
                            players[0].Armor = players[0].Armor - players[now_player].Attack;
                        }
                    }
                }

                if(stop ==true)
                {
                    players[0].State = PlayerState.Stop;
                }


                if(oneShot==true)
                {
                    players[0].State = PlayerState.Dead;
                    players[0].Blood = 0;
                }
            }

            if (players[now_player].BlockIndex == 17 || players[now_player].BlockIndex == 39)
            {
                if (players[0].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[0].Armor - players[now_player].Attack;
                    players[0].Blood = players[0].Blood + overkill;
                    players[0].Armor = 0;
                }
                else
                {
                    players[0].Armor = players[0].Armor - players[now_player].Attack;
                }
            }


            player1_Blood.Text = "血量：" + players[0].Blood.ToString();
            player2_Blood.Text = "血量：" + players[1].Blood.ToString();
            player3_Blood.Text = "血量：" + players[2].Blood.ToString();
            player4_Blood.Text = "血量：" + players[3].Blood.ToString();

            player1_Armor.Text = "護甲：" + players[0].Armor.ToString();
            player2_Armor.Text = "護甲：" + players[1].Armor.ToString();
            player3_Armor.Text = "護甲：" + players[2].Armor.ToString();
            player4_Armor.Text = "護甲：" + players[3].Armor.ToString();

            AttackGroupBox.Enabled = false;
        }

        private void player2_ByAttacked_Click(object sender, EventArgs e)
        {
            Random number = new Random();

            int overkill = 0;

            if (players[now_player].BlockIndex == 1)
            {
                players[1].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 5)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 7)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 11)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 18)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 22)
            {
                players[1].Blood = players[1].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 24)
            {
                players[1].Blood = players[1].Blood - 500;
            }

            if (players[now_player].BlockIndex == 27)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 29)
            {
                players[now_player].Blood = players[now_player].Blood + players[1].Blood / 5;
                players[1].Blood = players[1].Blood / 5 * 4;
                
            }

            if (players[now_player].BlockIndex == 35)
            {
                players[now_player].Blood = players[now_player].Blood + players[1].Blood / 5;
                players[1].Blood = players[1].Blood / 5 * 4;
                
            }

            if (players[now_player].BlockIndex == 37)
            {
                players[1].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 38)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 40)
            {
                players[1].Blood = players[1].Blood - 500;
            }

            if (players[now_player].BlockIndex == 42)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[1].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[1].Armor - players[now_player].Attack;
                        players[1].Blood = players[1].Blood + overkill;
                        players[1].Armor = 0;
                    }
                    else
                    {
                        players[1].Armor = players[1].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[1].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[1].Armor - players[now_player].Attack;
                        players[1].Blood = players[1].Blood + overkill;
                        players[1].Armor = 0;
                    }
                    else
                    {
                        players[1].Armor = players[1].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 44)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 47)
            {
                players[1].Blood = players[1].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 48)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[1].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[1].Armor - players[now_player].Attack;
                        players[1].Blood = players[1].Blood + overkill;
                        players[1].Armor = 0;
                    }
                    else
                    {
                        players[1].Armor = players[1].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[1].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[1].Armor - players[now_player].Attack;
                        players[1].Blood = players[1].Blood + overkill;
                        players[1].Armor = 0;
                    }
                    else
                    {
                        players[1].Armor = players[1].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 53)
            {
                players[1].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 49)
            {
                if (attack500 == true)
                {
                    players[now_player].Attack += 500;

                    if (players[1].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[1].Armor - players[now_player].Attack;
                        players[1].Blood = players[1].Blood + overkill;
                        players[1].Armor = 0;
                    }
                    else
                    {
                        players[1].Armor = players[1].Armor - players[now_player].Attack;
                    }
                }

                if (attack1000 == true)
                {
                    players[now_player].Attack += 1000;

                    if (players[1].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[1].Armor - players[now_player].Attack;
                        players[1].Blood = players[1].Blood + overkill;
                        players[1].Armor = 0;
                    }
                    else
                    {
                        players[1].Armor = players[1].Armor - players[now_player].Attack;
                    }
                }

                if (attack20 == true)
                {
                    players[1].Blood = players[1].Blood / 5 * 4;
                }

                if (getBlood == true)
                {
                    players[now_player].Blood = players[now_player].Blood + players[1].Blood / 5;
                    players[1].Blood = players[1].Blood / 5 * 4;
                }

                if (realAttack == true)
                {
                    players[1].Blood -= 500;
                }

                if (attackCritical == true)
                {
                    int critical = number.Next(100) + 1;

                    if (critical <= 50)
                    {
                        players[now_player].Attack = players[now_player].Attack * 2;

                        if (players[1].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[1].Armor - players[now_player].Attack;
                            players[1].Blood = players[1].Blood + overkill;
                            players[1].Armor = 0;
                        }
                        else
                        {
                            players[1].Armor = players[1].Armor - players[now_player].Attack;
                        }
                    }
                    else
                    {
                        if (players[1].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[1].Armor - players[now_player].Attack;
                            players[1].Blood = players[1].Blood + overkill;
                            players[1].Armor = 0;
                        }
                        else
                        {
                            players[1].Armor = players[1].Armor - players[now_player].Attack;
                        }
                    }
                }

                if (stop == true)
                {
                    players[1].State = PlayerState.Stop;
                }


                if (oneShot == true)
                {
                    players[1].State = PlayerState.Dead;
                    players[1].Blood = 0;
                }
            }

            if (players[now_player].BlockIndex == 17 || players[now_player].BlockIndex == 39)
            {
                if (players[1].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[1].Armor - players[now_player].Attack;
                    players[1].Blood = players[1].Blood + overkill;
                    players[1].Armor = 0;
                }
                else
                {
                    players[1].Armor = players[1].Armor - players[now_player].Attack;
                }
            }

            player1_Blood.Text = "血量：" + players[0].Blood.ToString();
            player2_Blood.Text = "血量：" + players[1].Blood.ToString();
            player3_Blood.Text = "血量：" + players[2].Blood.ToString();
            player4_Blood.Text = "血量：" + players[3].Blood.ToString();

            player1_Armor.Text = "護甲：" + players[0].Armor.ToString();
            player2_Armor.Text = "護甲：" + players[1].Armor.ToString();
            player3_Armor.Text = "護甲：" + players[2].Armor.ToString();
            player4_Armor.Text = "護甲：" + players[3].Armor.ToString();

            AttackGroupBox.Enabled = false;
        }

        private void player3_ByAttacked_Click(object sender, EventArgs e)
        {
            Random number = new Random();

            int overkill = 0;

            if (players[now_player].BlockIndex == 1)
            {
                players[2].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 5)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 7)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 11)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 18)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 22)
            {
                players[2].Blood = players[2].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 24)
            {
                players[2].Blood = players[2].Blood - 500;
            }

            if (players[now_player].BlockIndex == 27)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 29)
            {
                players[now_player].Blood = players[now_player].Blood + players[2].Blood / 5;
                players[2].Blood = players[2].Blood / 5 * 4;
                
            }

            if (players[now_player].BlockIndex == 35)
            {
                players[now_player].Blood = players[now_player].Blood + players[2].Blood / 5;
                players[2].Blood = players[2].Blood / 5 * 4;
                
            }

            if (players[now_player].BlockIndex == 37)
            {
                players[2].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 38)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 40)
            {
                players[2].Blood = players[2].Blood - 500;
            }

            if (players[now_player].BlockIndex == 42)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[2].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[2].Armor - players[now_player].Attack;
                        players[2].Blood = players[2].Blood + overkill;
                        players[2].Armor = 0;
                    }
                    else
                    {
                        players[2].Armor = players[2].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[2].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[2].Armor - players[now_player].Attack;
                        players[2].Blood = players[2].Blood + overkill;
                        players[2].Armor = 0;
                    }
                    else
                    {
                        players[2].Armor = players[2].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 44)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 47)
            {
                players[2].Blood = players[2].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 48)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[2].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[2].Armor - players[now_player].Attack;
                        players[2].Blood = players[2].Blood + overkill;
                        players[2].Armor = 0;
                    }
                    else
                    {
                        players[2].Armor = players[2].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[2].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[2].Armor - players[now_player].Attack;
                        players[2].Blood = players[2].Blood + overkill;
                        players[2].Armor = 0;
                    }
                    else
                    {
                        players[2].Armor = players[2].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 53)
            {
                players[2].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 49)
            {
                if (attack500 == true)
                {
                    players[now_player].Attack += 500;

                    if (players[2].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[2].Armor - players[now_player].Attack;
                        players[2].Blood = players[2].Blood + overkill;
                        players[2].Armor = 0;
                    }
                    else
                    {
                        players[2].Armor = players[2].Armor - players[now_player].Attack;
                    }
                }

                if (attack1000 == true)
                {
                    players[now_player].Attack += 1000;

                    if (players[2].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[2].Armor - players[now_player].Attack;
                        players[2].Blood = players[2].Blood + overkill;
                        players[2].Armor = 0;
                    }
                    else
                    {
                        players[2].Armor = players[2].Armor - players[now_player].Attack;
                    }
                }

                if (attack20 == true)
                {
                    players[2].Blood = players[2].Blood / 5 * 4;
                }

                if (getBlood == true)
                {
                    players[now_player].Blood = players[now_player].Blood + players[2].Blood / 5;
                    players[2].Blood = players[2].Blood / 5 * 4;
                }

                if (realAttack == true)
                {
                    players[2].Blood -= 500;
                }

                if (attackCritical == true)
                {
                    int critical = number.Next(100) + 1;

                    if (critical <= 50)
                    {
                        players[now_player].Attack = players[now_player].Attack * 2;

                        if (players[2].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[2].Armor - players[now_player].Attack;
                            players[2].Blood = players[2].Blood + overkill;
                            players[2].Armor = 0;
                        }
                        else
                        {
                            players[2].Armor = players[2].Armor - players[now_player].Attack;
                        }
                    }
                    else
                    {
                        if (players[2].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[2].Armor - players[now_player].Attack;
                            players[2].Blood = players[2].Blood + overkill;
                            players[2].Armor = 0;
                        }
                        else
                        {
                            players[2].Armor = players[2].Armor - players[now_player].Attack;
                        }
                    }
                }

                if (stop == true)
                {
                    players[2].State = PlayerState.Stop;
                }


                if (oneShot == true)
                {
                    players[2].State = PlayerState.Dead;
                    players[2].Blood = 0;
                }
            }

            if (players[now_player].BlockIndex == 17 || players[now_player].BlockIndex == 39)
            {
                if (players[2].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[2].Armor - players[now_player].Attack;
                    players[2].Blood = players[2].Blood + overkill;
                    players[2].Armor = 0;
                }
                else
                {
                    players[2].Armor = players[2].Armor - players[now_player].Attack;
                }
            }

            player1_Blood.Text = "血量：" + players[0].Blood.ToString();
            player2_Blood.Text = "血量：" + players[1].Blood.ToString();
            player3_Blood.Text = "血量：" + players[2].Blood.ToString();
            player4_Blood.Text = "血量：" + players[3].Blood.ToString();

            player1_Armor.Text = "護甲：" + players[0].Armor.ToString();
            player2_Armor.Text = "護甲：" + players[1].Armor.ToString();
            player3_Armor.Text = "護甲：" + players[2].Armor.ToString();
            player4_Armor.Text = "護甲：" + players[3].Armor.ToString();

            AttackGroupBox.Enabled = false;
        }

        private void player4_ByAttacked_Click(object sender, EventArgs e)
        {
            Random number = new Random();

            int overkill = 0;

            if (players[now_player].BlockIndex == 1)
            {
                players[3].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 5)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 7)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 11)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 18)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 22)
            {
                players[3].Blood = players[3].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 24)
            {
                players[3].Blood = players[3].Blood - 500;
            }

            if (players[now_player].BlockIndex == 27)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 29)
            {
                players[now_player].Blood = players[now_player].Blood + players[3].Blood / 5;
                players[3].Blood = players[3].Blood / 5 * 4;
                
            }

            if (players[now_player].BlockIndex == 35)
            {
                players[now_player].Blood = players[now_player].Blood + players[3].Blood / 5;
                players[3].Blood = players[3].Blood / 5 * 4;
                
            }

            if (players[now_player].BlockIndex == 37)
            {
                players[3].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 38)
            {
                players[now_player].Attack = players[now_player].Attack + 1000;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 40)
            {
                players[3].Blood = players[3].Blood - 500;
            }

            if (players[now_player].BlockIndex == 42)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[3].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[3].Armor - players[now_player].Attack;
                        players[3].Blood = players[3].Blood + overkill;
                        players[3].Armor = 0;
                    }
                    else
                    {
                        players[3].Armor = players[3].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[3].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[3].Armor - players[now_player].Attack;
                        players[3].Blood = players[3].Blood + overkill;
                        players[3].Armor = 0;
                    }
                    else
                    {
                        players[3].Armor = players[3].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 44)
            {
                players[now_player].Attack = players[now_player].Attack + 500;

                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            if (players[now_player].BlockIndex == 47)
            {
                players[3].Blood = players[3].Blood / 5 * 4;
            }

            if (players[now_player].BlockIndex == 48)
            {
                int critical = number.Next(100) + 1;

                if (critical <= 50)
                {
                    players[now_player].Attack = players[now_player].Attack * 2;

                    if (players[3].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[3].Armor - players[now_player].Attack;
                        players[3].Blood = players[3].Blood + overkill;
                        players[3].Armor = 0;
                    }
                    else
                    {
                        players[3].Armor = players[3].Armor - players[now_player].Attack;
                    }
                }
                else
                {
                    if (players[3].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[3].Armor - players[now_player].Attack;
                        players[3].Blood = players[3].Blood + overkill;
                        players[3].Armor = 0;
                    }
                    else
                    {
                        players[3].Armor = players[3].Armor - players[now_player].Attack;
                    }
                }
            }

            if (players[now_player].BlockIndex == 53)
            {
                players[3].State = PlayerState.Stop;
            }

            if (players[now_player].BlockIndex == 49)
            {
                if (attack500 == true)
                {
                    players[now_player].Attack += 500;

                    if (players[3].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[3].Armor - players[now_player].Attack;
                        players[3].Blood = players[3].Blood + overkill;
                        players[3].Armor = 0;
                    }
                    else
                    {
                        players[3].Armor = players[3].Armor - players[now_player].Attack;
                    }
                }

                if (attack1000 == true)
                {
                    players[now_player].Attack += 1000;

                    if (players[3].Armor - players[now_player].Attack < 0)
                    {
                        overkill = players[3].Armor - players[now_player].Attack;
                        players[3].Blood = players[3].Blood + overkill;
                        players[3].Armor = 0;
                    }
                    else
                    {
                        players[3].Armor = players[3].Armor - players[now_player].Attack;
                    }
                }

                if (attack20 == true)
                {
                    players[3].Blood = players[3].Blood / 5 * 4;
                }

                if (getBlood == true)
                {
                    players[now_player].Blood = players[now_player].Blood + players[3].Blood / 5;
                    players[3].Blood = players[3].Blood / 5 * 4;
                }

                if (realAttack == true)
                {
                    players[3].Blood -= 500;
                }

                if (attackCritical == true)
                {
                    int critical = number.Next(100) + 1;

                    if (critical <= 50)
                    {
                        players[now_player].Attack = players[now_player].Attack * 2;

                        if (players[3].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[3].Armor - players[now_player].Attack;
                            players[3].Blood = players[3].Blood + overkill;
                            players[3].Armor = 0;
                        }
                        else
                        {
                            players[3].Armor = players[3].Armor - players[now_player].Attack;
                        }
                    }
                    else
                    {
                        if (players[3].Armor - players[now_player].Attack < 0)
                        {
                            overkill = players[3].Armor - players[now_player].Attack;
                            players[3].Blood = players[3].Blood + overkill;
                            players[3].Armor = 0;
                        }
                        else
                        {
                            players[3].Armor = players[3].Armor - players[now_player].Attack;
                        }
                    }
                }

                if (stop == true)
                {
                    players[3].State = PlayerState.Stop;
                }


                if (oneShot == true)
                {
                    players[3].State = PlayerState.Dead;
                    players[3].Blood = 0;
                }
            }

            if (players[now_player].BlockIndex == 17 || players[now_player].BlockIndex == 39)
            {
                if (players[3].Armor - players[now_player].Attack < 0)
                {
                    overkill = players[3].Armor - players[now_player].Attack;
                    players[3].Blood = players[3].Blood + overkill;
                    players[3].Armor = 0;
                }
                else
                {
                    players[3].Armor = players[3].Armor - players[now_player].Attack;
                }
            }

            player1_Blood.Text = "血量：" + players[0].Blood.ToString();
            player2_Blood.Text = "血量：" + players[1].Blood.ToString();
            player3_Blood.Text = "血量：" + players[2].Blood.ToString();
            player4_Blood.Text = "血量：" + players[3].Blood.ToString();

            player1_Armor.Text = "護甲：" + players[0].Armor.ToString();
            player2_Armor.Text = "護甲：" + players[1].Armor.ToString();
            player3_Armor.Text = "護甲：" + players[2].Armor.ToString();
            player4_Armor.Text = "護甲：" + players[3].Armor.ToString();

            AttackGroupBox.Enabled = false;
        }

        private void AttackGroupBox_Paint(object sender, PaintEventArgs e)
        {
            if(players[0].State == PlayerState.Invisible)
            {
                player1_ByAttacked.Enabled = false;
            }
            if (players[1].State == PlayerState.Invisible)
            {
                player2_ByAttacked.Enabled = false;
            }
            if (players[2].State == PlayerState.Invisible)
            {
                player2_ByAttacked.Enabled = false;
            }
            if (players[3].State == PlayerState.Invisible)
            {
                player3_ByAttacked.Enabled = false;
            }
            
            if (players[0].Blood <= 0)
            {
                players[0].State = PlayerState.Dead;
                players[0].Image.Visible = false;
                player1_ByAttacked.Visible = false;
                player1_Blood.Visible = false;
                player1_Armor.Visible = false;
            }
            if (players[1].Blood <= 0)
            {
                players[1].State = PlayerState.Dead;
                players[1].Image.Visible = false;
                player2_ByAttacked.Visible = false;
                player2_Blood.Visible = false;
                player2_Armor.Visible = false;
            }
            if (players[2].Blood <= 0)
            {
                players[2].State = PlayerState.Dead;
                players[2].Image.Visible = false;
                player3_ByAttacked.Visible = false;
                player3_Blood.Visible = false;
                player3_Armor.Visible = false;
            }
            if (players[3].Blood <= 0)
            {
                players[3].State = PlayerState.Dead;
                players[3].Image.Visible = false;
                player4_ByAttacked.Visible = false;
                player4_Blood.Visible = false;
                player4_Armor.Visible = false;
            }
        }


        private void item1_Click(object sender, EventArgs e)
        {
            players[now_player].Blood -= 1000;

            players[now_player].Armor += 2000; 

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item2_Click(object sender, EventArgs e)
        {
            players[now_player].Blood -= 1000;

            players[now_player].Armor += 2000;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item3_Click(object sender, EventArgs e)
        {
            attack500 = true;

            players[now_player].Blood -= 250;


            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item4_Click(object sender, EventArgs e)
        {
            attack500 = true;

            players[now_player].Blood -= 250;


            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item5_Click(object sender, EventArgs e)
        {
            attack500 = true;

            players[now_player].Blood -= 250;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item6_Click(object sender, EventArgs e)
        {
            attack500 = true;

            players[now_player].Blood -= 250;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item7_Click(object sender, EventArgs e)
        {
            attack20 = true;

            players[now_player].Blood -= 1500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item8_Click(object sender, EventArgs e)
        {
            attack20 = true;

            players[now_player].Blood -= 1500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item9_Click(object sender, EventArgs e)
        {
            attack20 = true;

            players[now_player].Blood -= 1500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item10_Click(object sender, EventArgs e)
        {
            stop = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item11_Click(object sender, EventArgs e)
        {
            stop = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item12_Click(object sender, EventArgs e)
        {
            stop = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item13_Click(object sender, EventArgs e)
        {
            stop = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item14_Click(object sender, EventArgs e)
        {
            realAttack = true;

            players[now_player].Blood -= 1500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item15_Click(object sender, EventArgs e)
        {
            realAttack = true;

            players[now_player].Blood -= 1500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item16_Click(object sender, EventArgs e)
        {
            attack1000 = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item17_Click(object sender, EventArgs e)
        {
            attack1000 = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item18_Click(object sender, EventArgs e)
        {
            attack1000 = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item19_Click(object sender, EventArgs e)
        {
            attack1000 = true;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item20_Click(object sender, EventArgs e)
        {
            attackCritical = true;

            players[now_player].Blood -= 750;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item21_Click(object sender, EventArgs e)
        {
            attackCritical = true;

            players[now_player].Blood -= 750;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item22_Click(object sender, EventArgs e)
        {
            attackCritical = true;

            players[now_player].Blood -= 750;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item23_Click(object sender, EventArgs e)
        {
            players[now_player].State = PlayerState.SpeedUp;

            players[now_player].Blood -= 500;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item24_Click(object sender, EventArgs e)
        {
            players[now_player].Blood -= 1000;

            players[now_player].Blood += 2000;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item25_Click(object sender, EventArgs e)
        {
            players[now_player].Blood -= 1250;

            getBlood = true;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item26_Click(object sender, EventArgs e)
        {
            players[now_player].Blood -= 1250;

            getBlood = true;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void item27_Click(object sender, EventArgs e)
        {
            players[now_player].Blood -= 8000;

            oneShot = true;

            item1.Enabled = false;
            item2.Enabled = false;
            item3.Enabled = false;
            item4.Enabled = false;
            item5.Enabled = false;
            item6.Enabled = false;
            item7.Enabled = false;
            item8.Enabled = false;
            item9.Enabled = false;
            item10.Enabled = false;
            item11.Enabled = false;
            item12.Enabled = false;
            item13.Enabled = false;
            item14.Enabled = false;
            item15.Enabled = false;
            item16.Enabled = false;
            item17.Enabled = false;
            item18.Enabled = false;
            item19.Enabled = false;
            item20.Enabled = false;
            item21.Enabled = false;
            item22.Enabled = false;
            item23.Enabled = false;
            item24.Enabled = false;
            item25.Enabled = false;
            item26.Enabled = false;
            item27.Enabled = false;
            ShopExit.Enabled = true;
        }

        private void ShopExit_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            item1.Enabled = true;
            item2.Enabled = true;
            item3.Enabled = true;
            item4.Enabled = true;
            item5.Enabled = true;
            item6.Enabled = true;
            item7.Enabled = true;
            item8.Enabled = true;
            item9.Enabled = true;
            item10.Enabled =true;
            item11.Enabled =true;
            item12.Enabled =true;
            item13.Enabled =true;
            item14.Enabled =true;
            item15.Enabled =true;
            item16.Enabled =true;
            item17.Enabled =true;
            item18.Enabled =true;
            item19.Enabled =true;
            item20.Enabled =true;
            item21.Enabled =true;
            item22.Enabled =true;
            item23.Enabled =true;
            item24.Enabled =true;
            item25.Enabled =true;
            item26.Enabled =true;
            item27.Enabled =true;
            ShopExit.Enabled = true;
            label4.Text = players[now_player].Blood.ToString();
            label16.Text = players[now_player].Armor.ToString();
            player1_Blood.Text = "血量：" + players[0].Blood.ToString();
            player2_Blood.Text = "血量：" + players[1].Blood.ToString();
            player3_Blood.Text = "血量：" + players[2].Blood.ToString();
            player4_Blood.Text = "血量：" + players[3].Blood.ToString();

            player1_Armor.Text = "護甲：" + players[0].Armor.ToString();
            player2_Armor.Text = "護甲：" + players[1].Armor.ToString();
            player3_Armor.Text = "護甲：" + players[2].Armor.ToString();
            player4_Armor.Text = "護甲：" + players[3].Armor.ToString();

            AllGroupBox.Enabled = true;
        }

        private void AllGroupBox_Paint(object sender, PaintEventArgs e)
        {
            int deadBody = 0 , survive = 0;

            for(int i=0;i<4;i++)
            {
                if(players[i].State == PlayerState.Dead)
                {
                    deadBody++;
                }
                else
                {
                    survive = i;
                }
            }

            if(deadBody == 3)
            {
                panel3.Show();
                panel3.BackgroundImage = Image.FromFile("0014.jpg");
                MessageBox.Show("玩家" + (survive + 1).ToString() + "獲勝");
                Close();
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(this.item1, "盾+2000  (對%傷 真傷無效) $1000");
            toolTip.SetToolTip(this.item2, "盾+2000  (對%傷 真傷無效) $1000");
            toolTip.SetToolTip(this.item3, "攻+500 $250");
            toolTip.SetToolTip(this.item4, "攻+500 $250");
            toolTip.SetToolTip(this.item5, "攻+500 $250");
            toolTip.SetToolTip(this.item6, "攻+500 $250");
            toolTip.SetToolTip(this.item7, "扣敵人20%血 $1500");
            toolTip.SetToolTip(this.item8, "扣敵人20%血 $1500");
            toolTip.SetToolTip(this.item9, "扣敵人20%血 $1500");
            toolTip.SetToolTip(this.item10, "暫停對手一回合 $500");
            toolTip.SetToolTip(this.item11, "暫停對手一回合 $500");
            toolTip.SetToolTip(this.item12, "暫停對手一回合 $500");
            toolTip.SetToolTip(this.item13, "暫停對手一回合 $500");
            toolTip.SetToolTip(this.item14, "真傷500 $1500");
            toolTip.SetToolTip(this.item15, "真傷500 $1500");
            toolTip.SetToolTip(this.item16, "攻+1000 $500");
            toolTip.SetToolTip(this.item17, "攻+1000 $500");
            toolTip.SetToolTip(this.item18, "攻+1000 $500");
            toolTip.SetToolTip(this.item19, "攻+1000 $500");
            toolTip.SetToolTip(this.item20, "暴擊率50% $750");
            toolTip.SetToolTip(this.item21, "暴擊率50% $750");
            toolTip.SetToolTip(this.item22, "暴擊率50% $750");
            toolTip.SetToolTip(this.item23, "步數*2 $500");
            toolTip.SetToolTip(this.item24, "回2000血 $1000");
            toolTip.SetToolTip(this.item25, "吸血20% $1250");
            toolTip.SetToolTip(this.item26, "吸血20% $1250");
            toolTip.SetToolTip(this.item27, "一個敵人即死 $8000");

            if(players[now_player].Blood-1000 < 1)
            {
                item1.Enabled = false;
                item2.Enabled = false;
                item24.Enabled = false;
            }

            if (players[now_player].Blood - 250 < 1)
            {
                item3.Enabled = false;
                item4.Enabled = false;
                item5.Enabled = false;
                item6.Enabled = false;
            }

            if (players[now_player].Blood - 1500 < 1)
            {
                item7.Enabled = false;
                item8.Enabled = false;
                item9.Enabled = false;
                item14.Enabled = false;
                item15.Enabled = false;
            }

            if (players[now_player].Blood - 500 < 1)
            {
                item10.Enabled = false;
                item11.Enabled = false;
                item12.Enabled = false;
                item13.Enabled = false;
                item16.Enabled = false;
                item17.Enabled = false;
                item18.Enabled = false;
                item19.Enabled = false;
                item23.Enabled = false;
            }

            if(players[now_player].Blood - 750 < 1)
            {
                item20.Enabled = false;
                item21.Enabled = false;
                item22.Enabled = false;
            }

            if (players[now_player].Blood - 1250 < 1)
            {
                item25.Enabled = false;
                item26.Enabled = false;
            }

            if(players[now_player].Blood - 8000 < 1)
            {
                item27.Enabled = false;
            }
            
        }


        private void storyButton_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            AllGroupBox.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            step = 21;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            step = 5;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F1)
            {
                if(s == false)
                {
                    button2.Visible = true;
                    button3.Visible = true;
                    s = true;
                }
                else
                {
                    button2.Visible = false;
                    button3.Visible = false;
                    s = false;
                }
            }
        }
       

        
        

       

        
        
    }
}
