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
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices.Write.Own
{
    public class SearchHistoryOwnWriteService(
            IWriteRepository<SearchHistory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSearchHistoryOwnDto> createValidator,
            IValidator<UpdateSearchHistoryOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<SearchHistory, CreateSearchHistoryOwnDto, UpdateSearchHistoryOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ISearchHistoryOwnWriteService
    {
        protected override Task PreUpdateAsync(UpdateSearchHistoryOwnDto updateDto)
        {
            updateDto.SearchedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
