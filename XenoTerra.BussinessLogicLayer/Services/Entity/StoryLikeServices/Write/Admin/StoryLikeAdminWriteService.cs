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
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Write.Admin
{
    public class StoryLikeAdminWriteService(
            IWriteRepository<StoryLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateStoryLikeAdminDto> createValidator,
            IValidator<UpdateStoryLikeAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<StoryLike, CreateStoryLikeAdminDto, UpdateStoryLikeAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IStoryLikeAdminWriteService
    {
        protected override Task PreCreateAsync(CreateStoryLikeAdminDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

