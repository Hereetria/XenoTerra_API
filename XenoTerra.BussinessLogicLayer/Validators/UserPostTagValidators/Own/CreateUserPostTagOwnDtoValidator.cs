using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.UserPostTagValidators.Own
{
    public class CreateUserPostTagOwnDtoValidator : AbstractValidator<CreateUserPostTagOwnDto>
    {
        public CreateUserPostTagOwnDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");
        }
    }
}
