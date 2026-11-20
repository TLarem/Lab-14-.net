using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab10_LukasMelgar.Application.DTOs;
using Lab10_LukasMelgar.Domain.Port.Repositories;

namespace Lab10_LukasMelgar.Application.UseCases.UserRole;

public class ListRoleAssignmentsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public ListRoleAssignmentsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserRoleDto>> ExecuteAsync()
    {
        var assignments = await _unitOfWork.UserRoles.GetAllAsync();
        return assignments.Select(a => a.ToDto());
    }
}
