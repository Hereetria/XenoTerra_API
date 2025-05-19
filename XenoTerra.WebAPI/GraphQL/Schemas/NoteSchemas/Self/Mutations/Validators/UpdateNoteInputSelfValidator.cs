using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Mutations.Validators
{
    public class UpdateNoteInputSelfValidator : AbstractValidator<UpdateNoteSelfInput>
    {
        public UpdateNoteInputSelfValidator()
        {
            RuleFor(x => x.NoteId)
                .NotEmpty().WithMessage("NoteId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("NoteId must be a valid GUID.");
        }
    }
}
