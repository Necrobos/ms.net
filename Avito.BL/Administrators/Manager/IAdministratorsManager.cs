using Avito.BL.Administrators.Entities;

namespace Avito.BL.Administrators.Manager;

public interface IAdministratorsManager
{
    AdministratorModel CreateAdministrator(CreateAdministratorModel model);
    void DeleteAdministrator(int id);
    AdministratorModel UpdateAdministrator(int id, UpdateAdministratorModel updateModel);
}