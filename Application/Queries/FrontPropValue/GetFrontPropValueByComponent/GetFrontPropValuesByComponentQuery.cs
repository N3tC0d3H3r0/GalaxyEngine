using MediatR;
using System;

namespace Application.Queries.FrontPropValue.GetFrontPropValueByComponent
{
    public class GetFrontPropValuesByComponentQuery : IRequest<GetFrontPropValueListVm>
    {
        public Guid ComponentId { get; set; }
    }
}
