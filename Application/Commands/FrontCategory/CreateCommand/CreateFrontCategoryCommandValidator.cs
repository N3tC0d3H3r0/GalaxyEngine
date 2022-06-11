using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontCategory.CreateCommand
{
    public class CreateFrontCategoryCommandValidator : AbstractValidator<CreateFrontCategoryCommand>
    {
        public CreateFrontCategoryCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
