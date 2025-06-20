using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.SavedPostValidators.Admin
{
    public class UpdateSavedPostAdminDtoValidator : AbstractValidator<UpdateSavedPostAdminDto>
    {
        public UpdateSavedPostAdminDtoValidator()
        {
            RuleFor(x => x.SavedPostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Saved post ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.")
                .When(x => x.UserId is not null);

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.")
                .When(x => x.PostId is not null);
        }
    }
}
