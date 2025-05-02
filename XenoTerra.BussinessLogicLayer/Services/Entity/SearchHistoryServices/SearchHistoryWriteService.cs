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
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService
{
    public class SearchHistoryWriteService(
            IWriteRepository<SearchHistory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSearchHistoryDto> createValidator,
            IValidator<UpdateSearchHistoryDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<SearchHistory, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ISearchHistoryWriteService
    {
        protected override Task PreUpdateAsync(UpdateSearchHistoryDto updateDto)
        {
            updateDto.SearchedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
