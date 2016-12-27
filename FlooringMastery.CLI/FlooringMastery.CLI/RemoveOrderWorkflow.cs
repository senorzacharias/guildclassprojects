using Flooring.BLL;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI
{
    class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            OrderEditResponse editResponse = new OrderEditResponse();

            Console.Clear();
            Console.WriteLine("---------------Remove Order-------------------");
            Console.WriteLine();

            var date = ConsoleIO.GetDate("Please enter Order date (MM/dd/yyyy):");

            OrderLookupResponse responseLookup = orderManager.LookupOrder(date);
            if (responseLookup.Success == true)
            {
                ConsoleIO.DisplayOrders(responseLookup.Orders);
            }
            else
            {
                Console.WriteLine(responseLookup.Message);
                Console.ReadKey();
                Menu.Start();

            }

            var orderNumber = ConsoleIO.GetInteger("Please enter Order Number:");
            
            List<Order> loadedOrders = responseLookup.Orders;            
            var order = loadedOrders.FirstOrDefault(i => i.OrderNumber == orderNumber);
            ConsoleIO.DisplayOrderDetails(order);

            string answer = ConsoleIO.GetYesOrNo("Are you sure you want to remove this order? (Y/N");

            if(answer == "Y")
            {
                orderManager.OrderRemove(order);
                if(editResponse.Success == false)
                {
                    Console.WriteLine(editResponse.Message);
                }
                
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Remove cancelled. Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
