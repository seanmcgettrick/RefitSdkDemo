using AutoMapper;
using RefistSdkDemo.ApiContracts.V1.Responses;
using RefitSdkDemo.Api.Domain;

namespace RefitSdkDemo.Api.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Todo, TodoResponse>();
        }
    }
}
