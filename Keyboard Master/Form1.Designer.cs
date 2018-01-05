namespace Keyboard_Master
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.user = new System.Windows.Forms.PictureBox();
            this.showTime = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.PictureBox();
            this.wordTime = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.gameButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.showScore = new System.Windows.Forms.Label();
            this.jezykPolski = new System.Windows.Forms.Button();
            this.jezykAngielski = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // user
            // 
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.Image = ((System.Drawing.Image)(resources.GetObject("user.Image")));
            this.user.Location = new System.Drawing.Point(488, 615);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(64, 102);
            this.user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.user.TabIndex = 5;
            this.user.TabStop = false;
            this.user.Tag = "user";
            // 
            // showTime
            // 
            this.showTime.AutoEllipsis = true;
            this.showTime.AutoSize = true;
            this.showTime.BackColor = System.Drawing.Color.Transparent;
            this.showTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showTime.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.showTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.showTime.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.showTime.Location = new System.Drawing.Point(859, 23);
            this.showTime.MinimumSize = new System.Drawing.Size(0, 45);
            this.showTime.Name = "showTime";
            this.showTime.Size = new System.Drawing.Size(97, 45);
            this.showTime.TabIndex = 8;
            this.showTime.Text = "Time: 0";
            this.showTime.UseCompatibleTextRendering = true;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.Transparent;
            this.pauseButton.Image = global::Keyboard_Master.Properties.Resources.znak_pauzy;
            this.pauseButton.Location = new System.Drawing.Point(116, 23);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(36, 50);
            this.pauseButton.TabIndex = 10;
            this.pauseButton.TabStop = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // wordTime
            // 
            this.wordTime.Interval = 2500;
            this.wordTime.Tick += new System.EventHandler(this.wordTime_Tick);
            // 
            // startButton
            // 
            this.startButton.AutoEllipsis = true;
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.startButton.Image = global::Keyboard_Master.Properties.Resources.button_background;
            this.startButton.Location = new System.Drawing.Point(361, 285);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(314, 97);
            this.startButton.TabIndex = 12;
            this.startButton.Tag = "przycisk";
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // gameButton
            // 
            this.gameButton.BackColor = System.Drawing.Color.Transparent;
            this.gameButton.FlatAppearance.BorderSize = 0;
            this.gameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gameButton.Image = global::Keyboard_Master.Properties.Resources.button_background;
            this.gameButton.Location = new System.Drawing.Point(361, 285);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(314, 97);
            this.gameButton.TabIndex = 13;
            this.gameButton.Tag = "przycisk";
            this.gameButton.Text = "WZNOW";
            this.gameButton.UseVisualStyleBackColor = false;
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click_1);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.BackgroundImage = global::Keyboard_Master.Properties.Resources.title;
            this.title.Location = new System.Drawing.Point(295, 110);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(461, 83);
            this.title.TabIndex = 14;
            this.title.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.exitButton.Image = global::Keyboard_Master.Properties.Resources.button_background;
            this.exitButton.Location = new System.Drawing.Point(361, 397);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(314, 97);
            this.exitButton.TabIndex = 15;
            this.exitButton.Tag = "przycisk";
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // showScore
            // 
            this.showScore.AutoEllipsis = true;
            this.showScore.AutoSize = true;
            this.showScore.BackColor = System.Drawing.Color.Transparent;
            this.showScore.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold);
            this.showScore.ForeColor = System.Drawing.Color.White;
            this.showScore.Location = new System.Drawing.Point(853, 62);
            this.showScore.Name = "showScore";
            this.showScore.Size = new System.Drawing.Size(107, 33);
            this.showScore.TabIndex = 16;
            this.showScore.Text = "Score: 0";
            // 
            // jezykPolski
            // 
            this.jezykPolski.AutoEllipsis = true;
            this.jezykPolski.BackColor = System.Drawing.Color.Transparent;
            this.jezykPolski.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.jezykPolski.FlatAppearance.BorderSize = 0;
            this.jezykPolski.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jezykPolski.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jezykPolski.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.jezykPolski.Image = global::Keyboard_Master.Properties.Resources.button_background;
            this.jezykPolski.Location = new System.Drawing.Point(361, 223);
            this.jezykPolski.Name = "jezykPolski";
            this.jezykPolski.Size = new System.Drawing.Size(314, 97);
            this.jezykPolski.TabIndex = 17;
            this.jezykPolski.Tag = "przycisk";
            this.jezykPolski.Text = "JEZYK POLSKI";
            this.jezykPolski.UseVisualStyleBackColor = false;
            this.jezykPolski.Visible = false;
            this.jezykPolski.Click += new System.EventHandler(this.jezykPolski_Click);
            // 
            // jezykAngielski
            // 
            this.jezykAngielski.BackColor = System.Drawing.Color.Transparent;
            this.jezykAngielski.FlatAppearance.BorderSize = 0;
            this.jezykAngielski.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jezykAngielski.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jezykAngielski.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.jezykAngielski.Image = global::Keyboard_Master.Properties.Resources.button_background;
            this.jezykAngielski.Location = new System.Drawing.Point(361, 326);
            this.jezykAngielski.Name = "jezykAngielski";
            this.jezykAngielski.Size = new System.Drawing.Size(314, 97);
            this.jezykAngielski.TabIndex = 18;
            this.jezykAngielski.Tag = "przycisk";
            this.jezykAngielski.Text = "JEZYK ANGIELSKI";
            this.jezykAngielski.UseVisualStyleBackColor = false;
            this.jezykAngielski.Visible = false;
            this.jezykAngielski.Click += new System.EventHandler(this.jezykAngielski_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Keyboard_Master.Properties.Resources.point;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(511, 592);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 17);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Keyboard_Master.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.showScore);
            this.Controls.Add(this.title);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.showTime);
            this.Controls.Add(this.user);
            this.Controls.Add(this.jezykPolski);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.gameButton);
            this.Controls.Add(this.jezykAngielski);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Type";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox user;
        public System.Windows.Forms.Label showTime;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pauseButton;
        private System.Windows.Forms.Timer wordTime;
        private System.Windows.Forms.PictureBox title;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button gameButton;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label showScore;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button jezykPolski;
        private System.Windows.Forms.Button jezykAngielski;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

