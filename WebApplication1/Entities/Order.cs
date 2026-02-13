namespace WebApplication1.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}
