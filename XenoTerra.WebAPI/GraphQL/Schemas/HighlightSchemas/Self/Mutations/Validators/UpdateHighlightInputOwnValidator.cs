﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Mutations.Validators
{
    public class UpdateHighlightInputOwnValidator : AbstractValidator<UpdateHighlightOwnInput>
    {
        public UpdateHighlightInputOwnValidator()
        {
            RuleFor(x => x.HighlightId)
                .NotEmpty().WithMessage("HighlightId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("HighlightId must be a valid GUID.");
        }
    }
}
