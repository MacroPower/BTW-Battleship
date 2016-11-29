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
        public void CreateEmptyCell()
        {
            Cell test = new Cell();
        }

        [TestMethod]
        public void ReadMissOnEmptyBoard()
        {
            Board.Shot(6,6);
            Assert.AreEqual(false);
        }

        [TestMethod]
        public void PlaceValidShip()
        {
            Ship test = new Ship();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Can't start without placing all ships.")]
        public void ThrowIfStartedWithoutFullTeam()
        {
            Ship test1 = new Ship(4,2,2,6,2);
            Ship test2 = new Ship(3,2,3,4,3);
            Ship test3 = new Ship(2,2,4,2,5);
            //not a full team
            Assert.AreEqual(false); //"Place all ships before starting.")
        }

        [TestMethod]
        public void ShowAHit()
        {
            Ship test1 = new Ship(4, 2, 2, 6, 2);
            Board.Shot(2,2);
            Assert.AreEqual(true);
        }
        //show miss
        [TestMethod]
        public void ShowAMiss()
        {
            Ship test1 = new Ship(4, 2, 2, 6, 2);
            Board.Shot(6, 6);
            Assert.AreEqual(false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Not a valid ship placement.")]
        public void ThrowOnInvalidPlacement()
        {
            Board.Shot(6, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Already fired at these coordinates.")]
        public void ThrowOnRedundantShot()
        {
            Board.Shot(6, 6);
            Board.Shot(6, 6);
        }

        [TestMethod]
        public void GiveWinWhenAllShipsDestroyed()
        {
            Ship test1 = new Ship(4, 2, 2, 5, 2);
            Board.Shot(2, 2);
            Board.Shot(3, 2);
            Board.Shot(4, 2);
            Board.Shot(5, 2);

            Ship test1 = new Ship(3, 2, 3, 4, 3);
            Board.Shot(2, 3);
            Board.Shot(3, 3);
            Board.Shot(4, 3);

            Ship test1 = new Ship(3, 2, 4, 4, 4);
            Board.Shot(2, 4);
            Board.Shot(3, 4);
            Board.Shot(4, 4);

            Ship test1 = new Ship(2, 9, 10, 10, 10);
            Board.Shot(9, 10);
            Board.Shot(10, 10);

            Ship test1 = new Ship(5, 2, 6, 6, 6);
            Board.Shot(2, 6);
            Board.Shot(3, 6);
            Board.Shot(4, 6);
            Board.Shot(5, 6);
            Board.Shot(6, 6);

            Assert.AreEqual(true);
        }

        [TestMethod]
        public void DestroyFullyHitShip()
        {
            Ship test1 = new Ship(4, 2, 2, 6, 2);
            Board.Shot(2, 2);
            Board.Shot(3, 2);
            Board.Shot(4, 2);
            Board.Shot(5, 2);
            Assert.AreEqual(true);
        }
    }
}
