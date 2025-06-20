using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryLikeValidators.Own
{
    public class UpdateStoryLikeOwnDtoValidator : AbstractValidator<UpdateStoryLikeOwnDto>
    {
        public UpdateStoryLikeOwnDtoValidator(IExistenceChecker<StoryLike, UpdateStoryLikeOwnDto> existenceChecker)
        {
            RuleFor(x => x.StoryLikeId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story like ID is required.");

            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.");

            RuleFor(x => x.LikedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Liked time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.StoryLikeId,
                        x => x.UserId,
                        x => x.StoryId
                    ))
                .WithMessage("This story is already liked by the same user.");
        }
    }
}
