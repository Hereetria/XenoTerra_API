using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.RecentChatsValidators.Admin
{
    public class UpdateRecentChatsAdminDtoValidator : AbstractValidator<UpdateRecentChatsAdminDto>
    {
        public UpdateRecentChatsAdminDtoValidator()
        {
            RuleFor(x => x.RecentChatsId)
                .NotEqual(Guid.Empty)
                .WithMessage("RecentChats ID is required.");

            RuleFor(x => x.LastMessage)
                .NotEmpty()
                .WithMessage("Last message cannot be empty.")
                .MaximumLength(500)
                .WithMessage("Last message cannot exceed 500 characters.")
                .When(x => x.LastMessage is not null);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.")
                .When(x => x.UserId is not null);

            RuleFor(x => x.LastMessageAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Last message time cannot be in the future.")
                .When(x => x.LastMessageAt is not null);
        }
    }
}
