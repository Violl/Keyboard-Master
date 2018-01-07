// ***********************************************************************
// Assembly         : Keyboard Master
// Author           : Małgorzata Rucińska
// Created          : 07-01-2017
//
// Last Modified By : Hosi
// Last Modified On : 01-07-2018
// ***********************************************************************
// <copyright file="Form1.cs" company="Politechnika Gdańska">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Windows.Forms;

namespace Keyboard_Master
{

    /// <summary>
    /// Class Form1.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        /// <summary>
        /// The time
        /// </summary>
        int time = 0;
        /// <summary>
        /// The speed
        /// </summary>
        int speed = 5;
        /// <summary>
        /// The score
        /// </summary>
        int score = 0;
        /// <summary>
        /// The words number
        /// </summary>
        int wordsNumber = 1;
        /// <summary>
        /// The last letter typed correctly
        /// </summary>
        char lastLetter;
        /// <summary>
        /// The words
        /// </summary>
        string[] words;
        /// <summary>
        /// The end game
        /// </summary>
        bool endGame = false;
        /// <summary>
        /// The words in file
        /// </summary>
        int wordsInFile;
        Random randomX = new Random();
        /// <summary>
        /// The label words
        /// </summary>
        Label[] labelWords = new Label[102];
        /// <summary>
        /// The bullets
        /// </summary>
        PictureBox[] bullets = new PictureBox[50];
        System.Media.SoundPlayer hitSound = new System.Media.SoundPlayer("hit.wav");
        System.Media.SoundPlayer selectSound = new System.Media.SoundPlayer("select.wav");

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMenu();
        }

        /// <summary>
        /// Shows the game menu.
        /// </summary>
        private void ShowMenu()
        {
            user.Hide();
            pauseButton.Hide();
            showTime.Hide();
            showScore.Hide();
            user.Hide();
        }

        /// <summary>
        /// Hides the game menu.
        /// </summary>
        private void HideMeny()
        {
            startButton.Hide();
            exitButton.Hide();
            gameButton.Hide();
            title.Hide();
            user.Show();
            pauseButton.Show();
        }

        /// <summary>
        /// Exits the game and shows scores and menu that allows to exit game or start it again.
        /// </summary>
        private void ExitGame()
        {
            exitButton.Show();
            gameButton.Text = "RESET";
            pauseButton.Hide();
            gameButton.Show();
            TurnOffTimers();
            user.Hide();
            ScoreTable();
            endGame = true;
        }

        /// <summary>
        /// Handles the Click event of the startButton control. Shows buttons that allow player to choose game mode.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void startButton_Click(object sender, EventArgs e)
        {
            HideMeny();
            jezykAngielski.Show();
            jezykPolski.Show();
            selectSound.Play();
        }

        /// <summary>
        /// Handles the Click event of the jezykPolski control. Pushing this button by user loads polish word list and starts game in choosed game mode;
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void jezykPolski_Click(object sender, EventArgs e)
        {
            words = File.ReadAllLines("listaSlowPolskich.txt");
            wordsInFile = File.ReadAllLines("listaSlowPolskich.txt").Length;
            TurnOnTimers();
            showTime.Show();
            showScore.Show();
            user.Show();
            HideMeny();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            CreateLabels();
            selectSound.Play();
        }

        /// <summary>
        /// Handles the Click event of the jezykAngielski control.Pushing this button by user loads english word list and starts game in choosed game mode;
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void jezykAngielski_Click(object sender, EventArgs e)
        {
            words = File.ReadAllLines("listaSlowAngielskich.txt");
            wordsInFile = File.ReadAllLines("listaSlowAngielskich.txt").Length;
            TurnOnTimers();
            showTime.Show();
            showScore.Show();
            user.Show();
            HideMeny();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            CreateLabels();
            selectSound.Play();
        }

        /// <summary>
        /// Handles the 1 event of the gameButton_Click control. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gameButton_Click_1(object sender, EventArgs e)
        {
            TurnOnTimers();
            gameButton.Hide();
            exitButton.Hide();
            if (endGame == true)
                Application.Restart();
            selectSound.Play();
        }

        /// <summary>
        /// Handles the Click event of the pauseButton control. Pushin this button pauses the game.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            TurnOffTimers();
            gameButton.Text = "PAUSE";
            gameButton.Show();
            exitButton.Show();
            jezykAngielski.Hide();
            jezykPolski.Hide();
            selectSound.Play();
        }

        /// <summary>
        /// Handles the Click event of the exitButton control. Pushing this button exits application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            selectSound.Play();
        }

        /// <summary>
        /// Handles the KeyDown event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString().ToLower();
            CorrectLetter(key);

            //if esc is pressed game will be closed.
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        /// <summary>
        /// Checking if input letter is equal to any first letter of words in the game. If is - letter is removed and score counter is increased. This function also ensures that letter will be removed only from one word at the time.
        /// </summary>
        /// <param name="key">The key.</param>
        private void CorrectLetter(string key)
        {
            foreach (Control enemy in this.Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word" && enemy.Text.Length > 0)
                {
                    string temp = enemy.Text;
                    if (temp[0] == key[0])
                    {
                        if (!lastLetter.Equals(key[0]))
                        {
                            temp = temp.Remove(0, 1);
                            enemy.Text = temp;
                            lastLetter = key[0];
                            score++;
                            hitSound.Play();
                            showScore.Text = "Score: " + score;
                        }
                        else
                            lastLetter = '\0';
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control and shows current game time.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            showTime.Text = "Time: " + time;
        }

        /// <summary>
        /// Handles the Tick event of the wordTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void wordTime_Tick(object sender, EventArgs e)
        {
            GenerateWords(wordsNumber);
        }

        /// <summary>
        /// Handles the Tick event of the gameTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control enemy in this.Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word")
                {
                    enemy.Top += speed;
                    if (enemy.Top + enemy.Height > this.ClientSize.Height)
                    {
                        ExitGame();
                    }
                    if (enemy.Text.Length < 1)
                    {
                        this.Controls.Remove(enemy);
                    }
                }
            }
            ChangeDifficulty();
        }

        /// <summary>
        /// Creates the labels.
        /// </summary>
        private void CreateLabels()
        {
            for (int i = 0; i < wordsInFile - 1; i++)
            {
                labelWords[i] = new Label();
                labelWords[i].Tag = "word";
                labelWords[i].Text = words[i];
                labelWords[i].Font = showTime.Font;
                labelWords[i].BackColor = showTime.BackColor;
                labelWords[i].ForeColor = showTime.ForeColor;
                labelWords[i].Left = randomX.Next(180, 750);
                labelWords[i].AutoSize = true;
                labelWords[i].MinimumSize = showTime.MinimumSize;
            }
        }

        /// <summary>
        /// Turns on the timers.
        /// </summary>
        private void TurnOnTimers()
        {
            timer1.Start();
            wordTime.Start();
            gameTimer.Start();
        }

        /// <summary>
        /// Turns off the timers.
        /// </summary>
        private void TurnOffTimers()
        {
            timer1.Stop();
            gameTimer.Stop();
            wordTime.Stop();
        }

        /// <summary>
        /// Generates the words taken from loaded file in difficulty based on current score.
        /// </summary>
        /// <param name="ilosc">The ilosc.</param>
        private void GenerateWords(int ilosc)
        {
            Random cyfra = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                int caseSwitch = 1;
                if (score > 20 && score < 50) caseSwitch = 2;
                if (score >= 50 && score < 70) caseSwitch = 3;
                if (score >= 70 && score < 90) caseSwitch = 4;
                if (score >= 90) caseSwitch = 5;

                switch (caseSwitch)
                {
                    case 1:
                        this.Controls.Add(labelWords[cyfra.Next(0, wordsInFile / 5)]);
                        break;
                    case 2:
                        this.Controls.Add(labelWords[cyfra.Next(wordsInFile / 5, wordsInFile * 2 / 5)]);
                        break;
                    case 3:
                        this.Controls.Add(labelWords[cyfra.Next(wordsInFile * 2 / 5, wordsInFile * 3 / 5)]);
                        break;
                    case 4:
                        this.Controls.Add(labelWords[cyfra.Next(wordsInFile * 3 / 5, wordsInFile * 4 / 5)]);
                        break;
                    case 5:
                        this.Controls.Add(labelWords[cyfra.Next(wordsInFile * 4 / 5, wordsInFile)]);
                        break;
                    default:
                        this.Controls.Add(labelWords[cyfra.Next(0, wordsInFile)]);
                        break;
                }
            }
        }

        /// <summary>
        /// Clears this instance from controls
        /// </summary>
        private void Clear()
        {
            foreach (Control element in this.Controls)
            {
                if (element is Label && (string)element.Tag == "word")
                    this.Controls.Remove(element);
            }

        }

        /// <summary>
        /// Shows the score when game is over.
        /// </summary>
        private void ScoreTable()
        {
            showScore.Top = +240;
            showScore.Left = +400;
            showTime.Top = +240;
            showTime.Left = +540;
            Clear();
        }

        /// <summary>
        /// Changes the difficulty of the game upon current user score.
        /// </summary>
        private void ChangeDifficulty()
        {
            if (score % 20 == 0 && score > 20)
            {
                speed++;
            }
        }
    }
}
