using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.MessageValidators
{
    public class UpdateMessageDtoValidator : AbstractValidator<UpdateMessageDto>
    {
        public UpdateMessageDtoValidator()
        {
        }
    }
}
