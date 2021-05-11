namespace Orders.Domain.Models
{
    public enum OrderStatus
    {
        Registered = 1,
        RecievedInWarehouse = 2,
        GivenToCourier = 3,
        LeftInPostamat = 4,
        DeliveredToCustomer = 5
    }
}
