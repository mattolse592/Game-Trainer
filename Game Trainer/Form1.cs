using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Game_Trainer
{
    public partial class Form1 : Form
    {
        Random randGen = new Random();

        Rectangle hero = new Rectangle(450, 100, 30, 30);
        Rectangle exitButton = new Rectangle(825, 15, 60, 30);
        Rectangle aimTrainerButton = new Rectangle(150, 200, 150, 100);
        Rectangle target;

        int heroSpeed = 10;

        int exitLength = 0;
        int aimTrainerLength = 0;

        int aimTrainerCountdownnum = 99;
        int aimTrainerTimeLeft = 3000;
        int aimTrainerScore;
        int aimTrainerMisses;
        bool targetOnScreen = false;

        string gameState;

        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;

        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen whitePen = new Pen(Color.White);
        Font exitFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
        Font gameFont = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
        Font titleFont = new Font("Microsoft Sans Serif", 35, FontStyle.Bold);
        public Form1()
        {
            InitializeComponent();
            MenuSetup();
        }
        public void MenuSetup()
        {
            this.Focus();

            hero.X = 450;
            hero.Y = 100;

            menuTick.Enabled = true;

            gameState = "menu";
        }
        public void AimTrainerCountdownSetup()
        {
            menuTick.Enabled = false;
            aimTrainerCountdown.Enabled = true;

            gameState = "aimTrainerCountdown";

            Refresh();
        }

        public void AimTrainerSetup()
        {
            aimTrainerCountdown.Enabled = false;
            aimTrainer.Enabled = true;
            targetOnScreen = false;
            aimTrainerScore = 0;
            aimTrainerMisses = 0;

            aimTrainerTimeLeft = 3000;

            gameState = "aimTrainer";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            int x = Cursor.Position.X - this.Location.X;
            int y = Cursor.Position.Y - this.Location.Y;

            if (x > target.X && x < target.X + target.Width && y > target.Y && y < target.Y + target.Height)
            {
                targetOnScreen = false;
                aimTrainerScore++;
            }
            else
            {
                aimTrainerMisses++;
            }
        }

        private void gameTick_Tick(object sender, EventArgs e)
        {
            if (wDown == true && hero.Y > 0)
            {
                hero.Y -= heroSpeed;
            }
            if (aDown == true && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }
            if (sDown == true && hero.Y < 600 - hero.Height)
            {
                hero.Y += heroSpeed;
            }
            if (dDown == true && hero.X < 900 - hero.Width)
            {
                hero.X += heroSpeed;
            }

            if (hero.IntersectsWith(exitButton))
            {
                exitLength++;
            }
            else if (exitLength > 0)
            {
                exitLength -= 2;
            }
            if (exitLength == 61)
            {
                this.Close();
            }

            if (hero.IntersectsWith(aimTrainerButton))
            {
                aimTrainerLength += 3;
            }
            else if (aimTrainerLength > 0)
            {
                aimTrainerLength -= 5;
            }
            if (aimTrainerLength >= 151)
            {
                AimTrainerCountdownSetup();
            }

            Refresh();

        }
        private void aimTrainerCountdown_Tick(object sender, EventArgs e)
        {
            if (aimTrainerCountdownnum >= 0)
            {
                aimTrainerCountdownnum--;
            }
            else
            {
                AimTrainerSetup();
            }
            Refresh();
        }
        private void aimTrainer_Tick(object sender, EventArgs e)
        {
            if (targetOnScreen == false)
            {
                target = new Rectangle(randGen.Next(0, 850), randGen.Next(0, 550), 50, 50);
                targetOnScreen = true;
            }

            if (aimTrainerTimeLeft > 0)
            {
                aimTrainerTimeLeft -= 3;
            }
            else
            {
                gameState = "aimTrainerOver";
            }


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "menu")
            {
                e.Graphics.FillRectangle(redBrush, exitButton);
                e.Graphics.FillRectangle(whiteBrush, 825, 45, exitLength, 3);
                e.Graphics.DrawRectangle(whitePen, aimTrainerButton);
                e.Graphics.FillRectangle(whiteBrush, 150, 300, aimTrainerLength, 3);

                e.Graphics.DrawString("Exit", exitFont, whiteBrush, 835, 20);
                e.Graphics.DrawString("Aim Trainer", gameFont, whiteBrush, aimTrainerButton.X + 5, aimTrainerButton.Y + 37);
                e.Graphics.DrawString("Game Trainer", titleFont, whiteBrush, 280, 20);

                e.Graphics.FillRectangle(orangeBrush, hero);
            }
            else if (gameState == "aimTrainerCountdown")
            {
                if (aimTrainerCountdownnum > 66 && aimTrainerCountdownnum < 99)
                {
                    e.Graphics.DrawString("3", titleFont, whiteBrush, 450, 250);
                }
                else if (aimTrainerCountdownnum > 33 && aimTrainerCountdownnum < 66)
                {
                    e.Graphics.DrawString("2", titleFont, whiteBrush, 450, 250);
                }
                else if (aimTrainerCountdownnum > 0 && aimTrainerCountdownnum < 33)
                {
                    e.Graphics.DrawString("1", titleFont, whiteBrush, 450, 250);
                }
            }
            else if (gameState == "aimTrainer")
            {
                e.Graphics.DrawString(Convert.ToString(aimTrainerTimeLeft), gameFont, whiteBrush, 450, 20);
                e.Graphics.FillEllipse(redBrush, target);
            }
            else if (gameState == "aimTrainerOver")
            {
                e.Graphics.DrawString("Game Over", titleFont, whiteBrush, 300, 250);
            }
        }


    }
}
