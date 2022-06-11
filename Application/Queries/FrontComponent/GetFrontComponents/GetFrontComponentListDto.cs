using Application.Common.Mappings;
using Application.Queries.FrontPropValue;
using Application.Queries.FrontPropValue.GetFrontPropValueByComponent;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Application.Queries.FrontComponent.GetFrontComponents
{
    public class GetFrontComponentListDto : IMapWith<Domain.FrontComponent>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DisplayIndex { get; set; }
        public bool IsActive { get; set; }
        public bool IsHidden { get; set; }
        public List<GetFrontPropValueListDto> Props { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.FrontComponent, GetFrontComponentListDto>()
              .ForMember(option => option.Id,
                  opt => opt.MapFrom(front => front.Id))
              .ForMember(option => option.Name,
                  opt => opt.MapFrom(front => front.BaseComponent.Name))
              .ForMember(option => option.IsActive,
                  opt => opt.MapFrom(front => front.IsHidden))
              .ForMember(option => option.DisplayIndex,
                  opt => opt.MapFrom(front => front.DisplayIndex));

        }
    }
}
