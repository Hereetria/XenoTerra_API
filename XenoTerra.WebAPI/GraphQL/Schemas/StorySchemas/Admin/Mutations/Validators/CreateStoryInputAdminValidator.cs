﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Validators
{
    public class CreateStoryInputAdminValidator : AbstractValidator<CreateStoryAdminInput>
    {
        public CreateStoryInputAdminValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty().WithMessage("Path must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
