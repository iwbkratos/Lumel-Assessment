using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.Helper;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public interface IPaymentService
    {
        public Task<RevenueModel> GetRevernueByRange(TotalRevenue revenue);
       
    }

    public class PaymentService(IPaymentRepository _repository) : IPaymentService
    {
        public async Task<RevenueModel> GetRevernueByRange(TotalRevenue revenue)
        {

            try
            {
                var payments = await _repository.GetPayments(revenue.fromDate, revenue.toDate);

                if (payments == null)
                {
                    throw new Exception("No revenues at this range");
                }


                var sortedRevenue = new List<Payment>();

                if (revenue.ProductId != null)
                {
                    sortedRevenue = payments.Where(p => p.ProductId == revenue.ProductId).ToList();
                }
                else if (revenue.CategoryId != null)
                {
                    sortedRevenue = payments.Where(p => p.Product.Category.Id == revenue.CategoryId).ToList();
                }
                else if (revenue.RegionId != null)
                {
                    sortedRevenue = payments.Where(p => p.Customer.RegionId == revenue.RegionId).ToList();

                }


                var total = sortedRevenue.Where(p => p.PaymentType == "Recieved").Select(p => p.Amount).Sum();

                var res = new RevenueModel();

                res.ProductId = revenue.ProductId;
                res.RegionId = revenue.RegionId;
                res.CategoryId = revenue.CategoryId;
                res.TotalRevenue = total;

                return res;
            }
            catch
            (Exception ex)
            { 
              Console.WriteLine(ex.Message);
                throw new Exception("Something went wrong");
            }
        }
    }
}
