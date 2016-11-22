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

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            switch (button.BackColor.Name)
            {
                case "Miss":
                    button.BackColor = Color.White;
                    break;
                case "Hit":
                    button.BackColor = Color.Red;
                    break;
                default:
                    button.BackColor = Color.Gray;
                    break;
            }
        }

        private void button33_Click(object sender, EventArgs e) //new game button
        {
            AddShipsForm addShip = new AddShipsForm();

            Board leftBoard = new Board();
            Board rightBoard = new Board();
        }

        private void button34_Click(object sender, EventArgs e) //load game button
        {
            int[,] array;

            //Board leftBoard = new Board(array);
            //Board rightBoard = new Board(array);
        }

        private void button35_Click(object sender, EventArgs e) //save game button
        {
            //SaveGame();
        }

    }
}
