using Application.Common.Mappings;
using AutoMapper;
using System;

namespace Application.Queries.FrontBaseComponent.GetFrontBaseComponents
{
    public class FrontBaseComponentLookupDto : IMapWith<Domain.FrontBaseComponent>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.FrontBaseComponent, FrontBaseComponentLookupDto>()
                 .ForMember(option => option.Id,
                     opt => opt.MapFrom(front => front.Id))
                 .ForMember(option => option.Name,
                     opt => opt.MapFrom(front => front.Name));
        }
    }
}
