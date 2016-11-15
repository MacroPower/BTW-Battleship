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
            //for col
            for (int i = 1; i <= 10; i++)
            {
               
                array[col, i] = 0;
            } // 0 = no info
        }

        public int GetCellStatus(int x, int y)
        {
            return array[x,y];
        }

        public void Shot ()
        {
            //need to set shots?
        }
    }
}
