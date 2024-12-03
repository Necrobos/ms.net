using AutoMapper;
using Avito.BL.Administrators.Entities;
using Avito.DataAccess.Entities;
using Avito.Repository;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avito.BL.Administrators.Provider;

public class AdministratorsProvider: IAdministratorsProvider
{
    private IRepository<Administrator> _repository;
    private IMapper _mapper;

    public AdministratorsProvider(IRepository<Administrator> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public IEnumerable<AdministratorModel> GetAdministrators()
    {
        var administrators = _repository.GetAll();
        return _mapper.Map<IEnumerable<AdministratorModel>>(administrators);
    }
}