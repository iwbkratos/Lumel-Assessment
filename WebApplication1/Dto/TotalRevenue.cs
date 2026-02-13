namespace WebApplication1.Dto
{
    public class TotalRevenue
    {
        public required DateTime fromDate { get; set; }
        public required DateTime toDate { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? RegionId { get; set; }

    }
}
