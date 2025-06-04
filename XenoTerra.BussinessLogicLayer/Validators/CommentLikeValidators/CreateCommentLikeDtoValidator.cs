using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentLikeValidators
{
    public class CreateCommentLikeDtoValidator : AbstractValidator<CreateCommentLikeDto>
    {
        public CreateCommentLikeDtoValidator()
        {
        }
    }
}
