using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.RecentChatsValidators
{
    public class UpdateRecentChatsDtoValidator : AbstractValidator<UpdateRecentChatsDto>
    {
        public UpdateRecentChatsDtoValidator()
        {
        }
    }
}
