using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab10_LukasMelgar.Domain.Models;
using Lab10_LukasMelgar.Domain.Port.Repositories;
using Lab10_LukasMelgar.Infrastructure.Persistence;

namespace Lab10_LukasMelgar.Infrastructure.Adapters.Repositories.Implementation;

public class ResponseRepository : GenericRepository<Response>, IResponseRepository
{
    public ResponseRepository(TicketeraDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Response>> GetByTicketIdAsync(Guid ticketId)
    {
        return await _dbSet
            .Where(r => r.TicketId == ticketId)
            .OrderBy(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Response>> GetByTicketIdWithResponderAsync(Guid ticketId)
    {
        return await _dbSet
            .Include(r => r.Responder)
            .Where(r => r.TicketId == ticketId)
            .OrderBy(r => r.CreatedAt)
            .ToListAsync();
    }
}
