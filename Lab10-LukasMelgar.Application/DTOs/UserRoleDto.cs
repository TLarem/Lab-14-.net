namespace Lab10_LukasMelgar.Application.DTOs;

public class UserRoleDto
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = null!;
    public Guid RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public DateTime? AssignedAt { get; set; }
}
