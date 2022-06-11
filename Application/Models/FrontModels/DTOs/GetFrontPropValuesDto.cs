using Application.Common.Mappings;
using Application.Queries.FrontPropValue.GetFrontPropValueByComponent;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.DTOs
{
    public class GetFrontPropValuesDto : IMapWith<GetFrontPropValuesByComponentQuery>
    {
        public Guid ComponentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetFrontPropValuesDto, GetFrontPropValuesByComponentQuery>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
