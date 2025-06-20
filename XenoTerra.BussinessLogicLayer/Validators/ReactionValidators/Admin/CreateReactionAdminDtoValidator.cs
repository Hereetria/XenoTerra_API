using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReactionAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.ReactionValidators.Admin
{
    public class CreateReactionAdminDtoValidator : AbstractValidator<CreateReactionAdminDto>
    {
        public CreateReactionAdminDtoValidator()
        {
            RuleFor(x => x.Payload)
                .NotEmpty()
                .WithMessage("Reaction payload is required.")
                .MaximumLength(100)
                .WithMessage("Payload is too long.");

            RuleFor(x => x.MessageId)
                .NotEqual(Guid.Empty)
                .WithMessage("Message ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");
        }
    }
}
