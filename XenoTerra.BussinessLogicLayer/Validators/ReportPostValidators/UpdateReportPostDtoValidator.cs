using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportPostValidators
{
    public class UpdateReportPostDtoValidator : AbstractValidator<UpdateReportPostDto>
    {
        public UpdateReportPostDtoValidator()
        {
        }
    }
}
