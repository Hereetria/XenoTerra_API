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
using XenoTerra.DTOLayer.Dtos.ReportPostAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices.Write.Admin
{
    public class ReportPostAdminWriteService(
            IWriteRepository<ReportPost, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportPostAdminDto> createValidator,
            IValidator<UpdateReportPostAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportPost, CreateReportPostAdminDto, UpdateReportPostAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportPostAdminWriteService
    {
        protected override Task PreCreateAsync(CreateReportPostAdminDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
