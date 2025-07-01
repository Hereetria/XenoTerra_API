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
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentServices.Write.Admin
{
    public class ReportCommentAdminWriteService(
            IWriteRepository<ReportComment, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportCommentAdminDto> createValidator,
            IValidator<UpdateReportCommentAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportComment, CreateReportCommentAdminDto, UpdateReportCommentAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportCommentAdminWriteService
    {
        protected override Task PreCreateAsync(CreateReportCommentAdminDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
