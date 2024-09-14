using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcoWeb.API.Entities;

public class EmployeeAddress
{
    [Key]
    public Guid Id { get; set; }
    public string HomeAddress { get; set; } = null!;
    public string City { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } = null!;
    public Guid EmployeeId { get; set; }
}
