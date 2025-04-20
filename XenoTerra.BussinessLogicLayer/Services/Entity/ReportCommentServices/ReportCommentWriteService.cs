using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService
{
    public class ReportCommentWriteService(
            IWriteRepository<ReportComment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportCommentDto> createValidator,
            IValidator<UpdateReportCommentDto> updateValidator
        )
            : WriteService<ReportComment, CreateReportCommentDto, UpdateReportCommentDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IReportCommentWriteService
    {
    }
}
