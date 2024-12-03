using AutoMapper;
using Avito.BL.Administrators.Entities;
using Avito.DataAccess.Entities;

namespace Avito.BL.Mapper;

public class AdministratorBLProfile : Profile
{
    public AdministratorBLProfile()
    {
        CreateMap<Administrator, AdministratorModel>()
            .ForMember(x => x.FullName, 
                y => y.MapFrom(src => src.UserFIO));
        CreateMap<CreateAdministratorModel, Administrator>()
            .ForMember(x => x.UserFIO, y => y.MapFrom(src => src.FullName));
    }
}