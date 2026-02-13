using WebApplication1.Entities;
using WebApplication1.DbContext;
namespace WebApplication1.Repositories
{
    public interface IOrderRepository
    {
        public Task<int> AddOrder(Order order);
        
    }

    public class OrderRepository(AppDbContext _appDbContext) : IOrderRepository
    {
        public async Task<int> AddOrder(Order order)
        {
          var res =await _appDbContext.Orders.AddAsync(order);
            if (res == null)
                return 1;
            return 0;    
        }
    }
}
