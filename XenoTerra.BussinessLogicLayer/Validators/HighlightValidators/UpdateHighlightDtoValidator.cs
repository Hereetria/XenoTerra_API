using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators
{
    public class UpdateHighlightDtoValidator : AbstractValidator<UpdateHighlightDto>
    {
        public UpdateHighlightDtoValidator()
        {
        }
    }
}
