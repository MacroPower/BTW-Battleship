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
        private Ship twoPlace; //create in Add method.
        //etc

        public Board()
        {
            // 0 = no info
            // 1 = unhit ship

            // 2 = miss
            // 3 = hit ship

            for (int col = 1; col <= 10; col++)
            {
                for (int row = 1; row <= 10; row++)
                {
                    array[col, row] = 0;
                } // 0 = no info
            }
        }

        public int GetCellStatus(int x, int y)
        {
            return array[x,y];
        }

        public void AddShip(Ship ship)
        {
            int [] coords = ship.GetCoords();
            //x,y - x,y
            //loop to determine all coords
            //loop to write all values to array
        }

        public void Shot(int x, int y)
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
                //check for ship
                bool isDestroyed = shipx.Hit();
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
            
        }
    }
}
