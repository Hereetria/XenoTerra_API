using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ViewStoryValidators.Own
{
    public class UpdateViewStoryOwnDtoValidator : AbstractValidator<UpdateViewStoryOwnDto>
    {
        public UpdateViewStoryOwnDtoValidator(IExistenceChecker<ViewStory, UpdateViewStoryOwnDto> existenceChecker)
        {
            RuleFor(x => x.ViewStoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("View story ID is required.");

            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.")
                .When(x => x.StoryId is not null);

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.ViewStoryId,
                        x => x.UserId,
                        x => x.StoryId
                    ))
                .WithMessage("This story has already been viewed by the same user.");
        }
    }
}
