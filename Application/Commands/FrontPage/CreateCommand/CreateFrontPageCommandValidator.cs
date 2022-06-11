using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontPage.CreateCommand
{
    public class CreateFrontPageCommandValidator : AbstractValidator<CreateFrontPageCommand>
    {
        public CreateFrontPageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
