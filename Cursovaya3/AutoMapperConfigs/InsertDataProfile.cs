using AutoMapper;
using BLL;
using DatabaseAccess;

namespace Cursovaya3.AutoMapperConfigs
{
    
        public class InsertDataProfile : Profile
        {
            public InsertDataProfile()
                => CreateMap<InsertData_DTO, InsertData>()
                    .ReverseMap();
        }
    
}
