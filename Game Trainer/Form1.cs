//Matthew Olsen 2023-01-24
//A game with three basic skill testing games called aimtrainer, reactionspeed test, and number memory test. 

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
using System.Diagnostics;

namespace Game_Trainer
{
    public partial class Form1 : Form
    {
        Random randGen = new Random();
        Stopwatch aimTrainerStopwatch = new Stopwatch();
        Stopwatch reactionStopwatch = new Stopwatch();

        Rectangle hero = new Rectangle(450, 100, 30, 30);
        Rectangle exitButton = new Rectangle(825, 15, 60, 30);
        Rectangle aimTrainerButton = new Rectangle(150, 200, 150, 100);
        Rectangle numMemoryButton = new Rectangle(550, 200, 150, 100);
        Rectangle reactionButton = new Rectangle(350, 200, 150, 100);
        Rectangle target;

        SoundPlayer popPlayer = new SoundPlayer(Properties.Resources.pop);

        int heroSpeed = 10;

        int exitLength = 0;
        int aimTrainerLength = 0;
        int numMemoryLength = 0;
        int reactionLength = 0;

        int aimTrainerCountdownnum = 99;
        int aimTrainerScore;
        int aimTrainerMisses;
        double aimTrainerAccuracy;
        int aimTrainerClicks;
        bool targetOnScreen = false;

        int numMemoryScore;
        int numMemoryShownTime;
        int numMemory;
        bool numMemoryCreated;
        int numMin = 1;
        int numMax = 10;

        int reactionRound;
        double reactionAverage;

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
        //set up functions
        public void MenuSetup()
        {
            this.Focus();
            this.BackColor = Color.Black;
            hero.X = 450;
            hero.Y = 100;
            label1.Visible = true;

            menuTick.Enabled = true;

            menuButton.Visible = false;
            retryButton.Visible = false;

            aimTrainerLength = 0;
            numMemoryLength = 0;
            reactionLength = 0;
            numMemory = 0;
            numMemoryInput.Visible = false;
            numMemoryOutput.Visible = false;
            numMemorySubmit.Visible = false;

            gameState = "menu";

            this.Focus();
        }
        public void AimTrainerCountdownSetup()
        {
            menuTick.Enabled = false;
            aimTrainerCountdown.Enabled = true;
            aimTrainerCountdownnum = 99;

            menuButton.Visible = false;
            retryButton.Visible = false;

            gameState = "aimTrainerCountdown";

            Refresh();
        }
        public void AimTrainerSetup()
        {
            aimTrainerStopwatch.Reset();
            aimTrainerCountdown.Enabled = false;
            aimTrainer.Enabled = true;
            targetOnScreen = false;
            aimTrainerScore = 0;
            aimTrainerMisses = 0;
            aimTrainerAccuracy = 0;
            aimTrainerClicks = 0;

            aimTrainerStopwatch.Start();

            gameState = "aimTrainer";
        }
        public void NumberMemorySetup()
        {
            menuTick.Enabled = false;
            numMemoryTick.Enabled = true;
            numMemoryOutput.Visible = true;
            numMemoryCreated = false;
            menuButton.Visible = false;
            retryButton.Visible = false;
            numMemoryInput.Visible = false;
            numMemorySubmit.Visible = false;
            numMemoryInput.Text = "";

            numMin = 1;
            numMax = 10;

            numMemoryScore = 0;
            numMemoryShownTime = 900;

            gameState = "numMemoryShow";
        }
        public void ReactionSetup()
        {
            menuTick.Enabled = false;
            reactionTick.Enabled = true;
            reactionRound = 0;
            this.BackColor = Color.Red;
            reactionStopwatch.Reset();
            menuButton.Visible = false;
            retryButton.Visible = false;
            numMemoryOutput.Visible = false;
            reactionAverage = 0;

            reactionTick.Interval = randGen.Next(500, 2001);

            gameState = "reactionSpeed";
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
            label1.Visible = false;
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
            if (gameState == "aimTrainer")
            {

                int x = Cursor.Position.X - this.Location.X;
                int y = Cursor.Position.Y - this.Location.Y;

                if (x > target.X && x < target.X + target.Width && y > target.Y && y < target.Y + target.Height)
                {
                    targetOnScreen = false;
                    popPlayer.Play();
                    aimTrainerScore++;
                }
                else
                {
                    aimTrainerMisses++;
                }

                aimTrainerClicks = aimTrainerMisses + aimTrainerScore;
                aimTrainerAccuracy = (double)aimTrainerScore / (double)aimTrainerClicks;
            }
            else if (gameState == "reactionSpeed")
            {
                if (this.BackColor == Color.Red)
                {
                    gameState = "reactionSpeedEarly";
                    numMemoryOutput.Visible = true;
                    this.BackColor = Color.Black;
                    reactionTick.Enabled = false;
                    Refresh();
                }
                else if (this.BackColor == Color.Green)
                {
                    gameState = "reactionSpeedGood";
                    this.BackColor = Color.Black;
                    numMemoryOutput.Visible = true;
                    reactionStopwatch.Stop();
                    reactionRound++;
                    reactionAverage += Convert.ToDouble(reactionStopwatch.ElapsedMilliseconds);
                    
                    Refresh();
                }

            }
            else if (gameState == "reactionSpeedEarly" || gameState == "reactionSpeedGood")
            {
                if (reactionRound == 5)
                {
                    gameState = "reactionSpeedEnd";
                    reactionAverage /= 5;

                    menuButton.Visible = true;
                    retryButton.Visible = true;
                    Refresh();
                }
                else
                {
                    this.BackColor = Color.Red;
                    numMemoryOutput.Visible = false;
                    gameState = "reactionSpeed";
                    reactionTick.Interval = randGen.Next(500, 2001);
                    reactionTick.Enabled = true;

                    reactionStopwatch.Reset();
                }
            }
        }
        //game tick events
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

