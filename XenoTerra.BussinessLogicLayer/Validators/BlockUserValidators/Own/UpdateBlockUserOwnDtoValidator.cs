using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.BlockUserValidators.Own
{
    public class UpdateBlockUserOwnDtoValidator : AbstractValidator<UpdateBlockUserOwnDto>
    {
        public UpdateBlockUserOwnDtoValidator(IExistenceChecker<BlockUser, UpdateBlockUserOwnDto> existenceChecker)
        {
            RuleFor(x => x.BlockUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Block user ID is required.");

            RuleFor(x => x.BlockingUserId)
                .NotEqual(Guid.Empty)
                .When(x => x.BlockingUserId.HasValue)
                .WithMessage("Blocking user ID cannot be empty.");

            RuleFor(x => x.BlockedUserId)
                .NotEqual(Guid.Empty)
                .When(x => x.BlockedUserId.HasValue)
                .WithMessage("Blocked user ID cannot be empty.");

            RuleFor(x => x.BlockingUserId)
                .NotEqual(x => x.BlockedUserId)
                .WithMessage("A user cannot block themselves.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellation) =>
                    !await existenceChecker.ExistsAsync(dto, x => x.BlockUserId, x => x.BlockingUserId, x => x.BlockedUserId))
                .WithMessage("This block already exists.");
        }
    }
}
