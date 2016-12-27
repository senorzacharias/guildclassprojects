using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI
{
    class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Orders Application");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Lookup an Order");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");

                
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        OrderLookupWorkflow lookupWorkFlow = new OrderLookupWorkflow();
                        lookupWorkFlow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow();
                        removeWorkflow.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("That is not a valid entry.");
                        Console.ReadKey();
                        
                        break;
                }

            }
        }
    }
}
