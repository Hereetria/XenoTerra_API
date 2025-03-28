using FluentValidation;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.UserPostTagValidators
{
    public class UpdateUserPostTagDtoValidator : AbstractValidator<UpdateUserPostTagDto>
    {
        public UpdateUserPostTagDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("PostId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");
        }
    }
}
