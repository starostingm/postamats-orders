namespace Orders.BusinessLogic.Services.Orders.Models
{
    public class UpdateOrderRequest
    {
        public int OrderNumber { get; set; }
        public string[] Goods { get; set; }
        public decimal Price { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
    }
}
