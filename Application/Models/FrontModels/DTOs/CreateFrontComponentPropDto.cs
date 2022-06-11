using Application.Commands.FrontComponentProp.CreateCommand;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.DTOs
{
    public class CreateFrontComponentPropDto : IMapWith<CreateFrontComponentPropCommand>
    {
        public string Title { get; set; }
        public bool CanBeHidden { get; set; }
        public string Type { get; set; }
        public Guid BaseComponentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFrontComponentPropDto, CreateFrontComponentPropCommand>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
