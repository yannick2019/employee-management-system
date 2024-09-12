using AcoWeb.API.DTOs;
using AcoWeb.API.Entities;
using AutoMapper;

namespace AcoWeb.API.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, GetEmployeesDto>().ReverseMap();
    }
}
