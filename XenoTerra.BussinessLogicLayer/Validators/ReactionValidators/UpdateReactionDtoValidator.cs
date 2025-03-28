using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.ReactionValidators
{
    public class UpdateReactionDtoValidator : AbstractValidator<UpdateReactionDto>
    {
        public UpdateReactionDtoValidator()
        {
            RuleFor(x => x.ReactionId)
                .NotEmpty()
                .WithMessage("ReactionId must not be empty.");

            RuleFor(x => x.Payload)
                .NotEmpty()
                .WithMessage("Payload must not be empty.");

            RuleFor(x => x.MessageId)
                .NotEmpty()
                .WithMessage("MessageId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");
        }
    }
}
