using System.Collections.Generic;
using Domain.DomainModels;

namespace Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetAll();
        List<Order> GetOrdersByUser(string userId);
    }
}