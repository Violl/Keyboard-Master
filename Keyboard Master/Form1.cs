using System;
using System.IO;
using System.Windows.Forms;

namespace Keyboard_Master
{

    public partial class Form1 : Form
    {
        bool correct = false;
        int time = 0;
        int locationX;
        int locationY;
        int speed = 5;
        int score = 0;
        Random randomY = new Random();
        Random randomX = new Random();
        bool pauseButtonBool = false;
        string[] words;
        int wordsInFile;
        Label[] labelWords = new Label[102];

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
            timer1.Stop();
            gameTimer.Stop();
            wordTime.Stop();
            deleteWords();
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
            timer1.Start();
            gameTimer.Start();
            wordTime.Start();
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
            timer1.Start();
            gameTimer.Start();
            wordTime.Start();
            showTime.Show();
            showScore.Show();
            user.Show();
            hideMenu();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            createLabels();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            if (pauseButtonBool == true)
            {
                timer1.Start();
                wordTime.Start();
                pauseButtonBool = false;
                gameButton.Hide();
                exitButton.Hide();
            }
        }

        private void gameButton_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            wordTime.Start();
            gameTimer.Start();
            gameButton.Hide();
            exitButton.Hide();
            pauseButtonBool = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pauseButtonBool = true;
            timer1.Stop();
            gameTimer.Stop();
            wordTime.Stop();
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

            if (correct == true)
            {
                score++;
                showScore.Text = "Score: " + score;
            }
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
                        correct = true;
                        temp = temp.Remove(0, 1);
                        enemy.Text = temp;
                    }

                    else
                    {
                        correct = false;
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
            generateWords(1);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control enemy in this.Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word")
                {
                    enemy.Top += speed;
                    if (enemy.Top + enemy.Height > this.ClientSize.Height)
                    {
                        exitGame();
                    }
                }
            }

            foreach (Control enemy in this.Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word")
                {
                    if (enemy.Text.Length < 1)
                    {
                        this.Controls.Remove(enemy);
                    }
                }

            }

            if (score % 20 == 0 && score > 20)
            {
                speed++;
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

        private void generateWords(int ilosc)
        {
            Random cyfra = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                this.Controls.Add(labelWords[cyfra.Next(0, wordsInFile)]);
            }
        }

        private void deleteWords()
        {
            foreach (Control enemy in this.Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word")
                {
                    this.Controls.Remove(enemy);
                }

            }
        }
    }
}
