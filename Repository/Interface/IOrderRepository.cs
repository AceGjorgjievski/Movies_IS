using System.Collections.Generic;
using Domain.DomainModels;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(string id);
        void Insert(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}