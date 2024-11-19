namespace Avito.Service.Settings;

public class AvitoSettingsReader
{
    public static AvitoSettings Read(IConfiguration configuration)
    {
        return new AvitoSettings()
        {
            ServiceUri = configuration.GetValue<Uri>("Uri"),
                
           AvitoDbContextConnectionString = configuration.GetValue<string>("AvitoDbContext")
        };
    }
}