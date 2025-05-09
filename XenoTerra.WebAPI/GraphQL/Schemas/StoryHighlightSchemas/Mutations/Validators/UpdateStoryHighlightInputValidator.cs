﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Validators
{
    public class UpdateStoryHighlightInputValidator : AbstractValidator<UpdateStoryHighlightInput>
    {
        public UpdateStoryHighlightInputValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            When(x => x.HighlightId is not null, () =>
            {
                RuleFor(x => x.HighlightId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("HighlightId must be a valid GUID.");
            });
        }
    }
}
