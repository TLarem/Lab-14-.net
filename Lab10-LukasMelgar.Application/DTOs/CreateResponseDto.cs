namespace Lab10_LukasMelgar.Application.DTOs;

public class CreateResponseDto
{
    public Guid TicketId { get; set; }
    public string Message { get; set; } = null!;
}
