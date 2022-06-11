using Application.Common.Mappings;
using AutoMapper;
using System;

namespace Application.Demo.Queries.GetDemos
{
    public class DemoLookupDto : IMapWith<Domain.Demo>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Demo, DemoLookupDto>()
                .ForMember(option => option.Id,
                    opt => opt.MapFrom(demo => demo.Id))
                .ForMember(option => option.Title,
                    opt => opt.MapFrom(demo => demo.Title));
        }
    }
}
