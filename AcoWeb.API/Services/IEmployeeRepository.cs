using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public interface IEmployeeRepository
{
    Employee? GetEmployee(Guid officeId, Guid employeeId);
    IEnumerable<Employee> GetEmployeesByOffice(Guid officeId);
    IEnumerable<Employee> GetEmployees();
}
