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
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Write.Own
{
    public class StoryLikeOwnWriteService(
            IWriteRepository<StoryLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateStoryLikeOwnDto> createValidator,
            IValidator<UpdateStoryLikeOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<StoryLike, CreateStoryLikeOwnDto, UpdateStoryLikeOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IStoryLikeOwnWriteService
    {
        protected override Task PreCreateAsync(CreateStoryLikeOwnDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

