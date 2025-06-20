using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.SavedPostValidators.Own
{
    public class UpdateSavedPostOwnDtoValidator : AbstractValidator<UpdateSavedPostOwnDto>
    {
        public UpdateSavedPostOwnDtoValidator()
        {
            RuleFor(x => x.SavedPostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Saved post ID is required.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.")
                .When(x => x.PostId is not null);
        }
    }
}
