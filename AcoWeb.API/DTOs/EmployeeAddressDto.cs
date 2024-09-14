namespace AcoWeb.API.DTOs;

public class EmployeeAddressDto
{
    public Guid Id { get; set; }
    public string HomeAddress { get; set; } = null!;
    public string City { get; set; } = null!;
}
