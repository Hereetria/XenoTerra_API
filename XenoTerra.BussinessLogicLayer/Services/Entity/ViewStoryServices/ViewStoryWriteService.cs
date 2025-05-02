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
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService
{
    public class ViewStoryWriteService(
            IWriteRepository<ViewStory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateViewStoryDto> createValidator,
            IValidator<UpdateViewStoryDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ViewStory, CreateViewStoryDto, UpdateViewStoryDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IViewStoryWriteService
    {
        protected override Task PreCreateAsync(CreateViewStoryDto createDto)
        {
            createDto.ViewedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
