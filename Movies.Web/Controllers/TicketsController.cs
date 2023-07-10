using System;
using System.Security.Claims;
using Domain.DomainModels;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Movies.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService productService)
        {
            ticketService = productService;
        }

        public IActionResult Index()
        {
            var allTickets = ticketService.GetAllTickets();
            return View(allTickets);
        }

        public IActionResult AddToCart(Guid? id)
        {
            Ticket t = this.ticketService.GetDetailsForTicket(id);
            var model = new AddToShoppingCartDto
            {
                SelectedTicket = t,
                TicketId = t.Id,
                Quantity = 1
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult AddToCart(AddToShoppingCartDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this.ticketService.AddToShoppingCart(model, userId);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("TicketId,TicketName,TicketImage,TicketDescription,TicketPrice,TicketRating")]
            Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                this.ticketService.CreateNewTicket(ticket);
                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }


        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.ticketService.GetDetailsForTicket(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,
            [Bind("Id,TicketName,TicketImage,TicketDescription,TicketPrice,TicketRating")]
            Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.ticketService.UpdateExistingTicket(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }

        private bool TicketExists(Guid id)
        {
            return this.ticketService.GetDetailsForTicket(id) != null;
        }

        public IActionResult Delete(Guid id)
        {
            this.ticketService.DeleteTicket(id);
            return RedirectToAction("Index", "Tickets");
        }
    }
}