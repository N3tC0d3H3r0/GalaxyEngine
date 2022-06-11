using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontCategory.UpdateCommand
{
    public class UpdateFrontCategoryCommandValidator : AbstractValidator<UpdateFrontCategoryCommand>
    {
        public UpdateFrontCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
