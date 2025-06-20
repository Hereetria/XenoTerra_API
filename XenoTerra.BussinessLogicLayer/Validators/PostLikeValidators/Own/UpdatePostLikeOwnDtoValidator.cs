using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.PostLikeAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.PostLikeValidators.Own
{
    public class UpdatePostLikeOwnDtoValidator : AbstractValidator<UpdatePostLikeOwnDto>
    {
        public UpdatePostLikeOwnDtoValidator(IExistenceChecker<PostLike, UpdatePostLikeOwnDto> existenceChecker)
        {
            RuleFor(x => x.PostLikeId)
                .NotEqual(Guid.Empty)
                .WithMessage("PostLike ID is required.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .When(x => x.PostId.HasValue)
                .WithMessage("Post ID cannot be empty.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                {
                    return !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.PostLikeId,
                        x => x.PostId,
                        x => x.UserId
                    );
                })
                .WithMessage("This post like already exists.");
        }
    }
}
