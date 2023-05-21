using coreWebAngularCapstoneProject.Models;

namespace coreWebAngularCapstoneProject.DAL
{
    public interface IOrderService
    {
        public Task<int> CreateNewOrder(Order order);
    }
}
