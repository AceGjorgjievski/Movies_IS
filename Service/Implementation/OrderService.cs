using System.Collections.Generic;
using System.Linq;
using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAll()
        {
            return this._orderRepository.GetAll().ToList();
        }

        public List<Order> GetOrdersByUser(string userId)
        {
            return this._orderRepository.GetAll().Where(z => z.UserId.Equals(userId)).ToList();
        }
    }
}