using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowLevelGraphics
{
    public partial class Form1 : Form
    {
        //game initials
        bool leftMove;
        bool rightMove;
        int sunCordSpeedX;
        int sunCordSpeedY;
        int movementSpeed;
        Random rng = new Random();

        public Form1()
        {
            InitializeComponent();
            this.Width = 500;
            this.Height = 500;

            setUp();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gerp = e.Graphics;
            Pen line = new Pen(Color.Black);
            Brush fillGreen = new SolidBrush(Color.Green);
            Brush fillRed = new SolidBrush(Color.Red);
            Brush fillWhite = new SolidBrush(Color.White);
            Brush fillBlack = new SolidBrush(Color.Black);
            Brush fillBrown = new SolidBrush(Color.Brown);

            gerp.FillRectangle(fillGreen, 0, 400, 500, 100);
            //draw house base
            gerp.FillRectangle(fillRed, 50, 350, 100, 50);
            //draw window 1
            gerp.FillRectangle(fillWhite, 60, 370, 15, 10);
            //draw window 2
            gerp.FillRectangle(fillWhite, 125, 370, 15, 10);
            //draw door
            gerp.FillRectangle(fillBlack, 93, 380, 15, 20);
            //draw roof
            Point[] points = { new Point(35, 350), new Point(94, 325), new Point(165, 350) };
            gerp.FillPolygon(fillBrown, points);
        }

        private void setUp()
        {
            sunCordSpeedX = 5;
            sunCordSpeedY = 5;
            movementSpeed = 12;

            frameAnimator.Start();
        }

        private void frameAnimator_Tick(object sender, EventArgs e)
        {

            if (leftMove == true && car.Left > 0)
            {
                car.Left -= movementSpeed;
            }
            if(rightMove == true && car.Left < 384)
            {
                car.Left += movementSpeed;
            }

            sun.Left += sunCordSpeedX;
            sun.Top += sunCordSpeedY;

            if (sun.Left < 0 || sun.Left > 467)
            {
                sunCordSpeedX = -sunCordSpeedX;
            }
            if (sun.Top < 0)
            {
                sunCordSpeedY = -sunCordSpeedY;
            }
            if (sun.Bounds.IntersectsWith(car.Bounds))
            {
                sunCordSpeedY = rng.Next(5, 12) * -1;

                if(sunCordSpeedX < 0)
                {
                    sunCordSpeedX = rng.Next(5, 12) * -1;
                }
                else
                {
                    sunCordSpeedX = rng.Next(5, 12);
                }
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "aliens")
                {
                    if (sun.Bounds.IntersectsWith(x.Bounds))
                    {
                        sunCordSpeedY = -sunCordSpeedY;

                        this.Controls.Remove(x);
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                leftMove = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                rightMove = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                leftMove = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightMove = false;
            }
        }

        
    }
}
