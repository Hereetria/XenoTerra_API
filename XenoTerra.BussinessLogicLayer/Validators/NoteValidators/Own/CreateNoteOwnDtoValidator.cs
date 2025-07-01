using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.NoteValidators.Own
{
    public class CreateNoteOwnDtoValidator : AbstractValidator<CreateNoteOwnDto>
    {
        public CreateNoteOwnDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Note text is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Created time cannot be in the future.");
        }
    }
}
