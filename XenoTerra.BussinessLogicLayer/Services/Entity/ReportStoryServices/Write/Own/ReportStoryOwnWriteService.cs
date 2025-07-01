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
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportStoryServices.Write.Own
{
    public class ReportStoryOwnWriteService(
            IWriteRepository<ReportStory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportStoryOwnDto> createValidator,
            IValidator<UpdateReportStoryOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportStory, CreateReportStoryOwnDto, UpdateReportStoryOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportStoryOwnWriteService
    {
        protected override Task PreCreateAsync(CreateReportStoryOwnDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

