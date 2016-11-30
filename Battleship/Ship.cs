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

        public Ship(bool load, int size, int startX, int endX, int startY, int endY)
        {
            length = size;
            health = length;
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }


        public void Hit()
        {
            health--;
        }

        public int Health()
        {
            return health;
        }

        public string[] GetAllCells()
        {
            string[] intToWrite = new string[5];
            int i = 0;
            if (StartX == EndX)
            {
                for (int top = StartY; top <= EndY; top++)
                {
                    intToWrite[i] = StartX.ToString() + top.ToString();
                    //intToWrite[i] = (int.Parse(top.ToString() + StartX.ToString()));
                    i++;
                }
            }
            else if (StartY == EndY)
            {
                for (int top = StartX; top <= EndX; top++)
                {
                    intToWrite[i] = top.ToString() + StartY.ToString();
                    i++;
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            while (i < 5)
            {
                intToWrite[i] = "0";
                i++;
            }

            return intToWrite;
        }

        public int[] GetStats() //this needs to return health for save function, as board will use GetAllCells()
        {
            return new int[5] { health, StartX, EndX, StartY, EndY };
        }
    }
}
