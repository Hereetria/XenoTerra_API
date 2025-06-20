using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.MessageValidators.Admin
{
    public class CreateMessageAdminDtoValidator : AbstractValidator<CreateMessageAdminDto>
    {
        public CreateMessageAdminDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Message content is required.")
                .MaximumLength(500)
                .WithMessage("Last message cannot exceed 500 characters.");

            RuleFor(x => x.Header)
                .NotEmpty()
                .WithMessage("Message header is required.");

            RuleFor(x => x.SenderId)
                .NotEqual(Guid.Empty)
                .WithMessage("Sender ID is required.");

            RuleFor(x => x.ReceiverId)
                .NotEqual(Guid.Empty)
                .WithMessage("Receiver ID is required.");

            RuleFor(x => x.SentAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Sent time cannot be in the future.");
        }
    }
}
