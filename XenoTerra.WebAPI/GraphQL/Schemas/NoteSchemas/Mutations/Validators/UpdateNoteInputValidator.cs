﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Mutations.Validators
{
    public class UpdateNoteInputValidator : AbstractValidator<UpdateNoteInput>
    {
        public UpdateNoteInputValidator()
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
