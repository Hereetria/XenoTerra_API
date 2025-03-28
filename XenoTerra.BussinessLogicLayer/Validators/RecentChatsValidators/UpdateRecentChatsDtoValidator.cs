using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.RecentChatsValidators
{
    public class UpdateRecentChatsDtoValidator : AbstractValidator<UpdateRecentChatsDto>
    {
        public UpdateRecentChatsDtoValidator()
        {
            RuleFor(x => x.RecentChatsId)
                .NotEmpty()
                .WithMessage("RecentChatsId must not be empty.");

            RuleFor(x => x.LastMessage)
                .NotEmpty()
                .WithMessage("LastMessage must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.LastMessageAt)
                .NotEmpty()
                .WithMessage("LastMessageAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("LastMessageAt cannot be in the future.");
        }
    }
}
