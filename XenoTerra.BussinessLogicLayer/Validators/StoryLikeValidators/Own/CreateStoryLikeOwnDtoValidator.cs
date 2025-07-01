using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryLikeValidators.Own
{
    public class CreateStoryLikeOwnDtoValidator : AbstractValidator<CreateStoryLikeOwnDto>
    {
        public CreateStoryLikeOwnDtoValidator(IExistenceChecker<StoryLike, CreateStoryLikeOwnDto> existenceChecker)
        {
            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.LikedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Liked time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.UserId,
                        x => x.StoryId
                    ))
                .WithMessage("This story is already liked by the same user.");
        }
    }
}
