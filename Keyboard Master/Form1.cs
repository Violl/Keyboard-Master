using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Master
{
    public partial class Form1 : Form
    {
        int time = 0;
        
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
            showTime.Text = time + " " ; 
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            hideMenu();
        }

    }
}
