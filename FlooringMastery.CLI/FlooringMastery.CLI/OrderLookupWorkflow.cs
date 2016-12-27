using Flooring.BLL;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI
{
    public class OrderLookupWorkflow
    {
        public void Execute()
        {
            
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an order");
            Console.WriteLine("--------------------------");            
            DateTime date = ConsoleIO.GetDate("Enter the order date as MM/DD/YYYY: ");
             

            OrderLookupResponse response = manager.LookupOrder(date);

            if (response.Success)
            {
                ConsoleIO.DisplayOrders(response.Orders);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
