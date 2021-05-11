using Orders.BusinessLogic.Services.Orders.Models;
using Orders.Domain.Models;

namespace Orders.BusinessLogic.Services.Orders.Interfaces
{
    public interface IOrdersService
    {
        void CreateOrder(CreateOrderRequest orderDto);
        void UpdateOrder(UpdateOrderRequest orderDto);
        Order GetOrder(int orderNumber);
        void CancelOrder(int orderNumber);
    }
}
