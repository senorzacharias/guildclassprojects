using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleIO
    {
        public static void Display(string msg)
        {
            Console.WriteLine(msg);
        }
        public static string PromptMsg(string msg)
        {
            Display(msg);

            return Console.ReadLine();
        }
    }
}
