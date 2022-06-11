using MediatR;
using System;

namespace Application.Demo.Queries.GetDemos
{
    public class GetDemoListQuery : IRequest<DemoListVM>
    {
        public Guid UserID { get; set; }
    }
}
