using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.MediaValidators
{
    public class UpdateMediaDtoValidator : AbstractValidator<UpdateMediaDto>
    {
        public UpdateMediaDtoValidator()
        {
        }
    }
}
