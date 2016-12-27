using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(DateTime date);        
        void AddOrder(Order order);
        void EditOrder(Order order);
        void RemoveOrder(Order order);
        
             

    }
}
