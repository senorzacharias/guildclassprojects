using System;

namespace BattleShip.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UIController uiController = new UIController();
            uiController.StartGame();
        }
    }
}
