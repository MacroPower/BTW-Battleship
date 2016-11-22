using System;
using Battleship;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Test
{
    [TestClass]
    public class BoardShould
    {
        [TestMethod]
        public void CreateEmptyBoard()
        {
            Board test = new Board();
        }
    }
}
