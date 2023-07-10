using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Domain.DomainModels;
using Domain.DTO;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Movies.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly ITicketInOrderService _ticketInOrderService;
        private readonly IOrderService _orderService;
        private readonly ITicketService _ticketService;
        private readonly UserManager<ShopApplicationUser> _userManager;

        public OrderController(ITicketInOrderService ticketInOrderService, 
            IOrderService orderService, ITicketService ticketService,
            UserManager<ShopApplicationUser> userManager)
        {
            _ticketInOrderService = ticketInOrderService;
            _orderService = orderService;
            _ticketService = ticketService;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.First(u => u.Id == userId);

            var ordersByCurrentUser = this._orderService.GetOrdersByUser(userId);

            List<TicketInOrder> ticketInOrders = new List<TicketInOrder>();
            foreach (var item in ordersByCurrentUser)
            {
                var orderId = item.Id;
                var ticketInOrderItem = _ticketInOrderService.GetAll()
                    .Where(z => z.OrderId.Equals(orderId))
                    .FirstOrDefault();
                ticketInOrders.Add(ticketInOrderItem);
            }

            List<Ticket> orderedTickets = new List<Ticket>();

            TicketInOrderDto model = new TicketInOrderDto
            {
                Quantity = ticketInOrders.Count,
                Username = user.UserName
            };

            foreach (var item in ticketInOrders)
            {
                var ticketInOrder = _ticketService.GetAllTickets().FirstOrDefault(z => z.Id.Equals(item.TicketId));
                orderedTickets.Add(ticketInOrder);
            }

            return View(model);
        }

        
    }
}