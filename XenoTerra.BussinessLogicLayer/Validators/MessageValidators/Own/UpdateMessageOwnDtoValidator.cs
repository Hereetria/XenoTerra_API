using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.MessageValidators.Own
{
    public class UpdateMessageOwnDtoValidator : AbstractValidator<UpdateMessageOwnDto>
    {
        public UpdateMessageOwnDtoValidator()
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

            RuleFor(x => x.Header)
                .NotEmpty()
                .WithMessage("Message header cannot be empty.")
                .When(x => x.Header is not null);
        }
    }
}