            if (hero.IntersectsWith(numMemoryButton))
            {
                numMemoryLength += 3;
            }
            else if (numMemoryLength > 0)
            {
                numMemoryLength -= 5;
            }
            if (numMemoryLength >= 151)
            {
                NumberMemorySetup();
            }

            if (hero.IntersectsWith(reactionButton))
            {
                reactionLength += 3;
            }
            else if (reactionLength > 0)
            {
                reactionLength -= 5;
            }
            if (reactionLength >= 151)
            {
                ReactionSetup();
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

            if (aimTrainerStopwatch.ElapsedMilliseconds > 30000)
            {
                gameState = "aimTrainerOver";

                aimTrainer.Enabled = false;

                menuButton.Visible = true;
                retryButton.Visible = true;
            }

            Refresh();
        }
        private void numMemoryTick_Tick(object sender, EventArgs e)
        {
            if (numMemoryShownTime < 0)
            {
                gameState = "numMemoryInput";

                numMemoryTick.Enabled = false;
                numMemoryOutput.Visible = false;
                numMemoryInput.Visible = true;
                numMemorySubmit.Visible = true;

            }
            else
            {
                if (numMemoryCreated == false)
                {
                    numMemory = randGen.Next(numMin, numMax);
                    numMemoryOutput.Text = "";
                    numMemoryCreated = true;
                }

                numMemoryShownTime -= 7;
                Refresh();
            }

        }
        private void reactionTick_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            reactionStopwatch.Start();
            reactionTick.Interval = randGen.Next(500, 2001);
            reactionTick.Enabled = false;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "menu")
            {
                e.Graphics.FillRectangle(redBrush, exitButton);
                e.Graphics.FillRectangle(whiteBrush, 825, 45, exitLength, 3);
                e.Graphics.DrawRectangle(whitePen, aimTrainerButton);
                e.Graphics.FillRectangle(whiteBrush, 150, 300, aimTrainerLength, 3);
                e.Graphics.DrawRectangle(whitePen, numMemoryButton);
                e.Graphics.FillRectangle(whiteBrush, numMemoryButton.X, 300, numMemoryLength, 3);
                e.Graphics.DrawRectangle(whitePen, reactionButton);
                e.Graphics.FillRectangle(whiteBrush, reactionButton.X, 300, reactionLength, 3);

                e.Graphics.DrawString("Exit", exitFont, whiteBrush, 835, 20);
                e.Graphics.DrawString("Aim Trainer", gameFont, whiteBrush, aimTrainerButton.X + 5, aimTrainerButton.Y + 37);
                e.Graphics.DrawString("Game Trainer", titleFont, whiteBrush, 280, 20);
                e.Graphics.DrawString("Number\nMemory\nTest", gameFont, whiteBrush, numMemoryButton.X + 25, numMemoryButton.Y + 10);
                e.Graphics.DrawString("Reaction \nSpeed", gameFont, whiteBrush, reactionButton.X + 15, reactionButton.Y + 20);

                if (aimTrainerLength > 0)
                {
                    e.Graphics.DrawString("How many targets can \nyou hit in 30 seconds?", exitFont, whiteBrush, aimTrainerButton.X, aimTrainerButton.Y + 110);
                }
                if (numMemoryLength > 0)
                {
                    e.Graphics.DrawString("What is the longest number\n you can remember?", exitFont, whiteBrush, numMemoryButton.X, numMemoryButton.Y + 110);
                }
                if (reactionLength > 0)
                {
                    e.Graphics.DrawString("Test your visual reflexes!\nClick when the screen turns green.", exitFont, whiteBrush, reactionButton.X, reactionButton.Y + 110);
                }
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
                e.Graphics.DrawString($"{(aimTrainerStopwatch).Elapsed.ToString(@"ss\:ff")}", gameFont, whiteBrush, 450, 20);
                e.Graphics.FillEllipse(redBrush, target);
                e.Graphics.DrawString($"Score: {aimTrainerScore}\nMisses: {aimTrainerMisses}\nAccuracy: {aimTrainerAccuracy.ToString("P")}", gameFont, whiteBrush, 30, 20);

            }
            else if (gameState == "aimTrainerOver")
            {
                e.Graphics.DrawString("Game Over", titleFont, whiteBrush, 300, 250);
                e.Graphics.DrawString($"Score: {aimTrainerScore}\nMisses: {aimTrainerMisses}\nAccuracy: {aimTrainerAccuracy.ToString("P")}", gameFont, whiteBrush, 300, 300);
            }
            else if (gameState == "numMemoryShow")
            {
                e.Graphics.DrawString($"Score: {numMemoryScore}", titleFont, whiteBrush, 280, 20);
                e.Graphics.FillRectangle(whiteBrush, 0, 597, numMemoryShownTime, 3);

                if (numMemoryCreated == true)
                {
                    numMemoryOutput.Text = $"{Convert.ToString(numMemory)}";
                }
            }
            else if (gameState == "reactionSpeedEarly")
            {
                numMemoryOutput.Text = "Too soon. \nClick to try again.";
            }
            else if (gameState == "reactionSpeedGood")
            {
                numMemoryOutput.Text = reactionStopwatch.Elapsed.ToString(@"ss\:fff");
                numMemoryOutput.Text += "\n Click to try again.";
            }
            else if (gameState == "reactionSpeedEnd")
            {
                numMemoryOutput.Text = $"Average time: {reactionAverage}ms";
            }
        }
        private void retryButton_Click(object sender, EventArgs e)
        {
            if (gameState == "aimTrainerOver")
            {
                AimTrainerCountdownSetup();
            }
            if (gameState == "numMemoryInput")
            {
                NumberMemorySetup();
            }
            if (gameState == "reactionSpeedEnd")
            {
                ReactionSetup();
            }
        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            MenuSetup();
        }
        private void numMemorySubmit_Click(object sender, EventArgs e)
        {
            numMemoryOutput.Visible = true;
            if (numMemoryInput.Text == Convert.ToString(numMemory))
            {
                numMemoryOutput.Text = $"Correct. \nThe correct number was \n{numMemory}";
                numMemoryScore++;
                Refresh();
                Thread.Sleep(1000);
                gameState = "numMemoryShow";

                numMemoryTick.Enabled = true;
                numMemoryOutput.Visible = true;
                numMemoryInput.Visible = false;
                numMemorySubmit.Visible = false;
                numMemoryCreated = false;

                numMin *= 10;
                numMax *= 10;
                numMemoryShownTime = 900;
                numMemoryInput.Text = "";
            }
            else
            {
                numMemoryOutput.Text = $"Incorrect. \nThe correct number was\n {numMemory}";
                retryButton.Visible = true;
                menuButton.Visible = true;
            }
        }
    }
}
