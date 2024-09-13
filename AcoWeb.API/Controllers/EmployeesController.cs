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
    public ActionResult<List<GetEmployeesDto>> GetEmployeesByOffice(Guid officeId)
    {
        var employees = _employeeRepository.GetEmployeesByOffice(officeId);

        var employeesDto = _mapper.Map<List<GetEmployeesDto>>(employees);

        return Ok(employeesDto);
    }

    [HttpGet]
    public ActionResult<List<GetEmployeesDto>> GetEmployees()
    {
        var employeeList = _employeeRepository.GetEmployees();

        var employeesDtoList = _mapper.Map<List<GetEmployeesDto>>(employeeList);

        return Ok(employeesDtoList);
    }

    [HttpGet("{officeId}/{employeeId}")]
    public ActionResult<GetEmployeeDto> GetEmployee(Guid employeeId, Guid officeId)
    {
        var employee = _employeeRepository.GetEmployee(employeeId, officeId);

        var employeeDto = _mapper.Map<GetEmployeeDto>(employee);

        return employee is null ? NotFound("Employee not found") : Ok(employeeDto);
    }
}
