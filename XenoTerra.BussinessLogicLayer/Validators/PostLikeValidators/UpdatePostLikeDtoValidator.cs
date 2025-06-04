using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.PostLikeValidators
{
    public class UpdatePostLikeDtoValidator : AbstractValidator<UpdatePostLikeDto>
    {
        public UpdatePostLikeDtoValidator()
        {
        }
    }
}
