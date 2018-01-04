using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Resources;

namespace Keyboard_Master
{

    public partial class Form1 : Form
    {
        bool poprawne = false;
        int time = 0;
        int speed = 5;
        int score = 0;
        Random randomY = new Random();
        Random randomX = new Random();
        bool pauseButtonBool = false;
        string[] slowa;
        int slowaWPliku;
        Label[] labelSlowa = new Label[102];


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
        }

        private void hideMenu()
        {
            timer1.Start();
            startButton.Hide();
            exitButton.Hide();
            gameButton.Hide();
            title.Hide();
            user.Show();
            pauseButton.Show();
            showTime.Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            hideMenu();
            jezykAngielski.Show();
            jezykPolski.Show();
        }

        private void jezykPolski_Click(object sender, EventArgs e)
        {
            slowa = File.ReadAllLines("listaSlowPolskich.txt");
            slowaWPliku = File.ReadAllLines("listaSlowPolskich.txt").Length;
            timer1.Start();
            gameTimer.Start();
            wordTime.Start();
            hideMenu();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            stworzLabele();
        }

        private void jezykAngielski_Click(object sender, EventArgs e)
        {
            timer1.Start();
            gameTimer.Start();
            wordTime.Start();
            hideMenu();
            jezykPolski.Hide();
            jezykAngielski.Hide();
            slowa = File.ReadAllLines("listaSlowAngielskich.txt");
            slowaWPliku = File.ReadAllLines("listaSlowAngielskich.txt").Length;
            stworzLabele();
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
            literaPoprawna(key);

            if (e.KeyCode == Keys.Escape)
                this.Close();
            
            if (poprawne == true)
            {
                score++;
                showScore.Text = "Score: " + score;
            }
        }

        private void literaPoprawna(string key)
        {
            foreach (Control enemy in this.Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word" && enemy.Text.Length > 0)
                {
                    
                        string roboczy = enemy.Text;
                        if (roboczy[0] == key[0])
                        {
                            poprawne = true;
                            roboczy = roboczy.Remove(0, 1);
                            enemy.Text = roboczy;
                        }
                        else
                        {
                            poprawne = false;
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
            generujSlowa(2);

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
                        exitButton.Show();
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

            if(score % 20 == 0 && score > 20)
            {
                speed++;
            }
        }

        private void stworzLabele()
        {
            for (int i = 0; i < slowaWPliku-1; i++)
            {
                labelSlowa[i] = new Label();
                labelSlowa[i].Tag = "word";
                labelSlowa[i].Text = slowa[i];
                labelSlowa[i].Font = showTime.Font;
                labelSlowa[i].BackColor = showTime.BackColor;
                labelSlowa[i].ForeColor = showTime.ForeColor;
                labelSlowa[i].Left = randomX.Next(180, 750);
                labelSlowa[i].AutoSize = true;
                labelSlowa[i].MinimumSize = showTime.MinimumSize;
            }
        }

        private void generujSlowa(int ilosc)
        {
            Random cyfra = new Random();
            for (int i = 0; i < ilosc; i++)
            {
                this.Controls.Add(labelSlowa[cyfra.Next(0, slowaWPliku)]);
            }
        }
    }
}
