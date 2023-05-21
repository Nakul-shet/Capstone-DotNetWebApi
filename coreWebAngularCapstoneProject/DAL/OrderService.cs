using coreWebAngularCapstoneProject.Models;

namespace coreWebAngularCapstoneProject.DAL
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDBContext _context;

        public OrderService(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<int> CreateNewOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
