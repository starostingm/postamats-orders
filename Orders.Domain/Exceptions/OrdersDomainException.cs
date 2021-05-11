using System;

namespace Orders.Domain.Exceptions
{
    public class OrdersDomainException : Exception
    {
        public OrdersDomainException()
            : base() { }

        public OrdersDomainException(string message)
            : base(message) { }
    }
}
