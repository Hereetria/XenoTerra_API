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
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices
{
    public class PostLikeWriteService(
            IWriteRepository<PostLike, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreatePostLikeDto> createValidator,
            IValidator<UpdatePostLikeDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<PostLike, CreatePostLikeDto, UpdatePostLikeDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IPostLikeWriteService
    {
        protected override Task PreCreateAsync(CreatePostLikeDto createDto)
        {
            createDto.LikedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}

