using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontComponentProp.CreateCommand
{
    public class CreateFrontComponentPropCommandValidator : AbstractValidator<CreateFrontComponentPropCommand>
    {
        public CreateFrontComponentPropCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.BaseComponentId).NotEqual(Guid.Empty);
        }
    }
}
