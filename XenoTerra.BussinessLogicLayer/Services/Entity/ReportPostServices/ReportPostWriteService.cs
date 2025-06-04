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
using XenoTerra.DTOLayer.Dtos.ReportPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ReportPostServices
{
    public class ReportPostWriteService(
            IWriteRepository<ReportPost, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateReportPostDto> createValidator,
            IValidator<UpdateReportPostDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ReportPost, CreateReportPostDto, UpdateReportPostDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IReportPostWriteService
    {
        protected override Task PreCreateAsync(CreateReportPostDto createDto)
        {
            createDto.ReportedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
