using Orders.BusinessLogic.Services.Orders.Exceptions;
using Orders.BusinessLogic.Services.Orders.Interfaces;
using Orders.BusinessLogic.Services.Orders.Models;
using Orders.BusinessLogic.Validators.PhoneNumberValidator.Interfaces;
using Orders.BusinessLogic.Validators.PostamatNumberValidator.Interfaces;
using Orders.Data.Orders.Interfaces;
using Orders.Data.Postamats.Interfaces;
using Orders.Domain.Models;

namespace Orders.BusinessLogic.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IPostamatsRepository _postamatsRepository;
        private readonly IPhoneNumberValidator _phoneNumberValidator;
        private readonly IPostamatNumberValidator _postamatNumberValidator;

        public OrdersService(
            IOrdersRepository ordersRepository,
            IPostamatsRepository postamatsRepository,
            IPhoneNumberValidator phoneNumberValidator,
            IPostamatNumberValidator postamatNumberValidator
            )
        {
            _ordersRepository = ordersRepository;
            _postamatsRepository = postamatsRepository;
            _phoneNumberValidator = phoneNumberValidator;
            _postamatNumberValidator = postamatNumberValidator;
        }

        public void CancelOrder(int orderNumber)
        {
            _ordersRepository.Remove(orderNumber);
        }

        public void CreateOrder(CreateOrderRequest orderDto)
        {
            ValidatePhoneNumber(orderDto.ReceiverPhoneNumber);
            ValidatePostamatNumber(orderDto.PostamatNumber);
            ValidateGoods(orderDto.Goods);

            var order = new Order(orderDto.PostamatNumber)
            {
                Goods = orderDto.Goods,
                OrderNumber = orderDto.OrderNumber,
                Price = orderDto.Price,
                ReceiverFullName = orderDto.ReceiverFullName,
                ReceiverPhoneNumber = orderDto.ReceiverPhoneNumber
            };
            _ordersRepository.Add(order);
        }

        public Order GetOrder(int orderNumber)
        {
            return _ordersRepository.Get(orderNumber);
        }

        public void UpdateOrder(UpdateOrderRequest orderDto)
        {
            ValidatePhoneNumber(orderDto.ReceiverPhoneNumber);
            ValidateGoods(orderDto.Goods);

            var order = _ordersRepository.Get(orderDto.OrderNumber);
            if (order == null)
                throw new OrderNotFoundException();

            order.Goods = orderDto.Goods;
            order.Price = orderDto.Price;
            order.ReceiverFullName = orderDto.ReceiverFullName;
            order.ReceiverPhoneNumber = orderDto.ReceiverPhoneNumber;
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            if (!_phoneNumberValidator.IsValid(phoneNumber))
                throw new InvalidPhoneNumberException();
        }

        private void ValidatePostamatNumber(string postamatNumber)
        {
            if (!_postamatNumberValidator.IsValid(postamatNumber))
                throw new InvalidPostamatNumberException();

            var postamat = _postamatsRepository.Get(postamatNumber);
            if (postamat == null)
                throw new PostamatNotFoundException();
            if (postamat.IsActual == false)
                throw new InvalidPostamatException();
        }

        private void ValidateGoods(string[] goods)
        {
            if (goods.Length > 10)
                throw new TooMuchGoodsException();
        }
    }
}
