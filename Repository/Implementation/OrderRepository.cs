using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        
        
        
        public IEnumerable<Order> GetAll()
        {
            return entities.AsEnumerable();
        }

        public Order Get(string id)
        {
            return entities
                .Include(z => z.TicketInOrders)
                .Include("TicketInOrders.TicketId")
                .Include("TicketInOrders.OrderedTicket")
                .Include("TicketInOrders.OrderId")
                .Include("TicketInOrders.UserOrder")
                .SingleOrDefault(z => z.UserId.Equals(id));
        }

        public void Insert(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}