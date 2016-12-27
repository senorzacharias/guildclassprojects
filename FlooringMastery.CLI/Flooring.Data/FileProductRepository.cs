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
    public class FileProductRepository : IProductRepository
    {
        readonly string _filePath;
        

        public FileProductRepository(string filePath)
        {
            _filePath = filePath;
            
        }
        
        public Product GetProduct(ProductType productType)
        {
            List<Product> allProducts = new List<Product>();

            using (StreamReader file = new StreamReader(_filePath))
            {
                file.ReadLine();
                string line;

                Product newProduct = new Product();
                while ((line = file.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    var newEnum = (ProductType)Enum.Parse(typeof(ProductType), columns[0]);

                    if (newEnum == productType)
                    {
                      
                        newProduct.ProductType = newEnum;
                        newProduct.CostPerSqFt = decimal.Parse(columns[1]);
                        newProduct.LaborCostPerSqFt = decimal.Parse(columns[2]);

                        allProducts.Add(newProduct);
                    }
                }
            
                return newProduct;
            }
        }

        
    }
}
