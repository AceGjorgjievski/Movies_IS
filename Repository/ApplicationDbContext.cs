using Domain.DomainModels;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Ticket> Tickets {get; set;}
        public virtual DbSet<ShoppingCart> ShoppingCarts {get; set;}
        public virtual DbSet<TicketsInShoppingCart> TicketsInShoppingCarts {get; set;}
        public virtual DbSet<TicketInOrder> TicketInOrders {get; set;}
        public virtual DbSet<ShopApplicationUser> ShopApplicationUsers { get; set; }
        public virtual DbSet<Order> Orders {get; set;}
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketsInShoppingCart>()
                .HasKey(c => new { c.CartId, c.TicketId });
            builder.Entity<TicketInOrder>()
                .HasKey(c => new { c.TicketId, c.OrderId });
            
            builder.Entity<Ticket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();
            
            
            builder.Entity<TicketsInShoppingCart>()
                .HasOne(z => z.Ticket)
                .WithMany(z => z.TicketsInShoppingCarts)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketsInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.TicketsInShoppingCarts)
                .HasForeignKey(z => z.CartId);
            
            builder.Entity<ShoppingCart>()
                .HasOne<ShopApplicationUser>(u => u.Owner)
                .WithOne(c => c.UserShoppingCart)
                .HasForeignKey<ShoppingCart>(c => c.OwnerId);
            
            
            builder.Entity<TicketInOrder>()
                .HasKey(z => new {z.TicketId, z.OrderId});

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.OrderedTicket)
                .WithMany(z => z.ProductInOrders)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.TicketInOrders)
                .HasForeignKey(z => z.OrderId);
            
            
        }
    }
}