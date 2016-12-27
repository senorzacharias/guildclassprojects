using System;
using System.Linq;

namespace Linq.Models
{
    [Serializable]
    public class Customer
    {
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public Order[] Orders { get; set; }

        public override bool Equals(object obj)
        {
            Customer other = obj as Customer;

            if (other != null)
            {
                bool customerSame =
                    CustomerID == other.CustomerID
                    && Address == other.Address
                    && City == other.City
                    && CompanyName == other.CompanyName
                    && Country == other.Country
                    && Fax == other.Fax
                    && Phone == other.Phone
                    && PostalCode == other.PostalCode
                    && Region == other.Region;

                bool ordersSame = true;

                Func<Order, int> byId = o => o.OrderID;

                var zippedOrders = Orders.OrderBy(byId).Zip(
                    other.Orders.OrderBy(byId),
                    (thisOrder, otherOrder) => new
                    {
                        ThisOrder = thisOrder,
                        OtherOrder = otherOrder
                    });

                foreach (var zippedPair in zippedOrders)
                {
                    if (!zippedPair.ThisOrder.Equals(zippedPair.OtherOrder))
                    {
                        ordersSame = false;
                        break;
                    }
                }

                return customerSame && ordersSame;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
