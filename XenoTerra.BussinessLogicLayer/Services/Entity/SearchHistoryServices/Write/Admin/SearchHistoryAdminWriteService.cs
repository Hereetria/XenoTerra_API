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
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices.Write.Admin
{
    public class SearchHistoryAdminWriteService(
            IWriteRepository<SearchHistory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateSearchHistoryAdminDto> createValidator,
            IValidator<UpdateSearchHistoryAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<SearchHistory, CreateSearchHistoryAdminDto, UpdateSearchHistoryAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            ISearchHistoryAdminWriteService
    {
        protected override Task PreUpdateAsync(UpdateSearchHistoryAdminDto updateDto)
        {
            updateDto.SearchedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
