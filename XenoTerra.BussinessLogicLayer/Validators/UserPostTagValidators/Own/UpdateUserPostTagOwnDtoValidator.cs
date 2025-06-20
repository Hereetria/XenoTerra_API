using FluentValidation;
using XenoTerra.DTOLayer.Dtos.UserPostTagAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.UserPostTagValidators.Own
{
    public class UpdateUserPostTagOwnDtoValidator : AbstractValidator<UpdateUserPostTagOwnDto>
    {
        public UpdateUserPostTagOwnDtoValidator()
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
