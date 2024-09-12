using AcoWeb.API.DTOs;
using AcoWeb.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AcoWeb.API.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository ??
            throw new ArgumentNullException(nameof(employeeRepository));
        _mapper = mapper;
    }

    [HttpGet("{officeId}")]
    public IActionResult GetEmployeesByOffice(Guid officeId)
    {
        var employees = _employeeRepository.GetEmployeesByOffice(officeId);
        return Ok(employees);
    }

    [HttpGet]
    public ActionResult<List<GetEmployeesDto>> GetEmployees()
    {
        var employeeList = _employeeRepository.GetEmployees();

        var employeesDtoList = _mapper.Map<List<GetEmployeesDto>>(employeeList);

        return Ok(employeesDtoList);
    }
}
