using Application.Commands.FrontCategory.CreateCommand;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.FrontModels.DTOs
{
    public class CreateFrontCategoryDto : IMapWith<CreateFrontCategoryCommand>
    {
        public string Name { get; set; }
       
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFrontCategoryDto, CreateFrontCategoryCommand>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
