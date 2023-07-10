using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DinkToPdf;
using Domain;
using Domain.DomainModels;
using Domain.DTO;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Interface;

namespace Movies.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITicketInOrderService _ticketInOrderService;
        private readonly IOrderService _orderService;
        private readonly ITicketService _ticketService;
        private readonly UserManager<ShopApplicationUser> _userManager;
        private readonly RazorViewToStringRenderer _viewToStringRenderer;
        public OrderController(ITicketInOrderService ticketInOrderService,
            IOrderService orderService, ITicketService ticketService,
            UserManager<ShopApplicationUser> userManager,
            IRazorViewEngine viewEngine)
        {
            _ticketInOrderService = ticketInOrderService;
            _orderService = orderService;
            _ticketService = ticketService;
            _userManager = userManager;
            _viewEngine = viewEngine;
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

        
        
        public Task<IActionResult> CreateInvoice()
        {
            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var user = _userManager.Users.First(u => u.Id == userId);
            //
            // var ordersByCurrentUser = this._orderService.GetOrdersByUser(userId);
            //
            // List<TicketInOrder> ticketInOrders = new List<TicketInOrder>();
            // foreach (var item in ordersByCurrentUser)
            // {
            //     var orderId = item.Id;
            //     var ticketInOrderItem = _ticketInOrderService.GetAll()
            //         .Where(z => z.OrderId.Equals(orderId))
            //         .FirstOrDefault();
            //     ticketInOrders.Add(ticketInOrderItem);
            // }
            //
            // List<Ticket> orderedTickets = new List<Ticket>();
            //
            // TicketInOrderDto model = new TicketInOrderDto
            // {
            //     Quantity = ticketInOrders.Count,
            //     Username = user.UserName
            // };
            //
            // foreach (var item in ticketInOrders)
            // {
            //     var ticketInOrder = _ticketService.GetAllTickets().FirstOrDefault(z => z.Id.Equals(item.TicketId));
            //     orderedTickets.Add(ticketInOrder);
            // }
            //
            // var htmlContent = await _viewToStringRenderer.RenderViewToStringAsync("Index", model);
            //
            // // Generate PDF using DinkToPdf
            // var converter = new SynchronizedConverter(new PdfTools());
            // var doc = new HtmlToPdfDocument()
            // {
            //     GlobalSettings = {
            //         ColorMode = ColorMode.Color,
            //         Orientation = Orientation.Portrait,
            //         PaperSize = PaperKind.A4,
            //     },
            //     Objects = {
            //         new ObjectSettings
            //         {
            //             HtmlContent = htmlContent,
            //         }
            //     }
            // };
            // var pdfBytes = converter.Convert(doc);
            //
            // // Return the PDF file as a downloadable file - error
            // return File(pdfBytes, "application/pdf", "order.pdf");
            return null;
        }

        // Helper method to render a view to a string
        // private string RenderViewToString(string viewName, object model)
        // {
        //     ViewData.Model = model;
        //     using (var sw = new StringWriter())
        //     {
        //         var viewResult = _viewEngine.FindView(ControllerContext, viewName, null);
        //         var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
        //         viewResult.View.Render(viewContext, sw);
        //         viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
        //         return sw.ToString();
        //     }
        // }
    }
}