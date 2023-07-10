using System.Collections.Generic;

namespace Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        public string TicketName { get; set; }
        public string TicketDescription { get; set; }
        public string TicketImage { get; set; }
        public int TicketPrice { get; set; }
        public int TicketRating { get; set; }
        
        public ICollection<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }
        public IEnumerable<TicketInOrder> ProductInOrders { get; set; }
    }
}