using Orders.Domain.Exceptions;

namespace Orders.Domain.Models
{
    public class Order
    {
        public Order(string postamatNumber)
        {
            PostamatNumber = postamatNumber;
        }

        public int OrderNumber { get; set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Registered;
        public string[] Goods { get; set; }
        public decimal Price { get; set; }
        public string PostamatNumber { get; private set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverPhoneNumber { get; set; }

        public void SetStatusAsRecievedInWarehouse()
        {
            if (Status != OrderStatus.Registered)
                throw new OrdersDomainException();

            Status = OrderStatus.RecievedInWarehouse;
        }

        public void SetStatusAsGivenToCourier()
        {
            if (Status != OrderStatus.RecievedInWarehouse)
                throw new OrdersDomainException();

            Status = OrderStatus.GivenToCourier;
        }

        public void SetStatusAsLeftInPostamat()
        {
            if (Status != OrderStatus.GivenToCourier)
                throw new OrdersDomainException();

            Status = OrderStatus.LeftInPostamat;
        }

        public void SetStatusAsDeliveredToCustomer()
        {
            if (Status != OrderStatus.LeftInPostamat)
                throw new OrdersDomainException();

            Status = OrderStatus.DeliveredToCustomer;
        }
    }
}
