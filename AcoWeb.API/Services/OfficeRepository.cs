using AcoWeb.API.Data;
using AcoWeb.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcoWeb.API.Services;

public class OfficeRepository : IOfficeRepository
{
    private readonly EmployeesContext _context;

    public OfficeRepository(EmployeesContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Office> AddOffice(Office office)
    {
        await _context.Offices.AddAsync(office);
        await _context.SaveChangesAsync();
        return office;
    }

    public async Task DeleteOffice(Guid officeId)
    {
        var office = await _context.Offices.FindAsync(officeId);
        if (office != null)
        {
            _context.Offices.Remove(office);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<Office?> GetOffice(Guid officeId)
    {
        return await _context.Offices.Where(o => o.Id == officeId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Office>> GetOffices()
    {
        return await _context.Offices.ToListAsync();
    }

    public async Task UpdateOffice(Guid officeId, Office updatedOffice)
    {
        var existingOffice = await _context.Offices.FindAsync(officeId);
        if (existingOffice != null)
        {
            existingOffice.Name = updatedOffice.Name;
            existingOffice.Address = updatedOffice.Address;

            _context.Offices.Update(existingOffice);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Office not found");
        }
    }
}
