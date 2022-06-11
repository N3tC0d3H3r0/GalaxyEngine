using Application.Models.AuthModels.VMs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.RefreshToken.GetRefreshToken
{
    public class GetRefreshTokenQueryValidator : AbstractValidator<RefreshTokenVm>
    {
        public GetRefreshTokenQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
