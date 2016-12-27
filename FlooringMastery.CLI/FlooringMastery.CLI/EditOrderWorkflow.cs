using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.CLI
{
    class EditOrderWorkflow
    {
        public void Execute()
        {
            bool reEdit;
            IProductRepository product = new FileProductRepository(OrderManagerFactory.PRODUCT_PATH);
            OrderManager orderManager = OrderManagerFactory.Create();
            ITaxRepository taxRepo = new TaxRate();
            DateTime date;
            Order order;
            do
            {
                Console.Clear();
                Console.WriteLine("---------------Edit Order-------------------");
                Console.WriteLine();

                date = ConsoleIO.GetDate("Please enter Order date (MM/dd/yyyy):");

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
                //or no orders/ display message
                List<Order> loadedOrders = responseLookup.Orders;

                order = loadedOrders.FirstOrDefault(i => i.OrderNumber == orderNumber);


                ///////Need to pass over input if Enter is pressed
                Console.WriteLine("===== If you do not wish to edit a field, press Enter. =====");
                Console.WriteLine();


                Console.WriteLine($"New Name ({order.Name}):");                
                string name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    order.Name = name;
                }



                Console.WriteLine($"New State Abbreviation ({order.State}):");                
                string state = Console.ReadLine();
                if (!string.IsNullOrEmpty(state))
                {
                    order.State = (State)Enum.Parse(typeof(State), state);
                }              
                
                    var taxRate = taxRepo.GetTaxRate(order.State);
                order.TaxRate = taxRate;

                Console.WriteLine($" New Product Type ({order.Product.ProductType}):");

                string type = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(type))
                {
                    if (type == "LAMINATE")
                    {
                        order.Product.ProductType = ProductType.Laminate;
                    }
                    else if (type == "WOOD")
                    {
                        order.Product.ProductType = ProductType.Wood;
                    }
                    else if (type == "TILE")
                    {
                        order.Product.ProductType = ProductType.Tile;
                    }
                    else if (type == "CARPET")
                    {
                        order.Product.ProductType = ProductType.Carpet;
                    }
                }

                //Not working/////////////////////////////////////////////////
                order.Area = ConsoleIO.GetNewArea($"New Area ({order.Area}):");
                

                order.OrderDate = date;
                order.CostPerSqFt = product.GetProduct(order.Product.ProductType).CostPerSqFt;
                order.LaborCostPerSqFt = product.GetProduct(order.Product.ProductType).LaborCostPerSqFt;
                order.LaborCost = Calculator.CalculateLaborcost(order);
                order.MaterialCost = Calculator.CalculateMaterialCost(order);
                order.Tax = Calculator.CalculateTax(order);
                order.Total = Calculator.CalculateTotal(order);


                Console.WriteLine("--------------------------------------------------");
                string validate = ConsoleIO.GetYesOrNo("Is this information correct? Y/N:");

                

                reEdit = validate == "N";
            } while (reEdit);//refactor without using do while loop--they are currently stuck in the loop unless info is correct


            OrderEditResponse response = orderManager.OrderEdit(order);

            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(order);
            }
            else
            {
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }

}









