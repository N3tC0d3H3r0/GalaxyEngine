using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontCategory.ChangeActiveStateCommand
{
    public class ChangeActiveStateFrontCategoryCommandValidator : AbstractValidator <ChangeActiveStateFrontCategoryCommand>
    {
        public ChangeActiveStateFrontCategoryCommandValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
            RuleFor(c => c.IsActive).NotNull();
        }
    }
}
