using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.MessageValidators
{
    public class CreateMessageDtoValidator : AbstractValidator<CreateMessageDto>
    {
        public CreateMessageDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content must not be empty.");

            RuleFor(x => x.SenderId)
                .NotEmpty()
                .WithMessage("SenderId must not be empty.");

            RuleFor(x => x.ReceiverId)
                .NotEmpty()
                .WithMessage("ReceiverId must not be empty.");

            RuleFor(x => x.SentAt)
                .NotEmpty()
                .WithMessage("SentAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("SentAt cannot be in the future.");
        }
    }
}
