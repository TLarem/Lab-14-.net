using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab10_LukasMelgar.Domain.Models;
using Lab10_LukasMelgar.Domain.Port.Repositories;
using Lab10_LukasMelgar.Infrastructure.Persistence;

namespace Lab10_LukasMelgar.Infrastructure.Adapters.Repositories.Implementation;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly TicketeraDbContext _context;

    public UserRoleRepository(TicketeraDbContext context)
    {
        _context = context;
    }

    public async Task<UserRole?> GetAsync(Guid userId, Guid roleId)
    {
        return await _context.UserRoles
            .Include(ur => ur.User)
            .Include(ur => ur.Role)
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
    }

    public async Task<IEnumerable<UserRole>> GetAllAsync()
    {
        return await _context.UserRoles
            .Include(ur => ur.User)
            .Include(ur => ur.Role)
            .ToListAsync();
    }

    public async Task AddAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
    }

    public void Remove(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);
    }
}
