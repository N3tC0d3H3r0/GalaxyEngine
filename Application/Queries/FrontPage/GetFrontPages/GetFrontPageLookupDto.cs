using Application.Common.Mappings;
using AutoMapper;
using System;

namespace Application.Queries.FrontPage.GetFrontPages
{
    public class GetFrontPageLookupDto : IMapWith<Domain.FrontPage>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.FrontPage, GetFrontPageLookupDto>()
              .ForMember(option => option.Id,
                  opt => opt.MapFrom(front => front.Id))
              .ForMember(option => option.Name,
                  opt => opt.MapFrom(front => front.Name))
              .ForMember(option => option.Route,
                  opt => opt.MapFrom(front => front.Route));
        }
    }
}
