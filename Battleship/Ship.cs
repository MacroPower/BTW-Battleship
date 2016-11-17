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
        private int start1;
        private int start2;
        private int end1;
        private int end2;
        


        public Ship(int size, int startX, int endX, int startY, int endY)
        {
            length = size;
            health = size;
            start1 = startX;
            start2 = startY;
            end1 = endX;
            end2 = endY;
        }

        public bool Hit()
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
            return new int[4] { start1, start2, end1, end2 };
        }



    }
}
