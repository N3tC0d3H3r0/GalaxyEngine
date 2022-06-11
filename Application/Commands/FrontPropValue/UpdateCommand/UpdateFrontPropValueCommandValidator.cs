using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontPropValue.UpdateCommand
{
    public class UpdateFrontPropValueCommandValidator : AbstractValidator<UpdateFrontPropValueCommand>
    {
        public UpdateFrontPropValueCommandValidator()
        {
            RuleFor(c => c.PropValueID).NotEqual(Guid.Empty);
            RuleFor(c => c.Value).NotEmpty();
        }
    }
}
