﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Validators
{
    public class UpdateSearchHistoryInputAdminValidator : AbstractValidator<UpdateSearchHistoryAdminInput>
    {
        public UpdateSearchHistoryInputAdminValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEmpty().WithMessage("SearchHistoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("SearchHistoryId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
