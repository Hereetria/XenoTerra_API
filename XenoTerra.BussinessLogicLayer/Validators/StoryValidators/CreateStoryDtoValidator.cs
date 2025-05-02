using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryValidators
{
    public class CreateStoryDtoValidator : AbstractValidator<CreateStoryDto>
    {
        public CreateStoryDtoValidator()
        {
        }
    }
}
