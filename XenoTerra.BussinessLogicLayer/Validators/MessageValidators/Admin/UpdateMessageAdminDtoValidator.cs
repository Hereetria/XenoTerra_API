using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.MessageValidators.Admin
{
    public class UpdateMessageAdminDtoValidator : AbstractValidator<UpdateMessageAdminDto>
    {
        public UpdateMessageAdminDtoValidator()
        {
            RuleFor(x => x.MessageId)
                .NotEqual(Guid.Empty)
                .WithMessage("Message ID is required.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Message content cannot be empty.")
                .MaximumLength(500)
                .WithMessage("Last message cannot exceed 500 characters.")
                .When(x => x.Content is not null);

            RuleFor(x => x.SenderId)
                .NotEqual(Guid.Empty)
                .WithMessage("Sender ID cannot be empty.")
                .When(x => x.SenderId.HasValue);

            RuleFor(x => x.ReceiverId)
                .NotEqual(Guid.Empty)
                .WithMessage("Receiver ID is required.");

            RuleFor(x => x.Header)
                .NotEmpty()
                .WithMessage("Message header cannot be empty.")
                .When(x => x.Header is not null);
        }
    }
}
