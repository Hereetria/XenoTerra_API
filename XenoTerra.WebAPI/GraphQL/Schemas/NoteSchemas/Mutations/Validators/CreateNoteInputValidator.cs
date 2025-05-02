using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Validators
{
    public class CreateNoteInputValidator : AbstractValidator<CreateNoteInput>
    {
        public CreateNoteInputValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Text must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
