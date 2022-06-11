using Application.Commands.FrontPropValue.UpdateCommand;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UpdateFrontPropValueDto : IMapWith<UpdateFrontPropValueCommand>
    {
        public Guid PropValueID { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFrontPropValueDto, UpdateFrontPropValueCommand>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
