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

namespace Application.Commands.FrontCategory.ChangeActiveStateCommand
{
    public class ChangeActiveStateFrontCategoryCommandHandler : IRequestHandler<ChangeActiveStateFrontCategoryCommand, Unit>
    {
        private readonly IDBContext _dBContext;

        public ChangeActiveStateFrontCategoryCommandHandler(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Unit> Handle(ChangeActiveStateFrontCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _dBContext.FrontCategories.FirstOrDefault(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException("Front category", entity.Id);
            }

            entity.IsActive = request.IsActive;

            _dBContext.Entry(entity).State = EntityState.Modified;

            await _dBContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
