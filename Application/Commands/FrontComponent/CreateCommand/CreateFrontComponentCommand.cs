using MediatR;
using System;

namespace Application.Commands.FrontComponent.CreateCommand
{
    public class CreateFrontComponentCommand : IRequest<Guid>
    {
        public Guid BaseComponentId { get; set; }
        public Guid PageId { get; set; }
        public int DispayIndex { get; set; }
    }
}
