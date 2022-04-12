using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static readonly float Gravitational = 9.81F;
        int time = 1;           
        int shift = 6;
        bool isFalling = true;
        float eps = 0.00001F;
        // initialized just to go througt first if
        double velocity = 10;
        double hitVelocoty;
        double sleepTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            timer1.Start();
            timer2.Start();
        }
        private void falling(Button button)
        {
            // Phisics when an object fall
            velocity = Gravitational * time;
            sleepTime = 1 / velocity * 500;
            label4.Text = velocity.ToString();
            button.Location = new Point(button1.Location.X, button.Location.Y + shift);
            timer1.Interval = (int)sleepTime;
            hitVelocoty = velocity;
        }
        private void rising(Button button)
        {
            // Phisics when an object rise
            velocity = hitVelocoty - (time * Gravitational);
            if (velocity <= 0)
            {
                return;
            }
            sleepTime = 1 / velocity * 1000;
            label4.Text = velocity.ToString();
            button.Location = new Point(button1.Location.X, button.Location.Y + shift);
            timer1.Interval = (int)sleepTime;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Location.Y > 400 || velocity < eps)
            {
                // bounce ended
                if (button1.Location.Y > 400 && velocity < eps)
                {
                    timer1.Stop();
                    timer2.Stop();

                    return;
                }
                // changing dirrection of the move
                time = 1;
                isFalling = !isFalling;
                shift *= -1;
                label6.Text = button1.Location.Y.ToString(); 
            }
            if (isFalling)
            {
                falling(button1);
            }
            else
            {
                rising(button1);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = time.ToString();
        }
    }
}
