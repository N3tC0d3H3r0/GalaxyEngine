using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontGlobalSettings.UpdateCommand
{
    public class UpdateGlobalSettingCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
