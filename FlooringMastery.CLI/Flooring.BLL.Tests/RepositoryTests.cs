using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Flooring.Models;
using Flooring.BLL;
using Flooring.Models.Responses;
using Flooring.Data;
using Flooring.Models.Interfaces;
using System.IO;

namespace Flooring.BLL.Tests
{



    [TestFixture]
    class RepositoryTests
    {
        public string originalData = @"C:\Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\FlooringMastery.CLI\SystemIO\OrderSeed.txt";
        
        DateTime date = new DateTime(2016, 10, 11);

        

        [Test]
        public void CanLoadOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrder(date);

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Orders.First().OrderNumber);
            
        
        }        

        [Test]
        public void DoesNotEqualIncorrectAmount()
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrder(date);

            Assert.AreNotEqual(6, response.Orders.Count());
            Assert.IsTrue(response.Success);
           

        }
                [TestCase("10/11/2016", 3,"Bosephus", State.MN, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]
                [TestCase("10/11/2016", 3, "Bosephus", State.MN, .034, ProductType.Laminate, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]
                [TestCase("10/11/2016", 3, "Bosephus", State.AK, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]
                [TestCase("10/11/2016", 4,"Benjamin Franklin", State.MN, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]
                [TestCase("10/11/2016", 4, "Bosephus", State.MN, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]

                [Test]
                public void CanAddOrderTest(string date, int orderNumber, string name, State state, decimal taxRate, ProductType product, decimal area, decimal costPerFt, decimal materialCost, decimal laborPerFt, decimal laborCost, decimal tax, decimal total, bool expected)
                {
                    var dateParse = DateTime.Parse(date);
                    OrderManager manager = OrderManagerFactory.Create();
                    Order newOrder = new Order();
                    OrderLookupResponse responseLookup = manager.LookupOrder(dateParse);

                    newOrder.OrderDate = dateParse;
                    newOrder.Name = name;
                    newOrder.State = state;
                    newOrder.TaxRate = taxRate;
                    newOrder.Product.ProductType = product;
                    newOrder.Area = area;
                    newOrder.CostPerSqFt = costPerFt;
                    newOrder.MaterialCost = materialCost;
                    newOrder.LaborCostPerSqFt = laborPerFt;
                    newOrder.LaborCost = laborCost;
                    newOrder.Tax = tax;
                    newOrder.Total = total;          

                    OrderAddResponse response = manager.OrderAdd(newOrder);

                    Assert.AreEqual(expected, response.Success);

                }

        [TestCase("10/11/2016", 1, "Bosephus", State.MN, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 2300, false)]
        [TestCase("10/11/2016", 1, "Bosephus", State.MN, .034, ProductType.Laminate, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]
        [TestCase("10/11/2016", 1, "Bosephus", State.AK, .034, ProductType.Carpet, 900, 2.25, 500, 2.10, 200, 42, 2300, true)]
        [TestCase("10/11/2016", 1, "Benjamin Franklin", State.MN, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 2300, true)]
        [TestCase("10/11/2016", 1, "Bosephus", State.MN, .034, ProductType.Carpet, 100, 2.25, 500, 2.10, 200, 42, 9999, false)]

        [Test]
        public void CanEditOrderTest(string date, int orderNumber, string name, State state, decimal taxRate, ProductType product, decimal area, decimal costPerFt, decimal materialCost, decimal laborPerFt, decimal laborCost, decimal tax, decimal total, bool expected)
        {
            var dateParse = DateTime.Parse(date);
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrder(dateParse);
            var orders = response.Orders;
            var original = orders.FirstOrDefault(i => i.OrderNumber == 1);
            var order = new Order();

            order.OrderDate = dateParse;
            order.OrderNumber = orderNumber;
            order.Name = name;
            order.State = state;
            order.TaxRate = taxRate;
            order.Product.ProductType = product;
            order.Area = area;
            order.CostPerSqFt = costPerFt;
            order.MaterialCost = materialCost;
            order.LaborCostPerSqFt = laborPerFt;
            order.LaborCost = laborCost;
            order.Tax = tax;
            order.Total = total;

           var orderEditResponse = manager.OrderEdit(order);            

            Assert.AreEqual(expected, orderEditResponse.Success);
            

        }

        [Test]
        public void CanDeleteOrderTest()
        {
            
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrder(date);
            
            var selected = response.Orders.FirstOrDefault(i => i.OrderNumber == 1);          
            
            var orderRemove = manager.OrderRemove(selected);            
            
            Assert.AreEqual(true, orderRemove.Success);

        }

    }
}








