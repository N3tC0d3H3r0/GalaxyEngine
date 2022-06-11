using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontComponent.CreateCommand
{
    internal class CreateFrontComponentCommandValidator : AbstractValidator<CreateFrontComponentCommand>
    {
        public CreateFrontComponentCommandValidator()
        {
            RuleFor(c => c.BaseComponentId).NotEqual(Guid.Empty);
            RuleFor(c => c.DispayIndex).NotNull();
            RuleFor(c => c.PageId).NotEqual(Guid.Empty);
        }
    }
}
