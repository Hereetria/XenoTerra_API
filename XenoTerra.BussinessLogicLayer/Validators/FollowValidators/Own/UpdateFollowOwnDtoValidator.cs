using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.FollowValidators.Own
{
    public class UpdateFollowOwnDtoValidator : AbstractValidator<UpdateFollowOwnDto>
    {
        public UpdateFollowOwnDtoValidator(IExistenceChecker<Follow, UpdateFollowOwnDto> existenceChecker)
        {
            RuleFor(x => x.FollowId)
                .NotEqual(Guid.Empty)
                .WithMessage("Follow ID is required.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.FollowId,
                        x => x.FollowerId,
                        x => x.FollowingId
                    ))
                .WithMessage("This follow relationship already exists.");
        }
    }
}
