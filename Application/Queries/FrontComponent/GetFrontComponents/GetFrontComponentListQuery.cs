using MediatR;

namespace Application.Queries.FrontComponent.GetFrontComponents
{
    public class GetFrontComponentListQuery : IRequest<GetFrontComponentListVm>
    {
        public string Route { get; set; }
    }
}
