namespace WebApplication1.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public string PaymentType { get; set; }= string.Empty;
        public double Amount { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
