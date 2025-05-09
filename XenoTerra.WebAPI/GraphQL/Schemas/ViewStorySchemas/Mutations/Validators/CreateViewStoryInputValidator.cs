﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Validators
{
    public class CreateViewStoryInputValidator : AbstractValidator<CreateViewStoryInput>
    {
        public CreateViewStoryInputValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
