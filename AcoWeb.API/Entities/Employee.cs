using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcoWeb.API.Entities;

public class Employee
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string RoleInCompany { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTimeOffset HireDate { get; set; }

    [Required]
    [MaxLength(50)]
    public decimal Salary { get; set; }

    [ForeignKey("OfficeId")]
    public Office? Office { get; set; }

    public Guid OfficeId { get; set; }

}
