namespace AcoWeb.API.DTOs;

public class GetEmployeesDto
{
    public Guid Id { get; set; }
    public string RoleInCompany { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTimeOffset HireDate { get; set; }
    public Guid OfficeId { get; set; }
}
