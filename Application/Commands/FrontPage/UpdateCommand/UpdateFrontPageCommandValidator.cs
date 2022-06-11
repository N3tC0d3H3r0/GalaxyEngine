using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontPage.UpdateCommand
{
    public class UpdateFrontPageCommandValidator : AbstractValidator<UpdateFrontPageCommand>
    {
        public UpdateFrontPageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.CategoryId).NotEqual(Guid.Empty);
            RuleFor(x => x.IsActive).NotNull();
        }
    }
}
