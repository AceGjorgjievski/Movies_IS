using System.Collections.Generic;
using Domain.Identity;

namespace Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ShopApplicationUser User { get; set; }
        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
    }
}