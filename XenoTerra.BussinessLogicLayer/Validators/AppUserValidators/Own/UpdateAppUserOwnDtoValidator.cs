using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.AppUserValidators.Own
{
    using FluentValidation;

    public class UpdateAppUserOwnDtoValidator : AbstractValidator<UpdateAppUserOwnDto>
    {
        public UpdateAppUserOwnDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id is required.");

            RuleFor(x => x.UserName)
                .Matches("^[a-z0-9_.]+$")
                .When(x => !string.IsNullOrEmpty(x.UserName))
                .WithMessage("User name must be lowercase and can only contain letters, numbers, underscores (_) and dots (.) without spaces.");

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters.")
                .Matches("[A-Z]").When(x => !string.IsNullOrEmpty(x.Password)).WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").When(x => !string.IsNullOrEmpty(x.Password)).WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[^a-zA-Z0-9]").When(x => !string.IsNullOrEmpty(x.Password)).WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Invalid email format.");

            RuleFor(x => x.FullName)
                .MaximumLength(100)
                .When(x => !string.IsNullOrEmpty(x.FullName))
                .WithMessage("Full name must be less than 100 characters.");

            RuleFor(x => x.Bio)
                .MaximumLength(300)
                .When(x => !string.IsNullOrEmpty(x.Bio))
                .WithMessage("Bio must be less than 300 characters.");

            RuleFor(x => x.ProfilePicture)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.ProfilePicture))
                .WithMessage("Profile picture must be a valid URL.");

            RuleFor(x => x.Website)
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.Website))
                .WithMessage("Website must be a valid URL.");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Today.AddDays(1))
                .When(x => x.BirthDate.HasValue)
                .WithMessage("Birth date must be earlier than today.");
        }
    }

}
