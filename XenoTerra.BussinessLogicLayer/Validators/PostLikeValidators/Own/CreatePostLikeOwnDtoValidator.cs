using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.PostLikeValidators.Own
{
    public class CreatePostLikeOwnDtoValidator : AbstractValidator<CreatePostLikeOwnDto>
    {
        public CreatePostLikeOwnDtoValidator(IExistenceChecker<PostLike, CreatePostLikeOwnDto> existenceChecker)
        {
            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                    .WithMessage("Post ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.LikedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Liked time cannot be in the future.");

            RuleFor(x => x)
            .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(dto, null, x => x.PostId, x => x.UserId))
                .WithMessage("This post like already exists.");
        }
    }
}
