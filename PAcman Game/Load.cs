using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAcman_Game
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = startpoint;
            startpoint++;
            if (startpoint==100)
            {
                startpoint =0;
                progressBar1.Value = 0;
                timer1.Stop();
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }
    }
}
