using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace Keyboard_Master
{

    public partial class Form1 : Form
    {
        int wordNumber = 0;
        bool poprawne = false;
        string slowoSprawdzane;
        int time = 0;
        int speed = 5;
        int score = 0;
        char pressedKey;
        Random randomY = new Random();
        Random randomX = new Random();
        bool pauseButtonBool = false;
        string[] slowa = File.ReadAllLines("listaSlowAngielskich.txt");

        public Form1()
        {
            InitializeComponent();
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

        private void moveEnemies()
        {
            foreach ( Control enemy in this.Controls)
            if (enemy is PictureBox && enemy.Tag == word)
                {

                }
        }

        private void showMenu()
        {
            user.Hide();
            pauseButton.Hide();
            word.Hide();
            wordPointer.Hide();
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
            word.Show();
            wordPointer.Show();
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
            if (e.KeyCode == Keys.B)
                poprawne = true;
        }

        private void wordTime_Tick(object sender, EventArgs e)
        {
            if (poprawne == true)
            {
                slowoSprawdzane.Remove(0, 1);
                word.Text = slowoSprawdzane;

            }

        }


        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            wordTime.Start();
            hideMenu();
            slowoSprawdzane = slowa[0];
            word.Text = slowoSprawdzane;
            slowo2.Text = slowa[1];
        }
    }
}
