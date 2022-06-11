using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontPropValue.GetFrontPropValueByComponent
{
    public class GetFrontPropValuesByComponentQueryHandler : IRequestHandler<GetFrontPropValuesByComponentQuery, GetFrontPropValueListVm>
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetFrontPropValuesByComponentQueryHandler(IDBContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetFrontPropValueListVm> Handle(GetFrontPropValuesByComponentQuery request, CancellationToken cancellationToken)
        {
            return new GetFrontPropValueListVm
            {
                PropValues = await _dbContext.FrontPropValues
                                                         .Where(x => x.ComponentId == request.ComponentId)
                                                         .ProjectTo<GetFrontPropValueListDto>(_mapper.ConfigurationProvider)
                                                         .ToListAsync(cancellationToken)
            };
        }
    }
}