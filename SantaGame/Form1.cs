using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SantaGame
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int santaSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            santa.Top += gravity;
            päike.Left -= santaSpeed;
            house.Left -= santaSpeed;
            scoreLabel.Text = $"score: {score}";

            if(päike.Left < -100)
            {
                päike.Left = 500;
                score++;
            }
            if(house.Left < -100)
            {
                house.Left = 600;
                score++;
            }

            if (santa.Bounds.IntersectsWith(house.Bounds) || santa.Bounds.IntersectsWith(päike.Bounds) ||
                santa.Bounds.IntersectsWith(ground.Bounds))
            {
                gameOver();
            }

            if(santa.Top < -25)
            {
                gameOver();
            }
            
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text = $"Game Over!";
            playAgain.Visible = true;
        }

        private void playAgain_Click(object sender, EventArgs e)
        {
            Form1 NewFrom = new Form1();
            NewFrom.Show();
            this.Dispose(false);
        }
    }
}
