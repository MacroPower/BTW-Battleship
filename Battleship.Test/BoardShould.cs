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

        }

        [TestMethod]
        public void PlaceValidShip()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Can't start without placing all ships.")]
        public void ThrowIfStartedWithoutFullTeam()
        {

        }

        [TestMethod]
        public void ShowAHit()
        {

        }

        [TestMethod]
        public void ShowAMiss()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Not a valid ship placement.")]
        public void ThrowOnInvalidPlacement()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Already fired at these coordinates.")]
        public void ThrowOnRedundantShot()
        {

        }

        [TestMethod]
        public void HideOpponentShipsAppropriately()
        {

        }

        [TestMethod]
        public void GiveWinWhenAllShipsDestroyed()
        {

        }

        [TestMethod]
        public void DestroyFullyHitShip()
        {

        }

        [TestMethod]
        public void SaveGameCorrectly()
        {

        }

        [TestMethod]
        public void LoadGameCorrectly()
        {

        }
    }
}
