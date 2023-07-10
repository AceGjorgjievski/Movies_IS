using System.Collections.Generic;
using Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ShopApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserShoppingCart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}