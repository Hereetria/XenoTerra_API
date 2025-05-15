using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Auth.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Auth.Validators
{
    public class LoginInputValidator : AbstractValidator<LoginInput>
    {
        public LoginInputValidator()
        {
            RuleFor(x => x.Identity)
                .NotEmpty().WithMessage("Email, phone number, or username is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
