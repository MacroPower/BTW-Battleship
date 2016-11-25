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
            int[] coords = ship.GetCoords();
            //x,y - x,y
            int xStart = coords[0];
            int xEnd = coords[1];
            int yStart = coords[2];
            int yEnd = coords[3];
            //loop to determine all coords
            //loop to write all values to array
            if (xStart == xEnd)
            {
                for (int top = yStart; top <= yEnd; top++)
                {
                    array[xStart, top] = 1;
                }
            }
            else if (yStart == yEnd)
            {
                for (int top = xStart; top <= xEnd; top++)
                {
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
    }
}
