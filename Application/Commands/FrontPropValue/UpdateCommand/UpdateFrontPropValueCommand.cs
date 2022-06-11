using MediatR;
using System;

namespace Application.Commands.FrontPropValue.UpdateCommand
{
    public class UpdateFrontPropValueCommand : IRequest<Unit>
    {
        public Guid PropValueID { get; set; }
        public string Value { get; set; }
    }
}
