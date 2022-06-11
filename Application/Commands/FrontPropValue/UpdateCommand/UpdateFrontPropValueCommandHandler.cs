using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.FrontPropValue.UpdateCommand
{
    public class UpdateFrontPropValueCommandHandler : IRequestHandler<UpdateFrontPropValueCommand, Unit>
    {
        private readonly IDBContext _dbContext;

        public UpdateFrontPropValueCommandHandler(IDBContext dbContext) =>
            _dbContext = dbContext;

        public Task<Unit> Handle(UpdateFrontPropValueCommand request,
            CancellationToken cancellationToken)
        {

            var entity = _dbContext.FrontPropValues.FirstOrDefault(x => x.Id == request.PropValueID);

            if (entity == null)
            {
                throw new NotFoundException("FrontPropValue", entity.Id);
            }

            entity.Value = request.Value;

            _dbContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }

}
