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
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices.Write.Own
{
    public class ViewStoryOwnWriteService(
            IWriteRepository<ViewStory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateViewStoryOwnDto> createValidator,
            IValidator<UpdateViewStoryOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<ViewStory, CreateViewStoryOwnDto, UpdateViewStoryOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IViewStoryOwnWriteService
    {
        protected override Task PreCreateAsync(CreateViewStoryOwnDto createDto)
        {
            createDto.ViewedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
