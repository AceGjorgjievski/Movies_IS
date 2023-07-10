using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DomainModels;
using Domain.DTO;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _productRepository;
        private readonly IRepository<TicketsInShoppingCart> _productsInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public TicketService(IRepository<Ticket> productRepository,
            IRepository<TicketsInShoppingCart> productsInShoppingCartRepository, 
            IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productsInShoppingCartRepository = productsInShoppingCartRepository;
        }

        public List<Ticket> GetAllTickets()
        {
            return this._productRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(Guid? id)
        {
            return this._productRepository.Get(id);

        }

        public void CreateNewTicket(Ticket t)
        {
            this._productRepository.Insert(t);
        }

        public void UpdateExistingTicket(Ticket t)
        {
            this._productRepository.Update(t);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var ticket = this.GetDetailsForTicket(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedTicket = ticket,
                TicketId = ticket.Id,
                Quantity = 1
            };

            return model;
        }

        public void DeleteTicket(Guid id)
        {
            var productToBeDeleted = this.GetDetailsForTicket(id);
            this._productRepository.Delete(productToBeDeleted);
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserShoppingCart;

            if (item.TicketId != null && userShoppingCard != null)
            {
                var product = this.GetDetailsForTicket(item.TicketId);
                //{896c1325-a1bb-4595-92d8-08da077402fc}

                if (product != null)
                {
                    TicketsInShoppingCart itemToAdd = new TicketsInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Ticket = product,
                        TicketId = product.Id,
                        ShoppingCart = userShoppingCard,
                        CartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCard.TicketsInShoppingCarts
                        .Where(z => z.CartId == userShoppingCard.Id && z.TicketId == itemToAdd.TicketId)
                        .FirstOrDefault();

                    if(existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        this._productsInShoppingCartRepository.Update(existing);

                    }
                    else
                    {
                        this._productsInShoppingCartRepository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}