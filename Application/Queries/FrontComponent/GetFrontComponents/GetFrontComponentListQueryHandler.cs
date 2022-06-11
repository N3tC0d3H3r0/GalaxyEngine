using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.FrontComponent.GetFrontComponents
{
    public class GetFrontComponentListQueryHandler : IRequestHandler<GetFrontComponentListQuery, GetFrontComponentListVm>
    {
        private readonly IDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetFrontComponentListQueryHandler(IDBContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GetFrontComponentListVm> Handle(GetFrontComponentListQuery request, CancellationToken cancellationToken)
        {
            var components = await _dbContext.FrontComponents
                                             .Include(x => x.BaseComponent)
                                             .Include(x => x.Page) 
                                             .Where(x=>x.Page.Route.ToLower() == request.Route.ToLower())
                                             .ProjectTo<GetFrontComponentListDto>(_mapper.ConfigurationProvider)
                                             .ToListAsync(cancellationToken);


            return new GetFrontComponentListVm
            {
                Components = components
            };
        }
    }
}
