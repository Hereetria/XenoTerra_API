using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Validators
{
    public class CreateNoteInputSelfValidator : AbstractValidator<CreateNoteSelfInput>
    {
        public CreateNoteInputSelfValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Text must not be empty.");
        }
    }
}
