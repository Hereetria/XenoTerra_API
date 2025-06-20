using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.BlockUserAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.BlockUserValidators.Admin
{
    public class CreateBlockUserAdminDtoValidator : AbstractValidator<CreateBlockUserAdminDto>
    {
        public CreateBlockUserAdminDtoValidator(IExistenceChecker<BlockUser, CreateBlockUserAdminDto> existenceChecker)
        {
            RuleFor(x => x.BlockingUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Blocking user ID is required.");

            RuleFor(x => x.BlockedUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Blocked user ID is required.");

            RuleFor(x => x.BlockedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Blocked time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellation) =>
                    !await existenceChecker.ExistsAsync(dto, null, x => x.BlockingUserId, x => x.BlockedUserId))
                .WithMessage("This block already exists.");
        }
    }
}
