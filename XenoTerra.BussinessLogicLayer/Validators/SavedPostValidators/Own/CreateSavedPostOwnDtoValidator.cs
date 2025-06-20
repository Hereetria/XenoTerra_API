using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.SavedPostValidators.Own
{
    public class CreateSavedPostOwnDtoValidator : AbstractValidator<CreateSavedPostOwnDto>
    {
        public CreateSavedPostOwnDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.");

            RuleFor(x => x.SavedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Saved time cannot be in the future.");
        }
    }
}
