using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Mutations.Validators
{
    public class CreateUserInputSelfValidator : AbstractValidator<CreateUserSelfInput>
    {
        public CreateUserInputSelfValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName must not be empty.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password must not be empty.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must not be empty.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName must not be empty.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("BirthDate must not be empty.")
                .Must(ValidationHelper.BeValidDate).WithMessage("BirthDate must be a valid date.")
                .Must(ValidationHelper.BeInPast).WithMessage("BirthDate cannot be in the future.");
        }
    }
}
