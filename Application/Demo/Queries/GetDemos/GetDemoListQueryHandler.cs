using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Demo.Queries.GetDemos
{
    public class GetDemoListQueryHandler
       : IRequestHandler<GetDemoListQuery, DemoListVM>
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetDemoListQueryHandler(IDBContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DemoListVM> Handle(GetDemoListQuery request,
            CancellationToken cancellationToken)
        {
            var demoQuery = await _dbContext.Demos
                .ProjectTo<DemoLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DemoListVM { Demos = demoQuery };
        }
    }
}
