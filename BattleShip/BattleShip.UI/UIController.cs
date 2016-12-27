using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using BattleShip.BLL.Ships;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    public class UIController
    {
        GameWorkFlow gameWorkFlow = new GameWorkFlow();
        
        public void StartGame()
        {   
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Would you like to play? Press any key to begin or 'n' to exit.");
            string play = Console.ReadLine();
            if (play != "n")
            {
                Console.WriteLine("Prepare for battle!");
                Console.ReadKey();
                GetPlayerNames();
                Setup();
                gameWorkFlow.ChangeTurn();
                Console.Clear();
                Setup();
                Console.Clear();
                gameWorkFlow.ChangeTurn();
                gameWorkFlow.GetOpponentBoard();
                Fight();
            }
            else
            {
                Console.WriteLine("Chicken! Bock bock bock!");
                Console.ReadKey();
            }
        }
        

        public void Fight()// (ShotStatus currentShot, FireShotResponse shotResponse)
        {
            var yInput = string.Empty;
            
            FireShotResponse response = new FireShotResponse();
            do
            {
                DrawShotHistory();
                int x = CheckX();
                do
                {
                    yInput = ConsoleIO.PromptMsg("Please enter a character a-j.");
                } while (!CheckY(yInput));
                int yConversion;
                yConversion = ConvertLetter(yInput);

                Coordinate shotFired = new Coordinate(x, yConversion);
                response = gameWorkFlow.GetOpponentBoard().FireShot(shotFired);

                if (response.ShotStatus == ShotStatus.Hit)
                {
                    Console.WriteLine("You Hit Something!");
                   ///return true;
                    Console.Beep();
                    gameWorkFlow.ChangeTurn();
                }
                else if (response.ShotStatus == ShotStatus.Miss)
                {
                    Console.WriteLine("Your projectile splashes into the ocean, you missed!");
                    gameWorkFlow.ChangeTurn();
                    //return true;
                }
                else if (response.ShotStatus == ShotStatus.Victory)
                {
                    Console.WriteLine("You have sunk all your opponent's ships, you win!");
                    //StartGame()
                }
                else if (response.ShotStatus == ShotStatus.HitAndSunk)
                {                    Console.WriteLine("You sank the {0}!", response.ShipImpacted);
                    gameWorkFlow.ChangeTurn();
                    //return true;
                    Console.Beep();
                    Console.Beep();
                }
                else if (response.ShotStatus == ShotStatus.Duplicate)
                {
                    Console.WriteLine("Duplicate Shot. Press any key to fire again.");
                    //return false
                    Console.ReadKey();
                    
                    
                    //else if ---invalid
                    
                }
                
                Console.Clear();
                
            } while (response.ShotStatus != ShotStatus.Victory);//DisplayFIreshotresponse(fireShotResponse.ShotStatus, fireShotResonse) == false);

            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.WriteLine("Victory! All Hail {0} The Beautiful.", gameWorkFlow.GetCurrentName());
            gameWorkFlow.ChangeTurn();
            gameWorkFlow.GetCurrentName();
            Console.WriteLine("To exile, {0} The Ignominious.", gameWorkFlow.GetCurrentName());
            Console.Clear();
            Console.WriteLine("Would you like to play again? Press 'y' to play or any key to exit.");
            string playAgain = Console.ReadLine();

            if (playAgain == "y")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadKey();
                return;
            }
        }

        public void GetPlayerNames()
        {
            gameWorkFlow.PlayerOneName = GetConsoleString("Please enter Player 1 name.");
            gameWorkFlow.PlayerTwoName = GetConsoleString("Please enter Player 2 name.");
            Console.WriteLine("Hello, {0}! Press any key to continue.", gameWorkFlow.GetCurrentName());
            Console.ReadLine();
            Console.WriteLine("Are you ready? Press any key to begin.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PLAYER 2: Make like a tree and leaf so that PLAYER 1 can commence placement of ships. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            DisplayBoard();
        }

        public string GetConsoleString(string prompt)
        {
            string result;
            do
            {            
                Console.WriteLine(prompt);
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }

        public void DrawShotHistory()
        {
            Console.WriteLine("{0}'s Shot Board", gameWorkFlow.GetCurrentName());
            Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}", "A", " B", " C", " D", " E", " F", " G", " H", " I", " J");

            for (int x = 1; x <= 10; x++)
            {
                Console.Write("{0}", x);
                for (int y = 1; y <= 10; y++)
                {
                    Coordinate shotCoordinate = new Coordinate(x, y);


                    if (gameWorkFlow.GetOpponentBoard().ShotHistory.ContainsKey(shotCoordinate))
                    {
                        {
                            if (gameWorkFlow.GetOpponentBoard().ShotHistory[shotCoordinate] == ShotHistory.Hit)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("[{0}]", "H ");
                                Console.ResetColor();

                            }
                            else if (gameWorkFlow.GetOpponentBoard().ShotHistory[shotCoordinate] == ShotHistory.Miss)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("[{0}]", "M ");
                                Console.ResetColor();
                            }
                            else if (gameWorkFlow.GetOpponentBoard().ShotHistory[shotCoordinate] == ShotHistory.Unknown)
                            {

                            }
                        }
                    }
                    else
                    {
                        Console.Write("[{0}{1}]", "-", "-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void DisplayBoard()
        {
            Console.WriteLine("{0}'s Board", gameWorkFlow.GetCurrentName());
            Console.WriteLine("   {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}", "A", " B", " C", " D", " E", " F", " G", " H", " I", " J");

            for (int x = 1; x <= 10; x++)
            {
                Console.Write("{0}", x);
                for (int y = 1; y <= 10; y++)
                {
                    Coordinate boardCoordinate = new Coordinate(x, y);

                    if (gameWorkFlow.GetCurrentBoard().CheckShipCoordinate(boardCoordinate) == true)
                    {
                        Console.Write("[{0}{1}]", "X", "X");
                    }
                    else
                    {
                        Console.Write("[{0}{1}]", "-", "-");
                    }
                }
                Console.WriteLine();
            }
        }

        public void Setup()
        {
            var yInput = "";
            Console.WriteLine("Let's place your ships, {0}.", gameWorkFlow.GetCurrentName());

            ShipType[] ships = new ShipType[] { ShipType.Destroyer, ShipType.Submarine, ShipType.Cruiser, ShipType.Battleship, ShipType.Carrier };
            for (int i = 0; i < 5; i++)
            {
                ShipPlacement result;
                do
                {
                    Console.WriteLine($"Placing {ships[i]}");
                    PlaceShipRequest newShip = new PlaceShipRequest();
                    int x = CheckX();
                    do
                    {
                        yInput = ConsoleIO.PromptMsg("Please enter a character a-j.");
                        //yInput = yInput.ToLower();
                    } while (!CheckY(yInput));

                    int yConversion;
                    yConversion = ConvertLetter(yInput);

                    newShip.Coordinate = new Coordinate(x, yConversion);
                    newShip.Direction = GetDirection();
                    newShip.ShipType = ships[i];

                    result = gameWorkFlow.GetCurrentBoard().PlaceShip(newShip);
                    if (result == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleIO.Display("The world is flat. Your ship fell off the end of the world. Try again.");
                    }
                    if (result == ShipPlacement.Overlap)
                    {
                        Console.WriteLine("Cannot Overlap");
                    }
                    DisplayBoard();

                } while (result != ShipPlacement.Ok);
            }
        }
        public int CheckX()
        {
            while (true)
            {
                string xInput;
                int xConversion;
                Console.WriteLine("Enter a number 1-10 for your X-coordinate");
                xInput = Console.ReadLine();
                if (int.TryParse(xInput, out xConversion))
                {
                    if (xConversion >= 1 && xConversion <= 10)
                    {
                        return xConversion;
                    }
                }
                else
                {
                    CheckX();
                }
            }
        }
        public bool CheckY(string yInput)
        {
            if (yInput != null)
            {
                yInput = yInput.ToLower();
                if (yInput == "a" || yInput == "b" || yInput == "c" || yInput == "d" || yInput == "e" || yInput == "f" || yInput == "g" || yInput == "h" || yInput == "i" || yInput == "j")
                {
                    return true;
                }
            }
            return false;
        }

        public ShipDirection GetDirection()
        {
            Console.WriteLine("In which direction would you like to place your ship?");
            Console.WriteLine("Please enter Up, Down, Left, or Right.");

            while (true)
            {
                string directionInput = Console.ReadLine();

                if (directionInput == "up")
                {
                    return ShipDirection.Up;
                }
                else if (directionInput == "down")
                {
                    return ShipDirection.Down;
                }
                else if (directionInput == "left")
                {
                    return ShipDirection.Left;
                }
                else if (directionInput == "right")
                {
                    return ShipDirection.Right;
                }
                Console.WriteLine("Please enter Up, Down, Left, or Right");
            }
        }

        public int ConvertLetter(string input)
        {


            if (input == "a")
            {
                return 1;
            }
            else if (input == "b")
            {
                return 2;
            }
            else if (input == "c")
            {
                return 3;
            }
            else if (input == "d")
            {
                return 4;
            }
            else if (input == "e")
            {
                return 5;
            }
            else if (input == "f")
            {
                return 6;
            }
            else if (input == "g")
            {
                return 7;
            }
            else if (input == "h")
            {
                return 8;
            }
            else if (input == "i")
            {
                return 9;
            }
            else if (input == "j")
            {
                return 10;
            }
            else
            {
                return 1;
            }
        }
    }
}




