using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.FrontCategory.ChangeActiveStateCommand
{
    public class ChangeActiveStateFrontCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
