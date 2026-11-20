using System;
using System.Threading.Tasks;
using Lab10_LukasMelgar.Domain.Models;

namespace Lab10_LukasMelgar.Domain.Port.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role?> GetByNameAsync(string roleName);
}
