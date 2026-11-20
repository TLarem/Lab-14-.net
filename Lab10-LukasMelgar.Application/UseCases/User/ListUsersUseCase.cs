using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab10_LukasMelgar.Application.DTOs;
using Lab10_LukasMelgar.Domain.Port.Repositories;

namespace Lab10_LukasMelgar.Application.UseCases.User;

public class ListUsersUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public ListUsersUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserDto>> ExecuteAsync()
    {
        var users = await _unitOfWork.Users.GetAllWithRolesAsync();
        return users.Select(u => u.ToDto());
    }
}
