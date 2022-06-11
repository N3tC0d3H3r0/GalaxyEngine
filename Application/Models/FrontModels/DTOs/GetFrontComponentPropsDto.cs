using Application.Common.Mappings;
using Application.Queries.FrontComponentProp;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class GetFrontComponentPropsDto : IMapWith<GetFrontComponentPropListQuery>
    {
        public Guid BaseComponentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetFrontComponentPropsDto, GetFrontComponentPropListQuery>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
