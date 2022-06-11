using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontCategory.GetFrontCategories
{
    public class GetFrontCategoryListQueryHandler : IRequestHandler<GetFrontCategoryListQuery, FrontCategoryListVm>
    {
        private readonly IDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetFrontCategoryListQueryHandler(IDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task<FrontCategoryListVm> Handle(GetFrontCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _dBContext.FrontCategories.ProjectTo<FrontCategoryLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new FrontCategoryListVm()
            {
                Categories = categories
            };
        }
    }
}
