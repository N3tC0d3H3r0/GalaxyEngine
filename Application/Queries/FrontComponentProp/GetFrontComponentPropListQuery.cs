using MediatR;
using System;

namespace Application.Queries.FrontComponentProp
{
    public class GetFrontComponentPropListQuery : IRequest<GetFrontComponentPropListVm>
    {
        public Guid BaseComponentId { get; set; }
    }
}
