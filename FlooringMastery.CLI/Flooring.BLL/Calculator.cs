using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class Calculator
    {
        public static decimal CalculateMaterialCost(Order order)
        {
            decimal materialCost = order.Area * order.CostPerSqFt;
            return materialCost;
        }

        public static decimal CalculateLaborcost(Order order)
        {
            decimal laborCost = order.Area * order.LaborCostPerSqFt;
            return laborCost;
        }

        public static decimal CalculateTax(Order order)
        {
            decimal preTotal = order.MaterialCost + order.LaborCost;
            decimal tax = preTotal * order.TaxRate;
            return tax;
        }

        public static decimal CalculateTotal(Order order)
        {
            decimal total = order.MaterialCost + order.LaborCost + order.Tax;
            return total;
        }
    }
}
