namespace AcoWeb.API.DTOs;

public class GetEmployeesDto
{
    public Guid Id { get; set; }
    public string RoleInCompany { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateTimeOffset Hired { get; set; }
}
