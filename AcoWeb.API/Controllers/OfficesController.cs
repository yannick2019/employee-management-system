using AcoWeb.API.DTOs;
using AcoWeb.API.Entities;
using AcoWeb.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcoWeb.API.Controllers;

[ApiController]
[Route("api/offices")]
//[Authorize]
public class OfficesController : ControllerBase
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;

    public OfficesController(IOfficeRepository officeRepository, IMapper mapper)
    {
        _officeRepository = officeRepository ??
            throw new ArgumentNullException(nameof(officeRepository));
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<OfficeDto>>> GetOffices()
    {
        var officeList = await _officeRepository.GetOffices();
        var officesDtoList = _mapper.Map<List<OfficeDto>>(officeList);

        return Ok(officesDtoList);
    }

    [HttpGet("{officeId}")]
    public async Task<ActionResult<OfficeDto>> GetOffice(Guid officeId)
    {
        var office = await _officeRepository.GetOffice(officeId);
        var officeDto = _mapper.Map<OfficeDto>(office);

        return office is null ? NotFound("Office not found") : Ok(officeDto);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OfficeDto>> Create(OfficeDto officeDto)
    {
        var office = _mapper.Map<Office>(officeDto);
        await _officeRepository.AddOffice(office);

        var createdOfficeDto = _mapper.Map<OfficeDto>(office);

        return CreatedAtAction(nameof(GetOffice), new { id = office.Id }, createdOfficeDto);
    }

    [HttpPut("{officeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid officeId, OfficeDto officeDto)
    {
        if (officeId != officeDto.Id)
        {
            return BadRequest("Office Id mismatch");
        }

        var office = _mapper.Map<Office>(officeDto);

        try
        {
            await _officeRepository.UpdateOffice(officeId, office);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Office not found");
        }

        return NoContent();
    }

    [HttpDelete("{officeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid officeId)
    {
        await _officeRepository.DeleteOffice(officeId);
        return NoContent();
    }
}
