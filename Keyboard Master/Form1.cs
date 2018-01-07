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
        int time = 0;
        int speed = 25;
        int score = 0;
        int wordsNumber = 1;
        char lastLetter;
        Random randomX = new Random();
        string[] words;
        bool endGame = false;
        int wordsInFile;
        Label[] labelWords = new Label[102];
        PictureBox[] bullets = new PictureBox[50];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showMenu();
        }

        private void showMenu()
        {
            user.Hide();
            pauseButton.Hide();
            showTime.Hide();
            showScore.Hide();
            user.Hide();
        }

        private void hideMenu()
        {
            startButton.Hide();
            exitButton.Hide();
            gameButton.Hide();
            title.Hide();
            user.Show();
            pauseButton.Show();
        }

        private void exitGame()
        {
            exitButton.Show();
            gameButton.Text = "RESET";
            pauseButton.Hide();
            gameButton.Show();
            turnOffTimers();
            clear();
            scoreTable();
            endGame = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            hideMenu();
            jezykAngielski.Show();
            jezykPolski.Show();
        }

        private void jezykPolski_Click(object sender, EventArgs e)
        {
            words = File.ReadAllLines("listaSlowPolskich.txt");
            wordsInFile = File.ReadAllLines("listaSlowPolskich.txt").Length;
            turnOnTimers();
            showTime.Show();
            showScore.Show();
            user.Show();
            hideMenu();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            createLabels();
        }

        private void jezykAngielski_Click(object sender, EventArgs e)
        {
            words = File.ReadAllLines("listaSlowAngielskich.txt");
            wordsInFile = File.ReadAllLines("listaSlowAngielskich.txt").Length;
            turnOnTimers();
            showTime.Show();
            showScore.Show();
            user.Show();
            hideMenu();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            createLabels();
        }

        private void gameButton_Click_1(object sender, EventArgs e)
        {
            turnOnTimers();
            gameButton.Hide();
            exitButton.Hide();
            if (endGame == true)
                Application.Restart();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            turnOffTimers();
            gameButton.Text = "PAUSE";
            gameButton.Show();
            exitButton.Show();
            jezykAngielski.Hide();
            jezykPolski.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString().ToLower();
            correctLetter(key);

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void correctLetter(string key)
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
                            showScore.Text = "Score: " + score;
                        }
                        else
                            lastLetter = '\0';
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            showTime.Text = "Time: " + time;
        }

        private void wordTime_Tick(object sender, EventArgs e)
        {
            generateWords(wordsNumber);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            foreach (Control obj in this.Controls)
            {
                if (obj is Label && (string)obj.Tag == "word")
                {
                    obj.Top += speed;
                    if (obj.Top + obj.Height > this.ClientSize.Height)
                    {
                        exitGame();
                    }
                    if (obj.Text.Length < 1)
                    {
                        this.Controls.Remove(obj);
                    }
                }

            }

            if (score % 20 == 0 && score > 20)
            {
                speed++;
            }

            if (score % 40 == 0 && score > 40)
            {
                wordsNumber++;
            }
        }

        private void createLabels()
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

        private void turnOnTimers()
        {
            timer1.Start();
            wordTime.Start();
            gameTimer.Start();
        }

        private void turnOffTimers()
        {
            timer1.Stop();
            gameTimer.Stop();
            wordTime.Stop();
        }

        private void generateWords(int ilosc)
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

        private void clear()
        {
            foreach (Control element in this.Controls)
            {
                if (element is Label && (string)element.Tag == "word")
                    this.Controls.Remove(element);
            }

        }

        private void scoreTable()
        {
            showScore.Top = +240;
            showScore.Left = +410;
            showTime.Top = +240;
            showTime.Left = +530;
            user.Hide();
            clear();
        }
    }
}
