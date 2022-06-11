using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.FrontGlobalSettings.UpdateCommand
{
    public class UpdateGlobalSettingCommandHandler : IRequestHandler<UpdateGlobalSettingCommand, Unit>
    {
        private readonly IDBContext _dbContext;

        public UpdateGlobalSettingCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateGlobalSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.FrontGlobalSettings.FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException("Front global setting", request.Id);
            }

            entity.Value = request.Value;

            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
