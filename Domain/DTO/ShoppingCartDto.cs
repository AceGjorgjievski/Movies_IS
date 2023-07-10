using System.Collections.Generic;
using Domain.DomainModels;

namespace Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }
        public float TotalPrice { get; set; }
    }
}