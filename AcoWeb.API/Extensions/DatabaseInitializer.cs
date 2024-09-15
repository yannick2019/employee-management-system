using AcoWeb.API.Data;
using Microsoft.EntityFrameworkCore;

namespace AcoWeb.API.Extensions;

public static class DatabaseInitializer
{
    public static void InitializeDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<EmployeesContext>();
            context!.Database.EnsureCreated();
            context!.Database.EnsureDeleted();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "An error occured when migrating the database");
        }
    }
}
