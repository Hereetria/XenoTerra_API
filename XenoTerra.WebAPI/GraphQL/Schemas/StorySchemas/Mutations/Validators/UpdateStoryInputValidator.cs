﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations.Validators
{
    public class UpdateStoryInputValidator : AbstractValidator<UpdateStoryInput>
    {
        public UpdateStoryInputValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
