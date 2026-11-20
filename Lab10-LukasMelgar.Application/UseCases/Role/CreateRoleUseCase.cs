using System;
using System.Threading.Tasks;
using Lab10_LukasMelgar.Application.DTOs;
using Lab10_LukasMelgar.Domain.Models;
using Lab10_LukasMelgar.Domain.Port.Repositories;

namespace Lab10_LukasMelgar.Application.UseCases.Role;

public class CreateRoleUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleDto> ExecuteAsync(CreateRoleDto dto)
    {
        var existing = await _unitOfWork.Roles.GetByNameAsync(dto.RoleName);
        if (existing != null)
        {
            throw new InvalidOperationException($"El rol '{dto.RoleName}' ya existe.");
        }

        var role = new Domain.Models.Role
        {
            RoleId = Guid.NewGuid(),
            RoleName = dto.RoleName
        };

        await _unitOfWork.Roles.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();

        return role.ToDto();
    }
}
