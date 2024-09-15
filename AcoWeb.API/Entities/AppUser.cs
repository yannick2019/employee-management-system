using Microsoft.AspNetCore.Identity;

namespace AcoWeb.API.Entities;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; } = null!;
    public string? Bio { get; set; }
}
