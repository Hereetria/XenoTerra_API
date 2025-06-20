﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Mutations.Validators
{
    public class CreateHighlightInputAdminValidator : AbstractValidator<CreateHighlightAdminInput>
    {
        public CreateHighlightInputAdminValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.");

            RuleFor(x => x.ProfilePicturePath)
                .NotEmpty().WithMessage("ProfilePicturePath must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.");
        }
    }
}
