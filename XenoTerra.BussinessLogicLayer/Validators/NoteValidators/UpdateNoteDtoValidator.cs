using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.NoteValidators
{
    public class UpdateNoteDtoValidator : AbstractValidator<UpdateNoteDto>
    {
        public UpdateNoteDtoValidator()
        {
            RuleFor(x => x.NoteId)
                .NotEmpty()
                .WithMessage("NoteId must not be empty.");

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty()
                .WithMessage("CreatedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("CreatedAt cannot be in the future.");
        }
    }
}
