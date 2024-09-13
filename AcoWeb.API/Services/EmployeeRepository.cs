using AcoWeb.API.Data;
using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeesContext _context;

    public EmployeeRepository(EmployeesContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Employee? GetEmployee(Guid employeeId, Guid officeId)
    {
        return _context.Employees
                        .Where(e => e.Id == employeeId && e.OfficeId == officeId)
                        .FirstOrDefault();
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public IEnumerable<Employee> GetEmployeesByOffice(Guid officeId)
    {
        return _context.Employees.Where(e => e.OfficeId == officeId).ToList();
    }
}
