using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public interface IEmployeeRepository
{
    Task<Employee?> GetEmployee(Guid officeId, Guid employeeId);
    Task<IEnumerable<Employee>> GetEmployeesByOffice(Guid officeId);
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> AddEmployee(Employee employee);
    Task UpdateEmployee(Guid employeeId, Employee updatedEmployee);
    Task DeleteEmployee(Guid employeeId);
}
