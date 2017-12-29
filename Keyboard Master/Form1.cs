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
        int wordNumber = 0;
        bool poprawne = false;
        bool fromLeft;
        bool fromRight;
        string slowoSprawdzane;
        int time = 0;
        int speed = 10;
        int score = 0;
        char pressedKey;
        Random randomY = new Random();
        Random randomX = new Random();
        bool pauseButtonBool = false;
        string[] slowa = File.ReadAllLines("listaSlowAngielskich.txt");
        int slowaWPliku = File.ReadAllLines("listaSlowAngielskich.txt").Length;
        string[] slowaWGrze;
        int liczbaSlowWGrze;


        public Form1()
        {
            InitializeComponent();
            resetGame();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showMenu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            showTime.Text = "Time: " + time;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void resetGame()
        {

        }

        private string getWord(int wordNumber)
        {
            string word = slowa[wordNumber];    //sprawdzic pod kątem tych samych nazw
            slowoSprawdzane = slowa[wordNumber];
            return word; 
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            pauseButtonBool = true;
            timer1.Stop();
            gameButton.Text = "PAUSE";
            gameButton.Show();
            exitButton.Show();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            if(pauseButtonBool == true)
            {
                timer1.Start();
                wordTime.Start();
                pauseButtonBool = false;
                gameButton.Hide();
                exitButton.Hide();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            foreach (Control enemy in Controls)
            {
                if (enemy is Label && (string)enemy.Tag == "word")
                {
                    //exitButton.Show();
                    string slowoObecne;
                    slowoObecne = (string)enemy.Text;
                    if (slowoObecne[0].Equals(e.KeyCode))
                    {
                        this.Close();
                    }
                }
            }
            
        }

        private void wordTime_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i < 20; i++)
           // {
                generujSlowa(1);
           // }
            

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
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            gameTimer.Start();
            wordTime.Start();
            hideMenu();

        }
        
        private void generujSlowa(int ilosc)
        {
            Label[] labelSlowa = new Label[slowaWPliku];
            liczbaSlowWGrze = 0;


            for (int i = 0; i < (ilosc+1); i++)
            {
                labelSlowa[i] = new Label();
                labelSlowa[i].Tag = "word";
                labelSlowa[i].Text = slowa[i];
                labelSlowa[i].Font = showTime.Font;
                labelSlowa[i].BackColor = showTime.BackColor;
                labelSlowa[i].ForeColor = showTime.ForeColor;
                labelSlowa[i].Left = randomX.Next(180, 750);
            }\\ 
            for (int i = 0; i < (ilosc + 1); i++)
            {
                Random cyfra = new Random();
                this.Controls.Add(labelSlowa[cyfra.Next(0, slowaWPliku)]);
            }
        }

        /*private bool literkaPoprawna()
        {
            bool poprawna;
            if()
            {

            }
            return poprawna;
        }*/

    }
}
