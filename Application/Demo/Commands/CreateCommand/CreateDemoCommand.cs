using MediatR;
using System;

namespace Application.Demo.Commands.CreateCommand
{
    public class CreateDemoCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
    }
}
