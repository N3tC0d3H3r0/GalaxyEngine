using FluentValidation;
using System;

namespace Application.Demo.Queries.GetDemos
{
    public class GetNoteListQueryValidator : AbstractValidator<GetDemoListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(x => x.UserID).NotEqual(Guid.Empty);
        }
    }
}
