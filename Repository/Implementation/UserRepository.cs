using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShopApplicationUser> entities;
        string errorMessage = string.Empty;
        
        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ShopApplicationUser>();
        }
        
        public IEnumerable<ShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ShopApplicationUser Get(string id)
        {
            return entities
                .Include(z => z.UserShoppingCart)
                .Include("UserShoppingCart.TicketsInShoppingCarts") // Updated navigation property name
                .Include("UserShoppingCart.TicketsInShoppingCarts.Ticket") // Updated navigation property name
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}