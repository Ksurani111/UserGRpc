using AutoMapper;
using UserGrpcService.Entities;
using UserGrpcService.Protos;

namespace UserGrpcService.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //// Add as many of these lines as you need to map your objects
            CreateMap<UserDetail, UserDetails>();
            CreateMap<UserDetails, UserDetail>();

        }
    }
}
