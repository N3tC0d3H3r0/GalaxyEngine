using Application.Commands.FrontCategory.UpdateCommand;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.DTOs
{
    public class UpdateFrontCategoryDto : IMapWith<UpdateFrontCategoryCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFrontCategoryDto, UpdateFrontCategoryCommand>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
