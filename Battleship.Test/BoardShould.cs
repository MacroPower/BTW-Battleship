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

        [TestMethod]
        public void ReadMissOnEmptyBoard()
        {
            Board test = new Board();

            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 10; x++)
                    Assert.AreEqual(test.Shot(x, y), 2);
        }

        [TestMethod]
        public void PlaceValidShip()
        {
            Board test = new Board();
            Ship testShip = new Ship(4, 0, 0, 0, 3);
            test.AddShip(testShip);
            Assert.AreEqual(test.GetCellStatus(0,0), 1);
        }

        [TestMethod]
        public void ShowAHit()
        {
            Board test = new Board();
            Ship testShip = new Ship(4, 0, 0, 0, 3);
            test.AddShip(testShip);
            Assert.AreEqual(test.Shot(0, 0), 3);
        }

        [TestMethod]
        public void ShowAMiss()
        {
            Board test = new Board();
            Ship testShip = new Ship(4, 0, 0, 0, 3);
            test.AddShip(testShip);
            Assert.AreEqual(test.Shot(1, 1), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Not a valid ship placement.")]
        public void ThrowOnInvalidPlacement()
        {
            Board test = new Board();
            test.Shot(6, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "Already fired at these coordinates.")]
        public void ThrowOnRedundantShot()
        {
            Board test = new Board();
            test.Shot(6, 6);
            test.Shot(6, 6);
        }

        [TestMethod]
        public void GiveWinWhenAllShipsDestroyed()
        { //this also covers DestroyFullyHitShip()
            Board test = new Board();
            Ship testShip = new Ship(4, 0, 0, 0, 3);
            test.AddShip(testShip);
            test.Shot(0, 0);
            test.Shot(0, 1);
            test.Shot(0, 2);
            test.Shot(0, 3);
            Assert.AreEqual(test.ShipHealths()[0], 0);
        }
    }
}
