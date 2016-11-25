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

        private Board leftBoard;
        private Board rightBoard;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button s in this.Controls.OfType<Button>())
            {
                s.Enabled = false;
            }

            btnControlNewGame.Enabled = true;
            btnControlLoadGame.Enabled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            Board currentBoard;
            string currentButton = button.Name;
            //standard form: btn(L/R)(00)

            if (currentButton[3].ToString() == "R")
                currentBoard = leftBoard;
            else if (currentButton[3].ToString() == "L")
                currentBoard = rightBoard;
            else
            {
                Console.WriteLine(currentButton[3]);
                throw new NotImplementedException();
            }
                

            int status = currentBoard.Shot(int.Parse(currentButton[4].ToString()), int.Parse(currentButton[5].ToString()));

            switch (status)
            {
                case 2:
                    button.BackColor = Color.White;
                    break;
                case 3:
                    button.BackColor = Color.Red;
                    break;
                default:
                    button.BackColor = Color.Gray;
                    break;
            }

            if (currentButton[3].ToString() == "R")
                leftBoard = currentBoard;
            else if (currentButton[3].ToString() == "L")
                rightBoard = currentBoard;
            else
                throw new NotImplementedException();

            //switch board

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.Name[3].ToString() != currentButton[3].ToString())
                {
                    s.Enabled = true;
                }
                else if (s.Name[3].ToString() == currentButton[3].ToString())
                {
                    s.Enabled = false;
                }
            }

            //check for win
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //need to add a reset here

            AddShipsForm addShipL = new AddShipsForm();
            AddShipsForm addShipR = new AddShipsForm();

            leftBoard = new Board();
            rightBoard = new Board();

            //TODO: Loop all this.
            Ship ship5Place = addShipL.GetNewShip(5);
            Ship ship4Place = addShipL.GetNewShip(4);
            //Ship ship3Place = addShip.GetNewShip(3);
            //Ship ship3Place2 = addShip.GetNewShip(3);
            //Ship ship2Place = addShipL.GetNewShip(2);

            leftBoard.AddShip(ship5Place);
            leftBoard.AddShip(ship4Place);
            //leftBoard.AddShip(ship3Place);
            //leftBoard.AddShip(ship3Place2);
            //leftBoard.AddShip(ship2Place);

            Ship ship5PlaceR = addShipR.GetNewShip(5);
            //Ship ship4Place = addShip.GetNewShip(4);
            //Ship ship3Place = addShip.GetNewShip(3);
            //Ship ship3Place2 = addShip.GetNewShip(3);
            Ship ship2PlaceR = addShipR.GetNewShip(2);

            rightBoard.AddShip(ship5PlaceR);
            //rightBoard.AddShip(ship4Place);
            //rightBoard.AddShip(ship3Place);
            //rightBoard.AddShip(ship3Place2);
            rightBoard.AddShip(ship2PlaceR);

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.Name[3].ToString() == "L")
                {
                    s.Enabled = true;
                }
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            int[,] array;

            //Board leftBoard = new Board(array);
            //Board rightBoard = new Board(array);
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {

        }
    }
}
