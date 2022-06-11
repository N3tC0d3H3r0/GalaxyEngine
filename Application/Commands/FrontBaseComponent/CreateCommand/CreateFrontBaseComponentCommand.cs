using MediatR;
using System;

namespace Application.Commands.FrontBaseComponent.CreateCommand
{
    public class CreateFrontBaseComponentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
