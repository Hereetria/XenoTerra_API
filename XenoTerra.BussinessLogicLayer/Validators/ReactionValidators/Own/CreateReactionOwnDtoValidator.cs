using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.ReactionValidators.Own
{
    public class CreateReactionOwnDtoValidator : AbstractValidator<CreateReactionOwnDto>
    {
        public CreateReactionOwnDtoValidator()
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
