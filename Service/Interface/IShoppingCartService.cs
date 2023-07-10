using System;
using Domain.DomainModels;
using Domain.DTO;

namespace Service.Interface
{
    public interface IShoppingCartService
    {
        public ShoppingCartDto getShoppingCartInfo(string userId);
        public TicketsInShoppingCart deleteTicketFromSoppingCart( Guid? ticketId, string userId);
        public Order CreateOrder(string userId);
    }
}