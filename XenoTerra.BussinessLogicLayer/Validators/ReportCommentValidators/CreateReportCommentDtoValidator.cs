using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportCommentValidators
{
    public class CreateReportCommentDtoValidator : AbstractValidator<CreateReportCommentDto>
    {
        public CreateReportCommentDtoValidator()
        {
        }
    }
}
