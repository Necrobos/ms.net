using AutoMapper;
using Avito.BL.Administrators.Entities;
using Avito.DataAccess.Entities;
using Avito.Repository;

namespace Avito.BL.Administrators.Manager;

public class AdministratorsManager : IAdministratorsManager
{
    private IRepository<Administrator> _repository;
    private IMapper _mapper;

    public AdministratorsManager(IRepository<Administrator> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public AdministratorModel CreateAdministrator(CreateAdministratorModel model)
    {
        var administratorEntity = _mapper.Map<Administrator>(model);
        administratorEntity = _repository.Save(administratorEntity);
        return _mapper.Map<AdministratorModel>(administratorEntity);
    }

    public void DeleteAdministrator(int id)
    {
        var entity = _repository.GetById(id);
        if (entity is null)
            throw new ApplicationException("Такого пользователя не существует");

        _repository.Delete(entity);
    }

    public AdministratorModel UpdateAdministrator(int id, UpdateAdministratorModel updateModel)
    {
        throw new NotImplementedException();
    }
}