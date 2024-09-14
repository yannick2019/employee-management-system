using AcoWeb.API.Data;
using AcoWeb.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoWeb.API.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeesContext _context;

    public EmployeeRepository(EmployeesContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> GetEmployee(Guid employeeId, Guid officeId)
    {
        return await _context.Employees
                        .Where(e => e.Id == employeeId && e.OfficeId == officeId)
                        .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetEmployeesByOffice(Guid officeId)
    {
        return await _context.Employees.Where(e => e.OfficeId == officeId).ToListAsync();
    }

    public async Task UpdateEmployee(Guid employeeId, Employee updatedEmployee)
    {
        var existingEmployee = await _context.Employees.FindAsync(employeeId);
        if (existingEmployee != null)
        {
            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.RoleInCompany = updatedEmployee.RoleInCompany;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.EmployeeAddress = updatedEmployee.EmployeeAddress;
            existingEmployee.HireDate = updatedEmployee.HireDate;
            existingEmployee.OfficeId = updatedEmployee.OfficeId;

            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Employee not found");
        }
    }

    public async Task DeleteEmployee(Guid employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
        }
        await _context.SaveChangesAsync();
    }
}
