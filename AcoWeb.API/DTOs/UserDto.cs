namespace AcoWeb.API.DTOs;

public class UserDto
{
    public string DisplayName { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string? Image { get; set; }
    public string Username { get; set; } = null!;
}
