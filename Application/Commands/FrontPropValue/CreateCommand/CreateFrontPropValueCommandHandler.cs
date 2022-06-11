using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.FrontPropValue.CreateCommand
{
    internal class CreateFrontPropValueCommandHandler : IRequestHandler<CreateFrontPropValueCommand, Guid>
    {
        private readonly IDBContext _dbContext;

        public CreateFrontPropValueCommandHandler(IDBContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFrontPropValueCommand request,
            CancellationToken cancellationToken)
        {

            var prop = await _dbContext.FrontComponentProps.FirstOrDefaultAsync(x => x.Id == request.PropId, cancellationToken);

            if (prop == null)
            {
                throw new NotFoundException("CreatePropValue prop not found", request.PropId);
            }

            var entity = new Domain.FrontPropValue
            {
                ComponentId = request.ComponentId,
                Prop = prop,
                Value = request.Value
            };

            _dbContext.FrontPropValues.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}
