using FluentValidation;
using Microsoft.AspNetCore.Identity;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Auth.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Auth.Validators
{
    public class RegisterInputValidator : AbstractValidator<RegisterInput>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterInputValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(50)
                .MustAsync(BeUniqueUsername)
                .WithMessage("A user with this username already exists.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MustAsync(BeUniqueEmail)
                .WithMessage("A user with this email already exists.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords must match.");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(dateStr =>
                {
                    if (DateOnly.TryParse(dateStr, out var date))
                        return date <= DateOnly.FromDateTime(DateTime.UtcNow);
                    return false;
                })
                .WithMessage("Birth date cannot be in the future and must be a valid date.");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }

        private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return await _userManager.FindByNameAsync(username) == null;
        }
    }
}
