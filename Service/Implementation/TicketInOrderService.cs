using System.Collections.Generic;
using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class TicketInOrderService : ITicketInOrderService
    {
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;

        public TicketInOrderService(IRepository<TicketInOrder> ticketInOrderRepository)
        {
            _ticketInOrderRepository = ticketInOrderRepository;
        }
        
        
        public IEnumerable<TicketInOrder> GetAll()
        {
            return this._ticketInOrderRepository.GetAll();
        }
    }
}