using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryValidators.Own
{
    public class CreateStoryOwnDtoValidator : AbstractValidator<CreateStoryOwnDto>
    {
        public CreateStoryOwnDtoValidator()
        {
        }
    }
}
