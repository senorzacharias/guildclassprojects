using BattleShip.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Tests
{
    [TestFixture]
    class CoordinateTranslationTest
    {

        [TestCase("a", true)]
        [TestCase("z", false)]
        [TestCase("A", true)]
        [TestCase("", false)]
        [TestCase("1", false)]
        [TestCase(null, false)]
        [TestCase("asdf", false)]
        [TestCase(" ", false)]
        [TestCase("0", false)]
        [TestCase("-1", false)]

        
        
        public void CheckCoordinateTranslation(string input, bool expected)
        {
            UIController uiController = new UIController();           
            bool actual = uiController.CheckY(input);
            Assert.AreEqual(expected, actual);

        }
    }
}
