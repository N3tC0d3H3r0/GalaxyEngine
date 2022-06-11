using Application.Common.Mappings;
using Application.Queries.FrontComponent.GetFrontComponents;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.DTOs
{
    public class GetFrontComponentListDto : IMapWith<GetFrontComponentListQuery>
    {
        public string Route { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetFrontComponentListDto, GetFrontComponentListQuery>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
