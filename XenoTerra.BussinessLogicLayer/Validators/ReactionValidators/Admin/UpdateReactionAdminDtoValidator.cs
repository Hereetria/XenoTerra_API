using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.ReactionValidators.Admin
{
    public class UpdateReactionAdminDtoValidator : AbstractValidator<UpdateReactionAdminDto>
    {
        public UpdateReactionAdminDtoValidator()
        {
            RuleFor(x => x.ReactionId)
                .NotEqual(Guid.Empty)
                .WithMessage("Reaction ID is required.");

            RuleFor(x => x.Payload)
                .MaximumLength(100)
                .WithMessage("Payload is too long.")
                .When(x => x.Payload is not null);

            RuleFor(x => x.MessageId)
                .NotEqual(Guid.Empty)
                .WithMessage("Message ID is required.")
                .When(x => x.MessageId.HasValue);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.")
                .When(x => x.UserId.HasValue);
        }
    }
}
