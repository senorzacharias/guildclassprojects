using System;
using Flooring.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        public List<Order> allOrders;


        public OrderTestRepository()
        {
            allOrders = new List<Order>();


            allOrders.Add(order1);
            allOrders.Add(order2);
        }

        public Order order1 = new Order
        {
            OrderDate = new DateTime(2016, 10, 11),
            OrderNumber = 1,
            Name = "Bosephus",
            State = State.MN,
            TaxRate = .034M,
            Product = new Product
            {
                ProductType = ProductType.Carpet,
                CostPerSqFt = 2.25M,
                LaborCostPerSqFt = 2.10M

            },

            Area = 100,
            CostPerSqFt = 2.25M,
            MaterialCost = 500M,
            LaborCostPerSqFt = 2.10M,
            LaborCost = 200M,
            Tax = 42M,
            Total = 2300M
        };

        public Order order2 = new Order
        {
            OrderDate = new DateTime(2016, 10, 11),
            OrderNumber = 2,
            Name = "Prince",
            State = State.MN,
            TaxRate = .08M,
            Product = new Product
            {
                ProductType = ProductType.Wood,
                CostPerSqFt = 4.25M,
                LaborCostPerSqFt = 3.10M

            },
            Area = 200,
            CostPerSqFt = 5.15M,
            MaterialCost = 880M,
            LaborCost = 500M,
            Tax = 52M,
            Total = 5000M
        };

        public List<Order> LoadOrders(DateTime date)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in allOrders)
            {
                if (date == item.OrderDate)
                {
                    orders.Add(item);
                }
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            allOrders.Add(order);

        }

        public void EditOrder(Order order)
        {

            var selectedOrder = allOrders.FirstOrDefault(i => i.OrderNumber == order.OrderNumber);
            selectedOrder = order;
            allOrders[order.OrderNumber - 1] = selectedOrder;

        }

        public void RemoveOrder(Order order)
        {
            allOrders.Remove(order);
        }





    }
}


