using System.Collections;
using System.Collections.Generic;
using Domain.DomainModels;

namespace Service.Interface
{
    public interface ITicketInOrderService
    {
        IEnumerable<TicketInOrder> GetAll();
    }
}