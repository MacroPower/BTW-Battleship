using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        private int[,] array = new int[10, 10];
        private List<Ship> ships = new List<Ship>();

        public Board()
        {
            // 0 = no info
            // 1 = unhit ship

            // 2 = miss
            // 3 = hit ship

            for (int col = 0; col < 10; col++)
            {
                for (int row = 0; row < 10; row++)
                {
                    array[col, row] = 0;
                } // 0 = no info
            }
        }

        public Board(int[,]load)
        {
            array = load;
        }

        public int GetCellStatus(int x, int y)
        {
            return array[x,y];
        }

        public void AddShip(Ship ship)
        {
            ships.Add(ship);

            int[] coords = ship.GetStats();
            //x,y - x,y
            int xStart = coords[1];
            int xEnd = coords[2];
            int yStart = coords[3];
            int yEnd = coords[4];
            //loop to determine all coords
            //loop to write all values to array

            //can be replaced with GetAllCells();
            if (xStart == xEnd)
            {
                for (int top = yStart; top <= yEnd; top++)
                {
                    if (array[xStart, top] != 3)
                        array[xStart, top] = 1;
                }
            }
            else if (yStart == yEnd)
            {
                for (int top = xStart; top <= xEnd; top++)
                {
                    if (array[xStart, top] != 3)
                        array[top, yStart] = 1;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public int Shot(int x, int y)
        {
            int status = array[x, y];

            if (status > 1)
            {
                throw new NotImplementedException();
                //already a shot here.
            }
            else if (status == 1)
            {
                //hit
                array[x, y] = 3;
                foreach (Ship ship in ships)
                {
                    string[] cells = ship.GetAllCells();
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Cell: " + cells[i].ToString());

                        if (cells[i] == x.ToString() + y.ToString())
                        { //this is not selecting the correct ship.
                            ship.Hit();
                        }
                    }
                }
            }
            else if (status == 0)
            {
                //miss
                array[x, y] = 2;
            }
            else
            {
                Console.WriteLine("Out of range.");
                throw new NotImplementedException();
            }

            return GetCellStatus(x, y);
        }

        public bool Win()
        {
            //THIS IS ONLY FOR TESTING-------------
            //int totalHits = 0;

            //for (int col = 0; col < 10; col++)
            //{
            //    for (int row = 0; row < 10; row++)
            //    {
            //        if (array[col, row] == 3)
            //            totalHits++;
            //    }
            //}

            //if (totalHits == 5) //5+4+3+3+2=17. Setting to 5 for testing.
            //    return true;

            //return false;

            //REAL FUNCTION------------

            int[] hps = ShipHealths();

            for (int i = 0; i < 5; i++)
            {
                if (hps[i] > 0)
                    return false;
            }

            return true;
        }

        public int[] ShipHealths()
        {
            int[] healths = new int[5];
            int i = 0;
            foreach (Ship ship in ships)
            {
                healths[i] = ship.Health();
                i++;
            }
            return healths;
        }

        public List<Ship> AllShips()
        {
            return ships;
        }
    }
}
