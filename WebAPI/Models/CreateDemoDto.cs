using Application.Common.Mappings;
using Application.Demo.Commands.CreateCommand;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CreateDemoDto : IMapWith<CreateDemoCommand>
    {
        [Required]
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDemoDto, CreateDemoCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title));
        }
    }
}
