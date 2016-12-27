using Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private static readonly List<Product> allProducts = null;

        static ProductTestRepository()
        {
            allProducts = new List<Product>();
            allProducts.Add(new Product
            {
                ProductType = ProductType.Carpet,
                CostPerSqFt = 2.25M,
                LaborCostPerSqFt = 2.10M
            });
            allProducts.Add(new Product
            {
                ProductType = ProductType.Laminate,
                CostPerSqFt = 1.75M,
                LaborCostPerSqFt = 2.10M
            });
            allProducts.Add(new Product
            {
                ProductType = ProductType.Tile,
                CostPerSqFt = 3.50M,
                LaborCostPerSqFt = 4.15M,
            });
            allProducts.Add(new Product
            {
                ProductType = ProductType.Wood,
                CostPerSqFt = 5.15M,
                LaborCostPerSqFt = 4.75M
            });
        }

       

        public Product GetProduct(ProductType productType)
        {
            Product newProduct = null;

            foreach (var product in allProducts)
            {
                if(productType == product.ProductType)
                {
                    return product;
                }
            }
            return newProduct;       
        }
    }
}

