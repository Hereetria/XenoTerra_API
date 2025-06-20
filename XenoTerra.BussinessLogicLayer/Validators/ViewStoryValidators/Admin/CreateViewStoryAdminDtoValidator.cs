using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DTOLayer.Dtos.ViewStoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ViewStoryValidators.Admin
{
    public class CreateViewStoryAdminDtoValidator : AbstractValidator<CreateViewStoryAdminDto>
    {
        public CreateViewStoryAdminDtoValidator(IExistenceChecker<ViewStory, CreateViewStoryAdminDto> existenceChecker)
        {
            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.ViewedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Viewed time cannot be in the future.");

            RuleFor(x => x)
            .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.UserId,
                        x => x.StoryId
                    ))
                .WithMessage("This story has already been viewed by the same user.");
        }
    }
}
