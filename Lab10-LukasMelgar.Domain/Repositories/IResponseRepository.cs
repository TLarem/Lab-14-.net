using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_LukasMelgar.Domain.Models;

namespace Lab10_LukasMelgar.Domain.Port.Repositories;

public interface IResponseRepository : IGenericRepository<Response>
{
    Task<IEnumerable<Response>> GetByTicketIdAsync(Guid ticketId);
    Task<IEnumerable<Response>> GetByTicketIdWithResponderAsync(Guid ticketId);
}
