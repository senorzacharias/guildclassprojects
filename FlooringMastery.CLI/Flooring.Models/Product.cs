namespace Flooring.Models
{
    public class Product
    {
        public ProductType ProductType { get; set; }
        public decimal CostPerSqFt { get; set; }
        public decimal LaborCostPerSqFt { get; set; }
    };
}