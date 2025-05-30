﻿using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Validators
{
    public class CreateMessageInputAdminValidator : AbstractValidator<CreateMessageAdminInput>
    {
        public CreateMessageInputAdminValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content must not be empty.");

            RuleFor(x => x.SenderId)
                .NotEmpty().WithMessage("SenderId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("SenderId must be a valid GUID.");

            RuleFor(x => x.ReceiverId)
                .NotEmpty().WithMessage("ReceiverId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReceiverId must be a valid GUID.");
        }
    }
}
