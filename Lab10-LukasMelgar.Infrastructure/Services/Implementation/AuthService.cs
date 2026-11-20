using System.Threading.Tasks;
using Lab10_LukasMelgar.Application.DTOs;
using Lab10_LukasMelgar.Application.Port.Services;
using Lab10_LukasMelgar.Application.UseCases.User;

namespace Lab10_LukasMelgar.Infrastructure.Adapters.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly LoginUseCase _loginUseCase;
    private readonly CreateUserUseCase _createUserUseCase;

    public AuthService(LoginUseCase loginUseCase, CreateUserUseCase createUserUseCase)
    {
        _loginUseCase = loginUseCase;
        _createUserUseCase = createUserUseCase;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        return await _loginUseCase.ExecuteAsync(request);
    }

    public async Task<UserDto> RegisterAsync(CreateUserDto request)
    {
        return await _createUserUseCase.ExecuteAsync(request);
    }
}
