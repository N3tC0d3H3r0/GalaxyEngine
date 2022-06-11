using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RefreshToken.CreateRefreshTokenCommand
{
    public class CreateRefreshTokenCommandValidator : AbstractValidator<CreateRefreshTokenCommand>
    {
        public CreateRefreshTokenCommandValidator()
        {
            RuleFor(x => x.ToLife).NotNull().GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Token).NotEqual(Guid.Empty);
        }
    }
}
