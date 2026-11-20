using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab10_LukasMelgar.Domain.Models;

namespace Lab10_LukasMelgar.Domain.Port.Repositories;

public interface IUserRoleRepository
{
    Task<UserRole?> GetAsync(Guid userId, Guid roleId);
    Task<IEnumerable<UserRole>> GetAllAsync();
    Task AddAsync(UserRole userRole);
    void Remove(UserRole userRole);
}
