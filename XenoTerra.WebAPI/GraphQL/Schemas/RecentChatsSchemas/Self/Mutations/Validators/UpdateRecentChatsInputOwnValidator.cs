﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Validators
{
    public class UpdateRecentChatsInputOwnValidator : AbstractValidator<UpdateRecentChatsOwnInput>
    {
        public UpdateRecentChatsInputOwnValidator()
        {
            RuleFor(x => x.RecentChatsId)
                .NotEmpty().WithMessage("RecentChatsId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("RecentChatsId must be a valid GUID.");

            When(x => x.LastMessageAt is not null, () =>
            {
                RuleFor(x => x.LastMessageAt)
                    .Must(ValidationHelper.BeValidDate).WithMessage("LastMessageAt must be a valid date.")
                    .Must(ValidationHelper.BeInPast).WithMessage("LastMessageAt cannot be in the future.");
            });
        }
    }
}
