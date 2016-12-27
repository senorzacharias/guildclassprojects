using System;

namespace Linq.Models
{
    [Serializable]
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public override bool Equals(object obj)
        {
            Product other = obj as Product;

            if (other != null)
            {
                return ProductID == other.ProductID
                    && Category == other.Category
                    && ProductName == other.ProductName
                    && UnitPrice == other.UnitPrice
                    && UnitsInStock == other.UnitsInStock;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
