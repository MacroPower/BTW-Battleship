using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Cell
    {
        public Cell (int col, int row)
        {

        }

        public int CellStats()
        {
            if (hit)
                return 2;
            if (miss)
                return 1;
            //if none
                return 0;
        }
    }
}
