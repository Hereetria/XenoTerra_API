using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.LikeValidators
{
    public class CreateLikeDtoValidator : AbstractValidator<CreateLikeDto>
    {
        public CreateLikeDtoValidator()
        {
        }
    }
}
