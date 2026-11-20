using System;
using System.Collections.Generic;
using Lab10_LukasMelgar.Domain.Models;

namespace Lab10_LukasMelgar.Application.Port.Services;

public interface ITokenService
{
    string GenerateToken(User user, IEnumerable<string> roles);
}
