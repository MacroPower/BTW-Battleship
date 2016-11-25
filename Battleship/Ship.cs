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
        


        public Ship(int size, int startX, int endX, int startY, int endY)
        {
            length = size;
            health = size;
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        public bool Hit() //this cannot save with current config. need to redo one or the other.
        {
            health--;
            if(health == 0)
            {
                return true;
            }
            
            return false;
        }

        public int[] GetCoords()
        {
            return new int[4] { StartX, EndX, StartY, EndY };
        }
    }
}
