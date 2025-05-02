using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.BlockUserValidators
{
    public class CreateBlockUserDtoValidator : AbstractValidator<CreateCommentckUserDto>
    {
        public CreateBlockUserDtoValidator()
        {
        }
    }

}
