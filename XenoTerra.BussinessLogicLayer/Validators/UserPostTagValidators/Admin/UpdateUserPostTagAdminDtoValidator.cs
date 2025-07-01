using FluentValidation;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.UserPostTagValidators.Admin
{
    public class UpdateUserPostTagAdminDtoValidator : AbstractValidator<UpdateUserPostTagAdminDto>
    {
        public UpdateUserPostTagAdminDtoValidator()
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
