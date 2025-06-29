﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.RecentChatsAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.RecentChatsValidators.Own
{
    public class CreateRecentChatsOwnDtoValidator : AbstractValidator<CreateRecentChatsOwnDto>
    {
        public CreateRecentChatsOwnDtoValidator()
        {
            RuleFor(x => x.LastMessage)
                .NotEmpty()
                .WithMessage("Last message is required.")
                .MaximumLength(500)
                .WithMessage("Last message cannot exceed 500 characters.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.LastMessageAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Last message time cannot be in the future.");
        }
    }
}
