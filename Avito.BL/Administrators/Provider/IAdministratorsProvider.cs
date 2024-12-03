using Avito.BL.Administrators.Entities;

namespace Avito.BL.Administrators.Provider;

public interface IAdministratorsProvider
{
    IEnumerable<AdministratorModel> GetAdministrators();
}