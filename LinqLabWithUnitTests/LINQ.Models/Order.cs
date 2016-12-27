using System;

namespace Linq.Models
{
    [Serializable]
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public override bool Equals(object obj)
        {
            Order other = obj as Order;

            if (other != null)
            {
                return OrderID == other.OrderID
                    && OrderDate == other.OrderDate
                    && Total == other.Total;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
