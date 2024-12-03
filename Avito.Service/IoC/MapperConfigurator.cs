using AutoMapper;
using Avito.BL.Mapper;

namespace Avito.Service.IoC;

public class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(expression =>
        {
            expression.AddProfile<AdministratorBLProfile>();
        });
    }
}