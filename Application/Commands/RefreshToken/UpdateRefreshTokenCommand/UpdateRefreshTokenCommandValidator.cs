using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RefreshToken.UpdateRefreshTokenCommand
{
    public class UpdateRefreshTokenCommandValidator : AbstractValidator<UpdateRefreshTokenCommand>
    {
        public UpdateRefreshTokenCommandValidator()
        {
            RuleFor(x => x.ToLife).NotNull().GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Token).NotEqual(Guid.Empty);
        }
    }
}
