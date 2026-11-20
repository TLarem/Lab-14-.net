using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab10_LukasMelgar.Domain.Models;
using Lab10_LukasMelgar.Domain.Port.Repositories;
using Lab10_LukasMelgar.Infrastructure.Persistence;

namespace Lab10_LukasMelgar.Infrastructure.Adapters.Repositories.Implementation;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(TicketeraDbContext context) : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string roleName)
    {
        return await _dbSet.FirstOrDefaultAsync(r => r.RoleName.ToLower() == roleName.ToLower());
    }
}
