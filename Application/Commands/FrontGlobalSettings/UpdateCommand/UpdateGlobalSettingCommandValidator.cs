using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontGlobalSettings.UpdateCommand
{
    public class UpdateGlobalSettingCommandValidator : AbstractValidator<UpdateGlobalSettingCommand>
    {
        public UpdateGlobalSettingCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}
