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

        private List<Ship> ships = null;

        public Form1()
        {
            InitializeComponent();
        }

        //TODO: 
             // Add error handling.
             // Allow selectable save/load locations.
             // Make a better end-game screen.
             // Fix issues with saving/loading finished games.
             // Distribute code more correctly, placing related functions in their classes.
             // Fix code in general to make it less redundant.
             // Make tests.
             // Don't break anything?

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
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
                throw new NotImplementedException(); //something was named wrong.

            int status = currentBoard.Shot(int.Parse(currentButton[4].ToString()), int.Parse(currentButton[5].ToString()));

            switch (status)
            {
                case 2: //miss
                    button.BackColor = Color.White;
                    break;
                case 3: //hit
                    button.BackColor = Color.Red;
                    break;
                default: //array is malformed
                    throw new NotImplementedException();
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
                else
                    throw new NotImplementedException();
            }

            //update scoreboard
            
            int rHpCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (rightBoard.ShipHealths()[i].ToString() == "0")
                    rHpCount++;
            }

            leftScore.Text = rHpCount.ToString();
            
            int lHpCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (leftBoard.ShipHealths()[i].ToString() == "0")
                    lHpCount++;
            }

            rightScore.Text = lHpCount.ToString();

            //check for win

            if (currentBoard.Win())
            {
                MessageBox.Show("Player " + button.Name[3].ToString() + " won.");

                for (int i = 0; i < 5; i++)
                    Console.WriteLine(leftBoard.ShipHealths()[i].ToString());

                for (int i = 0; i < 5; i++)
                    Console.WriteLine(rightBoard.ShipHealths()[i].ToString());

                Reset();
            }
                
        }

        private void Reset()
        {
            foreach (Button s in this.Controls.OfType<Button>())
            {
                s.Enabled = false;
                s.UseVisualStyleBackColor = true;
            }

            btnControlNewGame.Enabled = true;
            btnControlLoadGame.Enabled = true;
            //can't save a game without ships.
            //pointless to allow saving a just-loaded game.
        }


        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Reset();
            
            AddShipsForm addShipL = new AddShipsForm();
            AddShipsForm addShipR = new AddShipsForm();
            //these windows jump all over the place for no good reason. need to find a fix.

            leftBoard = new Board();
            rightBoard = new Board();

            ships = new List<Ship>();
            
            for (int i = 5; i > 0; i--)
            {
                Ship ship = addShipL.GetNewShip(i);
                leftBoard.AddShip(ship);
                ships.Add(ship);
            }

            for (int i = 5; i > 0; i--)
            {
                Ship ship = addShipR.GetNewShip(i);
                rightBoard.AddShip(ship);
                ships.Add(ship);
            }

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
            Reset();

            string[] lines = System.IO.File.ReadLines("C:\\Users\\macropower\\Documents\\test.txt").ToArray();
            //should ALWAYS be 10+10+5+5+1 lines

            int[,] arrayR = new int[10, 10];

            for (int rowIndex = 0; rowIndex < 10; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 10; colIndex++)
                {
                    arrayR[rowIndex, colIndex] = int.Parse(lines[rowIndex][colIndex].ToString());
                }
            }

            int[,] arrayL = new int[10, 10];

            for (int rowIndex = 0; rowIndex < 10; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 10; colIndex++)
                {
                    arrayL[rowIndex, colIndex] = int.Parse(lines[rowIndex+10][colIndex].ToString());
                }
            }

            //above should probably go into board class.

             leftBoard = new Board(arrayL);
             rightBoard = new Board(arrayR);


            ships = new List<Ship>();

            for (int i = 0; i < 5; i++)
            {
                Ship ship = new Ship(int.Parse(lines[i+20][0].ToString()), int.Parse(lines[i + 20][1].ToString()), int.Parse(lines[i + 20][2].ToString()), int.Parse(lines[i + 20][3].ToString()), int.Parse(lines[i + 25][4].ToString()));
                leftBoard.AddShip(ship);
                ships.Add(ship);
            }

            for (int i = 0; i < 5; i++)
            {
                Ship ship = new Ship(int.Parse(lines[i + 25][0].ToString()), int.Parse(lines[i + 25][1].ToString()), int.Parse(lines[i + 25][2].ToString()), int.Parse(lines[i + 25][3].ToString()), int.Parse(lines[i + 25][4].ToString()));
                rightBoard.AddShip(ship);
                ships.Add(ship);
            }


            //update all buttons based on array.

            //this code is very bad and should be written in a way that's not super redundant. just PoC for now.

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if(!(s.Name[3].ToString() == "C" || s.Name[3].ToString() == "L"))
                {
                    if (leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 0
                     || leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 1)
                    {
                        s.UseVisualStyleBackColor = true;
                    }
                    else if (leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 2)
                    {
                        s.BackColor = Color.White;
                    }
                    else if (leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 3)
                    {
                        s.BackColor = Color.Red;
                    }
                }
            }

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (!(s.Name[3].ToString() == "C" || s.Name[3].ToString() == "R"))
                {
                    if (rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 0
                     || rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 1)
                    {
                        s.UseVisualStyleBackColor = true;
                    }
                    else if (rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 2)
                    {
                        s.BackColor = Color.White;
                    }
                    else if (rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 3)
                    {
                        s.BackColor = Color.Red;
                    }
                }
            }

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.Name[3].ToString() == lines[30][0].ToString())
                {
                    s.Enabled = true;
                }
            }
        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            List<string> linesToWrite = new List<string>();
            for (int rowIndex = 0; rowIndex < 10; rowIndex++)
            {
                StringBuilder line = new StringBuilder();
                for (int colIndex = 0; colIndex < 10; colIndex++)
                    line.Append(rightBoard.GetCellStatus(rowIndex, colIndex));
                linesToWrite.Add(line.ToString());
            }

            for (int rowIndex = 0; rowIndex < 10; rowIndex++)
            {
                StringBuilder line = new StringBuilder();
                for (int colIndex = 0; colIndex < 10; colIndex++)
                    line.Append(leftBoard.GetCellStatus(rowIndex, colIndex));
                linesToWrite.Add(line.ToString());
            }

            foreach (Ship ship in ships) //will not work unless ships are loaded.
            {
                StringBuilder line = new StringBuilder();
                for (int i = 0; i < 5; i++)
                    line.Append(ship.GetStats()[i].ToString());
                linesToWrite.Add(line.ToString());
            }

            if (btnL00.Enabled)
                linesToWrite.Add("L");

            if (btnR00.Enabled)
                linesToWrite.Add("R");

            System.IO.File.WriteAllLines("C:\\Users\\macropower\\Documents\\test.txt", linesToWrite.ToArray());
        }
    }
}
