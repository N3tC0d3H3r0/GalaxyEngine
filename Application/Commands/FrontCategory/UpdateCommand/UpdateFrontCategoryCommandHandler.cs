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

namespace Application.Commands.FrontCategory.UpdateCommand
{
    public class UpdateFrontCategoryCommandHandler : IRequestHandler<UpdateFrontCategoryCommand, Unit>
    {
        private readonly IDBContext _dbContext;

        public UpdateFrontCategoryCommandHandler(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateFrontCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _dbContext.FrontCategories.FirstOrDefault(x=>x.Id == request.Id);

            if (category == null)
            {
                throw new NotFoundException("FrontCategory", request.Id);
            }

            if (_dbContext.FrontCategories.Any(x=>x.Name.ToLower() == request.Name.ToLower() && x.Id != request.Id))
            {
                throw new AlreadyExistsException("FrontCategory", request.Name);
            } 

            category.Name = request.Name;

          //  _dbContext.Entry(category).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
