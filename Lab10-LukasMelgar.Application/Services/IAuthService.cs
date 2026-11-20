using System.Threading.Tasks;
using Lab10_LukasMelgar.Application.DTOs;

namespace Lab10_LukasMelgar.Application.Port.Services;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    Task<UserDto> RegisterAsync(CreateUserDto request);
}
