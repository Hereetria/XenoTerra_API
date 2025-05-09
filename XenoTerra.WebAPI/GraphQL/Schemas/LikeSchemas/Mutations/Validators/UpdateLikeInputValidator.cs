﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Mutations.Validators
{
    public class UpdateLikeInputValidator : AbstractValidator<UpdateLikeInput>
    {
        public UpdateLikeInputValidator()
        {
            RuleFor(x => x.LikeId)
                .NotEmpty().WithMessage("LikeId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("LikeId must be a valid GUID.");

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
