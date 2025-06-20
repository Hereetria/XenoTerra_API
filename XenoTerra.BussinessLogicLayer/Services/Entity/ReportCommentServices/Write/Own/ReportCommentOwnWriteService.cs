using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ReportCommentAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices.Write.Own
{
    public class ReportCommentOwnWriteService(
            IWriteRepository<ReportComment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportCommentOwnDto> createValidator,
            IValidator<UpdateReportCommentOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportComment, CreateReportCommentOwnDto, UpdateReportCommentOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportCommentOwnWriteService
    {
        protected override Task PreCreateAsync(CreateReportCommentOwnDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
