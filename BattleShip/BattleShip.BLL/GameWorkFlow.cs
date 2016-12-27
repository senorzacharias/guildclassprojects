using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL
{
    public class GameWorkFlow
    {
        private bool turnToggle = true;
        private Board playerOneBoard = new Board();
        private Board playerTwoBoard = new Board();
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }

        public Board GetOpponentBoard()
        {
            if (turnToggle == false)
            {
                return playerOneBoard;
            }
            else
            {
                return playerTwoBoard;
            }
        }
        public Board GetCurrentBoard()
        {
            if (turnToggle == true)
            {
                return playerOneBoard;
            }
            else
            {
                return playerTwoBoard;
            }
        }

        public string GetCurrentName()
        {
            if (turnToggle == true)
            {
                return PlayerOneName;
            }
            else
            {
                return PlayerTwoName;
            }
        }

        public void ChangeTurn()
        {
            turnToggle = !turnToggle;
        }
    }
}
