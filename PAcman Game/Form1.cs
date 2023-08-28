using WMPLib;
using System.Media;
namespace PAcman_Game
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer mplayer = new WindowsMediaPlayer();
        WindowsMediaPlayer coinplayer = new WindowsMediaPlayer();
        WindowsMediaPlayer loseplayer = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            mplayer.URL = "back.mp3";
            mplayer.controls.play();
            pnlloser.Visible = false;
            pnlwin.Visible = false;
        }
        bool goleft, goright, goup, godown = false;
        int playerspeed = 8;
        int score = 0;
        int redghostspeed = 5;
        int yellowghostspeed = 6;
        int pinkghost3x = 8;
        int pinkghost3y = 8;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult isexit = MessageBox.Show("Are You Sure You Want To Exit", "Pac Man Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (isexit == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                player.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                player.Image = Properties.Resources.down;
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            redghost.Left -= redghostspeed;
            yellowghost.Left += yellowghostspeed;
            pinkghost.Left += pinkghost3x;
            pinkghost.Top += pinkghost3y;

            if (redghost.Bounds.IntersectsWith(ored1.Bounds) || redghost.Bounds.IntersectsWith(ored2.Bounds))
            {
                redghostspeed = -redghostspeed;
            }
            if (yellowghost.Bounds.IntersectsWith(oyellow1.Bounds) || yellowghost.Bounds.IntersectsWith(oyellow2.Bounds))
            {
                yellowghostspeed = -yellowghostspeed;
            }
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Tag == "obstacles")
                {
                    if (pinkghost.Left < 1 ||
                        pinkghost.Left > this.ClientSize.Width ||
                        pinkghost.Bounds.IntersectsWith(c.Bounds))
                    {
                        pinkghost3x = -pinkghost3x;
                    }
                    if (pinkghost.Top < 1 ||
                        pinkghost.Top > this.ClientSize.Height ||
                        pinkghost.Bounds.IntersectsWith(c.Bounds))
                    {
                        pinkghost3y = -pinkghost3y;
                    }
                    foreach (Control g in this.Controls)
                    {
                        if (g is PictureBox && g.Tag == "ghost")
                        {
                            if (player.Bounds.IntersectsWith(c.Bounds) || player.Bounds.IntersectsWith(g.Bounds))
                            {
                                timer1.Stop();
                                loseplayer.URL = "lose.mp3";
                                mplayer.controls.stop();
                                loseplayer.controls.play();
                                player.Left = 0;
                                player.Top = 0;
                                lbllose.Text = "Score : " + score;
                                pnlloser.Visible = true;

                            }
                        }
                    }
                }
            }
            if (goleft == true)
            {
                player.Left -= playerspeed;
            }
            if (goright == true)
            {
                player.Left += playerspeed;
            }
            if (goup == true)
            {
                player.Top -= playerspeed;
            }
            if (godown == true)
            {
                player.Top += playerspeed;
            }
            if (player.Left < 0)
                player.Left = this.ClientSize.Width;
            if (player.Left > this.ClientSize.Width)
                player.Left = 0;
            if (player.Top < 0)
                player.Top = this.ClientSize.Height;
            if (player.Top > this.ClientSize.Height)
                player.Top = 0;
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(c.Bounds))
                    {
                        this.Controls.Remove(c);
                        score++;
                        coinplayer.URL = "coin.mp3";
                        coinplayer.controls.play();
                        lblscore.Text = "Score : " + score;
                    }
                }
            }
            if (score == 96)
            {
                lblwinscore.Text = "Score : " + score;
                pnlwin.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
            loseplayer.controls.stop();
            mplayer.controls.stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}