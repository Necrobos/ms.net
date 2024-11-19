using Avito.DataAccess;
using Avito.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace Avito.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services,AvitoSettings settings)
    {
        services.AddDbContextFactory<AvitoDbContext>(
            options => { options.UseNpgsql(settings.AvitoDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AvitoDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}