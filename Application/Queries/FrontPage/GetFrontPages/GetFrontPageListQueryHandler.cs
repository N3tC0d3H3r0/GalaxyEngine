using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontPage.GetFrontPages
{
    public class GetFrontPageListQueryHandler : IRequestHandler<GetFrontPageListQuery, GetFrontPageListVm>
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetFrontPageListQueryHandler(IDBContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetFrontPageListVm> Handle(GetFrontPageListQuery request, CancellationToken cancellationToken)
        {
            return new GetFrontPageListVm
            {
                Pages = await _dbContext.FrontPages
                                                         .ProjectTo<GetFrontPageLookupDto>(_mapper.ConfigurationProvider)
                                                         .ToListAsync(cancellationToken)
            };
        }
    }

}
