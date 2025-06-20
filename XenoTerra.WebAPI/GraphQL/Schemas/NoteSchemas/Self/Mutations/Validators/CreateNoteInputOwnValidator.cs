using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Validators
{
    public class CreateNoteInputOwnValidator : AbstractValidator<CreateNoteOwnInput>
    {
        public CreateNoteInputOwnValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Text must not be empty.");
        }
    }
}
