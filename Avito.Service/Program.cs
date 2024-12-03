using System.Collections.Immutable;
using AutoMapper;
using Avito.Service.IoC;
using Avito.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings =AvitoSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);
DbContextConfigurator.ConfigureService(builder.Services, settings);

MapperConfigurator.ConfigureServices(builder.Services);

ServicesConfigurator.ConfigureServices(builder.Services);
builder.Services.AddControllers();



var app = builder.Build();


SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);

app.MapControllers();
app.UseHttpsRedirection();

app.Run();