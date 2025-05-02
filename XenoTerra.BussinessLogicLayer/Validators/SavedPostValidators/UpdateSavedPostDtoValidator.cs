using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.SavedPostValidators
{
    public class UpdateSavedPostDtoValidator : AbstractValidator<UpdateSavedPostDto>
    {
        public UpdateSavedPostDtoValidator()
        {
        }
    }
}
