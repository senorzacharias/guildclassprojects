using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public OrderLookupResponse LookupOrder(DateTime date)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Orders = _orderRepository.LoadOrders(date);

            if (response.Orders == null || response.Orders.Count < 1)
            {
                response.Success = false;
                response.Message = $"{date} contains no orders.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public OrderAddResponse OrderAdd(Order order)
        {
            OrderAddResponse response = new OrderAddResponse();

            var orders = LookupOrder(order.OrderDate);

            var selectedOrder = orders.Orders.FirstOrDefault(i => i.OrderNumber == order.OrderNumber);

            if (selectedOrder == null)
            {
                //check for valid entries
                _orderRepository.AddOrder(order);
            }


            if (_orderRepository.LoadOrders(order.OrderDate).Count <= orders.Orders.Count)

            {
                response.Success = false;
                response.Message = $" Order was not saved. Please try again.";

            }


            else
            {
                response.Success = true;
                response.Message = $"Order placement successful.";
            }

            response.Order = order;
            return response;
        }

        public OrderEditResponse OrderEdit(Order order)
        {
            OrderEditResponse response = new OrderEditResponse();

            response.Orders = _orderRepository.LoadOrders(order.OrderDate);
            var selectedOrder = response.Orders.FirstOrDefault(i => i.OrderNumber == order.OrderNumber);

            if (selectedOrder != null)
            {

                _orderRepository.EditOrder(order);


                if (selectedOrder.Area == order.Area && selectedOrder.Name == order.Name && selectedOrder.Product.ProductType == order.Product.ProductType && selectedOrder.State == order.State)
                {
                    response.Success = false;
                    response.Message = $"There was an error editing your order.";

                }
                else
                {
                    response.Success = true;
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"There was an error editing your order.";
            }

            return response;
        }

        public OrderRemoveResponse OrderRemove(Order order)
        {
            OrderRemoveResponse response = new OrderRemoveResponse();
            response.Orders = _orderRepository.LoadOrders(order.OrderDate);           
           

            if (response.Orders != null)
            {
                _orderRepository.RemoveOrder(order);
                
            }
            var secondCount = _orderRepository.LoadOrders(order.OrderDate);
            if ( response.Orders.Count() <= secondCount.Count)
            {
                response.Success = false;
                response.Message = $" Order was not removed. Please try again.";
            }
            else
            {
                response.Success = true;
                response.Message = $"Order placement successful.";
            }


            return response;

        }
    }
}
