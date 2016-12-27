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
    class AddOrderWorkflow
    {

        public void Execute()
        {
            bool reEdit;
            Order newOrder = new Order();
            IProductRepository product = new FileProductRepository(OrderManagerFactory.PRODUCT_PATH);
            OrderManager orderManager = OrderManagerFactory.Create();

            ITaxRepository taxRepo = new TaxRate();
            do
            {
                Console.Clear();



                Console.WriteLine("---------------Submit New Order-------------------");
                Console.WriteLine();
                DateTime date = ConsoleIO.GetDate("Please enter today's date (MM/dd/yyyy):");
                newOrder.OrderDate = date;
                newOrder.Name = ConsoleIO.GetString("Please enter Name:");
                string state = ConsoleIO.GetString("Please enter State Abbreviation (MN):");
                var stateEnum = (State)Enum.Parse(typeof(State), state);
                newOrder.State = stateEnum;
                var taxRate = taxRepo.GetTaxRate(newOrder.State);
                newOrder.TaxRate = taxRate;
                var newProductType = ConsoleIO.GetProductType("Please enter Product Type:");
                newOrder.Product = product.GetProduct(newProductType);
                int area = ConsoleIO.GetInteger("Please enter Area:");
                newOrder.Area = area;
                Console.WriteLine("--------------------------------------------------");
                string validate = ConsoleIO.GetYesOrNo("Is this information correct? Y/N:");

                 

                newOrder.CostPerSqFt = product.GetProduct(newProductType).CostPerSqFt;
                newOrder.LaborCostPerSqFt = product.GetProduct(newProductType).LaborCostPerSqFt;
                newOrder.LaborCost = Calculator.CalculateLaborcost(newOrder);
                newOrder.MaterialCost = Calculator.CalculateMaterialCost(newOrder);
                newOrder.Tax = Calculator.CalculateTax(newOrder);
                newOrder.Total = Calculator.CalculateTotal(newOrder);



                reEdit = validate == "N";
            } while (reEdit);

            OrderAddResponse response = orderManager.OrderAdd(newOrder);



            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
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



