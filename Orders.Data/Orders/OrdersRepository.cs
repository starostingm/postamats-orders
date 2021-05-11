using Orders.Data.Orders.Interfaces;
using Orders.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Data.Orders
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly List<Order> _orders = new List<Order>();

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public Order Get(int orderNumber)
        {
            return _orders.FirstOrDefault(order => order.OrderNumber == orderNumber);
        }

        public void Remove(int orderNumber)
        {
            var order = _orders.FirstOrDefault(order => order.OrderNumber == orderNumber);
            if (order != null)
                _orders.Remove(order);
        }
    }
}
