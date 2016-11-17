using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control board = ((Control)sender);
            switch (board.BackColor.Name)
            {
                case "Miss":
                    board.BackColor = Color.White;
                    break;
                case "Hit":
                    board.BackColor = Color.Red;
                    break;
                default:
                    board.BackColor = Color.Gray;
                    break;
            }
        }

        private void button33_Click(object sender, EventArgs e) //new game button
        {
            //NewGame();
        }

        private void button34_Click(object sender, EventArgs e) //load game button
        {
            //LoadGame();
        }

        private void button35_Click(object sender, EventArgs e) //save game button
        {
            //SaveGame();
        }
    }
}
