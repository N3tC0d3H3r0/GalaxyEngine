using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontBaseComponent.GetFrontBaseComponents
{
    public class GetFrontBaseComponentQueryListHandler : IRequestHandler<GetFrontBaseComponentListQuery, FrontBaseComponentListVm>
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetFrontBaseComponentQueryListHandler(IDBContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FrontBaseComponentListVm> Handle(GetFrontBaseComponentListQuery request, CancellationToken cancellationToken)
        {
            return new FrontBaseComponentListVm
            {
                FrontBaseComponents = await _dbContext.FrontBaseComponents
                                                       .ProjectTo<FrontBaseComponentLookupDto>(_mapper.ConfigurationProvider)
                                                       .ToListAsync(cancellationToken)
            };
        }
    }

}
