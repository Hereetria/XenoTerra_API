using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.FollowValidators.Admin
{
    public class UpdateFollowAdminDtoValidator : AbstractValidator<UpdateFollowAdminDto>
    {
        public UpdateFollowAdminDtoValidator(IExistenceChecker<Follow, UpdateFollowAdminDto> existenceChecker)
        {
            RuleFor(x => x.FollowId)
                .NotEqual(Guid.Empty)
                .WithMessage("Follow ID is required.");

            RuleFor(x => x.FollowerId)
                .NotEqual(Guid.Empty)
                .When(x => x.FollowerId.HasValue)
                .WithMessage("Follower ID cannot be empty.");

            RuleFor(x => x.FollowingId)
                .NotEqual(Guid.Empty)
                .When(x => x.FollowingId.HasValue)
                .WithMessage("Following ID cannot be empty.");

            RuleFor(x => x.FollowerId)
                .NotEqual(x => x.FollowingId)
                .When(x => x.FollowerId.HasValue && x.FollowingId.HasValue)
                .WithMessage("A user cannot follow themselves.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.FollowId,
                        x => x.FollowerId!,
                        x => x.FollowingId!
                    ))
                .WithMessage("This follow relationship already exists.");
        }
    }
}
