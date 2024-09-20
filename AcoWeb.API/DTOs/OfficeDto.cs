namespace AcoWeb.API.DTOs;

public class OfficeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
}
