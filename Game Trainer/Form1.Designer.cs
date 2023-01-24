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
            this.retryButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.numMemoryTick = new System.Windows.Forms.Timer(this.components);
            this.numMemoryOutput = new System.Windows.Forms.Label();
            this.numMemoryInput = new System.Windows.Forms.TextBox();
            this.numMemorySubmit = new System.Windows.Forms.Button();
            this.reactionTick = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            // retryButton
            // 
            this.retryButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.retryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retryButton.ForeColor = System.Drawing.Color.White;
            this.retryButton.Location = new System.Drawing.Point(230, 369);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(60, 30);
            this.retryButton.TabIndex = 0;
            this.retryButton.Text = "Retry";
            this.retryButton.UseVisualStyleBackColor = false;
            this.retryButton.Click += new System.EventHandler(this.retryButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Red;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Location = new System.Drawing.Point(630, 369);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(60, 30);
            this.menuButton.TabIndex = 1;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // numMemoryTick
            // 
            this.numMemoryTick.Interval = 20;
            this.numMemoryTick.Tick += new System.EventHandler(this.numMemoryTick_Tick);
            // 
            // numMemoryOutput
            // 
            this.numMemoryOutput.AutoSize = true;
            this.numMemoryOutput.BackColor = System.Drawing.Color.Transparent;
            this.numMemoryOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMemoryOutput.ForeColor = System.Drawing.Color.White;
            this.numMemoryOutput.Location = new System.Drawing.Point(300, 125);
            this.numMemoryOutput.Name = "numMemoryOutput";
            this.numMemoryOutput.Size = new System.Drawing.Size(118, 42);
            this.numMemoryOutput.TabIndex = 2;
            this.numMemoryOutput.Text = "label1";
            this.numMemoryOutput.Visible = false;
            // 
            // numMemoryInput
            // 
            this.numMemoryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMemoryInput.Location = new System.Drawing.Point(307, 269);
            this.numMemoryInput.Name = "numMemoryInput";
            this.numMemoryInput.Size = new System.Drawing.Size(168, 26);
            this.numMemoryInput.TabIndex = 3;
            this.numMemoryInput.Visible = false;
            // 
            // numMemorySubmit
            // 
            this.numMemorySubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMemorySubmit.Location = new System.Drawing.Point(496, 270);
            this.numMemorySubmit.Name = "numMemorySubmit";
            this.numMemorySubmit.Size = new System.Drawing.Size(73, 26);
            this.numMemorySubmit.TabIndex = 4;
            this.numMemorySubmit.Text = "Sumbit";
            this.numMemorySubmit.UseVisualStyleBackColor = true;
            this.numMemorySubmit.Visible = false;
            this.numMemorySubmit.Click += new System.EventHandler(this.numMemorySubmit_Click);
            // 
            // reactionTick
            // 
            this.reactionTick.Interval = 200;
            this.reactionTick.Tick += new System.EventHandler(this.reactionTick_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "WASD to move";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMemorySubmit);
            this.Controls.Add(this.numMemoryInput);
            this.Controls.Add(this.numMemoryOutput);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.retryButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Trainer";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer menuTick;
        private System.Windows.Forms.Timer aimTrainerCountdown;
        private System.Windows.Forms.Timer aimTrainer;
        private System.Windows.Forms.Button retryButton;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Timer numMemoryTick;
        private System.Windows.Forms.Label numMemoryOutput;
        private System.Windows.Forms.TextBox numMemoryInput;
        private System.Windows.Forms.Button numMemorySubmit;
        private System.Windows.Forms.Timer reactionTick;
        private System.Windows.Forms.Label label1;
    }
}

