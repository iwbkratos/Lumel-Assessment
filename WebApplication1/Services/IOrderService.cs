using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public interface IOrderService
    {
        public Task<bool> AddOrder(List<AddOrder> order);
    }
    public class OrderService : IOrderService
    {
        public IOrderRepository _orderRepository { get; set; }
        public ICommonRespository _commonRespository { get; set; }
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> AddOrder(List<AddOrder> orders)
        {
            try
            {
                bool isSuccess = true;
                foreach (var order in orders)
                {
                    var product = await _commonRespository.GetProduct(order.ProductId);
                    var customer = await _commonRespository.GetCustomer(order.CustomerId);
                    var payment = await _commonRespository.GetPayment(order.PaymentId);

                    if (product == null)
                        throw new Exception("product not found");
                    if (customer == null)
                        throw new Exception("customer not found");
                    if (payment == null)
                        throw new Exception("payment not found");

                    var AddOrder = new Order
                    {
                        OrderName = order.OrderName,
                        Product = product,
                        Customer = customer,
                        Payment = payment
                    };
                    var result = await _orderRepository.AddOrder(AddOrder);
                    if(result != 1)
                        isSuccess = false;

                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception();
            }
          
           
        }
    }
}
