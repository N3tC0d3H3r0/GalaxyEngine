using Application.Commands.FrontPage.CreateCommand;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.Models
{
    public class CreateFrontPageDto : IMapWith<CreateFrontPageCommand>
    {
        public string Name { get; set; }
        public string Route { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFrontPageDto, CreateFrontPageCommand>()
                   .ForMember(option => option.Name, dest => dest.MapFrom(src => src.Name))
                   .ForMember(option => option.Route, dest => dest.MapFrom(src => src.Route));
        }
    }
}
