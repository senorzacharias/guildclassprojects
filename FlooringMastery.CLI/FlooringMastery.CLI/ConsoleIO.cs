using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI
{
    class ConsoleIO
    {
        EditOrderWorkflow editWorkflow = new EditOrderWorkflow();
        

        

        

        public static int GetNewArea(string prompt)
        {
            do
            {
                Console.WriteLine(prompt);
                string area = Console.ReadLine();
                if (!string.IsNullOrEmpty(area))
                {

                    int newInt = 0;
                    if (int.TryParse(Console.ReadLine(), out newInt) && newInt > 0)
                    {
                        return newInt;
                    }
                    else//dont need?
                    {
                        continue;
                    }                  
                }
            } while (true);
        }
        public static DateTime GetDate(string prompt)
        {
            Console.WriteLine(prompt);

            do
            {
                DateTime date;
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    return date;
                }
                Console.Write("Please enter correct date format.");
            } while (true);
        }

        public static string GetYesOrNo(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue");
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue");
                        continue;
                    }
                }
                return input;
            }



        }

        public static int GetInteger(string prompt)
        {
            Console.WriteLine(prompt);

            do
            {
                int newInt;
                if (int.TryParse(Console.ReadLine(), out newInt))
                {
                    return newInt;
                }
                Console.WriteLine("Please enter valid integer.");
            } while (true);
        }

        public static void DisplayOrders(List<Order> orders)
        {
            foreach (var item in orders)
            {
                DisplayOrderDetails(item);
            }
        }


        public static string GetString(string prompt)
        {
            Console.Write(prompt);
            do
            {
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                Console.Write("Please enter information.");
            } while (true);
        }




        public static ProductType GetProductType(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string type = Console.ReadLine().ToUpper();
                if (type == "LAMINATE")
                {
                    return ProductType.Laminate;
                }
                else if (type == "WOOD")
                {
                    return ProductType.Wood;
                }
                else if (type == "TILE")
                {
                    return ProductType.Tile;
                }
                else if (type == "CARPET")
                {
                    return ProductType.Carpet;
                }
                else
                {
                    continue;
                }


            } while (true);
        }

        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"--------Order Results---------");
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Name: {order.Name}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}");
            Console.WriteLine($"Product Type: {order.Product.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost Per Sq Ft: {order.CostPerSqFt}");
            Console.WriteLine($"Labor Cost Per Sq Ft: {order.LaborCostPerSqFt}");
            Console.WriteLine($"Material Cost: {order.MaterialCost}");
            Console.WriteLine($"Labor Cost: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine($"--------------------------------");

        }
    }
}
