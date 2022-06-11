using MediatR;
using System;

namespace Application.Commands.FrontPropValue.CreateCommand
{
    public class CreateFrontPropValueCommand : IRequest<Guid>
    {
        public Guid ComponentId { get; set; }
        public Guid PropId { get; set; }
        public string Value { get; set; }
    }
}
