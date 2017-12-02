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

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            startButton.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            showTime.Text = time + " " ; 
        }


    }
}
