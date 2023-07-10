using System.Collections.Generic;
using Domain.Identity;

namespace Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public ShopApplicationUser Owner { get; set; }
        public ICollection<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }
    }
}