using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DomainModels;
using Domain.DTO;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<TicketsInShoppingCart> _ticketInShoppingCartRepository;
        private readonly UserManager<ShopApplicationUser> _userManager;
        
        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository,
            IRepository<Order> orderRepository, IRepository<TicketInOrder> ticketInOrderRepository,
            IUserRepository userRepository, IRepository<TicketsInShoppingCart> ticketInShoppingCartRepository,
            UserManager<ShopApplicationUser> userManager)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _userRepository = userRepository;
            _ticketInShoppingCartRepository = ticketInShoppingCartRepository;
            _userManager = userManager;
        }
        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var UserCart = loggedInUser.UserShoppingCart;

            var allTickets = UserCart.TicketsInShoppingCarts?.ToList() ?? new List<TicketsInShoppingCart>();

            var allTicketPrices = allTickets.Select(z => new
            {
                ProductPrice = z.Ticket.TicketPrice,
                Quantity = z.Quantity
            }).ToList();

            float totalPrice = 0.0f;

            foreach (var item in allTicketPrices)
            {
                totalPrice += item.Quantity * item.ProductPrice;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TicketsInShoppingCarts = allTickets,
                TotalPrice = totalPrice
            };

            return model;
        }


        public TicketsInShoppingCart deleteTicketFromSoppingCart(Guid? ticketId, string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var UserCart = loggedInUser.UserShoppingCart;

            var itemToDelete = UserCart.TicketsInShoppingCarts
                .Where(z => z.TicketId.Equals(ticketId)).FirstOrDefault();

            UserCart.TicketsInShoppingCarts.Remove(itemToDelete);

            _shoppingCartRepository.Update(UserCart);

            return itemToDelete;
        }

        public Order CreateOrder(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var UserCart = loggedInUser.UserShoppingCart;

            Order userOrder = new Order
            {
                Id = Guid.NewGuid(),
                UserId = loggedInUser.Id,
                User = loggedInUser
            };

            _orderRepository.Insert(userOrder);

            var productsInOrder = UserCart.TicketsInShoppingCarts.Select(z => new TicketInOrder
            {
                Id = Guid.NewGuid(),
                TicketId = z.Ticket.Id,
                OrderedTicket = z.Ticket,
                OrderId = userOrder.Id,
                UserOrder = userOrder
            }).ToList();

            foreach (var item in productsInOrder)
            {
                _ticketInOrderRepository.Insert(item);
            }

            UserCart.TicketsInShoppingCarts.Clear();

            _shoppingCartRepository.Update(UserCart);

            return userOrder;
        }
    }
}