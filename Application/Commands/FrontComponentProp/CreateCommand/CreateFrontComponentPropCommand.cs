using MediatR;
using System;

namespace Application.Commands.FrontComponentProp.CreateCommand
{
    public class CreateFrontComponentPropCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public bool CanBeHidden { get; set; }
        public string Type { get; set; }
        public Guid BaseComponentId { get; set; }
    }
}
