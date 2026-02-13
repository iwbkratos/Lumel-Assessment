namespace WebApplication1.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int RegionId { get; set; }
        public Region region { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
