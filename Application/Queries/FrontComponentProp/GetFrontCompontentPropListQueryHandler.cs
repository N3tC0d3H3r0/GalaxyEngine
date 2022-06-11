using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontComponentProp
{
    public class GetFrontCompontentPropListQueryHandler : IRequestHandler<GetFrontComponentPropListQuery, GetFrontComponentPropListVm>
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetFrontCompontentPropListQueryHandler(IDBContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetFrontComponentPropListVm> Handle(GetFrontComponentPropListQuery request, CancellationToken cancellationToken)
        {
            return new GetFrontComponentPropListVm
            {
                Props = await _dbContext.FrontComponentProps.Where(x => x.BaseComponentId == request.BaseComponentId)
                                                         .ProjectTo<GetFrontComponentPropListDto>(_mapper.ConfigurationProvider)
                                                         .ToListAsync(cancellationToken)
            };
        }
    }
}
