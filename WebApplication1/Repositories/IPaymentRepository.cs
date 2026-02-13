using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContext;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public interface IPaymentRepository
    {
        public Task<List<Payment>> GetPayments(DateTime from,DateTime to);
    }
    public class PaymentRepository(AppDbContext _context) : IPaymentRepository
    {
        public async Task<List<Payment>> GetPayments(DateTime from, DateTime to)
        {
           var result = await _context.Payments.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToListAsync();
            return result;
        }
    }
}
