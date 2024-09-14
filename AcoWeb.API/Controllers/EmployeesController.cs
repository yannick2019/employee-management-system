using AcoWeb.API.DTOs;
using AcoWeb.API.Entities;
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

    /// <summary>
    /// Retrieves a list of employees from a specific office.
    /// </summary>
    /// <param name="officeId">The unique identifier of the office.</param>
    /// <returns>A list of <see cref="GetEmployeesDto"/> representing the employees in the specified office.</returns>
    /// <response code="200">Returns the list of employees.</response>
    /// <response code="404">If no employees are found for the specified office.</response>
    [HttpGet("{officeId}")]
    public async Task<ActionResult<List<GetEmployeesDto>>> GetEmployeesByOffice(Guid officeId)
    {
        var employees = await _employeeRepository.GetEmployeesByOffice(officeId);

        var employeesDto = _mapper.Map<List<GetEmployeesDto>>(employees);

        return Ok(employeesDto);
    }

    /// <summary>
    /// Retrieves a list of all employees.
    /// </summary>
    /// <returns>An ActionResult containing a list of <see cref="GetEmployeesDto"/> objects.</returns>
    /// <response code="200">Returns the list of employees.</response>
    /// <response code="404">If no employees are found.</response>
    [HttpGet]
    public async Task<ActionResult<List<GetEmployeesDto>>> GetEmployees()
    {
        var employeeList = await _employeeRepository.GetEmployees();

        var employeesDtoList = _mapper.Map<List<GetEmployeesDto>>(employeeList);

        return Ok(employeesDtoList);
    }

    /// <summary>
    /// Retrieves an employee by their employeeId and officeId.
    /// </summary>
    /// <param name="employeeId">The unique identifier of the employee.</param>
    /// <param name="officeId">The unique identifier of the office.</param>
    /// <returns>An ActionResult containing a GetEmployeeDto object.</returns>
    /// <response code="200">Returns the employee data.</response>
    /// <response code="404">If the employee is not found.</response>
    [HttpGet("{officeId}/{employeeId}")]
    public async Task<ActionResult<GetEmployeeDto>> GetEmployee(Guid employeeId, Guid officeId)
    {
        var employee = await _employeeRepository.GetEmployee(employeeId, officeId);

        var employeeDto = _mapper.Map<GetEmployeeDto>(employee);

        return employee is null ? NotFound("Employee not found") : Ok(employeeDto);
    }

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    /// <param name="employeeDto">The employee data transfer object containing the details of the employee to be created.</param>
    /// <returns>An ActionResult containing the created employee data transfer object.</returns>
    /// <response code="201">Returns the newly created employee.</response>
    /// <response code="400">If the employee data transfer object is null or invalid.</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetEmployeeDto>> Create(GetEmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.AddEmployee(employee);

        var createdEmployeeDto = _mapper.Map<GetEmployeeDto>(employee);
        return CreatedAtAction(nameof(GetEmployee), new { officeId = employee.OfficeId, employeeId = employee.Id }, createdEmployeeDto);
    }

    /// <summary>
    /// Updates an existing employee.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to be updated.</param>
    /// <param name="employeeDto">The employee data transfer object containing the updated details of the employee.</param>
    /// <returns>An IActionResult indicating the result of the update operation.</returns>
    /// <response code="204">If the employee was successfully updated.</response>
    /// <response code="400">If the employee ID in the route does not match the employee ID in the DTO.</response>
    /// <response code="404">If the employee is not found.</response>
    [HttpPut("{employeeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid employeeId, GetEmployeeDto employeeDto)
    {
        if (employeeId != employeeDto.Id)
        {
            return BadRequest("Employee ID mismatch");
        }

        var employee = _mapper.Map<Employee>(employeeDto);

        try
        {
            await _employeeRepository.UpdateEmployee(employeeId, employee);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Employee not found");
        }

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing employee.
    /// </summary>
    /// <param name="employeeId">The ID of the employee to be deleted.</param>
    /// <returns>An IActionResult indicating the result of the delete operation.</returns>
    /// <response code="204">If the employee was successfully deleted.</response>
    /// <response code="404">If the employee is not found.</response>
    [HttpDelete("{employeeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid employeeId)
    {
        await _employeeRepository.DeleteEmployee(employeeId);
        return NoContent();
    }
}
