using Application.Commands.FrontComponent.CreateCommand;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.DTOs
{
    public class CreateFrontComponentDto : IMapWith<CreateFrontComponentCommand>
    {
        public Guid BaseComponentId { get; set; }
        public Guid PageId { get; set; }
        public int DisplayIndex { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFrontComponentDto, CreateFrontComponentCommand>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
