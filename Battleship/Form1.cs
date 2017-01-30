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
        private bool turn; //true = left, false = right

        public Form1()
        {
            InitializeComponent();
        }

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

            // Switch board

            UpdateBoard();

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.Name[3].ToString() == "C") continue;
                if (turn && s.Name[3].ToString() == "L")
                {
                    s.Enabled = false;
                }
                else if (!turn && s.Name[3].ToString() == "R")
                {
                    s.Enabled = false;
                }
            }
            turn = !turn;

            UpdateScore();

            //check for win
            if (currentBoard.Win())
            {
                MessageBox.Show("Player " + button.Name[3].ToString() + " won.");

                for (int i = 0; i < 5; i++)
                    Console.WriteLine("Win: " + leftBoard.ShipHealths()[i].ToString());

                for (int i = 0; i < 5; i++)
                    Console.WriteLine("Win: " + rightBoard.ShipHealths()[i].ToString());

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
            rightScore.Text = "0";
            leftScore.Text = "0";
        }

        
        private void UpdateScore()
        {
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
        }

        private void UpdateBoard()
        {
            // Update all buttons based on array.
            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.Name[3].ToString() == "R") // both these blocks are the same uuuuuuguggghghghhhhhh
                {
                    if (leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 0
                     || leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 1)
                    {
                        s.UseVisualStyleBackColor = true;
                        s.Enabled = true;
                    }
                    else if (leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 2)
                    {
                        s.BackColor = Color.White;
                        s.Enabled = false;
                    }
                    else if (leftBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 3)
                    {
                        s.BackColor = Color.Red;
                        s.Enabled = false;
                    }
                }
                else if (s.Name[3].ToString() == "L")
                {
                    if (rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 0
                     || rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 1)
                    {
                        s.UseVisualStyleBackColor = true;
                        s.Enabled = true;
                    }
                    else if (rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 2)
                    {
                        s.BackColor = Color.White;
                        s.Enabled = false;
                    }
                    else if (rightBoard.GetCellStatus(int.Parse(s.Name[4].ToString()), int.Parse(s.Name[5].ToString())) == 3)
                    {
                        s.BackColor = Color.Red;
                        s.Enabled = false;
                    }
                }
                // Else: Button is menu control.
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Reset();
            
            AddShipsForm addShipL = new AddShipsForm();
            AddShipsForm addShipR = new AddShipsForm();
            //these windows jump all over the place for no good reason. need to find a fix.

            leftBoard = new Board();
            rightBoard = new Board();
            
            for (int i = 5; i > 0; i--)
            {
                Ship ship = addShipL.GetNewShip(i);
                leftBoard.AddShip(ship);
            }

            for (int i = 5; i > 0; i--)
            {
                Ship ship = addShipR.GetNewShip(i);
                rightBoard.AddShip(ship);
            }

            foreach (Button s in this.Controls.OfType<Button>())
            {
                if (s.Name[3].ToString() == "L")
                {
                    s.Enabled = true;
                }
            }
            turn = true;
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = System.IO.File.ReadLines(Application.StartupPath + "\\savegame.txt").ToArray();
                // Always will be 10+10+5+5+1 lines.

                // Load the first 10 lines into an array for the right board.
                int[,] arrayR = new int[10, 10];
                for (int rowIndex = 0; rowIndex < 10; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < 10; colIndex++)
                        arrayR[rowIndex, colIndex] = int.Parse(lines[rowIndex][colIndex].ToString());
                }

                // Load the next 10 lines into an array for the left board.
                int[,] arrayL = new int[10, 10];
                for (int rowIndex = 0; rowIndex < 10; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < 10; colIndex++)
                        arrayL[rowIndex, colIndex] = int.Parse(lines[rowIndex + 10][colIndex].ToString());
                }

                // Recreate boards with arrays.
                leftBoard = new Board(arrayL);
                rightBoard = new Board(arrayR);

                // Add ship objects to left board.
                for (int i = 0; i < 5; i++)
                {
                    Ship ship = new Ship(true, int.Parse(lines[i + 20][0].ToString()), int.Parse(lines[i + 20][1].ToString()), int.Parse(lines[i + 20][2].ToString()), int.Parse(lines[i + 20][3].ToString()), int.Parse(lines[i + 20][4].ToString()));
                    Console.WriteLine("Load: " + int.Parse(lines[i + 20][0].ToString()));
                    leftBoard.AddShip(ship);
                }

                // Add ship objects to right board.
                for (int i = 0; i < 5; i++)
                {
                    Ship ship = new Ship(true, int.Parse(lines[i + 25][0].ToString()), int.Parse(lines[i + 25][1].ToString()), int.Parse(lines[i + 25][2].ToString()), int.Parse(lines[i + 25][3].ToString()), int.Parse(lines[i + 25][4].ToString()));
                    Console.WriteLine("Load: " + int.Parse(lines[i + 25][0].ToString()));
                    rightBoard.AddShip(ship);
                }

                Reset();

                UpdateBoard();

                // Set the turn correctly.
                foreach (Button s in this.Controls.OfType<Button>())
                {
                    if (s.Name[3].ToString() == "C")
                    {
                        s.UseVisualStyleBackColor = true;
                        s.Enabled = true;
                        continue; //kill meeeee
                    }
                    if (s.Name[3].ToString() != lines[30][0].ToString())
                        s.Enabled = false;
                }

                if (lines[30][0].ToString() == "L")
                    turn = true;
                else
                    turn = false;

                UpdateScore();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("No save file!");
                Reset();
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

            foreach (Ship ship in leftBoard.AllShips())
            {
                StringBuilder line = new StringBuilder();
                for (int i = 0; i < 5; i++)
                    line.Append(ship.GetStats()[i].ToString());
                linesToWrite.Add(line.ToString());
            }

            foreach (Ship ship in rightBoard.AllShips())
            {
                StringBuilder line = new StringBuilder();
                for (int i = 0; i < 5; i++)
                    line.Append(ship.GetStats()[i].ToString());
                linesToWrite.Add(line.ToString());
            }

            if (turn)
                linesToWrite.Add("L");

            if (!turn)
                linesToWrite.Add("R");

            System.IO.File.WriteAllLines(Application.StartupPath + "\\savegame.txt", linesToWrite.ToArray());
        }
        
    }
}
