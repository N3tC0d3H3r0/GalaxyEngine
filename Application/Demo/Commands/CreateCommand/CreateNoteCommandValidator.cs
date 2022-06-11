using FluentValidation;
using System;

namespace Application.Demo.Commands.CreateCommand
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateDemoCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createCommand =>
                createCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createCommand =>
                createCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
