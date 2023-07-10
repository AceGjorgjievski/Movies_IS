using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Movies.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = this._shoppingCartService.getShoppingCartInfo(userId);
            return View(model);
        }

        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                _shoppingCartService.deleteTicketFromSoppingCart(id, userId);
            }

            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                _shoppingCartService.CreateOrder(userId);
            }

            return RedirectToAction("Index", "Tickets");
        }
    }
}