using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.FrontCategory.GetFrontCategories
{
    public class FrontCategoryLookupDto : IMapWith<Domain.FrontCategory>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.FrontCategory, FrontCategoryLookupDto>()
                   .ForAllMembers(x => x.MapAtRuntime());
        }
    }
}
