using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        public decimal TaxRate { get; set; }
        public Product Product { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSqFt { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCostPerSqFt { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public Order()
        {
            this.Product = new Product();
        }

        private void CalculateCost(Product product, decimal area, decimal tax)
        {
            MaterialCost = area * CostPerSqFt;
            LaborCostPerSqFt = area * LaborCostPerSqFt;
            decimal preTaxTotal = CostPerSqFt + LaborCostPerSqFt;
            decimal Total = preTaxTotal + (preTaxTotal * tax);
        }
        //create method for all calculations
        private void CalculateLaborCost(decimal area, decimal laborCostPerSqFt)
        {
            LaborCost = area * laborCostPerSqFt; 
        }
        private void CalculateMaterialCost(decimal area, decimal costPerSqFt)
        {
            MaterialCost = area * costPerSqFt;
        }
        private void CalculatePreTaxTotal(decimal laborCost, decimal materialCost)
        {
            decimal preTaxTotal = laborCost + materialCost;
        }
        private void CalculateTax()
        {
            throw new NotImplementedException();
        }

    }
}

