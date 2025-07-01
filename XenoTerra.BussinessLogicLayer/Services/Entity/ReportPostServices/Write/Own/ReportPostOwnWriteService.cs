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
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices.Write.Own
{
    public class ReportPostOwnWriteService(
            IWriteRepository<ReportPost, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportPostOwnDto> createValidator,
            IValidator<UpdateReportPostOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportPost, CreateReportPostOwnDto, UpdateReportPostOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportPostOwnWriteService
    {
        protected override Task PreCreateAsync(CreateReportPostOwnDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
