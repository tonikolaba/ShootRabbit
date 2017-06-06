//#define My_Debug

using ShootRabit.Properties;
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

namespace ShootRabit
{
    public partial class ShootRabit : Form
    {
#if My_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif
        private int moleCounter;
        private int splashCounter;
        private CRabbit mole;
        private CMenuBoard menuBoard;
        private CScoreBoard scoreBoard;
        private CBloodSplash bloodSplash;
        private Random random;
        private bool isDead = false;

        private int hits;
        private int misses;
        private int shotsFired;
        private double avgHits;
        private int frameNum = 8;
        private string level = "Noob";

        public ShootRabit()
        {
       
             // add characters on background
            InitializeComponent();

            Bitmap bmp = Resources.Crosshair;
            this.Cursor = CustomCursor.CreateCursor(bmp, bmp.Height / 2, bmp.Width / 2);

            this.mole = new CRabbit(10, 200);
            this.menuBoard = new CMenuBoard(400, 50);
            this.scoreBoard = new CScoreBoard(10, -20);
            this.bloodSplash = new CBloodSplash(0, 0);
            this.random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void timeGameLoop_Tick(object sender, EventArgs e)
        {
            if (this.avgHits <= 30)
            {
                this.frameNum = 8;
                this.level = "Hard";
            }
            else if (this.avgHits <= 50)
            {
                this.frameNum = 6;
                this.level = "Medium";
            }
            else if (this.avgHits >= 75)
            {
                this.frameNum = 4;
                this.level = "Easy";
            }

            if (this.moleCounter >= this.frameNum)
            {
                this.UpdateMole();
                this.moleCounter = 0;
            }

            if (this.isDead)
            {
                if (this.splashCounter >= SplashNum)
                {
                    this.splashCounter = 0;
                    this.UpdateMole();
                    this.isDead = false;
                }

                this.splashCounter++;
            }

            this.moleCounter++;
            this.Refresh();
        }

        private void UpdateMole()
        {
            this.mole.Update(this.random.Next(Resources.rabbit.Width, this.Width - Resources.rabbit.Width),
                            this.random.Next(this.Height / 2, this.Height - Resources.rabbit.Height * 2));
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

#if Debug
            TextRenderer.DrawText(
                dc,
                $"X = {this.currX} : Y = {this.currY}",
                font,
                new Rectangle(0, 0, 150, 20),
                SystemColors.ControlText,
                textFormatFlags);
           dc.DrawRectangle(new Pen(Color.Black, 3), mole.moleHotSpot.X, this.mole.moleHotSpot.Y, this.mole.moleHotSpot.Width, this.mole.moleHotSpot.Height);

#endif
            if (this.isDead)
            {
                this.bloodSplash.DrawImage(dc);
            }
            else
            {
                if (this.moleCounter >= 1)
                {
                    this.mole.DrawImage(dc);
                }
            }

            this.menuBoard.DrawImage(dc);
            this.scoreBoard.DrawImage(dc);

            /*add info to table score*/

            TextFormatFlags textFormatFlags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font font = new Font("Stencil", 10, FontStyle.Regular);
            TextRenderer.DrawText(dc, "SHOTS:" + shotsFired.ToString(), font, new Rectangle(40, 30, 120, 20), Color.Black,textFormatFlags);
            TextRenderer.DrawText(dc, "HITS:" + hits.ToString(), font, new Rectangle(40, 47, 120, 20), Color.Black, textFormatFlags);
            TextRenderer.DrawText(dc, "MISSES:" + misses.ToString(), font, new Rectangle(40, 69, 120, 20), Color.Black, textFormatFlags);
            TextRenderer.DrawText(dc, "AVG:" + avgHits.ToString() + " %", font, new Rectangle(40, 85, 120, 20), Color.Black, textFormatFlags);
            TextRenderer.DrawText(dc, "Level:" + level.ToString(), new Font("Times New Roman", 13, FontStyle.Bold), new Rectangle(40, 110, 200, 80), Color.Black, textFormatFlags);
/**/
            base.OnPaint(e);
        }

        private void ShootRabit_MouseMove(object sender, MouseEventArgs e)
        {
#if Debug
            this.currX = e.X;
            this.currY = e.Y;

#endif
            this.Refresh();
        }


        private void ShootRabit_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X >= 412 && e.X <= 570 && e.Y >= 68 && e.Y <= 100)
            {
                this.timeGameLoop.Start();
            }

            else if (e.X >= 412 && e.X <= 570 && e.Y >= 125 && e.Y <= 167)
            {
                this.timeGameLoop.Stop();
                this.moleCounter = 0;
                this.splashCounter = 0;
                this.isDead = false;
                this.hits = 0;
                this.shotsFired = 0;
                this.avgHits = 0;
                this.misses = 0;
                this.level = "Hard";
            }
            else if (e.X >= 412 && e.X <= 570 && e.Y >= 194 && e.Y <= 230)
            {
                Application.Exit();
            }
            else if(this.moleCounter >= 1)
            {
                if (this.mole.Hit(e.X, e.Y))
                {
                    this.isDead = true;
                    this.bloodSplash.Left = this.mole.Left;
                    this.bloodSplash.Top = this.mole.Top;
                    this.hits++;
                }

                this.ProduceGunshot();
                this.shotsFired++;
                this.misses = this.shotsFired - this.hits;
                this.avgHits = (double) this.hits/this.shotsFired * 100;
            }
         }


        private void ProduceGunshot()
        {
            SoundPlayer gunSound = new SoundPlayer(Resources.GunShot);
            gunSound.Play();
        }
    
public  int SplashNum { get; set; }}
}
