using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.ReactionValidators.Own
{
    public class UpdateReactionOwnDtoValidator : AbstractValidator<UpdateReactionOwnDto>
    {
        public UpdateReactionOwnDtoValidator()
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
        }
    }
}
