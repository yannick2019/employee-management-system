using AcoWeb.API.DTOs;
using AcoWeb.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcoWeb.API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ??
            throw new ArgumentNullException(nameof(employeeRepository));
    }

    [HttpGet("{officeId}")]
    public IActionResult GetEmployeesByOffice(Guid officeId)
    {
        var employees = _employeeRepository.GetEmployeesByOffice(officeId);
        return Ok(employees);
    }

    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = _employeeRepository.GetEmployees();

        var employeesDtoList = from e in employees
                               select new GetEmployeesDto
                               {
                                   Id = e.Id,
                                   FullName = e.FullName,
                                   Hired = e.Hired,
                                   RoleInCompany = e.RoleInCompany
                               };
        return Ok(employeesDtoList);
    }
}
