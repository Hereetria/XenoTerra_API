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
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Write.Admin
{
    public class ReportStoryAdminWriteService(
            IWriteRepository<ReportStory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportStoryAdminDto> createValidator,
            IValidator<UpdateReportStoryAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportStory, CreateReportStoryAdminDto, UpdateReportStoryAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportStoryAdminWriteService
    {
        protected override Task PreCreateAsync(CreateReportStoryAdminDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

