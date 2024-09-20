using AcoWeb.API.Entities;

namespace AcoWeb.API.Services;

public interface IOfficeRepository
{
    Task<Office?> GetOffice(Guid officeId);
    Task<IEnumerable<Office>> GetOffices();
    Task<Office> AddOffice(Office office);
    Task UpdateOffice(Guid officeId, Office updatedOffice);
    Task DeleteOffice(Guid officeId);
}
