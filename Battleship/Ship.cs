using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Ship
    {
        private int length;
        private int health;
        private int StartX;
        private int StartY;
        private int EndX;
        private int EndY;
        

        //size = health? perhaps we may want to change it to say health all the time.
        public Ship(int size, int startX, int endX, int startY, int endY)
        {
            if (size == 1 || size == 2)
                length = size + 1;
            else
                length = size;

            health = length;
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        public void Hit() //this cannot save with current config. need to redo one or the other.
        {
            health--;
        }

        public int Health()
        {
            return health;
        }

        public List<int> GetAllCells()
        {
            List<int> intToWrite = new List<int>();

            if (StartX == EndX)
            {
                for (int top = StartY; top <= EndY; top++)
                {
                    intToWrite.Add(int.Parse(top.ToString() + StartX.ToString()));
                }
            }
            else if (StartY == EndY)
            {
                for (int top = StartX; top <= EndX; top++) //same goes
                {
                    intToWrite.Add(int.Parse(StartY.ToString() + top.ToString()));
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            return intToWrite;
        }

        public int[] GetCoords() //this needs to return health and be renamed for save function, as board will use GetAllCells()
        {
            return new int[4] { StartX, EndX, StartY, EndY };
        }
    }
}
