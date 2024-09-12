using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public interface IEmployeeRepository
{
    Employee GetEmployee(Guid employeeId, Guid officeId);
    IEnumerable<Employee> GetEmployeesByOffice(Guid officeId);
    IEnumerable<Employee> GetEmployees();
}
