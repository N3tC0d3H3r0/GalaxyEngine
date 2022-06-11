using Application.Commands.FrontPropValue.CreateCommand;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateFrontPropValueDto : IMapWith<CreateFrontPropValueCommand>
    {
        public string ComponentId { get; set; }
        public string PropId { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFrontPropValueDto, CreateFrontPropValueCommand>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
