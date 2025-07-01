using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.NoteValidators.Own
{
    public class UpdateNoteOwnDtoValidator : AbstractValidator<UpdateNoteOwnDto>
    {
        public UpdateNoteOwnDtoValidator()
        {
            RuleFor(x => x.NoteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Note ID is required.");

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Note text cannot be empty.")
                .When(x => x.Text is not null);
        }
    }
}
