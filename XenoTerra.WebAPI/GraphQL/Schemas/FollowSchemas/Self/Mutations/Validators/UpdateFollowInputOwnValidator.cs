﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Validators
{
    public class UpdateFollowInputOwnValidator : AbstractValidator<UpdateFollowOwnInput>
    {
        public UpdateFollowInputOwnValidator()
        {
            RuleFor(x => x.FollowId)
                .NotEmpty().WithMessage("FollowId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("FollowId must be a valid GUID.");

            When(x => x.FollowingId is not null, () =>
            {
                RuleFor(x => x.FollowingId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("FollowingId must be a valid GUID.");
            });
        }
    }
}
