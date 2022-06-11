using MediatR;
using System;

namespace Application.Commands.FrontPage.CreateCommand
{
    public class CreateFrontPageCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Route { get; set; }
    }
}
