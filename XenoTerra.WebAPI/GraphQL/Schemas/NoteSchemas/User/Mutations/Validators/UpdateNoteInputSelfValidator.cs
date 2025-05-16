using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Mutations.Validators
{
    public class UpdateNoteInputSelfValidator : AbstractValidator<UpdateNoteSelfInput>
    {
        public UpdateNoteInputSelfValidator()
        {
            RuleFor(x => x.NoteId)
                .NotEmpty().WithMessage("NoteId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("NoteId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
