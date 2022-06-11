using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.FrontCategory.CreateCommand
{
    public class CreateFrontCategoryCommandHandler : IRequestHandler<CreateFrontCategoryCommand, Guid>
    {
        private readonly IDBContext _dbContext;

        public CreateFrontCategoryCommandHandler(IDBContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFrontCategoryCommand request,
                                       CancellationToken cancellationToken)
        {
            var category =_dbContext.FrontCategories.FirstOrDefault(
                                     x => x.Name.ToLower() == request.Name.ToLower());
            
            if (category != null)
            {
                throw new AlreadyExistsException("FrontCategory", category.Name);
            }

            var entity = new Domain.FrontCategory
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsDeleted = false,
                IsActive = true,
            };

            _dbContext.FrontCategories.Add(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
