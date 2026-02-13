using WebApplication1.Entities;
using WebApplication1.DbContext;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Repositories
{
    public interface ICommonRespository
    {
        public  Task<Customer?> GetCustomer(int customerId);
        public  Task<Product?> GetProduct(int payementId);
        public  Task<Payment?> GetPayment(int productId);

    }

    public class CommonRepository(AppDbContext _db) : ICommonRespository
    {
        public async Task<Customer?> GetCustomer(int customerId)
        {
           var res =await   _db.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            return res;
        }

        public async Task<Payment?> GetPayment(int paymentId)
        {
            var res = await _db.Payments.FirstOrDefaultAsync(p => p.Id == paymentId);
            return res;
        }

        public async Task<Product?> GetProduct(int productId)
        {
           var res = await _db.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return res;
        }

    }
}
