﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Mutations.Validators
{
    public class CreatePostLikeInputAdminValidator : AbstractValidator<CreatePostLikeAdminInput>
    {
        public CreatePostLikeInputAdminValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
