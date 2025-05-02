using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryHighlightValidators
{
    public class UpdateStoryHighlightDtoValidator : AbstractValidator<UpdateStoryHighlightDto>
    {
        public UpdateStoryHighlightDtoValidator()
        {
        }
    }
}
