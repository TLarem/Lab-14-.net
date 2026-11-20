using System;
using System.Collections.Generic;

namespace Lab10_LukasMelgar.Application.Port.Services;

public interface ICurrentUser
{
    Guid? UserId { get; }
    string? Username { get; }
    IEnumerable<string> Roles { get; }
    bool IsAuthenticated { get; }
    bool IsInRole(string role);
}
