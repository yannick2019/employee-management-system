using AcoWeb.API.Data;
using AcoWeb.API.Services;
using Microsoft.EntityFrameworkCore;

namespace AcoWeb.API.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<EmployeesContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            options.LogTo(Console.WriteLine);
        });

        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}
