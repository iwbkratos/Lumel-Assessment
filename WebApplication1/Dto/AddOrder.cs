using WebApplication1.Entities;

namespace WebApplication1.Dto
{
    public class AddOrder
    {
        public string OrderName { get; set; }
        public required int ProductId { get; set; }
        public required int CustomerId { get; set; }
        public required int PaymentId { get; set; }
    }
}
