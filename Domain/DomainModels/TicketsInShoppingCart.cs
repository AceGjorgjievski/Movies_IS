using System;

namespace Domain.DomainModels
{
    public class TicketsInShoppingCart : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        
        public Guid CartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        
        public int Quantity { get; set; }
    }
}