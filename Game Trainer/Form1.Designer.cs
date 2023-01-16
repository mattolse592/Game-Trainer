namespace Game_Trainer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuTick = new System.Windows.Forms.Timer(this.components);
            this.aimTrainerCountdown = new System.Windows.Forms.Timer(this.components);
            this.aimTrainer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // menuTick
            // 
            this.menuTick.Interval = 20;
            this.menuTick.Tick += new System.EventHandler(this.gameTick_Tick);
            // 
            // aimTrainerCountdown
            // 
            this.aimTrainerCountdown.Interval = 20;
            this.aimTrainerCountdown.Tick += new System.EventHandler(this.aimTrainerCountdown_Tick);
            // 
            // aimTrainer
            // 
            this.aimTrainer.Interval = 20;
            this.aimTrainer.Tick += new System.EventHandler(this.aimTrainer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Trainer";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer menuTick;
        private System.Windows.Forms.Timer aimTrainerCountdown;
        private System.Windows.Forms.Timer aimTrainer;
    }
}

