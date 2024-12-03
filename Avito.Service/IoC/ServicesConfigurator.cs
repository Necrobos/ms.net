using AutoMapper;
using Avito.BL.Administrators.Manager;
using Avito.BL.Administrators.Provider;
using Avito.DataAccess;
using Avito.DataAccess.Entities;
using Avito.Repository;
using Microsoft.EntityFrameworkCore;

namespace Avito.Service.IoC;

public class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<Administrator>>(x =>
            new Repository<Administrator>(x.GetRequiredService<IDbContextFactory<AvitoDbContext>>()));
        services.AddScoped<IAdministratorsProvider>(x => new AdministratorsProvider(
            x.GetRequiredService<IRepository<Administrator>>(), 
            x.GetRequiredService<IMapper>()));
        services.AddScoped<IAdministratorsManager>(x =>
            new AdministratorsManager(x.GetRequiredService<IRepository<Administrator>>(), x.GetRequiredService<IMapper>()));
    }
}