using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.UserValidators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName must not be empty.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("FullName must not be empty.");

            RuleFor(x => x.Bio)
                .NotEmpty()
                .WithMessage("Bio must not be empty.");

            RuleFor(x => x.ProfilePicture)
                .NotEmpty()
                .WithMessage("ProfilePicture must not be empty.");

            RuleFor(x => x.Website)
                .NotEmpty()
                .WithMessage("Website must not be empty.");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("BirthDate cannot be in the future.");
        }
    }
}
