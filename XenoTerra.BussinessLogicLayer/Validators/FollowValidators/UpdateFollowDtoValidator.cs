using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.FollowValidators
{
    public class UpdateFollowDtoValidator : AbstractValidator<UpdateFollowDto>
    {
        public UpdateFollowDtoValidator()
        {
        }
    }
}
