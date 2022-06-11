using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontBaseComponent.CreateCommand
{
    public class CreateFrontBaseComponentCommandValidator : AbstractValidator<CreateFrontBaseComponentCommand>
    {
        public CreateFrontBaseComponentCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
