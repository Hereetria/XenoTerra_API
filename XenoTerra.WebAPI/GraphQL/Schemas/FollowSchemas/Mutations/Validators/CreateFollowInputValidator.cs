﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Mutations.Validators
{
    public class CreateFollowInputValidator : AbstractValidator<CreateFollowInput>
    {
        public CreateFollowInputValidator()
        {
            RuleFor(x => x.FollowerId)
                .NotEmpty().WithMessage("FollowerId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("FollowerId must be a valid GUID.");

            RuleFor(x => x.FollowingId)
                .NotEmpty().WithMessage("FollowingId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("FollowingId must be a valid GUID.");
        }
    }
}
