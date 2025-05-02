using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.ViewStoryValidators
{
    public class CreateViewStoryDtoValidator : AbstractValidator<CreateViewStoryDto>
    {
        public CreateViewStoryDtoValidator()
        {
        }
    }
}
