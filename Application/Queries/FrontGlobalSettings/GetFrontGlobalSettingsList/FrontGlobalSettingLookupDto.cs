using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.FrontGlobalSettings.GetFrontGlobalSettingsList
{
    public class FrontGlobalSettingLookupDto : IMapWith<Domain.FrontGlobalSetting>
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.FrontGlobalSetting, FrontGlobalSettingLookupDto>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
