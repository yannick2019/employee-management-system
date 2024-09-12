using System.ComponentModel.DataAnnotations;

namespace AcoWeb.API.Entities;

public class Office
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(400)]
    public string Address { get; set; } = null!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
