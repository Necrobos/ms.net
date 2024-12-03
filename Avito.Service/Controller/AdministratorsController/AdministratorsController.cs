using AutoMapper;
using Avito.BL.Administrators.Entities;
using Avito.BL.Administrators.Manager;
using Avito.BL.Administrators.Provider;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Avito.Service.Controller.AdministratorsController;

[ApiController]
[Route("[controller]")]

public class AdministratorsController : ControllerBase
{
    private IAdministratorsManager _manager;
    private IAdministratorsProvider _provider;
    private IMapper _mapper;
    private ILogger _logger;
    
    public AdministratorsController(IAdministratorsManager manager, IAdministratorsProvider provider, IMapper mapper, ILogger logger)
    {
        _manager = manager;
        _provider = provider;
        _mapper = mapper;
        _logger = logger;
    }
    
    [HttpPost]
    [Route ("create")]
    
    public IActionResult Create([FromQuery] CreateAdministratorModel createModel)
    {
        
        var administrator = _manager.CreateAdministrator(createModel);
        return Ok(administrator);
    }
    
    [HttpGet]
    [Route("get")]
    public IActionResult Get()
    {
        var administrators = _provider.GetAdministrators();
        return Ok(administrators.ToList());
    }
    
    [HttpDelete]
    [Route ("delete")]
    public IActionResult Delete([FromQuery] int id)
    {
        try
        {
            _manager.DeleteAdministrator(id);
            return Ok("Пользователь удален!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    [Route ("update")]
    public IActionResult Update([FromQuery] int id)
    {
        try
        {
            var model = _manager.UpdateAdministrator(id, new UpdateAdministratorModel());
            return Ok(model);
        }
        catch (Exception ex)
        {
            _logger.Error(ex.ToString());
            return BadRequest("Что-то пошло не так(");
        }
    }
}