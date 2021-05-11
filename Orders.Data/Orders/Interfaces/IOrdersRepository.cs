using Orders.Domain.Models;

namespace Orders.Data.Orders.Interfaces
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        Order Get(int orderNumber);
        void Remove(int orderNumber);
    }
}
