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
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Write.Own
{
    public class PostLikeOwnWriteService(
            IWriteRepository<PostLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreatePostLikeOwnDto> createValidator,
            IValidator<UpdatePostLikeOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<PostLike, CreatePostLikeOwnDto, UpdatePostLikeOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IPostLikeOwnWriteService
    {
        protected override Task PreCreateAsync(CreatePostLikeOwnDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

