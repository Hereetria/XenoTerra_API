using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.NoteValidators.Admin
{
    public class UpdateNoteAdminDtoValidator : AbstractValidator<UpdateNoteAdminDto>
    {
        public UpdateNoteAdminDtoValidator()
        {
            RuleFor(x => x.NoteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Note ID is required.");

            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Note text cannot be empty.")
                .When(x => x.Text is not null);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.")
                .When(x => x.UserId.HasValue);
        }
    }
}
