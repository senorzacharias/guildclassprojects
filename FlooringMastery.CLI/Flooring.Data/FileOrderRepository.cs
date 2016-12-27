using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using System.IO;

namespace Flooring.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        public string FILE_PATH = @"C: \Users\apprentice\Desktop\Repos\bitbucket\zach-robinson-individual-work\FlooringMastery.CLI\SystemIO\";
        private string _filePath;
        public string fullPath;
        private IProductRepository _product;        
        public string header = "OrderNumber, Name, State, TaxRate, ProductType, Area, CostPerSqFt, MaterialCost, LaborCostPerSqFt, LaborCost, Tax, Total";

        public FileOrderRepository(string filepath, IProductRepository product)
        {
            _filePath = filepath;
            _product = product;
            
        }
        public List<Order> LoadOrders(DateTime date)
        {

            List<Order> allOrders = new List<Order>();
            string fileName = string.Format("Orders_{0:MMddyyyy}.txt", date);
            fullPath = Path.Combine(_filePath, fileName);
           
            if (File.Exists(fullPath))
            {

                using (StreamReader sr = new StreamReader(fullPath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Order newOrder = new Order();
                        string[] columns = line.Split(',');


                        newOrder.OrderDate = date;
                        newOrder.OrderNumber = int.Parse(columns[0]);
                        newOrder.Name = columns[1];
                        newOrder.State = (State)Enum.Parse(typeof(State), columns[2]);
                        newOrder.TaxRate = decimal.Parse(columns[3]);
                        var newEnum = (ProductType)Enum.Parse(typeof(ProductType), columns[4]);
                        newOrder.Product = _product.GetProduct(newEnum);
                        newOrder.Area = decimal.Parse(columns[5]);
                        newOrder.CostPerSqFt = decimal.Parse(columns[6]);
                        newOrder.MaterialCost = decimal.Parse(columns[7]);
                        newOrder.LaborCostPerSqFt = decimal.Parse(columns[8]);
                        newOrder.LaborCost = decimal.Parse(columns[9]);
                        newOrder.Tax = decimal.Parse(columns[10]);
                        newOrder.Total = decimal.Parse(columns[11]);


                        allOrders.Add(newOrder);
                    }
                }
            }
            return allOrders;
        }

        public void AddOrder(Order order)
        {
            string fileName = string.Format("Orders_{0:MMddyyyy}.txt", order.OrderDate);
            string fullPath = string.Format("{0}{1}", FILE_PATH, fileName);
            List<Order> allOrders = new List<Order>();
            List<Order> loadedOrders = LoadOrders(order.OrderDate);

            if (File.Exists(fullPath))
            {
                order.OrderNumber = loadedOrders.Count+1;
            }
            else
            {
                order.OrderNumber = 1;
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    sw.WriteLine("OrderNumber, Name, State, TaxRate, ProductType, Area, CostPerSqFt, MaterialCost, LaborCostPerSqFt, LaborCost, Tax, Total");
                }

            }

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {

                string line = CreateOrderFormat(order);

                sw.WriteLine(line);
            }
            allOrders.Add(order);






        }

        public void EditOrder(Order order)//Working, but printing the original list 2x after editing
        {
            string fileName = string.Format("Orders_{0:MMddyyyy}.txt", order.OrderDate);
            string fullPath = string.Format("{0}{1}", FILE_PATH, fileName);

            List<Order> loadedOrders = LoadOrders(order.OrderDate);

            
            var selectedOrder = loadedOrders.FirstOrDefault(i => i.OrderNumber == order.OrderNumber);
            selectedOrder = order;
            loadedOrders[order.OrderNumber - 1] = selectedOrder;

            if (selectedOrder != null)
            {
                CreateOrderFile(loadedOrders);
            }

        }


        public void RemoveOrder(Order order)//not removing//date not setting
        {
            string fileName = string.Format("Orders_{0:MMddyyyy}.txt", order.OrderDate);
            string fullPath = string.Format("{0}{1}", FILE_PATH, fileName);

            List<Order> loadedOrders = LoadOrders(order.OrderDate);
            var selectedOrder = loadedOrders.FirstOrDefault(i => i.OrderNumber == order.OrderNumber);
            loadedOrders.Remove(selectedOrder);

             CreateOrderFile(loadedOrders);
        }

        public void CreateOrderFile(List<Order> orders)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.WriteLine("OrderNumber, Name, State, TaxRate, ProductType, Area, CostPerSqFt, MaterialCost, LaborCostPerSqFt, LaborCost, Tax, Total");

                foreach (var order in orders)
                {
                    sw.WriteLine(CreateOrderFormat(order));
                }
            }
        }

        public string CreateOrderFormat(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.Name, order.State, order.TaxRate, order.Product.ProductType, order.Area,
                                                order.CostPerSqFt, order.MaterialCost, order.LaborCostPerSqFt, order.LaborCost, order.Tax, order.Total.ToString());

        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
